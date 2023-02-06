<%@ Control Language="C#" AutoEventWireup="true" CodeFile="menu_old.ascx.cs" Inherits="control_menu" EnableViewState="true" %>
<link href="../css/menu.css" rel="stylesheet" />
<asp:XmlDataSource ID="XmlDataSource1" runat="server"
    XPath="DATA/PAGE_HEAD_INF"></asp:XmlDataSource>
 <div id='cssmenu' runat="server" CliendIDMode="static">
 </div>
