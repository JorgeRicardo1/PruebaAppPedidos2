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
        public string _detallesExtras;
        public bool _isEnableInfoDespacho;
        public string _operarioActual;

        //CONSTRUCTOR
        public ViewModelCliente(INavigation navigation)
        {
            Navigation = navigation;
            OperarioActual = App.Operario.nombre;
            DespachoActual = new ModelDespacho {
                titular = "",
                tituciud = "",
                titudire = "",
                titutelf = ""
            };
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
        public string DetallesExtras
        {
            get { return _detallesExtras; }
            set { SetValue(ref _detallesExtras, value); }
        }
        public bool IsEnableInfoDespacho
        {
            get { return _isEnableInfoDespacho; }
            set { SetValue(ref _isEnableInfoDespacho, value); }
        }
        public string OperarioActual
        {
            get { return _operarioActual; }
            set { SetValue(ref _operarioActual, value); }
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
            
            if (ClienteActual != null)
            {
                await Servicesxxxxvpex.crearEncabezadoTemp(ClienteActual.tronit, DespachoActual,DetallesExtras);
                App.clienteActual= ClienteActual;
                App.encabezadoTemp = await Servicesxxxxvpex.obtenerEncabezado();
                await ServicesGrupo.extraerGrupos();//METODOS para obtener los grupos y articulos de la empresa una vez
                await ServicesArticulos.obtenerTodoArticulos();
                MessagingCenter.Send<Object>(this, "ContinuarPedido"); //Mensaje para cambiar la currentTabPage, en Home 
                MessagingCenter.Send<Object>(this, "ContinuarPedido2"); //Mensaje para actualizar el encabezado en ViewModelGestionarArti
            }
            else
            {
                await DisplayAlert("Error", "Seleccione un cliente antes de continuar", "Ok");
                return;
            }
        }

        public Task HabilitarInfoDespacho()
        {
            if (DespachoActual.titular == "")
            {
                DespachoActual.titudire = "";
                DespachoActual.tituciud = "";
                DespachoActual.titutelf = "";
                OnPropertyChanged(nameof(DespachoActual));
                IsEnableInfoDespacho = false;
            }
            else
            {
                IsEnableInfoDespacho = true;
            }

            return Task.CompletedTask;
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
        public ICommand HabilitarInfoDespachocommand => new Command(async () => await HabilitarInfoDespacho());

    }
}
