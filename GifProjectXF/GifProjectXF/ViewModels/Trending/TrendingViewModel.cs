using GifProjectXF.Core;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace GifProjectXF
{
    public class TrendingViewModel : BaseGifViewModel
    {
        public TrendingViewModel()
        {
            if (NetStatusHelper.IsConnected)
            {
                LoadTrendingGifs();
            }
            else
            {
                ShowNoNetworkError();
            }
        }

        private void LoadTrendingGifs()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                if (IsBusy)
                {
                    return;
                }

                if (GifItems?.Any() == true)
                {
                    return;
                }

                try
                {
                    IsBusy = true;

                    var trendingGifs = await gifManager.LoadTrendingGifsAsync();

                    var favouriteGifs = await gifManager.LoadFavouriteGifsAsync();

                    GifItems = new ObservableCollection<GifItemViewModel>(trendingGifs.Data.Select(x => new GifItemViewModel(x)
                    {
                        IsFavourite = favouriteGifs.Any(i => i.Id == x.Id),
                    }));
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
