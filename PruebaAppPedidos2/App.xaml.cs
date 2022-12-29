using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PruebaAppPedidos2.Views;

namespace PruebaAppPedidos2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new InformacionCliente());
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
