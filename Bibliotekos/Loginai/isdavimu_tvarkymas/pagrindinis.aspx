<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pagrindinis.aspx.cs" Inherits="Loginai.isdavimu_tvarkymas.pagrindinis" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="i_isdavimas" runat="server" Text="Išduoti knygą" OnClick="i_isdavimas_Click"/>
            <asp:Button ID="i_skaitytojai" runat="server" Text="Skaitytojų paieška"   OnClick="i_skaitytojai_Click"/>
            <asp:Button ID="i_knygos" runat="server" Text="Knygų paieška"  OnClick="i_knygos_Click" />
            <asp:Button ID="i_apdovanojimai" runat="server" Text="Apdovanojimai"  OnClick="i_apdovanojimai_Click"/>
        </div>
        <br/>
        <br/>
        <div>
            <asp:Table ID="isdavimai" runat="server" BorderColor="Black" BorderWidth="2px" GridLines="Both">
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server">ID</asp:TableCell>
                    <asp:TableCell runat="server">Išdavimo data</asp:TableCell>
                    <asp:TableCell runat="server">Grąžinimo data</asp:TableCell>
                    <asp:TableCell runat="server">Filialas</asp:TableCell>
                    <asp:TableCell runat="server">Būsena</asp:TableCell>
                    <asp:TableCell runat="server">Skaitytojas</asp:TableCell>
                    <asp:TableCell runat="server">Knyga</asp:TableCell>
                    <asp:TableCell runat="server">Veiksmai</asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>


    </form>
</body>
</html>