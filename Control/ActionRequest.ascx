<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ActionRequest.ascx.cs" Inherits="Control_ActionRequest" %>
<div class="sidebar_box">    
    <asp:Repeater ID="ActnRqrdLinks" runat="server">
        <HeaderTemplate>
            <h2>Action Request</h2>
            <ul class="side_menu">
                </HeaderTemplate>
        <ItemTemplate> <li><a href='<%# Eval("PAGE_URL") %>'><%#Eval("PAGE_VALUE") %></a></li></ItemTemplate>
        <FooterTemplate></ul></FooterTemplate>
    </asp:Repeater> 
    </div>