<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UzsakymasSekmingas.aspx.cs" Inherits="SunuBuduSistema.UzsakymasSekmingas" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <title>Užsakymas sėkmingas!</title>
      <link href ="DefaultStyle.css"  rel="stylesheet" />
    <div class="mainBox"
            <div align ="center"> 
                <asp:Label ID="Label1" runat="server" Text=" Užsakymas sėkmingas! Detalią užsakymo informaciją galite peržiūrėti paspaudus" ForeColor="Red" Font-Size=50px></asp:Label>
                    <asp:HyperLink ID="RegistracijaLink" runat="server" NavigateUrl="~/KlientuUzsakymai.aspx" Visible="true" Font-Size=50px>čia</asp:HyperLink>
            </div>
        </div>
</asp:Content>
