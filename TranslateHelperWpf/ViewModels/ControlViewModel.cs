using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Windows.Input;
using TranslateHelperWpf.Models;

namespace TranslateHelperWpf.ViewModels
{
    internal class ControlViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ICommand _browseSourceFileCommand;
        private ICommand _browseTargetFileCommand;
        private ICommand _saveTargetAsFileCommand;

        public string SourceFileName { get; set; }
        public string TargetFileName { get; set; }
        public bool IsSourceFileLoaded { get; set; }
        public bool IsTargetFileLoaded { get; set; }

        public ICommand BrowseSourceFileCommand
        {
            get
            {
                return _browseSourceFileCommand ?? (_browseSourceFileCommand = new RelayCommand((o) =>
                {
                    OpenFileDialog dlg = new OpenFileDialog();
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        IsSourceFileLoaded = false;
                        if (File.Exists(dlg.FileName) == false)
                            return;
                        SourceFileName = dlg.FileName;
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SourceFileName"));
                        try
                        {
                            JsonProperty jsonFile;
                            JsonOperator.ReadFile(SourceFileName, out jsonFile);
                            var flatList = JsonOperator.GetFlatList(jsonFile);
                            ComSite.Instance.SetData(flatList);
                            IsSourceFileLoaded = true;
                        }
                        catch (Exception ex)
                        { }
                    }
                }));
            }
        }
        public ICommand BrowseTargetFileCommand
        {
            get
            {
                return _browseTargetFileCommand ?? (_browseTargetFileCommand = new RelayCommand((o) =>
                {
                    OpenFileDialog dlg = new OpenFileDialog();
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        IsTargetFileLoaded = false;
                        if (File.Exists(dlg.FileName) == false)
                            return;
                        TargetFileName = dlg.FileName;
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TargetFileName"));
                        try
                        {
                            JsonProperty jsonFile;
                            JsonOperator.ReadFile(TargetFileName, out jsonFile);
                            var flatList = JsonOperator.GetFlatList(jsonFile);
                            ComSite.Instance.SetData(flatList);
                            IsSourceFileLoaded = true;
                        }
                        catch (Exception ex)
                        { }
                    }

                }));
            }
        }
        public ICommand SaveTargetAsFileCommand
        {
            get
            {
                return _saveTargetAsFileCommand ?? (_saveTargetAsFileCommand = new RelayCommand((o) =>
                {

                    SaveFileDialog dlg = new SaveFileDialog();
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        if (File.Exists(dlg.FileName) == false)
                            return;
                        TargetFileName = dlg.FileName;
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TargetFileName"));
                    }

                }));
            }
        }

        public ControlViewModel()
        {
            IsSourceFileLoaded = false;
            IsTargetFileLoaded = false;
        }
    }
}
