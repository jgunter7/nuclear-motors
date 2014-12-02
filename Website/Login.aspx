<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login"  MasterPageFile="~/MasterPage.master" %>

<asp:Content id="mainContent" ContentPlaceHolderID="content" runat="server">
    
    <form id="form1" runat="server">
        User Name:&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtUser" runat="server"></asp:TextBox>
        <br />
        <br />
        Password:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtPass" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Log In" />
        <asp:Label ID="lblFailed" runat="server" />
    </form>
    
</asp:Content>