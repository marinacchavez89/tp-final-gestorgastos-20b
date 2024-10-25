<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Exito.aspx.cs" Inherits="TpFinal_WebForms_20B_GestorGastos.Exito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .success-container {
            margin-top: 50px;
            text-align: center;
        }

        .success-icon {
            font-size: 100px;
            color: #28a745;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container success-container">
        <img src="/Images/logoExito.png" alt="Éxito" class="success-image" style="width: 100px; height: 100px;" />
        <h2>¡Éxito!</h2>
        <p>La operación se ha realizado correctamente.</p>
        <a href="Default.aspx" class="btn btn-secondary">Home</a>
    </div>
</asp:Content>
