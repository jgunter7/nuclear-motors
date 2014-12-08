<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Cart.aspx.cs" Inherits="Cart" MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="mainContent" ContentPlaceHolderID="content" runat="server">
    <div id="ordHeader" class="center3">
        Current Order Total:
        <asp:Label ID="orderCost" runat="server"></asp:Label>
    </div>
    <div id="orders">
        <asp:Panel ID="pnlOrders" runat="server">
        </asp:Panel>
    </div>
    <form id="chkOut" runat="server" class="center3">
        <asp:Button ID="btnChkOut" runat="server" Text="Check Out" OnClick="btnChkOut_Click" Width="100%" />
    </form>
    <form id="paypal" runat="server" class="center3">
        <script async="async" src="https://www.paypalobjects.com/js/external/paypal-button.min.js?merchant=jgdev2014@hotmail.com" 
    data-button="buynow" 
    data-name="Order Total" 
    data-amount="<%=orderCost.Text.Substring(1,orderCost.Text.Length-1) %>"
></script>
    </form>
</asp:Content>
