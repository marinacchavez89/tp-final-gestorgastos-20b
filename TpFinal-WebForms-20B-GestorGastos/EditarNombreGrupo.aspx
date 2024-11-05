<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="EditarNombreGrupo.aspx.cs" Inherits="TpFinal_WebForms_20B_GestorGastos.EditarNombreGrupo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Editar Nombre del Grupo</h2>
    <div style="margin-top: 20px;">
        <asp:TextBox ID="txtNombreGrupo" CssClass="form-control" runat="server" Placeholder="Ingrese el nuevo nombre del grupo..."></asp:TextBox>        
    </div>

    <div style="margin-top: 20px;">
        <asp:Button ID="btnGuardar" Text="Guardar" CssClass="btn btn-secondary" runat="server" OnClick="btnGuardar_Click"></asp:Button>
    </div>
</asp:Content>
