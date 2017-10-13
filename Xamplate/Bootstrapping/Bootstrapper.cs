using System;
using Autofac;
using Xamplate.Views;
using Xamplate.ViewModels;
using Xamplate.Services;
using Xamplate.Bootstrapping.Modules;
using Xamarin.Forms;

namespace Xamplate.Bootstrapping
{
    public class Bootstrapper
    {
        private readonly App _app;

        public Bootstrapper(App app)
        {
            _app = app;
        }
        
        public void Run()
        {
            var builder = new ContainerBuilder();
            ConfigureContainer(builder);

            var container = builder.Build();

            var viewFactory = container.Resolve<IViewFactory>();
            RegisterViews(viewFactory);

            ConfigureApplication(container);
        }

        private void ConfigureApplication(IContainer container)
        {
            var viewFactory = container.Resolve<IViewFactory>();
            
            var mainPage = viewFactory.Resolve<HomeBaseViewModel>();
            var navPage = new NavigationPage(mainPage);
            
            _app.MainPage = navPage;
        }

        private void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<DependencyRegistrationModule>();
            builder.RegisterModule<ViewModelViewRegistrationModule>();
        }

        private void RegisterViews(IViewFactory viewFactory)
        {
            viewFactory.Register<HomeBaseViewModel, HomePage>();
            viewFactory.Register<SecondViewModel, SecondPage>();
        }
    }
}
