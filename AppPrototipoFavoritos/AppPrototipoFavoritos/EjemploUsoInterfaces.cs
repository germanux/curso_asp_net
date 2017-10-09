using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace AppPrototipoFavoritos
{
    class EjemploUsoInterfaces
    {
        static IEdadCalculable per1 = new Persona("Luis", "klj@kjk.com", 1997, TipoGenero.Hombre);
        static IEdadCalculable per2 = new Persona("Raul", "ddddd@333.com", 1987, TipoGenero.Hombre);
        public static void UsoInterfaces()
        {

            System.Console.WriteLine("Edad: " + per1.Edad.ToString());
            per1.Edad++;
            System.Console.WriteLine("Edad: " + per1.Edad.ToString());
            System.Console.WriteLine("Nom: " + ((Persona)per1).Nombre);
            Persona lidia = "Lidia,aaaa@sss.com,1997";
            System.Console.WriteLine("Lidia: " + lidia.ToString());
        }
        public static void UsoOperadores()
        {
            Persona perCumple = ((Persona)per1) + 1;
            System.Console.WriteLine("Cumple: " + per1.ToString());
            System.Console.WriteLine(
                (((Persona)per1) + ((Persona)per2)).ToString());
            System.Console.WriteLine(
                (((Persona)per1) % ((Persona)per2)).ToString());

        }
    }
}
