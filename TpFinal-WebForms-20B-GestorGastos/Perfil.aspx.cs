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
                txtEmail.Text = Session["UsuarioEmail"].ToString();
                txtNombre.Text = Session["UsuarioNombre"].ToString();
            }
            txtEmail.Enabled = false;
            txtNombre.Enabled = false;
            btnGuardar.Enabled = false;
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            txtEmail.Enabled = true;
            txtNombre.Enabled = true;
            btnGuardar.Enabled = true;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            UsuarioNegocio negocio = new UsuarioNegocio();
            Usuario usuario = (Usuario)Session["Usuario"];
            usuario.Email = txtEmail.Text;
            usuario.Nombre = txtNombre.Text;
            negocio.actualizar(usuario);
            Session["UsuarioEmail"] = txtEmail.Text;
            Session["UsuarioNombre"] = txtNombre.Text;
        }
    }
}