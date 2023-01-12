using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PruebaAppPedidos2.Views;
using PruebaAppPedidos2.Models;

namespace PruebaAppPedidos2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new Home());
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

        //Variable global para almacenar el encabezado del pedido
        public static Modelxxxxvped encabezadoTemp { get; set; }
    }
}
