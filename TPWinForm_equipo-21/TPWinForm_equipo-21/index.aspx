<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="TPWinForm_equipo_21.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<style>
        .card:hover{
                box-shadow : -1px 9px 40px 2px #020202;
        }

        .card img{
            width:250px;
            height:250px;
        }
        .card-text.clase2:hover{
            transform: scale(1.2); 
        }
        .botonCarrito::after {
            content: none; 
        }
        .botonCarrito::before {
            content: none; 
        }
        
    </style>
    <!--Filtro lateral derecho-->
    <div class="offcanvas offcanvas-end text-bg-dark" tabindex="-1" id="offcanvasRight" aria-labelledby="offcanvasRightLabel">
        <div class="offcanvas-header">
            <h5 class="offcanvas-title" id="offcanvasRightLabel">Filtrado</h5>
            <button type="button" class="btn-close btn-close-white" data-bs-dismiss="offcanvas" aria-label="Close"></button>
        </div>
        <div class="offcanvas-body">

            <div class="containerbody" style="display:flex; flex-direction:column; justify-content: space-between; height: 100%;">
                <div class="apartado-superior" style="height: 45%;display: flex;flex-direction: column;justify-content: space-evenly;">
                    <div class="marca" style="display:flex; flex-direction:column;">
                        <label>MARCA:</label>
                        <asp:DropDownList ID="ddlMarca" runat="server"></asp:DropDownList>
                    </div>
                    <div class="categoria" style="display:flex; flex-direction:column;">
                        <label>CATEGORIA:</label>
                        <asp:DropDownList ID="ddlCategoria" runat="server"></asp:DropDownList>
                    </div>
                    <div class="categoria" style="display:flex; flex-direction:column;">
                        <label>Filtrar por precio:</label>
                        <asp:DropDownList ID="ddlPrecio" runat="server"></asp:DropDownList>
                    </div>
                    <div class="precio" style="display:flex; flex-direction:column;">
                        <label>PRECIO BUSCADO:</label>
                        <asp:TextBox ID="txtPrecio" runat="server">0</asp:TextBox>
                    </div>
                </div>
                <div class="apartado-inferior" style="display:flex; flex-direction:column">
                    <hr />
                    <div class="conjunto-botones" style="display:flex; flex-direction:row; justify-content: space-evenly;">
                        <div class="aplicar">
                            <asp:Button ID="BtnFilters" runat="server" Text="Aplicar Filtros" CssClass="btn btn-primary" OnClick="BtnFilters_Click"/>
                        </div>
                        <div class="no-aplicar">
                            <asp:Button ID="BtnSacarFiltros" runat="server" Text="Limpiar Filtros" CssClass="btn btn-primary" OnClick="BtnSacarFiltros_Click" AutoPostBack="false"/>
                        </div>
                    </div>
                </div>
            </div>

            

        </div>
    </div>


    <asp:Label ID="Label1" runat="server" Text=" "></asp:Label>

    <!--Filas y columnas de cards (container)-->
    <div class="row row-cols-1 row-cols-md-3 g-4">
            <asp:Repeater ID="repeater2" runat="server">
                <ItemTemplate>
                    <div class="col" style="margin-bottom: 30px;">
                        <div class="card" style="--bs-border-width: 3px; --bs-card-bg: #5A538E; color: #ffffff;">
                            <div style="display: flex;justify-content: center;">
                                <asp:Image ID="imgArticulo" runat="server" ImageUrl='<%# Eval("Imagen.imagenUrl") %>'/>
                            </div>
                            <hr />
                            <div class="card-body">
                                <h5 style="text-align:center; margin-bottom: 30px;" class="card-title"><%# Eval("nombre") %></h5>
                                <p class="card-text"><%# Eval("descripcion") %></p>
                                <p class="card-text">Categoria:<%# Eval("categoria") %></p>
                                <p class="card-text">Marca: <%# Eval("marca") %></p>
                                <p class="card-text">Precio: <%# Eval("precio") %></p>
                                <hr />
                                <div style="display: flex;justify-content: space-evenly;">
                                    <a class="card-text clase2" style="text-decoration: none;color: ghostwhite; transition: transform 0.3s;" href="DetalleArticulo.aspx?id=<%# Eval("id") %>">Ver Detalle</a>
                                    <div class="botonCarrito">
                                        <asp:Button ID="btnCarrito" runat="server" Text="Agregar al carrito 🛒" OnClick="btnCarrito_Click" CommandArgument='<%#Eval("id") %>' CommandName="idArticulo" CssClass="card-text"/>
                                    </div>
                                    
                                </div>
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
