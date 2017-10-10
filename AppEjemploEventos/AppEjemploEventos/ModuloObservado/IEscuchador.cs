using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEjemploEventos
{
    interface IEscuchador
    {
        void AvisameAlEmpezar(string infoEvento = "");
        /// <summary>
        /// Evento que  Avisa Al Seguir  trabajando
        /// </summary>
        /// <param name="infoEvento"></param>
        /// <returns>Devuelve el nº de caracteres mostrados</returns>
        int AvisameAlSeguir(string infoEvento = "");

        void AvisameAlAcabar();
    }
}
