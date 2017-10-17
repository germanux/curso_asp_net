using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class UsuariosBaseOleDB : UsuariosImportadorBase
    {
        protected string cadenaConexion;
        protected string insertSQL = "INSERT INTO usuario (nombre, email, anio, genero, nacional, estado) VALUES (@nombre, @email, @anio, @genero, @nacional, @estado  );";
        public UsuariosBaseOleDB(string proveedorOleDb, string nombreFichero)
        {
            var constructorCadConex = new OleDbConnectionStringBuilder();
            constructorCadConex.Provider = proveedorOleDb;
            constructorCadConex.DataSource = nombreFichero;
            this.cadenaConexion = constructorCadConex.ConnectionString;
        }
        public async override Task<bool> ExportarAsync(List<Persona> listaUsuarios)
        {
            await Task.Yield();
            var conexion = new OleDbConnection(this.cadenaConexion);
            OleDbCommand comando = null;
            try
            {
                await conexion.OpenAsync();

                OleDbCommand comandoBorrar = conexion.CreateCommand();
                comandoBorrar.CommandText = "DELETE FROM usuario" ;
                comandoBorrar.ExecuteNonQuery();

                foreach(Persona persona in listaUsuarios)
                {
                    comando = new OleDbCommand(insertSQL, conexion);
                    comando.AddParametro("@nombre", persona.Nombre);
                    comando.AddParametro("@email", persona.Email);
                    comando.AddParametro("@anio", persona.Anio, DbType.Int32);
                    comando.AddParametro("@genero", (int) persona.Genero, DbType.Int32);
                    comando.AddParametro("@nacional", persona.Nacional, DbType.Boolean);
                    comando.AddParametro("@estado", persona.Estado, DbType.Boolean);
                    //comando.Prepare();*/
                    comando.ExecuteNonQuery();
                }
            } catch (Exception ex)
            {
                this.EstadoBD(false, "ERROR EN EXPORTACION: " + ex.GetType().ToString() + ", " + ex.Message + ", " + ex.StackTrace);
                return false;
            }
            finally
            {
                conexion.Close();
                conexion.Dispose();
                this.EstadoBD(true, "Exportacion OK");
            }
            return true;
        }

        public async override Task<bool> ImportarAsync(List<Persona> listaUsuarios)
        {
            await Task.Yield();
            OleDbCommand comando = null;
            OleDbConnection conexion;
            Persona persona;
            try  {
                if (listaUsuarios == null) listaUsuarios = new List<Persona>();
                using (conexion = new OleDbConnection(this.cadenaConexion))
                {
                    await conexion.OpenAsync();
                    comando = conexion.CreateCommand();
                    comando.CommandText = "SELECT nombre, email, anio, nacional, genero FROM usuario ORDER BY nombre";
                    OleDbDataReader lectorDB = comando.ExecuteReader();
                    while (lectorDB.Read())
                    {
                        persona = new Persona();
                        persona.Nombre = lectorDB[0].ToString();
                        persona.Email = lectorDB.GetString(1);
                        persona.Anio = lectorDB.GetInt32(2);
                        persona.Nacional = (bool)lectorDB.GetValue(3);
                        persona.Genero = lectorDB.GetFieldValue<TipoGenero>(4);
                        listaUsuarios.Add(persona);
                    }
                    lectorDB.Close();
                }
            }   catch (Exception ex)  {
                this.EstadoBD(false, "ERROR EN IMPORTACION: " + ex.GetType().ToString() + ", " + ex.Message + ", " + ex.StackTrace);
                return false;
            }   finally {
                this.EstadoBD(true, string.Format("IMPORTACION OK: {0} elementÓn", listaUsuarios.Count));
            }
            return true;
        }
    }
}
