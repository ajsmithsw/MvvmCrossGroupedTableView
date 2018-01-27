using System;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.ExtensionMethods;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters.Attributes;
using MvvmCross.Platform.Core;
using MvvmCrossGroupedTableView.iOS.Views.Cells;
using MvvmCrossGroupedTableView.ViewModels;
using UIKit;

namespace MvvmCrossGroupedTableView.iOS.Views
{
    [MvxRootPresentation(WrapInNavigationController = true)]
    public partial class MainView : MvxViewController<MainViewModel>
    {
        public MainView() : base("MainView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            Title = "Grouped Table View";

            var myTableViewSource = new CustomTableViewSource(MyTableView);
            MyTableView.Source = myTableViewSource;

            var set = this.CreateBindingSet<MainView, MainViewModel>();
            set.Bind(myTableViewSource).To(vm => vm.MyData);
            set.Apply();

            MyTableView.ReloadData();
        }
    }


    public class CustomTableViewSource : MvxTableViewSource
    {
        public CustomTableViewSource(UITableView tableView) : base(tableView)
        {
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var group = ItemsSource.ElementAt(indexPath.Section) as MvxObservableCollection<CustomCellViewModel>;
            var item = group.ElementAt(indexPath.Row) as CustomCellViewModel;

            var cell = GetOrCreateCellFor(tableView, indexPath, item);

            return cell;
        }

        protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
        {
            var cell = tableView.DequeueReusableCell(CustomCell.Key) as CustomCell;

            if (cell == null)
            {
                cell = CustomCell.Create();
            }

            var bindable = cell as IMvxDataConsumer;
            if (bindable != null)
                bindable.DataContext = item;

            return cell;
        }

        public override System.nint NumberOfSections(UITableView tableView)
        {
            return ItemsSource.Count();
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            var group = ItemsSource.ElementAt((int)section) as MvxObservableCollection<CustomCellViewModel>;
            return group.Count();
        }

        public override string TitleForHeader(UITableView tableView, nint section)
        {
            return string.Format($"Header for section {section}");
        }
    }
}
