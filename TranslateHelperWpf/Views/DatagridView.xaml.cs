using System.Windows.Controls;
using TranslateHelperWpf.ViewModels;

namespace TranslateHelperWpf.Views
{
    public partial class DatagridView : UserControl
    {
        DatagridViewModel _viewModel = new DatagridViewModel();
        public DatagridView()
        {
            InitializeComponent();
            this.DataContext = _viewModel;
        }
    }
}
