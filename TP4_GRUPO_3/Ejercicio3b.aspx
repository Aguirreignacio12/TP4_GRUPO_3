<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio3b.aspx.cs" Inherits="TP4_GRUPO_3.Ejercicio3b" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="LblListadoLibros" runat="server" Text="Listado de libros"></asp:Label>
            <asp:GridView ID="GVLibros" runat="server"></asp:GridView>
        </div>
         <asp:LinkButton ID="LblVolverAtras" runat="server"  OnClick="LblVolverAtras_Click">Consultar otro tema</asp:LinkButton>
    </form>
</body>
</html>
