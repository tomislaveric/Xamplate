using System;
using Xamarin.Forms;
using Xamplate.ViewModels;

namespace Xamplate.Services
{
    public interface IViewFactory
    {
        void Register<TViewModel, TView>() where TViewModel : class, IViewModelBase where TView : Page;
        Page Resolve<TViewModel>() where TViewModel : class, IViewModelBase;
    }
}
