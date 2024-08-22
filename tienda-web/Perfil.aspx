<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="tienda_web.Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <h1 class="text-sm-center text-bg-primary rowDefault">MI PERFIL</h1>


    <div class="row rowForm">

        <div class="col-6 sinArticulos">
            <asp:Panel ID="panelPerfil" DefaultButton="btnAceptarPerfil" runat="server">

            <div class="mb-3">
                <asp:Label ID="labelEmailPerfil" CssClass="labels" runat="server" Text="Email"></asp:Label>
                <asp:TextBox ID="txtEmailPerfil" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:Label ID="labelNombrePerfil" CssClass="labels" runat="server" Text="Nombre"></asp:Label>
                <asp:TextBox ID="txtNombrePerfil" CssClass="form-control" MaxLength="20" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ErrorMessage="El nombre es requerido" ControlToValidate="txtNombrePerfil" CssClass="validacion" runat="server" />
                <asp:RegularExpressionValidator ErrorMessage="Solo letras para este campo" ControlToValidate="txtNombrePerfil" runat="server" CssClass="validacion validator" ValidationExpression="^[a-zA-Z\s]*$" /> <%--solo letras y espacios--%>
        
               
            </div>
            <div class="mb-3">
                <asp:Label ID="labelApellidoPerfil" CssClass="labels" runat="server" Text="Apellido"></asp:Label>
                <asp:TextBox ID="txtApellidoPerfil" MaxLength="20" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ErrorMessage="El apellido es requerido" ControlToValidate="txtApellidoPerfil" CssClass="validacion" runat="server" />
                 <asp:RegularExpressionValidator ErrorMessage="Solo letras para este campo" ControlToValidate="txtApellidoPerfil" runat="server" CssClass="validacion validator" ValidationExpression="^[a-zA-Z\s]*$" />
            </div>
            <div class="mb-3">
                <asp:Label ID="labelSeleccionImagenPerfil" CssClass="labels" runat="server" Text="Seleccione imagen de perfil"></asp:Label>
                <input type="File" id="txtImagen" runat="server" class="form-control" />
            </div>
            <div>
                <asp:Button ID="btnAceptarPerfil" OnClick="btnAceptarPerfil_Click" CssClass="btn btn-primary inputs" runat="server" Text="GUARDAR" />
            </div>
            </asp:Panel>
        </div>
        <div class="col">

            <asp:Image ID="imgPerfil" CssClass="img-fluid mb-3 imagenPerfil" runat="server" />

        </div>
    </div>


</asp:Content>
