using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaAppPedidos2.Data
{
    public class DataConexion
    {
        private static string connectionString = "Database = a000; Data Source = 192.168.1.190; User Id = prueba; Password= qwerty";
        
        public static MySqlConnection conectar()
        {
            MySqlConnection conexionBD = null;
            try
            {
                conexionBD = new MySqlConnection(connectionString);
                return conexionBD;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("El error es " + ex.Message);
                //throw;
            }
            return null;
        }
    }
}
