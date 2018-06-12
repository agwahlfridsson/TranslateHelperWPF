using System.Windows.Controls;

namespace TranslateHelperWpf.Views
{
    public partial class FooterView : UserControl
    {
        public string Revision { get { return THdefinitions.VersionString; } }
        public string History { get { return THdefinitions.History; } }
        public FooterView()
        {
            InitializeComponent();
        }
    }
}
