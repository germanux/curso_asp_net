using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForms_Favoritos
{
    public partial class lista_usuarios_linq : System.Web.UI.Page
    {
       // public List<lista_usuarios_linq>
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {

        }
        public static string DameNumeroChorra(int num)
        {
            switch (num)
            {
                case 0: return "cero";
                case 1: return "uno";
                case 2: return "dos";
                case 3: return "tres";
                case 5: throw new FormatException();
                case 6: return int.Parse("AAAA").ToString();
                default: return null;
            }

        }
    }
}