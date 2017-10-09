using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Persona : Nombrable,
        IEdadCalculable, IComparable, IActivable
    {
        private string email;
        private int anio;
        private bool nacional = true;
        private TipoGenero genero;
        public Persona() : base("") { }
        public Persona(Persona personaCopia) : base (personaCopia.Nombre)
        {
            this.email = personaCopia.email;
            this.anio = personaCopia.anio;
            this.nacional = personaCopia.nacional;
            this.genero = personaCopia.genero;
        }
        public Persona(string nom, string email,int anio,TipoGenero genero, bool nacional = true)
            : base(nom)
        {
            // base.Nombre = nom;
            this.Email = email;
            this.Nacional = nacional;
            this.Anio = anio;
            this.Genero = genero;
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public int Edad   {
            get { return DateTime.Now.Year - this.Anio; }
            set { this.Anio = DateTime.Now.Year - value; }
        }
        public bool Nacional
        {
            get { return nacional; }
            set { nacional = value; }
        }
        public TipoGenero Genero  {
            get { return genero; }
            set { genero = value; }
        }
        public bool EsAdulto   {
            get   {
                return this.Edad > Constantes.EDAD_ADULTO ? true : false;
            }
        }

        public int Anio  {
            get  {  return this.anio;  }
            set  { this.anio = value; }
        }
        public bool Estado   {  get; set; }
        // Es lo mismo que:
        // bool _estado;
        // public bool Estado {
        //    get { return this._estado; }
        //    set { this._estado = value; }
        //}
        override public  string ToString()
        {
            return Nombre + " <" + this.Email + "> (" + this.Edad + " años)";
        }
        public int CompareTo(object obj)
        {
            if (this == obj)
                return 0;
            else
            {
                int compNombre = ComparadoresPersona.GetCompradorNombre().Compare(this, (Persona)obj);
                if (compNombre != 0)
                {
                    return compNombre;
                }
                else
                {
                    int compEdad = ComparadoresPersona.GetCompradorEdad().Compare(this, (Persona)obj);
                    if (compEdad != 0)
                    {
                        return compEdad;
                    }
                    else
                        return 0;
                }
            }
        }

        public void SetEstado(bool nuevoEstado)
        {
            this.Estado = nuevoEstado;
        }

        /*public static explicit operator Persona(string X)
        {
            string[] Xs = X.Split(',');
            return new Persona(Xs[0], Xs[1], int.Parse(Xs[2]), TipoGenero.Hermafrodita);
        }*/
        public static implicit operator Persona(string X)
        {
            string[] Xs = X.Split(',');
            return new Persona(Xs[0], Xs[1], int.Parse(Xs[2]), TipoGenero.Hermafrodita);
        }
        /*public static implicit operator Persona(Nombrable X)
        {
            return (Persona) X;
        }*/

        public static Persona operator +(int años, Persona persona)
        {
            persona.Anio += años;
            return persona;
            // return new Persona(persona.Nombre, persona.Email);
        }
        public static Persona operator +(Persona persona, int años)
        {
            persona.Anio += años;
            return persona;
            // return new Persona(persona.Nombre, persona.Email);
        }
        public static Persona operator +(Persona per1, Persona per2)
        {
            return new Persona(per1.Nombre + per2.Nombre,
                per1.Email + per2.Email,
                DateTime.Now.Year - per1.Edad  - per2.Edad,
                per1.Genero   );
        }
        public static Persona operator %(Persona per1, Persona per2)
        {
            return new Persona("Media: " + per1.Nombre + per2.Nombre,
                "",
                (per1.Anio + per2.Anio) / 2 ,
                per1.Genero);
        }

        public override void LlamarAbstracto() { Mostrar("Persona.LlamarAbstracto(): "); }
        public void LlamarNormal() { Mostrar("Persona.LlamarNormal(): "); }
        public override void LlamarVirtual()
        {
            // base.LlamarVirtual(); 
            Mostrar("Persona.LlamarVirtual(): ");
        }
    }
}
