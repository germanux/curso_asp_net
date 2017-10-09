using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public interface IGestionUsuarios
    {
        Persona this[int id] { get; set; } // Por ID
        Persona this[string nombre] { get; set; }
        bool Crear(Persona persona);
        bool Eliminar(Persona persona);
        bool Eliminar(int id);
        bool Modificar(int id, Persona persona);
        bool Obtener(int id, out Persona persona);
        bool Listar(out List<Persona> lista);
        bool Buscar(out List<Persona> lista, Persona personaCampos);
    }
}
