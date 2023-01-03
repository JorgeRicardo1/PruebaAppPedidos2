using PruebaAppPedidos2.Models;
using PruebaAppPedidos2.Services;
using PruebaAppPedidos2.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PruebaAppPedidos2.ViewsModels
{
    class ViewModelFiltrarArticulos : BaseViewModel
    {
        //VARIABLES
        public ObservableCollection<ModelArticulo> _listArticulos;
        public string _palabra1;
        public string _palabra2;
        public string _palabra3;
        public string _palabra4;

        //CONSTRUCTOR
        public ViewModelFiltrarArticulos(INavigation navigation)
        {
            Navigation = navigation;
        }

        //OBJETOS
        public ObservableCollection<ModelArticulo> ListArticulos
        {
            get { return _listArticulos; }
            set { SetValue(ref _listArticulos, value); }
        }

        public string Palabra1
        {
            get { return _palabra1; }
            set { SetValue(ref _palabra1, value); }
        }
        public string Palabra2
        {
            get { return _palabra2; }
            set { SetValue(ref _palabra2, value); }
        }
        public string Palabra3
        {
            get { return _palabra3; }
            set { SetValue(ref _palabra3, value); }
        }
        public string Palabra4
        {
            get { return _palabra4; }
            set { SetValue(ref _palabra4, value); }
        }

        //PROCESOS
        public async Task filtrar()
        {
            List<string> palabras = new List<string> { Palabra1, Palabra2, Palabra3, Palabra4};
            ListArticulos = await ServicesArticulos.filtrarArticulos(palabras);
            
        }
        public void limpiarBusqueda()
        {
            Palabra1 = "";
            Palabra2 = "";
            Palabra3 = "";
            Palabra4 = "";
            if(ListArticulos.Count != 0) { ListArticulos.Clear(); }
            
        }

        //COMANDOS
        public ICommand filtrarCommand => new Command(async () => await filtrar());
        public ICommand limpiarBusquedaCommand => new Command(limpiarBusqueda);
    }
}
