<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="DetalleArticulo.aspx.cs" Inherits="TPWinForm_equipo_21.DetalleArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .carousel-inner .carousel-item img {
            width: 30%;
            height: auto;
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




    <asp:Label ID="Label1" runat="server" Text=" "></asp:Label>

<div class="container mt-5">
    <div class="row">
        <!-- Detalles del producto (primera mitad) -->
        <div class="col-md-6">
            <h2>Detalle de producto</h2>
            <div>
                Nombre: <asp:Label ID="lblNombreArticulo" runat="server" Text="" CssClass="font-weight-bold"></asp:Label><br />
                Descripcion: <asp:Label ID="lblDescripcionArticulo" runat="server" Text=""></asp:Label><br />
                Categoria: <asp:Label ID="lblCategoriaArticulo" runat="server" Text=""></asp:Label><br />
                Marca: <asp:Label ID="lblMarcaArticulo" runat="server" Text=""></asp:Label><br />
                Precio: <asp:Label ID="lblPrecioArticulo" runat="server" Text="" CssClass="font-weight-bold"></asp:Label>
                <div class="botonCarrito mt-3">
                    <asp:Button ID="btnCarrito" runat="server" Text="Agregar al carrito 🛒" OnClick="btnCarrito_Click" CssClass="btn btn-primary" />
                </div>
            </div>
        </div>
        <!-- Carrusel de imágenes (segunda mitad) -->
        <div class="col-md-6">
            <div id="carouselExample" class="carousel slide" data-bs-ride="carousel">
                <div class="carousel-inner">
                    <asp:Repeater ID="repeaterImagenes" runat="server" >
                        <ItemTemplate>
                            <div class='carousel-item<%# (bool)Eval("IsFirst") ? " active" : "" %>'>
                                <asp:Image ID="imgArticulo" runat="server" ImageUrl='<%# Eval("imagenUrl") %>' CssClass="d-block w-100 artImagen" alt="No se pudo cargar la imagen" />
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
