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

            App.encabezadoTemp = await Servicesxxxxvpex.buscarEncabezado(Pedido.nit, Pedido.fecha, Pedido.hdigita);

            // Verificar el estado del pedido
            if (App.encabezadoTemp.ped_estado != 0 && App.encabezadoTemp.ped_estado != 1)
            {
                await DisplayAlert("Aviso", "No se puede continuar con el pedido, Solicite autorizacion", "Ok");
                App.encabezadoTemp = null;
                return;
            }

            ClienteActual = await Servicesxxx3ro.extraerCliente(Pedido.nit);
            App.clienteActual = ClienteActual;

            // Si ped_estado es 0 o 1, y el encabezado se ha reiniciado, continúa con la acción normalmente
            await ServicesGrupo.extraerGrupos();
            await ServicesArticulos.obtenerTodoArticulos();
            await DisplayAlert("Aviso", "Información del pedido obtenida, ahora puede continuar este pedido en la sección 'realizar pedido'", "Ok");

            // Descomentado si es necesario volver a la página raíz
            // await Navigation.PopToRootAsync();

            MessagingCenter.Send<Object>(this, "RetomarPedido"); // Mensaje para MainPage que cambie la página del Flyout
            MessagingCenter.Send<Object>(this, "RetomarPedido2"); // Mensaje para Home que cambia la tabbed page
        }


        //COMANDOS
        public ICommand continuarPedidoCommand => new Command(async () => await continuarPedido());
    }
}
