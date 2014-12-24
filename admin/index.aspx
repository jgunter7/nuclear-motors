<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="jg.css" />
    <title>Server Admin</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="top"></div>
        <h1>Administration</h1>
        <div class="top"></div>
        <br />
        <div id="main">
            <div id="logo">
                <img src="jgLogo.png" alt="Logo" width="100%" height="100%" />
            </div>
            <div id="con">
                <br />
                <asp:Label ID="lblCPU" runat="server" Text="Current CPU Usage:"></asp:Label><br />
                <br />
                <asp:Label ID="lblRam" runat="server" Text="Current RAM Available:"></asp:Label><br />
                <br />
                <asp:Label ID="lblUp" runat="server" Text="Server Uptime:"></asp:Label><br />
                <br />
                <asp:Label ID="lblEST" runat="server" Text="Server Time(EST):"></asp:Label><br />
                <br />
                <asp:Label ID="lblUTC" runat="server" Text="Server Time(UTC):"></asp:Label><br />
                <br />
                <hr /><br />
                <asp:Label ID="lblNuke" runat="server" Text="Total /nuke/ Hits:"></asp:Label><br />
                <br />
                <hr /><br />
                <asp:Label ID="lblUser" runat="server" Text="Current User:"></asp:Label><br /><br />
                <br />
                <hr />
                <span class="footer">Copyright &copy; 2014 Jason Gunter Inc. All Rights Reserved.</span>
            </div>
        </div>
    </form>
</body>
</html>
