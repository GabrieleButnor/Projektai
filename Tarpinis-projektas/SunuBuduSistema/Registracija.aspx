<%@ Page Language="C#"  Title="Register" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registracija.aspx.cs" Inherits="SunuBuduSistema.Registracija" %>

<%--<!DOCTYPE html>--%>

<%--<html xmlns="http://www.w3.org/1999/xhtml">--%>
<%--<head runat="server">--%>
  <%--  <title>Registracija</title>
    <link href="StyleSheet2.css" rel="stylesheet" />
</head>
<body>--%>
<%--    <form id="form1" runat="server">--%>
       <%-- <div>--%>
           
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href ="RegistracijosStyle.css" rel="stylesheet" />
            <div class="login">
                 <h1  style="font-size:300%; color:cadetblue; font-family:'Times New Roman'";>Vartotojo registracija <img src="Images/login.png" width="40"/> </h1>

                <h1 style="font-size:200%; padding-bottom:20px; color:cadetblue; font-family:'Times New Roman'">Užpildykite visus pateiktus laukus</h1>
  <asp:Label ID="ErrorUserEmailLabel" runat="server" Visible="false" ForeColor="Tomato"></asp:Label>
                <p>
                <asp:Label ID="Label1" runat="server" ForeColor="gray" Text="Prisijungimo vardas" Font-Size="20px" ></asp:Label>
        
                    </p>
                <p>
                <asp:TextBox ID="TextBox1" ForeColor="White" runat="server" Width="300px" Font-Size="18px"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Font-Size="Larger" ForeColor="Tomato" ErrorMessage="Reikalingas prisijungimo vardas" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>
                                  
                    </p>
        <p>
            <asp:Label ID="Label2" runat="server" ForeColor="gray" Text="Vardas" Font-Size="20px"></asp:Label>
                </p>

                <p>
                <asp:TextBox ID="TextBox2" ForeColor="White" runat="server" Width="300px" Font-Size="18px"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Font-Size="Larger" ForeColor="Tomato" ErrorMessage="Reikalingas vardas" ControlToValidate="TextBox2"></asp:RequiredFieldValidator>
                </p>
                <p>
                <asp:Label ID="Label3"  ForeColor="gray" runat="server" Text="Pavardė"  Font-Size="20px"></asp:Label>
        
                </p>
                <p>
        
                <asp:TextBox ID="TextBox3" ForeColor="White" runat="server" Width="300px" Font-Size="18px"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Font-Size="Larger" ForeColor="Tomato" ErrorMessage="Reikalinga pavardė" ControlToValidate="TextBox3"></asp:RequiredFieldValidator>
                </p>
        <p>
            <asp:Label ID="Label4" runat="server" ForeColor="gray" Text="Slaptažodis"  Font-Size="20px"  ></asp:Label>
                </p>
                <p>
                <asp:TextBox ID="TextBox4" ForeColor="White" runat="server" TextMode="Password" Width="300px" Font-Size="18px"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Font-Size="Larger" ForeColor="Tomato" ErrorMessage="Reikalingas slaptažodis" ControlToValidate="TextBox4"></asp:RequiredFieldValidator>
                </p>
        <p>
            <asp:Label ID="Label5" runat="server" ForeColor="gray" Text="Telefonas"  Font-Size="20px" ></asp:Label>

                </p>
                <p>

                <asp:TextBox ID="TextBox5" ForeColor="White" runat="server" Width="300px" Font-Size="18px"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Font-Size="Larger" ForeColor="Tomato" ErrorMessage="Reikalingas telefonas" ControlToValidate="TextBox5"></asp:RequiredFieldValidator>
                </p>
        <p>
            <asp:Label ID="Label6" runat="server" ForeColor="gray" Text="El.paštas"  Font-Size="20px" ></asp:Label>
            
             </p>
                <p>
                <asp:TextBox ID="TextBox6" ForeColor="White" runat="server" Width="300px" Font-Size="18px" ></asp:TextBox>      
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Padding="100px" ForeColor="Tomato" Font-Size="Larger" Display="Dynamic" ErrorMessage="Reikalingas el. paštas " ControlToValidate="TextBox6"></asp:RequiredFieldValidator>
             <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Font-Size="Larger" ForeColor="Tomato" Display="Dynamic" ErrorMessage="Reikalingas teisingas el. paštas" ControlToValidate="TextBox6" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"></asp:RegularExpressionValidator>
                </p>
                <p>
                <asp:Label ID="Label7" runat="server" ForeColor="gray" Text="Adresas" Font-Size="20px"></asp:Label>
               </p>
                <p>
                <asp:TextBox ID="TextBox7" ForeColor="White" runat="server" Width="300px" Font-Size="18px"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" Font-Size="Larger" ForeColor="Tomato" ErrorMessage="Reikalingas adresas" ControlToValidate="TextBox7"></asp:RequiredFieldValidator>
               </p>
                 <p>
                     &nbsp;</p>
                    <p>
                <asp:Button ID="RegistrationButton" runat="server" Text="Registruotis" Height="50px"  Width="150px" class="color" Font-Size="X-Large" ForeColor="black" OnClick="RegistrationButton_Click" />
            </p>
       <%-- </div>--%>
   
  <%--  </form>
</body>
</html>--%>
</asp:Content>