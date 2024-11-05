<%@ Page Title="Listado de Gastos" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TpFinal_WebForms_20B_GestorGastos.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
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
                                    <img src="/Images/logoGasto.png" class="card-img-top d-block mx-auto" alt="img-gasto" style="height: 100px; width: 100px;">
                                    <div class="card-body">
                                        <h5 class="card-title"><%# Eval("Descripcion") %></h5>
                                        <p class="card-text"><%# ((DateTime)Eval("FechaGasto")).ToString("dd/MM/yyyy") %></p>
                                        <p class="card-text">$<%# Eval("MontoTotal") %></p>
                                        <div class="d-flex justify-content-center mt-2">
                                            <button class="btn btn-danger me-2" onclick="quitarParticipante(<%# Eval("IdGasto") %>)" style="border: none; background: none; padding: 0;">
                                                <img src="/Images/logoEliminar.png" alt="Eliminar Gasto" title="Eliminar Gasto"style="width: 50px; height: 45px;" />
                                            </button>
                                            <button class="btn btn-secondary" onclick="modificarParticipante(<%# Eval("IdGasto") %>)" style="border: none; background: none; padding: 0;">
                                                <img src="/Images/logoEditar.png" alt="Modificar Gasto" title="Modificar Gasto" style="width: 30px; height: 30px;" />
                                            </button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
