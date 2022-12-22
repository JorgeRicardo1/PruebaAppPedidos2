using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using PruebaAppPedidos2.Data;
using PruebaAppPedidos2.Models;

namespace PruebaAppPedidos2.Services
{
    public class ServicesGrupo
    {
        public static ObservableCollection<ModelGrupo> Grupos { get; set; }

        ServicesGrupo() 
        {
        }

        public static async Task extraerGrupos()
        {
            var conexionBD = await DataConexion.conectar();
            
            try
            {
                ObservableCollection<ModelGrupo> listGrupos = new ObservableCollection<ModelGrupo> { };
                string query = "SELECT * FROM xxxxgrup";
                MySqlCommand comando = new MySqlCommand(query);
                MySqlDataReader reader = null;
                comando.Connection = conexionBD;
                conexionBD.Open();
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    ModelGrupo grupo = new ModelGrupo();
                    grupo.codigo = reader.GetString(0).ToString();
                    grupo.nombre = reader.GetString(1).ToString();
                    grupo.tipo = reader.GetString(2).ToString();

                    listGrupos.Add(grupo);
                }
                reader.Close();
                conexionBD.Close();
                Grupos = listGrupos;

            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                //throw;
            }
        }
    }
}
