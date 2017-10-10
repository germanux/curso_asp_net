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
            /*obrera.AlCurroCallBK(escuchadorA.AvisameAlEmpezar, 
                (string str) => {
                    string texto = "Función Lambda (fun anonima): " + str;
                    Console.WriteLine(texto);
                    return texto.Length; 
                }, FunAvisameAlAcabarEstatica);*/
            
            obrera.FuncionCampoAlEmpezar += escuchadorA.AvisameAlEmpezar;
            obrera.FuncionCampoAlEmpezar += escuchadorA.AvisameAlEmpezar;
            obrera.FuncionCampoAlEmpezar += escuchadorA.AvisameAlEmpezar;
            obrera.FuncionCampoAlEmpezar += escuchadorB.AvisameAlEmpezar;
            obrera.FuncionCampoAlEmpezar -= escuchadorA.AvisameAlEmpezar;

            obrera.FuncionCampoAlSeguir = (string str) =>
            {
                string texto = "Función Lambda (fun anonima): " + str;
                Console.WriteLine(texto);
                return texto.Length;
            };
            obrera.FuncionCampoAlAcabar = FunAvisameAlAcabarEstatica;
            obrera.FunEventoAviso += FunEstaticaEvAviso;
            obrera.AlCurroDelegados();
            obrera.MetodoExtensionObrera("ARGUMENTO");
            Console.WriteLine("   Solo  Tenemos 50 minutos  ".GatchetoString());
        }
        static void FunEstaticaEvAviso(object sender, MisArgumentosEventArgs args)
        {
            Console.WriteLine(sender.ToString() + ", " + args.ToString() + ", " );
        }
        static void FunAvisameAlAcabarEstatica()
        {
            Console.WriteLine("FunAvisameAlAcabarEstatica");
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
