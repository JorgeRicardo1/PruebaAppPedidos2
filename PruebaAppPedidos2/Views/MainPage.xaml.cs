using PruebaAppPedidos2.Models;
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
	public partial class MainPage : FlyoutPage
    {
		public MainPage ()
		{
			InitializeComponent ();
			flyout.listMenuLateral.ItemSelected += OnSelectedItem;
            //Mensaje suscriptor de VMDetallePedidoVend para ir a la seccion de realizar pedidos
            MessagingCenter.Subscribe<Object>(this, "RetomarPedido", (sender) =>
            {
                Detail = new NavigationPage (new Home());
                flyout.listMenuLateral.SelectedItem = 0;
            });
        }

        private void OnSelectedItem(object sender, SelectedItemChangedEventArgs e)
        {
			var item = e.SelectedItem as FlyoutItemPage;
			if (item != null)
			{
				Detail = new NavigationPage((Page)Activator.CreateInstance(item.targetPage));
				flyout.listMenuLateral.SelectedItem = item;
				IsPresented= false;
			}
        }

        protected override bool OnBackButtonPressed()
        {
            Detail = new NavigationPage(new Home());
            flyout.listMenuLateral.SelectedItem = 0;
            return true;
        }

    }
}