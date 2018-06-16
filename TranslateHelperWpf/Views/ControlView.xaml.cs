using System.Windows.Controls;
using TranslateHelperWpf.ViewModels;

namespace TranslateHelperWpf.Views
{
    public partial class ControlView : UserControl
    {
        ControlViewModel _viewModel = new ControlViewModel();
        public ControlView()
        {
            InitializeComponent();
            this.DataContext = _viewModel;
        }
    }
}
