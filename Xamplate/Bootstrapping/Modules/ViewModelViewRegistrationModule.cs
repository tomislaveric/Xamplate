using System;
using Autofac;
using Xamplate.ViewModels;
using Xamplate.Views;

namespace Xamplate.Bootstrapping.Modules
{
    public class ViewModelViewRegistrationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<HomePage>().SingleInstance();
            builder.RegisterType<HomeViewModel>().SingleInstance();
            
            builder.RegisterType<SecondPage>().SingleInstance();
            builder.RegisterType<SecondViewModel>().SingleInstance();
        }
    }
}
