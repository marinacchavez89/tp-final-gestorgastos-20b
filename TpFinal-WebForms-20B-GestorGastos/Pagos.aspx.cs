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
	public partial class Pagos : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if(!IsPostBack)
            {
                CargarGrupos();
                int idGasto = 6; // el gasto va por ahora hardcodeado
                cargarDetalleGasto(idGasto);
            }
		}
        private void cargarDetalleGasto(int idGasto)
        {
            GastoNegocio gastoNegocio = new GastoNegocio();
            GrupoNegocio grupoNegocio = new GrupoNegocio();
            Gasto gasto = gastoNegocio.obtenerGastoPorId(idGasto);
            string nombreGrupo = grupoNegocio.ObtenerNombreGrupoPorId(gasto.IdGrupo);
            if (gasto != null)
            {
                lblDescripcion.Text = gasto.Descripcion;
                lblMontoTotal.Text = gasto.MontoTotal.ToString();
                lblFechaGasto.Text = gasto.FechaGasto.ToString();
                lblGrupo.Text = nombreGrupo;
            }
        }
        private void CargarGrupos()
        {
            if (Session["UsuarioId"] != null)
            {
                int usuarioId = (int)Session["UsuarioId"];
                GastoNegocio gastoNegocio = new GastoNegocio();
                List<Grupo> grupos = gastoNegocio.listarGruposPorUsuario(usuarioId);

                ddlGrupos.DataSource = grupos;
                ddlGrupos.DataValueField = "IdGrupo";
                ddlGrupos.DataTextField = "NombreGrupo";
                ddlGrupos.DataBind();
                ddlGrupos.Items.Insert(0, new ListItem("Selecciona un grupo", "0"));
            }
        }
        protected void ddlGrupos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int grupoId = Convert.ToInt32(ddlGrupos.SelectedValue);
            if (grupoId > 0)
            {
              //logica
            }
        }
    }
}