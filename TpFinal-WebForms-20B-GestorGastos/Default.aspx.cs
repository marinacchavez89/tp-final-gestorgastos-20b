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
            GastoNegocio negocio = new GastoNegocio();
            ListaGastos = negocio.listar();
            repRepetidor.DataSource = ListaGastos;
            repRepetidor.DataBind();
        }
    }
}