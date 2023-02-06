<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="SupportStaffAttendace.aspx.cs" Inherits="HR_SupportStaffAttendace" %>

<%@ Register Src="~/Control/MonthYear.ascx" TagPrefix="uc1" TagName="MonthYear" %>


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
            } if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }
    </script>
    <div class="container">
        <div class="heading">
            <h2>Support Staff Attendance</h2>
        </div>
        <div>
            <asp:UpdatePanel ID="updatePannel" runat="server">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td></td>
                            <td>
                                <asp:Button ID="btnDate" runat="server" Text="Date Wise" OnClick="btnDate_Click" />
                            </td>
                            <td>
                                <asp:Button ID="btnMonthly" runat="server" Text="Month Wise" OnClick="btnMonthly_Click" />
                            </td>
                        </tr>
                    </table>
                    <!--By Date-->
                    <table id="TableDate" runat="server" visible="false">
                        <tr>
                            <td style="vertical-align: top">
                                <table>
                                    <tr>
                                        <td>
                                            <table>
                                                <tr>

                                                    <th>BY DATE<span class="required">*</span></th>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtDate" runat="server" Width="100px"></asp:TextBox></td>

                                                    <td>&nbsp;</td>
                                                    <td>
                                                        <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" /></td>
                                                    <td>&nbsp;</td>
                                                    <td>
                                                        <asp:Button ID="btnExcelToExport" runat="server" Visible="false" Text="Export to excel" OnClick="btnExcelToExport_Click" /></td>
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
                                        <td style="color: #fff; background-color: LightPink;">
                                            <h3>In </h3>
                                            <asp:Label ID="lblIn" Font-Bold="true" runat="server"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td style="color: #fff; background-color: LightSkyBlue;">
                                            <h3>Out</h3>
                                            <asp:Label ID="lblOut" Font-Bold="true" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="color: #fff; background-color: LightGreen;">
                                            <h3>In-Out</h3>
                                            <asp:Label ID="lblInOut" Font-Bold="true" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <!--By Month-->
                    <table id="TableMonthly" runat="server" visible="false">
                        <tr>
                            <td style="vertical-align: top">
                                <table>
                                    <tr>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>Month & Year</td>
                                                    <td>&nbsp;</td>
                                                    <td>Employee Code</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <uc1:MonthYear runat="server" ID="MonthYear" />
                                                    </td>
                                                    <td>&nbsp;</td>
                                                       <td>
                                                           <asp:TextBox ID="txtEmployeeCode" runat="server"></asp:TextBox></td>
                                                       <td>&nbsp;</td>
                                                    <td>
                                                        <asp:Button ID="btnMonthlyShow" runat="server" Text="Show" OnClick="btnMonthlyShow_Click" /></td>
                                                    <td>&nbsp;</td>
                                                    <td>
                                                        <asp:Button ID="btnMonthlyExportToExcel" runat="server" Visible="false" Text="Export to excel" OnClick="btnMonthlyExportToExcel_Click" /></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:GridView ID="gridmonthlyAttenanceReg" runat="server" CssClass="gridDynamic" EmptyDataText="No recored found" AutoGenerateColumns="False">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S.No.">
                                                        <ItemTemplate><%#((GridViewRow)Container).RowIndex+1 %></ItemTemplate>
                                                        <ItemStyle Width="15px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="Date" HeaderText="Date" />
                                                    <asp:BoundField DataField="EMP_ID" HeaderText="Code" />
                                                    <asp:BoundField HeaderText="In-Time" ItemStyle-Width="100px" />
                                                    <asp:BoundField HeaderText="Out-Time" ItemStyle-Width="100px" />
                                                    <asp:BoundField HeaderText="Status" ItemStyle-Width="130px" />
                                                </Columns>
                                            </asp:GridView>

                                        </td>
                                    </tr>

                                </table>
                            </td>

                        </tr>
                    </table>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnExcelToExport" />
                    <asp:PostBackTrigger ControlID="btnMonthlyExportToExcel" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

