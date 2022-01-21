<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RengKur.aspx.cs" Inherits="Loginai.RengKur" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" Text="Pagrindinis" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" Text="Sukurti Renginį" OnClick="Button2_Click" />
            <asp:Button ID="Button5" runat="server" OnClick="Button4_Click" Text="Registruoti Dalyvį" />
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click1" style="height: 26px" Text="Atsijungti" />
            <br />
            <br />
            <br />
            Tipas<br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            Renginio Data<br />
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            Vieta<br />
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
            Pavadinimas<br />
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <br />
            Laikas<br />
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            <br />
            Aprasas<br />
            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button4" runat="server" Text="Button" OnClick="Button4_Click1" />
            <br />
        </div>
    </form>
</body>
</html>
