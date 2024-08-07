<%@ Page Title="ListaArticulos" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ListaDeArticulos.aspx.cs" Inherits="tienda_web.ListaDeArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link rel="stylesheet" href="StyleMaster.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
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
        <div class="col-2"></div>
    </div>

    <a href="FormArticulo.aspx" class="btn btn-primary boton">AGREGAR ARTÍCULO</a>
    


</asp:Content>



