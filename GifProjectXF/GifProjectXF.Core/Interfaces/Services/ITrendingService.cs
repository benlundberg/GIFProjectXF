using System.Threading.Tasks;

namespace GifProjectXF.Core
{
    public interface ITrendingService
    {
        Task<TrendingGif> GetTrendingGifsAsync();
    }
}
