<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm4.aspx.cs" Inherits="Loginai.WebForm4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Font-Size="22pt" Text="Prekės redagavimas"></asp:Label>
            <br />
            <br />
        </div>
        <asp:Label ID="Label2" runat="server" Font-Size="22pt" Text="Pavadinimas"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox1" runat="server" Font-Size="17pt" Width="500px"></asp:TextBox>
        <br />
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Font-Size="22pt" Text="Kaina"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox2" runat="server" Font-Size="17pt" Width="500px"></asp:TextBox>
        <br />
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Font-Size="22pt" Text="Kiekis"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox3" runat="server" Font-Size="17pt" Width="500px"></asp:TextBox>
        <br />
        <br />
        <br />
        <asp:Label ID="Label5" runat="server" Font-Size="22pt" Text="Apibūdinimas"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox4" runat="server" Font-Size="17pt" Height="106px" Width="500px" TextMode="MultiLine" Rows="10" ></asp:TextBox>
        <br />
        <br />
        <asp:Image ID="Image1" runat="server" />
        <br />
        <br />
        <p>
            <asp:Button ID="Button1" runat="server" Font-Size="20pt" OnClick="Button1_Click" Text="Pridėti prekę" />
        </p>
    </form>
</body>
</html>
