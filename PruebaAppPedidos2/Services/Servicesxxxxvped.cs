using MySqlConnector;
using PruebaAppPedidos2.Data;
using PruebaAppPedidos2.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PruebaAppPedidos2.Services
{
    public class Servicesxxxxvped
    {
        public static async Task<Modelxxxxvped> extraerInfoDespacho(string codigoCliente)
        {
            var conexionBD = await DataConexion.conectar();

            try
            {
                Modelxxxxvped infoDespacho = new Modelxxxxvped();
                string query = $"SELECT * FROM xxxxvped WHERE nit='{codigoCliente}'";
                MySqlCommand comando = new MySqlCommand(query);
                MySqlDataReader reader = null;
                comando.Connection = conexionBD;
                conexionBD.Open();
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        infoDespacho.titular = reader.GetString(20);
                        infoDespacho.titudire = reader.GetString(21);
                        infoDespacho.titutelf = reader.GetString(22);
                        infoDespacho.tituciud = reader.GetString(23);
                    }
                }
                conexionBD.Close();
                return infoDespacho;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task crearEncabezadoTemp(string codigoCliente)
        {
            string date = DateTime.UtcNow.ToString("yyyy-MM-dd");
            string time = DateTime.Now.ToString("HH:mm:ss");

            var conexionBD = await DataConexion.conectar();
            try
            {
                string query = $"INSERT INTO `a000`.`xxxxvpex` " +
                    $"(`nit`, `numero`, `fecha`, `dias`, `obra`, `transporte`, `fdigitar`, `hdigita`, `datos1`, `vendedor`, `valor`, `abono`, `saldo`, `terminal`, `vriva`, `desctos`, `neto`, `costo`, `titular`, `titudire`, `titutelf`, `tituciud`, `ped_fraxx`, `ped_envio`, `ped_estado`, `sucursal`, `operario`, `grupo`, `consumo`) " +
                    $"VALUES " +
                    $"('{codigoCliente}', 'Temp', '{date}', '1', '0000', 'cpp66f', '{date}', '{time}', 'Prueba de agregar4', 'C00', '100000', '0', '125000', '000', '0', '0', '0', '0', 'Ventas', 'calle 2', '3333333', 'Pereura,Risaralda', '0', '1', '0', '000', 'a002', '0', '0')";
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
                        encabezadoTemp.numero = reader.GetString(1);
                        encabezadoTemp.fecha = reader.GetDateTime(2);
                        encabezadoTemp.dias = reader.GetInt16(3);
                        encabezadoTemp.obra = reader.GetString(4);
                        encabezadoTemp.transporte = reader.GetString(5);
                        encabezadoTemp.fultima = safeGetDate(reader, "fultima");
                        encabezadoTemp.fdigitar = reader.GetDateTime(7);
                        encabezadoTemp.hdigita = reader.GetString(8);
                        encabezadoTemp.factura = reader.GetString(9);
                        encabezadoTemp.datos1 = reader.GetString(10);
                        encabezadoTemp.vendedor = reader.GetString(11);
                        encabezadoTemp.valor = reader.GetInt32(12);
                        encabezadoTemp.abono = reader.GetInt32(13);
                        encabezadoTemp.saldo = reader.GetInt32(14);
                        encabezadoTemp.terminal = reader.GetString(15);
                        encabezadoTemp.vriva = reader.GetInt32(16);
                        encabezadoTemp.desctos = reader.GetInt32(17);
                        encabezadoTemp.neto = reader.GetInt32(18);
                        encabezadoTemp.costo = reader.GetInt32(19);
                        encabezadoTemp.titular = reader.GetString(20);
                        encabezadoTemp.titudire = reader.GetString(21);
                        encabezadoTemp.titutelf = reader.GetString(22);
                        encabezadoTemp.tituciud = reader.GetString(23);
                        encabezadoTemp.ped_fraxx = reader.GetInt32(24);
                        encabezadoTemp.ped_envio = reader.GetInt32(25);
                        encabezadoTemp.ped_estado = reader.GetInt32(26);
                        encabezadoTemp.ped_estadn = reader.GetString(27);
                        encabezadoTemp.ped_closed = safeGetDate(reader, "ped_closed");
                        encabezadoTemp.ped_closet = reader.GetString("ped_closet");
                        encabezadoTemp.sucursal = reader.GetString("sucursal");
                        encabezadoTemp.term_pedi = reader.GetString("term_pedi");
                        encabezadoTemp.grupo = reader.GetInt32("grupo");
                        encabezadoTemp.fventa = safeGetDate(reader, "fventa");
                        encabezadoTemp.id_vtaped = reader.GetInt32("id_vtaped");
                        encabezadoTemp.desp_nomb = reader.GetString("desp_nomb");
                        encabezadoTemp.desp_direc = reader.GetString("desp_direc");
                        encabezadoTemp.desp_telf = reader.GetString("desp_telf");
                        encabezadoTemp.desp_city = reader.GetString("desp_city");
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

        //FUNCION PARA OBTENER LAS FECHAS NULL DE UNA MANERA SEGURA
        public static DateTime safeGetDate(MySqlDataReader reader, string colName)
        {
            int colIndex = reader.GetOrdinal(colName);

            if (!reader.IsDBNull(colIndex))
            {
                return reader.GetDateTime(colIndex);
            }
            else
            {
                return new DateTime(1999, 09, 19);
            }
        }
    }
}
