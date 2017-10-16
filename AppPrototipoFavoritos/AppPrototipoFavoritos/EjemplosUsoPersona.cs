using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace AppPrototipoFavoritos
{
    class EjemplosUsoPersona
    {
        public static void UsoReflection()
        {
            var obj = new Persona("03423423F", "kasdsdf@asdfasdf.com", 1980, TipoGenero.Hombre);
            var tipoObj = obj.GetType();
            var tipoPer = typeof(Persona);
            if (tipoObj.Equals(tipoPer))
            {
                foreach (System.Reflection.PropertyInfo propiedad in tipoPer.GetProperties())
                {
                    Console.WriteLine("Propiedad: " + propiedad.Name + ", Valor: " + propiedad.GetValue(obj));
                }
            }
            else
            {
                Console.WriteLine("NO SON IGUALES");
            }
        }
        public static void UsoPropiedades()
        {
            var yo = new Persona("03423423F", "kasdsdf@asdfasdf.com", 1970, TipoGenero.Hombre);
            var tu = new Persona("03423423F", "kasdsdf@asdfasdf.com", 1975, TipoGenero.Hombre);
            yo.Nombre = "Germán";
            if (yo.EsAdulto)
            {
                Console.WriteLine(yo.ToString() + " Es adulto");
            }
            if (!tu.EsAdulto)
            {
                Console.WriteLine(tu.ToString() + " No es adulto");
            }
        }
        public static void UsoClasesEstructurasEnums()
        {
            var per1 = new Persona();
            per1.Nombre = "Pablo";
            per1.Edad = 18;
            var per2 = per1;// = new Persona();

            var perStr1 = new PersonaStruct();
            perStr1.nombre = "Pablo";
            perStr1.edad = 18;
            var perStr2 = perStr1; //= new PersonaStruct();

            per1.Nombre = "Lidia";
            perStr1.nombre = "Lidia";
            per1.Genero = TipoGenero.Mujer;
            per2.Genero = (TipoGenero)Enum.Parse(typeof(TipoGenero), "MUJER", true);

            Console.WriteLine(per1.Genero.ToString() + ", " + per2.Genero.ToString());

            MostrarPersona_Valor(per1);
            MostrarPersona_Valor(per1);
            MostrarPersona_Ref(ref per2);
            MostrarPersona_Ref(ref per2);

            MostrarPersonaStruct_Valor(perStr1);
            MostrarPersonaStruct_Valor(perStr1);
            MostrarPersonaStruct_Ref(ref perStr2);
            MostrarPersonaStruct_Ref(ref perStr2);
        }

        static void MostrarPersona_Valor(Persona persona)
        {
            Console.WriteLine(persona.ToString());
            persona.Nombre += " Mancillado";
        }
        static void MostrarPersona_Ref(ref Persona persona)
        {
            Console.WriteLine(persona.ToString());
            persona.Nombre += " Mancillado";
        }
        static void MostrarPersonaStruct_Valor(PersonaStruct persona)
        {
            Console.WriteLine(persona.ToString());
            persona.nombre += " Mancillado";
        }
        static void MostrarPersonaStruct_Ref(ref PersonaStruct persona)
        {
            Console.WriteLine(persona.ToString());
            persona.nombre += " Mancillado";
        }
    }
}
