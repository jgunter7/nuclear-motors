<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Product.aspx.cs" Inherits="Product" MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="mainContent" ContentPlaceHolderID="content" runat="server">
    <% int pID;
       try { pID = int.Parse(Request.QueryString["pId"]); }
       catch { pID = 0; }
       if (pID != 0)
       {
    %>
    <div id="singleProd">
        <form id="form2" runat="server">
            <div class="center2">
        <table id="singleTbl">
            <tr>
                <td colspan="3">
                       <asp:Label ID="prodName" runat="server" /></td>
            </tr>
            <tr>
                <td colspan="3">
                        <asp:Image ID="prodImg" runat="server" CssClass="centerCrop" />
                </td>
            </tr>
            <tr>
                <td>Current Price:</td>
                <td>
                    <asp:Label ID="prodPrice" runat="server" /></td>
                <td><asp:Panel ID="buttonHere" runat="server"></asp:Panel></td>
            </tr>
        </table>
                </div>
            </form>
    </div>
<%}
       else
       {%>
    <div id="AllProds">
        <form id="form1" runat="server">
        <asp:DropDownList ID="sorting" runat="server" AutoPostBack="True">
            <asp:ListItem Selected="True">No Sort</asp:ListItem>
            <asp:ListItem>Price: High - Low</asp:ListItem>
            <asp:ListItem>Price: Low - High</asp:ListItem>
        </asp:DropDownList>
        <asp:Panel ID="pnlAllProd" runat="server" />
            </form>
    </div>
<%} %>
</asp:Content>
