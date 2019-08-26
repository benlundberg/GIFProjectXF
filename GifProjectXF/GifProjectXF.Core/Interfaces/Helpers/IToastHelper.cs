using System.Windows.Input;

namespace GifProjectXF.Core
{
    public enum ToastTime
    {
        SHORT,
        LONG
    }

    public interface IToastHelper
    {
        void DisplayToast(string text, ToastTime toastTime = ToastTime.SHORT, bool snackbar = false, ICommand command = null);
    }
}
