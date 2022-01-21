<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="SunuBuduSistema.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href ="AboutStyle.css" rel="stylesheet" />
                    <p>
            <div class="mainBox">
                <div aligin="center"
    <asp:Label ID="Label" runat="server" Text="INFORMACIJA" style="text-align:center; font-size: xx-large; color:cadetblue; font-weight: 700"></asp:Label>
            </div>
                    </p>
        <p>
    <p></p>
    <asp:Label ID="Label2" runat="server" Text="Informacija apie sistemą" style="font-size: x-large; color:cadetblue; font-weight: 700"></asp:Label>
    <p></p>
    <asp:Label ID="Label3" runat="server" Text="Ši sistema yra skirta užsisakyti savarankiškai suprojektuotą gyvūno būdą. Tam yra pateikiami pasirinkimai.
        Jūs galite rinktis kelias skirtingas būdos spalvas, medžio tipą, sienų kiekį, būdos angos formą, stogo tipa. 
        Taip pat papildomai galite rinktis įrangą ar kitus būdos komponentus." style="color:cadetblue; font-size: large"></asp:Label>
    <p></p>
     <asp:Label ID="Label4" runat="server" Text="Naudojimos Instrukcija" style="color:cadetblue; font-size: x-large; font-weight: 700"></asp:Label>
    <p></p>
    <asp:Label ID="Label5" runat="server" Text="Meniu juostoje pasirinkite 'Būdos projektavimas' laukelį. 
        Naujame puslapyje matysite galimus pasirinkimus. 
        Reikia pažymėti visus laukelius. Išsirinkite sienų, stogo parametrus. Pasirinkite papildomą įrangą.
        Jeigu viską išsirinkote, spauskite skaičiuoti mygtuką. Puslapio apačioje matysite laiką, per kurį užsakymas bus paruoštas, bei galutinę kainą. 
        Jeigu tai jums tiks, spauskite užsakyti mygtuką. Prie apmokėjimo galėsite prieiti tik tuo atveju, jei esate prisijungęs. Viršuje matysite pranešimą, jei nesate prisijungęs. Prisijungti galėsite padaryti paspaudę rodomą pranešimą arba meniu juostoje pasirinkę 'LOGIN'. Naujame atsiverusiame lange Jums reikės prisijungti su jau egzistuojančia paskyra arba susikurti naują.
        Įvykdžius šį žingsnį pasirinkite apmokėjimo būdą, apmokėkite. Jūsų užsakymas bus įvykdytas. Jo būseną galite stebėti prisijungę meniu juostoje pasirinkus 'Užsakymai'.
        Iškilus nesklandumams ar turint klausimų, galite rašyti el.paštu arba skambinti telefonu. Šiuos duomenis rasite žemiau." style="color:cadetblue; font-size: large"></asp:Label>
     <p></p>
     <asp:Label ID="Label1" runat="server" Text="Kontaktai" style="color:cadetblue; font-size: x-large; font-weight: 700"></asp:Label>
    <p></p>
     <asp:Label ID="Label6" runat="server" Text="info@biy.com" style="color:cadetblue; font-size: large; "></asp:Label>
</asp:Content>

