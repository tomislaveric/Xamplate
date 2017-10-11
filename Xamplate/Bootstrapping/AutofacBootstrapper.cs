using System;
using Autofac;
using Xamplate.Bootstrapping.Modules;
using Xamplate.Services;
namespace Xamplate.Bootstrapping
{
    public abstract class AutofacBootstrapper
    {
        public void Run()
        {
            var builder = new ContainerBuilder();

            ConfigureContainer(builder);

            var container = builder.Build();

            var viewFactory = container.Resolve<IViewFactory>();
            RegisterViews(viewFactory);

            ConfigureApplication(container);
        }

        protected virtual void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<AutofacModule>();
        }

        protected abstract void RegisterViews(IViewFactory builder);

        protected abstract void ConfigureApplication(IContainer container);
    }
}
