<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="RecuperarContraseña.aspx.cs" Inherits="TpFinal_WebForms_20B_GestorGastos.RecuperarContraseña" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h2>Recuperar Contraseña</h2>

<div class="form-group">
    <label for="txtEmail" class="form-label">Ingrese su correo electronico</label>
    <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" placeholder="Ingrese su correo electronico"></asp:TextBox>
</div>

<div class="form-group">
    <asp:Button ID="btnRecuperar" Text="Recuperar" CssClass="btn btn-secondary" runat="server" OnClick="btnRecuperar_Click"></asp:Button>
    <asp:Label ID="lblMensaje" runat="server" Text="Label" Visible="false"></asp:Label>
    </div>

</asp:Content>
