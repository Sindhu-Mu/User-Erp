<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="OnDutyApplication.aspx.cs" Inherits="HR_OnDutyApplication" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script lang="javascript" type="text/javascript">
        function CheckControl(ctrl) {
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == ".") {
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
                return false;
            }
            else
                document.getElementById(ctrl).style.backgroundColor = "#fff";
            return true;
        }
        function CheckDate(ctrl) {
            var dt = document.getElementById(ctrl).value;
            if (!isDatecheck(dt, "dd/MM/yyyy")) {
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
                return false;
            }
            else
                document.getElementById(ctrl).style.backgroundColor = "#fff";
            return true;
        }
        function getDate(ctrl, ctrl1) {
            var dd = (compareDateshr(document.getElementById(ctrl).value, "dd/MM/yyyy", document.getElementById(ctrl1).value, "dd/MM/yyyy"));
            if (dd == 1)
                return false;

            return true;
        }
        function validation() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckDate("<%=txtFromDate.ClientID%>")) {
                if (!CheckControl("<%=txtFromDate.ClientID%>")) {
                    msg += " * Enter From date. \n";
                    if (ctrl == "")
                        ctrl = "<%=txtFromDate.ClientID%>";
                    flag = false;
                }
                else {
                    msg += " * Enter Correct Date.  \n";
                    if (ctrl == "")
                        ctrl = "<%=txtFromDate.ClientID%>";
                    flag = false;
                }
            }
            if (!CheckDate("<%=txtToDate.ClientID%>")) {
                if (!CheckControl("<%=txtFromDate.ClientID%>")) {
                    msg += " * Enter to date. \n";
                    if (ctrl == "")
                        ctrl = "<%=txtToDate.ClientID%>";
                   flag = false;
               }
               else {
                   msg += " * Enter Correct Date.  \n";
                   if (ctrl == "")
                       ctrl = "<%=txtToDate.ClientID%>";
                    flag = false;
                }
            }
            if (!getDate("<%=txtFromDate.ClientID%>", "<%=txtToDate.ClientID%>")) {
                msg += "- From date is greater then To date\n";
                if (ctrl == "")
                    ctrl = "<%=txtFromDate.ClientID%>";
                flag = false;
            }

            if (!CheckControl("<%=ddlreason.ClientID%>")) {
                msg += "- Select Reason for On Duty\n";
                if (ctrl == "")
                    ctrl = "<%=ddlreason.ClientID%>";
                flag = false;
            }

            if (document.getElementById("<%=ddlreason.ClientID%>").value == "Others") {
                if (!CheckControl("<%=txtReason.ClientID%>")) {
                    msg += " * Enter Reason. \n";
                    if (ctrl == "")
                        ctrl = "<%=txtReason.ClientID%>";
                    flag = false;
                }
            }
            if (msg != "") alert(msg);
            if (ctrl != "") document.getElementById(ctrl).focus();
            return flag;
        }
    </script>

    <div>
        <div class="heading">
            <h2>OnDuty Application</h2>
        </div>
        <table>
            <tr>
                <td>
                    <table>
                        <tr>
                            <th>From Date<span style="color: red">*</span></th>
                            <th>To Date<span style="color: red">*</span></th>
                            <th>Apply for<span style="color: red">*</span></th>
                            <th>Reason<span style="color: red">*</span></th>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtFromDate" runat="server" Width="90px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtToDate" runat="server" Width="90px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlApply" runat="server" Width="100px">
                                    <asp:ListItem Value="0">Full Day</asp:ListItem>
                                    <asp:ListItem Value="1">First Half</asp:ListItem>
                                    <asp:ListItem Value="2">Second Half</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlreason" runat="server" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="ddlreason_SelectedIndexChanged">
                                    <asp:ListItem Value=".">Select</asp:ListItem>
                                    <asp:ListItem>On-Duty Outside the Campus</asp:ListItem>
                                    <asp:ListItem>Forget to mark Attendance</asp:ListItem>
                                   <%-- <asp:ListItem>Traffic jam
                                    </asp:ListItem>
                                    <asp:ListItem>Taking Scheduled Class</asp:ListItem>
                                    <asp:ListItem>MU Visit</asp:ListItem>--%>
                                    <asp:ListItem>Others</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td id="tdReason" runat="server" visible="false">
                                <asp:TextBox ID="txtReason" runat="server" Width="170px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
           
            <tr >
                <td>
                    <asp:GridView
                        ID="gvShow" runat="server" AutoGenerateColumns="False" Caption="Application Detail" EmptyDataText="No record found" CssClass="gridDynamic">
                        <Columns>
                            <asp:TemplateField HeaderText="S.No.">
                                <ItemTemplate>
                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                </ItemTemplate>
                                <ItemStyle Width="20px" />
                            </asp:TemplateField>

                            <asp:BoundField DataField="REQUEST_DT" DataFormatString="{0:dd/MM/yyy}" HeaderText="Request Date" />
                            <asp:BoundField DataField="FROM_DT" DataFormatString="{0:dd/MM/yyy}" HeaderText="From Date" />
                            <asp:BoundField DataField="TO_DT" DataFormatString="{0:dd/MM/yyyy}" HeaderText="To Date" />
                            <asp:BoundField DataField="TOT_DAYS" HeaderText="Days" HtmlEncode="False">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="REASON" HeaderText="Reason" />
                            <asp:BoundField HeaderText="Action By" DataField="ACTION_BY" />
                            <asp:BoundField DataField="ACTION_DT" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Action Date" />
                            <asp:BoundField DataField="STS_VALUE" HeaderText="Status" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>
                    <ajaxToolkit:MaskedEditExtender ID="MasEdit1" runat="server" Mask="99/99/9999" MaskType="Date"
                        TargetControlID="txtFromDate">
                    </ajaxToolkit:MaskedEditExtender>
                    <ajaxToolkit:CalendarExtender ID="cal1" runat="server" Format="dd/MM/yyyy" TargetControlID="txtFromDate">
                    </ajaxToolkit:CalendarExtender>
                    <ajaxToolkit:MaskedEditExtender ID="MasEdit2" runat="server" Mask="99/99/9999" MaskType="Date"
                        TargetControlID="txtToDate">
                    </ajaxToolkit:MaskedEditExtender>
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy"
                        TargetControlID="txtToDate">
                    </ajaxToolkit:CalendarExtender>
                </td>
            </tr>
        </table>
    </div>

</asp:Content>

