using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GifProjectXF.Core
{
    public interface IGifManager
    {
        Task<TrendingGif> LoadTrendingGifsAsync();
        Task<TrendingGif> SearchGifsAsync(string searchWord);
        Task<bool> SaveFavouriteGifAsync(GifItem gif);
        Task<bool> RemoveFavouriteGifAsync(GifItem gif);
        Task<IEnumerable<GifItem>> LoadFavouriteGifsAsync();

        event EventHandler<GifItem> AddedAsFavouriteEvent;
        event EventHandler<GifItem> RemovedAsFavouriteEvent;
    }
}
