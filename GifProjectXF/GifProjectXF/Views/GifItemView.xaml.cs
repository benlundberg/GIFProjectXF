using FFImageLoading.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GifProjectXF
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GifItemView : ContentView
    {
        public GifItemView()
        {
            InitializeComponent();

            InitializeView();
        }

        private void InitializeView()
        {
            if (viewInitialized)
            {
                return;
            }

            if (Device.RuntimePlatform == Device.UWP)
            {
                Image = new Image
                {
                    Aspect = Aspect.AspectFit,
                };

                Content = Image;
            }
            else
            {
                CachedImage = new CachedImage
                {
                    Aspect = Aspect.AspectFit,
                    FadeAnimationEnabled = true,
                    LoadingDelay = 1000
                };

                Content = CachedImage;
            }

            viewInitialized = true;
        }

        private static void SourceChanged(BindableObject bindableObject, string oldValue, string newValue)
        {
            if (!(bindableObject is GifItemView view))
            {
                return;
            }

            if (!(view.BindingContext is GifItemViewModel viewModel))
            {
                return;
            }

            view.InitializeView();

            if (Device.RuntimePlatform == Device.UWP && view.Image != null)
            {
                view.Image.Source = viewModel.Path;
            }
            else if (view.CachedImage != null)
            {
                view.CachedImage.Source = viewModel.Path;
            }
        }

        public string Source
        {
            get { return (string)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        public static readonly BindableProperty SourceProperty = BindableProperty.Create(
            propertyName: "Source",
            returnType: typeof(string),
            declaringType: typeof(GifItemView),
            defaultValue: default(string),
            propertyChanged: (bindableObject, oldValue, newValue) =>
            {
                SourceChanged(bindableObject, (string)oldValue, (string)newValue);
            });

        public CachedImage CachedImage { get; set; }
        public Image Image { get; set; }

        private bool viewInitialized;
    }
}