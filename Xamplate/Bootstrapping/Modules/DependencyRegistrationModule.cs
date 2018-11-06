using System;
using Autofac;
using Xamarin.Forms;
using $safeprojectname$.Interfaces;
using $safeprojectname$.Services;

namespace $safeprojectname$.Bootstrapping.Modules
{
	public class DependencyRegistrationModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<ViewFactory>().As<IViewFactory>().SingleInstance();
			builder.RegisterType<Navigator>().As<INavigator>().SingleInstance();
			builder.Register<INavigation>(context => Application.Current.MainPage.Navigation).SingleInstance();
		}
	}
}
