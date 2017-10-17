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
        Task<bool> ImportarAsync(List<Persona> listaUsuarios);
        Task<bool> ExportarAsync(List<Persona> listaUsuarios);
    }
}
