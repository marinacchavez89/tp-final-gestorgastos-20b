<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Pagos.aspx.cs" Inherits="TpFinal_WebForms_20B_GestorGastos.Pagos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <h2>Grupos</h2>
        <div class="mb-3">
            <label for="ddlGrupos" class="form-label">Selecciona un Grupo</label>
            <asp:DropDownList ID="ddlGrupos" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlGrupos_SelectedIndexChanged">
            </asp:DropDownList>
        </div>

        <div id="gastosContainer" runat="server" visible="false">
            <h3>Eventos</h3>
            <asp:Repeater ID="repGastos" runat="server" OnItemCommand="repGastos_ItemCommand">
                <ItemTemplate>
                    <div class="card mb-3">
                        <div class="card-body">
                            <h5 class="card-title"><%# Eval("Descripcion") %></h5>
                            <p class="card-text">Monto: <%# Eval("MontoTotal") %></p>
                            <p class="card-text">Fecha: <%# Eval("FechaGasto", "{0:dd/MM/yyyy}") %></p>
                            <asp:Button ID="btnSeleccionarGasto" runat="server" CommandName="SeleccionarGasto" CommandArgument='<%# Eval("IdGasto") %>' Text="Seleccionar" CssClass="btn btn-secondary" />
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>


        <h2 class="text-center">Detalle del Evento</h2>


        <div id="detalleGastoContainer" runat="server" visible="false" class="mt-4">
            <h3>Detalle del Gasto</h3>
            <table class="table table-bordered">
                <thead>
                    <tr>
                        <th>Descripción</th>
                        <th>Fecha</th>
                        <th>Monto Total</th>
                        <th>Grupo</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>
                            <asp:Label ID="lblDescripcion" runat="server" /></td>
                        <td>
                            <asp:Label ID="lblFechaGasto" runat="server" /></td>
                        <td>
                            <asp:Label ID="lblMontoTotal" runat="server" /></td>
                        <td>
                            <asp:Label ID="lblGrupo" runat="server" /></td>
                    </tr>
                </tbody>
            </table>
        </div>


        <!-- tabla de participantes. vamos a llamar al mismo repeater -->
        <h3 class="text-center">Participantes y Pagos</h3>
        <div class="card">
            <div class="card-body">
                <table class="table table-bordered">
                    <thead>
                        <tr>
                            <th>Participante</th>
                            <th>Email</th>
                            <th>Monto Individual</th>
                            <th>Monto Pagado</th>
                            <th>Saldo</th>
                            <th>Editar Pago</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="repPagosParticipantes" runat="server" OnItemDataBound="repPagosParticipantes_ItemDataBound">
                            <ItemTemplate>
                                <tr>
                                    <td><%# Eval("NombreUsuario") %></td>
                                    <td><%# Eval("EmailUsuario") %></td>
                                    <td>$<%# Eval("MontoIndividual") %></td>
                                    <td>$<%# Eval("MontoPagado") %></td>
                                    <td>
                                        <asp:Label ID="lblSaldo" runat="server" Text='<%# "$" + Eval("DeudaPendiente") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:HiddenField ID="hfMontoPagado" runat="server" Value='<%# Eval("MontoPagado") %>' />
                                        <asp:HiddenField ID="hfEmail" runat="server" Value='<%# Eval("EmailUsuario") %>' />
                                        <asp:ImageButton ID="btnModificarPago" ImageUrl="/Images/logoEditar.png" AutoPostBack="true" CommandArgument='<%# Eval("IdGasto") %>'
                                            AlternateText="Modificar Gasto" OnClick="btnModificarPago_Click" ToolTip="Modificar Pago" runat="server" CssClass="btn btn-secondary"
                                            Style="width: 25px; height: 20px; border: none; background: none; padding: 0;" />
                                    </td>
                                </tr>
                                <!-- hacer el eval de deuda pendiente-->
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>

            <div class="text-center mt-4" style="margin-bottom: 20px">
                <asp:Button ID="btnExportarExcel" runat="server" CssClass="btn btn-secondary" Text="Exportar a Excel" OnClick="btnExportarExcel_Click" />
                <asp:Button ID="btnIniciarPagos" runat="server" CssClass="btn btn-secondary" Text="Iniciar Pagos" OnClick="btnIniciarPagos_Click" />
            </div>

        </div>

        <div class="mb-3" style="margin-top: 20px">
            <asp:Label ID="lblParticipantes" runat="server" CssClass="form-label" Visible="false">Selecciona quien paga</asp:Label>
            <asp:DropDownList ID="ddlParticipantes" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlParticipantes_SelectedIndexChanged" Visible="false">
            </asp:DropDownList>
        </div>

        <div class="mb-3">
            <asp:Label ID="lblParticipantesFiltrado" runat="server" CssClass="form-label" Visible="false">Le abonarás al creador del gasto:</asp:Label>
            <asp:TextBox ID="txtParticipanteFiltrado" runat="server" CssClass="form-control" Visible="false" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="mb-3">
            <asp:Label ID="lblImporteAPagar" runat="server" CssClass="form-label" Visible="false">Ingresá el importe que vas a abonar</asp:Label>
            <asp:TextBox ID="txtIngresarImporteAPagar" CssClass="form-control" runat="server" Visible="false"></asp:TextBox>
            <asp:RegularExpressionValidator
                ID="regexImporteAPagar"
                runat="server"
                ControlToValidate="txtIngresarImporteAPagar"
                ErrorMessage="Debe ingresar solo números y un monto mayor a 0"
                ValidationExpression="^\d+(\.\d{1,2})?$"
                CssClass="text-danger"
                Display="Dynamic"
                Visible="false">
            </asp:RegularExpressionValidator>
            <asp:Label ID="lblErrorImporteAPagar" runat="server" CssClass="form-label" Text="Debe ingresar solo números y al ser dinero, un monto mayor a $ 0" ForeColor="Red" Visible="false"></asp:Label>
        </div>

        <div class="mb-3">
            <asp:Button ID="btnConfirmarPago" runat="server" CssClass="btn btn-secondary" Text="Pagar" Visible="false" OnClick="btnConfirmarPago_Click" />
        </div>

        <!-- Panel para editar pago -->
        <asp:Panel ID="pnlEditarPago" runat="server" Visible="false" CssClass="card border-secondary mb-3">
            <div class="card-header" style="position: relative; display: flex; justify-content: space-between; align-items: center; padding: 0.75rem 1.25rem;">
                <h5>Editar Pago</h5>
                <asp:Button ID="btnCerrarPanel" runat="server" Text="" CssClass="btn-close float-end" OnClick="btnCerrarPanel_Click" CausesValidation="false" style="position: absolute; top: 50%; right: 10px; transform: translateY(-50%);" />
            </div>
            <div class="card-body">
                <asp:HiddenField ID="hfIdGasto" runat="server" />
                <asp:HiddenField ID="hfIdUsuario" runat="server" />
                <div class="mb-3">
                    <asp:TextBox ID="txtEmail" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="txtNuevoMonto" class="form-label">Nuevo Monto</label>
                    <asp:TextBox ID="txtNuevoMonto" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="txtNuevoMonto" ErrorMessage="El monto es requerido" CssClass="text-danger" runat="server" />
                    <asp:RegularExpressionValidator ControlToValidate="txtNuevoMonto" ValidationExpression="^\d+(\.\d{1,2})?$" ErrorMessage="Ingrese un monto válido" CssClass="text-danger" runat="server" />
                </div>
                <asp:Label ID="lblErrorEdicionPago" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
                <div class="mt-3">
                    <asp:Button ID="btnGuardarEdicion" runat="server" CssClass="btn btn-secondary" Text="Guardar Cambios" OnClick="btnGuardarEdicion_Click" />
                    <asp:Button ID="btnCancelarEdicion" runat="server" CssClass="btn btn-secondary" Text="Cancelar" OnClick="btnCancelarEdicion_Click" CausesValidation="false" />
                </div>
            </div>
        </asp:Panel>

    </div>
</asp:Content>
