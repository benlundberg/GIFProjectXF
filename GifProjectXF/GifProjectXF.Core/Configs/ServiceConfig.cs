namespace GifProjectXF.Core
{
    public class ServiceConfig
    {
        private const string API_KEY = "0dFrqmHiEL2rZ1VR6nR4TPeAVoIHVSYA";

        public const string TRENDING = "https://api.giphy.com/v1/gifs/trending?api_key=" + API_KEY + "&limit=25&rating=G";
        public const string SEARCH = "https://api.giphy.com/v1/gifs/search?api_key=" + API_KEY + "&q={0}&limit=25&offset=0&rating=G&lang=en";
    }
}
