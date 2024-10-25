using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TpFinal_WebForms_20B_GestorGastos
{
    public partial class Registrarse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();

            Usuario nuevoUsuario = new Usuario
            {
                Nombre = txtNombre.Text,
                Email = txtEmail.Text,
                PasswordHash = HashPassword(txtPass.Text),
                FechaRegistro = DateTime.Now,
                Activo = true
            };

            try
            {
                bool registroExitoso = usuarioNegocio.RegistrarUsuario(nuevoUsuario);

                if (registroExitoso)
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {                    
                    lblError.Text = "El email ya está registrado. Por favor, usa uno diferente.";
                    lblError.Visible = true;
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Error: " + ex.Message;
                lblError.Visible = true;
            }

        }

        private string HashPassword(string password)
        {
            // Acá se debería implementar el método de hasheo de password, por ejemplo con bcrypt o SHA256
            return password; // (Temporal, solo para ejemplo)
        }

    }
    
}