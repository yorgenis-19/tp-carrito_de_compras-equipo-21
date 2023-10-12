<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="TPWinForm_equipo_21.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<style>
        .card:hover{
                box-shadow : -1px 9px 40px -12px #808080;
        }

        .card img{
            height:250px;
            width: 250px;
        }
    </style>


    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

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
                            <asp:Button ID="btnCarrito" runat="server" Text="🛒" OnClick="btnCarrito_Click" CommandArgument='<%#Eval("id") %>' CommandName="idArticulo"/><td />
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
