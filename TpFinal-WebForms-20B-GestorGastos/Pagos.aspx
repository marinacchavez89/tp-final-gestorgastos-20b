<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Pagos.aspx.cs" Inherits="TpFinal_WebForms_20B_GestorGastos.Pagos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container mt-5">
        <h2 class="text-center">Detalle del Gasto</h2>

        <!-- Tabla de Detalle del Gasto -->
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
                            <td><asp:Label ID="lblDescripcion" runat="server" /></td>
                            <td><asp:Label ID="lblFechaGasto" runat="server" /></td>
                            <td><asp:Label ID="lblMontoTotal" runat="server" /></td>
                            <td><asp:Label ID="lblGrupo" runat="server" /></td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>

        <!-- Tabla de Participantes -->
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
                                <tr>
                                    <td><%# Eval("Nombre") %></td>
                                    <td><%# Eval("Email") %></td>
                                    <td>$<%# Eval("MontoIndividual") %></td>
                                    <td>
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
