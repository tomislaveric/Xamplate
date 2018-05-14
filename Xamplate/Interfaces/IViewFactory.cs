using System;
using Xamarin.Forms;

namespace Xamplate.Interfaces
{
	public interface IViewFactory
	{
		void Register<TViewModel, TView>() where TViewModel : class, IViewModelBase where TView : Page;
		Page Resolve<TViewModel>() where TViewModel : class, IViewModelBase;
	}
}
