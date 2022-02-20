using DateCheck.ViewModels;
using System.Windows.Controls;

namespace DateCheck.Views
{
    /// <summary>
    /// Interaction logic for DateInputView.xaml
    /// </summary>
    /// 
    
    public partial class DateInputView : UserControl
    {

        private DateInputViewModel _viewModel;
        public DateInputView()
        {
            InitializeComponent();
            DataContext = _viewModel = new DateInputViewModel();
        }
    }
}
