using GifProjectXF.Core;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace GifProjectXF
{
    public class SearchViewModel : BaseGifViewModel
    {
        public SearchViewModel()
        {
        }

        private ICommand searchCommand;
        public ICommand SearchCommand => searchCommand ?? (searchCommand = new Command(() =>
        {
            try
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

                        var gifs = await gifManager.SearchGifsAsync(SearchWord);

                        var favouriteGifs = await gifManager.LoadFavouriteGifsAsync();

                        GifItems = new ObservableCollection<GifItemViewModel>(gifs.Data.Select(x => new GifItemViewModel(x)
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
            catch (Exception ex)
            {
                ex.Print();
            }
        }));

        public string SearchWord { get; set; }
    }
}
