<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="TPWinForm_equipo_21.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


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
            <th>Carrito</th>
        </tr>
    </thead>
    <tbody>
        <asp:Repeater ID="repeaterArticulos" runat="server">
            <ItemTemplate>
                <tr>
                    <td class="d-none" name="id"<%# Eval("id") %></td>
                    <td><%# Eval("codigo") %></td>
                    <td><%# Eval("nombre") %></td>
                    <td><%# Eval("descripcion") %></td>
                    <td><%# Eval("marca") %></td>
                    <td><%# Eval("categoria") %></td>
                    <td><%# Eval("precio") %></td>
                    <td><a href="DetalleArticulo.aspx?id<%# Eval("id") %>">Ver Detalle</a></td>
                    <td><asp:Button ID="btnCarrito" runat="server" Text="🛒" OnClick="btnCarrito_Click" CommandArgument='<%#Eval("id") %>' CommandName="idArticulo"/></td> 
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </tbody>
</table>

    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
</asp:Content>
