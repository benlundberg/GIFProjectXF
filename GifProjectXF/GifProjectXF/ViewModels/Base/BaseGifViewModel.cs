using GifProjectXF.Core;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace GifProjectXF
{
    public class BaseGifViewModel : BaseViewModel, IDisposable
    {
        public BaseGifViewModel()
        {
            gifManager = ComponentContainer.Current.Resolve<IGifManager>();

            // Events for adding and removing from favourite list
            gifManager.AddedAsFavouriteEvent += GifManager_AddedAsFavouriteEvent;
            gifManager.RemovedAsFavouriteEvent += GifManager_RemovedAsFavouriteEvent;
        }

        private void GifManager_RemovedAsFavouriteEvent(object sender, GifItem gifItem)
        {
            var item = GifItems?.FirstOrDefault(x => x.Id == gifItem.Id);

            if (item != null)
            {
                item.IsFavourite = false;
            }
        }

        private void GifManager_AddedAsFavouriteEvent(object sender, GifItem gifItem)
        {
            var item = GifItems?.FirstOrDefault(x => x.Id == gifItem.Id);

            if (item != null)
            {
                item.IsFavourite = true;
            }
        }

        public void Dispose()
        {
            gifManager.AddedAsFavouriteEvent -= GifManager_AddedAsFavouriteEvent;
            gifManager.RemovedAsFavouriteEvent -= GifManager_RemovedAsFavouriteEvent;

            GC.Collect();
        }

        private ICommand itemDisappearCommand;
        public ICommand ItemDisappearCommand => itemDisappearCommand ?? (itemDisappearCommand = new Command((param) =>
        {
            if (!(param is ItemVisibilityEventArgs eventArgs))
            {
                return;
            }

            if (!(eventArgs.Item is GifItemViewModel item))
            {
                return;
            }

            item.IsVisible = false;

            item.Stop();
        }));

        private ICommand itemAppearCommand;
        public ICommand ItemAppearCommand => itemAppearCommand ?? (itemAppearCommand = new Command(async (param) =>
        {
            if (!(param is ItemVisibilityEventArgs eventArgs))
            {
                return;
            }

            if (!(eventArgs.Item is GifItemViewModel item))
            {
                return;
            }

            item.IsVisible = true;

            await Task.Delay(TimeSpan.FromSeconds(1));

            item.Play();
        }));

        private ICommand favouriteCommand;
        public ICommand FavouriteCommand => favouriteCommand ?? (favouriteCommand = new Command(async (param) =>
        {
            if (!(param is GifItemViewModel item))
            {
                return;
            }

            item.IsFavourite = !item.IsFavourite;

            if (item.IsFavourite)
            {
                await gifManager.SaveFavouriteGifAsync(new GifItem()
                {
                    Id = item.Id,
                    GifSource = item.GifSource,
                    StillImage = item.StillImage,
                    Title = item.Title
                });
            }
            else
            {
                await gifManager.RemoveFavouriteGifAsync(new GifItem()
                {
                    Id = item.Id,
                    GifSource = item.GifSource,
                    StillImage = item.StillImage,
                    Title = item.Title
                });
            }
        }));

        private ICommand shareCommand;
        public ICommand ShareCommand => shareCommand ?? (shareCommand = new Command(async (param) =>
        {
            if (!(param is GifItemViewModel item))
            {
                return;
            }

            await Share.RequestAsync(new ShareTextRequest()
            {
                Title = item.Title,
                Uri = item.GifSource
            });
        }));

        public ObservableCollection<GifItemViewModel> GifItems { get; set; }

        protected readonly IGifManager gifManager;
    }
}
