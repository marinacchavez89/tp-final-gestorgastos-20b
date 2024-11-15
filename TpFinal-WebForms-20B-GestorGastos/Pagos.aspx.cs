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
                int idGasto = 5; // el gasto va por ahora hardcodeado
                cargarDetalleGasto(idGasto);
            }
		}
        private void cargarDetalleGasto(int idGasto)
        {
            GastoNegocio gastoNegocio = new GastoNegocio();
            Gasto gasto = gastoNegocio.obtenerGastoPorId(idGasto);
            string nombreGrupo = gastoNegocio.ObtenerNombreGrupoPorId(gasto.IdGrupo);
            if (gasto != null)
            {
            lblDescripcion.Text = gasto.Descripcion;
            lblMontoTotal.Text = gasto.MontoTotal.ToString();
            lblFechaGasto.Text = gasto.FechaGasto.ToString();
                lblGrupo.Text = nombreGrupo;
            }
        }
        
    }
}