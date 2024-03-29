﻿using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPrototipoFavoritos
{
    class EjemploAccess
    {
        static List<Persona> lista = new List<Persona>();
        static UsuariosBaseOleDB accessDB = new UsuariosBaseOleDB(Constantes.PROVEEDOR_ACCESS,
                "C:\\Users\\pmpcurso1\\Desktop\\Curso_Tracasa.NET\\curso_asp_net_old.git\\AppPrototipoFavoritos\\Modelo\\EmpleadosDB.mdb");

        public static void CreaBD()
        {
            List<Persona> lista = new List<Persona>();
            lista.Add(new Persona("Juan J", "kasdsdf@asdfasdf.com", 1970, TipoGenero.Hombre));
            lista.Add(new Persona("Pedro", "kasdsdf@asdfasdf.com", 1975, TipoGenero.Hombre));
            lista.Add(new Persona("Otro", "kasdsdf@asdfasdf.com", 1975, TipoGenero.Hombre));

            accessDB.EstadoBD += DimeEstadoBD;
            Console.WriteLine("Comenzando exportacion");
            accessDB.ExportarAsync(lista);
            Console.WriteLine("Metodo Exportar() finalizado");
            // ;
        }
        public static void ImportaBD()
        {
            accessDB.EstadoBD += CuandoImportaBD;
            Console.WriteLine("Comenzando importacion");
            accessDB.ImportarAsync(lista);
            Console.WriteLine("Metodo ImportarAsync() finalizado");
        }
        private static void DimeEstadoBD(bool estado, string mensaje)
        {
            Console.WriteLine("\u0002 " + mensaje);
            accessDB.EstadoBD -= DimeEstadoBD;
        }
        private static void CuandoImportaBD(bool estado, string mensaje)    {
            Console.WriteLine("\u0002 " + mensaje);
            if (estado == true)
            {
                foreach (Persona per in lista)
                {
                    Console.WriteLine(per.ToString());
                }
            }
            accessDB.EstadoBD -= CuandoImportaBD;
        }
    }
}
