using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.FormsMVVMTemplate.ViewModels;

namespace Xamarin.FormsMVVMTemplate.Services
{
    public class NavigationService : INavigationService
    {
        private readonly INavigation _navigation;

        public NavigationService(INavigation navigation)
        {
            _navigation = navigation;
        }
        
        public Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase
        {
            throw new System.NotImplementedException();
        }
    }
}