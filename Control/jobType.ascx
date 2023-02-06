<%@ Control Language="C#" AutoEventWireup="true" CodeFile="jobType.ascx.cs" Inherits="control_ddlJobType" %>
<asp:DropDownList ID="ddlJobType" runat="server" Width="95px">
    <asp:ListItem Value="." Selected="True">Select</asp:ListItem>
    <asp:ListItem Value="1">Teaching</asp:ListItem>
    <asp:ListItem Value=".">Non-Teaching</asp:ListItem>
</asp:DropDownList>
