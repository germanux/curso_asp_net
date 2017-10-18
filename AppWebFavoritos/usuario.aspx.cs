using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class usuario : System.Web.UI.Page
{
    GestionUsuarios gesUsu;

    protected void Page_Load(object sender, EventArgs e)
    {
        gesUsu = new GestionUsuarios();
        gesUsu.EnPeticionSQL += GesUsu_EnPeticionSQL;
    }
    protected void BtnEnviar_Click(object sender, EventArgs e)
    {
        Usuario usuario = new Usuario();
        usuario.Nombre = TxtNombre.Text;
        int num;
        int.TryParse(TxtAnio.Text, out num);
        usuario.Anio = num;
        gesUsu.CrearUsuario(usuario);
    }
    protected void GesUsu_EnPeticionSQL(object sender, EventArgs e)
    {
        GestionUsuarios.GesUsuEventArgs evSql = (GestionUsuarios.GesUsuEventArgs) e;
        LstMensajes.Items.Add(new ListItem(evSql.Mensaje, "", false));
        // LstMensajes.Items.Add(evSql.Mensaje);
    }
}