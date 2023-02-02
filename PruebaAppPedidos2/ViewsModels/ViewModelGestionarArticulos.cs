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
using System.ComponentModel;
using Xamarin.Essentials;
using Acr.UserDialogs;
using ZXing.Net.Mobile.Forms;

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
        public bool _isEditing;
        public string _valUnidad;
        public Modelxxxxvpax _movAEditar;
        public int _precioTotalPedido;
        public int _cantidadTotalPedido;
        public int _pesoTotalPedido;
        public bool _isVisibleFinalizar;
        public bool _isEnableCantidad;
        public string _codArtiABuscar;
        public bool _isEnabledTxtCodArti;
        public bool _isVisibleReiniciar;
        public double _opacityInfoArti;
        public bool _isVisibleAdd;


        //Constructor
        public ViewModelGestionarArticulos(INavigation navigation, ModelArticulo articuloSeleccionado)
        {
            Navigation = navigation;
            _articuloSeleccionado = articuloSeleccionado;
            EncabezadoTem = App.encabezadoTemp;
            _isEditing = false;
            _isVisibleFinalizar = true;
            IsEnableCantidad = false;
            IsEnabledTxtCodArti = true;
            LstPedidoTemporal = new ObservableCollection<Modelxxxxvpax>();
            IsVisibleReiniciar = true;
            OpacityInfoArti = 0.5;
            IsVisibleAdd = false;

            _ =getMovimientos();
            //Mensaje suscriptor para actualizar el encabezado del pedido (ClienteViewModel)
            MessagingCenter.Subscribe<Object>(this, "ContinuarPedido2", (sender) =>
            {
                EncabezadoTem = App.encabezadoTemp;
            });

            if(ArticuloSeleccionado != null)
            {
                _cantidadArtiActual = "1";
                _valUnidad = articuloSeleccionado.artivlr1_c.ToString();
                _ = calcularValorParcial();
                IsEnableCantidad = true;
                IsEnabledTxtCodArti = false;
                CodArtiABuscar = ArticuloSeleccionado.articodigo;
                IsVisibleReiniciar = false;
                OpacityInfoArti = 1;
                IsVisibleAdd = true;
            }
            //Mensaje suscriptor para reiniciar el pedido 
            MessagingCenter.Subscribe<Object>(this, "ReinicarPedido", (sender) =>
            {
                EncabezadoTem = App.encabezadoTemp;
            });
        }

        //CONSTRUCTOR PARA EDITAR UN MOVIMIENTO
        public ViewModelGestionarArticulos(INavigation navigation,Modelxxxxvpax movimientoSeleccionado)
        {
            Navigation = navigation;
            EncabezadoTem = App.encabezadoTemp;
            _movAEditar = movimientoSeleccionado;
            _cantidadArtiActual = movimientoSeleccionado.cantinic.ToString();
            _detallesArti = movimientoSeleccionado.detalle;
            _valParcialArtiActual = movimientoSeleccionado.neto.ToString();
            _valUnidad = movimientoSeleccionado.valor.ToString();
            _isEditing = true;
            _isVisibleFinalizar = false;
            IsEnableCantidad = true;
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
        public bool IsEditing
        {
            get { return _isEditing; }
            set { SetValue(ref _isEditing, value); }
        }
        public string ValUnidad
        {
            get { return _valUnidad; }
            set { SetValue(ref _valUnidad, value); }
        }
        public Modelxxxxvpax MovAEditar
        {
            get { return _movAEditar; }
            set { SetValue(ref _movAEditar, value); }
        }
        public int PrecioTotalPedido
        {
            get { return _precioTotalPedido; }
            set { SetValue(ref _precioTotalPedido, value); }
        }
        public int CantidadTotalPedido
        {
            get { return _cantidadTotalPedido; }
            set { SetValue(ref _cantidadTotalPedido, value); }
        }
        public int PesoTotalPedido
        {
            get { return _pesoTotalPedido; }
            set { SetValue(ref _pesoTotalPedido, value); }
        }
        public bool IsVisibleFinalizar
        {
            get { return _isVisibleFinalizar; }
            set { SetValue(ref _isVisibleFinalizar, value); }
        }
        public bool IsEnableCantidad
        {
            get { return _isEnableCantidad; }
            set { SetValue(ref _isEnableCantidad, value); }
        }
        public string CodArtiABuscar
        {
            get { return _codArtiABuscar; }
            set { SetValue(ref _codArtiABuscar, value); }
        }
        public bool IsEnabledTxtCodArti
        {
            get { return _isEnabledTxtCodArti; }
            set { SetValue(ref _isEnabledTxtCodArti, value); }
        }
        public bool IsVisibleReiniciar
        {
            get { return _isVisibleReiniciar; }
            set { SetValue(ref _isVisibleReiniciar, value); }
        }
        public double OpacityInfoArti
        {
            get { return _opacityInfoArti; }
            set { SetValue(ref _opacityInfoArti, value); }
        }
        public bool IsVisibleAdd
        {
            get { return _isVisibleAdd; }
            set { SetValue(ref _isVisibleAdd, value); }
        }
        //Procesos
        public async Task irAVerGrupos()
        {
            if (ArticuloSeleccionado == null)
            {
                if (IsEditing)
                {
                    await DisplayAlert("Aviso", "Se esta editando un movimiento", "Ok");
                    return;
                }
                if (App.encabezadoTemp == null)
                {
                    await DisplayAlert("Error", "Seleccione un cliente y luego darle continuar", "Ok");
                    return;
                }
                if (CodArtiABuscar != null && CodArtiABuscar != "")
                {
                    var articuloSeleccionado = await ServicesArticulos.getArticulo(CodArtiABuscar);
                    if (articuloSeleccionado == null)
                    {
                        await DisplayAlert("Aviso",$"No existe un articolo con el codigo: {CodArtiABuscar}","Ok");
                        return;
                    }
                    await Navigation.PushAsync(new GestionarArticulos(articuloSeleccionado));
                }
                else
                {
                    await Navigation.PushAsync(new VerGrupos());
                }
            }
            else
            {
                await DisplayAlert("Aviso", "Ya tiene un articulo seleccionado para añadir", "Ok");
            }
        }
        public async Task addArticuloPedidoTemp()
        {
            UserDialogs.Instance.ShowLoading("Agregando");
            await Task.Delay(500);
            ObservableCollection<ModelArticulo> lstAux = new ObservableCollection<ModelArticulo>();
            if (App.encabezadoTemp == null)
            {
                await DisplayAlert("Error","Seleccione un cliente y luego darle continuar", "Ok");
                UserDialogs.Instance.HideLoading();
                return;
            }
            
            if (!IsEditing)
            {
                if (ArticuloSeleccionado == null)
                {
                    await DisplayAlert("Aviso", "No se ha seleccionado un articulo a agregar", "Ok");
                    UserDialogs.Instance.HideLoading();
                    return;
                }
                if (ArticuloSeleccionado.articodigo != null)
                {
                    await Servicesxxxxvpax.addMoviminetoPedidoTemp(ArticuloSeleccionado, EncabezadoTem, Convert.ToInt32(CantidadArtiActual), Convert.ToInt32(ValParcialArtiActual), DetallesArti);
                }
            }
            else
            {
                await Servicesxxxxvpax.modificarMovimineto(MovAEditar.Id_vpar, _detallesArti, _cantidadArtiActual,_valParcialArtiActual) ;
            }
            UserDialogs.Instance.HideLoading();
            await Navigation.PopToRootAsync();   
        }
        public async Task getMovimientos()
        {
            //if (IsRefreshing) { return; }
            
            try
            {
                IsVisible = false;
                _isRefreshing = true;
                if (EncabezadoTem != null) 
                {
                    LstPedidoTemporal = await Servicesxxxxvpax.getMovimientosPedidoTemp(EncabezadoTem.id_vtaped);
                    calcularTotalesPedido();
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally { IsRefreshing = false; }
        }
        public async Task calcularValorParcial()
        {
            if( CantidadArtiActual!="")
            {
                ValParcialArtiActual = await Task.Run(() => (Convert.ToInt32(CantidadArtiActual) * Convert.ToUInt32(ValUnidad)).ToString());
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
                if (ArticuloSeleccionado == null)
                {
                    IsVisible = true;
                }
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
            bool respuesta = await DisplayAlert("Aviso", $"Seguro que quiere borrar el articulo {movimientoAborrar.detalle} ?", "yes", "no");
            if (respuesta)
            {
                await Servicesxxxxvpax.borrarMovimiento(movimientoAborrar.Id_vpar);
            }
            await getMovimientos();   
        }
        public async Task editarMovimiento()
        {
            Modelxxxxvpax movimientoAeditar = MovimientoSeleccionado;
            await DisplayAlert("Aviso", $"Se editara el producto {movimientoAeditar.detalle}, una vez finalizado darle agregar", "ok");
            await Navigation.PushAsync(new GestionarArticulos(movimientoAeditar));
        }
        public void calcularTotalesPedido()
        {
            PrecioTotalPedido = 0;
            CantidadTotalPedido = 0;
            PesoTotalPedido = 0;
            if (!IsEditing && LstPedidoTemporal.Count > 0)
            {
                foreach (var movimiento in LstPedidoTemporal)
                {
                    PrecioTotalPedido += movimiento.neto;
                    CantidadTotalPedido += movimiento.cantinic;
                    PesoTotalPedido += movimiento.peso;
                }
            }
        }
        public async Task reiniciarPedido()
        {
            if (App.encabezadoTemp != null)
            {
                bool respuesta = await DisplayAlert("Aviso", "Seguro desea borrar todo el pedido actual?", "Si", "No");
                if (respuesta)
                {
                    await Servicesxxxxvped.borrarEncabezado(App.encabezadoTemp.id_vtaped);
                    App.encabezadoTemp = null;
                    LstPedidoTemporal = null;
                    PrecioTotalPedido = 0;
                    CantidadTotalPedido = 0;
                    PesoTotalPedido = 0;

                    MessagingCenter.Send<Object>(this, "ReinicarPedido"); //Mensaje a Home, para volver a la pagina Cliente

                }
            }
            else
            {
                await DisplayAlert("Aviso", "No hay un pedido para reiniciar", "Ok");
                return;
            }
            
        }
        public async Task enviarCorreo()
        {
            if (App.encabezadoTemp == null || LstPedidoTemporal.Count == 0)
            {
                await DisplayAlert("Aviso", "No hay ningun pedido o articulo para enviar", "Ok");
                return;
            }
            bool respuesta = await DisplayAlert("Finalizar", "Esta seguro que quiere finalizar el pedido?", "Si", "No");
            if (respuesta)
            {
                try
                {
                    //Propiedades del mensaje
                    var message = new EmailMessage
                    {
                        Subject = "Informacion Pedido",
                        Body = crearBodyMensaje(),
                        To = { App.clienteActual.troemail },
                    };

                    //API que se encarga de abrir el cliente como el Gmail, Outlook u otros para realizar el envío del mensaje
                    await Email.ComposeAsync(message);
                }
                catch (FeatureNotSupportedException fnsEx)
                {
                    // Email is not supported on this device
                    await DisplayAlert("Error", fnsEx.ToString(), "OK");
                }
                catch (Exception ex)
                {
                    // Some other exception occurred
                    await DisplayAlert("Error", ex.ToString(), "OK");
                }
                App.encabezadoTemp = null;
                App.clienteActual = null;
                EncabezadoTem = App.encabezadoTemp;
                LstPedidoTemporal.Clear();
            }
        }
        public string crearBodyMensaje()
        {
            string body = "";
            int i = 1;
            foreach (var movimiento  in LstPedidoTemporal)
            {
                body += $"-{i} \t {movimiento.detalle}\t Cantidad:{movimiento.cantinic}\t Neto:${movimiento.neto}\n";
                body += "\n";
                i++;
            }
            body += "----------------------------------------";
            body += $"\nTotal=${PrecioTotalPedido}";
            return body;
        }
        public async Task leerCodigoDeBarras()
        {
            try
            {
                var scanner = new ZXing.Mobile.MobileBarcodeScanner();
                scanner.TopText= "Centre el codigo dentro de la pantalla";
                var result = await scanner.Scan();
                if (result != null)
                {
                    CodArtiABuscar = result.Text;
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message.ToString(), "ok");
                throw;
            }
        }

        //Comandos
        public ICommand irAVerGruposcommand => new Command(async () => await irAVerGrupos());
        public ICommand addArticuloPedidoTempcommand => new Command(async () => await addArticuloPedidoTemp());
        public ICommand calcularValorParcialcommand => new Command(async () => await calcularValorParcial());
        public ICommand getMovimientoscommand => new Command(async () => await getMovimientos());
        public ICommand activarBotonescommand => new Command(() =>  activarBotones());
        public ICommand borrarMovimientocommand => new Command(async () => await borrarMovimiento());
        public ICommand editarMovimientocommand => new Command(async () => await editarMovimiento());
        public ICommand calcularTotalesPedidocommand => new Command(() => calcularTotalesPedido());
        public ICommand reiniciarPedidocommand => new Command(async () => await reiniciarPedido());
        public ICommand enviarCorreocommand => new Command(async () => await enviarCorreo());
        public ICommand leerCodigoDeBarrascommand => new Command(async () => await leerCodigoDeBarras());
    }
}
