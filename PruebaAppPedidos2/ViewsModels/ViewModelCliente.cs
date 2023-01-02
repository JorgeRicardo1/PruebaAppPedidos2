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

        //PROCESOS
        public async Task obtenerCliente()
        {
            ClienteActual = await Servicesxxx3ro.extraerCliente(Tronit);
            PrecioOtorgado = obtenerPrecioCliente(ClienteActual);
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
    }
}
