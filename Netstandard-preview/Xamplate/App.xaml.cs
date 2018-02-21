using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamplate.Bootstrapping;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace Xamplate
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            LoadTypes();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        private void LoadTypes()
        {
            var bootstrapper = new Bootstrapper(this);
            bootstrapper.Run();
        }
    }
}
