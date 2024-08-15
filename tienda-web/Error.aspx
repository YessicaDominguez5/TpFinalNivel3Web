<%@ Page Title="Error" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="tienda_web.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Error</h1>

    <asp:Label ID="labelError" runat="server" Text=""></asp:Label>
   
    <div>
        <a href="Default.aspx" class="btn btn-primary inputs">VOLVER</a>

    </div>

</asp:Content>
