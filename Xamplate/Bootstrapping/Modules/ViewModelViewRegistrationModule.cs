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
            builder.RegisterType<StartViewModel>().SingleInstance();
            builder.RegisterType<StartView>().SingleInstance();

            builder.RegisterType<SecondView>().SingleInstance();
            builder.RegisterType<SecondViewModel>().SingleInstance();
        }
    }
}
