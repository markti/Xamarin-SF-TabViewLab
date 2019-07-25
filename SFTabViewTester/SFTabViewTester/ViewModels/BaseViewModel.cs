using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SFTabViewTester.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {

        private bool isBusy;
        public bool IsBusy
        {
            get => isBusy;
            set => SetAndRaisePropertyChanged(ref isBusy, value);
        }

        public BaseViewModel()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual Task LoadAsync() => Task.CompletedTask;
        public virtual Task InitializeAsync()
        {
            return LoadAsync();
        }

        public virtual Task UninitializeAsync() => Task.CompletedTask;


        protected void RaisePropertyChanged(string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        protected void SetAndRaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected void SetAndRaisePropertyChanged<TRef>(ref TRef field, TRef value, [CallerMemberName]string propertyName = null)
        {
            field = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected void SetAndRaisePropertyChangedIfDifferentValues<TRef>(ref TRef field, TRef value, [CallerMemberName] string propertyName = null)
            where TRef : class
        {
            if (field == null || !field.Equals(value))
            {
                SetAndRaisePropertyChanged(ref field, value, propertyName);
            }
        }
    }
}