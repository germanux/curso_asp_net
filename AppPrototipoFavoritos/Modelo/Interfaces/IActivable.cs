using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    /// <summary>
    /// Para poder activar
    /// </summary>
    public interface IActivable
    {
        bool Estado  {
            get;
            set;
        }
        void SetEstado(bool nuevoEstado);
    }
}
