<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="skaitytoju_paieska.aspx.cs" Inherits="Loginai.isdavimu_tvarkymas.skaitytoju_paieska" %>

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
            <asp:Button ID="i_knygos" runat="server" Text="Knygų paieška"  OnClick="i_knygos_Click" />
            <asp:Button ID="i_apdovanojimai" runat="server" Text="Apdovanojimai"  OnClick="i_apdovanojimai_Click"/>
        </div>
        <br />
        <br/>
        Skaitytojo vardas:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="vardo_laukas" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Skaitytojo pavardė:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="pavardes_laukas" runat="server"></asp:TextBox>
        <br />
        <br />
        <br />
        <asp:Button ID="ieskoti" runat="server" Text="Ieškoti skaitytojų" OnClick="i_ieskoti_Click"/>
        <br />
        <br/>
        <div>
            <asp:Table ID="skaitytojai" runat="server" BorderColor="Black" BorderWidth="2px" GridLines="Both">
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server">Numeris</asp:TableCell>
                    <asp:TableCell runat="server">Vardas</asp:TableCell>
                    <asp:TableCell runat="server">Pavardė</asp:TableCell>
                    <asp:TableCell runat="server">Elektroninis paštas</asp:TableCell>
                    <asp:TableCell runat="server">Telefonas</asp:TableCell>
                    <asp:TableCell runat="server">Gimimo data</asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
    </form>
</body>
</html>
