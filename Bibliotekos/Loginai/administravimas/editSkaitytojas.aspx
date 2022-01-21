<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editSkaitytojas.aspx.cs" Inherits="Loginai.administravimas.editSkaitytojas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Redaguoti skaitytoją</title>
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
                <td><asp:TextBox ID="vardas" runat="server"></asp:TextBox></td></tr>

                <tr><td>Pavardė</td>
                <td><asp:TextBox ID="pavarde" runat="server"></asp:TextBox></td></tr>

                <tr><td>El. paštas</td>
                <td><asp:TextBox ID="el_pastas" runat="server"></asp:TextBox></td></tr>

                <tr><td>Telefono nr.</td>
                <td><asp:TextBox ID="telefono_nr" runat="server"></asp:TextBox></td></tr>

                <tr><td>Gimimo data</td>
                <td><asp:TextBox ID="gimimo_data" runat="server"></asp:TextBox></td></tr>
            </table>
            <br />
            <asp:Button ID="Button2" runat="server" Text="Redaguoti" OnClick="Button2_Click"/>
        </div>
    </form>
</body>
</html>
