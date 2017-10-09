using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public struct PersonaStruct
    {
        public string dni;
        public string email;
        public string nombre;
        public int edad;
        public bool nacional;
        public override string ToString()
        {
            return nombre + "<" + this.edad + ">";
        }
    }
}
