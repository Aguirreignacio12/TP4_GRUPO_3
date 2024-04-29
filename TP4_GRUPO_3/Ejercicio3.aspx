<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio3.aspx.cs" Inherits="TP4_GRUPO_3.Ejercicio3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="LblSeleccionarTema" runat="server" Text="Seleccionar Tema: "></asp:Label>
            <asp:DropDownList ID="DDLTemas" runat="server"></asp:DropDownList>
            </div>
        <asp:LinkButton ID="LblVerLibros" runat="server" OnClick="LblVerLibros_Click">Ver libros</asp:LinkButton>
          
    </form>
</body>
</html>
