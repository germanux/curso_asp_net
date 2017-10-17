using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Modelo;

namespace AplicacionWeb
{
    public partial class nuevo_usuario : System.Web.UI.Page
    {
        GestionUsuarios gu;
        protected void Page_Load(object sender, EventArgs e)
        {
            gu = new GestionUsuarios();
        }
        protected void AlPulsarBotonEnviar(object sender, EventArgs e)
        {
            Button elBoton = (Button)sender;
            Persona p = new Persona();
            p.Nombre = TxtNombre.Text;
            p.Email = TxtEmail.Text;

            gu.Crear(p);
        }
    }
}