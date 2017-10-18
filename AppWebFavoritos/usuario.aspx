<%@ Page Language="C#" AutoEventWireup="true" CodeFile="usuario.aspx.cs" Inherits="usuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Nombre" Width="150px"></asp:Label>
            <asp:TextBox ID="TxtNombre" runat="server" Width="222px" ></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label2" runat="server" Text="Anio" Width="150px"></asp:Label>
            <asp:TextBox ID="TxtAnio" runat="server" Width="221px"></asp:TextBox>
        </div>
        <asp:Button ID="BtnEnviar" runat="server" Text="CREAR" Width="380px" BackColor="#66FF66" BorderColor="#000099" BorderStyle="Groove" BorderWidth="5px" Height="52px" OnClick="BtnEnviar_Click" /><hr />
        <asp:ListBox ID="LstMensajes" runat="server" Width="386px"></asp:ListBox>
    </form>
</body>
</html>
