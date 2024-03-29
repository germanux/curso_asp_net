﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace Modelo
{
    public static class UtilidadesBD
    {
        public static void AddParametro(
           this OleDbCommand comando,
           string clave,
           object valor,
           DbType tipo = DbType.String,
           int tamanio = 50,
           ParameterDirection direccion = ParameterDirection.Input)
        {
            if (clave.Substring(0, 1) != "@")
            {
                clave = "@" + clave;
            }
            // comando.CreateParameter();
            OleDbParameter parametro = new OleDbParameter(clave, valor);
            parametro.Direction = direccion;
            parametro.DbType = tipo;
            parametro.Size = tamanio;
            comando.Parameters.Add(parametro);
        }
        public static void AddParametro(
           this SqlCommand comando,
           string clave,
           object valor,
           DbType tipo = DbType.String,
           int tamanio = 50,
           ParameterDirection direccion = ParameterDirection.Input)
        {
            if (clave.Substring(0, 1) != "@")
            {
                clave = "@" + clave;
            }
            // comando.CreateParameter();
            SqlParameter parametro = new SqlParameter(clave, valor);
            parametro.Direction = direccion;
            parametro.DbType = tipo;
            parametro.Size = tamanio;
            comando.Parameters.Add(parametro);
        }
    }
}
