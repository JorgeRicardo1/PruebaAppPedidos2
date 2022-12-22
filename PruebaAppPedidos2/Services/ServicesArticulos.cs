using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MySqlConnector;
using PruebaAppPedidos2.Data;
using PruebaAppPedidos2.Models;

namespace PruebaAppPedidos2.Services
{
    public class ServicesArticulos
    {
        public static ObservableCollection<ModelArticulo> Articulos;

        public ServicesArticulos() 
        {
            
        }


        public static async Task obtenerTodoArticulos()
        {
            var conexionBD =  await DataConexion.conectar();
            try
            {
                ObservableCollection<ModelArticulo> listArticulos = new ObservableCollection<ModelArticulo> { };
                string query = "SELECT * FROM xxxxarti";
                MySqlCommand comando = new MySqlCommand(query);
                MySqlDataReader reader = null;
                comando.Connection = conexionBD;
                conexionBD.Open();
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    ModelArticulo articulo = new ModelArticulo();
                    articulo.articodigo = reader.GetString(0).ToString();
                    articulo.artigrupo = reader.GetString(1).ToString();
                    articulo.articodi2 = reader.GetString(2).ToString();
                    articulo.artinomb = reader.GetString(3).ToString();

                    listArticulos.Add(articulo);
                }
                reader.Close();
                conexionBD.Close();
                Articulos = listArticulos;

            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                //throw;
            }
        }
    }
}
