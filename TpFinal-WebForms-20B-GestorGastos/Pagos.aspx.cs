using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClosedXML.Excel;
using System.IO;

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
            ParticipanteGastoNegocio participanteGastoNegocio = new ParticipanteGastoNegocio();
            int usuarioId = (int)Session["UsuarioId"];
            List<Gasto> gastos = gastoNegocio.listarGastosPorGrupo(idGrupo);

            foreach (Gasto gasto in gastos)
            {
                List<ParticipanteGasto> participantes = participanteGastoNegocio.listarParticipantesConEstadoPago(gasto.IdGasto);
                ParticipanteGasto miParticipante = participantes.Find(x => x.IdUsuario == usuarioId);

                if (miParticipante != null)
                {
                    gasto.Descripcion += $" - Estado: {miParticipante.EstadoDeuda}";
                }
                else
                {
                    gasto.Descripcion += "- Estado: No participas";

                }
            }

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
                Session.Add("idGastoSeleccionado", idGasto);
                cargarDetalleGasto(idGasto);
                cargarParticipantesConEstadoDePago(idGasto);
                cargarDropdownParticipantes(idGasto);
            }
            else
            {
                // error generico (no deberia pasar)
            }
        }

        private void cargarParticipantesConEstadoDePago(int idGasto)
        {
            ParticipanteGastoNegocio participanteGastoNegocio = new ParticipanteGastoNegocio();
            List<ParticipanteGasto> participantes = participanteGastoNegocio.listarParticipantesConEstadoPago(idGasto);

            repPagosParticipantes.DataSource = participantes;
            repPagosParticipantes.DataBind();

        }

        protected void btnIniciarPagos_Click(object sender, EventArgs e)
        {
            lblParticipantes.Visible = true;            
            ddlParticipantes.Visible = true;            
        }

        protected void ddlParticipantes_SelectedIndexChanged(object sender, EventArgs e)
        {
            ParticipanteGastoNegocio participanteNegocio = new ParticipanteGastoNegocio();   
            int idGastoSeleccionado = (int)Session["idGastoSeleccionado"];           
            cargarTxtParticipantesFiltrados(idGastoSeleccionado);
            lblParticipantesFiltrado.Visible = true;
            txtParticipanteFiltrado.Visible = true;
            lblImporteAPagar.Visible = true;
            txtIngresarImporteAPagar.Visible = true;
            btnConfirmarPago.Visible = true;

        }

        private void cargarDropdownParticipantes(int idGasto)
        {
            ParticipanteGastoNegocio participanteGastoNegocio = new ParticipanteGastoNegocio();            
            List<ParticipanteGasto> participantes = participanteGastoNegocio.listarParticipantesConEstadoPago(idGasto);
            Usuario usuario = new Usuario();
            int idUsuarioCreador = participanteGastoNegocio.obtenerUsuarioCreadorPorIdGasto(idGasto).IdUsuario;
            // Filtrar la lista sin user creador del gasto.
            List<ParticipanteGasto> participantesFiltrados = participantes
               .Where(p => p.IdUsuario != idUsuarioCreador)
               .ToList();
            
            ddlParticipantes.DataSource = participantesFiltrados;
            ddlParticipantes.DataValueField = "IdUsuario";
            ddlParticipantes.DataTextField = "NombreUsuario";
            ddlParticipantes.DataBind();
            
            ddlParticipantes.Items.Insert(0, new ListItem("Selecciona un participante", "0"));
        }   

        private void cargarTxtParticipantesFiltrados(int idGasto)
        {
            ParticipanteGastoNegocio participanteGastoNegocio = new ParticipanteGastoNegocio();
            Usuario usuario = new Usuario();
            usuario = participanteGastoNegocio.obtenerUsuarioCreadorPorIdGasto(idGasto);

            txtParticipanteFiltrado.Text = usuario.Nombre.ToString();
            
        }

        protected void btnConfirmarPago_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtIngresarImporteAPagar.Text,
                          System.Globalization.NumberStyles.AllowDecimalPoint,
                          System.Globalization.CultureInfo.CurrentCulture,
                          out decimal importeAPagar))
            {
                if (importeAPagar > 0)
                {
                    int idGastoSeleccionado = (int)Session["idGastoSeleccionado"];
                    int idUsuarioSeleccionado = int.Parse(ddlParticipantes.SelectedValue);
                    Pago pago = new Pago
                    {
                        IdGasto = idGastoSeleccionado,
                        IdUsuario = idUsuarioSeleccionado,
                        MontoPagado = importeAPagar,
                        FechaPago = DateTime.Now,
                    };
                    PagoNegocio pagoNegocio = new PagoNegocio();
                    pagoNegocio.AgregarPago(pago);
                    lblErrorImporteAPagar.Text = "Pago registrado con exito...";
                    lblErrorImporteAPagar.ForeColor = System.Drawing.Color.Green;
                    lblErrorImporteAPagar.Visible = true;

                    cargarParticipantesConEstadoDePago(idGastoSeleccionado);
                    // Acá debemos hacer la lógica de saldar deuda.
                }
                else
                {
                    lblErrorImporteAPagar.Text = "El importe debe ser mayor a 0.";
                    lblErrorImporteAPagar.Visible = true;
                }
            }
            else
            {
                lblErrorImporteAPagar.Text = "Debe ingresar un número válido.";
                lblErrorImporteAPagar.Visible = true;
            }

        }

        protected void btnExportarExcel_Click(object sender, EventArgs e)
        {
            // Crear un nuevo libro de Excel
            using (var workbook = new XLWorkbook())
            {
                // Crear una hoja de trabajo
                var worksheet = workbook.Worksheets.Add("Participantes Pagos");

                // Agregar cabeceras a la hoja de trabajo
                worksheet.Cell(1, 1).Value = "Nombre Usuario";
                worksheet.Cell(1, 2).Value = "Nombre Usuario";
                worksheet.Cell(1, 3).Value = "Estado Deuda";
                worksheet.Cell(1, 4).Value = "Monto Individual"; 
                worksheet.Cell(1, 5).Value = "Monto Pagado";
                worksheet.Cell(1, 6).Value = "Deuda Pendiente";

                // Obtener la lista de participantes con estado de pago.
                ParticipanteGastoNegocio participanteGastoNegocio = new ParticipanteGastoNegocio();
                int idGastoSeleccionado = (int)Session["idGastoSeleccionado"];
                List<ParticipanteGasto> participantes = participanteGastoNegocio.listarParticipantesConEstadoPago(idGastoSeleccionado);

                // Agregar los datos de los participantes
                int row = 2; // Comienza desde la fila 2, ya que en la primera estan los encabezados.
                foreach (var participante in participantes)
                {
                    worksheet.Cell(row, 1).Value = participante.NombreUsuario;
                    worksheet.Cell(row, 2).Value = participante.EmailUsuario;
                    worksheet.Cell(row, 3).Value = participante.EstadoDeuda;
                    worksheet.Cell(row, 4).Value = participante.MontoIndividual;
                    worksheet.Cell(row, 5).Value = participante.MontoPagado;
                    worksheet.Cell(row, 6).Value = participante.DeudaPendiente;
                    row++;
                }

                // Configurar la respuesta HTTP para la descarga del archivo Excel
                Response.Clear();
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("Content-Disposition", "attachment;filename=Participantes_Pagos.xlsx");

                // Escribir el archivo Excel en la respuesta HTTP
                using (var memoryStream = new MemoryStream())
                {
                    workbook.SaveAs(memoryStream);
                    memoryStream.WriteTo(Response.OutputStream);
                    Response.End();
                }
            }
        }
    }
}