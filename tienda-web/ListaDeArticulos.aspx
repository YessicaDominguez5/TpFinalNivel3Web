<%@ Page Title="ListaArticulos" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ListaDeArticulos.aspx.cs" Inherits="tienda_web.ListaDeArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="StyleMaster.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <%-- filtro rápido--%>
            <div class="mb-3 filtroRapido">
                <asp:Label ID="labelFiltroRapidoListaArticulos" runat="server" CssClass="labels" Text="Filtro"></asp:Label>
                <asp:TextBox ID="txtFiltroRapidoListaArticulos" OnTextChanged="txtFiltroRapidoListaArticulos_TextChanged" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:Label ID="labelSinFiltrosListaDeArticulos" runat="server" Text=""></asp:Label>
            </div>
            <%--  filtro avanzado--%>
            <div>

            <asp:CheckBox ID="cBoxFAvanzadoLDeArticulos" OnCheckedChanged="cBoxFAvanzadoLDeArticulos_CheckedChanged" AutoPostBack="true" runat="server" />
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
                <a href="Default.aspx">Volver</a>
                <%}%>
                <%}%>
            </div>
            <%-- grilla--%>
            <div class="row-3">

                <div class="col-2">
                </div>
                <div class="col">


                    <asp:GridView ID="dgvArticulos" AutoGenerateColumns="false" DataKeyNames="Id" CssClass="table table-bordered border-primary text-center table-dark" AllowPaging="true" PageSize="5" OnPageIndexChanging="dgvArticulos_PageIndexChanging" OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged" runat="server">
                        <Columns>
                            <asp:BoundField HeaderText="Código" DataField="CodigoArticulo" />
                            <asp:BoundField HeaderText="Artículo" DataField="NombreArticulo" />
                            <asp:BoundField HeaderText="Marca" DataField="MarcaArticulo" />
                            <asp:BoundField HeaderText="Categoría" DataField="CategoriaArticulo" />
                            <%--<asp:CheckBoxField HeaderText="Activo" DataField="Activo"/>--%>
                            <asp:CommandField ShowSelectButton="true" SelectText="✏️" HeaderText="Editar" />

                        </Columns>

                    </asp:GridView>

                </div>
                <%if (filtradoListaDeArticulos)
                    {%>
                <a href="ListaDeArticulos.aspx">volver</a>
                <%} %>
                <div class="col-2"></div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <a href="FormArticulo.aspx" class="btn btn-primary boton">AGREGAR ARTÍCULO</a>



</asp:Content>



