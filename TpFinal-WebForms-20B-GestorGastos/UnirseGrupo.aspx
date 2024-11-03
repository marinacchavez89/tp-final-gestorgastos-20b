<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="UnirseGrupo.aspx.cs" Inherits="TpFinal_WebForms_20B_GestorGastos.UnirseGrupo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
        <h2>Unirse a un Grupo Existente</h2>
        <div class="form-group" Style="margin-top: 15px;">
            <label for="txtCodigoInvitacion">Para unirse a un grupo debe tener un código de invitación en la casilla de correo ingresada.</label>
            <asp:TextBox ID="txtCodigoInvitacion" runat="server" CssClass="form-control" placeholder="Ingrese el código de invitación" Style="margin-top: 15px;"></asp:TextBox>
        </div>
        <asp:Button ID="btnUnirseGrupo" runat="server" CssClass="btn btn-secondary" OnClick="btnUnirseGrupo_Click" Text="Unirse al Grupo" Style="margin-top: 15px;"/>
        <asp:Button ID="btnVolver" runat="server" CssClass="btn btn-secondary" Text="Volver" OnClick="btnVolver_Click" Style="margin-top: 15px;"/>
    </div>
</asp:Content>
