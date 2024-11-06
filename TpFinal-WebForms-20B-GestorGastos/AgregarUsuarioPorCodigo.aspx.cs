using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TpFinal_WebForms_20B_GestorGastos
{
    public partial class AgregarUsuarioPorCodigo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtEmail.Text = (string)Session["emailUsuarioAInvitar"];
            txtPass.Text = (string)Session["codInvitacionGrupo"];
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {           
            if (Session["emailUsuarioAInvitar"] != null && Session["idGrupoAInvitarPorCodigo"] != null )
            {                
                UsuarioNegocio negocio = new UsuarioNegocio();               
                Usuario nuevoUsuario = new Usuario();
                nuevoUsuario.Email = txtEmail.Text;
                nuevoUsuario.Nombre = txtNombre.Text;
                nuevoUsuario.FechaRegistro = DateTime.Now;
                nuevoUsuario.PasswordHash = txtPass.Text;
                
                negocio.RegistrarUsuario(nuevoUsuario);
                int idUsuarioDadoDeAlta = negocio.obtenerIdUsuarioPorEmail(txtEmail.Text);

                GastoNegocio gastoNegocio = new GastoNegocio();
                bool agregado = gastoNegocio.AgregarParticipanteAGrupo((int)Session["idGrupoAInvitarPorCodigo"], idUsuarioDadoDeAlta);

                if (agregado)
                {
                    Response.Redirect("Exito.aspx", false);
                }
                else
                {
                    lblError.Text = "No se pudo dar de alta al usuario con el código de invitación.";
                    lblError.Visible = true;
                }
                
            }
        }
    }
}