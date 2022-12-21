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
        public static ObservableCollection<ModelArticulo> lstaArticulos;

        public ServicesArticulos() 
        {
            obtenerTodoArticulos();
        }

        public static async Task<ObservableCollection<ModelArticulo>> extraerArticulos(ModelGrupo grupo)
        {
            var conexionBD = await DataConexion.conectar();

            try
            {
                ObservableCollection<ModelArticulo> listArticulos = new ObservableCollection<ModelArticulo> { };
                string query = "SELECT * FROM xxxxarti  WHERE artigrupo=" + grupo.codigo;
                MySqlCommand comando = new MySqlCommand(query);
                //comando.Parameters.AddWithValue("@codigo_grupo", codigoGrupo);
                MySqlDataReader reader = null;
                comando.Connection = conexionBD;
                conexionBD.Open();
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    ModelArticulo articulo = new ModelArticulo();
                    articulo.articodigo = reader.GetString(0).ToString();
                    articulo.artigrupo = reader.GetString(1).ToString();
                    articulo.artigrupo = reader.GetString(2).ToString();
                    articulo.artinomb = reader.GetString(3).ToString();

                    listArticulos.Add(articulo);
                }
                reader.Close();
                conexionBD.Close();
                return listArticulos;

            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                //throw;
            }
            return null;
        }

        public static async Task<ObservableCollection<ModelArticulo>> obtenerTodoArticulos()
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
                    articulo.artigrupo = reader.GetString(2).ToString();
                    articulo.artinomb = reader.GetString(3).ToString();

                    listArticulos.Add(articulo);
                }
                reader.Close();
                conexionBD.Close();
                return listArticulos;

            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                //throw;
            }
            return null;
        }
    }
}
