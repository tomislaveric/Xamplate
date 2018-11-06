using System;
using Autofac;
using $safeprojectname$.ViewModels;
using $safeprojectname$.Views;

namespace $safeprojectname$.Bootstrapping.Modules
{
	public class ViewModelViewRegistrationModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<HomePage>().SingleInstance();
			builder.RegisterType<HomeBaseViewModel>().SingleInstance();

			builder.RegisterType<SecondPage>();
			builder.RegisterType<SecondViewModel>();
		}
	}
}
