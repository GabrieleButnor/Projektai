<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Report_B.aspx.cs" Inherits="Loginai.knygu_tvarkymas.Report_B" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="m_books" runat="server" Text="Knygu Sarasas" OnClick="m_books_Click"/>
            <asp:Button ID="m_add" runat="server" Text="Kurti knyga" OnClick="m_add_Click"/>
            <asp:Button ID="m_report_a" runat="server" Text="Nurasytu knygu ataskaita" OnClick="m_report_a_Click"/>
        </div>
        <br/>
        <div>
            <h1>Bendra knygu ataskaita</h1>
        </div>
        <br/>
        <div>
            <asp:Table ID="genre_stats_table" runat="server" BorderColor="Black" BorderWidth="2px" GridLines="Both">
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server">Zanras</asp:TableCell>
                    <asp:TableCell runat="server">Kiekis (Sk.)</asp:TableCell>
                    <asp:TableCell runat="server">Kiekis (%)</asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <br/>
            <asp:Table ID="quality_stats_table" runat="server" BorderColor="Black" BorderWidth="2px" GridLines="Both">
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server">Busena</asp:TableCell>
                    <asp:TableCell runat="server">Kiekis (Sk.)</asp:TableCell>
                    <asp:TableCell runat="server">Kiekis (%)</asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
        <div>
            <p>Geriausei islaikytas zanras: <asp:Label ID="best_genre" runat="server" Text=""></asp:Label>, didzioji sio zanro knygu dalis yra <asp:Label ID="best_genre1" runat="server" Text=""></asp:Label> busenos.</p>
            <asp:Table ID="best_genre3" runat="server" BorderColor="Black" BorderWidth="2px" GridLines="Both">
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server">Busena</asp:TableCell>
                    <asp:TableCell runat="server">Kiekis (Sk.)</asp:TableCell>
                    <asp:TableCell runat="server">Kiekis (%)</asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
    </form>
</body>
</html>
