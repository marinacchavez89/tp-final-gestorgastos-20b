<%@ Page Title="Gastos" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Gastos.aspx.cs" Inherits="TpFinal_WebForms_20B_GestorGastos.Gastos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2>Gestión de Gastos</h2>
        <p>Comenzá a gestionar tus cuentas ingresando un nuevo gasto</p>

        <div class="mb-3">
            <label for="fechaGasto" class="form-label">Fecha</label>
            <asp:TextBox ID="txtFechaGasto" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="mb-3">
            <label for="conceptoGasto" class="form-label">Descripción del Gasto</label>
            <asp:TextBox ID="txtConceptoGasto" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="mb-3">
            <label for="montoGasto" class="form-label">Monto Total</label>
            <asp:TextBox ID="txtMontoGasto" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
        </div>

        <label for="idGrupo" class="form-label">Grupo</label>
        <asp:DropDownList ID="ddlGrupos" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlGrupos_SelectedIndexChanged">
        </asp:DropDownList>

        <!--<asp:ListBox ID="lstParticipantesGasto" runat="server" SelectionMode="Multiple" CssClass="form-control">          
        </asp:ListBox>-->

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
                                            <h5 class="card-title"><%# Eval("Nombre") %></h5>
                                            <p class="card-text"><%# Eval("Email") %></p>
                                            <button class="btn btn-danger" onclick="quitarParticipante(<%# Eval("IdUsuario") %>)" style="border: none; background: none; padding: 0;">
                                                <img src="/Images/logoEliminar.png" alt="Eliminar" style="width: 50px; height: 45px;" />
                                            </button>
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
</asp:Content>
