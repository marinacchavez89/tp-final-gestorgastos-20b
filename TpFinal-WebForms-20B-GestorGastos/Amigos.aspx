﻿<%@ Page Title="Amigos" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Amigos.aspx.cs" Inherits="TpFinal_WebForms_20B_GestorGastos.Amigos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2>Gestión de Amigos</h2>
        <h5>Listado de grupos</h5>

        <label for="idGrupo" class="form-label">Seleccionar grupo</label>
        <asp:DropDownList ID="ddlGrupos" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlGrupos_SelectedIndexChanged">
        </asp:DropDownList>

        <!--<asp:ListBox ID="lstParticipantesGasto" runat="server" SelectionMode="Multiple" CssClass="form-control">          
        </asp:ListBox>-->

        <div class="container">
            <div class="row justify-content-center">
                <div class="col-12 text-center">
                    <h5 style="margin-top: 20px;">Participantes</h5>
                    <div class="row row-cols-1 row-cols-md-3 g-4 justify-content-center">
                        <asp:Repeater runat="server" ID="repParticipantes">
                            <ItemTemplate>
                                <div class="col-md-3">
                                    <div class="card">
                                        <img src="/Images/logoParticipante.png" class="card-img-top d-block mx-auto" alt="img-participante" style="height: 100px; width: 100px;">
                                        <div class="card-body">
                                            <h5 class="card-title"><%# Eval("Nombre") %></h5>
                                            <p class="card-text"><%# Eval("Email") %></p>
                                            <button class="btn btn-danger" onclick="quitarParticipante(<%# Eval("IdUsuario") %>)" style="border: none; background: none; padding: 0;">
                                                <img src="/Images/logoEliminar.png" alt="Eliminar" style="width: 50px; height: 45px;" />
                                                <img src="https://cdn-icons-png.flaticon.com/128/5646/5646186.png" alt="Modificar" style="width: 30px; height: 30px;" />
                                            </button>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
        </div>
        <!-- logica para gestionar los amigos -->
    </div>
</asp:Content>
