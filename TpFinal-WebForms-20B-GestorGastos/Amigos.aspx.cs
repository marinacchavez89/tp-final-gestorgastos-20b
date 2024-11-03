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
                lblCodigoInvitacion.Visible = false;
                txtCodigoInvitacion.Visible = false;
            }
        }

        protected void ddlGrupos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idGrupo = int.Parse(ddlGrupos.SelectedValue);
            Session.Add("idGrupo", idGrupo);
            lblCodigoInvitacion.Visible = true;
            txtCodigoInvitacion.Visible = true;
            txtCodigoInvitacion.Text = (string)obtenerCodigoInvitacionGrupo();
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

        protected void btnAgregarParticipante_Click(object sender, EventArgs e)
        {   
            txtEmailParticipante.Visible = true;
            btnGuardar.Visible = true;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string email = txtEmailParticipante.Text;
            int idGrupo = int.Parse(ddlGrupos.SelectedValue);

            if (string.IsNullOrWhiteSpace(email))
            {
                lblMensaje.Text = "Por favor, ingrese un email.";
                lblMensaje.Visible = true;
                return;
            }

            GastoNegocio gastoNegocio = new GastoNegocio();

            // Buscar el usuario por email
            int? idUsuario = gastoNegocio.ObtenerIdUsuarioPorEmail(email);

            if (idUsuario == null)
            {
                lblMensaje.Text = "El usuario con el email especificado no existe.";
                lblMensaje.Visible = true;
                return;
            }

            // Intentar agregar al usuario al grupo
            bool agregado = gastoNegocio.AgregarParticipanteAGrupo(idGrupo, idUsuario.Value);

            if (agregado)
            {
                lblMensaje.Text = "";
                lblMensaje.Visible = false;
            }
            else
            {
                lblMensaje.Text = "El participante ya es miembro del grupo.";
                lblMensaje.Visible = true;
            }

            CargarParticipantes();
            ddlGrupos_SelectedIndexChanged(null, null);
            txtEmailParticipante.Text = string.Empty;
        }

        protected void btnEliminarParticianteGrupo_Click(object sender, EventArgs e)
        {
            // Obtener el id del usuario a eliminar desde CommandArgument
            LinkButton btnEliminar = (LinkButton)sender;
            int idUsuario = int.Parse(btnEliminar.CommandArgument);
            int idGrupo = int.Parse(ddlGrupos.SelectedValue);

            GastoNegocio gastoNegocio = new GastoNegocio();
            bool eliminado = gastoNegocio.EliminarParticipanteDeGrupo(idGrupo, idUsuario);
           
            if (eliminado)
            {
                lblMensaje.Text = "";
                lblMensaje.Visible = false;
            }
            else
            {
                lblMensaje.Text = "No se pudo eliminar al participante.";
                lblMensaje.Visible = true;
            }

            // Refrescar la lista de participantes
            CargarParticipantes();
            ddlGrupos_SelectedIndexChanged(null, null);
        }

        private string obtenerCodigoInvitacionGrupo()
        {
            GrupoNegocio negocio = new GrupoNegocio();
            int idGrupo = (int)Session["idGrupo"];

            return negocio.obtenerCodigoInvitacion(idGrupo);
        }
    }
}