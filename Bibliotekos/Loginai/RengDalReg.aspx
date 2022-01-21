<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RengDalReg.aspx.cs" Inherits="Loginai.RengDalReg" %>

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
            <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Registruoti Dalyvį" />
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click1" Text="Atsijungti" />
            <br />
            <br />
            <br />
            Vardas<br />
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            Pavardė<br />
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
            El. Paštas<br />
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <br />
            Tel. Nr<br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            Renginys<br />
            <asp:DropDownList ID="DropDownList1" runat="server">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="Button4" runat="server" Text="Button" OnClick="Button4_Click1" />
        </div>
    </form>
</body>
</html>
