using Microsoft.Win32;
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
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!(Page is Login || Page is Registrarse))
            {
                if (!Seguridad.sesionActiva(Session["Usuario"]))
                {
                    Response.Redirect("Login.aspx", false);
                }
            }

            if (Session["Usuario"] != null)
            {
                Usuario usuario = (Usuario)Session["Usuario"];
                UsuarioNegocio negocio = new UsuarioNegocio();
                string imagenPerfil = negocio.obtenerImagenPerfil(usuario.IdUsuario);

                // Guardar la URL de la imagen en la sesión
                Session["ImagenPerfil"] = imagenPerfil ?? "/Images/logoLogin.png";
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("Login.aspx", false);
        }
    }
}