using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AplicacionWeb.App_Code
{
    public class Origen
    {
        public ListaUsuarios listaUsuarios;
        public List<Modelo.Persona> lista = new List<Persona>();
        public Persona[] Lista()
        {
            return lista.ToArray();
        }
        public Origen()
        {
            listaUsuarios = new ListaUsuarios();
            listaUsuarios.Crear(new Persona("Juan", "asdf@ee", 1990, TipoGenero.Hombre));
            listaUsuarios.Crear(new Persona("Pepe", "asdf@ee", 1990, TipoGenero.Hombre));
            listaUsuarios.Crear(new Persona("Fran", "asdf@ee", 1990, TipoGenero.Hombre));
            listaUsuarios.Listar(out lista);
        }
    }
}