<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="TPWinForm_equipo_21.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<style>
        .card:hover{
                box-shadow : -1px 9px 40px -12px #808080;
        }

        .card img{
            width:250px;
            height:250px;
        }
    </style>

        <div class="offcanvas offcanvas-end text-bg-dark" tabindex="-1" id="offcanvasRight" aria-labelledby="offcanvasRightLabel">
          <div class="offcanvas-header">
            <h5 class="offcanvas-title" id="offcanvasRightLabel">Filtrado</h5>
            <button type="button" class="btn-close btn-close-white" data-bs-dismiss="offcanvasDark" aria-label="Close"></button>
          </div>
          <div class="offcanvas-body">
            <asp:Label>ID PRODUCTO:</asp:Label>
             <asp:TextBox runat="server" />
             <asp:Label>MARCA:</asp:Label>
             <asp:Label>PRECIO:</asp:Label>
          </div>
    </div>



    <asp:Label ID="Label1" runat="server" Text=" "></asp:Label>

<div class="row row-cols-1 row-cols-md-3 g-4">
        <asp:Repeater ID="repeater2" runat="server">
            <ItemTemplate>
                <div class="col">
                    <div class="card">
                        <asp:Image ID="imgArticulo" runat="server" ImageUrl='<%# Eval("Imagen.imagenUrl") %>'/>
                        <div class="card-body">
                            <h5 class="card-title"><%# Eval("nombre") %></h5>
                            <p class="card-text"><%# Eval("descripcion") %></p>
                            <p class="card-text">Categoria:<%# Eval("categoria") %></p>
                            <p class="card-text">Marca: <%# Eval("marca") %></p>
                            <p class="card-text">Precio: <%# Eval("precio") %></p>
                            <a class="card-text" href="DetalleArticulo.aspx?id=<%# Eval("id") %>">Ver Detalle</a>
                            <asp:Button ID="btnCarrito" runat="server" Text="Agregar al carrito 🛒" OnClick="btnCarrito_Click" CommandArgument='<%#Eval("id") %>' CommandName="idArticulo" CssClass="card-text"/><td />
                        </div>
                    </div>
                </div>
            </ItemTemplate>
    </asp:Repeater>
</div>

<script type="text/javascript">
    $('.card').hover(
        function () {
            $(this).animate({
                marginTop: "-=1%",
                marginBottom : "+=1%"
            },200)
        },
        function () {
            $(this).animate({
                marginTop: "+=1%",
                marginBottom : "-=1%"
            })
        }
    )
</script>    


</asp:Content>
