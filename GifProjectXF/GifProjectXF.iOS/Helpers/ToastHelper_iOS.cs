using System.Windows.Input;
using GifProjectXF.Core;
using Xamarin.Forms;

namespace GifProjectXF.iOS
{
    public class ToastHelper_iOS : IToastHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="toastTime"></param>
        /// <param name="snackbar"></param>
        /// <param name="command"></param>
        public void DisplayToast(string text, ToastTime toastTime = ToastTime.SHORT, bool snackbar = false, ICommand command = null)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("", text, "Ok");
            });
        }
    }
}
