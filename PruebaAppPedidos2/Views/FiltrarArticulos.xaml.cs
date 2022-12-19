using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaAppPedidos2.ViewsModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PruebaAppPedidos2.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FiltrarArticulos : ContentPage
	{
		public FiltrarArticulos ()
		{
			InitializeComponent ();
			BindingContext = new ViewModelFiltrarArticulos(Navigation);
		}
	}
}