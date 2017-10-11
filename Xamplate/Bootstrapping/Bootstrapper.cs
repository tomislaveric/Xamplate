using System;
using Autofac;
using Xamplate.Views;
using Xamplate.ViewModels;
using Xamplate.Services;
using Xamplate.Bootstrapping.Modules;
using Xamarin.Forms;

namespace Xamplate.Bootstrapping
{
    public class Bootstrapper : AutofacBootstrapper
    {
        private readonly App _app;

        public Bootstrapper(App app)
        {
            _app = app;
        }

        protected override void ConfigureContainer(ContainerBuilder builder)
        {
            base.ConfigureContainer(builder);
            builder.RegisterModule<ViewModelViewRegistrationModule>();
        }

        protected override void ConfigureApplication(IContainer container)
        {
            var viewFactory = container.Resolve<IViewFactory>();
            
            var mainPage = viewFactory.Resolve<StartViewModel>();
            var navPage = new NavigationPage(mainPage);
            
            _app.MainPage = navPage;
        }

        protected override void RegisterViews(IViewFactory viewFactory)
        {
            viewFactory.Register<StartViewModel, StartView>();
            viewFactory.Register<SecondViewModel, SecondView>();
        }
    }
}
