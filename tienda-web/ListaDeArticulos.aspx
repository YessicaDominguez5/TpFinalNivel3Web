<%@ Page Title="ListaArticulos" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ListaDeArticulos.aspx.cs" Inherits="tienda_web.ListaDeArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="row-3">

        <div class="col-2">
        </div>
            <div class="col">


            <asp:GridView ID="dgvArticulos" AutoGenerateColumns="false" DataKeyNames="Id" CssClass="table table-bordered border-primary text-center table-dark" runat="server">
                <Columns>
                    <asp:BoundField HeaderText="Código" DataField="CodigoArticulo" />
                    <asp:BoundField HeaderText="Artículo" DataField="NombreArticulo" />
                    <asp:BoundField HeaderText="Marca" DataField="MarcaArticulo" />
                    <asp:BoundField HeaderText="Categoría" DataField="CategoriaArticulo" />
                    <asp:CheckBoxField HeaderText="Activo" DataField="Activo"/>
                    <asp:CommandField ShowSelectButton="true" SelectText="✏️" HeaderText="Editar" />

                </Columns>

            </asp:GridView>

            </div>
        <div class="col-2"></div>
    </div>
    


</asp:Content>



