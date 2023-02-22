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
    public class ViewModelDetallesPedidoVend : BaseViewModel
    {
        //variables
        public Modelxxxxvped _pedido;
        public ObservableCollection<Modelxxxxvpax> _lstMovimientosPedido;
        public bool _estadoPedido;
        public Modelxxx3ro _clienteActual;

        //constructor
        public ViewModelDetallesPedidoVend (INavigation navigation, Modelxxxxvped Pedido, bool estadoPedido)
        {
            Navigation = navigation;
            _pedido = Pedido;
            _estadoPedido = estadoPedido;
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
        public bool EstadoPedido
        {
            get { return _estadoPedido; }
            set { SetValue(ref _estadoPedido, value); }
        }
        public Modelxxx3ro ClienteActual
        {
            get { return _clienteActual; }
            set { SetValue(ref _clienteActual, value); }
        }
        //PROCESOS
        public async Task getMovimientosPedidoVend()
        {
            if (EstadoPedido)
            {
                LstMovimientosPedido = await Servicesxxxxvpax.getMovimientosPedidoTemp(Pedido.id_vtaped);
            }
            else
            {
                LstMovimientosPedido = await Servicesxxxxvpar.getMovimientosPedido(Pedido.numero);
            }
        }

        public async Task continuarPedido()
        {
            if (App.encabezadoTemp != null)
            {
                await DisplayAlert("Aviso", "Ya tiene un pedido en proceso, para empezar uno nuevo, primero reinicie el pedido actual", "Ok");
                return;
            }
            ClienteActual = await Servicesxxx3ro.extraerCliente(Pedido.nit);
            App.clienteActual = ClienteActual;
            App.encabezadoTemp = await Servicesxxxxvpex.buscarEncabezado(Pedido.nit, Pedido.fecha, Pedido.hdigita);
            await ServicesGrupo.extraerGrupos();//METODOS para obtener los grupos y articulos de la empresa una vez
            await ServicesArticulos.obtenerTodoArticulos();
            await DisplayAlert("Aviso", "Informacion de el pedido obtenida, ahora puede continuar este pedido en la seccion 'realizar pedido'", "Ok");
            //await Navigation.PopToRootAsync();
            MessagingCenter.Send<Object>(this, "RetomarPedido");//Mensaje para MainPage que cambie la pagina del Flyout
            MessagingCenter.Send<Object>(this, "RetomarPedido2");//Mensaje para Home que cambia la tabbed page

        }
        //COMANDOS
        public ICommand continuarPedidoCommand => new Command(async () => await continuarPedido());
    }
}
