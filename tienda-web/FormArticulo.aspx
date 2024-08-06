<%@ Page Title="Formulario" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormArticulo.aspx.cs" Inherits="tienda_web.FormArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col">
            <br />
            <div class="mb-3">
                <asp:Label ID="labelId" runat="server" Text="ID" CssClass="labels"></asp:Label>
                <asp:TextBox ID="txtIdArticulo" CssClass="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="mb-3">
                <asp:Label ID="labelCodigoArticulo" runat="server" Text="CÓDIGO DE ARTÍCULO" CssClass="labels"></asp:Label>
                <asp:TextBox ID="txtCodigoArticulo" CssClass="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="mb-3">
                <asp:Label ID="labelNombreArticulo" runat="server" Text="ARTÍCULO" CssClass="labels"></asp:Label>
                <asp:TextBox ID="txtNombreArticulo" CssClass="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="mb-3">
                <asp:Label ID="labelDescripcionArticulo" runat="server" Text="DESCRIPCIÓN" CssClass="labels"></asp:Label>
                <asp:TextBox ID="txtDescripcionArticulo" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="mb-3">
                <asp:Label ID="labelUrlImagenArticulo" runat="server" Text="URL IMAGEN" CssClass="labels"></asp:Label>
                <asp:TextBox ID="txtUrlImagenArticulo" OnTextChanged="txtUrlImagenArticulo_TextChanged" CssClass="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="mb-3">
                <asp:Label ID="labelPrecioArticulo" runat="server" Text="PRECIO" CssClass="labels"></asp:Label>
                <asp:TextBox ID="txtPrecioArticulo" CssClass="form-control" runat="server"></asp:TextBox>
            </div>


            <div class="mb-3">

                <asp:Button ID="btnAceptarFormulario" OnClick="btnAceptarFormulario_Click" CssClass="btn btn-primary" runat="server" Text="ACEPTAR" />

                <a href="ListaDeArticulos.aspx" class="btn btn-success">CANCELAR</a>

            </div>

        </div>

        <div class="col">
            <br />
            <br />

            <div class="mb-3">
                <asp:Label ID="labelMarcaArticulo" runat="server" Text="MARCA" CssClass="labels"></asp:Label>
                <asp:DropDownList ID="ddlMarcaArticulo" CssClass="btn btn-outline-dark dropdown-toggle" runat="server"></asp:DropDownList>
            </div>

            <div class="mb-3">
                <asp:Label ID="labelCategoriaArticulo" runat="server" Text="CATEGORÍA" CssClass="labels"></asp:Label>
                <asp:DropDownList ID="ddlCategoriaArticulo" CssClass="btn btn-outline-dark dropdown-toggle" runat="server"></asp:DropDownList>
            </div>

            <%--<div>
                <asp:Label ID="labelActivoArticulo" CssClass="labels" runat="server" Text="ACTIVO"></asp:Label>
                <asp:CheckBox ID="ckbActivoArticulo" Text="" runat="server" />
            </div>--%>

        </div>
        <div class="col">

            <asp:Image ID="imgArticulo" runat="server" />


        </div>

    </div>

</asp:Content>
