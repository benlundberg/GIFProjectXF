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
    public class FavouriteViewModel : BaseGifViewModel
    {
        public FavouriteViewModel()
        {
            if (NetStatusHelper.IsConnected)
            {
                LoadFavouriteGifs();
            }
            else
            {
                ShowNoNetworkError();
            }

            gifManager.RemovedAsFavouriteEvent += GifManager_RemovedAsFavouriteEvent;
            gifManager.AddedAsFavouriteEvent += GifManager_AddedAsFavouriteEvent;
        }

        private void GifManager_AddedAsFavouriteEvent(object sender, GifItem gifItem)
        {
            var item = GifItems?.FirstOrDefault(x => x.Id == gifItem.Id);

            if (item == null)
            {
                GifItems.Add(new GifItemViewModel(gifItem));
            }
        }

        private void GifManager_RemovedAsFavouriteEvent(object sender, GifItem gifItem)
        {
            var item = GifItems?.FirstOrDefault(x => x.Id == gifItem.Id);

            if (item != null)
            {
                GifItems?.Remove(item);
            }
        }

        private void LoadFavouriteGifs()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                if (IsBusy)
                {
                    return;
                }

                try
                {
                    IsBusy = true;

                    var favouriteGifs = await gifManager.LoadFavouriteGifsAsync();

                    GifItems = new ObservableCollection<GifItemViewModel>(favouriteGifs.Select(x => new GifItemViewModel(x)));
                }
                catch (Exception ex)
                {
                    ex.Print();

                    ShowAlert(ex.Message, "");
                }
                finally
                {
                    IsBusy = false;
                }
            });
        }
    }
}
