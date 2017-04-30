<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Account_Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h4>Create a new account.</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtFirstName" CssClass="col-md-2 control-label">First Name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtFirstName" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtFirstName"
                    CssClass="text-danger" ErrorMessage="This field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtLastName" CssClass="col-md-2 control-label">Last Name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtLastName" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtlastName"
                    CssClass="text-danger" ErrorMessage="This field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtDoB" CssClass="col-md-2 control-label">Date of Birth</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtDoB" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtDoB"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="Date of Birth is required." />
            </div><div><asp:Calendar ID="calDoB" runat="server" OnSelectionChanged="calDoB_SelectionChanged"></asp:Calendar></div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtMajor" CssClass="col-md-2 control-label">Major</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtMajor" CssClass="form-control" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ddlTeams" CssClass="col-md-2 control-label">Team</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList runat="server" ID="ddlTeams" CssClass="form-control"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlTeams"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="Date of Birth is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ddlRole" CssClass="col-md-2 control-label">Role</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList runat="server" ID="ddlRole" CssClass="form-control"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlRole"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="Individual Role is required" />
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="CreateUser_Click" Text="Register" CssClass="btn btn-default" /><asp:Label runat="server" ID="txtInsertStatus" Visible ="false" CssClass="text_danger" ForeColor="#b94a48"></asp:Label><div></div>
            </div>
        </div>
    </div>
</asp:Content>

