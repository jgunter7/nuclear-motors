<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Product.aspx.cs" Inherits="Product" MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="mainContent" ContentPlaceHolderID="content" runat="server">
    <% int pID;
       try { pID = int.Parse(Request.QueryString["pId"]); }
       catch { pID = 0; }
       if (pID != 0)
       {
    %>
    <div id="singleProd">
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
                <td>Add to Cart!</td>
            </tr>
        </table>
    </div>
    <%}
       else
       {%>
    <div id="AllProds">
        <asp:Panel ID="pnlAllProd" runat="server" />
    </div>
    <%} %>
</asp:Content>
