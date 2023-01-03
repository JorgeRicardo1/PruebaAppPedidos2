using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using PruebaAppPedidos2.Data;
using PruebaAppPedidos2.Models;

namespace PruebaAppPedidos2.Services
{
    public class Servicesxxx3ro
    {

        public static async Task<Modelxxx3ro> extraerCliente(string codigoCliente)
        {
            var conexionBD = await DataConexion.conectar();

            try
            {
                Modelxxx3ro cliente = new Modelxxx3ro();
                string query = $"SELECT * FROM xxxx3ros WHERE tronit='{codigoCliente}'";
                MySqlCommand comando = new MySqlCommand(query);
                MySqlDataReader reader = null;
                comando.Connection = conexionBD;
                conexionBD.Open();
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        cliente.trotelef = reader.GetString(9);
                        cliente.tronombre = reader.GetString(1);
                        cliente.troemail = reader.GetString(11);
                        cliente.trocccupo = reader.GetInt32(31);
                        cliente.trotipo = reader.GetString(6);
                        cliente.troprecio = reader.GetInt32(37);
                        cliente.trocelular = reader.GetString(70);
                    }
                }
                conexionBD.Close();
                return cliente;
            }
            catch (Exception)
            {

                throw;
            }
        }
    } 
}
