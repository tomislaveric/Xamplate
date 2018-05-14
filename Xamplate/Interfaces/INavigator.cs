using System;
using System.Threading.Tasks;

namespace Xamplate.Interfaces
{
	public interface INavigator
	{
		Task PopAsync();
		Task PopToRootAsync();
		Task PushAsync<TViewModel>() where TViewModel : class, IViewModelBase;
		Task PushModalAsync<TViewModel>() where TViewModel : class, IViewModelBase;
	}
}
