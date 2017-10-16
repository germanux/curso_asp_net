using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPrototipoFavoritos
{
    class EjemploAccess
    {
        public static void CreaBD()
        {
            List<Persona> lista = new List<Persona>();
            lista.Add(new Persona("Juan", "kasdsdf@asdfasdf.com", 1970, TipoGenero.Hombre));
            lista.Add(new Persona("Pedro", "kasdsdf@asdfasdf.com", 1975, TipoGenero.Hombre));
            UsuariosBaseOleDB accessDB = new UsuariosBaseOleDB(Constantes.PROVEEDOR_ACCESS, "C:\\EmpleadosDB.mdb");
            accessDB.Exportar(lista);
        }
    }
}
