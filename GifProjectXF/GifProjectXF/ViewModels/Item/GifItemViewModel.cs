using GifProjectXF.Core;
using System.ComponentModel;

namespace GifProjectXF
{
    public class GifItemViewModel : INotifyPropertyChanged
    {
        public GifItemViewModel(Datum gif)
        {
            Id = gif.Id;
            Title = gif.Title?.ToUpper();
            GifSource = gif.Images.Original.Url.AbsoluteUri;
            StillImage = gif.Images.FixedWidthStill.Url.AbsoluteUri;
        }

        public GifItemViewModel(GifItem gifItem)
        {
            Id = gifItem.Id;
            Title = gifItem.Title?.ToUpper();
            IsFavourite = true;
            GifSource = gifItem.GifSource;
            StillImage = gifItem.StillImage;
        }
        
        public string Id { get; set; }
        public string Title { get; set; }
        public string StillImage { get; set; }
        public string GifSource { get; set; }
        public string Path { get; private set; }
        public bool IsFavourite { get; set; }
        public bool IsVisible { get; set; }

        public void Play()
        {
            if (!IsVisible)
            {
                Stop();
                return;
            }

            Path = GifSource;
        }

        public void Stop()
        {
            Path = StillImage;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
