<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewUser.aspx.cs" Inherits="NewUser" MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="mainContent" ContentPlaceHolderID="content" runat="server">
    <form id="form1" runat="server">
        <div id="newUserDiv" class="center">
            <asp:Table ID="tblNewUser" runat="server" CssClass="userStuff">
                <asp:TableRow>
                    <asp:TableHeaderCell>UserName:</asp:TableHeaderCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtUser" runat="server"></asp:TextBox></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableHeaderCell>First Name:</asp:TableHeaderCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableHeaderCell>Password:</asp:TableHeaderCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtPass" runat="server" TextMode="Password"></asp:TextBox></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="2">
                        <asp:Button ID="btnCreateUser" runat="server" OnClick="btnCreateUser_Click" Text="Create User" /></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="2">
                        <asp:Label ID="lblErrors" runat="server"></asp:Label></asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
    </form>
</asp:Content>
