<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListaUsuariosLinq.aspx.cs" Inherits="WebForms_Favoritos.lista_usuarios_linq" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Lista de usuarios</title>
</head>
<body>
    <h1>Lista de usuarios</h1>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="LblNombre" runat="server" Text="Nombre: " Width="20em"></asp:Label>
            <asp:TextBox ID="TxtNombre" runat="server" Width="26.8em" TabIndex="1"></asp:TextBox>
            <asp:Button ID="BtnBuscar" runat="server" Text="Buscar"  TabIndex="2"
                OnClick="BtnBuscar_Click"/>
            <asp:GridView ID="GrdTodosUsuarios" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="ObjectDataSource_Todos" PageSize="5" Width="390px">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                    <asp:BoundField DataField="Anio" HeaderText="Anio" SortExpression="Anio" />
                </Columns>
            </asp:GridView>
            <asp:ListView ID="ListView1" runat="server" DataSourceID="ObjectDataSource_UsuariosPorNombre" GroupItemCount="3">
                <AlternatingItemTemplate>
                    <td runat="server" style="background-color: #FFFFFF;color: #284775;">Id:
                        <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                        <br />Nombre:
                        <asp:Label ID="NombreLabel" runat="server" Text='<%# Eval("Nombre") %>' />
                        <br />Anio:
                        <asp:Label ID="AnioLabel" runat="server" Text='<%# Eval("Anio") %>' />
                        <br /></td>
                </AlternatingItemTemplate>
                <EditItemTemplate>
                    <td runat="server" style="background-color: #999999;">Id:
                        <asp:TextBox ID="IdTextBox" runat="server" Text='<%# Bind("Id") %>' />
                        <br />Nombre:
                        <asp:TextBox ID="NombreTextBox" runat="server" Text='<%# Bind("Nombre") %>' />
                        <br />Anio:
                        <asp:TextBox ID="AnioTextBox" runat="server" Text='<%# Bind("Anio") %>' />
                        <br />
                        <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Actualizar" />
                        <br />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancelar" />
                        <br /></td>
                </EditItemTemplate>
                <EmptyDataTemplate>
                    <table runat="server" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                        <tr>
                            <td>No se han devuelto datos.</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <EmptyItemTemplate>
<td runat="server" />
                </EmptyItemTemplate>
                <GroupTemplate>
                    <tr id="itemPlaceholderContainer" runat="server">
                        <td id="itemPlaceholder" runat="server"></td>
                    </tr>
                </GroupTemplate>
                <InsertItemTemplate>
                    <td runat="server" style="">Id:
                        <asp:TextBox ID="IdTextBox" runat="server" Text='<%# Bind("Id") %>' />
                        <br />Nombre:
                        <asp:TextBox ID="NombreTextBox" runat="server" Text='<%# Bind("Nombre") %>' />
                        <br />Anio:
                        <asp:TextBox ID="AnioTextBox" runat="server" Text='<%# Bind("Anio") %>' />
                        <br />
                        <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insertar" />
                        <br />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Borrar" />
                        <br /></td>
                </InsertItemTemplate>
                <ItemTemplate>
                    <td runat="server" style="background-color: #E0FFFF;color: #333333;">Id:
                        <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                        <br />Nombre:
                        <asp:Label ID="NombreLabel" runat="server" Text='<%# Eval("Nombre") %>' />
                        <br />Anio:
                        <asp:Label ID="AnioLabel" runat="server" Text='<%# Eval("Anio") %>' />
                        <br /></td>
                </ItemTemplate>
                <LayoutTemplate>
                    <table runat="server">
                        <tr runat="server">
                            <td runat="server">
                                <table id="groupPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                                    <tr id="groupPlaceholder" runat="server">
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr runat="server">
                            <td runat="server" style="text-align: center;background-color: #5D7B9D;font-family: Verdana, Arial, Helvetica, sans-serif;color: #FFFFFF">
                                <asp:DataPager ID="DataPager1" runat="server" PageSize="12">
                                    <Fields>
                                        <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" />
                                    </Fields>
                                </asp:DataPager>
                            </td>
                        </tr>
                    </table>
                </LayoutTemplate>
                <SelectedItemTemplate>
                    <td runat="server" style="background-color: #E2DED6;font-weight: bold;color: #333333;">Id:
                        <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                        <br />Nombre:
                        <asp:Label ID="NombreLabel" runat="server" Text='<%# Eval("Nombre") %>' />
                        <br />Anio:
                        <asp:Label ID="AnioLabel" runat="server" Text='<%# Eval("Anio") %>' />
                        <br /></td>
                </SelectedItemTemplate>
            </asp:ListView>
        </div>
        <asp:ObjectDataSource ID="ObjectDataSource_Todos" runat="server" SelectMethod="ListaUsuarios" TypeName="WebForms_Favoritos.GestionUsuarios">
            <SelectParameters>
                <asp:Parameter Name="nombre" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSource_UsuariosPorNombre" runat="server" SelectMethod="ListaUsuarios" TypeName="WebForms_Favoritos.GestionUsuarios">
            <SelectParameters>
                <asp:ControlParameter ControlID="TxtNombre" Name="nombre" PropertyName="Text" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </form>
</body>
</html>
