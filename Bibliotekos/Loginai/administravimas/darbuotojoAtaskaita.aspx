<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="darbuotojoAtaskaita.aspx.cs" Inherits="Loginai.administravimas.darbuotojoAtaskaita" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Darbuotojo ataskaita</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" Text="Administravimo langas" OnClick="Button1_Click"/>
        </div>
        <br/>
        <div>
            <asp:Table ID="Table1" runat="server" BorderColor="Black" BorderWidth="2px" GridLines="Both">
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">ID</asp:TableCell>
                <asp:TableCell runat="server">Vardas</asp:TableCell>
                <asp:TableCell runat="server">Pavardė</asp:TableCell>
                <asp:TableCell runat="server">Gimimo Data</asp:TableCell>
                <asp:TableCell runat="server">El. Paštas</asp:TableCell>
                <asp:TableCell runat="server">Telefonas</asp:TableCell>
                <asp:TableCell runat="server">Adresas</asp:TableCell>
                <asp:TableCell runat="server">Pareigos</asp:TableCell>
            </asp:TableRow>
            </asp:Table>
            <br />
            Etatas:
            <asp:TextBox ID="etatas" runat="server"></asp:TextBox>
            <asp:Button ID="Button2" runat="server" Text="Skaičiuoti atlyginimą" OnClick="Button2_Click"/>
            <br />
            <asp:Table ID="Table2" runat="server" BorderColor="Black" BorderWidth="2px" GridLines="Both">
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">Suma</asp:TableCell>
                <asp:TableCell runat="server">Suma (padauginta iš etato)</asp:TableCell>
                <asp:TableCell runat="server">Suma (atskaičius mokęsčius)</asp:TableCell>
            </asp:TableRow>
            </asp:Table>
        </div>
    </form>
</body>
</html>
