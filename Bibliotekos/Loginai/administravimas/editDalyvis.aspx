<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editDalyvis.aspx.cs" Inherits="Loginai.administravimas.editDalyvis" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Redaguoti dalyvį</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" Text="Administravimo langas" OnClick="Button1_Click"/>
        </div>
        <br/>
        <div>
            <table>
                <tr><td>Vardas</td>
                <td><asp:TextBox ID="Vardas" runat="server"></asp:TextBox></td></tr>

                <tr><td>Pavardė</td>
                <td><asp:TextBox ID="Pavarde" runat="server"></asp:TextBox></td></tr>

                <tr><td>El. paštas</td>
                <td><asp:TextBox ID="ElPastas" runat="server"></asp:TextBox></td></tr>

                <tr><td>Telefono nr.</td>
                <td><asp:TextBox ID="TelNr" runat="server"></asp:TextBox></td></tr>
            </table>
            <br />
            <asp:Button ID="Button2" runat="server" Text="Redaguoti" OnClick="Button2_Click"/>
        </div>
    </form>
</body>
</html>
