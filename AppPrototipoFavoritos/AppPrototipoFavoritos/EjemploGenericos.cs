using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPrototipoFavoritos
{
    class EjemploGenericos
    {
        public static void UsoGenericos()
        {
            Persona yo = new Persona("03423423F", "kasdsdf@asdfasdf.com", 1970, TipoGenero.Hombre);
            Persona tu = new Persona("03423423F", "kasdsdf@asdfasdf.com", 1975, TipoGenero.Hombre);
            GestionUsuarios gesUsu = new GestionUsuarios();
            EjemploGenericos ej = new EjemploGenericos();

            ej.MostrarVariasVeces<GestionUsuarios>(3, gesUsu);
            ej.MostrarVariasVeces<Persona>(2, yo);
            ej.MostrarVariasVeces<int>(3, 5);
            ej.MostrarVariasVeces<string>(2, "jkhkjhk");

            Persona[] gentuzas = ej.DameUnTrio<Persona>(yo, tu, yo);
            int[] numeros = ej.DameUnTrio<int>(1, 4, 3);


            Console.ReadKey();
        }
        public void MostrarVariasVeces<Tipo>(int veces, Tipo objeto)
        {
            for (int i = 0; i < veces; i++)
            {
                Console.WriteLine("Mostrando " + objeto.ToString());
            }
        }
    public Tipo[] DameUnTrio<Tipo>(Tipo obj1, Tipo obj2, Tipo obj3)
    {
            Tipo[] array;
            array = new Tipo[3];
            array[0] = obj1;
            array[1] = obj2;
            array[2] = obj3;
            return array;
        }
        public static void UsoOrdenacionsGenericosComparadores()
        {
            Persona[] personas = {
                    new Persona(),
                    new Persona()
                };
            Array.Sort<Persona>(personas);
            Console.ReadKey();
        }
    }
}