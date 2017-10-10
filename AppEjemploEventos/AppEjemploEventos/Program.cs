using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEjemploEventos
{
    class Program
    {
        static void Main(string[] args)
        {
            GestionandoCallbacks();
            Console.ReadKey();
        }
        static void GestionandoCallbacks()
        {
            ClaseObreraDeleg obrera = new ClaseObreraDeleg();

            ClaseObservadorA escuchadorA = new ClaseObservadorA();
            EscuchadorB escuchadorB = new EscuchadorB();

            //obrera.AlCurroCallBK(escuchadorB.AvisameAlEmpezar);
            obrera.AlCurroCallBK(escuchadorA.AvisameAlEmpezar);
        }
        static void GestionandoObservadores()
        {
            ClaseObrera obrera = new ClaseObrera();
            IEscuchador escuchador = new ClaseObservadorA();
            IEscuchador escuchadorB = new EscuchadorB();

            obrera.RegistrarObervador(escuchador);
            obrera.RegistrarObervador(escuchadorB);
            obrera.RegistrarObervador(escuchadorB);
            obrera.RegistrarObervador(escuchadorB);

            obrera.Desregistrar(escuchadorB);

            // Otras cosas ...
            obrera.AlCurro();
        }
    }
}
