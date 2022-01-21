<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="KlientuUzsakymai.aspx.cs" Inherits="SunuBuduSistema.KlientuUzsakymai" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <link href ="KlientuUzsakymaiStyle.css" rel="stylesheet" />
     <div class="auto-style2">
         <center>
         <asp:Label ID="Label1" runat="server" Text="Mano užsakymai" Font-Size=40px ForeColor="AliceBlue"></asp:Label>
         <asp:Label ID="Tuscias" runat="server" CssClass="aa" Text="Neturite sudarytų užsakymų!" style="font-size: 25px; font-weight:bold" Visible="false" ForeColor = "Red"></asp:Label>
             </center>
    <asp:GridView ID="Uzsakymai" runat="server" AutoGenerateColumns="False"  OnPageIndexChanging="OnPaging" BackColor="White" BorderColor="#CCCCC" BorderStyle="None" BorderWidth="1px" PageSize="7" AllowPaging="True" CssClass="auto-style1">
       <HeaderStyle Width="5%" />
         <RowStyle Width="5%" />
    <FooterStyle Width="5%"/>

        <Columns>
    
            <asp:BoundField DataField="Id" HeaderText="Užsakymo numeris"  HeaderStyle-Width="1%"  ItemStyle-Width="1%" FooterStyle-Width="1%">
<FooterStyle Width="1%"></FooterStyle>

<HeaderStyle Width="1%"></HeaderStyle>

<ItemStyle Width="1%"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Data" HeaderText="Data"  HeaderStyle-Width="5%"  ItemStyle-Width="5%" FooterStyle-Width="5%">
<FooterStyle Width="5%"></FooterStyle>

<HeaderStyle Width="5%"></HeaderStyle>

<ItemStyle Width="5%"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Busena" HeaderText="Būsena" HeaderStyle-Width="5%" ItemStyle-Width="5%" FooterStyle-Width="5%">
<FooterStyle Width="5%"></FooterStyle>

<HeaderStyle Width="5%"></HeaderStyle>

<ItemStyle Width="5%"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Kaina" HeaderText="Kaina" HeaderStyle-Width="5%" ItemStyle-Width="5%" FooterStyle-Width="5%">
<FooterStyle Width="5%"></FooterStyle>

<HeaderStyle Width="5%"></HeaderStyle>

<ItemStyle Width="5%"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Preliminari_data" HeaderText="Preliminari data" HeaderStyle-Width="5%"  ItemStyle-Width="15%" FooterStyle-Width="5%">
<FooterStyle Width="5%"></FooterStyle>

<HeaderStyle Width="5%"></HeaderStyle>

<ItemStyle Width="15%"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Kiekis" HeaderText="Sienų kiekis" HeaderStyle-Width="5%" ItemStyle-Width="5%" FooterStyle-Width="5%">
<FooterStyle Width="5%"></FooterStyle>

<HeaderStyle Width="5%"></HeaderStyle>

<ItemStyle Width="5%"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Medis" HeaderText="Sienos medis" HeaderStyle-Width="5%"  ItemStyle-Width="5%" FooterStyle-Width="5%">
<FooterStyle Width="5%"></FooterStyle>

<HeaderStyle Width="5%"></HeaderStyle>

<ItemStyle Width="5%"></ItemStyle>
            </asp:BoundField>
             <asp:BoundField DataField="SienosMedzioKaina" HeaderText="Sienos medžio kaina" HeaderStyle-Width="5%" ItemStyle-Width="15%" FooterStyle-Width="5%">
<FooterStyle Width="5%"></FooterStyle>

<HeaderStyle Width="5%"></HeaderStyle>

<ItemStyle Width="15%"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="SpalvosPav" HeaderText="Sienos spalva"  HeaderStyle-Width="5%" ItemStyle-Width="5%" FooterStyle-Width="5%">
<FooterStyle Width="5%"></FooterStyle>

<HeaderStyle Width="5%"></HeaderStyle>

<ItemStyle Width="5%"></ItemStyle>
            </asp:BoundField>
             <asp:BoundField DataField="SienosSpalvosKaina" HeaderText="Sienos spalvos kaina" HeaderStyle-Width="5%" ItemStyle-Width="15%" FooterStyle-Width="5%">
<FooterStyle Width="5%"></FooterStyle>

<HeaderStyle Width="5%"></HeaderStyle>

<ItemStyle Width="15%"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="AngosForma" HeaderText="Sienos anga"  HeaderStyle-Width="5%"  ItemStyle-Width="5%" FooterStyle-Width="5%">
<FooterStyle Width="5%"></FooterStyle>

<HeaderStyle Width="5%"></HeaderStyle>

<ItemStyle Width="5%"></ItemStyle>
            </asp:BoundField>
             <asp:BoundField DataField="Uzdeng" HeaderText="Uždengimas" HeaderStyle-Width="5%"  ItemStyle-Width="5%" FooterStyle-Width="5%">
<FooterStyle Width="5%"></FooterStyle>

<HeaderStyle Width="5%"></HeaderStyle>

<ItemStyle Width="5%"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Dydis" HeaderText="Sienos dydis"  HeaderStyle-Width="20%"  ItemStyle-Width="20%" FooterStyle-Width="20%">
<FooterStyle Width="20%"></FooterStyle>

<HeaderStyle Width="20%"></HeaderStyle>

<ItemStyle Width="20%"></ItemStyle>
            </asp:BoundField>
             <asp:BoundField DataField="Kaminas" HeaderText="Kaminas" HeaderStyle-Width="5%"  ItemStyle-Width="5%" FooterStyle-Width="5%">
<FooterStyle Width="5%"></FooterStyle>

<HeaderStyle Width="5%"></HeaderStyle>

<ItemStyle Width="5%"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="StogoMedis" HeaderText="Stogo medis"  HeaderStyle-Width="5%"  ItemStyle-Width="5%" FooterStyle-Width="5%">
<FooterStyle Width="5%"></FooterStyle>

<HeaderStyle Width="5%"></HeaderStyle>

<ItemStyle Width="5%"></ItemStyle>
            </asp:BoundField>
              <asp:BoundField DataField="StogoMedzioKaina" HeaderText="Stogo medžio kaina" HeaderStyle-Width="5%" ItemStyle-Width="15%" FooterStyle-Width="5%">
<FooterStyle Width="5%"></FooterStyle>

<HeaderStyle Width="5%"></HeaderStyle>

<ItemStyle Width="15%"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="StogoSpalva" HeaderText="Stogo spalva" HeaderStyle-Width="5%"  ItemStyle-Width="5%" FooterStyle-Width="5%">
<FooterStyle Width="5%"></FooterStyle>

<HeaderStyle Width="5%"></HeaderStyle>

<ItemStyle Width="5%"></ItemStyle>
            </asp:BoundField>
              <asp:BoundField DataField="StogoSpalvosKaina" HeaderText="Stogo spalvos kaina" HeaderStyle-Width="5%"  ItemStyle-Width="15%" FooterStyle-Width="5%">
<FooterStyle Width="5%"></FooterStyle>

<HeaderStyle Width="5%"></HeaderStyle>

<ItemStyle Width="15%"></ItemStyle>
            </asp:BoundField>
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <RowStyle ForeColor="#000066" />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#007DBB" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#00547E" />
    </asp:GridView>
         </div>
</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .auto-style1 {
            margin-left: 0px;
        }
        .auto-style2 {
            margin-left: 0px;
            margin-top: 100px;
            padding: 15px;
        }
    </style>
</asp:Content>

