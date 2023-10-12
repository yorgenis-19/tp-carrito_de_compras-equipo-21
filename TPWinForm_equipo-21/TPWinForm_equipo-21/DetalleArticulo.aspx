<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="DetalleArticulo.aspx.cs" Inherits="TPWinForm_equipo_21.DetalleArticulo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

       <h2> Detalle de producto</h2>
    <div>
        <asp:Label ID="lblNombreArticulo" runat="server" Text=""></asp:Label><br />
        <asp:Label ID="lblDescripcionArticulo" runat="server" Text=""></asp:Label><br />
        <asp:Label ID="lblCategoriaArticulo" runat="server" Text=""></asp:Label><br />
        <asp:Label ID="lblMarcaArticulo" runat="server" Text=""></asp:Label><br />
        <asp:Label ID="lblPrecioArticulo" runat="server" Text=""></asp:Label><br />
    </div>

    <!-- Controles para mostrar las imágenes relacionadas al artículo -->
   <div id="carouselExample" class="carousel slide" data-ride="carousel">
    <div class="carousel-inner">
        <asp:Repeater ID="repeaterImagenes" runat="server">
            <ItemTemplate>
                <div class='<%# Container.ItemIndex == 0 ? "carousel-item active" : "carousel-item" %>'>
                    <asp:Image ID="imgArticulo" runat="server" ImageUrl='<%# Eval("imagenUrl") %>' CssClass="d-block w-100" alt="Imagen del artículo" />
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <a class="carousel-control-prev" href="#carouselExample" role="button" data-slide="prev">
        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
        <span class="visually-hidden">Previous</span>
    </a>
    <a class="carousel-control-next" href="#carouselExample" role="button" data-slide="next">
        <span class="carousel-control-next-icon" aria-hidden="true"></span>
        <span class="visually-hidden">Next</span>
    </a>
</div>

</asp:Content>
