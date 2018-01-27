using MvvmCross.Core.ViewModels;

namespace MvvmCrossGroupedTableView.ViewModels
{
    public class MainViewModel : MvxViewModel
    {

        public MainViewModel()
        {
        }

        public MvxObservableCollection<MvxObservableCollection<CustomCellViewModel>> MyData
        {
            get 
            {
                var firstGroup = new MvxObservableCollection<CustomCellViewModel>();
                var secondGroup = new MvxObservableCollection<CustomCellViewModel>();

                firstGroup.Add(new CustomCellViewModel("Section: 0, Row: 0"));
                firstGroup.Add(new CustomCellViewModel("Section: 0, Row: 1"));
                firstGroup.Add(new CustomCellViewModel("Section: 0, Row: 2"));

                secondGroup.Add(new CustomCellViewModel("Section: 1, Row: 0"));
                secondGroup.Add(new CustomCellViewModel("Section: 1, Row: 1"));
                secondGroup.Add(new CustomCellViewModel("Section: 1, Row: 2"));
                secondGroup.Add(new CustomCellViewModel("Section: 1, Row: 3"));

                return new MvxObservableCollection<MvxObservableCollection<CustomCellViewModel>>()
                {
                    firstGroup, secondGroup
                };
            }
        }

    }
}
