
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using TranslateHelperWpf.Models;

namespace TranslateHelperWpf.ViewModels
{
    internal class DatagridViewModel : INotifyPropertyChanged
    {
        private Dictionary<string, JsonProperty> _jsonDataOrg;
        private Dictionary<string, JsonProperty> _jsonDataTrans;

        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<DatagridViewItemModel> Items { get; set; }
        public DatagridViewModel()
        {
            Items = new ObservableCollection<DatagridViewItemModel>();
        }
    }
}
