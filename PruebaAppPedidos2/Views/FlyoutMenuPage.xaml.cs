using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PruebaAppPedidos2.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FlyoutMenuPage : ContentPage
	{
		public FlyoutMenuPage ()
		{
			InitializeComponent ();
			BindingContext= this;
			txtOperarioActual.Text = App.Operario.nombre;
		}

        private async void btnSalir_Clicked(object sender, EventArgs e)
        {
			if (App.encabezadoTemp != null)
			{
				var response = await DisplayAlert("Aviso", "Tiene un pedido en curso, seguro que desea salir de la aplicacion?", "Si","No");
				if (!response)
				{
					return;
                }
			}
            System.Environment.Exit(0);
        }
    }
}