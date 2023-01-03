using MySqlConnector;
using PruebaAppPedidos2.Data;
using PruebaAppPedidos2.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PruebaAppPedidos2.Services
{
    public class Servicesxxxxvped
    {
        public static async Task<Modelxxxxvped> extraerInfoDespacho(string codigoCliente)
        {
            var conexionBD = await DataConexion.conectar();

            try
            {
                Modelxxxxvped infoDespacho = new Modelxxxxvped();
                string query = $"SELECT * FROM xxxxvped WHERE nit='{codigoCliente}'";
                MySqlCommand comando = new MySqlCommand(query);
                MySqlDataReader reader = null;
                comando.Connection = conexionBD;
                conexionBD.Open();
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        infoDespacho.titular = reader.GetString(20);
                        infoDespacho.titudire = reader.GetString(21);
                        infoDespacho.titutelf = reader.GetString(22);
                        infoDespacho.tituciud = reader.GetString(23);
                    }
                }
                conexionBD.Close();
                return infoDespacho;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
