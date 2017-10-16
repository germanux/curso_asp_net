using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    interface IPersistenciaUsuarios
    {
        string NombreFichero { get; set; }
        bool Importar(List<Persona> listaUsuarios);
        bool Exportar(List<Persona> listaUsuarios);
    }
}
