using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    class Producto : Nombrable, IActivable
    {
        /// <summary>
        /// Nuevo Producto
        /// </summary>
        /// <param name="nombre"></param>
        public Producto(string nombre) : base(nombre)
        {
        }
        public bool Estado { get; set; }

        public override void LlamarAbstracto()
        {
            Mostrar("Producto: ");
        }

        public void SetEstado(bool nuevoEstado)
        {
            this.Estado = nuevoEstado;
        }
    }
}
