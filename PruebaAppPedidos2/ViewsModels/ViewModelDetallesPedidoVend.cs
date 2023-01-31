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
    public class ViewModelDetallesPedidoVend : BaseViewModel
    {
        //variables
        public Modelxxxxvped _pedido;
        public ObservableCollection<Modelxxxxvpax> _lstMovimientosPedido;

        //constructor
        public ViewModelDetallesPedidoVend (INavigation navigation, Modelxxxxvped Pedido)
        {
            Navigation = navigation;
            _pedido = Pedido;
            _ = getMovimientosPedidoVend();
        }
        //OBJESTOS
        public Modelxxxxvped Pedido
        {
            get { return _pedido; }
            set { SetValue(ref _pedido, value); }
        }
        public ObservableCollection<Modelxxxxvpax> LstMovimientosPedido
        {
            get { return _lstMovimientosPedido; }
            set { SetValue(ref _lstMovimientosPedido, value); }
        }
        //PROCESOS
        public async Task getMovimientosPedidoVend()
        {
            LstMovimientosPedido = await Servicesxxxxvpax.getMovimientosPedidoTemp(Pedido.id_vtaped);
        }

        //COMANDOS
    }
}
