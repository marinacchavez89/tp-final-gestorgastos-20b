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
        <asp:DropDownList ID="ddlGrupos" runat="server" CssClass="form-control">
        </asp:DropDownList>

        <asp:ListBox ID="lstParticipantesGasto" runat="server" SelectionMode="Multiple" CssClass="form-control">          
        </asp:ListBox>

    </div>

    <asp:Button ID="btnAgregar" Text="Agregar" CssClass="btn btn-secondary" OnClick="btnAgregar_Click" runat="server" />
</asp:Content>
