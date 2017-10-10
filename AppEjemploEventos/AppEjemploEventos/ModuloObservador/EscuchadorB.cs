using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEjemploEventos
{
    class EscuchadorB : IEscuchador
    {
        public void AvisameAlEmpezar(string infoEvento)
        {
            Console.WriteLine("\a <-- EscuchadorB.AvisameAlEmpezar(): {0}", infoEvento);
        }
        public int AvisameAlSeguir(string infoEvento = "")
        {
            string texto = "<-- EscuchadorB.AlSeguir: " + infoEvento + ".";
            Console.WriteLine(texto);
            return texto.Length;
        }
        public void AvisameAlAcabar()
        {
            Console.WriteLine("\a EscuchadorB.Terminando de currar");
        }
        public void AvisameSiAcaso(string infoEvento = "")
        {
            Console.WriteLine("\a ****** EscuchadorB. He sido avisado: " + infoEvento);
        }
    }
}
