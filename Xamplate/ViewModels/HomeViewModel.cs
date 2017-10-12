using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using Xamplate.Services;

namespace Xamplate.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {

        public string WelcomeText => "Hello MVVM World";
        public string PageTitle => "Start Page";

        private readonly INavigator _navigator;

        public HomeViewModel(INavigator navigator)
        {
            _navigator = navigator;
        }

        public ICommand NextPageCommand => new Command(() =>
        {
            _navigator.PushAsync<SecondViewModel>();
        });
    }
}
