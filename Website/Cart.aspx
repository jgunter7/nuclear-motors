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
</asp:Content>
