<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addOrder.aspx.cs" Inherits="Loginai.administravimas.addOrder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Pridėti užsakymą</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" Text="Administravimo langas" OnClick="Button1_Click"/>
        </div>
        <br/>
        <div>
            <table>
                <tr><td>Data</td>
                <td><asp:TextBox ID="data" runat="server"></asp:TextBox></td></tr>

                <tr><td>Pavadinimas</td>
                <td><asp:TextBox ID="pavadinimas" runat="server"></asp:TextBox></td></tr>

                <tr><td>Autorius</td>
                <td><asp:TextBox ID="autorius" runat="server"></asp:TextBox></td></tr>

                <tr><td>Leidimas</td>
                <td><asp:TextBox ID="leidimas" runat="server"></asp:TextBox></td></tr>

                <tr><td>Tiekėjas</td>
                <td><asp:TextBox ID="tiekejas" runat="server"></asp:TextBox></td></tr>

                <tr><td>Kiekis</td>
                <td><asp:TextBox ID="kiekis" runat="server"></asp:TextBox></td></tr>

                <tr><td>Vnt. kaina</td>
                <td><asp:TextBox ID="vnt_kaina" runat="server"></asp:TextBox></td></tr>
            </table>
            <br />
            <asp:Button ID="Button2" runat="server" Text="Pridėti užsakymą" OnClick="Button2_Click"/>
        </div>
    </form>
</body>
</html>
