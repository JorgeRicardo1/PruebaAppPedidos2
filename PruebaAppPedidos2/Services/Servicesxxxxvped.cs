using MySqlConnector;
using PruebaAppPedidos2.Data;
using PruebaAppPedidos2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace PruebaAppPedidos2.Services
{
    public class Servicesxxxxvped
    {
        public static async Task<ObservableCollection<Modelxxxxvped>> getAllPedidosVendedor(string idVendedor)
        {
            var conexionBD = await DataConexion.conectar();
            ObservableCollection<Modelxxxxvped> pedidosVendedor = new ObservableCollection<Modelxxxxvped>();
            try
            {
                string query = $"SELECT * FROM xxxxvped WHERE `vendedor`='{idVendedor}' ORDER BY id_vtaped DESC;";
                MySqlCommand comando = new MySqlCommand(query);
                MySqlDataReader reader = null;
                comando.Connection = conexionBD;
                conexionBD.Open();
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Modelxxxxvped pedido = new Modelxxxxvped();
                        pedido.nit = reader.GetString("nit");
                        pedido.numero = reader.GetString("numero");
                        pedido.fecha = reader.GetDateTime("fecha");
                        pedido.dias = reader.GetInt16("dias");
                        pedido.obra = reader.GetString("obra");
                        pedido.transporte = reader.GetString("transporte");
                        pedido.fultima = Lector.safeGetDate(reader, "fultima");
                        pedido.fdigitar = reader.GetDateTime("fdigitar");
                        pedido.hdigita = reader.GetString("hdigita");
                        pedido.factura = reader.GetString("factura");
                        pedido.datos1 = reader.GetString("datos1");
                        pedido.vendedor = reader.GetString("vendedor");
                        pedido.valor = reader.GetInt32("valor");
                        pedido.abono = reader.GetInt32("abono");
                        pedido.saldo = reader.GetInt32("saldo");
                        pedido.terminal = reader.GetString("terminal");
                        pedido.vriva = reader.GetInt32("vriva");
                        pedido.desctos = reader.GetInt32("desctos");
                        pedido.neto = reader.GetInt32("neto");
                        pedido.costo = reader.GetInt32("costo");
                        pedido.titular = reader.GetString("titular");
                        pedido.titudire = reader.GetString("titudire");
                        pedido.titutelf = reader.GetString("titutelf");
                        pedido.tituciud = reader.GetString("tituciud");
                        pedido.ped_fraxx = reader.GetInt32("ped_fraxx");
                        pedido.ped_envio = reader.GetInt32("ped_envio");
                        pedido.ped_estado = reader.GetInt32("ped_estado");
                        pedido.ped_estadn = reader.GetString("ped_estadn");
                        pedido.ped_closed = Lector.safeGetDate(reader, "ped_closed");
                        pedido.ped_closet = reader.GetString("ped_closet");
                        pedido.sucursal = reader.GetString("sucursal");
                        pedido.term_pedi = Lector.safeGetString(reader, "term_pedi");
                        pedido.grupo = reader.GetInt32("grupo");
                        pedido.fventa = Lector.safeGetDate(reader, "fventa");
                        pedido.id_vtaped = reader.GetInt32("id_vtaped");
                        //pedido.desp_nomb = Lector.safeGetString(reader, "desp_nomb");
                        //pedido.desp_direc = Lector.safeGetString(reader, "desp_direc");
                        //pedido.desp_telf = Lector.safeGetString(reader, "desp_telf");
                        //pedido.desp_city = Lector.safeGetString(reader, "desp_city");
                        pedido.consumo = reader.GetInt32("consumo");

                        pedidosVendedor.Add(pedido);
                    }
                }
                reader.Close();
                conexionBD.Close();
                return pedidosVendedor;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
