using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class UsuariosBaseOleDB : UsuariosImportadorBase
    {
        protected string cadenaConexion;
        protected string consultaSQL;

        public UsuariosBaseOleDB(string proveedorOleDb, string nombreFichero)
        {
            var constructorCadConex = new OleDbConnectionStringBuilder();
            constructorCadConex.Provider = proveedorOleDb;
            constructorCadConex.DataSource = nombreFichero;
            this.cadenaConexion = constructorCadConex.ConnectionString;
        }

        public override bool Exportar(List<Persona> listaUsuarios)
        {
            var conexion = new OleDbConnection(this.cadenaConexion);
            OleDbCommand comando = null;
            try
            {
                conexion.Open();

                foreach(Persona persona in listaUsuarios)
                {
                    comando = new OleDbCommand("INSERT INTO usuario (nombre, anio) VALUES ('" + persona.Nombre + "', " + persona.Anio + ");", conexion);
                    //comando = conexion.CreateCommand();
                    //comando.CommandText = "INSERT ....";
                    comando.ExecuteNonQuery();
                }
            } catch (Exception ex)
            {
                return false;
            }
            conexion.Close();
            conexion.Dispose();
            return true;
        }

        public override bool Importar(List<Persona> listaUsuarios)
        {
            throw new NotImplementedException();
        }
    }
}
