using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace GifProjectXF.Core
{
    public class SearchService : BaseService, ISearchService
    {
        public async Task<TrendingGif> SearchGifsAsync(string searchWord)
        {
            try
            {
                string url = string.Format(ServiceConfig.SEARCH, searchWord);

                var response = await MakeRequestAsync(url, HttpMethod.Get);

                if (response.ResultStatusCode != System.Net.HttpStatusCode.OK)
                {
                    throw new Exception(response.Data?.ToString());
                }

                return TrendingGif.FromJson(response.Data.ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
