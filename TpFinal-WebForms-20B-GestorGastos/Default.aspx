<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TpFinal_WebForms_20B_GestorGastos.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row justify-content-center">
            <div class="col-12 col-md-6 text-center">
                <h1>¡Bienvenido/a!</h1>
                <p>Comenzá a gestionar tus cuentas ingresando un nuevo gasto</p>

                <div class="mb-3">
                    <div class="form-group">
                        <label for="txtGasto" class="form-label">Ingresa tu gasto</label>
                        <asp:TextBox CssClass="form-control" ID="txtGasto" aria-describedby="codigoHelp" runat="server" />                       
                        <asp:Label ID="lblError" runat="server" CssClass="text-danger" ForeColor="Red" Visible="false"></asp:Label>
                    </div>
                </div>

                <asp:Button ID="btnAgregar" Text="Agregar" CssClass="btn btn-secondary" OnClick="btnAgregar_Click" runat="server" />
            </div>
        </div>
    </div>

</asp:Content>
