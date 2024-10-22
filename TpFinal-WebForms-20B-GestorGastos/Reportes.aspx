<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="TpFinal_WebForms_20B_GestorGastos.Reportes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row justify-content-center">
            <div class="col-12 col-md-6 text-center">
                <h1>Listado de Gastos</h1>
                <div class="row row-cols-1 row-cols-md-3 g-4">
                    <asp:Repeater runat="server" ID="repRepetidor">
                        <ItemTemplate>
                            <div class="col">
                                <div class="card">
                                    <img src="https://cdn-icons-png.flaticon.com/128/11989/11989322.png" class="card-img-top d-block mx-auto" alt="img-gasto" style="height: 100px; width: 100px;">
                                    <div class="card-body">
                                        <h5 class="card-title"><%#Eval("Concepto")%></h5>
                                        <p class="card-text"><%#Eval("Fecha")%></p>
                                        <p class="card-text">$<%#Eval("Monto")%></p>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <%--<p>Comenzá a gestionar tus cuentas ingresando un nuevo gasto</p>

                <div class="mb-3">
                    <div class="form-group">
                        <label for="txtGasto" class="form-label">Ingresa tu gasto</label>
                        <asp:TextBox CssClass="form-control" ID="txtGasto" aria-describedby="codigoHelp" runat="server" />                       
                        <asp:Label ID="lblError" runat="server" CssClass="text-danger" ForeColor="Red" Visible="false"></asp:Label>
                    </div>
                </div>

                <asp:Button ID="btnAgregar" Text="Agregar" CssClass="btn btn-secondary" OnClick="btnAgregar_Click" runat="server" />--%>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
