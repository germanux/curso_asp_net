using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    class ComparadoresPersona
    {
        public static IComparer<Persona> GetCompradorEdad()
        {
            return new ComparadorEdad();
        }
        public static IComparer<Persona> GetCompradorNombre()
        {
            return new ComparadorNombre();
        }
        private class ComparadorEdad : IComparer<Persona>
        {
            public int Compare(Persona x, Persona y)
            {
                return x.Edad == y.Edad ? 0 : x.Edad > y.Edad ? 1 : -1;
            }
        }
        private class ComparadorNombre : IComparer<Persona>
        {
            public int Compare(Persona x, Persona y)
            {
                return x.Nombre.CompareTo(y.Nombre);
            }
        }

    }
}
