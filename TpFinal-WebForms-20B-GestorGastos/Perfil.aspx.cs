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
                    txtEmail.Enabled = true; 
                    txtNombre.Enabled = true;
                    btnAceptar.Enabled = true;
                }
            }
           
        }        
        

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            UsuarioNegocio negocio = new UsuarioNegocio();
            Usuario usuario = (Usuario)Session["Usuario"];
            usuario.Email = txtEmail.Text;
            usuario.Nombre = txtNombre.Text;
            negocio.actualizar(usuario);
            // Actualizar la sesión con los nuevos valores
            Session["UsuarioEmail"] = txtEmail.Text;
            Session["UsuarioNombre"] = txtNombre.Text;

            // Deshabilitar los campos después de guardar
            txtEmail.Enabled = false;
            txtNombre.Enabled = false;
            btnAceptar.Enabled = false;

            Response.Redirect("Exito.aspx", false);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx", false);
        }
    }
}