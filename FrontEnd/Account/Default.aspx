<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Account_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Player Profile
        <asp:label id="test" runat="server">hi</asp:label>
    </div>
    </form>
    <div>
        <gridview id="profile"></gridview>
    </div>
</body>
</html>
