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
    public class ViewModelArticulosDeUnGrupo :BaseViewModel
    {
        //Variables
        public string _grupoAMostrar;
        //CONSTRUCTOR
        public ViewModelArticulosDeUnGrupo(INavigation navigation, ModelGrupo grupoSeleccionado)
        {
            Navigation = navigation;
            _grupoAMostrar = grupoSeleccionado.nombre.ToString();
        }

        //OBJETOS
        public string GrupoAMostrar
        {
            get { return _grupoAMostrar; }
            set { SetValue(ref _grupoAMostrar, value); }
        }

        //PROCESOS

        //COMANDOS

    }
}
