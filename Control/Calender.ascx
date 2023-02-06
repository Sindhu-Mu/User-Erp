<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Calender.ascx.cs" Inherits="Control_Calender" %>
<asp:Calendar ID="Calendar1" runat="server" BackColor="#FFFFCC"
    Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px"
    OnDayRender="Calendar1_DayRender" OnVisibleMonthChanged="Calendar1_VisibleMonthChanged"
    SelectionMode="None" Width="220px" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" ShowGridLines="True">
    <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
    <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
    <OtherMonthDayStyle ForeColor="#CC9966" />
    <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
    <DayHeaderStyle Font-Bold="True" BackColor="#FFCC66" Height="1px" />
    <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
    <SelectorStyle BackColor="#FFCC66" />
</asp:Calendar>
