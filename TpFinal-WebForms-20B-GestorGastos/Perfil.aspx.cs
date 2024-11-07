using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;

namespace TpFinal_WebForms_20B_GestorGastos
{
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!Seguridad.sesionActiva(Session["Usuario"]))
                {
                    Response.Redirect("Login.aspx", false);
                }
                else
                {
                    txtEmail.Text = Session["UsuarioEmail"].ToString();
                    txtNombre.Text = Session["UsuarioNombre"].ToString();
                    txtEmail.Enabled = false;
                    txtNombre.Enabled = false;
                    btnGuardar.Visible = false;
                    //txtImagen.Visible = false;
                }

                if (Session["Usuario"] != null)
                {
                    Usuario usuario = (Usuario)Session["Usuario"];
                    UsuarioNegocio negocio = new UsuarioNegocio();
                    string imagenPerfil = negocio.obtenerImagenPerfil(usuario.IdUsuario);

                    // Asignar la URL de la imagen al control de imagen o usar la imagen predeterminada
                    imgNuevoPerfil.ImageUrl = !string.IsNullOrEmpty(imagenPerfil) ? imagenPerfil : "https://www.palomacornejo.com/wp-content/uploads/2021/08/no-image.jpg";

                    bool mostrarLblParaUserMismaPassCodInv = negocio.VerificarContraseñaConCodigoInvitacion(usuario.IdUsuario, usuario.PasswordHash);
                    if (mostrarLblParaUserMismaPassCodInv)
                    {
                        lblCambiarPassCodInvitacion.Visible = true;
                        lblCambiarPassCodInvitacion.Text = "¡Por seguridad, debes cambiar tu contraseña!";
                    }
                }
            }

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx", false);
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            txtEmail.Enabled = true;
            txtNombre.Enabled = true;
            btnGuardar.Visible = true;
            //txtImagen.Visible = true;
            rptImagenesPerfil.Visible = true;

            var imagenes = new List<string>
            {
                "/Images/perfil1.png",
                "/Images/perfil2.png",
                "/Images/perfil3.png",
                "/Images/perfil4.png"
            };

            rptImagenesPerfil.DataSource = imagenes.Select(img => new { ImageUrl = img });
            rptImagenesPerfil.DataBind();
        }



        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            UsuarioNegocio negocio = new UsuarioNegocio();
            Usuario usuario = (Usuario)Session["Usuario"];
            usuario.Email = txtEmail.Text;
            usuario.Nombre = txtNombre.Text;

            usuario.UrlImagen = imgNuevoPerfil.ImageUrl;

            negocio.actualizar(usuario);
            negocio.guardarImagen(usuario);

            // Actualizar la sesión con los nuevos valores
            Session["UsuarioEmail"] = txtEmail.Text;
            Session["UsuarioNombre"] = txtNombre.Text;

            // Deshabilitar los campos después de guardar
            txtEmail.Enabled = false;
            txtNombre.Enabled = false;
            btnGuardar.Enabled = false;

            Response.Redirect("Exito.aspx", false);
        }

        protected void btnSeleccionar_Command(object sender, CommandEventArgs e)
        {
            // Obtener la URL de la imagen seleccionada
            string imageUrl = e.CommandArgument.ToString();

            // Asignar la URL al control de imagen de perfil
            imgNuevoPerfil.ImageUrl = imageUrl;

            Usuario usuario = (Usuario)Session["Usuario"];
            usuario.UrlImagen = imageUrl;
        }

        protected void btnModificarPass_Click(object sender, EventArgs e)
        {
            Response.Redirect("ModificarPass.aspx", false);
        }
    }
}