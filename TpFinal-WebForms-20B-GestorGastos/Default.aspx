<%@ Page Title="Listado de Gastos" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TpFinal_WebForms_20B_GestorGastos.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row justify-content-center">
            <div class="col-12 col-md-6 text-center">
                <h1>Listado de Gastos</h1>
                <h5 id="lblNoHayGastos" visible="false" runat="server">¡Usted no posee gastos, agregue uno para comenzar!</h5>
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
                                            <%--<button class="btn btn-danger me-2" onclick="quitarParticipante(<%# Eval("IdGasto") %>)" style="border: none; background: none; padding: 0;">
                                                <img src="/Images/logoEliminar.png" alt="Eliminar Gasto" title="Eliminar Gasto"style="width: 50px; height: 45px;" />
                                            </button>
                                            <button class="btn btn-secondary" onclick="modificarParticipante(<%# Eval("IdGasto") %>)" style="border: none; background: none; padding: 0;">
                                                <img src="/Images/logoEditar.png" alt="Modificar Gasto" title="Modificar Gasto" style="width: 30px; height: 30px;" />
                                            </button>--%>
                                            <asp:ImageButton ID="btnEliminarGasto" CssClass="btn btn-danger me-2" runat="server"
                                                OnClick="btnEliminarGasto_Click" AutoPostBack="true" CommandArgument='<%# Eval("IdGasto") %>'
                                                ImageUrl="/Images/logoEliminar.png" AlternateText="Eliminar Gasto" ToolTip="Eliminar Gasto"
                                                Style="width: 50px; height: 45px; border: none; background: none; padding: 0;" />
                                            <asp:ImageButton ID="btnModificarGasto" ImageUrl="/Images/logoEditar.png" AutoPostBack="true" CommandArgument='<%# Eval("IdGasto") %>'
                                                AlternateText="Modificar Gasto" OnClick="btnModificarGasto_Click" ToolTip="Modificar Gasto" runat="server" CssClass="btn btn-secondary"
                                                Style="width: 45px; height: 40px; border: none; background: none; padding: 0;" />
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
