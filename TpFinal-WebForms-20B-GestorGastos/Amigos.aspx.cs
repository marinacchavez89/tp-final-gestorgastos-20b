using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace TpFinal_WebForms_20B_GestorGastos
{
    public partial class Amigos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarGrupos();
                CargarParticipantes();
            }
        }

        protected void ddlGrupos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idGrupo = int.Parse(ddlGrupos.SelectedValue);
            if(idGrupo !=0)
            {
                btnAgregarParticipante.Visible = true;
            }
            else
            {
                btnAgregarParticipante.Visible = false;
            }
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

        private void CargarGrupos()
        {
            GastoNegocio gastoNegocio = new GastoNegocio();
            List<Grupo> grupos = gastoNegocio.ListarGrupos();


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
       
    }
}