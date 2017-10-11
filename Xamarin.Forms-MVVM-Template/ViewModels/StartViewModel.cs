using System;
namespace Xamarin.FormsMVVMTemplate.ViewModels
{
    public class StartViewModel : ViewModelBase
    {
        public string WelcomeText => "Hello MVVM World";
        public string PageTitle => "Start Page";

        public StartViewModel()
        {
        }
    }
}
