<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<asp:Content ID="Home" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="form-horizontal">
        <h2><asp:Label runat="server" ID="lblhello" Text="Welcome " /><asp:Label runat="server" ID ="lblProfileName" /></h2>
    </div>
    <div>

    </div>
    <div class="form-horizontal">
        <asp:Label runat="server" ID="lblRoles" Text="Your Roles in the team are: "/>
        <asp:Label runat="server" ID="lblRoleDetails" />
    </div>
    <div>

    </div>
    <div>
        <asp:gridview runat="server" ID="grvProfileDisplay" CssClass="table"></asp:gridview>
    </div>
</asp:Content>

