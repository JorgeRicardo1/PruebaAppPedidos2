﻿using System;
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
                    articulo.artiunidad = reader.GetString(4).ToString();
                    articulo.artiaplica = reader.GetString(5).ToString();
                    articulo.artirefer = reader.GetString(6).ToString();
                    articulo.articontie = reader.GetInt32(7);
                    articulo.artipeso = reader.GetInt32(8);
                    articulo.articolor = reader.GetString(9).ToString();
                    articulo.artimarca = reader.GetString(10).ToString();
                    articulo.artiinvima = reader.GetString(11).ToString();
                    articulo.artinomb2 = reader.GetString(12).ToString();
                    articulo.artiforma = reader.GetString(13).ToString();
                    articulo.artiptoi = reader.GetInt32(14);
                    articulo.artiptor = reader.GetInt32(15);
                    articulo.artiptop1 = reader.GetInt32(16);
                    articulo.artiptop2 = reader.GetInt32(17);

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
        public static async Task<ObservableCollection<ModelArticulo>> filtrarArticulos(List<string> palabras)
        {
            ObservableCollection<ModelArticulo> articulosFiltrados = new ObservableCollection<ModelArticulo>();
            try
            {
                var conexionDB = await DataConexion.conectar();
                
                foreach (string palabra in palabras)
                {
                    if(palabra != "" && palabra != null)
                    {
                        conexionDB.Open();
                        string query = $"SELECT * FROM xxxxarti WHERE artinomb like '%{palabra}%' OR  artimarca like '%{palabra}%' OR articodi2 like '{palabra}%'";
                        MySqlCommand comando = new MySqlCommand(query);
                        MySqlDataReader reader = null;
                        comando.Connection = conexionDB;
                        
                        reader = comando.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while(reader.Read())
                            {
                                ModelArticulo articulo = new ModelArticulo();
                                articulo.articodigo = reader.GetString(0).ToString();
                                articulo.artigrupo = reader.GetString(1).ToString();
                                articulo.articodi2 = reader.GetString(2).ToString();
                                articulo.artinomb = reader.GetString(3).ToString();
                                articulo.artiunidad = reader.GetString(4).ToString();
                                articulo.artiaplica = reader.GetString(5).ToString();
                                articulo.artirefer = reader.GetString(6).ToString();
                                articulo.articontie = reader.GetInt32(7);
                                articulo.artipeso = reader.GetInt32(8);
                                articulo.articolor = reader.GetString(9).ToString();
                                articulo.artimarca = reader.GetString(10).ToString();
                                articulo.artiinvima = reader.GetString(11).ToString();
                                articulo.artinomb2 = reader.GetString(12).ToString();
                                articulo.artiforma = reader.GetString(13).ToString();
                                articulo.artiptoi = reader.GetInt32(14);
                                articulo.artiptor = reader.GetInt32(15);
                                articulo.artiptop1 = reader.GetInt32(16);
                                articulo.artiptop2 = reader.GetInt32(17);


                                if (!articulosFiltrados.Contains(articulo))
                                {
                                    articulosFiltrados.Add(articulo);
                                }
                            }
                        }
                    }
                    conexionDB.Close();
                }
                
                return articulosFiltrados;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
