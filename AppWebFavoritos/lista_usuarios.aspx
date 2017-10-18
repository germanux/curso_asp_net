<%@ Page Language="C#" AutoEventWireup="true" CodeFile="lista_usuarios.aspx.cs" Inherits="lista_usuarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Label ID="LblNombre" runat="server" Text="Nombre" Width="200px"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" Width="226px"></asp:TextBox>
    
     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SQL_BD_Favoritos">
         <Columns>
             <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
             <asp:BoundField DataField="nombre" HeaderText="nombre" SortExpression="nombre" />
             <asp:BoundField DataField="anio" HeaderText="anio" SortExpression="anio" />
         </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SQL_BD_Favoritos" runat="server" ConnectionString="<%$ ConnectionStrings:cadenaConex_bd_favoritos %>" SelectCommand="SELECT [Id], [nombre], [anio] FROM [usuario] ORDER BY [nombre]"></asp:SqlDataSource>
    </form>
    
     </body>
</html>
