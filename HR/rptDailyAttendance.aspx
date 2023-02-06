<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="rptDailyAttendance.aspx.cs" Inherits="HR_rptDailyAttendance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script lang="javascript" type="text/javascript">
        function CheckControl(ctrl) {
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == "." || bTrim(document.getElementById(ctrl).value) == "Select") {
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
                return false;
            }
            else {
                document.getElementById(ctrl).style.backgroundColor = "#fff";
                return true;
            }
        }
        function validate() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=txtDate.ClientID%>")) {
                msg += "- Enter Date\n";
                if (ctrl == "")
                    ctrl = "<%=txtDate.ClientID%>";
                flag = false;
            }if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }
    </script>
    <div class="container">
        <div class="heading">
            <h2>Daily Attendance</h2>
        </div>
        <div>
            <asp:UpdatePanel ID="updatePannel" runat="server">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td style="vertical-align: top">
                                <table>
                                    <tr>
                                        <td>
                                            <table>
                                                <tr>

                                                    <th>BY INSTITUTE</th>
                                                    <td>&nbsp;</td>
                                                    <th>BY DEPARTMENT</th>
                                                    <td>&nbsp;</td>
                                                    <th>BY JOB TYPE</th>
                                                    <td>&nbsp;</td>
                                                    <th>BY DATE<span class="required">*</span></th>
                                                    <td>&nbsp;</td>

                                                    <th>BY STATUS</th>

                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:DropDownList ID="ddlInstitute" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlInstitute_SelectedIndexChanged" Width="110px"></asp:DropDownList></td>
                                                    <td>&nbsp;</td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlDepartment" runat="server" Width="210px">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>&nbsp;</td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlJobType" runat="server" Width="105px">
                                                            <asp:ListItem Value="2">All</asp:ListItem>
                                                            <asp:ListItem Value="1">Teaching</asp:ListItem>
                                                            <asp:ListItem Value="0">Non-Teaching</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>&nbsp;</td>

                                                    <td>
                                                        <asp:TextBox ID="txtDate" runat="server" Width="100px"></asp:TextBox></td>
                                                    <td>&nbsp;</td>

                                                    <td>
                                                        <asp:DropDownList ID="ddlStatus" runat="server" Width="105px">
                                                            <asp:ListItem Value="0">All</asp:ListItem>
                                                            <asp:ListItem Value="1">Present</asp:ListItem>
                                                            <asp:ListItem Value="2">Absent</asp:ListItem>
                                                            <asp:ListItem Value="3">On-Leave</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:GridView ID="gridAttenanceReg" runat="server" CssClass="gridDynamic" EmptyDataText="No recored found" AutoGenerateColumns="False">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S.No.">
                                                        <ItemTemplate><%#((GridViewRow)Container).RowIndex+1 %></ItemTemplate>
                                                        <ItemStyle Width="15px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="EMP_ID" HeaderText="Code" />
                                                    <asp:BoundField DataField="EMP_NAME" HeaderText="Name" />
                                                    <asp:BoundField DataField="DEPT_VALUE" HeaderText="Department" />
                                                    <asp:BoundField DataField="PHN_NO" HeaderText="Contact No" />
                                                    <asp:BoundField HeaderText="In-Time" ItemStyle-Width="100px" />
                                                    <asp:BoundField HeaderText="Out-Time" ItemStyle-Width="100px" />
                                                    <asp:BoundField HeaderText="Status" ItemStyle-Width="130px" />
                                                </Columns>
                                            </asp:GridView>

                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate" Format="dd/MM/yyyy">
                                            </ajaxToolkit:CalendarExtender>
                                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender5" runat="server" Mask="99/99/9999" MaskType="Date"
                                                TargetControlID="txtDate">
                                            </ajaxToolkit:MaskedEditExtender>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td style="width: 200px; vertical-align: top">
                                <table>
                                    <tr>

                                        <td>
                                            <h4>Total Employee </h4>

                                            <asp:Label ID="lblTotal" Font-Bold="true" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h3>Present </h3>
                                            <asp:Label ID="lblPresent" Font-Bold="true" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="color:#fff;background-color:lawngreen;">
                                            <h3>On Leave</h3>
                                            <asp:Label ID="lblLeave" Font-Bold="true" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                     <tr>
                                        <td style="color:#fff;background-color:Orange;">
                                            <h3>Leave Applied</h3>
                                            <asp:Label ID="lblAppLeave" Font-Bold="True" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="color:#fff;background-color:red;">
                                            <h3>Absent</h3>
                                            <asp:Label ID="lblAbsent" Font-Bold="true" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    
                                </table>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

