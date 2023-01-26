using MySqlConnector;
using PruebaAppPedidos2.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PruebaAppPedidos2.Data
{
    public class DataConexion
    {
        //private static string connectionString = "Database = a000; Data Source = 192.168.1.108; User Id = pruebas; Password= qwerty";
        public static MySqlConnection conexionBD { get; set; }
        private static string connectionString { get; set; }

        

        public static async Task<MySqlConnection> conectar()
        {
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
        public static void getConnectionString(List<EmpresaModel> empresa)
        {
            connectionString = $"Database = {empresa[0].empresa}; Data Source = {empresa[0].ipserver}; User Id = {empresa[0].usuario}; Password= {empresa[0].serverPassword}";
            //connectionString = "Database = a000; Data Source = 192.168.1.108; User Id = pruebas; Password= qwerty";
        }
    }
}
