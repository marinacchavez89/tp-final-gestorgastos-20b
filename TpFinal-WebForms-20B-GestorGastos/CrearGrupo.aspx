<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="CrearGrupo.aspx.cs" Inherits="TpFinal_WebForms_20B_GestorGastos.CrearGrupo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container">

<h2>Crear nuevo Grupo</h2>

    <div class="form-group">
        <label for="txtNombreGrupo" Style="margin-top: 15px;">Ingrese el nombre del Grupo</label>
        <asp:TextBox ID="txtNombreGrupo" runat="server" CssClass="form-control"  Style="margin-top: 15px;"></asp:TextBox>
    </div>

    <asp:Button ID="btnGuardarGrupo" runat="server" CssClass="btn btn-secondary" Text="Aceptar" Style="margin-top: 15px;" />
    <asp:Button ID="btnVolver" runat="server" CssClass="btn btn-secondary" Text="Volver" OnClick="btnVolver_Click" Style="margin-top: 15px;"/>

</div>
</asp:Content>