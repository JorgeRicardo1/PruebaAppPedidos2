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
        public string _nombreCompleto;
        public Modelxxx3ro _cliente;
        public ModelDespacho _despachoActual;

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
        public string NombreCompleto
        {
            get { return _nombreCompleto;}
            set { SetValue(ref _nombreCompleto, value); }
        }
        public Modelxxx3ro ClienteActual
        {
            get { return _cliente; }
            set { SetValue(ref _cliente, value); }
        }
        public ModelDespacho DespachoActual
        {
            get { return _despachoActual; }
            set { SetValue(ref _despachoActual, value); }
        }
 
        //PROCESOS
        public async Task obtenerCliente()
        {
            if (Tronit != null)
            {
                ClienteActual = await Servicesxxx3ro.extraerCliente(Tronit);
                NombreCompleto = $"{ClienteActual.tronombre} {ClienteActual.tronomb_2} {ClienteActual.troapel_1} {ClienteActual.troapel_2}";
                PrecioOtorgado = obtenerPrecioCliente(ClienteActual);
                DespachoActual = new ModelDespacho { };
                //DespachoActual = await Servicesxxxxvped.extraerInfoDespacho(Tronit);
            }
        }

        public async Task continuarPedido()
        {
            try
            {
                if (DespachoActual.titular == null || DespachoActual.titudire == null || DespachoActual.tituciud == null || DespachoActual.titutelf == null)
                {
                    await DisplayAlert("Error", "Llene la informacion del despacho", "Ok");
                }
                else
                {
                    if (ClienteActual.tronit != "")
                    {
                        await Servicesxxxxvped.crearEncabezadoTemp(Tronit, DespachoActual);
                        App.encabezadoTemp = await Servicesxxxxvped.obtenerEncabezado();
                        MessagingCenter.Send<Object>(this, "ContinuarPedido");
                        MessagingCenter.Send<Object>(this, "ContinuarPedido2");
                    }
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
