<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="DetalleArticulo.aspx.cs" Inherits="TPWinForm_equipo_21.DetalleArticulo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <style>
            .carousel-inner .carousel-item {
                width: 250px;
                height: 250px;
                overflow: hidden;
            }

            .carousel-inner .carousel-item img {
                width: 100%;
                height: 100%;
                object-fit: cover;
            }

            /* Estilo para los botones "Previous" y "Next" */
            .carousel-control-prev, .carousel-control-next {
                color: #000000;
            }
            /* Estilo para los botones "Previous" y "Next" */
            .carousel-control-prev, .carousel-control-next {
                background-color: #d6cdc1;
                color: #ffffff;
                font-size: 24px;
                width: auto;
            }

            /* Estilo para los íconos de los botones "Previous" y "Next" */
            .carousel-control-prev-icon, .carousel-control-next-icon {
                color: #ffffff;
            }
    </style>

    <div class="container">
        <h2>Detalle de producto</h2>

        <div class="row">
            <!-- Columna izquierda -->
            <div class="col-md-6">
                <asp:Label ID="lblNombreArticulo" runat="server" Text=""></asp:Label><br />
                <asp:Label ID="lblDescripcionArticulo" runat="server" Text=""></asp:Label><br />
                <asp:Label ID="lblCategoriaArticulo" runat="server" Text=""></asp:Label><br />
                <asp:Label ID="lblMarcaArticulo" runat="server" Text=""></asp:Label><br />
                <asp:Label ID="lblPrecioArticulo" runat="server" Text=""></asp:Label><br />
            </div>

            <!-- Columna derecha (carrusel) -->
            <div class="col-md-6">
                <div id="carouselExample" class="carousel slide" data-bs-ride="carousel">
                    <div class="carousel-inner">
                        <asp:Repeater ID="repeaterImagenes" runat="server">
                            <ItemTemplate>
                                <div class='carousel-item<%# (bool)Eval("IsFirst") ? " active" : "" %>'>
                                    <asp:Image ID="imgArticulo" runat="server" ImageUrl='<%# Eval("imagenUrl") %>' CssClass="d-block w-100" alt="Imagen del artículo" />
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <a class="carousel-control-prev" href="#carouselExample" role="button" data-bs-slide="prev">
                        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Previous</span>
                    </a>
                    <a class="carousel-control-next" href="#carouselExample" role="button" data-bs-slide="next">
                        <span class="carousel-control-next-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Next</span>
                    </a>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
