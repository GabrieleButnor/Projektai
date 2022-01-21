<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cancelOrder.aspx.cs" Inherits="Loginai.administravimas.cancelOrder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ADMINISTRAVIMO POSISTEMĖ<br />
            <asp:Button ID="Button6" runat="server" Text="Įdarbinimas" OnClick="Button6_Click" />
            <asp:Button ID="Button7" runat="server" Text="Vartotojo redagavimas" OnClick="Button7_Click" />
            <asp:Button ID="Button8" runat="server" Text="Knygos užsakymas" OnClick="Button8_Click" />
            <asp:Button ID="Button9" runat="server" Text="Finansinė ataskaita" OnClick="Button9_Click" />
            <asp:Button ID="Button10" runat="server" Text="Darbuotojo ataskaita" OnClick="Button10_Click" />
            <br /><br />
        Ar tikrai norite atšaukti šį užsakymą?
        <asp:Table ID="Table1" runat="server" BorderColor="Black" BorderWidth="2px" GridLines="Both">
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">Užsakymo ID</asp:TableCell>
                <asp:TableCell runat="server">Data</asp:TableCell>
                <asp:TableCell runat="server">Pavadinimas</asp:TableCell>
                <asp:TableCell runat="server">Autorius</asp:TableCell>
                <asp:TableCell runat="server">Leidimas</asp:TableCell>
                <asp:TableCell runat="server">Tiekėjas</asp:TableCell>
                <asp:TableCell runat="server">Kiekis</asp:TableCell>
                <asp:TableCell runat="server">Vnt. kaina</asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:Button ID="Button1" runat="server" Text="Taip" OnClick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" Text="Grįžti" OnClick="Button2_Click" />
        </div>
    </form>
</body>
</html>
