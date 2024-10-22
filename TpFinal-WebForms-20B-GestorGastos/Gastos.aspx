<%@ Page Title="Gastos" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Gastos.aspx.cs" Inherits="TpFinal_WebForms_20B_GestorGastos.Gastos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2>Gestión de Gastos</h2>
        <p>Comenzá a gestionar tus cuentas ingresando un nuevo gasto</p>
        <div class="mb-3">
            <label for="fechaGasto" class="form-label">Fecha</label>
            <input type="date" class="form-control" id="fechaGasto" />
        </div>
        <div class="mb-3">
            <label for="conceptoGasto" class="form-label">Concepto del Gasto</label>
            <input type="text" class="form-control" id="conceptoGasto" />
        </div>
        <div class="mb-3">
            <label for="montoGasto" class="form-label">Monto</label>
            <input type="number" class="form-control" id="montoGasto" />
        </div>
        <div class="mb-3">
            <label for="participantesGasto" class="form-label">Participantes</label>
            <select multiple class="form-control" id="participantesGasto">
                <option>Marina</option>
                <option>Juan</option>
                <option>Martin</option>
            </select>
        </div>
    </div>


       


        <asp:Button ID="btnAgregar" Text="Agregar" CssClass="btn btn-secondary" OnClick="btnAgregar_Click" runat="server" />
</asp:Content>
