<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="tienda_web.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">

    <div class="row">
        <div class="col">

            <asp:Image ID="imagenDetalle" CssClass="imagenDetalle" runat="server" />

        </div>
        <div class="col textoDetalle">
            <div class="card text-bg-primary mb-3" style="max-width: 18rem;">

                <div class="card-header">
                    <asp:Label ID="labelNombreDetalle" CssClass="labels" runat="server" Text=""></asp:Label>
                </div>
                <div class="card-body">

                    <div>
                        <asp:Label ID="labelCodigoDetalle" CssClass="labels" runat="server" Text=""></asp:Label>
                    </div>
                    <div>
                        <asp:Label ID="labelDescripcionDetalle" CssClass="labels" runat="server" Text=""></asp:Label>
                    </div>
                    <div>
                        <asp:Label ID="labelMarcaDetalle" CssClass="labels" runat="server" Text=""></asp:Label>
                    </div>
                    <div>
                        <asp:Label ID="labelCategoriaDetalle" CssClass="labels" runat="server" Text=""></asp:Label>
                    </div>
                    <div>
                        <asp:Label ID="labelPrecioDetalle" CssClass="labels" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>

        </div>

    </div>

    </div>
    <a href="Default.aspx" class="btn btn-success boton volver">Volver</a>


</asp:Content>


