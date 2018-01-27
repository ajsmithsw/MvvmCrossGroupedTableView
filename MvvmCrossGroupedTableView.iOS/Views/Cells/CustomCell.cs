using System;

using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCrossGroupedTableView.ViewModels;
using MvvmCross.Plugins.Color;
using UIKit;

namespace MvvmCrossGroupedTableView.iOS.Views.Cells
{
    public partial class CustomCell : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString("CustomCell");
        public static readonly UINib Nib = Nib = UINib.FromName("CustomCell", NSBundle.MainBundle);

        public static CustomCell Create()
        {
            return Nib.Instantiate(null, null)[0] as CustomCell;
        }

        protected CustomCell(IntPtr handle) : base(handle)
        {
            this.DelayBind(() => {
                var set = this.CreateBindingSet<CustomCell, CustomCellViewModel>();
                set.Bind(TextLabel).To(vm => vm.Text);
                set.Apply();
            });
        }
    }
}
