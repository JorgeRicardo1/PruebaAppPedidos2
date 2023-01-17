using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaAppPedidos2.Models;
using PruebaAppPedidos2.Services;
using PruebaAppPedidos2.ViewsModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PruebaAppPedidos2.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GestionarArticulos : ContentPage
	{
		public GestionarArticulos (ModelArticulo parametros)
		{
			InitializeComponent ();
            BindingContext = new ViewModelGestionarArticulos(Navigation, parametros);
		}

        public GestionarArticulos(Modelxxxxvpax movimiento)
        {
            InitializeComponent();
            BindingContext = new ViewModelGestionarArticulos(Navigation,movimiento);
        }

        protected override void OnAppearing()
        {
			
        }
    }
}