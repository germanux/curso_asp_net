using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEjemploEventos
{
    delegate void TipoDel_AlEmpezar(string infoEvento = "");
    delegate int TipoDel_AlSeguir(string infoEvento = "");
    delegate void TipoDel_AlAcabar();

    // EventHandler = delegate void TipoEvento(object sender, EventArgs args);  // EVENTO
	public class MisArgumentosEventArgs : EventArgs
    {
        public string textoInfo;
        public int valorInfo;
    }
    partial class ClaseObreraDeleg
    {
        public TipoDel_AlEmpezar FuncionCampoAlEmpezar;
        public TipoDel_AlSeguir FuncionCampoAlSeguir;
        public TipoDel_AlAcabar FuncionCampoAlAcabar;

        public event EventHandler<MisArgumentosEventArgs> FunEventoAviso;  // EVENTO

        public void AlCurroDelegados()
        {
            FunEventoAviso(this, new MisArgumentosEventArgs());  // EVENTO

            Console.WriteLine("--> ClaseObrera.AlCurro(): Empezando a currar");
            FuncionCampoAlEmpezar?.Invoke("** Info Delegado Al Empezar");
            Console.ReadKey();

            Console.WriteLine("--> ClaseObrera.AlCurro(): Currando");
            int? numCaracteres = FuncionCampoAlSeguir?.Invoke("** Info Delegado Al Seguir");
            Console.WriteLine("--> ClaseObrera.AlCurro(): Caracteres: " + numCaracteres);
            Console.ReadKey();

            Console.WriteLine("--> ClaseObrera.AlCurro(): Terminando de currar");
            FuncionCampoAlAcabar?.Invoke();
            Console.ReadKey();
        }


    }
}
