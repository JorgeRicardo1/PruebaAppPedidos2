using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using PruebaAppPedidos2.Models;
using PruebaAppPedidos2.Services;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;

namespace PruebaAppPedidos2.ViewsModels
{
    internal class ViewModelCliente : BaseViewModel
    {
        //VARIABLES
        public string _tronit;
        public string _precioOtorgado;
        public string _nombreCompleto;
        public Modelxxx3ro _clienteActual;
        public ModelDespacho _despachoActual;

        //CONSTRUCTOR
        public ViewModelCliente(INavigation navigation)
        {
            Navigation = navigation;
            DespachoActual = new ModelDespacho { };
        }

        //OBJETOS
        public string Tronit
        {
            get { return _tronit; }
            set { SetValue(ref _tronit, value); }
        }
        public string PrecioOtorgado
        {
            get { return _precioOtorgado; }
            set { SetValue(ref _precioOtorgado, value); }
        }
        public string NombreCompleto
        {
            get { return _nombreCompleto;}
            set { SetValue(ref _nombreCompleto, value); }
        }
        public Modelxxx3ro ClienteActual
        {
            get { return _clienteActual; }
            set { SetValue(ref _clienteActual, value); }
        }
        public ModelDespacho DespachoActual
        {
            get { return _despachoActual; }
            set { SetValue(ref _despachoActual, value); }
        }
 
        //PROCESOS
        public async Task obtenerCliente()
        {
            UserDialogs.Instance.ShowLoading("Buscando");
            await Task.Delay(1000);
            if (Tronit != null)
            {
                ClienteActual = await Servicesxxx3ro.extraerCliente(Tronit);
                if (ClienteActual == null)
                {
                    await DisplayAlert("Aviso", $"No existe un cliente con nit {Tronit}", "Ok");
                    UserDialogs.Instance.HideLoading();
                    return;
                }
                NombreCompleto = $"{ClienteActual.tronombre} {ClienteActual.tronomb_2} {ClienteActual.troapel_1} {ClienteActual.troapel_2}";
                PrecioOtorgado = obtenerPrecioCliente(ClienteActual);
                
                //DespachoActual = await Servicesxxxxvped.extraerInfoDespacho(Tronit);
            }
            else
            {
                await DisplayAlert("Aviso", $"No se ha escrito un nit para buscar", "Ok");
            }
            UserDialogs.Instance.HideLoading();
        }

        public async Task continuarPedido()
        {
            if (App.encabezadoTemp != null)
            {
                await DisplayAlert("Aviso","Ya tiene un pedido en proceso, para empezar uno nuevo, primero reinicie el pedido actual","Ok");
                return;
            }
            if (DespachoActual.titular == null || DespachoActual.titudire == null || DespachoActual.tituciud == null || DespachoActual.titutelf == null)
            {
                await DisplayAlert("Error", "Llene la informacion del despacho", "Ok");
                return;
            }
            if (ClienteActual != null)
            {
                await Servicesxxxxvped.crearEncabezadoTemp(Tronit, DespachoActual);
                App.clienteActual= ClienteActual;
                App.encabezadoTemp = await Servicesxxxxvped.obtenerEncabezado();
                MessagingCenter.Send<Object>(this, "ContinuarPedido"); //Mensaje para cambiar la currentTabPage, en Home 
                MessagingCenter.Send<Object>(this, "ContinuarPedido2"); //Mensaje para actualizar el encabezado en ViewModelGestionarArti
            }
            else
            {
                await DisplayAlert("Error", "Seleccione un cliente antes de continuar", "Ok");
                return;
            }
        }

        public  string obtenerPrecioCliente(Modelxxx3ro cliente)
        {
            //escala del precio otorgado al cliente 1- contado - 2 mayorista -3 distribuidor 4 credito
            //trocccupo - troccsdovn 
            switch (cliente.troprecio)
            {
                case 1:
                    return "contado";
                case 2:
                    return "mayorista";
                case 3:
                    return "distribuidor";
                case 4:
                    return "credito";
                default:
                    return "no especificado";
            }
        }
        //COMANDOS
        public ICommand obtenerClienteCommand => new Command(async () => await obtenerCliente());
        public ICommand continuarPedidoCommand => new Command(async () => await continuarPedido());

    }
}
