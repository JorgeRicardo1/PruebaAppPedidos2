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

namespace PruebaAppPedidos2.ViewsModels
{
    public class ViewModelVerGrupo : BaseViewModel
    {
        string _codigo;
        string _nombre;
        string _tipo;
        public ObservableCollection<ModelGrupo> _listarticulos;

        //CONSTRUCTOR
        public ViewModelVerGrupo()
        {
            obtenerGrupos();
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

        public ObservableCollection<ModelGrupo> ListArticulos
        {
            get { return _listarticulos; }
            set { SetValue(ref _listarticulos, value); }
        }

        //PROCESPS
        public async Task obtenerGrupos()
        {
            var grupoObtenido = ServicesGrupo.extraerGrupos();
            ListArticulos = grupoObtenido;
        }
        //COMANDOS
        public ICommand obtenerGruposcommand => new Command(async () => await obtenerGrupos());
    }
}
