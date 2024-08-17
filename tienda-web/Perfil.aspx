<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="tienda_web.Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <h1 class="text-sm-center text-bg-primary rowDefault">MI PERFIL</h1>


    <div class="row rowForm">

        <div class="col-6 sinArticulos">

            <div class="mb-3">
                <asp:Label ID="labelEmailPerfil" CssClass="labels" runat="server" Text="Email"></asp:Label>
                <asp:TextBox ID="txtEmailPerfil" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:Label ID="labelNombrePerfil" CssClass="labels" runat="server" Text="Nombre"></asp:Label>
                <asp:TextBox ID="txtNombrePerfil" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:Label ID="labelApellidoPerfil" CssClass="labels" runat="server" Text="Apellido"></asp:Label>
                <asp:TextBox ID="txtApellidoPerfil" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:Label ID="labelSeleccionImagenPerfil" CssClass="labels" runat="server" Text="Seleccione imagen de perfil"></asp:Label>
                <input type="File" id="txtImagen" runat="server" class="form-control" />
            </div>
            <div>
                <asp:Button ID="btnAceptarPerfil" OnClick="btnAceptarPerfil_Click" CssClass="btn btn-primary inputs" runat="server" Text="GUARDAR" />
            </div>
        </div>
    <div class="col">

        <asp:Image ID="imgPerfil" ImageUrl="https://lh5.googleusercontent.com/proxy/9vqIPeIeHQHyGEo43DlSgD-DUtidieclv56O6UoAcYNGPXGNnZwFJL2V7oSodehCB1YT28jit7pMSVjNTnrBOnlBxW0CiRmOeH22FlPockzEbfdQPHLkDMPcgMwWdNfVHF1r2QpUk6W_aY_J87A9lFtYKMHf8_xhkMB7l_4=w1200-h630-p-k-no-nu" CssClass="img-fluid mb-3 imagenPerfil" runat="server" />

    </div>
    </div>
   

</asp:Content>
