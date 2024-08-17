<%@ Page Title="Lista de Articulos" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ListaDeArticulos.aspx.cs" Inherits="tienda_web.ListaDeArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="StyleMaster.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 class="text-sm-center text-bg-primary rowDefault">LISTA DE ARTÍCULOS</h1>


    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container">

        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>

                <div class="volverArticulos">
                    <%-- filtro rápido--%>
                    <div class="mb-3 filtroRapido">
                        <asp:Label ID="labelFiltroRapidoListaArticulos" runat="server" CssClass="labels" Text="Filtro"></asp:Label>
                        <asp:TextBox ID="txtFiltroRapidoListaArticulos" OnTextChanged="txtFiltroRapidoListaArticulos_TextChanged" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>

                    <%if (filtradoListaDeArticulos)
                        {%>
                    <div class="m-4">
                        <a href="ListaDeArticulos.aspx" class="volverArticulos">volver</a>
                    </div>
                    <%} %>
                </div>
                <asp:Label ID="labelSinFiltrosListaDeArticulos" runat="server" CssClass="sinArticulos" Text=""></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>

        <%--  filtro avanzado--%>
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <div class="inputs">


                    <asp:CheckBox ID="cBoxFAvanzadoLDeArticulos" OnCheckedChanged="cBoxFAvanzadoLDeArticulos_CheckedChanged" CssClass="rowFiltroAvanzado" AutoPostBack="true" runat="server" />

                    <asp:Label ID="labelFAvanzadoLDeArticulos" runat="server" Text="Filtro Avanzado"></asp:Label>

                </div>


                <%if (cBoxFAvanzadoLDeArticulos.Checked)
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
                    <%if (filtradoAvanzadoVolverLArticulos)

                        {%>
                    <a href="ListaDeArticulos.aspx">Volver</a>
                    <%}%>

                    <%}%>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <%-- grilla--%>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="row-3">

                    <div class="col-2">
                    </div>
                    <div class="col">

                        <asp:GridView ID="dgvArticulos" AutoGenerateColumns="false" DataKeyNames="Id" CssClass="table table-bordered border-primary text-center table-dark rowFiltroAvanzado" AllowPaging="true" PageSize="5" OnPageIndexChanging="dgvArticulos_PageIndexChanging" OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged" runat="server">
                            <Columns>
                                <asp:BoundField HeaderText="Código" DataField="CodigoArticulo" />
                                <asp:BoundField HeaderText="Artículo" DataField="NombreArticulo" />
                                <asp:BoundField HeaderText="Marca" DataField="MarcaArticulo" />
                                <asp:BoundField HeaderText="Categoría" DataField="CategoriaArticulo" />
                                <asp:CommandField ShowSelectButton="true" SelectText="✏️" HeaderText="Editar" />

                            </Columns>

                        </asp:GridView>


                    </div>

                    <div class="col-2"></div>
                </div>

                <a href="FormArticulo.aspx" class="btn btn-primary boton rowFiltroAvanzado">AGREGAR ARTÍCULO</a>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

</asp:Content>



