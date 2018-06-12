using System.ComponentModel;
using TranslateHelperWpf.Models;

namespace TranslateHelperWpf.ViewModels
{
    internal class DatagridViewItemModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _tag;
        public string Tag
        {
            get { return _tag; }
            set
            {
                if (_tag != value)
                {
                    _tag = value;
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Tag"));
                }
            }
        }
        private string _org;
        public string Org
        {
            get { return _org; }
            set
            {
                if (_org != value)
                {
                    _org = value;
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Org"));
                }
            }
        }
        private string _trans;
        public string Trans
        {
            get { return _trans; }
            set
            {
                if (_trans != value)
                {
                    _trans = value;
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Trans"));
                }
            }
        }
        private JsonProperty _dataOrg, _dataTrans;
        public DatagridViewItemModel(JsonProperty Org, JsonProperty Trans)
        {
            _dataOrg = Org;
            _dataTrans = Trans;
        }
     
    }
}
