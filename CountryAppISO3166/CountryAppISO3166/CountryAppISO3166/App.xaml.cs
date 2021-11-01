using CountryAppISO3166.Services;
using CountryAppISO3166.Views;
using SimpleInjector;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CountryAppISO3166
{
    public partial class App : Application
    {
        public static string UrlApi = "http://192.168.0.106:5000/api/";
        public static string accessToken;

        private static Container ioCContainer = new SimpleInjector.Container();

        public static Container IoCContainer
        {
            get => ioCContainer;
            set => ioCContainer = value;
        }

        public App()
        {
            
            

            App.IoCContainer.Register<ICountryRestService, CountryRestService>(Lifestyle.Transient);

            InitializeComponent();
            
            MainPage = new NavigationPage(new Login());
            
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
