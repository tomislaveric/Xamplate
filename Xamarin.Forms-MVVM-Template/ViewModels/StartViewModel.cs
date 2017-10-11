using System;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.FormsMVVMTemplate.Services;

namespace Xamarin.FormsMVVMTemplate.ViewModels
{
    public class StartViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public string WelcomeText => "Hello MVVM World";
        public string PageTitle => "Start Page";

        public StartViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public StartViewModel()
        {

        }

        public ICommand GoToNextPage => new Command(() =>
            _navigationService.NavigateToAsync<SecondViewModel>());
    }
}
