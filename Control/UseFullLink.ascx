<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UseFullLink.ascx.cs" Inherits="Control_UseFullLink" %>
<div class="sidebar_box">
    <asp:Repeater ID="RptUserFullLinks" runat="server">
        <HeaderTemplate>
            <h2>UseFull Links</h2>
            <ul class="side_menu">
        </HeaderTemplate>
        <ItemTemplate>
            <li><a href='<%# Eval("PAGE_URL") %>'><%#Eval("PAGE_VALUE") %></a></li>
        </ItemTemplate>
        <FooterTemplate></ul></FooterTemplate>
    </asp:Repeater>
</div>
