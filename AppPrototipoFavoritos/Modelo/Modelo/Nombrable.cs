using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public abstract class Nombrable
    {
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { this.nombre = value; }
        }
        public Nombrable(string nombre)
        {
            this.Nombre = nombre;
        }
        //TODO: Poner overrride
        public override string ToString()
        {
            return "Nombrable: " + nombre;
        }
        public void Mostrar(string mensaje = "")
        {
            Console.WriteLine(mensaje + ToString());
        }
        public abstract void LlamarAbstracto();
        public void LlamarNormal() { Mostrar("Nombrable.LlamarNormal(): "); }
        public virtual void LlamarVirtual() { Mostrar("Nombrable.LlamarVirtual(): "); }
    }
}
