using Projeto.R4.StartupOne.Services;
using Projeto.R4.StartupOne.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Projeto.R4.StartupOne
{
    public partial class App : Application
    {
        public static string ApiBackendUrl = "http://localhost:5000";
        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
