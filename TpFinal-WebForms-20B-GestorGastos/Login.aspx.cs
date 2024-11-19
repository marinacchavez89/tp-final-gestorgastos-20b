using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                string password = txtPassLogin.Text;

                if (string.IsNullOrWhiteSpace(email))
                {
                    lblError.Text = "El campo de email no puede estar vacío.";
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Visible = true;
                    return;
                }

                if (string.IsNullOrWhiteSpace(password))
                {
                    lblError.Text = "El campo contraseña no puede estar vacío.";
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Visible = true;
                    return;
                }

                // Verificamos las credenciales del usuario
                Usuario usuario = usuarioNegocio.ValidarUsuario(email, HashPassword(password));
                Session.Add("Usuario", usuario);

                if (usuario != null && usuario.Activo)
                {
                    Session["UsuarioId"] = usuario.IdUsuario;
                    Session["UsuarioEmail"] = usuario.Email;
                    Session["UsuarioNombre"] = usuario.Nombre;

                    bool verificarPassActualCodInvitacion = usuarioNegocio.VerificarContraseñaConCodigoInvitacion(usuario.IdUsuario, usuario.PasswordHash);
                    bool verificacionPassActualAleatoria = usuarioNegocio.esPasswordAleatoria(usuario.PasswordHash, usuario.IdUsuario);

                    if (verificarPassActualCodInvitacion || verificacionPassActualAleatoria)
                    {                     
                        Response.Redirect("Perfil.aspx");
                    }
                    else
                    {
                        Response.Redirect("Default.aspx");
                    }
                    
                }
                else
                {
                    lblError.Text = "Email o contraseña incorrectos.";
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Visible = true;
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Ocurrió un error al intentar iniciar sesión: " + ex.Message;
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Visible = true;
            }
        }

        private string HashPassword(string password)
        {
            // Acá se debería implmementar SHA como en labo III
            return password;
        }

        protected void btnOlvidePass_Click(object sender, EventArgs e)
        {
            UsuarioNegocio negocio = new UsuarioNegocio();
            string email = txtEmail.Text;

            if (string.IsNullOrWhiteSpace(email))
            {
                lblError.Text = "El campo de email no puede estar vacío.";
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Visible = true;
                return;
            }            

            string passDefaultAleatoria = generarPasswordAleatoria();
            if (negocio.ExisteUsuario(email))
            {   
                int idUsuario = negocio.obtenerIdUsuarioPorEmail(email);
                negocio.updatePass(idUsuario, passDefaultAleatoria);
                EmailService emailService = new EmailService();
                emailService.EnviarCorreoOlvidoPass(email, passDefaultAleatoria);
                lblError.ForeColor = System.Drawing.Color.Green;
                lblError.Visible = true;
                lblError.Text = "En la casilla de email registrada ha recibido una nueva contraseña.";                
            }

        }
        public static string generarPasswordAleatoria()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()";
            var random = new Random();
            var password = new StringBuilder();

            for (int i = 0; i < 8; i++)
            {
                password.Append(chars[random.Next(chars.Length)]);
            }

            // Le agrego el sufijo -A para identificar que es una pass generada aleatoriamente.
            return password.ToString() + "-A";
        }        
    }
}