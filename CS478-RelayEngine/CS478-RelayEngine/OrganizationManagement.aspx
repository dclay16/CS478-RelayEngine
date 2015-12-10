<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrganizationManagement.aspx.cs" Inherits="RelayEngineWebsite.OrganizationManagement" %>

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
    <link href="~/Content/DylanSite.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin-left:auto;margin-right:auto; text-align: center;">
        <asp:Image ID="LogoImage" runat="server" ImageUrl="~/Content/evansville_day_school.jpg" /><br />
        <br />
        <a href ="Update Logo Page.aspx">Update Logo</a><br />
        <br />
        <a href ="ManageListPage.aspx">Manage Lists</a><br />
        <br />
        <a href ="ManageSenders.aspx">Manage Senders</a><br />
        <br />
        <a href ="Organization Security Code Page.aspx">Organization Security Code</a><br />
        <br />
        <a href ="AccountInformationPage.aspx">Account Information</a></div>
    </form>
</body>
</html>
