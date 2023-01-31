using PruebaAppPedidos2.Models;
using PruebaAppPedidos2.Services;
using PruebaAppPedidos2.Views;
using System;
using System.Collections.Generic;
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
        //CONSTRUCTOR
        public ViewModelLoginOperario()
        {

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
        //PROCESOS
        public async Task validarOperario()
        {
            if (ClaveOperario == null)
            {
                ClaveOperario = "";
            }
            if (NombreOperario == null )
            {
                await DisplayAlert("Aviso", "por favor colocar el operario", "ok");
                return;
            }
            Modelxxxxciao operario = await Servicesxxxxciao.getOperario(NombreOperario);
            if (operario == null)
            {
                await DisplayAlert("Aviso",$"No existe un operario {NombreOperario}","ok");
                return;
            }
            else
            {
                if (operario.pw != ClaveOperario)
                {
                    await DisplayAlert("Aviso","Contraseña incorrecta","Ok");
                    return;
                }
                else
                {
                    App.Operario = operario;
                    Application.Current.MainPage = new NavigationPage(new MainPage());
                }
            }
        }
        //COMANDOS
        public ICommand validarOperariocommand => new Command(async () => await validarOperario());
    }
}
