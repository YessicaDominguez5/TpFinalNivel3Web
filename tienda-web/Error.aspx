<%@ Page Title="Error" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="tienda_web.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Error</h1>

    <asp:Label ID="labelError" runat="server" Text=""></asp:Label>

    <%if (Session["error"] != null && Session["error"].ToString() == "User o Pass incorrectos.")
        { %>
    <div>
        <a href="Login.aspx" class="btn btn-primary inputs">VOLVER</a>

    </div>

    <%}
        else if (Session["error"] != null && (Session["error"].ToString() == "Debe completar todos los campos para poder registrarse." || Session["error"].ToString() == "No coinciden las contraseñas" ))
        { %>

    <div>
        <a href="Registro.aspx" class="btn btn-primary inputs">VOLVER</a>

    </div>

    <%}
        else
        {%>

    <div>
        <a href="Default.aspx" class="btn btn-primary inputs">VOLVER</a>

    </div>

    <%}%>
</asp:Content>
