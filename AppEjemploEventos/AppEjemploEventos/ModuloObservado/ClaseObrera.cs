using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEjemploEventos
{
    class ClaseObrera
    {
        List<IEscuchador> observadores = new List<IEscuchador>();
        public void RegistrarObervador(IEscuchador nuevoEschador)
        {
            observadores.Add(nuevoEschador);
        }
        public void Desregistrar(IEscuchador observador)
        {
            this.observadores.Remove(observador);
        }
        public void AlCurro()
        {
            Console.WriteLine("--> ClaseObrera.AlCurro(): Empezando a currar");
            foreach (IEscuchador observador in observadores)
            {
                observador.AvisameAlEmpezar("Ehhh! Toma Info");
            }
            Console.ReadKey();

            Console.WriteLine("--> ClaseObrera.AlCurro(): Currando");
            foreach (IEscuchador observador in observadores)
            {
                int numCaracteres = observador.AvisameAlSeguir("QUE ESTAMOS CURRANDO");
                Console.WriteLine("El escuchador {0} ha mostrado {1} caracteres. ",
                    observador.GetType().ToString(), numCaracteres);
            }
            Console.ReadKey();

            Console.WriteLine("--> ClaseObrera.AlCurro(): Terminando de currar");
            foreach (IEscuchador observador in observadores)
            {
                observador.AvisameAlAcabar();
            }
            Console.ReadKey();

            Console.WriteLine("--> ClaseObrera.Avisando SI ACASO: ");
            foreach (IEscuchador observador in observadores)
            {
                System.Reflection.MethodInfo metodo 
                    = observador.GetType().GetMethod("AvisameSiAcaso");
                if (metodo != null)
                {
                    metodo.Invoke(observador, new string[]{"OU YEAH! *** "});
                }
            }

        }
        ~ClaseObrera()
        {
            Console.WriteLine("DESTRUIDO");
            this.observadores.Clear();
        }
    }
}
