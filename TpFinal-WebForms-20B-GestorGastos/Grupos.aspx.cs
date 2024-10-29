using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TpFinal_WebForms_20B_GestorGastos
{
    public partial class Grupos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUnirseGrupo_Click(object sender, EventArgs e)
        {
            Response.Redirect("UnirseGrupo.aspx");
        }
        protected void btnCrearGrupo_Click(Object sender, EventArgs e)
        {
            Response.Redirect("CrearGrupo.aspx");
        }
    }
}