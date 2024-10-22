<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TpFinal_WebForms_20B_GestorGastos.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Iniciar sesión</h2>

    <div class="mb-3">
        <label for="txtEmail" class="form-label">Email</label>
        <input type="email" class="form-control" id="txtEmail" placeholder="name@example.com">
    </div>
    <div class="mb-3">
        <label for="txtPass" class="form-label">Contraseña</label>
        <input type="password" id="txtPass" class="form-control" aria-describedby="passwordHelpBlock">
    </div>

    <asp:Button ID="btnIngresar" Text="Ingresar" CssClass="btn btn-secondary" OnClick="btnIngresar_Click" runat="server" />
    <asp:Button ID="btnOlvidePass" Text="Olvidé contraseña" CssClass="btn btn-secondary" OnClick="btnOlvidePass_Click" runat="server" />
</asp:Content>
