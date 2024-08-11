<%@ Page Title="Home" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="tienda_web.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="StyleMaster.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1 class="text-sm-center text-bg-primary rowDefault">CATÁLOGO DE ARTÍCULOS</h1>

    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <%--   filtro rápido--%>
    <div class="mb-3 filtroRapido">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>

                <asp:Label ID="labelFiltroRapido" CssClass="labels" runat="server" Text="Filtro:"></asp:Label>
                <asp:TextBox ID="txtFiltroRapido" OnTextChanged="txtFiltroRapido_TextChanged" CssClass="form-control" AutoPostBack="true" runat="server"></asp:TextBox>
                <asp:Label ID="labelSinFiltros" runat="server" Text=""></asp:Label>
                <%if (filtrado)
                    {%>
                <a href="Default.aspx">volver</a>
                <%}%>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <%--filtro avanzado--%>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <div>

                <asp:CheckBox ID="cBoxFiltroAvanzado" OnCheckedChanged="cBoxFiltroAvanzado_CheckedChanged" AutoPostBack="true" runat="server" />
                <asp:Label ID="labelFiltroAvanzado" runat="server" Text="Filtro Avanzado"></asp:Label>


            </div>
            <%if (cBoxFiltroAvanzado.Checked)
                {%>
            <div class="rowFiltroAvanzado">

                <div class="row">
                    <div class="col-3">
                        <div class="mb-3">

                            <asp:Label ID="labelCampo" CssClass="labels" runat="server" Text="Campo"></asp:Label>
                            <asp:DropDownList ID="ddlCampo" CssClass="form-control" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged" AutoPostBack="true" runat="server">
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
                            <asp:Button ID="btnBuscarFiltroAvanzado" CssClass="btn btn-primary" OnClick="btnBuscarFiltroAvanzado_Click" runat="server" Text="Buscar" />

                        </div>
                    </div>

                </div>
                <asp:Label ID="labelSinFiltrosAvanzados" runat="server" Text=""></asp:Label>
                <%if (filtradoAvanzado)
                    {%>
                <a href="Default.aspx">Volver</a>
                <%}%>
                <%}%>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--   cards--%>

    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
        <ContentTemplate>
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
        </ContentTemplate>
    </asp:UpdatePanel>
    </div>

</asp:Content>
