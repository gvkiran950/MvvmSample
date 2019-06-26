using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Mvvm.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {

        public string Title { get; set; }
        //private bool _isBusy = false;
        //public bool IsBusy
        //{
        //    get { return _isBusy; }
        //    set
        //    {
        //        _isBusy = value;
        //        OnPropertyChanged();
        //    }
        //}

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName]string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        protected bool SetProperty<M>(ref M storage, M value, [CallerMemberName]string propertyName = null)
        {
            if (EqualityComparer<M>.Default.Equals(storage, value))
            {
                return false;
            }
            storage = value;
            OnPropertyChanged(propertyName);

            return true;
        }
    }
}
