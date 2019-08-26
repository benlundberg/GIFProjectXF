using SQLite;

namespace GifProjectXF.Core
{
    public class GifItem
    {
        [PrimaryKey]
        public string Id { get; set; }
        public string Title { get; set; }
        public string StillImage { get; set; }
        public string GifSource { get; set; }
    }
}
