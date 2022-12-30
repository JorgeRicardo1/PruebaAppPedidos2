using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using PruebaAppPedidos2.Models;

namespace PruebaAppPedidos2.ViewsModels
{
    internal class ViewModelCliente : BaseViewModel
    {
        //VARIABLES
        public string _tronit;
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

        public Modelxxx3ro Cliente
        {
            get { return _cliente; }
            set { SetValue(ref _cliente, value); }
        }

        //PROCESOS

        //COMANDOS
    }
}
