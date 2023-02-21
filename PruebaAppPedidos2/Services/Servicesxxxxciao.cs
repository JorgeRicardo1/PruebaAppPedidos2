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
    public class Servicesxxxxciao
    {
        public static async Task<Modelxxxxciao> getOperario(string nombreOperario)
        {
            var conexionBD = await DataConexion.conectar();
            Modelxxxxciao operario= new Modelxxxxciao();
            try
            {
                string query = $"SELECT * FROM xxxxciao WHERE `nombre`='{nombreOperario}'";
                MySqlCommand comando = new MySqlCommand(query);
                MySqlDataReader reader = null;
                comando.Connection = conexionBD;
                conexionBD.Open();
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        operario.obra = reader.GetString("obra");
                        operario.clave = reader.GetString("clave");
                        operario.nombre = reader.GetString("nombre");
                        operario.pasabordo = reader.GetString("pasabordo");
                        operario.cedula = reader.GetString("cedula");
                        operario.direccion = reader.GetString("direccion");
                        operario.ciudad = reader.GetString("ciudad");
                        operario.cargo = reader.GetString("cargo");
                        operario.telefono = reader.GetString("telefono");
                        operario.celular = reader.GetString("celular");
                        operario.email = reader.GetString("email");
                        operario.facceso = Lector.safeGetDate(reader, "facceso");
                        operario.status = reader.GetInt32("status");
                        operario.nivel = reader.GetInt32("nivel");
                        operario.fectrl = reader.GetInt32("fectrl");
                        operario.activo = reader.GetInt32("activo");
                        operario.impresion = reader.GetInt32("impresion");
                        operario.fingreso = Lector.safeGetDate(reader, "fingreso");
                        operario.fnacto = Lector.safeGetDate(reader, "fnacto");
                        operario.fretiro = Lector.safeGetDate(reader, "fretiro");
                        operario.datos = reader.GetString("datos");
                        operario.nroprint = reader.GetInt32("nroprint");
                        operario.punto = Lector.safeGetString(reader, "punto");
                        operario.terminal = reader.GetString("terminal");
                        operario.sucursal = reader.GetString("sucursal");
                        operario.bodega1 = reader.GetString("bodega1");
                        operario.bodega2 = reader.GetString("bodega2");
                        operario.bodega3 = reader.GetString("bodega3");
                        operario.bodega4 = reader.GetString("bodega4");
                        operario.bodega5 = reader.GetString("bodega5");
                        operario.bodega6 = Lector.safeGetString(reader, "bodega6");
                        operario.bodega7 = Lector.safeGetString(reader, "bodega7");
                        operario.pw = reader.GetString("pw");
                        operario.ciao_vend = reader.GetString("ciao_vend");
                        operario.rest_mesa = reader.GetInt32("rest_mesa");
                    }
                    conexionBD.Close();
                    return operario;
                }
                else
                {
                    conexionBD.Close();
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                conexionBD.Close();
                throw;
            }
        }

        public static async Task<ObservableCollection<Modelxxxxciao>> getOperariosPedidos()
        {
            var conexionBD = await DataConexion.conectar();
            ObservableCollection<Modelxxxxciao> operarios = new ObservableCollection<Modelxxxxciao>();

            try
            {
                string query = "SELECT * FROM xxxxciao WHERE `pw` != ''";
                MySqlCommand comando = new MySqlCommand(query);
                MySqlDataReader reader = null;
                comando.Connection = conexionBD;
                conexionBD.Open();
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Modelxxxxciao operario = new Modelxxxxciao();
                        operario.obra = reader.GetString("obra");
                        operario.clave = reader.GetString("clave");
                        operario.nombre = reader.GetString("nombre");
                        operario.pasabordo = reader.GetString("pasabordo");
                        operario.cedula = reader.GetString("cedula");
                        operario.direccion = reader.GetString("direccion");
                        operario.ciudad = reader.GetString("ciudad");
                        operario.cargo = reader.GetString("cargo");
                        operario.telefono = reader.GetString("telefono");
                        operario.celular = reader.GetString("celular");
                        operario.email = reader.GetString("email");
                        operario.facceso = Lector.safeGetDate(reader, "facceso");
                        operario.status = reader.GetInt32("status");
                        operario.nivel = reader.GetInt32("nivel");
                        operario.fectrl = reader.GetInt32("fectrl");
                        operario.activo = reader.GetInt32("activo");
                        operario.impresion = reader.GetInt32("impresion");
                        operario.fingreso = Lector.safeGetDate(reader, "fingreso");
                        operario.fnacto = Lector.safeGetDate(reader, "fnacto");
                        operario.fretiro = Lector.safeGetDate(reader, "fretiro");
                        operario.datos = reader.GetString("datos");
                        operario.nroprint = reader.GetInt32("nroprint");
                        operario.punto = Lector.safeGetString(reader, "punto");
                        operario.terminal = reader.GetString("terminal");
                        operario.sucursal = reader.GetString("sucursal");
                        operario.bodega1 = reader.GetString("bodega1");
                        operario.bodega2 = reader.GetString("bodega2");
                        operario.bodega3 = reader.GetString("bodega3");
                        operario.bodega4 = reader.GetString("bodega4");
                        operario.bodega5 = reader.GetString("bodega5");
                        operario.bodega6 = Lector.safeGetString(reader, "bodega6");
                        operario.bodega7 = Lector.safeGetString(reader, "bodega7");
                        operario.pw = reader.GetString("pw");
                        operario.ciao_vend = reader.GetString("ciao_vend");
                        operario.rest_mesa = reader.GetInt32("rest_mesa");
                        operarios.Add(operario);
                    }
                    reader.Close();
                    conexionBD.Close();
                    return operarios;
                }
                else
                {
                    conexionBD.Close();
                    return null;
                }
            }
            catch (Exception)
            {
                conexionBD.Close();
                throw;
            }
        }
    }
}
