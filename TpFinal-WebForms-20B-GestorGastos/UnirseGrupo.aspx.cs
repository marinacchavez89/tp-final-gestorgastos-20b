using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
namespace TpFinal_WebForms_20B_GestorGastos
{
    public partial class UnirseGrupo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Grupos.aspx", false);
        }

        protected void btnUnirseGrupo_Click(object sender, EventArgs e)
        {
            try
            {
                string codigoInvitacion = txtCodigoInvitacion.Text.Trim();
                string email = Session["UsuarioEmail"].ToString();
                int idUsuario = new UsuarioNegocio().obtenerIdUsuarioPorEmail(email);
                GrupoNegocio grupoNegocio = new GrupoNegocio();
                int idGrupo = grupoNegocio.obtenerIdGrupoPorCodigoInvitacion(codigoInvitacion);
                if (idGrupo == -1) 
                {
                    lblError.Text = "El código de invitación no es válido.";
                    lblError.Visible = true;
                }
                else
                {
                    grupoNegocio.agregarUsuarioGrupo(idUsuario, idGrupo);
                    Response.Redirect("Exito.aspx");                    
                }
               
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}