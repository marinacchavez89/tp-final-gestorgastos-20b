<%@ Page Title="Gastos" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Gastos.aspx.cs" Inherits="TpFinal_WebForms_20B_GestorGastos.Gastos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>


            <div class="container">
                <h2>Gestión de Gastos</h2>
                <p>Comenzá a gestionar tus cuentas ingresando un nuevo gasto</p>

                <div class="mb-3">
                    <label for="fechaGasto" class="form-label">Fecha</label>
                    <asp:TextBox ID="txtFechaGasto" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                    <asp:Label ID="lblErrorFecha" Text="Debe seleccionar una fecha válida" Visible="false" ForeColor="Red" runat="server" />
                </div>

                <div class="mb-3">
                    <label for="conceptoGasto" class="form-label">Descripción del Gasto</label>
                    <asp:TextBox ID="txtConceptoGasto" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:Label ID="lblErrorConceptoGasto" Text="El campo descripción no puede estar vacío." Visible="false" ForeColor="Red" runat="server" />
                </div>

                <div class="mb-3">
                    <label for="montoGasto" class="form-label">Monto Total</label>
                    <asp:TextBox ID="txtMontoGasto" runat="server" CssClass="form-control" TextMode="Number" AutoPostBack="true" OnTextChanged="txtMontoGasto_TextChanged"></asp:TextBox>
                    <asp:Label ID="lblErrorMontoGasto" Text="El monto del gasto debe ser mayor a cero." Visible="false" ForeColor="Red" runat="server" />
                </div>

                <label for="idGrupo" class="form-label">Grupo</label>
                <asp:DropDownList ID="ddlGrupos" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlGrupos_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:Label ID="lblErrorddlGrupos" Text="Debe seleccionar un grupo para continuar." Visible="false" ForeColor="Red" runat="server" />

                <!--<asp:ListBox ID="lstParticipantesGasto" runat="server" SelectionMode="Multiple" CssClass="form-control">          
        </asp:ListBox>-->

                <div class="mb-3">
                    <label class="form-label">Método de División</label>
                    <asp:RadioButtonList ID="rblDivision" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="rblDivision_SelectedIndexChanged">
                        <asp:ListItem Text="Equitativa" Value="1" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="Montos Exactos" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Porcentaje" Value="3"></asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <div class="container">
                    <div class="row justify-content-center">
                        <div class="col-12 text-center">
                            <h5 style="margin-top: 20px;">Participantes</h5>
                            <div class="row row-cols-1 row-cols-md-3 g-4 justify-content-center">
                                <asp:Repeater runat="server" ID="repParticipantes">
                                    <ItemTemplate>
                                        <div class="col-md-3">
                                            <div class="card">
                                                <img src="/Images/logoParticipante.png" class="card-img-top d-block mx-auto" alt="img-participante" style="height: 100px; width: 100px;">
                                                <div class="card-body">
                                                    <h5 class="card-title">
                                                        <asp:CheckBox ID="chkParticipante" runat="server" Checked="true" AutoPostBack="true" OnCheckedChanged="chkParticipante_CheckedChanged" />
                                                        <%# Eval("Nombre") %>
                                            </h5>
                                                    <p class="card-text"><%# Eval("Email") %></p>

                                                    <!-- Panel Montos Exactos -->
                                                    <asp:Panel ID="pnlMontosExactos" runat="server" Visible="false">
                                                        <label class="form-label">Monto Exacto:</label>
                                                        <asp:TextBox ID="txtMontoExacto" runat="server" CssClass="form-control" TextMode="Number" AutoPostBack="true" OnTextChanged="txtMontoExacto_TextChanged"></asp:TextBox>
                                                    </asp:Panel>

                                                    <!-- Panel Porcentaje -->
                                                    <asp:Panel ID="pnlPorcentaje" runat="server" Visible="false">
                                                        <label class="form-label">% </label>
                                                        <asp:TextBox ID="txtPorcentaje" runat="server" CssClass="form-control" TextMode="Number" AutoPostBack="true" OnTextChanged="txtPorcentaje_TextChanged"></asp:TextBox>
                                                    </asp:Panel>
                                                    <p class="card-text">
                                                        Monto Calculado: $
                                                        <asp:Label ID="lblMontoIndividual" runat="server" CssClass="form-label" Text="0.00"></asp:Label>
                                                    </p>
                                                </div>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                    </div>
                </div>

                <asp:Button ID="btnAgregar" Text="Agregar" CssClass="btn btn-secondary" OnClick="btnAgregar_Click" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
