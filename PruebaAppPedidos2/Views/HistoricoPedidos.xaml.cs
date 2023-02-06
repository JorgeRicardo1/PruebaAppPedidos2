using PruebaAppPedidos2.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PruebaAppPedidos2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoricoPedidos : ContentPage
    {
        public HistoricoPedidos()
        {
            InitializeComponent();
            BindingContext = new ViewModelHistoricoPedidos(Navigation);
        }
    }
}