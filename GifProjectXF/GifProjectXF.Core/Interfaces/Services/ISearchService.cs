using System.Threading.Tasks;

namespace GifProjectXF.Core
{
    public interface ISearchService
    {
        Task<TrendingGif> SearchGifsAsync(string searchWord);
    }
}
