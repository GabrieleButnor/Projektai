<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="knygos_pratesimas.aspx.cs" Inherits="Loginai.isdavimu_tvarkymas.knygos_pratesimas" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="i_pagrindinis" runat="server" Text="Išdavimų sąrašas" OnClick="i_pagrindinis_Click" />
            <asp:Button ID="i_isdavimas" runat="server" Text="Išduoti knygą" OnClick="i_isdavimas_Click"/>
            <asp:Button ID="i_skaitytojai" runat="server" Text="Skaitytojų paieška" OnClick="i_skaitytojai_Click"  />
            <asp:Button ID="i_knygos" runat="server" Text="Knygų paieška" OnClick="i_knygos_Click"  />
            <asp:Button ID="i_apdovanojimai" runat="server" Text="Apdovanojimai" OnClick="i_apdovanojimai_Click" />
        </div>
            <br/>
        <div>
            <table>
                <tr><td>Išdavimo data</td>
                <td><asp:TextBox textmode="Date" ID="isdavimo_data" runat="server" Enabled ="false"></asp:TextBox></td></tr>

                <tr><td>Grąžinimo data</td>
                <td><asp:TextBox textmode="Date" ID="grazinimo_data" runat="server"></asp:TextBox></td></tr>

                <tr><td>Filialas</td>
                <td><asp:TextBox ID="filialas" runat="server" Enabled ="false"></asp:TextBox></td></tr>

                <tr><td>Būsena</td>
                <td><asp:TextBox ID="busena" runat="server" Enabled ="false"></asp:TextBox></td></tr>

                <tr><td>Skaitytojas</td>
                <td><asp:TextBox ID="_skaitytojas" runat="server" Enabled ="false"></asp:TextBox></td></tr>
                
                <tr><td>Knyga</td>
                <td><asp:TextBox ID="_knyga" runat="server" Enabled ="false"></asp:TextBox></td></tr>

                <tr><td>Atsakingas darbuotojas</td>
                <td><asp:DropDownList ID="_darbuotojas" runat="server"></asp:DropDownList></td></tr>

            </table>
            <br />
            <asp:Button ID="pratesti" runat="server" Text="Pratęsti" OnClick="pratesti_Click"/>
            <br />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Neteisingai pasirinkta data" ForeColor ="red" visible =" false"></asp:Label>
        </div>

    </form>
</body>
</html>

