using System;
using System.Threading.Tasks;

namespace $safeprojectname$.Interfaces
{
	public interface INavigator
	{
		Task PopAsync();
		Task PopToRootAsync();
		Task PushAsync<TViewModel>() where TViewModel : class, IViewModelBase;
		Task PushModalAsync<TViewModel>() where TViewModel : class, IViewModelBase;
	}
}
