<%@ Page Title="Favoritos" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="tienda_web.Favoritos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 class="text-sm-center text-bg-primary rowDefault">MIS FAVORITOS</h1>

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
        <ContentTemplate>

            <div class="row row-cols-1 row-cols-md-3 g-4 rowDefault">
                <asp:Repeater ID="repFavoritos" runat="server">
                    <ItemTemplate>

                        <div class="col">
                            <div class="card">
                                <img src="<%#Eval("UrlImagenArticulo")%>" class="card-img-top imgCard" alt="<%#Eval("NombreArticulo")%>">
                                <div class="card-body">
                                    <h5 class="card-title"><%#Eval("NombreArticulo")%></h5>
                                    <p class="card-text">Tipo: <%#Eval("CategoriaArticulo")%></p>

                                    <asp:Button ID="btnEliminarFavorito" runat="server" Text="🖤" onclick="btnEliminarFavorito_Click" CssClass ="btn bg-gradient" CommandArgument='<%#Eval("Id")%>' />


                                    <asp:Label ID="labelFavoritos" runat="server" Text="Eliminar de Favoritos"></asp:Label>
                                </div>
                                <a class="btn btn-primary verDetalle" href="Detalle.aspx?id=<%#Eval("Id")%>">Ver Detalle</a>
                            </div>
                        </div>


                    </ItemTemplate>

                </asp:Repeater>
            </div>


        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
