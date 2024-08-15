<%@ Page Title="Crear cuenta" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="tienda_web.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="StyleMaster.css" />


    <h2 class="mb-3 login">Ingrese los datos para registrarse</h2>
    <div class="mb-3 login">
        <div class="inputs">
            <asp:Label ID="labelEmailRegistro" CssClass="labels" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="txtEmailRegistro" CssClass="form-control" TextMode="Email" runat="server"></asp:TextBox>
        </div>
        <div class="inputs">
            <asp:Label ID="labelPassRegistro" CssClass="labels" runat="server" Text="Contraseña"></asp:Label>
            <asp:TextBox ID="txtPassRegistro" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>
        </div>
        <div class="inputs">
            <asp:Label ID="labelNombreRegistro" CssClass="labels" runat="server" Text="Nombre"></asp:Label>
            <asp:TextBox ID="txtNombreRegistro" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="inputs">
            <asp:Label ID="labelApellidoRegistro" CssClass="labels" runat="server" Text="Apellido"></asp:Label>
            <asp:TextBox ID="txtApellidoRegistro" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="btnRegistrarse" OnClick="btnRegistrarse_Click"
                CssClass="btn btn-primary btnLogin" runat="server" Text="Registrarse" />
        </div>
    </div>

</asp:Content>
