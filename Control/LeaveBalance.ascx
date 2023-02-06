<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LeaveBalance.ascx.cs" Inherits="Control_LeaveBalance" %>
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" EmptyDataText="No Record Found" Font-Names="Tahoma" Font-Size="12px">
        <Columns>
            <asp:BoundField HeaderText="Leave Type" DataField="LV_VALUE" />
            <asp:BoundField HeaderText="Applied" DataField="APPLIED_BAL" >
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField HeaderText="Balance" DataField="CURRENT_BAL" >
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="LAPSED_BAL" HeaderText="Lapsed" />
            <asp:BoundField HeaderText="Availed" DataField="AVAILED_BAL" >
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            
        </Columns>
    </asp:GridView>
