using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TpFinal_WebForms_20B_GestorGastos
{
    public partial class Gastos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rblDivision.SelectedValue = "1";
                CargarGrupos();
                CargarParticipantes();
                mostrarCamposAdicionales();
                setearFechaDeHoy();
            }
            
            if (Request.QueryString["id"] != null && !IsPostBack)
            {
                btnAgregar.Text = "Modificar";
                pSubtitulo.Visible = false;
                GastoNegocio negocio = new GastoNegocio();
                List<Gasto> lista = new List<Gasto>();
                lista = negocio.listarPorId(Request.QueryString["id"].ToString());
                Gasto seleccionado = lista[0];
                Session.Add("idGasto", seleccionado.IdGasto);
                Session.Add("idGrupo", seleccionado.IdGrupo);

                txtFechaGasto.Text = seleccionado.FechaGasto.ToString("yyyy-MM-dd");
                txtConceptoGasto.Text = seleccionado.Descripcion.ToString();
                txtMontoGasto.Text = seleccionado.MontoTotal.ToString("0", CultureInfo.InvariantCulture);
                List<Grupo> grupo = new List<Grupo>();
                grupo = negocio.listarGrupoModificar((int)Session["idGrupo"]);
                ddlGrupos.DataSource = grupo;
                ddlGrupos.DataValueField = "IdGrupo";
                ddlGrupos.DataTextField = "NombreGrupo";
                ddlGrupos.DataBind();
                ddlGrupos.Enabled = false;

                int idGrupo = int.Parse(ddlGrupos.SelectedValue);
                GastoNegocio gastoNegocio = new GastoNegocio();
                List<ParticipanteGasto> participantes = gastoNegocio.ListarParticipantesPorGrupo(idGrupo);
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                var participantesConDatos = participantes.Select(p => new
                {
                    p.IdUsuario,
                    Nombre = gastoNegocio.ObtenerNombreUsuario(p.IdUsuario),
                    Email = gastoNegocio.ObtenerEmailUsuario(p.IdUsuario),
                    ImagenPerfil = usuarioNegocio.obtenerImagenPerfil(p.IdUsuario)
                }).ToList();

                repParticipantes.DataSource = participantesConDatos;
                repParticipantes.DataBind();
                ActualizarMontosIndividuales();
            }


        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtFechaGasto.Text))
            {
                lblErrorFecha.Visible = true;
                return;
            }
            if (string.IsNullOrEmpty(txtConceptoGasto.Text))
            {
                lblErrorConceptoGasto.Visible = true;
                return;
            }
            if(int.TryParse(txtMontoGasto.Text, out int montoGasto))
            {
                if(montoGasto <= 0)
                {
                    lblErrorMontoGasto.Visible = true;
                    return;
                }
            }
            if (string.IsNullOrEmpty(ddlGrupos.SelectedItem.Text) || ddlGrupos.SelectedItem.Text == "Seleccione un grupo")
            {
                lblErrorddlGrupos.Visible = true;
                return;
            }
            Gasto nuevoGasto;
            if (Request.QueryString["id"] != null)
            {
                nuevoGasto = new Gasto
                {
                    IdGasto = (int)Session["idGasto"],
                    IdGrupo = Convert.ToInt32(ddlGrupos.SelectedValue),
                    Descripcion = txtConceptoGasto.Text,
                    MontoTotal = Convert.ToDecimal(txtMontoGasto.Text),
                    FechaGasto = Convert.ToDateTime(txtFechaGasto.Text),
                    CreadoPor = (int)Session["UsuarioId"]
                };
            }
            else
            {
                nuevoGasto = new Gasto
                {
                    IdGrupo = Convert.ToInt32(ddlGrupos.SelectedValue),
                    Descripcion = txtConceptoGasto.Text,
                    MontoTotal = Convert.ToDecimal(txtMontoGasto.Text),
                    FechaGasto = Convert.ToDateTime(txtFechaGasto.Text),
                    CreadoPor = (int)Session["UsuarioId"]
                };
            }

            GastoNegocio gastoNegocio = new GastoNegocio();
            if (Request.QueryString["id"] != null)
                gastoNegocio.modificar(nuevoGasto);
            else
                gastoNegocio.AgregarGasto(nuevoGasto);


            int participantesSeleccionados = 0;
            foreach (ListItem item in lstParticipantesGasto.Items)
            {
                if (item.Selected)
                {
                    participantesSeleccionados++;
                }
            }

            if (participantesSeleccionados > 0)
            {
                decimal montoIndividual = nuevoGasto.MontoTotal / participantesSeleccionados;

                foreach (ListItem item in lstParticipantesGasto.Items)
                {
                    if (item.Selected)
                    {
                        ParticipanteGasto nuevoParticipante = new ParticipanteGasto
                        {
                            IdGasto = nuevoGasto.IdGasto,
                            IdUsuario = Convert.ToInt32(item.Value),
                            MontoIndividual = montoIndividual
                        };

                        ParticipanteGastoNegocio participanteGastoNegocio = new ParticipanteGastoNegocio();
                        participanteGastoNegocio.AgregarParticipante(nuevoParticipante);
                    }
                }
            }
            else
            {
                //Arrojar algun error o redirigir a pagina en especial.
            }

            Response.Redirect("Exito.aspx", false);
        }

        private void CargarGrupos()
        {
            if (Session["UsuarioId"] != null)
            {
                int idUsuario = (int)Session["UsuarioId"];
                GastoNegocio gastoNegocio = new GastoNegocio();
                List<Grupo> grupos = gastoNegocio.listarGruposPorUsuario(idUsuario);


                if (grupos.Count > 0)
                {
                    ddlGrupos.DataSource = grupos;
                    ddlGrupos.DataValueField = "IdGrupo";
                    ddlGrupos.DataTextField = "NombreGrupo";
                    ddlGrupos.DataBind();
                }
                else
                {
                    Console.WriteLine("No se encontraron grupos.");
                }

                ddlGrupos.Items.Insert(0, new ListItem("Seleccione un grupo", "0"));
            }

        }

        private void CargarParticipantes()
        {
            if (Session["UsuarioId"] != null)
            {
                GastoNegocio gastoNegocio = new GastoNegocio();
                int idGrupo = Convert.ToInt32(ddlGrupos.SelectedValue);
                List<ParticipanteGasto> participantesGasto = gastoNegocio.ListarParticipantesPorGrupo(idGrupo);

                lstParticipantesGasto.Items.Clear();

                foreach (var participante in participantesGasto)
                {
                    string nombreUsuario = gastoNegocio.ObtenerNombreUsuario(participante.IdUsuario);
                    lstParticipantesGasto.Items.Add(new ListItem
                    {
                        Value = participante.IdUsuario.ToString(),
                        Text = nombreUsuario
                    });
                }
            }

        }

        protected void ddlGrupos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idGrupo = int.Parse(ddlGrupos.SelectedValue);
            GastoNegocio gastoNegocio = new GastoNegocio();
            List<ParticipanteGasto> participantes = gastoNegocio.ListarParticipantesPorGrupo(idGrupo);
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            var participantesConDatos = participantes.Select(p => new
            {
                p.IdUsuario,
                Nombre = gastoNegocio.ObtenerNombreUsuario(p.IdUsuario),
                Email = gastoNegocio.ObtenerEmailUsuario(p.IdUsuario),
                ImagenPerfil = usuarioNegocio.obtenerImagenPerfil(p.IdUsuario)
            }).ToList();



            repParticipantes.DataSource = participantesConDatos;
            repParticipantes.DataBind();
            ActualizarMontosIndividuales();
        }
        private void ActualizarMontosIndividuales()
        {
            if (decimal.TryParse(txtMontoGasto.Text, out decimal montoTotal))
            {
                int participantesSeleccionados = 0;
                foreach (RepeaterItem item in repParticipantes.Items)
                {
                    CheckBox chkParticipante = (CheckBox)item.FindControl("chkParticipante");
                    if (chkParticipante != null && chkParticipante.Checked)
                    {
                        participantesSeleccionados++;
                    }
                }

                if (participantesSeleccionados > 0 && rblDivision.SelectedValue == "1") // Equitativa
                {
                    decimal montoIndividual = montoTotal / participantesSeleccionados;
                    foreach (RepeaterItem item in repParticipantes.Items)
                    {
                        CheckBox chkParticipante = (CheckBox)item.FindControl("chkParticipante");
                        Label lblMontoIndividual = (Label)item.FindControl("lblMontoIndividual");
                        if (lblMontoIndividual != null)
                        {
                            if (chkParticipante != null && chkParticipante.Checked)
                            {
                                lblMontoIndividual.Text = montoIndividual.ToString();

                            }
                            else
                            {
                                lblMontoIndividual.Text = "0";

                            }
                        }
                    }
                }
                else if (participantesSeleccionados > 0 && rblDivision.SelectedValue == "3")
                {
                    int totalPorcentaje = 0;
                    foreach (RepeaterItem item in repParticipantes.Items)
                    {
                        TextBox txtPorcentaje = (TextBox)item.FindControl("txtPorcentaje");
                        if (txtPorcentaje != null)
                        {
                            int.TryParse(txtPorcentaje.Text, out int porcentaje);
                            totalPorcentaje += porcentaje;
                        }
                    }
                    if (totalPorcentaje > 0)
                    {

                        foreach (RepeaterItem item in repParticipantes.Items)
                        {
                            TextBox txtPorcentaje = (TextBox)item.FindControl("txtPorcentaje");
                            Label lblMontoIndividual = (Label)item.FindControl("lblMontoIndividual");
                            CheckBox chkParticipante = (CheckBox)item.FindControl("chkParticipante");
                            if (int.TryParse(txtPorcentaje.Text, out int porcentaje))
                            {

                                decimal montoIndividual = (decimal)(montoTotal * porcentaje / 100);
                                lblMontoIndividual.Text = montoIndividual.ToString();
                            }
                            else
                            {
                                lblMontoIndividual.Text = "0";
                            }
                        }
                    }


                }
                else if (participantesSeleccionados > 0 && rblDivision.SelectedValue == "2")
                {
                    float montoAsignado = 0;
                    foreach (RepeaterItem item in repParticipantes.Items)
                    {
                        TextBox txtMontoExacto = (TextBox)item.FindControl("txtMontoExacto");
                        Label lblMontoIndividual = (Label)item.FindControl("lblMontoIndividual");
                        CheckBox chkParticipante = (CheckBox)item.FindControl("chkParticipante");

                        if (txtMontoExacto != null)
                        {
                            float.TryParse(txtMontoExacto.Text, out float montoExacto);
                            montoAsignado += montoExacto;
                            lblMontoIndividual.Text = montoExacto.ToString();
                        }
                        else
                        {
                            lblMontoIndividual.Text = "0";

                        }
                    }
                }

            }

        }
        private void mostrarCamposAdicionales()
        {
            foreach (RepeaterItem item in repParticipantes.Items)
            {
                Panel pnlMontosExactos = (Panel)item.FindControl("pnlMontosExactos");
                Panel pnlPorcentaje = (Panel)item.FindControl("pnlPorcentaje");
                Label lblMontoIndividual = (Label)item.FindControl("lblMontoIndividual");

                int metodoDivision = int.Parse(rblDivision.SelectedValue);

                pnlMontosExactos.Visible = metodoDivision == 2;
                pnlPorcentaje.Visible = metodoDivision == 3;
                if (lblMontoIndividual != null)
                {
                lblMontoIndividual.Visible = true; 

                }
            }

        }
        protected void rblDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            mostrarCamposAdicionales();
            ActualizarMontosIndividuales();

        }
        protected void chkParticipante_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarMontosIndividuales();
        }
        protected void txtMontoGasto_TextChanged(object sender, EventArgs e)
        {
            ActualizarMontosIndividuales();
        }
        protected void txtPorcentaje_TextChanged(object sender, EventArgs e)
        {
            ActualizarMontosIndividuales();
        }

        protected void txtMontoExacto_TextChanged(object sender, EventArgs e)
        {
            ActualizarMontosIndividuales();
        }

        private void setearFechaDeHoy()
        { 
            txtFechaGasto.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

    }
}