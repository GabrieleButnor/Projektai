<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Loginai.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Prekiu pridejimas" AutoPostBack="true"/>
        <br />
        <br />
        <br />
        <asp:Table ID="Table1" runat="server" BorderColor="Black" BorderWidth="2px" GridLines="Both">
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">Pavadinimas</asp:TableCell>
                <asp:TableCell runat="server">Kaina</asp:TableCell>
                <asp:TableCell runat="server">Kiekis</asp:TableCell>
                <asp:TableCell runat="server">Apibudinimas</asp:TableCell>
                <asp:TableCell runat="server">Nuotrauka</asp:TableCell>
                <asp:TableCell runat="server">Veiksmai</asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </form>
</body>
</html>
