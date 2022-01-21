<%@ Page Title="Atributu pridejimas"Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminPridejimas.aspx.cs" Inherits="SunuBuduSistema.AdminPridejimas" %>

       <asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
           <link href ="BuduGamybaStyle.css" rel="stylesheet" />
           <div class="main">
        &nbsp;<p>
            <asp:Label ID="Label2" runat="server" ForeColor="CadetBlue" Text="Nauja spalva" style="font-size: 30px; font-weight: 700; padding:20px"></asp:Label>
        </p>
                   <p>
            <asp:Label ID="Label3" runat="server" Text="Pavadinimas" ForeColor="SkyBlue" style="font-size:20px; padding-left:20px;padding-right:70px"></asp:Label>
                      
            &nbsp;&nbsp;
                      
            <asp:TextBox ID="spalva_pavadinimas_box" runat="server" Font-Size="18px" Width="300px"></asp:TextBox>
                      
        </p>
               
               
        <p>
            <asp:Label ID="Label4" runat="server" Text="Kaina" ForeColor="SkyBlue" style="font-size:20px; padding-left:20px;padding-right:67px"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
&nbsp;<asp:TextBox ID="spalva_kaina_box" runat="server" Font-Size="18px" Width="301px"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="Label5" runat="server" Text="Žmogvalandės" ForeColor="SkyBlue" style="font-size:20px; padding-left:20px;padding-right:60px"></asp:Label>
            &nbsp;<asp:TextBox ID="spalva_zmogvalandes_box" runat="server" Font-Size="18px" Width="301px"></asp:TextBox>
        </p>
        <p>
            &nbsp;</p>
               <p>
            <asp:Button ID="Button1" runat="server" class="color" Height="43px" style="font-size: 25px;" Text="Išsaugoti" OnClick="Button1_Click" />
                   <asp:Label ID="Klaida1" runat="server" Text="Ne visi laukai užpildyti!" ForeColor="Red" style="font-size:20px; padding-left:20px;padding-right:63px" Visible ="false"></asp:Label>
        </p>
               <p>
                   &nbsp;</p>
               </div>
      
            <div class="main">
                  <p>
            <asp:Label ID="Label9" runat="server" style="font-weight: 700; font-size: 30px; padding:20px" ForeColor="CadetBlue" Text="Naujas medžio tipas"></asp:Label>
            </p>
        <p>
            <asp:Label ID="Label10" runat="server" Text="Pavadinimas" ForeColor="SkyBlue" style="font-size:20px; padding:20px"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;<asp:TextBox ID="medis_pavadinimas_box" runat="server" Font-Size="18px" Width="300px"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="Label11" runat="server" Text="Kaina" ForeColor="SkyBlue" style="font-size:20px; padding-left:20px;padding-right:63px"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="medis_kaina_box" runat="server" Font-Size="18px" Width="301px"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="Label12" runat="server" Text="Žmogvalandės" ForeColor="SkyBlue" style="font-size:20px;  padding-left:20px;padding-right:69px"></asp:Label>
            <asp:TextBox ID="medis_zmogvalandes_box" runat="server" Font-Size="18px" Width="301px"></asp:TextBox>
        </p>
            <p>
                &nbsp;</p>
                  <p>
                      <asp:Button ID="Button2" runat="server" class="color" Height="43px" style="font-size: 25px;" Text="Išsaugoti" OnClick="Button2_Click" />
                   <asp:Label ID="Klaida2" runat="server" Text="Ne visi laukai užpildyti!" ForeColor="Red" style="font-size:20px; padding-left:20px;padding-right:63px" Visible ="false"></asp:Label>
                  </p>
            </div>
         
          <div class="main">
                  <p>
            <asp:Label ID="Label1" runat="server" style="font-weight: 700; font-size: 30px; padding:20px" ForeColor="CadetBlue" Text="Nauja angos forma"></asp:Label>
            </p>
        <p>
            <asp:Label ID="Label6" runat="server" Text="Pavadinimas" ForeColor="SkyBlue" style="font-size:20px; padding:20px"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;<asp:TextBox ID="angos_pavadinimas_box" runat="server" Font-Size="18px" Width="300px"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="Label7" runat="server" Text="Kaina" ForeColor="SkyBlue" style="font-size:20px; padding-left:20px;padding-right:63px"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="angos_kaina_box" runat="server" Font-Size="18px" Width="301px"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="Label8" runat="server" Text="Žmogvalandės" ForeColor="SkyBlue" style="font-size:20px;  padding-left:20px;padding-right:69px"></asp:Label>
            <asp:TextBox ID="angos_zmogvalandes_box" runat="server" Font-Size="18px" Width="301px"></asp:TextBox>
        </p>
            <p>
                &nbsp;</p>
                  <p>
                      <asp:Button ID="Button3" runat="server" class="color" Height="43px" style="font-size: 25px;" Text="Išsaugoti" OnClick="Button3_Click" />
                   <asp:Label ID="Klaida3" runat="server" Text="Ne visi laukai užpildyti!" ForeColor="Red" style="font-size:20px; padding-left:20px;padding-right:63px" Visible ="false"></asp:Label>
                  </p>
            </div>
           <div class="main">
        <p>
            <asp:Label ID="Label13" runat="server" style="font-weight: 700; font-size: 30px; padding:20px" ForeColor="CadetBlue" Text="Naujas būdos dydis"></asp:Label>
            </p>
        <p>
            <asp:Label ID="Label14" runat="server" Text="Pavadinimas" ForeColor="SkyBlue" style="font-size:20px; padding:19px"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;<asp:TextBox ID="dydziai_pavadinimas_box" runat="server" Font-Size="18px" Width="300px"></asp:TextBox>
        </p>
               <p>
            <asp:Label ID="Label17" runat="server" Text="Lentos ilgis" ForeColor="SkyBlue" style="font-size:20px; padding:19px"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="dydziai_ilgis_box" runat="server" Font-Size="18px" Width="301px"></asp:TextBox>
        </p>
               <p>
            <asp:Label ID="Label18" runat="server" Text="Lentos plotis" ForeColor="SkyBlue" style="font-size:20px; padding:20px"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="dydziai_plotis_box" runat="server" Font-Size="18px" Width="301px"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="Label15" runat="server" Text="Kaina" ForeColor="SkyBlue" style="font-size:20px; padding-left:20px;padding-right:63px"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="dydziai_kaina_box" runat="server" Font-Size="18px" Width="301px"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="Label16" runat="server" Text="Žmogvalandės" ForeColor="SkyBlue" style="font-size:20px;  padding-left:20px;padding-right:69px"></asp:Label>
            <asp:TextBox ID="dydziai_zmogvalandes_box" runat="server" Font-Size="18px" Width="301px"></asp:TextBox>
        </p>
            <p>
                &nbsp;</p>
                  <p>
                      <asp:Button ID="Button4" runat="server" class="color" Height="43px" style="font-size: 25px;" Text="Išsaugoti" OnClick="Button4_Click" />
                   <asp:Label ID="Klaida4" runat="server" Text="Ne visi laukai užpildyti!" ForeColor="Red" style="font-size:20px; padding-left:20px;padding-right:63px" Visible ="false"></asp:Label>
                  </p>
               </div>

           <br />
           <br />
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
           </asp:Content>
     <%--   </form>--%>
<%--    </body>--%>
<%--    </html>--%>
