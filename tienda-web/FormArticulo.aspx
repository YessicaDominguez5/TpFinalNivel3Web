<%@ Page Title="Formulario" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormArticulo.aspx.cs" Inherits="tienda_web.FormArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="StyleMaster.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row rowForm">
        <div class="col-6">

            <asp:Panel ID="panelFormArticulo" DefaultButton="btnAceptarFormulario" runat="server">

            <div class="mb-3">
                <asp:Label ID="labelId" runat="server" Text="ID" CssClass="labels"></asp:Label>
                <asp:TextBox ID="txtIdArticulo" CssClass="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="mb-3">
                <asp:Label ID="labelCodigoArticulo" runat="server" Text="CÓDIGO DE ARTÍCULO" CssClass="labels"></asp:Label>
                <asp:TextBox ID="txtCodigoArticulo" MaxLength="20" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ErrorMessage="Campo requerido" ControlToValidate="txtCodigoArticulo" CssClass="validacion" runat="server" />
            </div>

            <div class="mb-3">
                <asp:Label ID="labelNombreArticulo" runat="server" Text="ARTÍCULO" CssClass="labels"></asp:Label>
                <asp:TextBox ID="txtNombreArticulo" CssClass="form-control" MaxLength="20" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ErrorMessage="Campo requerido" ControlToValidate="txtNombreArticulo" CssClass="validacion" runat="server" />
            </div>

            <div class="mb-3">
                <asp:Label ID="labelDescripcionArticulo" runat="server" Text="DESCRIPCIÓN" CssClass="labels"></asp:Label>
                <asp:TextBox ID="txtDescripcionArticulo" TextMode="MultiLine" CssClass="form-control" MaxLength="200" runat="server"></asp:TextBox>
            </div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>

                    <div class="mb-3">
                        <asp:Label ID="labelUrlImagenArticulo" runat="server" Text="URL IMAGEN" CssClass="labels"></asp:Label>
                        <asp:TextBox ID="txtUrlImagenArticulo" OnTextChanged="txtUrlImagenArticulo_TextChanged" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>

            <div class="mb-3">
                <asp:Label ID="labelPrecioArticulo" runat="server" Text="PRECIO" CssClass="labels"></asp:Label>
                <asp:TextBox ID="txtPrecioArticulo" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ErrorMessage="Solo números" ControlToValidate="txtPrecioArticulo" CssClass="validacion" ValidationExpression="^[0-9]+([,][0-9]+)?$" runat="server" />
            </div>
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>


                    <div class="mb-3">

                        <asp:Button ID="btnAceptarFormulario" OnClick="btnAceptarFormulario_Click" CssClass="btn btn-primary boton" runat="server" Text="ACEPTAR" />
                        <a href="ListaDeArticulos.aspx" class="btn btn-success boton">CANCELAR</a>
                        <%if (Request.QueryString["id"] != null)//si la pantalla es la de modificar que muestre el botón Eliminar
                            {%>
                        <asp:Button ID="btnEliminar" OnClick="btnEliminar_Click" CssClass="btn btn-danger boton" runat="server" Text="ELIMINAR" />
                        <%if (visible)
                            { %>
                        <div>

                            <asp:CheckBox ID="cBoxConfirmarEliminar" runat="server" />
                            <asp:Label ID="labelCheckBoxConfirmarEliminar" runat="server" Text="¿Está seguro que desea eliminar el artículo?"></asp:Label>
                            <asp:Button ID="btnConfirmarEliminar" OnClick="btnConfirmarEliminar_Click" CssClass="btn btn-danger boton" runat="server" Text="CONFIRMAR ELIMINAR" />
                        </div>
                        <%}
                            }%>
                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>
            </asp:Panel>
        </div>

        <div class="col-6 imgSelects">


            <div>
                <div class="mb-3">
                    <asp:Label ID="labelMarcaArticulo" runat="server" Text="MARCA" CssClass="labels"></asp:Label>
                    <asp:DropDownList ID="ddlMarcaArticulo" CssClass="btn btn-outline-dark dropdown-toggle" runat="server"></asp:DropDownList>
                </div>

                <div class="mb-3">
                    <asp:Label ID="labelCategoriaArticulo" runat="server" Text="CATEGORÍA" CssClass="labels"></asp:Label>
                    <asp:DropDownList ID="ddlCategoriaArticulo" CssClass="btn btn-outline-dark dropdown-toggle" runat="server"></asp:DropDownList>
                </div>
            </div>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>

                    <div>

                        <asp:Image ID="imgArticulo" ImageUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT9cSGzVkaZvJD5722MU5A-JJt_T5JMZzotcw&s" CssClass="imagen" runat="server" />

                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>


        </div>



    </div>

</asp:Content>
