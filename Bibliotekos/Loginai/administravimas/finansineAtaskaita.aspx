<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="finansineAtaskaita.aspx.cs" Inherits="Loginai.administravimas.finansineAtaskaita" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Darbuotojo ataskaita</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" Text="Administravimo langas" OnClick="Button1_Click"/>
        </div>
        <br/>
        <div>
            <asp:Table ID="Table1" runat="server" BorderColor="Black" BorderWidth="2px" GridLines="Both">
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">Bendros išlaidos darbuotojams</asp:TableCell>
                <asp:TableCell runat="server">Išlaidos administratoriams</asp:TableCell>
                <asp:TableCell runat="server">Išlaidos reng. organizatoriams</asp:TableCell>
                <asp:TableCell runat="server">Išlaidos bibliotekininkams</asp:TableCell>
                <asp:TableCell runat="server">Išlaidos užsakymams</asp:TableCell>
                <asp:TableCell runat="server">Bendros išlaidos</asp:TableCell>
            </asp:TableRow>
            </asp:Table>
        </div>
    </form>
</body>
</html>
