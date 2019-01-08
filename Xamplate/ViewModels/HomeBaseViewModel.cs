using System;
using System.Windows.Input;
using Xamarin.Forms;
using $safeprojectname$.Interfaces;

namespace $safeprojectname$.ViewModels
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
