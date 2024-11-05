using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace TpFinal_WebForms_20B_GestorGastos
{
    public partial class ConfirmarEliminar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            GrupoNegocio negocio = new GrupoNegocio();

            negocio.eliminarGrupo((int)Session["idGrupo"]);

            Response.Redirect("Exito.aspx", false);
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Amigos.aspx", false);
        }
    }
}