using System.Threading.Tasks;
using Xamarin.FormsMVVMTemplate.ViewModels;

namespace Xamarin.FormsMVVMTemplate.Services
{
    public interface INavigationService
    {
        Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase;
    }
}