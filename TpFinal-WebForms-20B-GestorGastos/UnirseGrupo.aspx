<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="UnirseGrupo.aspx.cs" Inherits="TpFinal_WebForms_20B_GestorGastos.UnirseGrupo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
        <h2>Unirse a un Grupo Existente</h2>
        <div class="form-group">
            <label for="txtCodigoInvitacion">Código de Invitación</label>
            <asp:TextBox ID="txtCodigoInvitacion" runat="server" CssClass="form-control" placeholder="Ingrese el código de invitación"></asp:TextBox>
        </div>
        <asp:Button ID="btnUnirseGrupo" runat="server" CssClass="btn btn-success" Text="Unirse al Grupo" />
    </div>
</asp:Content>
