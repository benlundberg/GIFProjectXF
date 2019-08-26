using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace GifProjectXF.Core
{
    public class TrendingService : BaseService, ITrendingService
    {
        public async Task<TrendingGif> GetTrendingGifsAsync()
        {
            try
            {
                var response = await MakeRequestAsync(ServiceConfig.TRENDING, HttpMethod.Get);

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
