using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TpFinal_WebForms_20B_GestorGastos
{
    public partial class confirmarEliminarGasto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            GastoNegocio negocio = new GastoNegocio();
            int idGasto = (int)Session["idGasto"];
            negocio.eliminarGasto(idGasto);

            Response.Redirect("Default.aspx", false);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx", false);
        }
    }
}