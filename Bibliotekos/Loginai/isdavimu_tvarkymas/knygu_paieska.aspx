<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="knygu_paieska.aspx.cs" Inherits="Loginai.isdavimu_tvarkymas.knygu_paieska" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="i_pagrindinis" runat="server" Text="Išdavimų sąrašas" OnClick="i_pagrindinis_Click" />
            <asp:Button ID="i_isdavimas" runat="server" Text="Išduoti knygą" OnClick="i_isdavimas_Click"/>
            <asp:Button ID="i_skaitytojai" runat="server" Text="Skaitytojų paieška"   OnClick="i_skaitytojai_Click"/>
            <asp:Button ID="i_apdovanojimai" runat="server" Text="Apdovanojimai"  OnClick="i_apdovanojimai_Click"/>
        </div>
        <br />
        <br/>
        Knygos pavadinimas:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="pavadinimo_laukas" runat="server"></asp:TextBox>
&nbsp;<br />
        <br />
        <br />
        <asp:Button ID="ieskoti" runat="server" Text="Ieškoti knygų" OnClick="i_ieskoti_Click"/>
        <br />
        <br/>
        <div>
            <asp:Table ID="knygos" runat="server" BorderColor="Black" BorderWidth="2px" GridLines="Both">
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server">Numeris</asp:TableCell>
                    <asp:TableCell runat="server">Pavadinimas</asp:TableCell>
                    <asp:TableCell runat="server">Autorius</asp:TableCell>
                    <asp:TableCell runat="server">Išleidimo data</asp:TableCell>
                    <asp:TableCell runat="server">Leidejas</asp:TableCell>
                    <asp:TableCell runat="server">Zanras</asp:TableCell>
                    <asp:TableCell runat="server">Busena</asp:TableCell>
                    <asp:TableCell runat="server">Puslapių sk</asp:TableCell>
                    <asp:TableCell runat="server">Komentaras</asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
    </form>
</body>
</html>
