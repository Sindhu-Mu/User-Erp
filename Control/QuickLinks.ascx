<%@ Control Language="C#" AutoEventWireup="true" CodeFile="QuickLinks.ascx.cs" Inherits="Control_QuickLinks" %>
<div class="sidebar_box">
    <asp:Repeater ID="RptQuickLinks" runat="server">
        <HeaderTemplate>
            <h2>Quick Links</h2>
            <ul class="side_menu">
        </HeaderTemplate>
        <ItemTemplate>
            <li><a href='<%# Eval("PAGE_URL") %>'><%#Eval("PAGE_VALUE") %></a></li>
        </ItemTemplate>
        <FooterTemplate></ul></FooterTemplate>
    </asp:Repeater>
</div>
