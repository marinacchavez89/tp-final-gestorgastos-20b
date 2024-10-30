<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="TpFinal_WebForms_20B_GestorGastos.Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <h2>Perfil de <%=Session["UsuarioNombre"]%></h2>
            
            <div class="mb-3">
                <label for="txtNombre" class="form-label" style="margin-top: 15px;">Nombre</label>
                <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server" />
            </div>

            <div class="mb-3">
                <label for="txtEmail" class="form-label" style="margin-top: 15px;">Email</label>
                <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" placeholder="name@example.com" TextMode="Email" />
            </div>

            <div class="mb-3">
                <asp:Label ID="Label1" CssClass="text-danger" runat="server" Visible="false"></asp:Label>
            </div>

            <div class="col-md-4">
                <div class="mb-3">
                    <label class="form-label">Imagen Perfil</label>                    
                </div>
                <asp:Image ID="imgNuevoPerfil" ImageUrl="https://www.palomacornejo.com/wp-content/uploads/2021/08/no-image.jpg"
                    runat="server" CssClass="img-fluid mb-3" Style="width: 50%; max-width: 200px; height: auto;" />
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
                <asp:Button ID="btnCancelar" Text="Cancelar" CssClass="btn btn-secondary" OnClick="btnCancelar_Click" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
