

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="payment.aspx.cs" Inherits="BITM_PROJECT.payment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <br />
    <form id="form1" runat="server">
    <div>
        Bill Number<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><asp:Button ID="Button1" runat="server" Text="Search" OnClick="Button1_Click" />
        <asp:GridView ID="GridView1" runat="server"></asp:GridView>
    
        <br />
        <br />
        Total Fee&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :<asp:Label ID="Label1" runat="server" Text="0$"></asp:Label>
        <br />
        Paid ammount&nbsp;&nbsp; :<asp:Label ID="paidLabel2" runat="server" Text="0$"></asp:Label>
        <br />
        Due ammount&nbsp;&nbsp; :<asp:Label ID="dueLabel3" runat="server" Text="0$"></asp:Label>
        <br />
        <br />
        Ammount&nbsp;&nbsp; <asp:TextBox ID="ammountTextBox" runat="server"></asp:TextBox>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Pay" />
        <br />
        <br />
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/test_request_entry.aspx">BACK</asp:HyperLink>
&nbsp;&nbsp;
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/test_wise_report.aspx">NEXT</asp:HyperLink>
        <br />
    
    </div>
    </form>
</body>
</html>
