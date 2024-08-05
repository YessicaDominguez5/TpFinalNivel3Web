<%@ Page Title="Formulario" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormArticulo.aspx.cs" Inherits="tienda_web.FormArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col">

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
                <asp:Label ID="labelPrecioArticulo" runat="server" Text="PRECIO" CssClass="labels"></asp:Label>
                <asp:TextBox ID="txtPrecioArticulo" CssClass="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="form-check">
                <asp:CheckBox ID="ckbActivoArticulo" Text="" runat="server" />
                <asp:Label ID="labelActivoArticulo" CssClass="labels" runat="server" Text="ACTIVO"></asp:Label>

            </div>

            <div class="mb-3">
                <asp:Label ID="labelMarcaArticulo" runat="server" Text="MARCA" CssClass="labels"></asp:Label>
                <asp:DropDownList ID="ddlMarcaArticulo" CssClass="dropdown-menu" runat="server"></asp:DropDownList>
            </div>

            <div class="mb-3">
                <asp:Label ID="labelCategoriaArticulo" runat="server" Text="CATEGORÍA" CssClass="labels"></asp:Label>
                <asp:DropDownList ID="ddlCategoriaArticulo" CssClass="dropdown-menu" runat="server"></asp:DropDownList>
            </div>



        </div>

    </div>

</asp:Content>
