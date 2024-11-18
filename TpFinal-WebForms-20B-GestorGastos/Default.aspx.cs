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
    public partial class Home : System.Web.UI.Page
    {
        public List<Gasto> ListaGastos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if(Session["UsuarioId"] == null)
                {
                    Response.Redirect("Login.aspx");
                    return;
                }   
            GastoNegocio negocio = new GastoNegocio();

            int idUsuario = (int)Session["UsuarioId"];
            ListaGastos = negocio.listarGastosPorUsuario(idUsuario);
            repRepetidor.DataSource = ListaGastos;
            repRepetidor.DataBind();
                if(ListaGastos.Count == 0 && ListaGastos != null)
                {
                    lblNoHayGastos.Visible = true;
                }
            }
        }

        protected void btnEliminarGasto_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btn = (ImageButton)sender;
            int idGasto = Convert.ToInt32(btn.CommandArgument);
            Session.Add("idGasto", idGasto);
            Response.Redirect("ConfirmarEliminarGasto.aspx", false);         
        }

        protected void btnModificarGasto_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btn = (ImageButton)sender;
            int idGasto = Convert.ToInt32(btn.CommandArgument);

            Session.Add("idGasto", idGasto);
            Response.Redirect("Gastos.aspx?id=" + idGasto);
        }
    }
}