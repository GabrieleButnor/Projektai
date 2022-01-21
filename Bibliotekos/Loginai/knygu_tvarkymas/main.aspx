<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="Loginai.knygu_tvarkymas.main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="m_add" runat="server" Text="Kurti Nauja Knyga" OnClick="m_add_Click" />
            <asp:Button ID="m_report_a" runat="server" Text="Nurasytu knygu ataskaita" OnClick="m_report_a_Click" />
            <asp:Button ID="m_report_b" runat="server" Text="Bedra knygu ataskaita" OnClick="m_report_b_Click" />
        </div>
        <br/>
        <div>
            <asp:DropDownList ID="filtrai" runat="server">
            </asp:DropDownList>
            <asp:Button ID="filter" runat="server" Text="Filtruoti" OnClick="filter_Click" />
        </div>
        <br/>
        <div>
            <asp:Table ID="books" runat="server" BorderColor="Black" BorderWidth="2px" GridLines="Both">
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server">ID</asp:TableCell>
                    <asp:TableCell runat="server">Pavadinimas</asp:TableCell>
                    <asp:TableCell runat="server">Autorius</asp:TableCell>
                    <asp:TableCell runat="server">Isleidimo Data</asp:TableCell>
                    <asp:TableCell runat="server">Leidykla</asp:TableCell>
                    <asp:TableCell runat="server">Zanras</asp:TableCell>
                    <asp:TableCell runat="server">Busena</asp:TableCell>
                    <asp:TableCell runat="server">Puslapiu skaicius</asp:TableCell>
                    <asp:TableCell runat="server">Papildoma info</asp:TableCell>
                    <asp:TableCell runat="server">Salinti?</asp:TableCell>
                    <asp:TableCell runat="server">Redaguoti</asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
    </form>
</body>
</html>
