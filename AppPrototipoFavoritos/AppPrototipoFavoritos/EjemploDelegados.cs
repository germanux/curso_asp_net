using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace AppPrototipoFavoritos
{
    public class EjemploDelegados : IListaUsuariosListener
    {
        /// <summary>
        /// AvisameAlCrear es avisado mediante patrón de diseño Observer,
        /// interfaz IListaUsuariosListener
        /// </summary>
        public void AvisameAlCrear()
        {
            Console.WriteLine("Avisado estás del cambio CREAR");
        }
        public void AvisameAlModificar()
        {
            Console.WriteLine("Avisado estás del cambio MODIFICAR");
        }
    }
}
