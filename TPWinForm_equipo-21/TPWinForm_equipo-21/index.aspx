<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="TPWinForm_equipo_21.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:GridView ID="dgvArticulos" CssClass="table" AutoGenerateColumns="false" runat="server">
        <Columns>
            <asp:BoundField HeaderText="codigo" DataField="codigo" />
            <asp:BoundField HeaderText="nombre" DataField="nombre" />
            <asp:BoundField HeaderText="descripcion" DataField="descripcion" />
            <asp:BoundField HeaderText="marca" DataField="marca" />
            <asp:BoundField HeaderText="categoria" DataField="categoria" />
            <asp:BoundField HeaderText="precio" DataField="precio" />

        </Columns>
    </asp:GridView>

</asp:Content>
