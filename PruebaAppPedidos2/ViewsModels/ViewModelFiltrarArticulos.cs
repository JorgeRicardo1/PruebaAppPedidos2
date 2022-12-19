using PruebaAppPedidos2.Models;
using PruebaAppPedidos2.Services;
using PruebaAppPedidos2.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PruebaAppPedidos2.ViewsModels
{
    class ViewModelFiltrarArticulos : BaseViewModel
    {
        //VARIABLES
        public ObservableCollection<ModelArticulo> _listArticulos;
        public string _palabra1;
        public string _palabra2;
        public string _palabra3;
        public string _palabra4;

        //CONSTRUCTOR
        public ViewModelFiltrarArticulos(INavigation navigation)
        {
            Navigation = navigation;
        }

        //OBJETOS
        public ObservableCollection<ModelArticulo> ListArticulos
        {
            get { return _listArticulos; }
            set { SetValue(ref _listArticulos, value); }
        }

        public string  Palabra1
        {
            get { return _palabra1; }
            set { SetValue(ref _palabra1, value); }
        }
        public string Palabra2
        {
            get { return _palabra2; }
            set { SetValue(ref _palabra2, value); }
        }
        public string Palabra3
        {
            get { return _palabra3; }
            set { SetValue(ref _palabra3, value); }
        }
        public string Palabra4
        {
            get { return _palabra4; }
            set { SetValue(ref _palabra4, value); }
        }

        //PROCESOS
        public async Task filtrar()
        {
            var articulosObtenido = ServicesArticulos.obtenerTodoArticulos();
            //ListGrupos = await ServicesGrupo.extraerGrupos(); Averiguar como
            ListArticulos = new ObservableCollection<ModelArticulo> { };
            foreach (var item in articulosObtenido)
            {
                if (Palabra4 ==null && Palabra3 == null && Palabra2==null)
                {
                    if (item.artinomb.Contains(Palabra1.ToUpper()))
                    {
                        ListArticulos.Add(item);
                    }
                }
                else if (Palabra4 == null && Palabra3 == null)
                {
                    if (item.artinomb.Contains(Palabra1.ToUpper() + " " + Palabra2.ToUpper()))
                    {
                        ListArticulos.Add(item);
                    }
                }
                else if (Palabra4 == null)
                {
                    if (item.artinomb.Contains(Palabra1.ToUpper() + " " + Palabra2.ToUpper() + " " + Palabra3.ToUpper()))
                    {
                        ListArticulos.Add(item);
                    }
                }
                else if (Palabra4 != null && Palabra3 != null && Palabra2 != null && Palabra1 != null)
                {
                    if (item.artinomb.Contains(Palabra1.ToUpper() + " " + Palabra2.ToUpper() + " " + Palabra3.ToUpper() + " " + Palabra4.ToUpper()))
                    {
                        ListArticulos.Add(item);
                    }
                }
            }
        }
        //COMANDOS
        public ICommand filtrarCommand => new Command(async () => await filtrar());
    }
}
