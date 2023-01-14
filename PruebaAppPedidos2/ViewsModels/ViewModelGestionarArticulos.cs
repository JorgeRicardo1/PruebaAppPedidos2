using System;
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
        



        //Constructor
        public ViewModelGestionarArticulos(INavigation navigation, ModelArticulo articuloSeleccionado)
        {
            Navigation = navigation;
            _articuloSeleccionado = articuloSeleccionado;
            EncabezadoTem = App.encabezadoTemp;

            MessagingCenter.Subscribe<Object>(this, "ContinuarPedido", (sender) =>
            {
                EncabezadoTem = App.encabezadoTemp;
            });
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
                await Servicesxxxxvpax.addMoviminetoPedidoTemp(ArticuloSeleccionado, EncabezadoTem, Convert.ToInt32(CantidadArtiActual), Convert.ToInt32(ValParcialArtiActual));
                
            }
            await Navigation.PopToRootAsync();
        }

        public async Task getMovimientos()
        {
            //if (IsRefreshing) { return; }
            try
            {
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

        //Comandos
        public ICommand irAVerGruposcommand => new Command(async () => await irAVerGrupos());
        public ICommand addArticuloPedidoTempcommand => new Command(async () => await addArticuloPedidoTemp());
        public ICommand calcularValorParcialcommand => new Command(async () => await calcularValorParcial());
        public ICommand getMovimientoscommand => new Command(async () => await getMovimientos());


    }
}
