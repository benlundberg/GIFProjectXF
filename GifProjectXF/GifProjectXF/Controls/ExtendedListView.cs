using System.Windows.Input;
using Xamarin.Forms;

namespace GifProjectXF.Controls
{
    public class ExtendedListView : ListView
    {
        public ExtendedListView() : base(ListViewCachingStrategy.RecycleElement)
        {
            this.ItemAppearing += ExtendedListView_ItemAppearing;
            this.ItemDisappearing += ExtendedListView_ItemDisappearing;
        }

        private void ExtendedListView_ItemDisappearing(object sender, ItemVisibilityEventArgs e)
        {
            ItemDisappearCommand?.Execute(e);
        }

        private void ExtendedListView_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            ItemAppearCommand?.Execute(e);
        }

        public static readonly BindableProperty ItemDisappearCommandProperty = BindableProperty.Create(
            propertyName: "ItemDisappearCommand",
            returnType: typeof(ICommand),
            declaringType: typeof(ExtendedListView),
            defaultValue: default(ICommand));

        public ICommand ItemDisappearCommand
        {
            get { return (ICommand)GetValue(ItemDisappearCommandProperty); }
            set { SetValue(ItemDisappearCommandProperty, value); }
        }

        public static readonly BindableProperty ItemAppearCommandProperty = BindableProperty.Create(
            propertyName: "ItemAppearCommand",
            returnType: typeof(ICommand),
            declaringType: typeof(ExtendedListView),
            defaultValue: default(ICommand));

        public ICommand ItemAppearCommand
        {
            get { return (ICommand)GetValue(ItemAppearCommandProperty); }
            set { SetValue(ItemAppearCommandProperty, value); }
        }
    }
}
