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
                //string query = "SELECT * FROM xxxxarti";
                string query = "SELECT articodigo,artigrupo,articodi2,artinomb,artiunidad,artiaplica,artirefer,articontie, artipeso, articolor,artimarca,artiinvima,artinomb2,artiforma, artiptoi,artiptor,artiptop1,artiptop2," +
                    "artivlr1_c,artivlr2_c,artivlr3_c,artivlr4_c, artiiva, articant " +
                    "FROM xxxxarti,xxxxartv " +
                    "where xxxxarti.articodigo=xxxxartv.artvcodigo";
                MySqlCommand comando = new MySqlCommand(query);
                MySqlDataReader reader = null;
                comando.Connection = conexionBD;
                conexionBD.Open();
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    ModelArticulo articulo = new ModelArticulo();
                    articulo.articodigo = reader.GetString("articodigo").ToString();
                    articulo.artigrupo = reader.GetString("artigrupo").ToString();
                    articulo.articodi2 = reader.GetString("articodi2").ToString();
                    articulo.artinomb = reader.GetString("artinomb").ToString();
                    articulo.artiunidad = reader.GetString("artiunidad").ToString();
                    articulo.artiaplica = reader.GetString("artiaplica").ToString();
                    articulo.artirefer = reader.GetString("artirefer").ToString();
                    articulo.articontie = reader.GetInt32("articontie");
                    articulo.artipeso = reader.GetInt32("artipeso");
                    articulo.articolor = reader.GetString("articolor").ToString();
                    articulo.artimarca = reader.GetString("artimarca").ToString();
                    articulo.artiinvima = reader.GetString("artiinvima").ToString();
                    articulo.artinomb2 = reader.GetString("artinomb2").ToString();
                    articulo.artiforma = reader.GetString("artiforma").ToString();
                    articulo.artiptoi = reader.GetInt32("artiptoi");
                    articulo.artiptor = reader.GetInt32("artiptor");
                    articulo.artiptop1 = reader.GetInt32("artiptop1");
                    articulo.artiptop2 = reader.GetInt32("artiptop2");
                    articulo.artivlr1_c = reader.GetInt32("artivlr1_c");
                    articulo.artivlr2_c = reader.GetInt32("artivlr2_c");
                    articulo.artivlr3_c = reader.GetInt32("artivlr3_c");
                    articulo.artivlr4_c = reader.GetInt32("artivlr4_c");
                    articulo.artiiva = reader.GetInt32("artiiva");
                    articulo.articant = reader.GetInt32("articant");

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
        public static async Task<ModelArticulo> getArticulo(string codiArti)
        {
            ModelArticulo articulo = new ModelArticulo();
            var conexionBD = await DataConexion.conectar();

            try
            {
                string query = $"SELECT articodigo,artigrupo,articodi2,artinomb,artiunidad,artiaplica,artirefer,articontie, artipeso, articolor,artimarca,artiinvima,artinomb2,artiforma, artiptoi,artiptor,artiptop1,artiptop2," +
                    $"artivlr1_c,artivlr2_c,artivlr3_c,artivlr4_c, artiiva, articant " +
                    $"FROM xxxxarti,xxxxartv " +
                    $"where xxxxarti.articodigo=xxxxartv.artvcodigo " +
                    $"AND xxxxarti.articodigo = '{codiArti}'";
                MySqlCommand comando = new MySqlCommand(query);
                MySqlDataReader reader = null;
                comando.Connection = conexionBD;
                conexionBD.Open();
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        articulo.articodigo = reader.GetString("articodigo").ToString();
                        articulo.artigrupo = reader.GetString("artigrupo").ToString();
                        articulo.articodi2 = reader.GetString("articodi2").ToString();
                        articulo.artinomb = reader.GetString("artinomb").ToString();
                        articulo.artiunidad = reader.GetString("artiunidad").ToString();
                        articulo.artiaplica = reader.GetString("artiaplica").ToString();
                        articulo.artirefer = reader.GetString("artirefer").ToString();
                        articulo.articontie = reader.GetInt32("articontie");
                        articulo.artipeso = reader.GetInt32("artipeso");
                        articulo.articolor = reader.GetString("articolor").ToString();
                        articulo.artimarca = reader.GetString("artimarca").ToString();
                        articulo.artiinvima = reader.GetString("artiinvima").ToString();
                        articulo.artinomb2 = reader.GetString("artinomb2").ToString();
                        articulo.artiforma = reader.GetString("artiforma").ToString();
                        articulo.artiptoi = reader.GetInt32("artiptoi");
                        articulo.artiptor = reader.GetInt32("artiptor");
                        articulo.artiptop1 = reader.GetInt32("artiptop1");
                        articulo.artiptop2 = reader.GetInt32("artiptop2");
                        articulo.artivlr1_c = reader.GetInt32("artivlr1_c");
                        articulo.artivlr2_c = reader.GetInt32("artivlr2_c");
                        articulo.artivlr3_c = reader.GetInt32("artivlr3_c");
                        articulo.artivlr4_c = reader.GetInt32("artivlr4_c");
                        articulo.artiiva = reader.GetInt32("artiiva");
                        articulo.articant = reader.GetInt32("articant");
                    }
                    return articulo;
                }
                else
                {
                    return null;
                }
            }           
            catch (Exception)
            {

                throw;
            }
        }
        public static async Task<ObservableCollection<ModelArticulo>> obtenerArticulosDeGrupo(string codidoGrupo)
        {
            ObservableCollection<ModelArticulo> listArticulos = new ObservableCollection<ModelArticulo> { };
            try
            {
                var conexionDB = await DataConexion.conectar();
                string query = $"SELECT * FROM xxxxarti WHERE artigrupo = '{codidoGrupo}'";
                MySqlCommand comando = new MySqlCommand(query);
                MySqlDataReader reader = null;
                comando.Connection = conexionDB;
                conexionDB.Open();
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
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
                        //await obtenerPrecioInfo(articulo);

                        listArticulos.Add(articulo);
                    }
                    reader.Close();
                    conexionDB.Close();
                }
                return listArticulos;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static async Task obtenerPrecioInfo(ModelArticulo articulo)
        {
            try
            {
                var conexionDB = await DataConexion.conectar();
                conexionDB.Open();
                string query = $"SELECT artinomb , artivlr1_c, artiiva FROM xxxxarti JOIN xxxxartv ON xxxxarti.articodigo = xxxxartv.artVcodigo WHERE xxxxarti.articodigo = '{articulo.articodigo}'";
                MySqlCommand comando = new MySqlCommand(query);
                MySqlDataReader reader = null;
                comando.Connection = conexionDB;
                reader = comando.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        articulo.artivlr1_c = reader.GetInt32(1);
                        articulo.artiiva = reader.GetInt32(2);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
