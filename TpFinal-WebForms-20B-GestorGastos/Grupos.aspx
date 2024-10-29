<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Grupos.aspx.cs" Inherits="TpFinal_WebForms_20B_GestorGastos.Grupos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Gestión de Grupos</h2>
    
    <div class="row mt-4 text-center">

        <div class="col-md-6 mb-4">
            <img src="/Images/logoGrupo.png" alt="Unirse a un Grupo" class="img-fluid rounded mb-3"
                style="width: 75%; max-width: 300px; height: auto;" />
            <asp:Button ID="btnUnirseGrupo" runat="server" CssClass="btn btn-secondary d-block mx-auto"
                Text="Unirse a grupo" OnClick="btnUnirseGrupo_Click" />
        </div>

        <div class="col-md-6 mb-4">
            <img src="/Images/logoAgregarGrupo.png" alt="Crear un Grupo" class="img-fluid rounded mb-3"
                style="width: 75%; max-width: 300px; height: auto;" />
            <asp:Button ID="btnCrearGrupo" runat="server" CssClass="btn btn-secondary d-block mx-auto"
                Text="Crear Grupo" OnClick="btnCrearGrupo_Click" />
        </div>
    </div>

</asp:Content>
