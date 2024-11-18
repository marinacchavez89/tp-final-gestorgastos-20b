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
            if (!IsPostBack)
            {
                CargarGrupos();

            }
        }
        private void cargarDetalleGasto(int idGasto)
        {
            GastoNegocio gastoNegocio = new GastoNegocio();
            GrupoNegocio grupoNegocio = new GrupoNegocio();
            Gasto gasto = gastoNegocio.obtenerGastoPorId(idGasto);
            if (gasto != null)
            {
                string nombreGrupo = grupoNegocio.ObtenerNombreGrupoPorId(gasto.IdGrupo);
                lblDescripcion.Text = gasto.Descripcion;
                lblMontoTotal.Text = gasto.MontoTotal.ToString();
                lblFechaGasto.Text = gasto.FechaGasto.ToString();
                lblGrupo.Text = nombreGrupo;
                detalleGastoContainer.Visible = true;
            }
            else
            {
                lblDescripcion.Text = "";
                lblMontoTotal.Text = "";
                lblFechaGasto.Text = "";
                lblGrupo.Text = "";
                detalleGastoContainer.Visible = false;
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
            GastoNegocio gastoNegocio = new GastoNegocio();
            int idGrupo = Convert.ToInt32(ddlGrupos.SelectedValue);
            if (idGrupo > 0)
            {
                listarGastosPorGrupo(idGrupo);
            }
        }
        private void listarGastosPorGrupo(int idGrupo)
        {
            GastoNegocio gastoNegocio = new GastoNegocio();
            List<Gasto> gastos = gastoNegocio.listarGastosPorGrupo(idGrupo);
            if (gastos != null && gastos.Count > 0)
            {
                repGastos.DataSource = gastos;
                repGastos.DataBind();
                gastosContainer.Visible = true;
            }
            else
            {
                repGastos.DataSource = null;
                repGastos.DataBind();
                gastosContainer.Visible = false;
            }
        }
        protected void repGastos_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "SeleccionarGasto")
            {
                int idGasto = Convert.ToInt32(e.CommandArgument);
                cargarDetalleGasto(idGasto);
                cargarParticipantesConEstadoDePago(idGasto);
            }
            else
            {
                // error generico (no deberia pasar)
            }
        }

        private void cargarParticipantesConEstadoDePago(int idGasto)
        {
            ParticipanteGastoNegocio participanteGastoNegocio = new ParticipanteGastoNegocio();
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            List<ParticipanteGasto> participantes = participanteGastoNegocio.listarParticipantesConEstadoPago(idGasto);
            foreach (ParticipanteGasto participante in participantes)
            {
                participante.MontoPagado = participanteGastoNegocio.obtenerMontoPagadoPorUsuario(participante.IdGasto, participante.IdUsuario);
                participante.DeudaPendiente = participante.MontoIndividual - participante.MontoPagado;

            }
            repPagosParticipantes.DataSource = participantes;
            repPagosParticipantes.DataBind();

        }
    } }