<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="apdovanojimai.aspx.cs" Inherits="Loginai.isdavimu_tvarkymas.apdovanojimai" %>

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
            <asp:Button ID="i_knygos" runat="server" Text="Knygų paieška"  OnClick="i_knygos_Click" />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Label" Font-Size="X-Large"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Label" Font-Size="Large" ForeColor ="Blue"></asp:Label>
            <br />
            <br />
         <div>
           <table>
             <tr><td>Sudarymo data</td>
             <td><asp:TextBox textmode="Date" ID="sudarymo_data" runat="server"></asp:TextBox></td></tr>
             <tr><td>Pavadinimas</td>
             <td><asp:TextBox ID="pavadinimas" runat="server"></asp:TextBox></td></tr>
             <tr><td>Komentaras</td>
             <td><asp:TextBox ID="komentaras" runat="server"></asp:TextBox></td></tr>
             <tr><td>Atsakingas darbuotojas<br />
                 </td>
             <td><asp:DropDownList ID="_darbuotojas" runat="server"></asp:DropDownList></td></tr>
           </table>
            <br />
            <asp:Button ID="generavimas" runat="server" Text="Generuoti skaitytojus" OnClick="generuoti_Click"/>
             <br />
             <br />
             <asp:Label ID="Label3" runat="server" Text="Label" ForeColor ="red" visible =" false"></asp:Label>
            <br />
        </div>
            <asp:Table ID="apdovanoti_skaitytojai" runat="server" BorderColor="Black" BorderWidth="2px" GridLines="Both">
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server">Numeris</asp:TableCell>
                    <asp:TableCell runat="server">Vardas</asp:TableCell>
                    <asp:TableCell runat="server">Pavardė</asp:TableCell>
                    <asp:TableCell runat="server">Elektroninis paštas</asp:TableCell>
                    <asp:TableCell runat="server">Telefonas</asp:TableCell>
                    <asp:TableCell runat="server">Gimimo data</asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Label" ForeColor ="red" visible =" false"></asp:Label>
            <br />
            <asp:Button ID="siuntimas" runat="server" Text="Išsaugoti apdovanojimą" OnClick="siuntimas_Click"/>
            </div>
    </form>
</body>
</html>
