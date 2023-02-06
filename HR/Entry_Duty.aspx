<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Entry_Duty.aspx.cs" Inherits="HR_Entry_Duty" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="../js/validation.js"></script>
    <script type="text/javascript" src="../js/date.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div>
            <table bgcolor="seashell" width="550px" align="center" style="font-family: Tahoma; font-size: 10pt">
                <tr>
                    <td colspan="4" style="height: 26px">
                        <asp:Button ID="btnEvent_Add" runat="server" Text="Add New" OnClick="btnEvent_Add_Click" /></td>
                </tr>
                <tr>
                    <td align="right" class="lbl">Shift:</td>
                    <td>
                        <asp:DropDownList ID="ddlShift" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlShift_SelectedIndexChanged">
                        </asp:DropDownList>*</td>
                    <td align="right" class="lbl">Duty Off</td>
                    <td>
                        <asp:DropDownList ID="ddlOffDay" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr id="trmain" runat="server">
                    <td colspan="4">
                        <table id="maintable" width="100%">
                            <tr>
                                <td class="lbl" align="right" style="height: 16px"><strong>From Date</strong></td>
                                <td align="left" style="height: 16px">
                                    <asp:TextBox ID="txtFromDate" runat="server" Width="70px"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender3" Format="dd/MM/yyyy" runat="server" TargetControlID="txtFromDate" Enabled="True">
                                    </ajaxToolkit:CalendarExtender>
                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtFromDate" Mask="99/99/9999"
                                        MaskType="Date" Enabled="True">
                                    </ajaxToolkit:MaskedEditExtender>
                                </td>
                                <td class="lbl" align="right" style="height: 16px"><strong>To Date</strong></td>
                                <td align="left" style="height: 16px">
                                    <asp:TextBox ID="txtToDate" runat="server" Width="70px"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="txtToDate" Enabled="True">
                                    </ajaxToolkit:CalendarExtender>
                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtToDate" Mask="99/99/9999"
                                        MaskType="Date" Enabled="True">
                                    </ajaxToolkit:MaskedEditExtender>

                                </td>
                            </tr>
                            <tr>
                                <td align="right">Employee name:</td>
                                <td colspan="3">
                                    <asp:ListBox ID="lstBox1" runat="server" SelectionMode="Multiple" Width="252px" Rows="6"></asp:ListBox><span
                                        style="color: #ff0066">*</span>
                                </td>
                            </tr>

                            <tr>
                                <td colspan="4" align="center">
                                    <asp:ImageButton ID="Imgadd" runat="server" ImageUrl="~/Siteimages/1button-add.gif" OnClick="Imgadd_Click" /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="4">
                        <asp:Button ID="btnSubmit" runat="server" Text="Save and Back" OnClick="btnSubmit_Click" /><asp:Button ID="btnCancel" runat="server" Text="Cancel and Back" OnClick="btnCancel_Click" /></td>
                </tr>
                <tr>
                    <td align="center" colspan="4">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="Black" OnRowDeleting="GridView1_RowDeleting"
                            BorderColor="Black" BorderWidth="1px" CellPadding="2" CellSpacing="1" ForeColor="#333333"
                            GridLines="None" EmptyDataText="No Record found" CssClass="lb">
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <Columns>
                                <asp:BoundField HeaderText="S#" HtmlEncode="False">
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="EMP_NAME" HeaderText="Employee Name" />
                                <asp:BoundField DataField="DUTY_DATE" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Date"
                                    HtmlEncode="False" />
                                <asp:BoundField HeaderText="Shift" />
                                <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Siteimages/delete.jpg" ShowDeleteButton="True" />
                            </Columns>
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <EditRowStyle BackColor="#999999" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <EmptyDataRowStyle BackColor="#C0C0FF" />
                        </asp:GridView>
                    </td>
                </tr>

            </table>
        </div>
    </form>
</body>
</html>
