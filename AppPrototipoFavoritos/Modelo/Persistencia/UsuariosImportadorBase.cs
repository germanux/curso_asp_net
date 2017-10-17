using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public delegate void TipoFuncionBD(bool estado, string mensaje);

    public abstract class UsuariosImportadorBase : IPersistenciaUsuarios
    {
        public TipoFuncionBD EstadoBD;

        public string NombreFichero { get; set; }

        public abstract Task<bool> ExportarAsync(List<Persona> listaUsuarios);

        public abstract Task<bool> ImportarAsync(List<Persona> listaUsuarios);

       
    }
}
