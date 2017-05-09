﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="unpaid_bill_report.aspx.cs" Inherits="BITM_PROJECT.unpaid_bill_report" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 169px">
    <form id="form1" runat="server">
    <div>
     From Date<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:ImageButton ID="ImageButton1" runat="server" OnClick="ImageButton1_Click" CausesValidation="False" Height="32px" ImageUrl="~/images.png" Width="45px" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="STAR DATE REQUIRED" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
        <br />
        To date&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <asp:ImageButton ID="ImageButton2" runat="server" OnClick="ImageButton2_Click" CausesValidation="False" Height="30px" ImageUrl="~/images.png" Width="44px" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="END DATE REQUIRED" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <asp:Calendar ID="Calendar2" runat="server" OnSelectionChanged="Calendar2_SelectionChanged"></asp:Calendar>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      <asp:Button ID="Button1" runat="server" Text="Show" OnClick="Button1_Click" />
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
      
    
        &nbsp; TOTAL&nbsp;
        <asp:TextBox ID="TextBox3" runat="server" Width="84px"></asp:TextBox>
      
    
        <br />
        <asp:Button ID="Button2" runat="server" Text="pdf" OnClick="Button2_Click" />
      
    </div>
    </form>
</body>
</html>
