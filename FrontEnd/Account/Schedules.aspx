<%@ Page Title="Schedules" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Schedules.aspx.cs" Inherits="Account_Schedules" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div>
        <h2><asp:Label id ="lbl_player" runat="server"></asp:Label></h2>
    </div>
    <div id="Container" runat ="server">
    <div>
        <asp:TextBox ID="txt_ChooseDate" runat ="server" Text ="Select a date"></asp:TextBox><asp:Button ID="btn_FindPlayers" runat="server" OnClick ="btn_FindPlayers_Click" Text ="Find Players"/>
        <div></div>
    </div>
    <div>
        <asp:Calendar ID="cal_calChooseDate" runat="server" OnSelectionChanged ="cal_calChooseDate_SelectionChanged"></asp:Calendar>
    </div>
        <div><asp:GridView ID ="grv_displayPlayers" runat="server" Visible =false></asp:GridView></div>
    </div>
</asp:Content>

