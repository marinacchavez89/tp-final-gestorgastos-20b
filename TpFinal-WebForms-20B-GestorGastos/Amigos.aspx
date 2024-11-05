<%@ Page Title="Amigos" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Amigos.aspx.cs" Inherits="TpFinal_WebForms_20B_GestorGastos.Amigos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2>Gestión de Amigos</h2>

        <label for="idGrupo" class="form-label">Seleccionar grupo</label>
        <div style="display: flex; align-items: center;">
            <asp:DropDownList ID="ddlGrupos" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlGrupos_SelectedIndexChanged" Style="width: 80%;"></asp:DropDownList>

            <asp:LinkButton ID="btnEliminarGrupoLogo" runat="server" CssClass="btn btn-danger" OnClick="btnEliminarGrupo_Click" Style="border: none; background: none; padding: 0; margin-left: 10px;">
                <img src="/Images/logoEliminar.png" alt="Eliminar Grupo" title="Eliminar Grupo" style="width: 50px; height: 45px;" />
            </asp:LinkButton>
        </div>

        <!--<asp:ListBox ID="lstParticipantesGasto" runat="server" SelectionMode="Multiple" CssClass="form-control">          
        </asp:ListBox>-->

        <div class="container">
            <div class="row justify-content-center">
                <div class="col-12 text-center">
                    <h5 id="lblParticipantes" runat="server" style="margin-top: 20px;">Participantes 
                        <asp:LinkButton ID="btnAgregarParticipante" runat="server" OnClick="btnAgregarParticipante_Click" Visible="false"
                            Style="background-color: white; color: #000;">
                        <img src="/Images/plus-solid.svg" alt="Agregar" title="Agregar Participante"  style="height: 20px; width: 20px; margin-right: 8px;" />   
                        </asp:LinkButton>
                    </h5>
                    <div class="row row-cols-1 row-cols-md-3 g-4 justify-content-center">
                        <asp:Repeater runat="server" ID="repParticipantes">
                            <ItemTemplate>
                                <div class="col-md-3">
                                    <div class="card">
                                        <img src="/Images/logoParticipante.png" class="card-img-top d-block mx-auto" alt="img-participante" style="height: 100px; width: 100px;">
                                        <div class="card-body">
                                            <h5 class="card-title"><%# Eval("Nombre") %></h5>
                                            <p class="card-text"><%# Eval("Email") %></p>
                                            <asp:LinkButton ID="btnEliminarParticianteGrupo" runat="server" CssClass="btn btn-danger" CommandArgument='<%# Eval("IdUsuario") %>' OnClick="btnEliminarParticianteGrupo_Click" Style="border: none; background: none; padding: 0;">
                                                <img src="/Images/logoEliminar.png" alt="Eliminar Participante" title="Eliminar Participante" style="width: 50px; height: 45px;" />
                                            </asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>

                    <div style="margin-top: 20px;">
                        <asp:TextBox ID="txtEmailParticipante" CssClass="form-control" runat="server" Visible="false" Placeholder="Ingrese el email del participante"></asp:TextBox>
                        <asp:Label ID="lblMensaje" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                    </div>

                    <div style="margin-top: 20px;">
                        <asp:Button ID="btnGuardar" Text="Guardar" CssClass="btn btn-secondary" runat="server" Visible="false" OnClick="btnGuardar_Click"></asp:Button>
                    </div>


                </div>
            </div>
        </div>
        <div class="mb-3">
            <%--<asp:Label ID="lblCodigoInvitacion" CssClass="form-control" runat="server" Visible="false">Código invitación grupo</asp:Label>--%>
            <label id="lblCodigoInvitacion" cssclass="form-control" runat="server" visible="false">Código invitación grupo</label>
            <div class="mb-2"></div>
            <asp:TextBox ID="txtCodigoInvitacion" CssClass="form-control" runat="server" Enabled="false" />
        </div>

    </div>
</asp:Content>
