using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace AppPrototipoFavoritos
{
    class Program
    {
        static void Main(string[] args)
        {
            // EjemplosUsoPersona.UsoClasesEstructurasEnums();
            // EjemplosUsoPersona.UsoPropiedades();
            // EjemplosUsoPersona.UsoReflection();
            // EjemploGenericos.UsoGenericos();  
            // EjemploUsoInterfaces.UsoInterfaces();
            // EjemploUsoInterfaces.UsoOperadores();
            // EjemploUsoPOO.UsoPolimorfismo();
            //EjemploUsoPOO.UsoBusquedaAsincronaUsuarios();

            EjemploDelegados observador = new EjemploDelegados();
            EjemploUsoPOO.gesUsu = new ListaUsuarios();
            EjemploUsoPOO.gesUsu.RegistrarObservador(observador);

            EjemploUsoPOO.UsoGestionUsuarios(observador.AvisameAlModificar);

            Console.ReadKey();
        }
    }
}