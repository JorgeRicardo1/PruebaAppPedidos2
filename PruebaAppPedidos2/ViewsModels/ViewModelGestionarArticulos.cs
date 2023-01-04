using System;
using System.Collections.Generic;
using System.Text;
using PruebaAppPedidos2.Views;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PruebaAppPedidos2.ViewsModels
{
    class ViewModelGestionarArticulos : BaseViewModel
    {
        //Variables


        //Constructor
        public ViewModelGestionarArticulos(INavigation navigation)
        {
            Navigation = navigation;
        }
        //Objetos



        //Procesos
        public async Task irAVerGrupos()
        {
            await Navigation.PushAsync(new VerGrupos());
        }

        //Comandos
        public ICommand irAVerGruposcommand => new Command(async () => await irAVerGrupos());
    }
}
