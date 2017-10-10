using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEjemploEventos
{
    partial class ClaseObreraDeleg
    {        
        public void AlCurroCallBK(TipoDel_AlEmpezar funAlEmpezar,
            TipoDel_AlSeguir funAlSeguir, TipoDel_AlAcabar funAlcabar)
        {
            Console.WriteLine("--> ClaseObrera.AlCurro(): Empezando a currar");
            // if (funAlEmpezar != null)
            //   funAlEmpezar("LLAMANDO A CALLBACK");
            funAlEmpezar?.Invoke("LLAMANDO A CALLBACK funAlEmpezar");
            Console.ReadKey();

            Console.WriteLine("--> ClaseObrera.AlCurro(): Currando");
            int? numCaracteres = funAlSeguir?.Invoke("LLAMANDO A CALLBACK funAlSeguir");
            Console.WriteLine("--> ClaseObrera.AlCurro(): Caracteres: " + numCaracteres);
            Console.ReadKey();

            Console.WriteLine("--> ClaseObrera.AlCurro(): Terminando de currar");
            funAlcabar?.Invoke();
            Console.ReadKey();
        }
    }
}
