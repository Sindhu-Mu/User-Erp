<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShowDutyRoster.aspx.cs" Inherits="HR_ShowDutyRoster" %>

<%@ Register Src="../Control/MonthYear.ascx" TagName="MonthYear" TagPrefix="uc2" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Duty Roster</title>
    <link href="../css/Main.css" rel="stylesheet"/>
</head>
<body style="margin: 0px">
    <form id="form1" runat="server">
        <table style="padding: 10px; font-family: Tahoma; font-size: 11px">
            <tr>
                <td><span style="font-size: 20px; font-family: Trebuchet MS">Monthly Duty Roster <span style="color: #ff0000">
                    <asp:Label ID="lblDept" runat="server" /></span></span>
                    <hr style="color: #f00; height: 1px" />
                    **Note: Cell colored in <span style="background-color: #ff99cc">PINK</span> means that employee has applied leave for that day 
                </td>

            </tr>
            <tr>
                <td>
                    <table>
                        <tr>
                            <th>Month/Year</th>
                            <td>&nbsp;</td>

                        </tr>
                        <tr>
                            <td>
                                <uc2:MonthYear ID="MonthYear1" runat="server" />
                            </td>
                            <td></td>
                        </tr>
                    </table>
                    <hr style="color: #ccc; height: 1px" />
                    <table id="tblDept" runat="server" cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="padding-right: 5px">Institution</td>
                            <td style="padding-right: 5px">
                                <asp:DropDownList ID="ddlinstitution" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlinstitution_SelectedIndexChanged">
                                </asp:DropDownList></td>
                            <td style="padding-right: 5px">Department</td>
                            <td style="padding-right: 5px">
                                <asp:DropDownList ID="ddlDept" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDept_SelectedIndexChanged" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2" id="tdMain" runat="server">Wait .....</td>
            </tr>
            <tr>
                <td>

                    <table>
                        <tr style="vertical-align: top">
                            <td style="vertical-align: top">
                                <asp:GridView ID="GridShow" runat="server" AutoGenerateColumns="False" BorderWidth="1px" EmptyDataText="No record found" Width="300px" CssClass="gridDynamic" >
                                    <FooterStyle BackColor="White" ForeColor="#333333" />
                                    <RowStyle BackColor="White" ForeColor="#333333" />
                                    <EmptyDataRowStyle BackColor="#FFC0C0" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="S.No.">
                                            <ItemTemplate>
                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                            </ItemTemplate>
                                            <ItemStyle Width="15px" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="EMP_NAME" HeaderText="Employee" />
                                        <asp:BoundField HeaderText="Shift" DataField="SHIFT" ItemStyle-HorizontalAlign="Right">
                                            <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Hours" DataField="TIME" ItemStyle-HorizontalAlign="Right">
                                            <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                        </asp:BoundField>
                                    </Columns>
                                    <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                                </asp:GridView>
                            </td>

                        </tr>
                    </table>
                </td>
                <td>
                    <asp:GridView ID="gvShift" runat="server" AutoGenerateColumns="False" BorderWidth="1px" EmptyDataText="No recoed found" Width="300px" CssClass="gridDynamic">
                        <FooterStyle BackColor="White" ForeColor="#333333" />
                        <RowStyle BackColor="White" ForeColor="#333333" />
                        <EmptyDataRowStyle BackColor="#FFC0C0" />
                        <Columns>
                            <asp:TemplateField HeaderText="S.No.">
                                <ItemTemplate>
                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                </ItemTemplate>
                                <ItemStyle Width="15px" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="SHORT_NAME" HeaderText="Short Name" />
                            <asp:BoundField HeaderText="Shift Name" DataField="SHIFT_VALUE" ItemStyle-HorizontalAlign="Right">
                                <ItemStyle HorizontalAlign="Right"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Timing" DataField="TIME" ItemStyle-HorizontalAlign="Right">
                                <ItemStyle HorizontalAlign="Right"></ItemStyle>
                            </asp:BoundField>
                        </Columns>
                        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                    </asp:GridView>
                </td>
            </tr>

        </table>

    </form>
</body>
</html>
