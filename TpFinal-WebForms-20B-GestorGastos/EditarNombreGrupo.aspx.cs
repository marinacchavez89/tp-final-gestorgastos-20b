using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TpFinal_WebForms_20B_GestorGastos
{
    public partial class EditarNombreGrupo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {   
            string nuevoNombre = txtNombreGrupo.Text;
            if (Session["idGrupo"] != null)
            {
                int idGrupo = (int)Session["idGrupo"];
                GrupoNegocio negocio = new GrupoNegocio();
                negocio.editarNombreGrupo(nuevoNombre, idGrupo);
                Response.Redirect("Exito.aspx", false);
            }        
        }
    }
}