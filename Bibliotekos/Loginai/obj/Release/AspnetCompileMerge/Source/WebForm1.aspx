<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Loginai.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin-left: 600px">
        &nbsp;<br />
            <br />
            <br />
            <asp:Table ID="Table1" runat="server" Height="25px">
            </asp:Table>
            <br />
            <asp:Label ID="Label1" runat="server" Font-Size="22pt" Text="Vartotojo vardas"></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox1" runat="server" Font-Size="22pt"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Font-Size="22pt" Text="Slaptažodis"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
            <asp:TextBox ID="TextBox2" runat="server" Font-Size="22pt" TextMode="Password"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Font-Size="22pt" OnClick="Button1_Click" Text="Prisijungti" />
            <asp:Label ID="Label3" runat="server" Font-Size="22pt" ForeColor="#CC3300" Text="Pavadinimas arba slaptažodis netinkamas" Visible="False"></asp:Label>
            <br />
        </div>
    </form>
</body>
</html>
