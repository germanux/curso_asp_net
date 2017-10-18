using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

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
    public List<Usuario> listaUsuarios;
    public event EventHandler EnPeticionSQL;

    public GestionUsuarios()
    {
        cadena_conexion = "Server=tcp:servidorgerman.database.windows.net,1433;Initial Catalog=bd_usuarios;Persist Security Info=False;User ID=administrador;Password=SQL.1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        insertSQL = "INSERT INTO usuario(nombre, anio) VALUES (@nombre, @anio);";
        selectSQL = "SELECT nombre, anio FROM usuario";
        conexDB = new SqlConnection(cadena_conexion);
    }
    public void CrearUsuario(Usuario usuario)
    {
        try
        {
            if (conexDB.State == ConnectionState.Closed) { 
                conexDB.Open();
            }
            SqlCommand comandoSQL = conexDB.CreateCommand();
            comandoSQL.CommandText = insertSQL;
            comandoSQL.Parameters.Add(new SqlParameter("@nombre", usuario.Nombre));
            comandoSQL.Parameters.Add(new SqlParameter("@anio", usuario.Anio));
            comandoSQL.ExecuteNonQuery();
        } catch (Exception ex)
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
    ~GestionUsuarios() {
        conexDB.Dispose();
    }
}