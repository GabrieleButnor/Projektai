<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="add.aspx.cs" Inherits="Loginai.knygu_tvarkymas.add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Knyga</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="m_books" runat="server" Text="Knygu Sarasas" OnClick="m_books_Click1"/>
            <asp:Button ID="m_report_a" runat="server" Text="Nurasytu knygu ataskaita" OnClick="m_report_a_Click" />
            <asp:Button ID="m_report_b" runat="server" Text="Bedra knygu ataskaita" OnClick="m_report_b_Click" />
        </div>
        <br/>
        <div>
            <table>
                <tr><td>Pavadinimas</td>
                <td><asp:TextBox ID="pavadinimas" runat="server"></asp:TextBox></td></tr>

                <tr><td>Autorius</td>
                <td><asp:TextBox ID="autorius" runat="server"></asp:TextBox></td></tr>

                <tr><td>Isleidimo data</td>
                <td><asp:TextBox textmode="Date" ID="isleidimo_data" runat="server"></asp:TextBox></td></tr>

                <tr><td>Leidejas</td>
                <td><asp:TextBox ID="leidejas" runat="server"></asp:TextBox></td></tr>

                <tr><td>Zanras</td>
                <td><asp:DropDownList ID="_zanras" runat="server"></asp:DropDownList></td></tr>

                <tr><td>Busena</td>
                <td><asp:DropDownList ID="_busena" runat="server"></asp:DropDownList></td></tr>

                <tr><td>Puslapiu skaicius</td>
                <td><asp:TextBox ID="puslapiu_sk" runat="server"></asp:TextBox></td></tr>

                <tr><td>Komentaras</td>
                <td><asp:TextBox ID="komentaras" runat="server"></asp:TextBox></td></tr>
            </table>
            <br />
            <asp:Button ID="add_book" runat="server" Text="Prideti" OnClick="add_book_Click"/>
        </div>
    </form>
</body>
</html>
