﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio1.aspx.cs" Inherits="TP4_GRUPO_3.Ejercicio1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Ejercicio 1</title>
</head>
<body>
    <form id="form2" runat="server">
        <div style="margin:1em;">
            <asp:Label ID="Label1" runat="server" Font-Underline="True" Text="DESTINO INICIO"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="PROVINCIA: "></asp:Label>
            <asp:DropDownList ID="DDLInicioProvincias" runat="server" TabIndex="1" AutoPostBack="True" OnSelectedIndexChanged="DDLInicioProvincias_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="LOCALIDAD: "></asp:Label>
             <asp:DropDownList ID="DDLInicioLocalidades" runat="server" TabIndex="2">
            </asp:DropDownList>
            <asp:Label ID="lblError" runat="server"></asp:Label>
        </div>
         <div style="margin:1em;">
            <asp:Label ID="Label4" runat="server" Font-Underline="True" Text="DESTINO FINAL"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label5" runat="server" Text="PROVINCIA: "></asp:Label>
            <asp:DropDownList ID="DDLFinalProvincias" runat="server" TabIndex="3" AutoPostBack="True" OnSelectedIndexChanged="DDLFinalProvincias_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="Label6" runat="server" Text="LOCALIDAD: "></asp:Label>
             <asp:DropDownList ID="DDLFinalLocalidades" runat="server" TabIndex="4">
            </asp:DropDownList>
        </div>
    </form>
</body>
</html>