
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using TranslateHelperWpf.Models;

namespace TranslateHelperWpf.ViewModels
{
    internal class DatagridViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<DatagridViewItemModel> Items { get; set; }
        public DatagridViewModel()
        {
            Items = new ObservableCollection<DatagridViewItemModel>();
            ComSite.Instance.OnNewSourceDataSet += Instance_OnNewSourceDataSet;
            ComSite.Instance.OnNewTargetDataSet += Instance_OnNewTargetDataSet;
        }

        private void Instance_OnNewSourceDataSet()
        {

        }
        private void Instance_OnNewTargetDataSet()
        {
            foreach (string key in ComSite.Instance.TargetData.Keys)
            {
            }
        }


    }
}
