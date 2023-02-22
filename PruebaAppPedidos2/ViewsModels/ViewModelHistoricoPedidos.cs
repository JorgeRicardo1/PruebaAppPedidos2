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
    public class ViewModelHistoricoPedidos : BaseViewModel
    {
        //Variables
        public ObservableCollection<Modelxxxxvped> _pedidosVendedor;
        public string _nitCliente;
        public string _nombreCliente;
        public DateTime _fechaDesde;
        public DateTime _fechaHasta;
        public string _msgListaVacia;

        //Constructor
        public ViewModelHistoricoPedidos(INavigation navigation)
        {
            Navigation= navigation;
            FechaDesde = DateTime.Now;
            FechaHasta = DateTime.Now;
            //_ = getPedidosVendor(App.Operario.ciao_vend);
        }
        //Objetos
        public ObservableCollection<Modelxxxxvped> PedidosVendedor
        {
            get { return _pedidosVendedor; }
            set { SetValue(ref _pedidosVendedor, value); }
        }
        public string NitCliente
        {
            get { return _nitCliente; }
            set { SetValue(ref _nitCliente, value); }
        }
        public string NombreCliente
        {
            get { return _nombreCliente; }
            set { SetValue(ref _nombreCliente, value); }
        }
        public DateTime FechaDesde
        {
            get { return _fechaDesde; }
            set { SetValue(ref _fechaDesde, value); }
        }
        public DateTime FechaHasta
        {
            get { return _fechaHasta; }
            set { SetValue(ref _fechaHasta, value); }
        }
        public string MsgListaVacia
        {
            get { return _msgListaVacia; }
            set { SetValue(ref _msgListaVacia, value); }
        }
        //Procesos
        public async Task getPedidosVendor(string idVendedor)
        {
            PedidosVendedor = await Servicesxxxxvped.getAllPedidosVendedor(idVendedor);
            foreach (var pedido in PedidosVendedor)
            {
                pedido.textAprovado = (pedido.ped_estado == 0) ? "No" : "Si";
            }
        }

        public async Task filtrarPedidos()
        {
            PedidosVendedor = await Servicesxxxxvped.getPedidosFiltrados(NitCliente, NombreCliente, FechaDesde, FechaHasta);
            if (PedidosVendedor.Count > 0)
            {
                foreach (var pedido in PedidosVendedor)
                {
                    pedido.textAprovado = (pedido.ped_estado == 0) ? "No" : "Si";
                }
            }
            else
            {
                MsgListaVacia = "No se encontraron pedidos";
            }
        }

        public void limpiarBusqueda()
        {
            if (PedidosVendedor == null)
            {
                return;
            }
            if (PedidosVendedor.Count > 0)
            {
                NitCliente = "";
                NombreCliente = "";
                MsgListaVacia = "";
                PedidosVendedor.Clear();
            }
        }
        public async Task irDetallePedidoVendedor(Modelxxxxvped pedido)
        {
            //await DisplayAlert("hye",$"{pedido}","hey");
            await Navigation.PushAsync(new DetallesPedidoVendedor(pedido,false));
        }

        //Comandos
        public ICommand filtrarPedidoscommand => new Command(async () => await filtrarPedidos());
        public ICommand limpiarBusquedaCommand => new Command(limpiarBusqueda);
        public ICommand irDetallePedidoVendedorcommand => new Command<Modelxxxxvped>(async (p) => await irDetallePedidoVendedor(p));
    }
}
