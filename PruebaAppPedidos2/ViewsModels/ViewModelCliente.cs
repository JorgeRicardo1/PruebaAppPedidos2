using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using PruebaAppPedidos2.Models;
using PruebaAppPedidos2.Services;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PruebaAppPedidos2.ViewsModels
{
    internal class ViewModelCliente : BaseViewModel
    {
        //VARIABLES
        public string _tronit;
        public string _precioOtorgado;
        public Modelxxx3ro _cliente;
        public Modelxxxxvped _despacho;

        //CONSTRUCTOR
        public ViewModelCliente(INavigation navigation)
        {
            Navigation = navigation;
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

        public Modelxxx3ro ClienteActual
        {
            get { return _cliente; }
            set { SetValue(ref _cliente, value); }
        }
        public Modelxxxxvped DespachoActual
        {
            get { return _despacho; }
            set { SetValue(ref _despacho, value); }
        }
 
        //PROCESOS
        public async Task obtenerCliente()
        {
            if (Tronit != null)
            {
                ClienteActual = await Servicesxxx3ro.extraerCliente(Tronit);
                PrecioOtorgado = obtenerPrecioCliente(ClienteActual);
                DespachoActual = await Servicesxxxxvped.extraerInfoDespacho(Tronit);
            }
        }

        public async Task continuarPedido()
        {
            try
            {
                if (ClienteActual.tronit != "")
                {
                    MessagingCenter.Send<Object, string>(this, "ContinuarPedido", Tronit);
                }
            }
            catch (NullReferenceException)
            {
                await DisplayAlert("Error", "Seleccione un cliente antes de continuar", "Ok");
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
