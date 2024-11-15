<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Pagos.aspx.cs" Inherits="TpFinal_WebForms_20B_GestorGastos.Pagos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <h2>Pagos</h2>
        <div class="mb-3">
            <label for="ddlGrupos" class="form-label">Selecciona un Grupo</label>
            <asp:DropDownList ID="ddlGrupos" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlGrupos_SelectedIndexChanged">
            </asp:DropDownList>
        </div>

        <h2 class="text-center">Detalle del Gasto</h2>

        <!-- tabla de detalle del gasto con el idGastoGenerado invocamos los campos
            sin la posibilidad de modificarlos -->
        <div class="card mb-4">
            <div class="card-body">
                <table class="table table-striped">
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
                            <th>Pago Confirmado</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="repPagosParticipantes" runat="server">
                            <ItemTemplate>
                                <!-- <tr> aca va a ir la logica del idGastoGenerado
                                   1.- idGastoGenerado
                                   2.- idGrupo
                                   3.- idPago

                                    <td><%# Eval("Nombre") %></td>
                                    <td><%# Eval("Email") %></td>
                                    <td>$<%# Eval("MontoIndividual") %></td>
                                    <td>-->
                                <asp:CheckBox ID="chkPagoConfirmado" runat="server" />
                                </td>
                                </tr>
                           
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
        </div>

        <div class="text-center mt-4">
            <asp:Button ID="btnConfirmarPagos" runat="server" CssClass="btn btn-secondary" Text="Confirmar Pagos" />
        </div>
    </div>



</asp:Content>
