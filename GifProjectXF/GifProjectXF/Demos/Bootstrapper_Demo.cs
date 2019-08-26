using GifProjectXF.Demos.UI.GridView;
using GifProjectXF.Demos.UI.Login;
using GifProjectXF.Demos.UI.ForgotPassword;
using GifProjectXF.Demos.UI.List;
using GifProjectXF.Demos.UI.Register;
using GifProjectXF.Demos.UI.Details;

namespace GifProjectXF.Demos
{
    public class Bootstrapper_Demo
    {
        public static void Init()
        {
            ViewContainer.Current.Register<LoginViewModel, LoginPage>();
            ViewContainer.Current.Register<ListViewModel, ListPage>();
            ViewContainer.Current.Register<GridViewModel, GridPage>();
            ViewContainer.Current.Register<ForgotPasswordViewModel, ForgotPasswordPage>();
            ViewContainer.Current.Register<RegisterViewModel, RegisterPage>();
            ViewContainer.Current.Register<DetailsViewModel, DetailsPage>();
        }
    }
}
