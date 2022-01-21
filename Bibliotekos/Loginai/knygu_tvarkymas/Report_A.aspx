<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Report_A.aspx.cs" Inherits="Loginai.knygu_tvarkymas.Report_A" %>

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
            <asp:Button ID="m_report_b" runat="server" Text="Bedra knygu ataskaita" OnClick="m_report_b_Click"/>
        </div>
        <br/>
        <div>
            <h1>Nurasytu knygu ataskaita</h1>
        </div>
        <br/>
        <div>
            <asp:Table ID="del_stats_table" runat="server" BorderColor="Black" BorderWidth="2px" GridLines="Both">
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server">Zanras</asp:TableCell>
                    <asp:TableCell runat="server">Pasalinta</asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
    </form>
</body>
</html>
