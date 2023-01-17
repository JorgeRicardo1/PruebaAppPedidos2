﻿using System;
using System.Collections.Generic;
using System.Text;
using PruebaAppPedidos2.Views;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using PruebaAppPedidos2.Models;
using System.Collections.ObjectModel;
using PruebaAppPedidos2.Services;

namespace PruebaAppPedidos2.ViewsModels
{
    public class ViewModelGestionarArticulos : BaseViewModel
    {
        //Variables
        public ModelArticulo _articuloSeleccionado;
        public Modelxxxxvped _encabezadoTem;
        public ObservableCollection<Modelxxxxvpax> _lstPedidoTemporal;
        public string _cantidadArtiActual;
        public string _valParcialArtiActual;
        public bool _isRefreshing;
        public string _detallesArti;
        public bool _isVisible;
        public Modelxxxxvpax _movimientoSeleccionado; 

        //Constructor
        public ViewModelGestionarArticulos(INavigation navigation, ModelArticulo articuloSeleccionado)
        {
            Navigation = navigation;
            _articuloSeleccionado = articuloSeleccionado;
            EncabezadoTem = App.encabezadoTemp;
            _=getMovimientos();

            MessagingCenter.Subscribe<Object>(this, "ContinuarPedido2", (sender) =>
            {
                EncabezadoTem = App.encabezadoTemp;
            });

            if(ArticuloSeleccionado.articodigo != null)
            {
                _cantidadArtiActual = "1";
                _ = calcularValorParcial();
            }
        }
        //Objetos
        public ModelArticulo ArticuloSeleccionado
        {
            get { return _articuloSeleccionado; }
            set { SetValue(ref _articuloSeleccionado, value); }
        }
        public Modelxxxxvped EncabezadoTem
        {
            get { return _encabezadoTem; }
            set { SetValue(ref _encabezadoTem, value); }
        }
        public ObservableCollection<Modelxxxxvpax> LstPedidoTemporal
        {
            get { return _lstPedidoTemporal; }
            set { SetValue(ref _lstPedidoTemporal, value); }
        }
        public string CantidadArtiActual
        {
            get { return _cantidadArtiActual; }
            set { SetValue(ref _cantidadArtiActual, value); }
        }
        public string ValParcialArtiActual
        {
            get { return _valParcialArtiActual; }
            set { SetValue(ref _valParcialArtiActual, value); }
        }
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set { SetValue(ref _isRefreshing, value); }
        }
        public string DetallesArti
        {
            get { return _detallesArti; }
            set { SetValue(ref _detallesArti, value); }
        }
        public bool IsVisible
        {
            get { return _isVisible; }
            set { SetValue(ref _isVisible, value); }
        }
        public Modelxxxxvpax MovimientoSeleccionado
        {
            get { return _movimientoSeleccionado; }
            set { SetValue(ref _movimientoSeleccionado, value); }
        }
        //Procesos
        public async Task irAVerGrupos()
        {
            await Navigation.PushAsync(new VerGrupos());
        }

        public async Task addArticuloPedidoTemp()
        {
            ObservableCollection<ModelArticulo> lstAux = new ObservableCollection<ModelArticulo>();
            if (ArticuloSeleccionado.articodigo != null)
            {
                await Servicesxxxxvpax.addMoviminetoPedidoTemp(ArticuloSeleccionado, EncabezadoTem, Convert.ToInt32(CantidadArtiActual), Convert.ToInt32(ValParcialArtiActual), DetallesArti);
                
            }
            await Navigation.PopToRootAsync();
        }

        public async Task getMovimientos()
        {
            //if (IsRefreshing) { return; }
            try
            {
                IsVisible = false;
                _isRefreshing = true;
                LstPedidoTemporal = await Servicesxxxxvpax.getMovimientosPedidoTemp(EncabezadoTem.id_vtaped);
            }
            catch (Exception)
            {

                throw;
            }
            finally { IsRefreshing = false; }
        }
        public async Task calcularValorParcial()
        {
            if(ArticuloSeleccionado.articodigo != null && CantidadArtiActual!="")
            {
                ValParcialArtiActual = await Task.Run(() => (Convert.ToInt32(CantidadArtiActual) * ArticuloSeleccionado.artivlr1_c).ToString());
            }
            if (CantidadArtiActual =="")
            {
                ValParcialArtiActual = "0";
            }
        }
        public void activarBotones()
        {
            try
            {
                
                IsVisible= true;
            }
            catch (Exception)
            {

                throw;
            }
            //finally { IsVisible = false; }
        }
        public async Task borrarMovimiento()
        {
            Modelxxxxvpax movimientoAborrar = MovimientoSeleccionado;
            await Servicesxxxxvpax.borrarMovimiento(movimientoAborrar.Id_vpar);
            await DisplayAlert("Aviso", $"Se borro el articulo {movimientoAborrar.detalle} con exito", "ok");
            await getMovimientos();   
        }

        public async Task editarMovimiento()
        {
            Modelxxxxvpax movimientoAeditar = MovimientoSeleccionado;
            await Servicesxxxxvpax.borrarMovimiento(movimientoAeditar.Id_vpar);
            await DisplayAlert("Aviso", $"Se editara el producto {movimientoAeditar.detalle}, una vez finalizado darle agregar", "ok");
            //await Navigation.PushAsync(new GestionarArticulos(movimientoAeditar));

        }

        //Comandos
        public ICommand irAVerGruposcommand => new Command(async () => await irAVerGrupos());
        public ICommand addArticuloPedidoTempcommand => new Command(async () => await addArticuloPedidoTemp());
        public ICommand calcularValorParcialcommand => new Command(async () => await calcularValorParcial());
        public ICommand getMovimientoscommand => new Command(async () => await getMovimientos());
        public ICommand activarBotonescommand => new Command(() =>  activarBotones());
        public ICommand borrarMovimientocommand => new Command(async () => await borrarMovimiento());


    }
}
