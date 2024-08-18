<%@ Page Title="Crear cuenta" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="tienda_web.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="StyleMaster.css" />


    <h2 class="mb-3 login">Ingrese los datos para registrarse</h2>
    <div class="mb-3 login">
        <div class="inputs">
            <asp:Label ID="labelEmailRegistro" CssClass="labels" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="txtEmailRegistro" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ErrorMessage="Formato incorrecto" CssClass="validacion" ControlToValidate="txtEmailRegistro" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" runat="server" />
        </div>
        <div class="inputs">
            <asp:Label ID="labelPassRegistro" CssClass="labels" runat="server" Text="Contraseña"></asp:Label>
            <asp:TextBox ID="txtPassRegistro" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>
            <%--<asp:RegularExpressionValidator ErrorMessage="La contraseña debe tener al entre 8 y 16 caracteres, al menos un dígito, al menos una minúscula y al menos una mayúscula. Puede tener otros símbolos." ControlToValidate="txtPassRegistro" CssClass="validacion" runat="server" ValidationExpression="^(?=\w*\d)(?=\w*[A-Z])(?=\w*[a-z])\S{8,16}$" />--%>
        </div>

        <div class="inputs">
            <asp:Label ID="labelRepetirPass" CssClass="labels" runat="server" Text="Repita contraseña"></asp:Label>
            <asp:TextBox ID="txtRepetirPass" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>
        </div>

        <div class="inputs">
            <asp:Label ID="labelNombreRegistro" CssClass="labels" runat="server" Text="Nombre"></asp:Label>
            <asp:TextBox ID="txtNombreRegistro" MaxLength="20" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ErrorMessage="Solo letras para este campo" ControlToValidate="txtNombreRegistro" runat="server" CssClass="validacion " ValidationExpression="^[a-zA-Z\s]*$" />
            <%--solo letras y espacios--%>
        </div>
        <div class="inputs">
            <asp:Label ID="labelApellidoRegistro" CssClass="labels" runat="server" Text="Apellido"></asp:Label>
            <asp:TextBox ID="txtApellidoRegistro" MaxLength="20" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ErrorMessage="Solo letras para este campo" ControlToValidate="txtApellidoRegistro" runat="server" CssClass="validacion " ValidationExpression="^[a-zA-Z\s]*$" />
            <%--solo letras y espacios--%>
        </div>
        <div>
            <asp:Button ID="btnRegistrarse" OnClick="btnRegistrarse_Click"
                CssClass="btn btn-primary btnLogin" runat="server" Text="Registrarse" />
        </div>
    </div>

</asp:Content>
