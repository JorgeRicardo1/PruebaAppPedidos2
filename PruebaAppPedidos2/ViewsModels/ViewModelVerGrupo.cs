using MySqlConnector;
using PruebaAppPedidos2.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using PruebaAppPedidos2.Services;
using PruebaAppPedidos2.Models;
using System.Collections.ObjectModel;
using PruebaAppPedidos2.Views;

namespace PruebaAppPedidos2.ViewsModels
{
    public class ViewModelVerGrupo : BaseViewModel
    {
        string _codigo;
        string _nombre;
        string _tipo;
        public ObservableCollection<ModelGrupo> _listgrupos;

        //CONSTRUCTOR
        public ViewModelVerGrupo(INavigation navigation)
        {
            Navigation= navigation;
            _ = obtenerGrupos();
        }

        //OBJETOS
        public string Codigo
        {
            get { return _codigo; }
            set { SetValue(ref _codigo, value); }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { SetValue(ref _nombre, value); }
        }

        public string Tipo
        {
            get { return _tipo; }
            set { SetValue(ref _tipo, value); }
        }

        public ObservableCollection<ModelGrupo> ListGrupos
        {
            get { return _listgrupos; }
            set { SetValue(ref _listgrupos, value); }
        }

        //PROCESOS
        public async Task obtenerGrupos()
        {
            await ServicesGrupo.extraerGrupos();
            //ListGrupos = await ServicesGrupo.extraerGrupos(); Averiguar como
            ListGrupos =  ServicesGrupo.Grupos;
        }

        public async Task irArticulosDeGrupo(ModelGrupo parametros)
        {
            await Navigation.PushAsync(new ArticulosDeUnGrupo(parametros));
        }

        public async Task irAfiltrar()
        {
            await Navigation.PushAsync(new FiltrarArticulos());
        }
        //COMANDOS
        public ICommand obtenerGruposcommand => new Command(async () => await obtenerGrupos());
        public ICommand irArticulosDeGrupocommand => new Command<ModelGrupo> (async (p) => await irArticulosDeGrupo(p));

        public ICommand irAFiltrarcommand => new Command(async () => await irAfiltrar());
    }
}
