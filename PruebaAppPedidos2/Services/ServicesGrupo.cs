using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using PruebaAppPedidos2.Data;
using PruebaAppPedidos2.Models;
using PruebaAppPedidos2.Services;     

namespace PruebaAppPedidos2.Services
{
    //ESTO SOLO ES UN COMENTARIO DE PRUEBAS
    //OTRO COMENTARIO DE PRUEBA
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
                    grupo.librecnt = reader.GetInt32(3);
                    grupo.librecto= reader.GetInt32(4);
                    grupo.acumula = reader.GetInt32(5);
                    grupo.inventar = reader.GetString(6).ToString();
                    grupo.ventas= reader.GetString(7).ToString();
                    grupo.vcontadoe = reader.GetString(8).ToString();
                    grupo.vcreditog = reader.GetString(9).ToString();
                    grupo.vdevolue= reader.GetString(10).ToString();
                    grupo.vdevolug= reader.GetString(11).ToString();
                    grupo.viva= reader.GetString(12).ToString();
                    grupo.vivadev= reader.GetString(13).ToString();    
                    grupo.ccontadoe= reader.GetString(14).ToString();
                    grupo.ccontadog= reader.GetString(15).ToString();
                    grupo.ccreditog= reader.GetString(16).ToString();
                    grupo.cdevolue= reader.GetString(17).ToString();
                    grupo.cdevolug= reader.GetString(18).ToString();
                    grupo.civa= reader.GetString(19).ToString();
                    grupo.civadev= reader.GetString(20).ToString();
                    //grupo.activo = reader.GetInt32(21);
                    grupo.req_serial = reader.GetInt32(22);
                    grupo.dscmax= reader.GetInt32(23);
                    grupo.utilidad= reader.GetInt32(24);
                    grupo.util_vta= reader.GetInt32(25);
                    //grupo.ajustes = reader.GetString(26).ToString();
                    grupo.impresora= reader.GetString(27).ToString();
                    grupo.keyx= reader.GetString(28).ToString();
                    grupo.parentx= reader.GetString(29).ToString();
                    grupo.lugar= reader.GetString(30).ToString();
                    grupo.antex= reader.GetString(31).ToString();
                    //grupo.logou = reader.GetInt32(32);

                    listGrupos.Add(grupo);
                }
                reader.Close();
                conexionBD.Close();
                Grupos = listGrupos;

            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                throw new InvalidOperationException("what happend");
            }
        }

        
    }
}
