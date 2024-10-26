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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {            
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();

            try
            {                
                string email = txtEmail.Text;
                string password = txtPass.Text;

                // Verificamos las credenciales del usuario
                Usuario usuario = usuarioNegocio.ValidarUsuario(email, HashPassword(password));
                Session.Add("Usuario", usuario);

                if (usuario != null && usuario.Activo)
                {
                    Session["UsuarioEmail"] = usuario.Email;
                    Session["UsuarioNombre"] = usuario.Nombre;
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    lblError.Text = "Email o contraseña incorrectos.";
                    lblError.Visible = true;
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Ocurrió un error al intentar iniciar sesión: " + ex.Message;
                lblError.Visible = true;
            }
        }

        private string HashPassword(string password)
        {
            // Implementar el método de hasheo de password (ej., con bcrypt o SHA256)
            return password; // Solo pa ejemplo
        }

        protected void btnOlvidePass_Click(object sender, EventArgs e)
        {
            // Aquí podrías redirigir a una página de recuperación de contraseña o mostrar un mensaje
            lblError.Text = "Funcionalidad de recuperación de contraseña aún no implementada.";
            lblError.Visible = true;
        }
    }
}