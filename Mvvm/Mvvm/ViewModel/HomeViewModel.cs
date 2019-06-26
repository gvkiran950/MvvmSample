using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Mvvm.ViewModel
{
    public class HomeViewModel : BaseViewModel
    {
        public Command TestCommand { get; }
        public Command Test2Command { get; }
        public HomeViewModel()
        {
            Title = "Home";
            TestCommand = new Command(async () => await Test(),()=> !IsBusy);
            Test2Command = new Command(Test2, () => !IsBusy);
        }
        private string _description;

        private bool _isBusy = false;
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                //_isBusy = value;
                SetProperty(ref _isBusy,value);
                TestCommand.ChangeCanExecute();
                Test2Command.ChangeCanExecute();
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
               // _description = value;
                SetProperty(ref _description, value);
                //SetProperty(ref _description, value,nameof(Message));
                OnPropertyChanged(nameof(Message));
            }
        }
        public string Message
        {
            get
            {
                return $"enter name is {Description}";
            }
        }

        public void Test2()
        {
            Application.Current.MainPage.DisplayAlert("Test Alert", "Sucess test", "Ok");
        }
       public async Task Test()
        {           
            IsBusy = true;
            Thread.Sleep(5000);
            IsBusy = false;
            //api call 
           await Application.Current.MainPage.DisplayAlert("Login Alert", "Sucess", "Ok");
        }

       
    }
}
