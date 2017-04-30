<%@ Page Title="ManagerTeam" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ManagerTeam.aspx.cs" Inherits="Account_ManagerTeam" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div>
        <div><asp:label id="lblInfo" runat="server"></asp:label></div>
        <div></div>
    <asp:GridView ID="grvAvailability" runat="server" CssClass="table"></asp:GridView>
    </div>
</asp:Content>

