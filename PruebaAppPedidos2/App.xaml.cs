using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PruebaAppPedidos2.Views;
using PruebaAppPedidos2.Models;
using PruebaAppPedidos2.Data;
using SQLite;
using System.Threading.Tasks;
using PruebaAppPedidos2.Services;

namespace PruebaAppPedidos2
{
    public partial class App : Application
    {
        //Variable global para almacenar el encabezado del pedido
        public static Modelxxxxvped encabezadoTemp { get; set; }
        public static Modelxxx3ro clienteActual { get; set; }
        public static DataBase Context { get; set; }
        public static SQLiteAsyncConnection Connection { get; set; }
        private bool func = true;

        public App()
        {
            InitializeComponent();
            InitializeDatabase();
            //MainPage = new NavigationPage(new Home());
            
        }
        private void InitializeDatabase()
        {
            var folderApp = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData); // ruta de la carpera local del aplicativo
            var dbPath = System.IO.Path.Combine(folderApp, "pedidos.db");
            Context = new DataBase(dbPath, Connection);
        }

        protected override void OnStart()  
        {

            var id = DependencyService.Get<PruebaAppPedidos2.IDevice>().DeviceID();
            //var id = "celular004";
            Task.Run(async () =>
            {
                try
                {
                    var empresa = await App.Context.getEmpresaAsync();
                    DataConexion.getConnectionString(empresa);
                    if (empresa.Count == 0)
                    {
                        func = false;
                        MainPage = new NavigationPage(new ValidacionView(null));
                    }
                    else
                    {
                        if (func)
                        {
                            var empre = await Servicesllequipo.validar(id, empresa[0].empresa);
                            if (empre != null && empre.modulos.Equals("M800") && empre.activar.Equals(empresa[0].activar))
                            {
                                
                                MainPage = new NavigationPage(new LoginOperarioPage());
                            }
                            else
                            {
                                MainPage = new NavigationPage(new ValidacionView(empresa[0]));
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    var empresa = await App.Context.getEmpresaAsync();
                    if (empresa.Count == 0)
                    {
                        func = false;
                        MainPage = new NavigationPage(new ValidacionView(null));
                    }
                    else 
                    {
                        MainPage = new NavigationPage(new ValidacionView(empresa[0]));
                    }
                }
            }).GetAwaiter().GetResult();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

    }
}
