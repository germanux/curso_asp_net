using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEjemploEventos
{
    delegate void TipoDel_AlEmpezar(string infoEvento = "");

    class ClaseObreraDeleg
    {
        public void AlCurroCallBK(TipoDel_AlEmpezar funAlEmpezar)
        {
            Console.WriteLine("--> ClaseObrera.AlCurro(): Empezando a currar");
            if (funAlEmpezar != null)
                funAlEmpezar("LLAMANDO A CALLBACK");
            funAlEmpezar?.Invoke("LLAMANDO A CALLBACK");
            Console.ReadKey();

            Console.WriteLine("--> ClaseObrera.AlCurro(): Currando");
            Console.ReadKey();

            Console.WriteLine("--> ClaseObrera.AlCurro(): Terminando de currar");
            Console.ReadKey();
        }
        public void AlCurro()
        {
            Console.WriteLine("--> ClaseObrera.AlCurro(): Empezando a currar");
            Console.ReadKey();

            Console.WriteLine("--> ClaseObrera.AlCurro(): Currando");
            Console.ReadKey();

            Console.WriteLine("--> ClaseObrera.AlCurro(): Terminando de currar");
            Console.ReadKey();
        }
    }
}
