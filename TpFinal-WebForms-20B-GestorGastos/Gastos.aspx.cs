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
    public partial class Gastos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarGrupos();
                CargarParticipantes();
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Gasto nuevoGasto = new Gasto
            {
                IdGrupo = Convert.ToInt32(ddlGrupos.SelectedValue),
                Descripcion = txtConceptoGasto.Text,
                MontoTotal = Convert.ToDecimal(txtMontoGasto.Text),
                FechaGasto = Convert.ToDateTime(txtFechaGasto.Text),
                CreadoPor = 1 //Esto despues se puede asumir que es por el usuario logueado
            };

            GastoNegocio gastoNegocio = new GastoNegocio();
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

        private void CargarParticipantes()
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

        protected void ddlGrupos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idGrupo = int.Parse(ddlGrupos.SelectedValue);
            GastoNegocio gastoNegocio = new GastoNegocio();
            List<ParticipanteGasto> participantes = gastoNegocio.ListarParticipantesPorGrupo(idGrupo);

            var participantesConDatos = participantes.Select(p => new
            {
                p.IdUsuario,
                Nombre = gastoNegocio.ObtenerNombreUsuario(p.IdUsuario),
                Email = gastoNegocio.ObtenerEmailUsuario(p.IdUsuario)
            }).ToList();

            repParticipantes.DataSource = participantesConDatos;
            repParticipantes.DataBind();
        }
    }
}