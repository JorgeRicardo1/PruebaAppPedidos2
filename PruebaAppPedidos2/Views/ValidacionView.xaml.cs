using PruebaAppPedidos2.Models;
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
    public partial class ValidacionView : ContentPage
    {
        readonly private bool func = true;
        readonly private EmpresaModel empresaModel= new EmpresaModel();
        public ValidacionView(EmpresaModel empresa)
        {
            InitializeComponent();
            IdInfo.Text = DependencyService.Get<PruebaAppPedidos2.IDevice>().DeviceID();
            if (empresa == null)
            {
                func = false;
            }
            else
            {
                ServerPassword.Text = empresa.serverPassword;
                IpServer.Text = empresa.ipserver;
                CodeEmpresa.Text = empresa.empresa;
                Activar.Text = empresa.activar;
                Usuario.Text = empresa.usuario;
            }
        }

        private async void BtnGuardar_Clicked(object sender, EventArgs e)
         {
            empresaModel.activar = Activar.Text;
            empresaModel.empresa = CodeEmpresa.Text;
            empresaModel.ipserver = IpServer.Text;
            empresaModel.serverPassword= ServerPassword.Text;
            empresaModel.usuario = Usuario.Text;
            if (!string.IsNullOrEmpty(Usuario.Text) && !string.IsNullOrEmpty(Activar.Text) && !string.IsNullOrEmpty(CodeEmpresa.Text) && !string.IsNullOrEmpty(IpServer.Text) && !string.IsNullOrEmpty(ServerPassword.Text))
            {
                if (func)
                {
                    empresaModel.Id = 1;
                    await App.Context.updateEmpresaAsync(empresaModel);
                    System.Environment.Exit(0);
                }
                else
                {
                    await App.Context.insertEmpresaAsync(empresaModel);
                    System.Environment.Exit(0);
                }
            }
            else
            {
                await DisplayAlert("Aviso","Algunos campos estan vacios","Aceptar");
            }
        }
    }
}