<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="StudentAttendanceCredit.aspx.cs" Inherits="Academic_StudentAttendanceCredit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript">

        function CheckAutoComplete(ctrl) {

            var Value = bTrim(document.getElementById(ctrl).value);
            if (Value.indexOf(":") > 0 && Value.length - 1 != Value.lastIndexOf(":")) {
                document.getElementById(ctrl).style.backgroundColor = "#fff";
                return true;
            }
            else
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
            return false;
        }

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
            if (!CheckAutoComplete("<%=txtEnroll.ClientID%>")) {
                msg += " * Enter enrollment no & name. \n";
                if (ctrl == "")
                    ctrl = "<%=txtEnroll.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlReason.ClientID%>")) {
                msg += " * Select Reason. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlReason.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlApproved.ClientID%>")) {
                msg += " * Select Approval authority. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlApproved.ClientID%>";
                flag = false;
            }
            if (!CheckDate("<%=txtApprovedDT.ClientID%>")) {
                if (!CheckControl("<%=txtApprovedDT.ClientID%>")) {
                    msg += " * Enter Approval date. \n";
                    if (ctrl == "")
                        ctrl = "<%=txtApprovedDT.ClientID%>";
                    flag = false;
                }
                else {
                    msg += " * Enter Correct Date.  \n";
                    if (ctrl == "")
                        ctrl = "<%=txtApprovedDT.ClientID%>";
                   flag = false;
               }
            }

            if (!CheckDate("<%=txtFromDT.ClientID%>")) {
                if (!CheckControl("<%=txtFromDT.ClientID%>")) {
                    msg += " * Enter from date. \n";
                    if (ctrl == "")
                        ctrl = "<%=txtFromDT.ClientID%>";
                    flag = false;
                }
                else {
                    msg += " * Enter Correct Date.  \n";
                    if (ctrl == "")
                        ctrl = "<%=txtFromDT.ClientID%>";
                    flag = false;
                }
            }

            if (!CheckDate("<%=txtToDT.ClientID%>")) {
                if (!CheckControl("<%=txtToDT.ClientID%>")) {
                    msg += " * Enter to date. \n";
                    if (ctrl == "")
                        ctrl = "<%=txtToDT.ClientID%>";
                    flag = false;
                }
                else {
                    msg += " * Enter Correct Date.  \n";
                    if (ctrl == "")
                        ctrl = "<%=txtToDT.ClientID%>";
                    flag = false;
                }
            }

            if (!getDate("<%=txtFromDT.ClientID%>", "<%=txtToDT.ClientID%>")) {
                msg += "- From date is greater then To date\n";
                if (ctrl == "")
                    ctrl = "<%=txtFromDT.ClientID%>";
                flag = false;
            }


            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }

    </script>

    <table>
        <tr>
            <td>
                <div>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" AutoPostBack="true" ActiveTabIndex="1" OnActiveTabChanged="TabContainer1_ActiveTabChanged">
                                <ajaxToolkit:TabPanel runat="server" HeaderText="Credit Entry" ID="TabPanel1">
                                    <ContentTemplate>
                                        <div>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <table width="100%">
                                                            <tbody>
                                                                <tr>
                                                                    <th>Enrollment No<span class="required">*</span></th>
                                                                    <th>Reason<span class="required">*</span></th>
                                                                    <th>From Date<span class="required">*</span></th>
                                                                    <th>To Date<span class="required">*</span></th>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:TextBox ID="txtEnroll" runat="server"></asp:TextBox></td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlReason" runat="server" Width="120px">
                                                                        </asp:DropDownList></td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtFromDT" runat="server"></asp:TextBox></td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtToDT" runat="server"></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <th>Approved By<span class="required">*</span></th>
                                                                    <th>Date<span class="required">*</span></th>
                                                                    <th>Remark </th>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlApproved" runat="server" Width="120px">
                                                                        </asp:DropDownList></td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtApprovedDT" runat="server"></asp:TextBox></td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtRemark" runat="server"></asp:TextBox></td>
                                                                </tr>

                                                            </tbody>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"></asp:Button></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <ajaxToolkit:AutoCompleteExtender ID="autoComplete2" runat="server" TargetControlID="txtEnroll" ServicePath="~/AutoComplete.asmx" ServiceMethod="GetStudentList" MinimumPrefixLength="1" ContextKey="1" CompletionSetCount="12" CompletionInterval="500" DelimiterCharacters="" Enabled="True" UseContextKey="True">
                                                        </ajaxToolkit:AutoCompleteExtender>
                                                        <ajaxToolkit:MaskedEditExtender ID="ME1" runat="server" TargetControlID="txtFromDT" MaskType="Date" Mask="99/99/9999" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True">
                                                        </ajaxToolkit:MaskedEditExtender>
                                                        <ajaxToolkit:CalendarExtender ID="CalEx1" runat="server" TargetControlID="txtFromDT" Format="dd/MM/yyyy" Enabled="True">
                                                        </ajaxToolkit:CalendarExtender>
                                                        <ajaxToolkit:MaskedEditExtender ID="ME2" runat="server" TargetControlID="txtToDT" MaskType="Date" Mask="99/99/9999" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True">
                                                        </ajaxToolkit:MaskedEditExtender>
                                                        <ajaxToolkit:CalendarExtender ID="CalEx2" runat="server" TargetControlID="txtToDT" Format="dd/MM/yyyy" Enabled="True">
                                                        </ajaxToolkit:CalendarExtender>
                                                        <ajaxToolkit:MaskedEditExtender ID="ME3" runat="server" TargetControlID="txtApprovedDT" MaskType="Date" Mask="99/99/9999" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True">
                                                        </ajaxToolkit:MaskedEditExtender>
                                                        <ajaxToolkit:CalendarExtender ID="CalEx3" runat="server" TargetControlID="txtApprovedDT" Format="dd/MM/yyyy" Enabled="True">
                                                        </ajaxToolkit:CalendarExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Attendance Credit <span style="COLOR: blue">Detail</span>
                                                        <hr color="blue" noshade size="1" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:GridView ID="gvDetail" runat="server" Width="97%" DataKeyNames="CR_ID,ENROLL" EmptyDataText="No Record Found" AutoGenerateColumns="False" CssClass="gridDynamic" OnRowDeleting="gvDetail_RowDeleting">
                                                            <EmptyDataRowStyle BackColor="#FFC0C0" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="S.No.">
                                                                    <ItemTemplate><%#((GridViewRow)Container).RowIndex+1 %></ItemTemplate>
                                                                    <ItemStyle Width="15px" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField HeaderText="REASON" DataField="CREDIT_NAME" />
                                                                <asp:BoundField HeaderText="FROM DT" DataField="CR_FROM" DataFormatString="{0:dd/MM/yyyy}" />
                                                                <asp:BoundField HeaderText="TO DT" DataField="CR_TO" DataFormatString="{0:dd/MM/yyyy}" />
                                                                <asp:BoundField HeaderText="APPROVED BY" DataField="EMP_NAME" />
                                                                <asp:BoundField HeaderText="APPROVED DT" DataField="APPROVED_DT" DataFormatString="{0:dd/MM/yyyy}" />
                                                                <asp:BoundField HeaderText="REMARK" DataField="CR_REMARK" />
                                                                <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Siteimages/delete.jpg" ShowDeleteButton="True" />
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </ContentTemplate>
                                </ajaxToolkit:TabPanel>
                                <ajaxToolkit:TabPanel runat="server" HeaderText="Credit Report" ID="TabPanel2">
                                    <ContentTemplate>
                                        <div>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <table width="100%">
                                                            <tbody>
                                                                <tr>
                                                                    <th>BY BATCH</th>
                                                                    <th>BY STUDENT</th>
                                                                    <th>BY REASON</th>
                                                                    <th>BY APPROVAL</th>
                                                                    <th>BY DATE</th>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlBatch2" runat="server" Width="120px">
                                                                        </asp:DropDownList></td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlStudent" runat="server" Width="120px" AutoPostBack="True"></asp:DropDownList></td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlReason2" runat="server" Width="120px">
                                                                        </asp:DropDownList></td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlApp" runat="server" Width="120px">
                                                                        </asp:DropDownList></td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtFrom" runat="server"></asp:TextBox></td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtTo" runat="server"></asp:TextBox></td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btnView" runat="server" Text="View" OnClick="btnView_Click"></asp:Button><ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtFrom" MaskType="Date" Mask="99/99/9999" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True">
                                                        </ajaxToolkit:MaskedEditExtender>
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFrom" Format="dd/MM/yyyy" Enabled="True">
                                                        </ajaxToolkit:CalendarExtender>
                                                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtTo" MaskType="Date" Mask="99/99/9999" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True">
                                                        </ajaxToolkit:MaskedEditExtender>
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtTo" Format="dd/MM/yyyy" Enabled="True">
                                                        </ajaxToolkit:CalendarExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <div>
                                                            <asp:GridView ID="gvShow" runat="server" Width="97%" EmptyDataText="No Record Found" AutoGenerateColumns="False" CssClass="gridDynamic">
                                                                <EmptyDataRowStyle BackColor="#FFC0C0" />
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="S.No.">
                                                                        <ItemTemplate><%#((GridViewRow)Container).RowIndex+1 %></ItemTemplate>
                                                                        <ItemStyle Width="15px" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="ENROLLMENT_NO" HeaderText="Enroll"></asp:BoundField>
                                                                    <asp:BoundField DataField="STU_FULL_NAME" HeaderText="NAME"></asp:BoundField>
                                                                    <asp:BoundField HeaderText="REASON" DataField="CREDIT_NAME"></asp:BoundField>
                                                                    <asp:BoundField HeaderText="DURATION" DataField="DURATION"></asp:BoundField>
                                                                    <asp:BoundField HeaderText="APPROVED BY" DataField="EMP_NAME"></asp:BoundField>
                                                                    <asp:BoundField HeaderText="APPROVED DT" DataField="APPROVED_DT" DataFormatString="{0:dd/MM/yyyy}"></asp:BoundField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </ContentTemplate>
                                </ajaxToolkit:TabPanel>
                            </ajaxToolkit:TabContainer>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>

