using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using Xamplate.Services;

namespace Xamplate.ViewModels
{
    public class HomeBaseViewModel : BaseViewModel
    {
        public string PageTitle => "Start Page";
        public string GoToNextPageButtonText => "Push to next page";

        private readonly INavigator _navigator;

        public HomeBaseViewModel(INavigator navigator)
        {
            _navigator = navigator;
        }

        public ICommand NextPageCommand => new Command(() =>
        {
            _navigator.PushAsync<SecondViewModel>();
        });
    }
}
