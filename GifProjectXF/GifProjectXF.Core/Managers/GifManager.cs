using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GifProjectXF.Core
{
    public class GifManager : IGifManager
    {
        public GifManager(ITrendingService trendingService, ISearchService searchService, IDatabaseRepository databaseRepository)
        {
            this.trendingService = trendingService;
            this.searchService = searchService;
            this.databaseRepository = databaseRepository;
        }

        public Task<TrendingGif> LoadTrendingGifsAsync()
        {
            return trendingService.GetTrendingGifsAsync();
        }

        public Task<TrendingGif> SearchGifsAsync(string searchWord)
        {
            return searchService.SearchGifsAsync(searchWord);
        }

        public Task<bool> SaveFavouriteGifAsync(GifItem gif)
        {
            AddedAsFavouriteEvent?.Invoke(this, gif);
            return databaseRepository.InsertOrReplaceAsync(gif);
        }

        public Task<bool> RemoveFavouriteGifAsync(GifItem gif)
        {
            RemovedAsFavouriteEvent?.Invoke(this, gif);
            return databaseRepository.DeleteAsync(gif);
        }

        public Task<IEnumerable<GifItem>> LoadFavouriteGifsAsync()
        {
            return databaseRepository.LoadAllAsync<GifItem>();
        }

        private readonly ISearchService searchService;
        private readonly ITrendingService trendingService;
        private readonly IDatabaseRepository databaseRepository;

        public event EventHandler<GifItem> AddedAsFavouriteEvent;
        public event EventHandler<GifItem> RemovedAsFavouriteEvent;
    }
}
