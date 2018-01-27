using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.UI;

namespace MvvmCrossGroupedTableView.ViewModels
{
    public class CustomCellViewModel : MvxViewModel
    {
        string _text;

        public CustomCellViewModel(string text)
        {
            _text = text;
        }

        public string Text
        {
            get => _text;
            set => SetProperty(ref _text, value);
        }
    }
}
