<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Darbuotojai.aspx.cs" Inherits="Loginai.Darbuotojai" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button5" runat="server" Text="Pagrindinis" OnClick="Button5_Click" />
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Darbuotojai" />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Knygos" AutoPostBack="true"/>
            <asp:Button ID="Button4" runat="server" Text="Ataskaitos" OnClick="Button4_Click" />
            <br />
            DARBUOTOJAI<br />
            <asp:Button ID="Button6" runat="server" Text="Registracija" OnClick="Button6_Click" />
            <br />
        <asp:Table ID="Table1" runat="server" BorderColor="Black" BorderWidth="2px" GridLines="Both">
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">ID</asp:TableCell>
                <asp:TableCell runat="server">Vardas</asp:TableCell>
                <asp:TableCell runat="server">Pavardė</asp:TableCell>
                <asp:TableCell runat="server">Gimimo Data</asp:TableCell>
                <asp:TableCell runat="server">El. Paštas</asp:TableCell>
                <asp:TableCell runat="server">Telefonas</asp:TableCell>
                <asp:TableCell runat="server">Adresas</asp:TableCell>
                <asp:TableCell runat="server">Pareigos</asp:TableCell>
                <asp:TableCell runat="server">Veiksmai</asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        </div>
    </form>
</body>
</html>
