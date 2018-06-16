using System;
using System.Collections.Generic;
using System.Windows.Input;
using TranslateHelperWpf.Models;

namespace TranslateHelperWpf
{
    internal delegate void OnSignal();
    internal sealed class ComSite
    {
        static readonly ComSite _instance = new ComSite();
        public static ComSite Instance { get { return _instance; } }

        Dictionary<string, JsonProperty> _sourceData;
        Dictionary<string, JsonProperty> _targetData;
        public Dictionary<string, JsonProperty> SourceData { get { return _sourceData; } }
        public Dictionary<string, JsonProperty> TargetData { get { return _targetData; } }
        public event OnSignal OnNewSourceDataSet;
        public event OnSignal OnNewTargetDataSet;
        private ComSite()
        {
        }
        public void SetSourceData(Dictionary<string, JsonProperty> data)
        {
            _sourceData = data;
            OnNewSourceDataSet?.Invoke();
        }
        public void SetTargetData(Dictionary<string, JsonProperty> data)
        {
            _targetData = data;
            OnNewTargetDataSet?.Invoke();
        }
    }



    internal delegate void OnNewFlatList(Dictionary<string, JsonProperty> list);

    internal class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;
        private bool _canExecuteState = false;

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }
        public RelayCommand(Action<object> execute) : this(execute, null) { }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if (_canExecute == null)
                return true;
            else
            {
                bool oldState = _canExecuteState;
                _canExecuteState = _canExecute(parameter);
                if (oldState != _canExecuteState)
                {
                    CanExecuteChanged?.Invoke(this, null);
                }
                return _canExecuteState;
            }
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
