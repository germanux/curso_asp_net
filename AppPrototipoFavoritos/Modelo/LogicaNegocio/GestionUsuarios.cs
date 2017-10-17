using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class GestionUsuarios : ListaUsuarios
    {
        IPersistenciaUsuarios BD;

        public GestionUsuarios() : base()
        {
            BD = new UsuariosBaseOleDB(Constantes.PROVEEDOR_ACCESS,
                "C:\\Users\\Administrador\\Desktop\\CURSO_ASP_NET\\AppPrototipoFavoritos\\Modelo\\EmpleadosDB.mdb");

            BD.ImportarAsync(lista);
        }
        public override bool Crear(Persona persona)

        {
           bool ok = base.Crear(persona);
           BD.ExportarAsync(lista);
           return ok;
        }
    }
}