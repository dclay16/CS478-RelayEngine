<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TextAlertRegistration.aspx.cs" Inherits="RelayEngineWebsite.TextAlertRegistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 381px;
            height: 118px;
        }
    </style>
    <link href="Content/DylanSite.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Panel ID="Panel1" runat="server" style="text-align: center">
            <img alt="" class="auto-style1" src="evansville_day_school.jpg" />
            <br />
            <br />
            Select each list for which you wish to receive alerts. You may select more than one list.<br />
            <br />
            To update your lists, just come back to this page and reregister. Your new selections will replace your old selections.<br />
            <br />
            To remove yourself from these lists, just come back to this page and enter your cell phone number and click &quot;Remove All.&quot; This will remove you from all lists.
        </asp:Panel>
    
    </div>
        <asp:Panel ID="Panel2" runat="server" CssClass="textAlertListPanelClass">
            SMS Text Alert Lists<br />
            <asp:CheckBoxList ID="listCheckBox" runat="server" Font-Underline="False" CssClass="listCheckBox" Height="16px" Width="724px" />
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:EvansvilleDaySchoolDatabaseConnectionString %>" SelectCommand="SELECT [LIST_NAME] FROM [LIST]"></asp:SqlDataSource>
        </asp:Panel>
        <asp:Panel ID="Panel3" runat="server" Wrap="False">
            Cell Phone Number
            <asp:TextBox ID="phoneNumberBox1" runat="server" MaxLength="3" Width="46px"></asp:TextBox>
            <asp:TextBox ID="phoneNumberBox2" runat="server" MaxLength="3" Width="46px"></asp:TextBox>
            <asp:TextBox ID="phoneNumberBox3" runat="server" MaxLength="4" Width="62px"></asp:TextBox>
            <br />
            First Name&nbsp;
            <asp:TextBox ID="firstNameBox" runat="server" CssClass="textBox"></asp:TextBox>
            <br />
            Last Name&nbsp;
            <asp:TextBox ID="lastNameBox" runat="server" CssClass="textBox" Wrap="False"></asp:TextBox>
            <br />
            Organization Security Code
            <asp:TextBox ID="organizationCodeBox" runat="server" MaxLength="5" Width="72px"></asp:TextBox>
        </asp:Panel>
        <asp:Panel ID="Panel4" runat="server" style="text-align: center; height: 64px">
            <asp:Label ID="warningLabel" runat="server"></asp:Label>
            <br />
            <asp:Button ID="submitButton" runat="server" Text="Submit" OnClick="submitButtonClick" />
            <asp:Button ID="removeAllButton" runat="server" Text="Remove All" OnClick="removeAllClick" />
            <asp:Button ID="Button3" runat="server" Text="Cancel" />
            <br />
            <a href="~/SendMessage">Sender</a>
            <a href="~/AdminSignIn">Admin</a>
            <br />
        </asp:Panel>
    </form>
</body>
</html>
