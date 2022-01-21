<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dalyviai.aspx.cs" Inherits="Loginai.Dalyviai" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" Text="Pagrindinis" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" Text="Sukurti Renginį" OnClick="Button2_Click" />
            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Registruoti Dalyvį" />
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click1" style="height: 26px" Text="Atsijungti" />
            <br />
            <br />
        <asp:Table ID="Table1" runat="server" BorderColor="Black" BorderWidth="2px" GridLines="Both">
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">ID</asp:TableCell>
                <asp:TableCell runat="server">Renginio ID</asp:TableCell>
                <asp:TableCell runat="server">Vardas</asp:TableCell>
                <asp:TableCell runat="server">Pavarde</asp:TableCell>
                <asp:TableCell runat="server">El pastas</asp:TableCell>
                <asp:TableCell runat="server">Telefono Nr</asp:TableCell>

            </asp:TableRow>
        </asp:Table>
        </div>
    </form>
</body>
</html>
