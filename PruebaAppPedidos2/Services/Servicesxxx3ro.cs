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
                        cliente.tronit = reader.GetString("tronit");
                        cliente.tronombre = reader.GetString("tronombre");
                        cliente.trozona = reader.GetString("trozona");
                        cliente.trociudad = reader.GetString("trociudad");
                        cliente.trotelef = reader.GetString("trotelef");
                        cliente.troemail = reader.GetString("troemail");
                        cliente.trocccupo = reader.GetInt32("trocccupo");
                        cliente.trotipo = reader.GetString("trotipo");
                        cliente.trocelular = reader.GetString("trocelular");
                        cliente.tronomb_2 = reader.GetString("tronomb_2");
                        cliente.troapel_1 = reader.GetString("troapel_1");
                        cliente.troapel_2 = reader.GetString("troapel_2");
                        cliente.trocpsaldo = reader.GetInt32("trocpsaldo");
                        cliente.troprecio = reader.GetInt32("troprecio");
                        cliente.troccvnc = reader.GetInt32("troccvnc");
                        cliente.troccsaldo = reader.GetInt32("troccsaldo");
                    }
                }
                else
                {
                    conexionBD.Close();
                    return null;
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
