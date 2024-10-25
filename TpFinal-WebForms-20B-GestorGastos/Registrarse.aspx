<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Registrarse.aspx.cs" Inherits="TpFinal_WebForms_20B_GestorGastos.Registrarse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Registrate</h2>

    <div class="mb-3">
        <label for="txtNombre" class="form-label">Nombre</label>
        <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server" />
    </div>

    <div class="mb-3">
        <label for="txtEmail" class="form-label">Email</label>
        <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" placeholder="name@example.com" TextMode="Email" />
    </div>
  
    <div class="mb-3">
        <label for="txtPass" class="form-label">Contraseña</label>
        <asp:TextBox ID="txtPass" CssClass="form-control" runat="server" TextMode="Password" />
    </div>

    <div class="mb-3">
        <asp:Label ID="lblError" CssClass="text-danger" runat="server" Visible="false"></asp:Label>
    </div>

    <asp:Button ID="btnAceptar" Text="Aceptar" CssClass="btn btn-secondary" OnClick="btnAceptar_Click" runat="server" />

</asp:Content>
