<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="mainContent" ContentPlaceHolderID="content" runat="server">

    <form id="form1" runat="server">
        <div class="center">
        <asp:Table ID="tblLogin" runat="server" CssClass="userStuff">
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2">
                    <asp:Label ID="lblFailed" runat="server" />
                </asp:TableCell></asp:TableRow><asp:TableRow>
                <asp:TableHeaderCell>User Name:</asp:TableHeaderCell><asp:TableCell>
                    <asp:TextBox ID="txtUser" runat="server"></asp:TextBox>
                </asp:TableCell></asp:TableRow><asp:TableRow>
                <asp:TableHeaderCell>Password</asp:TableHeaderCell><asp:TableCell>
                    <asp:TextBox ID="txtPass" runat="server" TextMode="Password"></asp:TextBox>
                </asp:TableCell></asp:TableRow><asp:TableRow>
                <asp:TableCell ColumnSpan="2">
                    <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Log In" />
                </asp:TableCell></asp:TableRow><asp:TableRow>
                <asp:TableCell ColumnSpan="2">
                    <asp:HyperLink ID="NewUser" runat="server" NavigateUrl="NewUser.aspx">Create New Account</asp:HyperLink>
                </asp:TableCell></asp:TableRow></asp:Table></div></form></asp:Content>