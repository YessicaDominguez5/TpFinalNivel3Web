<%@ Page Title="Home" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="tienda_web.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="StyleMaster.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1 class="text-sm-center text-bg-primary rowDefault">CATÁLOGO DE ARTÍCULOS</h1>

    </div>

    <%--   filtro rápido--%>
    <div class="mb-3 filtroRapido">
        <asp:Label ID="labelFiltroRapido" CssClass="labels" runat="server" Text="Filtro:"></asp:Label>
        <asp:TextBox ID="txtFiltroRapido" OnTextChanged="txtFiltroRapido_TextChanged" CssClass="form-control" AutoPostBack="true" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:CheckBox ID="cBoxFiltroAvanzado" AutoPostBack="true" runat="server" />
        <asp:Label ID="labelFiltroAvanzado" runat="server" CssClass="labels" Text="Filtro Avanzado"></asp:Label>

    </div>
    <div class="row">
        <div class="col-3">
            <div class="mb-3">

                <asp:Label ID="labelCampo" CssClass="labels" runat="server" Text="Campo"></asp:Label>
                <asp:DropDownList ID="ddlCampo" CssClass="form-control" runat="server">
                    <asp:ListItem Text="Artículo" />
                    <asp:ListItem Text="Marca" />
                    <asp:ListItem Text="Precio" />
                </asp:DropDownList>

            </div>
        </div>
        <div class="col-3">
            <div class="mb-3">
                <asp:Label ID="labelCriterio" CssClass="labels" runat="server" Text="Criterio"></asp:Label>
                <asp:DropDownList ID="ddlCriterio" CssClass="form-control" runat="server">
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-3">
            <div class="mb-3">
                <asp:Label ID="labelFiltroAvanzado2" CssClass="labels" runat="server" Text="Filtro"></asp:Label>
                <asp:TextBox ID="txtFiltroAvanzado" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="col-3">
            <div class="mb-3 btnBuscar">
                <asp:Button ID="btnBuscarFiltroAvanzado" CssClass="btn btn-primary" runat="server" Text="Buscar" />
                
            </div>
        </div>

    </div>

    <%--   cards--%>
    <div class="row row-cols-1 row-cols-md-3 g-4 rowDefault">

        <% foreach (dominio.Articulo articulo in listaDeArticulos)
            {%>


        <div class="col">
            <div class="card">
                <img src="<%: articulo.UrlImagenArticulo %>" class="card-img-top imgCard" alt="<%: articulo.NombreArticulo%>">
                <div class="card-body">
                    <h5 class="card-title"><%: articulo.NombreArticulo %></h5>
                    <p class="card-text">Tipo: <%: articulo.CategoriaArticulo.DescripcionCategoria%></p>
                </div>
                <a class="btn btn-primary verDetalle" href="Detalle.aspx?id=<%: articulo.Id %>">Ver Detalle</a>
            </div>
        </div>

        <% } %>
    </div>

</asp:Content>
