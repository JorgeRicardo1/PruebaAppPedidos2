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
    public class Servicesxxxxvpex
    {

        public static async Task crearEncabezadoTemp(string codigoCliente, ModelDespacho despacho, string datos1)
        {
            string date = DateTime.UtcNow.ToString("yyyy-MM-dd");
            string time = DateTime.Now.ToString("HH:mm:ss");
            string operario = App.Operario.clave;
            string sucursal = App.Operario.sucursal;
            string vendedor = App.Operario.ciao_vend;
            string obra = App.Operario.obra;

            var conexionBD = await DataConexion.conectar();
            try
            {
                string query = $"INSERT INTO `xxxxvpex` " +
                    $"(`nit`, `numero`, `fecha`, `dias`, `obra`, `transporte`, `fdigitar`, `hdigita`, `datos1`, `vendedor`, `valor`, `abono`, `saldo`, `terminal`, `vriva`, `desctos`, `neto`, `costo`, `titular`, `titudire`, `titutelf`, `tituciud`, `ped_fraxx`, `ped_envio`, `ped_estado`, `sucursal`, `operario`, `grupo`, `consumo`) " +
                    $"VALUES " +
                    $"('{codigoCliente}', 'Temp', '{date}', '1', '{obra}', 'trans', '{date}', '{time}', '{datos1}', '{vendedor}', '0', '0', '0', 'ter', '0', '0', '0', '0', '{despacho.titular}', '{despacho.titudire}', '{despacho.titutelf}', '{despacho.tituciud}', '0', '1', '0', '{sucursal}', '{operario}', '0', '0')";
                MySqlCommand comando = new MySqlCommand(query);
                MySqlDataReader reader = null;
                comando.Connection = conexionBD;
                conexionBD.Open();
                reader = comando.ExecuteReader();
                conexionBD.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<Modelxxxxvped> obtenerEncabezado()
        {
            var conexionBD = await DataConexion.conectar();
            try
            {
                Modelxxxxvped encabezadoTemp = new Modelxxxxvped();
                string query = "SELECT * FROM xxxxvpex ORDER BY id_vtaped DESC limit 1";
                MySqlCommand comando = new MySqlCommand(query);
                MySqlDataReader reader = null;
                comando.Connection = conexionBD;
                conexionBD.Open();
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        encabezadoTemp.nit = reader.GetString("nit");
                        encabezadoTemp.numero = reader.GetString("numero");
                        encabezadoTemp.fecha = reader.GetDateTime("fecha");
                        encabezadoTemp.dias = reader.GetInt16("dias");
                        encabezadoTemp.obra = reader.GetString("obra");
                        encabezadoTemp.transporte = reader.GetString("transporte");
                        encabezadoTemp.fultima = Lector.safeGetDate(reader, "fultima");
                        encabezadoTemp.fdigitar = reader.GetDateTime("fdigitar");
                        encabezadoTemp.hdigita = reader.GetString("hdigita");
                        encabezadoTemp.factura = reader.GetString("factura");
                        encabezadoTemp.datos1 = reader.GetString("datos1");
                        encabezadoTemp.vendedor = reader.GetString("vendedor");
                        encabezadoTemp.valor = reader.GetInt32("valor");
                        encabezadoTemp.abono = reader.GetInt32("abono");
                        encabezadoTemp.saldo = reader.GetInt32("saldo");
                        encabezadoTemp.terminal = reader.GetString("terminal");
                        encabezadoTemp.vriva = reader.GetInt32("vriva");
                        encabezadoTemp.desctos = reader.GetInt32("desctos");
                        encabezadoTemp.neto = reader.GetInt32("neto");
                        encabezadoTemp.costo = reader.GetInt32("costo");
                        encabezadoTemp.titular = reader.GetString("titular");
                        encabezadoTemp.titudire = reader.GetString("titudire");
                        encabezadoTemp.titutelf = reader.GetString("titutelf");
                        encabezadoTemp.tituciud = reader.GetString("tituciud");
                        encabezadoTemp.ped_fraxx = reader.GetInt32("ped_fraxx");
                        encabezadoTemp.ped_envio = reader.GetInt32("ped_envio");
                        encabezadoTemp.ped_estado = reader.GetInt32("ped_estado");
                        encabezadoTemp.ped_estadn = reader.GetString("ped_estadn");
                        encabezadoTemp.ped_closed = Lector.safeGetDate(reader, "ped_closed");
                        encabezadoTemp.ped_closet = reader.GetString("ped_closet");
                        encabezadoTemp.sucursal = reader.GetString("sucursal");
                        encabezadoTemp.term_pedi = Lector.safeGetString(reader, "term_pedi");
                        encabezadoTemp.grupo = reader.GetInt32("grupo");
                        encabezadoTemp.fventa = Lector.safeGetDate(reader, "fventa");
                        encabezadoTemp.id_vtaped = reader.GetInt32("id_vtaped");
                        //encabezadoTemp.desp_nomb = Lector.safeGetString(reader, "desp_nomb");
                        //encabezadoTemp.desp_direc = Lector.safeGetString(reader, "desp_direc");
                        //encabezadoTemp.desp_telf = Lector.safeGetString(reader, "desp_telf");
                        //encabezadoTemp.desp_city = Lector.safeGetString(reader, "desp_city");
                        encabezadoTemp.consumo = reader.GetInt32("consumo");
                    }
                }
                conexionBD.Close();
                return encabezadoTemp;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static async Task borrarEncabezado(int idEncabezado)
        {
            var conexionBD = await DataConexion.conectar();
            try
            {
                string query = $"DELETE FROM `xxxxvpex` WHERE(`id_vtaped` = '{idEncabezado}')";
                MySqlCommand comando = new MySqlCommand(query);
                MySqlDataReader reader = null;
                comando.Connection = conexionBD;
                conexionBD.Open();
                reader = comando.ExecuteReader();
                conexionBD.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<ObservableCollection<Modelxxxxvped>> getAllPedidosVendedor(string idVendedor)
        {
            var conexionBD = await DataConexion.conectar();
            ObservableCollection<Modelxxxxvped> pedidosVendedor = new ObservableCollection<Modelxxxxvped>();
            try
            {
                string query = $"SELECT * FROM xxxxvpex WHERE `vendedor`='{idVendedor}' ORDER BY id_vtaped DESC;";
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

        public static async Task actualizarTotalesPedido(int idEncabezado, int valorTotal)
        {
            var conexionBD = await DataConexion.conectar();
            try
            {
                string query = $"UPDATE `xxxxvpex` SET `valor` = '{valorTotal}' WHERE(`id_vtaped` = '{idEncabezado}');";
                MySqlCommand comando = new MySqlCommand(query);
                MySqlDataReader reader = null;
                comando.Connection = conexionBD;
                conexionBD.Open();
                reader = comando.ExecuteReader();
                conexionBD.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
