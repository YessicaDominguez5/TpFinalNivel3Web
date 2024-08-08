<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="tienda_web.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col">

            <asp:Image ID="imagenDetalle" CssClass="rowForm" runat="server" />

        </div>
        <div class="col">

            <asp:Label ID="labelCodigoDetalle" Cssclass="labels textoDetalle" runat="server" Text=""></asp:Label>

        </div>

    </div>


</asp:Content>


<%--  CodigoArticulo

NombreArticulo

 DescripcionArticulo 


 MarcaArticulo 

 CategoriaArticulo

UrlImagenArticulo


 PrecioArticulo --%>
