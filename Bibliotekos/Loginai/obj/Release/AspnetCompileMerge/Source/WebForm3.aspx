<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="Loginai.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Font-Size="22pt" Text="Prekės pridėjimas"></asp:Label>
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
        <asp:Label ID="Label7" runat="server" Font-Size="22pt" Text="Kategorija"></asp:Label>
        <br />
        <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true">
            <asp:ListItem Value="2">Pagrindinis</asp:ListItem>
            <asp:ListItem Value="11">Aušinimo sistemos</asp:ListItem>
            <asp:ListItem Value="14">Uždegimo sistemos</asp:ListItem>
            <asp:ListItem Value="24">Diržinės pavaros sistema</asp:ListItem>
            <asp:ListItem Value="26">Elektors instaliacijos sitema</asp:ListItem>
            <asp:ListItem Value="36">Salonas ir išorė</asp:ListItem>
            <asp:ListItem Value="51">Kondicionavimo sistemos</asp:ListItem>
            <asp:ListItem Value="67">Vairo mechanizmas</asp:ListItem>
            <asp:ListItem Value="68">Važiuoklės dalys</asp:ListItem>
            <asp:ListItem Value="81">Sankaba ir pavarų dėžė</asp:ListItem>
            <asp:ListItem Value="87">Stabdžių sistemos</asp:ListItem>
            <asp:ListItem Value="96">Trosai ir laidai</asp:ListItem>
            <asp:ListItem Value="110">Variklis</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="DropDownList2" runat="server">
        </asp:DropDownList>
        <br />
        <br />
        <br />
        <asp:Label ID="Label6" runat="server" Font-Size="22pt" Text="Nuotraukos įkėlimas"></asp:Label>
        <br />
        <asp:FileUpload ID="FileUpload1" runat="server" accept =".png, .jpg, .jpeg" />
        <br />
        <br />
        <p>
            <asp:Button ID="Button1" runat="server" Font-Size="20pt" OnClick="Button1_Click" Text="Pridėti prekę" />
        </p>
    </form>
</body>
</html>
