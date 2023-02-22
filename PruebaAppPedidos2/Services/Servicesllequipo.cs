using MySqlConnector;
using PruebaAppPedidos2.Data;
using PruebaAppPedidos2.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace PruebaAppPedidos2.Services
{
    public class Servicesllequipo
    {
        public static async Task<EmpresaModel> validar (string mac, string empresa)
        {
            var conexionBD = await DataConexion.conectar();
            try
            {
                EmpresaModel empre = new EmpresaModel();
                string query = $"SELECT * FROM empresas.llequipo WHERE nro_mac = '{mac}' and empresa = '{empresa}'";
                MySqlCommand comando = new MySqlCommand(query);
                MySqlDataReader reader = null;
                comando.Connection = conexionBD;
                conexionBD.Open();
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        empre.empresa = reader.GetString("empresa");
                        empre.nro_mac = reader.GetString("nro_mac");
                        empre.activar = reader.GetString("activar");
                        empre.modulos = reader.GetString("modulos");
                    }
                }
                else
                {
                    conexionBD.Close();
                    return null;
                }
                reader.Close();
                string date = DateTime.UtcNow.ToString("yyyy-MM-dd");
                new MySqlCommand($"UPDATE empresas.llequipo SET maquina = '{DeviceInfo.Name}',facceso = '{date}',eq_notas='{"M10 " + date}'" +
                    $"WHERE nro_mac='{mac}'; ",conexionBD).ExecuteNonQuery();
                conexionBD.Close();
                return empre;
            }
            catch (Exception)
            {
                conexionBD.Close();
                throw;
            }
        }
    }
}
