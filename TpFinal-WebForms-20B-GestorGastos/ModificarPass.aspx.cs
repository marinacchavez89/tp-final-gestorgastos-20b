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
    public partial class ModificarPass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string passAnterior = txtPassAnterior.Text;
            string passNueva = txtPassNueva.Text;

            UsuarioNegocio negocio = new UsuarioNegocio();
            Usuario usuario = (Usuario)Session["Usuario"];
            
            usuario.PasswordHash = HashPassword(passNueva);
            
            bool resultado = negocio.CambiarContraseña(usuario, passAnterior, passNueva);

            if (resultado)
            {
                Response.Redirect("Exito.aspx", false);
            }
            else
            {
                lblError.Text = "La contraseña anterior es incorrecta.";
                lblError.Visible = true;
            }
        }
        private string HashPassword(string password)
        {            
            return password;
        }

    }
}