<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Loginai.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button5" runat="server" Text="Pagrindinis" OnClick="Button5_Click" />
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Darbuotojai" style="height: 26px" />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Knygos" AutoPostBack="true"/>
            <asp:Button ID="Button4" runat="server" Text="Ataskaitos" OnClick="Button4_Click" />
            <br />
            <br />
            Vartotojo Vardas<br />
            <asp:TextBox ID="TextBox1" runat="server" Height="16px"></asp:TextBox>
            <br />
            Slaptažodis<br />
            <asp:TextBox ID="TextBox2" runat="server" Height="16px"></asp:TextBox>
            <br />
            Pareigos<br />
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem Value="1">Administratorius</asp:ListItem>
                <asp:ListItem Value="2">Bibliotekininkas</asp:ListItem>
                <asp:ListItem Value="3">Renginiu org</asp:ListItem>
            </asp:DropDownList>
            <br />
            Vardas<br />
            <asp:TextBox ID="TextBox4" runat="server" Height="16px"></asp:TextBox>
            <br />
            Pavardė<br />
            <asp:TextBox ID="TextBox5" runat="server" Height="16px"></asp:TextBox>
            <br />
            Gimimo Dada<br />
            <asp:TextBox ID="TextBox6" runat="server" Height="16px"></asp:TextBox>
            <br />
            El. Paštas<br />
            <asp:TextBox ID="TextBox7" runat="server" Height="16px"></asp:TextBox>
            <br />
            Telefono Nr.<br />
            <asp:TextBox ID="TextBox8" runat="server" Height="16px"></asp:TextBox>
            <br />
            Adresas<br />
            <asp:TextBox ID="TextBox9" runat="server" Height="16px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="Button" />
        </div>
    </form>
</body>
</html>
