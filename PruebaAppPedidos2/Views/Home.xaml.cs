using PruebaAppPedidos2.Models;
using PruebaAppPedidos2.Services;
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
    public partial class Home : TabbedPage
    {
        public Home()
        {
            ModelArticulo articulo = new ModelArticulo();

            InitializeComponent();
            Children.Add(new InformacionCliente());
            Children.Add(new GestionarArticulos(articulo));

            //MENSAJE SUSCRIPTOR PARA CREAR EL ENCABEZADO TEMPORAL
            MessagingCenter.Subscribe<Object, string>(this, "ContinuarPedido", (sender, tronit) =>
            {
                Task.Run(async () => await Servicesxxxxvped.crearEncabezadoTemp(tronit));
                CurrentPage = Children[1];
            });
        }
    }
}