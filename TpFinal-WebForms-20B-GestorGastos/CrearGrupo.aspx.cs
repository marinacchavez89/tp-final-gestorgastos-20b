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
    public partial class CrearGrupo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Grupos.aspx", false);
        }
        protected void btnGuardarGrupo_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreGrupo = txtNombreGrupo.Text.Trim();
                if (string.IsNullOrEmpty(nombreGrupo))
                {
                    lblMensaje.Text = "Por favor, ingresa un nombre para el grupo.";
                    return;
                }
                string email = Session["UsuarioEmail"].ToString();
                int creadoPor = new UsuarioNegocio().obtenerIdUsuarioPorEmail(email);
                string codigoInvitacion = new GeneradorCodigo().generarCodigoUnico();

                Grupo nuevoGrupo = new Grupo
                {
                    NombreGrupo = nombreGrupo,
                    CreadoPor = creadoPor,
                    CodigoInvitacion = codigoInvitacion,
                    FechaCreacion = DateTime.Now,
                };
                GrupoNegocio grupoNegocio = new GrupoNegocio();
                int idGrupo = grupoNegocio.crearGrupo(nuevoGrupo);
                grupoNegocio.agregarUsuarioGrupo(creadoPor, idGrupo);
                Response.Redirect("Exito.aspx");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    

    }
}