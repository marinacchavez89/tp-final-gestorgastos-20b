<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="CrearGrupo.aspx.cs" Inherits="TpFinal_WebForms_20B_GestorGastos.CrearGrupo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
<h2>Crear Nuevo GRupo</h2>
    <div class="form-group">
        <label for="txtNombreGrupo">Nombre del Grupo</label>
        <asp:TextBox ID="txtNombreGrupo" runat="server" CssClass="form-group"></asp:TextBox>
    </div>
   <!-- <asp:Button ID="btnGuardarGrupo" runat="server" CssClass="btn btn-succes" Text="Grabar" />-->

</div>
</asp:Content>