<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="Loginai.administravimas.Darbuotojai" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ADMINISTRAVIMO POSISTEMĖ<br />
            <asp:Button ID="Button6" runat="server" Text="Įdarbinimas" OnClick="Button6_Click" />
            <asp:Button ID="Button8" runat="server" Text="Knygos užsakymas" OnClick="Button8_Click" />
            <asp:Button ID="Button9" runat="server" Text="Finansinė ataskaita" OnClick="Button9_Click" />
            <br /><br />
        Darbuotojai
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
                <asp:TableCell runat="server">Veiksmai</asp:TableCell>
                <asp:TableCell runat="server"></asp:TableCell>
                <asp:TableCell runat="server"></asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <br />
        Užsakymai
        <asp:Table ID="Table2" runat="server" BorderColor="Black" BorderWidth="2px" GridLines="Both">
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">Užsakymo ID</asp:TableCell>
                <asp:TableCell runat="server">Data</asp:TableCell>
                <asp:TableCell runat="server">Pavadinimas</asp:TableCell>
                <asp:TableCell runat="server">Autorius</asp:TableCell>
                <asp:TableCell runat="server">Leidimas</asp:TableCell>
                <asp:TableCell runat="server">Tiekėjas</asp:TableCell>
                <asp:TableCell runat="server">Kiekis</asp:TableCell>
                <asp:TableCell runat="server">Vnt. kaina</asp:TableCell>
                <asp:TableCell runat="server">Veiksmai</asp:TableCell>
            </asp:TableRow>
        </asp:Table><br />
        
        Renginių dalyviai
        <asp:Table ID="Table3" runat="server" BorderColor="Black" BorderWidth="2px" GridLines="Both">
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">ID</asp:TableCell>
                <asp:TableCell runat="server">Renginio ID</asp:TableCell>
                <asp:TableCell runat="server">Vardas</asp:TableCell>
                <asp:TableCell runat="server">Pavarde</asp:TableCell>
                <asp:TableCell runat="server">El Paštas</asp:TableCell>
                <asp:TableCell runat="server">Telefono nr.</asp:TableCell>
                <asp:TableCell runat="server">Veiksmai</asp:TableCell>
            </asp:TableRow>
        </asp:Table><br />
        Skaitytojai
        <asp:Table ID="Table4" runat="server" BorderColor="Black" BorderWidth="2px" GridLines="Both">
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">Skaitytojo nr.</asp:TableCell>
                <asp:TableCell runat="server">Vardas</asp:TableCell>
                <asp:TableCell runat="server">Pavardė</asp:TableCell>
                <asp:TableCell runat="server">El. paštas</asp:TableCell>
                <asp:TableCell runat="server">Telefono nr.</asp:TableCell>
                <asp:TableCell runat="server">Gimimo data</asp:TableCell>
                <asp:TableCell runat="server">Veiksmai</asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        </div>
    </form>
</body>
</html>
