<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="TPWinForm_equipo_21.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .hidden{
            display:none;
        }
    </style>
    <asp:GridView runat="server" ID="dgvArticulos" CssClass="table" OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged" AutoGenerateColumns="false" DataKeyNames="id">
        <Columns>
            <asp:BoundField HeaderText="id" DataField="id"/>
            <asp:BoundField HeaderText="codigo" DataField="codigo" />
            <asp:BoundField HeaderText="nombre" DataField="nombre" />
            <asp:BoundField HeaderText="descripcion" DataField="descripcion" />
            <asp:BoundField HeaderText="marca" DataField="marca" />
            <asp:BoundField HeaderText="categoria" DataField="categoria" />
            <asp:BoundField HeaderText="precio" DataField="precio"  />
            <asp:CommandField ShowSelectButton="true" SelectText="Agregar al Carrito" HeaderText="Acción"/>
            
        </Columns>
    </asp:GridView>

    
</asp:Content>
