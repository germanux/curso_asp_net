using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEjemploEventos
{
    static class ClaseMetodosExtension
    {
        public static string GatchetoString(this string str)
        {
            return str.ToUpperInvariant().Replace("  ", " ").Trim();
        }
        public static void MetodoExtensionObrera(
            this ClaseObreraDeleg obrero, string parametro)
        {
            Console.WriteLine("METODO EXTENDIDO " + parametro);
        }
    }
}
