using System;
using System.Threading.Tasks;
using Xamplate.ViewModels;
namespace Xamplate.Services
{
    public interface INavigator
    {
        Task PopAsync();
        Task PopToRootAsync();
        Task PushAsync<TViewModel>() where TViewModel : class, IViewModelBase;
        Task PushModalAsync<TViewModel>() where TViewModel : class, IViewModelBase;
    }
}
