using App99mobileAPI.Services;
using App99mobileAPI.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App99mobileAPI
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
#if DEBUG
            HotReloader.Current.Run(this);
#endif

            DependencyService.Register<MockDataStore>();
            MainPage = new  NavigationPage(new LoginPage());
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
