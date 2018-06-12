using System;
using System.Windows.Controls;
using System.Windows.Input;
using TranslateHelperWpf.Models;

namespace TranslateHelperWpf.Views
{
    public partial class MenuView : UserControl
    {
        private ICommand _menuFileExitPressed;
        public ICommand MenuFileExitPressed
        {
            get
            {
                return _menuFileExitPressed ?? (_menuFileExitPressed = new RelayCommand((o) =>
                {
                }));
            }
        }
        private ICommand _menuAboutHelpPressed;
        public ICommand MenuAboutHelpPressed
        {
            get
            {
                return _menuAboutHelpPressed ?? (_menuAboutHelpPressed = new RelayCommand((o) =>
                {
                }));
            }
        }
        public MenuView()
        {
            InitializeComponent();
        }
    }
}
