using Android.Content;
using GifProjectXF;
using GifProjectXF.Android;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ExtendedWebView), typeof(ExtendedWebViewRenderer_Droid))]
namespace GifProjectXF.Android
{
    public class ExtendedWebViewRenderer_Droid : WebViewRenderer
    {
        public ExtendedWebViewRenderer_Droid(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<WebView> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                var webview = Element as ExtendedWebView;
                Control.Settings.AllowUniversalAccessFromFileURLs = true;
                Control.LoadUrl(webview.Url);
            }
        }
    }
}