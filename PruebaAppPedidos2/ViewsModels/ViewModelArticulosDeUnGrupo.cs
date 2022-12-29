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
        public ModelGrupo _grupoAMostrar;
        public ObservableCollection<ModelArticulo> _listArticulos;
        //CONSTRUCTOR
        public ViewModelArticulosDeUnGrupo(INavigation navigation, ModelGrupo grupoSeleccionado)
        {
            Navigation = navigation;
            _grupoAMostrar = grupoSeleccionado;    
            obtenerArticulos();
        }

        //OBJETOS
        public ModelGrupo GrupoAMostrar
        {
            get { return _grupoAMostrar; }
            set { SetValue(ref _grupoAMostrar, value); }
        }

        public ObservableCollection<ModelArticulo> ListArticulos
        {
            get { return _listArticulos; }
            set { SetValue(ref _listArticulos, value); }
        }

        //PROCESOS

        public async Task obtenerArticulos()
        {

            await ServicesArticulos.obtenerTodoArticulos();
            ObservableCollection<ModelArticulo> artiDeGrupo = new ObservableCollection<ModelArticulo>();
            var articulosObtenido = ServicesArticulos.Articulos;
            foreach (var item in articulosObtenido)
            {
                if(item.artigrupo == GrupoAMostrar.codigo)
                {
                    artiDeGrupo.Add(item);
                }
            }
            ListArticulos = artiDeGrupo;

        }
        //COMANDOS
        public ICommand obtenerArticuloscommand => new Command(async () => await obtenerArticulos());
    }
}
