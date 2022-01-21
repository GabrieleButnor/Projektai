<%@ Page   Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminUzsakymai.aspx.cs" Inherits="SunuBuduSistema.AdminUzsakymai" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>--%>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link href ="AdminUzsakymai.css" rel="stylesheet" />
    <div>
       <asp:Label ID="Tuscias" runat="server" CssClass="aa" Text="Neturite sudarytų užsakymų!" style="font-size: 25px; font-weight:bold" Visible="false" ForeColor = "Red"></asp:Label>

       <asp:GridView ID="Uzsakymai" runat="server" CellPadding="5" AutoGenerateColumns="False"  OnPageIndexChanging="OnPaging" AllowPaging="True"
           OnRowEditing="Uzsakymai_RowEditing" OnRowCancelingEdit="Uzsakymai_RowCancelingEdit" onrowdatabound="Uzsakymai_RowDataBound" OnRowUpdating="Uzsakymai_RowUpdating"
           BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="3px" CssClass="auto-style1" Width="801px" CellSpacing="2">
           <AlternatingRowStyle BackColor="#CCCCFF" Font-Italic="False" VerticalAlign="Middle" />
        <Columns>          
            
             <asp:TemplateField HeaderText="Užsakymo nr">  
                    <ItemTemplate>  
                        <asp:Label ID="Id" runat="server" Text='<%#Eval("Id") %>'></asp:Label>  
                    </ItemTemplate>  
             </asp:TemplateField> 
             <asp:TemplateField HeaderText="Data">  
                    <ItemTemplate>  
                        <asp:Label ID="Data" runat="server" Text='<%#Eval("Data") %>'></asp:Label>  
                    </ItemTemplate>  
             </asp:TemplateField> 
             <asp:TemplateField HeaderText="Būsena">  
                    <ItemTemplate>  
                        <asp:Label ID="Busena" runat="server" Text='<%#Eval("Busena") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:DropDownList ID="busenos" runat="server"  Font-Size="15px" Width="150px">
                        </asp:DropDownList>
                    </EditItemTemplate> 
            </asp:TemplateField>  
            <asp:TemplateField HeaderText="Kaina (eurais)">  
                    <ItemTemplate>  
                        <asp:Label ID="Kaina" runat="server" Text='<%#Eval("Kaina") %>'></asp:Label>  
                    </ItemTemplate>  
             </asp:TemplateField> 
             <asp:TemplateField HeaderText="Preliminari data">  
                    <ItemTemplate>  
                        <asp:Label ID="Preliminari_data" runat="server" Text='<%#Eval("Preliminari_data") %>'></asp:Label>  
                    </ItemTemplate>  
             </asp:TemplateField> 
             <asp:TemplateField>  
                    <ItemTemplate>  
                        <asp:LinkButton ID="btn_Edit" runat="server"  BackColor="" Text="Redaguoti būseną" style="font-style:italic; font-weight:bold; " CommandName="Edit" />  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:LinkButton ID="btn_Update" runat="server" BackColor="" Text="Išsaugoti"  style="font-style:italic; font-weight:bold; " CommandName="Update"/>  
                        <asp:LinkButton ID="btn_Cancel" runat="server" BackColor="" Text="Atšaukti" style="font-style:italic; font-weight:bold; " CommandName="Cancel"/>  
                    </EditItemTemplate>  
              </asp:TemplateField> 

        </Columns>
           <FooterStyle BackColor="White" ForeColor="#000066" />
           <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" Wrap="True" />
           <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
           <RowStyle ForeColor="#000066" />
           <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
           <SortedAscendingCellStyle BackColor="#F1F1F1" />
           <SortedAscendingHeaderStyle BackColor="#007DBB" />
           <SortedDescendingCellStyle BackColor="#CAC9C9" />
           <SortedDescendingHeaderStyle BackColor="#00547E" />
    </asp:GridView>
   
            <asp:GridView ID="Uzsakymas" runat="server" AutoGenerateColumns="False"  OnPageIndexChanging="OnPaging" BackColor="White" BorderColor="#CCCCC" BorderWidth="1px" PageSize="5" AllowPaging="True" CssClass="auto-style2" Width="1285px" CellPadding="7">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Užsakymo nr" />
            <asp:BoundField DataField="Data" HeaderText="Data" />            
            <asp:BoundField DataField="Klientas" HeaderText="Klientas" />
            <asp:BoundField DataField="Kaina" HeaderText="Kaina" />
            <asp:BoundField DataField="Kiekis" HeaderText="Sienų kiekis" />
            <asp:BoundField DataField="SpalvosPav" HeaderText="Sienos spalva" />
             <asp:BoundField DataField="Medis" HeaderText="Sienos medžis" />
            <asp:BoundField DataField="AngosForma" HeaderText="Angos forma" />
             <asp:BoundField DataField="Uzdeng" HeaderText="Uždengimas" />
            <asp:BoundField DataField="Dydis" HeaderText="Dydis" />
             <asp:BoundField DataField="StogoMedis" HeaderText="Stogo medis" />
            <asp:BoundField DataField="StogoSpalva" HeaderText="Stogo spalva" />
             <asp:BoundField DataField="Kaminas" HeaderText="Kaminas" />
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
     
      <asp:GridView ID="Iranga" runat="server" AutoGenerateColumns="False"  OnPageIndexChanging="OnPaging" BackColor="White" BorderColor="#CCCCC" BorderStyle="None" BorderWidth="1px" PageSize="5" AllowPaging="True" CssClass="auto-style2" Width="629px" CellPadding="5">
        <Columns>
            <asp:BoundField DataField="Numeris" HeaderText="Įrangos kodas" />
            <asp:BoundField DataField="Tipas" HeaderText="Tipas" />            
            <asp:BoundField DataField="Kaina" HeaderText="Kaina" />
            <asp:BoundField DataField="Kiekis" HeaderText="Elemento kiekis" />
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
       
              <asp:GridView ID="Atributai" runat="server" AutoGenerateColumns="False"  OnPageIndexChanging="OnPaging" BackColor="White" BorderColor="#CCCCC" BorderStyle="None" BorderWidth="1px" PageSize="5" AllowPaging="True" CssClass="auto-style2" Width="633px" CellPadding="5">
        <Columns>
            <asp:BoundField DataField="Numeris" HeaderText="Atributo kodas" />
            <asp:BoundField DataField="Tipas" HeaderText="Tipas" />            
            <asp:BoundField DataField="Kaina" HeaderText="Kaina" />
            <asp:BoundField DataField="Kiekis" HeaderText="Elemento kiekis" />
            <asp:BoundField DataField="Komentaras" HeaderText="Komentaras" />
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
     <br />
    <br />
    <br />
     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
     <asp:Label ID="Label1" runat="server" Text="Įveskite užsakymo numerį:" Font-Size=19px ForeColor="lightblue"></asp:Label>
     &nbsp;&nbsp;
     <asp:TextBox ID="uzsakymo_id" runat="server" Font-Size="18px" Width="43px" Height="26px"></asp:TextBox>
     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Klaida" CssClass="a2" runat="server" style="font-size: 18px; font-weight:bold" Visible = "false" ForeColor = "Red"></asp:Label>
     &nbsp;
    <br />
    <br />
     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
     <asp:Button ID="Button" runat="server"  Height="43px" style="font-size: 18px; font-style:italic; background-color:lightblue;" Text="Rodyti" Width="86px" OnClick="Button_Click" />
</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .auto-style1 {
            margin-left: 40px;
            margin-top: 106px;
        }
        
        .auto-style2 {
            margin-left: 11px;
            margin-top: 106px;
        }
        
    </style>
</asp:Content>

