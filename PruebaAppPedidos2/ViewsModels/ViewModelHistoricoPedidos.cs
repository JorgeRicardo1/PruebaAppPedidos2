using PruebaAppPedidos2.Models;
using PruebaAppPedidos2.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PruebaAppPedidos2.ViewsModels
{
    public class ViewModelHistoricoPedidos : BaseViewModel
    {
        //Variables
        public ObservableCollection<Modelxxxxvped> _pedidosVendedor;
        //Constructor
        public ViewModelHistoricoPedidos(INavigation navigation)
        {
            Navigation= navigation;
            _ = getPedidosVendor(App.Operario.ciao_vend);
        }
        //Objetos
        public ObservableCollection<Modelxxxxvped> PedidosVendedor
        {
            get { return _pedidosVendedor; }
            set { SetValue(ref _pedidosVendedor, value); }
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
        //Comandos
    }
}
