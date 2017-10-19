using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;

namespace WebForms_Favoritos
{
    /// <summary>
    /// Descripción breve de GestionUsuarios
    /// </summary>
    public class GestionUsuarios
    {
        public class GesUsuEventArgs : EventArgs
        {
            public string Mensaje;
            public SqlNotificationEventArgs ev;
        }
        private string cadena_conexion;
        private string insertSQL;
        private string selectSQL;
        private SqlConnection conexDB;
        private DataSet dataSet;
        public List<Usuario> listaUsuarios;
        public event EventHandler EnPeticionSQL;

        public GestionUsuarios()
        {
            listaUsuarios = new List<Usuario>();
            cadena_conexion = "Server=tcp:servidorgerman.database.windows.net,1433;Initial Catalog=bd_favoritos;Persist Security Info=False;User ID=administrador;Password=SQL.1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            insertSQL = "INSERT INTO usuario(nombre, anio) VALUES (@nombre, @anio);";
            selectSQL = "SELECT id, nombre, anio FROM usuario";
            InicializarBD();
        }
        public int InicializarBD()
        {
            conexDB = new SqlConnection(cadena_conexion);
            conexDB.Open();
            dataSet = new DataSet("bd_favoritos");
            SqlDataAdapter adaptadorBD = new SqlDataAdapter();
            SqlCommand selectCmd = conexDB.CreateCommand();
            selectCmd.CommandText = selectSQL;
            adaptadorBD.SelectCommand = selectCmd;

            DataTableMapping mapeoTB = new DataTableMapping("usuario", "usuario");
            mapeoTB.ColumnMappings.Add(new DataColumnMapping("id", "id"));
            mapeoTB.ColumnMappings.Add(new DataColumnMapping("nombre", "nombre"));
            mapeoTB.ColumnMappings.Add(new DataColumnMapping("anio", "anio"));


            adaptadorBD.TableMappings.Add(mapeoTB);
            adaptadorBD.FillSchema(dataSet, SchemaType.Mapped);
            int numFilas = adaptadorBD.Fill(dataSet, "usuario");
            if (numFilas > 0)
                Debug.WriteLine(">>>>> GestionUsuarios: FILAS LEIDAS: " + numFilas);
            else
                Debug.Fail(">>>>> GestionUsuarios: NO HAY FILAS");
            conexDB.Close();
            return numFilas;
        }
        public List<Usuario> ListaUsuarios(string nombre)
        {
            listaUsuarios.Clear();
            if (nombre == null) nombre = "";
            DataTable dataTb_usu = dataSet.Tables["usuario"];

            IEnumerable<DataRow> listaRon = from usuario in dataTb_usu.AsEnumerable()
                where usuario.Field<string>("nombre").ToUpper().Contains(nombre.ToUpper())
                    select usuario;

            foreach (DataRow row in listaRon)
            {
                listaUsuarios.Add(
                    new Usuario()
                    {
                        Id = int.Parse(row["id"].ToString()),
                        Nombre = row["nombre"].ToString(),
                        Anio = int.Parse(row["anio"].ToString())
                    } );
            }
            return listaUsuarios;
        }
        public List<Usuario> ListaUsuarios2(string nombre)
        {
            listaUsuarios.Clear();
            listaUsuarios.Add(new Usuario() { Id = 1, Nombre = "eJuan", Anio = 1190 });
            listaUsuarios.Add(new Usuario() { Id = 2, Nombre = "Luis", Anio = 1180 });

            return listaUsuarios;
        }
        public void CrearUsuario(Usuario usuario)
        {
            try
            {
                if (conexDB.State == ConnectionState.Closed)
                {
                    conexDB.Open();
                }
                SqlCommand comandoSQL = conexDB.CreateCommand();
                comandoSQL.CommandText = insertSQL;
                comandoSQL.Parameters.Add(new SqlParameter("@nombre", usuario.Nombre));
                comandoSQL.Parameters.Add(new SqlParameter("@anio", usuario.Anio));
                comandoSQL.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                GesUsuEventArgs infoEv = new GesUsuEventArgs();
                infoEv.ev = new SqlNotificationEventArgs(SqlNotificationType.Unknown,
                    SqlNotificationInfo.Error,
                    SqlNotificationSource.Database);
                infoEv.Mensaje = "Error SQL: " + ex.Message + "\n" + ex.StackTrace;
                EnPeticionSQL(this, infoEv);
            }
            if (conexDB.State == ConnectionState.Open)
            {
                conexDB.Close();
            }
            GesUsuEventArgs infEv = new GesUsuEventArgs();
            infEv.Mensaje = "Creacion SQL OK: ";
            EnPeticionSQL(this, infEv);
        }
        ~GestionUsuarios()
        {
            conexDB.Dispose();
        }
    }
}