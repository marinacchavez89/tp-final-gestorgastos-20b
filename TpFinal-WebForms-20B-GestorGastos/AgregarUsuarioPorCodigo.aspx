<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AgregarUsuarioPorCodigo.aspx.cs" Inherits="TpFinal_WebForms_20B_GestorGastos.AgregarUsuarioPorCodigo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Ingrese los datos del amigo a invitar:</h2>

    <div class="mb-3">
        <label for="txtEmail" class="form-label">Email</label>
        <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" ReadOnly ="true"/>
    </div>

    <div class="mb-3">
        <label for="txtNombre" class="form-label">Nombre</label>
        <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server" />
    </div>

    <div class="mb-3">
        <label for="txtPass" class="form-label">Código de Invitación: </label>
        <asp:TextBox ID="txtPass" CssClass="form-control" runat="server" ReadOnly="true" />
    </div>

    <div class="mb-3">
        <asp:Label ID="lblError" CssClass="text-danger" runat="server" Visible="false"></asp:Label>
    </div>

    <asp:Button ID="btnAceptar" Text="Aceptar" CssClass="btn btn-secondary" OnClick="btnAceptar_Click" runat="server" />
</asp:Content>
