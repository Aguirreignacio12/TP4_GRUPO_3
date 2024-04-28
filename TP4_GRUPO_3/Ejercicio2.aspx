<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio2.aspx.cs" Inherits="TP4_GRUPO_3.Ejercicio2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Ejercicio2</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin:2em;">
            <table>
                <tr>
                    <td>
                        <asp:Label ID="LblProducto" runat="server" Text="IdProducto"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="DDLProducto" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                            <asp:ListItem>Igual a:</asp:ListItem>
                            <asp:ListItem>Mayor a</asp:ListItem>
                            <asp:ListItem>Menor a</asp:ListItem>
                        </asp:DropDownList></td>
                    <td>
                        <asp:TextBox ID="TxtBoxProducto" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblCategoria" runat="server" Text="IdCategoria"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="DDLCategoria" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                            <asp:ListItem>Igual a:</asp:ListItem>
                        </asp:DropDownList></td>
                    <td>
                        <asp:TextBox ID="TxtBoxCategoria" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="BtnFiltro" runat="server" Text="Filtrar" /></td>
                    <td>
                        <asp:Button ID="BtnQuitarFiltro" runat="server" Text="Quitar filtro" OnClick="BtnQuitarFiltro_Click" /></td>
                </tr>
            </table>
        </div>
    
        <asp:GridView ID="GvProductos" runat="server"></asp:GridView>
    </form>
</body>
</html>
