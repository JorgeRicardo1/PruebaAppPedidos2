﻿using MySqlConnector;
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
        public ObservableCollection<ModelGrupo> _listartigrupos;

        //CONSTRUCTOR
        public ViewModelVerGrupo(INavigation navigation)
        {
            Navigation= navigation;
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

        public ObservableCollection<ModelGrupo> ListGrupos
        {
            get { return _listartigrupos; }
            set { SetValue(ref _listartigrupos, value); }
        }

        //PROCESPS
        public async Task obtenerGrupos()
        {
            var grupoObtenido = ServicesGrupo.extraerGrupos();
            //ListGrupos = await ServicesGrupo.extraerGrupos(); Averiguar como
            ListGrupos = grupoObtenido;
        }

        public async Task irArticulosDeGrupo(ModelGrupo parametros)
        {
            await Navigation.PushAsync(new ArticulosDeUnGrupo(parametros));
        }
        //COMANDOS
        public ICommand obtenerGruposcommand => new Command(async () => await obtenerGrupos());
        public ICommand irArticulosDeGrupocommand => new Command<ModelGrupo> (async (p) => await irArticulosDeGrupo(p));  
    }
}
