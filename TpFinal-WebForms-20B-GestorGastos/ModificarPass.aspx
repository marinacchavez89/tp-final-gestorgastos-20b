<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ModificarPass.aspx.cs" Inherits="TpFinal_WebForms_20B_GestorGastos.ModificarPass" %>

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
    <h2>Modificar contraseña</h2>
    <div class="mb-3" style="width: 300px;">
        <label for="txtPassAnterior" class="form-label">Ingrese contraseña anterior</label>
        <div class="input-group">
            <asp:TextBox ID="txtPassAnterior" CssClass="form-control" runat="server" TextMode="Password" />
            <div class="input-group-append">
                <button class="btn btn-outline-secondary" type="button" id="btnTogglePassAnterior" onclick="togglePasswordVisibility('<%= txtPassAnterior.ClientID %>', 'iconPassAnterior')">
                    <i class="fas fa-eye" id="iconPassAnterior"></i>
                </button>
            </div>
        </div>
    </div>

    <div class="mb-3" style="width: 300px;">
        <label for="txtPassNueva" class="form-label">Ingrese la nueva contraseña</label>
        <div class="input-group">
            <asp:TextBox ID="txtPassNueva" CssClass="form-control" runat="server" TextMode="Password" />
            <div class="input-group-append">
                <button class="btn btn-outline-secondary" type="button" id="btnTogglePassNueva" onclick="togglePasswordVisibility('<%= txtPassNueva.ClientID %>', 'iconPassNueva')">
                    <i class="fas fa-eye" id="iconPassNueva"></i>
                </button>
            </div>
        </div>
    </div>

    <div class="mb-3">
        <asp:Label ID="lblError" CssClass="text-danger" runat="server" Visible="false"></asp:Label>
    </div>

    <asp:Button ID="btnGuardar" Text="Guardar" CssClass="btn btn-secondary me-2" OnClick="btnGuardar_Click" runat="server" />
</asp:Content>
