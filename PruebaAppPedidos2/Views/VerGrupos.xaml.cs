using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaAppPedidos2.ViewsModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PruebaAppPedidos2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VerGrupos : ContentPage
    {
        public VerGrupos()
        {
            InitializeComponent();
            BindingContext = new ViewModelVerGrupo(Navigation);
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var _container = BindingContext as ViewModelVerGrupo;
            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                grup_arti_list.ItemsSource = _container.ListGrupos;
            }
            else
            {
                grup_arti_list.ItemsSource = _container.ListGrupos.Where(i => i.nombre.Contains(e.NewTextValue.ToUpper()));
            }
        }
    }
}