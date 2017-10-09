using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace AppPrototipoFavoritos
{
    class EjemploUsoPOO
    {
        public static ListaUsuarios gesUsu;

        static Persona p1 = new Persona("Luis Perez", "klj@kjk.com", 1980, TipoGenero.Hombre);
        static Nombrable p2n = new Persona("Raul", "ddddd@333.com", 1980, TipoGenero.Hombre);
        static Persona p3 = new Persona("Pedro Perez", "sdgdfg@asdf.com", 1990, TipoGenero.Hombre);
        static Persona p4 = new Persona("Juan", "juan@asdf.com", 1990, TipoGenero.Hombre);
        static Persona p5 = new Persona("Sara Perez", "sara@asdf.com", 1980, TipoGenero.Mujer);
        static Persona p6 = new Persona("Alfonso", "sdgdfg@asdf.com", 1990, TipoGenero.Hombre);
        public static void UsoPolimorfismo()
        {
            Persona nom = (Persona) p2n;
            p2n.LlamarAbstracto();
            p2n.LlamarNormal();
            p2n.LlamarVirtual();

            p2n.LlamarAbstracto();
            p2n.LlamarNormal();
            p2n.LlamarVirtual();
        }
        public static void UsoGestionUsuarios(TipoFuncionCallbackEliminar funCallbackAlEliminar)
        {            
            gesUsu.Crear(p1);  gesUsu.Crear((Persona)p2n);  gesUsu.Crear(p3);  gesUsu.Crear(p4);    gesUsu.Crear(p5);  gesUsu.Crear(p6);
            List<Persona> personas;
            List<Persona> listaPersonas;
            if (gesUsu.Listar(out personas))  {
                personas.Add(new Persona("Intruso", "", 1, TipoGenero.Hombre));
                gesUsu.Listar(out listaPersonas);
                MostrarListaPersonas(listaPersonas);
            }
            gesUsu[1].Mostrar("Desde indizador o indexador de clase:");
            Persona perBuscada = gesUsu["  rauL  "];
            if (perBuscada != null)     {
                perBuscada.Mostrar("Encontrado: ");
            }
            gesUsu["raul"] = new Persona("Raul Modificado", "sdgdfg@asdf.com", 1990, TipoGenero.Hombre);
            gesUsu.Eliminar(4, funCallbackAlEliminar);
            // gesUsu.Eliminar("Alfonso");
            gesUsu.Eliminar(gesUsu["Alfonso"]);
            gesUsu.Listar(out listaPersonas);
            MostrarListaPersonas(listaPersonas);
            gesUsu[99].Mostrar();
        }
        public static void UsoBusquedaUsuarios()
        {
            for (int i = 0; i < 100; i++)
            {
                Persona p;
                switch (i % 6)
                {
                    case 0: p = new Persona(p1); break;
                    case 1: p = new Persona((Persona) p2n); break;
                    case 2: p = new Persona(p3); break;
                    case 3: p = new Persona(p4); break;
                    case 4: p = new Persona(p5); break;
                    default: p = new Persona(p6); break;
                }
                p.Nombre += " " + i.ToString();
                gesUsu.Crear(p);
            }
            
            List<Persona> personasBusq = null;
            Persona criteriosBusqueda = new Persona(null, null, 2017, 0);
            
            if (gesUsu.Buscar(out personasBusq, criteriosBusqueda))
                MostrarListaPersonas(personasBusq, "1-TODAS: ");

            criteriosBusqueda.Nombre = "Sin encontrar";
            if (gesUsu.Buscar(out personasBusq, criteriosBusqueda))
                MostrarListaPersonas(personasBusq, "2-Sin encontrar: ");
            else
                Console.WriteLine("2-Personas no encontradas: ");
            
            criteriosBusqueda.Nombre = "Perez";
            if (gesUsu.Buscar(out personasBusq, criteriosBusqueda))
                MostrarListaPersonas(personasBusq, "3-Con apellido Perez: ");
            
            criteriosBusqueda.Anio = 1980;
            if (gesUsu.Buscar(out personasBusq, criteriosBusqueda))
                MostrarListaPersonas(personasBusq, "4-Con apellido Perez y de 1980: ");

            criteriosBusqueda.Nombre = null;
            if (gesUsu.Buscar(out personasBusq, criteriosBusqueda))
                MostrarListaPersonas(personasBusq, "5-De 1980: ");
        }
        public static void UsoBusquedaAsincronaUsuarios()
        {
            for (int i = 0; i < 10000; i++)
            {
                Persona p;
                switch (i % 6)
                {
                    case 0: p = new Persona(p1); break;
                    case 1: p = new Persona((Persona)p2n); break;
                    case 2: p = new Persona(p3); break;
                    case 3: p = new Persona(p4); break;
                    case 4: p = new Persona(p5); break;
                    default: p = new Persona(p6); break;
                }
                p.Nombre += " " + i.ToString();
                gesUsu.Crear(p);
            }
            List<Persona> personasBusq = null;
            Persona criteriosBusqueda = new Persona(null, null, 2017, 0);

            if (gesUsu.Buscar(out personasBusq, criteriosBusqueda))
                MostrarCantidadPersonas(personasBusq, "1-TODAS: ");
            
            criteriosBusqueda.Nombre = "Sin encontrar";
            if (gesUsu.Buscar(out personasBusq, criteriosBusqueda))
                MostrarCantidadPersonas(personasBusq, "2-Sin encontrar: ");
            else
                Console.WriteLine("2-Personas no encontradas: ");

            criteriosBusqueda.Nombre = "Perez";
            if (gesUsu.Buscar(out personasBusq, criteriosBusqueda))
                MostrarCantidadPersonas(personasBusq, "3-Con apellido Perez: ");

            criteriosBusqueda.Anio = 1980;
            if (gesUsu.Buscar(out personasBusq, criteriosBusqueda))
                MostrarCantidadPersonas(personasBusq, "4-Con apellido Perez y de 1980: ");

            criteriosBusqueda.Nombre = null;
            if (gesUsu.Buscar(out personasBusq, criteriosBusqueda))
                MostrarCantidadPersonas(personasBusq, "5-De 1980: ");
        }
        static void MostrarListaPersonas(List<Persona> listaPersonas, string msj = "")
        {
            foreach (Persona persona in listaPersonas)
            {
                persona.Mostrar(msj);
            }
        }
        static void MostrarCantidadPersonas(List<Persona> listaPersonas, string msj = "")
        {
            Console.WriteLine("Lista con " + listaPersonas.Count);
        }
    }
}
