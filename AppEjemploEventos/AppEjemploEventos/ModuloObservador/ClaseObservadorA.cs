using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEjemploEventos
{
    class ClaseObservadorA : IEscuchador
    {
        public void AvisameAlEmpezar(string infoEvento)
        {
            Console.WriteLine("<-- ClaseObservadorA.AvisameAlEmpezar(): [{0}] - {1}", infoEvento, "UNO");
        }
        public void AvisameAlEmpezarHH(string infoEventoXX)
        {
            Console.WriteLine("<-- ClaseObservadorA.AvisameAlEmpezarHH(): [{0}] - {1}", infoEventoXX, "UNO");
        }
        public int AvisameAlSeguir(string infoEvento = "")
        {
            string texto = "<-- ClaseObservadorA.AvisameAlSeguir: INFO: " + infoEvento + ".";
            Console.WriteLine(texto);
            return texto.Length;
        }
        public void AvisameAlAcabar()
        {
            Console.WriteLine("<-- ClaseObservadorA.AvisameAlAcabar(): El obrero ha terminado de currar");
        }
        public void MetodoPropio() {
        }
    }
}
