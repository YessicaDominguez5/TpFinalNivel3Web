<%@ Page Title="Loguearse" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="tienda_web.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="StyleMaster.css" />


    <div class="mb-3 login">
            <asp:Panel ID="panel1" runat="server" DefaultButton="btnIngresarLogin">

        <div>

            <asp:Label ID="labelUser" CssClass="labels" runat="server" Text="User"></asp:Label>
            <asp:TextBox ID="txtUser" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ErrorMessage="Formato incorrecto" CssClass="validacion" ControlToValidate="txtUser" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" runat="server" />
        </div>
        
        <div class="rowForm">
            <asp:Label ID="labelPass" CssClass="labels" runat="server" Text="Pass"></asp:Label>
            <asp:TextBox ID="txtPass" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="btnIngresarLogin" CssClass="btn btn-primary btnLogin" OnClick="btnIngresarLogin_Click" runat="server" Text="INGRESAR" />
        </div>
        <div class="rowForm">
            <a class="btnLogin" href="Registro.aspx">No tengo cuenta</a>
        </div>


            </asp:Panel>
    </div>

</asp:Content>
