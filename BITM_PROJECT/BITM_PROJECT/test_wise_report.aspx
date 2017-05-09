<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test_wise_report.aspx.cs" Inherits="BITM_PROJECT.test_wise_report" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 349px">
        From Date<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:ImageButton ID="ImageButton1" runat="server" OnClick="ImageButton1_Click" CausesValidation="False" ImageUrl="~/images.png" Width="37px" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="SELECT A START DATE" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
        <br />
        To date&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <asp:ImageButton ID="ImageButton2" runat="server" OnClick="ImageButton2_Click" CausesValidation="False" Height="28px" ImageUrl="~/images.png" Width="37px" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="SELECT END DATE" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <asp:Calendar ID="Calendar2" runat="server" OnSelectionChanged="Calendar2_SelectionChanged"></asp:Calendar>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      <asp:Button ID="Button1" runat="server" Text="Show" OnClick="Button1_Click" />
        <asp:GridView ID="GridView1" runat="server">
             
        </asp:GridView>
      
    
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; TOTAL
        <asp:TextBox ID="TextBox3" runat="server" Width="75px"></asp:TextBox>
      
    
        <br />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="PDF" />
      
    
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/payment.aspx">BACK</asp:HyperLink>
&nbsp;&nbsp;&nbsp;
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/TypeWiseReport.aspx">NEXT</asp:HyperLink>
      
    
    </div>
    </form>
</body>
</html>
