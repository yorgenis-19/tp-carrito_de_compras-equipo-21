<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="TPWinForm_equipo_21.Carrito" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%
        List<TPWinForm_equipo_21.Models.Articulo> carrito = new List<TPWinForm_equipo_21.Models.Articulo>();
        carrito = (List<TPWinForm_equipo_21.Models.Articulo>)Session["Carrito"];
        if(carrito.Count == 0)
        {
            Response.Redirect("index.aspx");
        }
        %>

    <div class="alertita" id="alertita" style="display: flex; justify-content: flex-start;">
            <asp:Label ID="Label1" runat="server" Text=" "></asp:Label>
    </div>
    <table class="table table-bordered">
    <thead>
        <tr>
            <th class="d-none">Id</th>
            <th>Codigo</th>
            <th>Nombre</th>
            <th>Descripción</th>
            <th>Marca</th>
            <th>Categoría</th>
            <th>Precio</th>
            <th>Ver Más</th>
            <th>Quitar</th>
        </tr>
    </thead>
    <tbody>
        <asp:Repeater ID="repeaterCarrito" runat="server">
                <ItemTemplate>
                    <tr>
                        <td class="d-none" name="id"<%# Eval("id") %></td>
                        <td><%# Eval("codigo") %></td>
                        <td><%# Eval("nombre") %></td>
                        <td><%# Eval("descripcion") %></td>
                        <td><%# Eval("marca") %></td>
                        <td><%# Eval("categoria") %></td>
                        <td><%# Eval("precio") %></td>
                        <td><a href="DetalleArticulo.aspx?id=<%# Eval("id") %>">Ver Detalle</a></td>
                        <td><asp:Button ID="btnQuitar" runat="server" Text="X" OnClick="btnQuitar_Click" CommandArgument='<%#Eval("id") %>' CommandName="idArticulo"/></td> 
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
        <tfoot>
            <tr>
                <td>Total</td>
                <td><asp:Label ID="lblPrecioTotal" runat="server" Text="0"></asp:Label></td>
                <td><asp:Button ID="btnComprar" runat="server" Text="Comprar" OnClick="btnComprar_Click"/></td>
            </tr>
        </tfoot>
    </table>


</asp:Content>
