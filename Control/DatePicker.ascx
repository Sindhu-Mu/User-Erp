<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DatePicker.ascx.cs" Inherits="DatePicker" %>
<asp:TextBox ID="txtDate" runat="server" Width="86px"></asp:TextBox>
<ajaxToolkit:CalendarExtender ID="cal1" runat="server" TargetControlID="txtDate" Format="dd/MM/yyyy">
</ajaxToolkit:CalendarExtender>
<ajaxToolkit:MaskedEditExtender ID="me1" runat="server" Mask="99/99/9999" MaskType="Date"
    TargetControlID="txtDate">
</ajaxToolkit:MaskedEditExtender>
