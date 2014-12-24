<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="jg.css" runat="server" />
    <title>Server Login</title>
</head>
<body>
    <form id="frm1" runat="server">
    <div id="login_holder">
        <div id="login">
    <asp:Label ID="lblUser" Text="User Name:" runat="server"></asp:Label>
    &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtUser" runat="server"></asp:TextBox>
        <br />
    <asp:Label ID="lblPass" Text="Password:" runat="server"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtPass" runat="server" TextMode="Password"></asp:TextBox>
        <br />
    <asp:Label ID="lblErrors" runat="server" Width="215px"></asp:Label>
    &nbsp;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Login" />
    </div>
        </div>
    </form>
</body>
</html>
