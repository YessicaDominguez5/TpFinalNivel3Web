<%@ Page Title="Home" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="tienda_web.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="StyleMaster.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1 class="text-sm-center text-bg-primary rowDefault">CATÁLOGO DE ARTÍCULOS</h1>

    </div>

    <%--carrousel automático--%>
    <div id="carouselExampleSlidesOnly" class="carousel slide" data-bs-ride="carousel">
        <div class="carousel-inner">
            <div class="carousel-item active">
                <img src="./Imagenes/logotipo.jpg" class="d-block w-100  carrousel" alt="...">
            </div>
            <div class="carousel-item">
                <img src="<%:listaDeArticulos[4].UrlImagenArticulo %>" class="d-block w-100  carrousel" alt="...">
            </div>
            <div class="carousel-item">
                <img src="<%:listaDeArticulos[3].UrlImagenArticulo %>" class="d-block w-100  carrousel" alt="...">
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
