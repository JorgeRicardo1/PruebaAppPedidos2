using Acr.UserDialogs;
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
    public class ViewModelLoginOperario : BaseViewModel
    {
        //VARIABLES
        public string _nombreOperario;
        public string _claveOperario;
        public ObservableCollection<Modelxxxxciao> _operariosPedidos;
        public Modelxxxxciao _operarioSeleccionado;

        //CONSTRUCTOR
        public ViewModelLoginOperario()
        {
            _ = getOperarios();
        }
        //OBJETOS
        public string NombreOperario
        {
            get { return _nombreOperario; }
            set { SetValue(ref _nombreOperario, value); }
        }
        public string ClaveOperario
        {
            get { return _claveOperario; }
            set { SetValue(ref _claveOperario, value); }
        }
        public ObservableCollection<Modelxxxxciao> OperariosPedidos
        {
            get { return _operariosPedidos; }
            set { SetValue(ref _operariosPedidos, value); }
        }
        public Modelxxxxciao OperarioSeleccionado
        {
            get { return _operarioSeleccionado; }
            set { 
                    SetProperty(ref _operarioSeleccionado, value);
                    NombreOperario = _operarioSeleccionado.nombre;
                }
        }
        //PROCESOS
        public async Task validarOperario()
        {
            UserDialogs.Instance.ShowLoading("Accediendo");
            await Task.Delay(500);
            if (ClaveOperario == null)
            {
                ClaveOperario = "";
            }
            if (NombreOperario == null )
            {
                await DisplayAlert("Aviso", "por favor colocar el operario", "ok");
                UserDialogs.Instance.HideLoading();
                return;
            }
            Modelxxxxciao operario = await Servicesxxxxciao.getOperario(NombreOperario);
            if (operario == null)
            {
                await DisplayAlert("Aviso",$"No existe un operario {NombreOperario}","ok");
                UserDialogs.Instance.HideLoading();
                return;
            }
            else
            {
                if (operario.pw != ClaveOperario)
                {
                    await DisplayAlert("Aviso","Contraseña incorrecta","Ok");
                    UserDialogs.Instance.HideLoading();
                    return;
                }
                else
                {
                    App.Operario = operario;
                    Application.Current.MainPage = new NavigationPage(new MainPage());
                    UserDialogs.Instance.HideLoading();
                }
            }
        }

        public async Task getOperarios()
        {
            OperariosPedidos = await Servicesxxxxciao.getOperariosPedidos();
        }

        //COMANDOS
        public ICommand validarOperariocommand => new Command(async () => await validarOperario());
    }
}
