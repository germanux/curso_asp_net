using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public abstract class UsuariosImportadorBase
        : IPersistenciaUsuarios
    {
        public string NombreFichero { get; set; }

        public abstract bool Exportar(List<Persona> listaUsuarios);

        public abstract bool Importar(List<Persona> listaUsuarios);
    }
}
