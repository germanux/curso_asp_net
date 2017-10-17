<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="nuevo_usuario.aspx.cs" Inherits="AplicacionWeb.nuevo_usuario" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Nuevo usario</title>
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">
</head>
<body>
    <div class="container">
    <h1>Nuevo usario</h1>
    <form id="form1" runat="server" >
        <div class="row">
            <div class="col-md-2"></div>
            <asp:Label runat="server" CssClass="col-md-4" Text="Nombre:" ToolTip="Nombre de persona"/>
            <asp:TextBox ID="TxtNombre" CssClass="col-md-4" runat="server" required="required" placeholder="Intruzca su nombre"  TabIndex="1" />
         </div>
        <div class="row">
            <div class="col-md-2"></div>
            <asp:Label runat="server" CssClass="col-md-4" Text="E-Mail:" ToolTip="E-Mail de persona"/>
            <asp:TextBox ID="TxtEmail" CssClass="col-md-4" runat="server" required="required" placeholder="Intruzca su email"  TabIndex="2" />            
         </div>
        <asp:Button ID="BtnEnviar" runat="server" Text="Enviar" OnClick="AlPulsarBotonEnviar"/>

        <!--
        <label>Año:</label>
        <input type="number" id="anio" name="anio" min="1850" max="2017" step="1" required value="1990" tabindex="5"/><br/>
        <label>Genero:</label><br/>
        <input type="radio" id="genero_h" name="genero" value="1" checked tabindex="6"/>Hombre<br />
        <input type="radio" id="genero_m" name="genero" value="2"  tabindex="7"/>Mujer<br />
        <input type="radio" id="genero_hr" name="genero" value="3"  tabindex="8"/>Hermafrodita<br />
        <input type="checkbox" id="nacional" name="nacional" value="true" checked="checked"  tabindex="9"/>Nacional<br />
        <input type="submit" id="enviar" name="enviar" value="Enviar"  tabindex="10"/>
        -->
    </form>

    </div>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>
</body>
</html>
