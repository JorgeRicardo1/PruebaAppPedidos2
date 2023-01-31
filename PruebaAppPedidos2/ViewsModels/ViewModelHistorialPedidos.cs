using PruebaAppPedidos2.Models;
using PruebaAppPedidos2.Services;
using PruebaAppPedidos2.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PruebaAppPedidos2.ViewsModels
{
    public class ViewModelHistorialPedidos : BaseViewModel
    {
        //Variables
        public ObservableCollection<Modelxxxxvped> _pedidosVendedor;
        //Constructor
        public ViewModelHistorialPedidos(INavigation navigation) 
        {
            Navigation = navigation;
            _ = getPedidosVendor("vend");
        }

        //OBJETOS
        public ObservableCollection<Modelxxxxvped> PedidosVendedor
        {
            get { return _pedidosVendedor; }
            set { SetValue(ref _pedidosVendedor, value); }
        }
        //PROCESOS
        public async Task getPedidosVendor(string idVendedor)
        {
            PedidosVendedor = await Servicesxxxxvped.getAllPedidosVendedor(idVendedor);
        }
        public async Task irDetallePedidoVendedor(Modelxxxxvped pedido)
        {
            //await DisplayAlert("hye",$"{pedido}","hey");
           await Navigation.PushAsync(new DetallesPedidoVendedor(pedido));
        }

        //COMANDOS
        //public ICommand getPedidosVendorcommand => new Command(async () => await getPedidosVendor("vend"));
        public ICommand irDetallePedidoVendedorcommand => new Command<Modelxxxxvped>(async (p) => await irDetallePedidoVendedor(p));
    }

}
