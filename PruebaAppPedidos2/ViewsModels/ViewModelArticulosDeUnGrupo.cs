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
        public ModelGrupo parametrosRecibe { get; set; } 
        //CONSTRUCTOR
        public ViewModelArticulosDeUnGrupo(INavigation navigation, ModelGrupo parametrosTrae)
        {
            Navigation = navigation;
            parametrosRecibe = parametrosTrae;
        }

        //OBJETOS
        
        //PROCESPS
        
        //COMANDOS
        
    }
}
