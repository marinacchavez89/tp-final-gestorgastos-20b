<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TpFinal_WebForms_20B_GestorGastos.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function togglePasswordVisibility(inputId, iconId) {
            var input = document.getElementById(inputId);
            var icon = document.getElementById(iconId);
            if (input.type === "password") {
                input.type = "text"; // Cambia a texto para mostrar la contraseña
                icon.classList.remove("fa-eye"); // Remueve el icono de ojo
                icon.classList.add("fa-eye-slash"); // Agrega el icono de ojo tachado
            } else {
                input.type = "password"; // Cambia a password para ocultar la contraseña
                icon.classList.remove("fa-eye-slash"); // Remueve el icono de ojo tachado
                icon.classList.add("fa-eye"); // Agrega el icono de ojo
            }
        }
  </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="d-flex flex-column justify-content-center align-items-center">    

    <h2 class="mb-4">Iniciar sesión</h2>

    <div class="mb-3" style="width: 300px;">
        <label for="txtEmail" class="form-label">Email</label>
        <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" placeholder="name@example.com" TextMode="Email" />
    </div>

    <!--<div class="mb-3">
    <label for="txtPass" class="form-label">Contraseña</label>
    <asp:TextBox ID="txtPass" CssClass="form-control" runat="server" TextMode="Password" />
    </div>-->

    <div class="mb-3" style="width: 300px;">
        <label for="txtPassLogin" class="form-label">Contraseña</label>
        <div class="input-group">
            <asp:TextBox ID="txtPassLogin" CssClass="form-control" runat="server" TextMode="Password" />
            <div class="input-group-append">
                <button class="btn btn-outline-secondary" type="button" id="btnTogglePassNueva" onclick="togglePasswordVisibility('<%= txtPassLogin.ClientID %>', 'iconPass')">
                    <i class="fas fa-eye" id="iconPass"></i>
                </button>
            </div>
        </div>
    </div>

    <div class="mb-3">
        <asp:Label ID="lblError" CssClass="text-danger" runat="server" Visible="false"></asp:Label>
    </div>
    
    <div>    
    <asp:Button ID="btnIngresar" Text="Ingresar" CssClass="btn btn-secondary" OnClick="btnIngresar_Click" runat="server" />
    <asp:Button ID="btnOlvidePass" Text="Olvidé contraseña" CssClass="btn btn-secondary" OnClick="btnOlvidePass_Click" runat="server" />
    </div>
</div>
</asp:Content>
