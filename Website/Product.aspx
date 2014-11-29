<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Product.aspx.cs" Inherits="Product" MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="mainContent" ContentPlaceHolderID="content" runat="server">
    <% int pID;
       try { pID = int.Parse(Request.QueryString["pId"]); }
       catch { pID = 0; } 
       if (pID != 0) 
       {
       %>
    <asp:Label ID="prodId" runat="server" />
    <asp:Label ID="prodName" runat="server" />
    <asp:Image ID="prodImg" runat="server" />
    <asp:Label ID="prodPrice" runat="server" />
    <%} else {%>
    <div id="AllProds" style="margin-left:auto;margin-right:auto;display:block;width:80%;">
    <asp:Panel ID="pnlAllProd" runat="server" />
    </div>
    <%} %>     
</asp:Content>
