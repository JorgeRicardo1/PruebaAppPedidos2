﻿using MySqlConnector;
using PruebaAppPedidos2.Data;
using PruebaAppPedidos2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace PruebaAppPedidos2.Services
{
    public class Servicesxxxxvpar
    {
        public static async Task<ObservableCollection<Modelxxxxvpax>> getMovimientosPedido(string numeroPedido)
        {
            var conexionBD = await DataConexion.conectar();
            try
            {
                ObservableCollection<Modelxxxxvpax> lstMovimientos = new ObservableCollection<Modelxxxxvpax>();

                string query = $"SELECT * FROM xxxxvpar WHERE  numero = '{numeroPedido}'";
                MySqlCommand comando = new MySqlCommand(query);
                MySqlDataReader reader = null;
                comando.Connection = conexionBD;
                DataConexion.abrir();
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Modelxxxxvpax movimiento = new Modelxxxxvpax();
                        movimiento.Id_vpar = reader.GetInt32("Id_vpar");
                        movimiento.numero = reader.GetString("numero");
                        movimiento.fecha = reader.GetDateTime("fecha");
                        movimiento.codigo = reader.GetString("codigo");
                        movimiento.nit = reader.GetString("nit");
                        movimiento.punto = reader.GetString("punto");
                        movimiento.puntox = reader.GetString("puntox");
                        movimiento.obra = reader.GetString("obra");
                        movimiento.detalle = reader.GetString("detalle");
                        movimiento.medida = reader.GetString("medida");
                        movimiento.serial = reader.GetString("serial");
                        movimiento.lote = reader.GetString("lote");
                        movimiento.fvence = Lector.safeGetDate(reader, "fvence");
                        movimiento.talla = reader.GetString("talla");
                        movimiento.Ncolor = reader.GetString("Ncolor");
                        movimiento.operario = reader.GetString("operario");
                        movimiento.hdigita = reader.GetString("hdigita");
                        movimiento.fdigitar = Lector.safeGetDate(reader, "fdigitar");
                        movimiento.entregaf = Lector.safeGetDate(reader, "entregaf");
                        movimiento.entregan = reader.GetInt32("entregan");
                        movimiento.cantinic = reader.GetInt32("cantinic");
                        movimiento.cantidad = reader.GetInt32("cantidad");
                        movimiento.valor = reader.GetInt32("valor");
                        movimiento.costo = reader.GetInt32("costo");
                        movimiento.neto = reader.GetInt32("neto");
                        movimiento.dsct4 = reader.GetInt32("dsct4");
                        movimiento.dsct2 = reader.GetInt32("dsct2");
                        movimiento.desctos = reader.GetInt32("desctos");
                        movimiento.iva = reader.GetInt32("iva");
                        movimiento.vriva = reader.GetInt32("vriva");
                        movimiento.vrventa = reader.GetInt32("vrventa");
                        movimiento.consumo = reader.GetInt32("consumo");
                        movimiento.compuesto = reader.GetInt32("compuesto");
                        movimiento.peso = reader.GetInt32("peso");
                        movimiento.anulado = reader.GetInt32("anulado");
                        movimiento.anuladox = reader.GetString("anuladox");
                        movimiento.factura = reader.GetString("factura");
                        movimiento.sucursal = reader.GetString("sucursal");
                        movimiento.mvinterm = reader.GetString("mvinterm");

                        lstMovimientos.Add(movimiento);
                    }
                    reader.Close();
                    DataConexion.cerrar();
                }
                reader.Close();
                DataConexion.cerrar();
                return lstMovimientos;
            }
            catch (Exception)
            {
                conexionBD.Close();
                throw;
            }
        }

    }
}