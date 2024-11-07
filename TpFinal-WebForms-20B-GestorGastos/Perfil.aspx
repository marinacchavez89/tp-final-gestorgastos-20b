<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="TpFinal_WebForms_20B_GestorGastos.Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <h2>Perfil de <%=Session["UsuarioNombre"]%></h2>
            <div class="mb-3">
                <asp:Label ID="lblCambiarPassCodInvitacion" CssClass="text-danger" runat="server" Visible="false"></asp:Label>
            </div>
            <div class="d-flex flex-row justify-content-between" style="width: 100%;">
                <div class="d-flex flex-column justify-content-around" style="width: 600px">
                    <div class="mb-3">
                        <label for="txtNombre" class="form-label" style="margin-top: 15px;">Nombre</label>
                        <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server" />
                    </div>

                    <div class="mb-3">
                        <label for="txtEmail" class="form-label" style="margin-top: 15px;">Email</label>
                        <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" placeholder="name@example.com" TextMode="Email" />
                    </div>
                </div>
                <div class="d-flex flex-column" style="width: 350px">
                    <label class="form-label" style="margin-top: 15px;">Imagen Perfil</label>
                    <asp:Image ID="imgNuevoPerfil" runat="server" CssClass="img-fluid mb-3"
                        Style="max-width: 200px; border-radius: 20px;"
                        AlternateText="Imagen de Perfil" />
                </div>
            </div>

            <div class="mb-3">
                <asp:Label ID="lblError" CssClass="text-danger" runat="server" Visible="false"></asp:Label>
            </div>

            <div class="d-flex flex-wrap mb-4">
                <asp:Repeater ID="rptImagenesPerfil" runat="server" Visible="false">
                    <ItemTemplate>
                        <div class="card" style="width: 10rem; margin: 10px; text-align: center;">
                            <img class="card-img-top" src='<%# Eval("ImageUrl") %>' alt="Imagen de perfil" />
                            <div class="card-body" style="background-color: white; padding: 10px;">
                                <asp:Button ID="btnSeleccionar" runat="server" Text="➕" CssClass="btn btn-checkmark"
                                    CommandArgument='<%# Eval("ImageUrl") %>' OnCommand="btnSeleccionar_Command" />
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>

            <div class="mt-4">
                <asp:Button ID="btnModificar" Text="Modificar" CssClass="btn btn-secondary me-2" OnClick="btnModificar_Click" runat="server" />
                <asp:Button ID="btnGuardar" Text="Guardar" CssClass="btn btn-secondary me-2" OnClick="btnGuardar_Click" runat="server" />
                <asp:Button ID="btnCancelar" Text="Cancelar" CssClass="btn btn-secondary me-2" OnClick="btnCancelar_Click" runat="server" />
                <asp:Button ID="btnModificarPass" Text="Modificar Contraseña" CssClass="btn btn-secondary me-2" OnClick="btnModificarPass_Click" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
