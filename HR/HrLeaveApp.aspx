<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="HrLeaveApp.aspx.cs" Inherits="HR_HrLeaveApp" %>

<%@ Register Src="~/Control/LeaveBalance.ascx" TagPrefix="uc1" TagName="LeaveBalance" %>
<%@ Register Src="~/Control/Calender.ascx" TagPrefix="uc1" TagName="Calender" %>

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
        function ValidateShow() {
            var flag = true;
            var msg = "", ctrl = "";

            if (!CheckAutoComplete("<%=txtEmp.ClientID%>")) {
                msg += " * Enter Employee Name & Code. \n";
                if (ctrl == "")
                    ctrl = "<%=txtEmp.ClientID%>";
                flag = false;
            }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }

        function ComValidation() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckDate("<%=txtComDay.ClientID%>")) {
                if (!CheckControl("<%=txtComDay.ClientID%>")) {
                    msg += " * Enter Working date. \n";
                    if (ctrl == "")
                        ctrl = "<%=txtComDay.ClientID%>";
                    flag = false;
                }
                else {
                    msg += " * Enter Correct Date.  \n";
                    if (ctrl == "")
                        ctrl = "<%=txtComDay.ClientID%>";
                    flag = false;
                }
            }

            if (!CheckControl("<%=ddlComAppBy.ClientID%>")) {
                msg += " * Enter Approved by. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlComAppBy.ClientID%>";
                flag = false;
            }

            if (!CheckDate("<%=txtComAppDt.ClientID%>")) {
                if (!CheckControl("<%=txtComAppDt.ClientID%>")) {
                    msg += " * Enter Approval date. \n";
                    if (ctrl == "")
                        ctrl = "<%=txtComAppDt.ClientID%>";
                    flag = false;
                }
                else {
                    msg += " * Enter Correct Date.  \n";
                    if (ctrl == "")
                        ctrl = "<%=txtComAppDt.ClientID%>";
                    flag = false;
                }
            }

            if (!CheckControl("<%=txtDscrp.ClientID%>")) {
                msg += " * Enter Description. \n";
                if (ctrl == "")
                    ctrl = "<%=txtDscrp.ClientID%>";
                flag = false;
            }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }

        function CancelValidation() {
            var flag = true;
            var msg = "", ctrl = "";

            if (!CheckControl("<%=ddlCanSan.ClientID%>")) {
                msg += " * Enter Sanction by. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlCanSan.ClientID%>";
                flag = false;
            }

            if (!CheckDate("<%=txtCancelDT.ClientID%>")) {
                if (!CheckControl("<%=txtCancelDT.ClientID%>")) {
                    msg += " * Enter Sanction Date. \n";
                    if (ctrl == "")
                        ctrl = "<%=txtCancelDT.ClientID%>";
                    flag = false;
                }
                else {
                    msg += " * Enter Correct Date.  \n";
                    if (ctrl == "")
                        ctrl = "<%=txtCancelDT.ClientID%>";
                    flag = false;
                }
            }

            if (!CheckControl("<%=txtRemark.ClientID%>")) {
                msg += " * Enter Remark. \n";
                if (ctrl == "")
                    ctrl = "<%=txtRemark.ClientID%>";
                flag = false;
            }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }

        function AddValidation() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=ddlLvType.ClientID%>")) {
                msg += " * Select Leave type from the list. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlLvType.ClientID%>";
                flag = false;
            }
            if (!CheckDate("<%=txtFromDt.ClientID%>")) {
                if (!CheckControl("<%=txtFromDt.ClientID%>")) {
                    msg += " * Enter From date. \n";
                    if (ctrl == "")
                        ctrl = "<%=txtFromDt.ClientID%>";
                    flag = false;
                }
                else {
                    msg += " * Enter Correct Date.  \n";
                    if (ctrl == "")
                        ctrl = "<%=txtFromDt.ClientID%>";
                    flag = false;
                }
            }
            if (document.getElementById("<%=ddlLvType.ClientID%>").value == "11") {
                if (!CheckControl("<%=txtFrmTime.ClientID%>")) {
                    msg += " * Enter From Time. \n";
                    if (ctrl == "")
                        ctrl = "<%=txtFrmTime.ClientID%>";
                    flag = false;
                }
            }
            else {
                if (!CheckDate("<%=txtToDt.ClientID%>")) {
                    if (!CheckControl("<%=txtToDt.ClientID%>")) {
                        msg += " * Enter To date. \n";
                        if (ctrl == "")
                            ctrl = "<%=txtToDt.ClientID%>";
                        flag = false;
                    }
                    else {
                        msg += " * Enter Correct Date.  \n";
                        if (ctrl == "")
                            ctrl = "<%=txtToDt.ClientID%>";
                        flag = false;
                    }
                }
                if (!getDate("<%=txtFromDt.ClientID%>", "<%=txtToDt.ClientID%>")) {
                    msg += "- From date is greater then To date\n";
                    if (ctrl == "")
                        ctrl = "<%=txtFromDt.ClientID%>";
                    flag = false;
                }
            }

            if (!CheckControl("<%=txtReason.ClientID%>")) {
                msg += " * Enter reason. \n";
                if (ctrl == "")
                    ctrl = "<%=txtReason.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtAdd.ClientID%>")) {
                msg += " * Enter Contect address. \n";
                if (ctrl == "")
                    ctrl = "<%=txtAdd.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlSaction.ClientID%>")) {
                msg += " * Enter Sanction by. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlSaction.ClientID%>";
                flag = false;
            }
            if (!CheckDate("<%=txtSactionDt.ClientID%>")) {
                if (!CheckControl("<%=txtSactionDt.ClientID%>")) {
                    msg += " * Enter Sanction date. \n";
                    if (ctrl == "")
                        ctrl = "<%=txtSactionDt.ClientID%>";
                    flag = false;
                }
                else {
                    msg += " * Enter Correct Date.  \n";
                    if (ctrl == "")
                        ctrl = "<%=txtSactionDt.ClientID%>";
                    flag = false;
                }
            }

            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }

    </script>



    <div class="container">
        <div class="heading">
            <h2>Leave</h2>
        </div>
        <div>
            <table>
                <tr>
                    <th style="text-align: right">Employee Name & Code
                        <asp:TextBox ID="txtEmp" runat="server"></asp:TextBox>
                        <ajaxToolkit:AutoCompleteExtender ID="autoComplete1" runat="server" CompletionInterval="500"
                            CompletionSetCount="12" ContextKey="1,2" EnableCaching="true" MinimumPrefixLength="1"
                            ServiceMethod="GetEmployeeList" ServicePath="~\AutoComplete.asmx" TargetControlID="txtEmp">
                        </ajaxToolkit:AutoCompleteExtender>
                        &nbsp;<asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" />&nbsp;</th>
                </tr>
                <tr>
                    <td>
                        <table>
                            <tr>
                                <td style="vertical-align: top" id="tdApp" runat="server" visible="false">
                                    <div style="width: 700px">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" OnActiveTabChanged="TabContainer1_ActiveTabChanged" AutoPostBack="true" ActiveTabIndex="1">
                                                    <ajaxToolkit:TabPanel runat="server" HeaderText="Leave Detail" ID="TabPanel1">
                                                        <ContentTemplate>
                                                            <div style="max-height: 500px; overflow: auto">
                                                                <table>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:GridView ID="gvLvDetail" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" EmptyDataText="No record found.">
                                                                                <Columns>
                                                                                    <asp:TemplateField HeaderText="S.No.">
                                                                                        <ItemTemplate><%#((GridViewRow)Container).RowIndex+1 %></ItemTemplate>
                                                                                        <ItemStyle Width="15px" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:BoundField HeaderText="Request Date" DataField="REQUEST_DT" />
                                                                                    <asp:BoundField HeaderText="Leave Type" DataField="LV_VALUE" />
                                                                                    <asp:BoundField HeaderText="From Date" DataField="FROM_DT" />
                                                                                    <asp:BoundField HeaderText="To Date" DataField="TO_DT" />
                                                                                    <asp:BoundField HeaderText="No. of days" DataField="TOT_DAYS" />
                                                                                    <asp:BoundField HeaderText="Action by" DataField="ACTION_BY" />
                                                                                    <asp:BoundField HeaderText="Action Date" DataField="ACTION_DT" />
                                                                                    <asp:BoundField HeaderText="Status" DataField="STS_VALUE" />
                                                                                </Columns>
                                                                            </asp:GridView>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>


                                                        </ContentTemplate>


                                                    </ajaxToolkit:TabPanel>
                                                    <ajaxToolkit:TabPanel runat="server" HeaderText="Leave Application" ID="TabPanel2">
                                                        <ContentTemplate>
                                                            <div>
                                                                <table>
                                                                    <tr>
                                                                        <td>Leave Type<span style="color: red">*</span></td>
                                                                        <td>From Date<span style="color: red">*</span></td>
                                                                        <td id="tdDt" runat="server">To Date<span style="color: red">*</span></td>
                                                                        <td id="tdSL" runat="server" visible="False">From Time<span style="color: red">*</span></td>
                                                                        <td id="tdDay" runat="server">Day Type</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddlLvType" runat="server" Width="150px" AutoPostBack="true" OnSelectedIndexChanged="ddlLvType_SelectedIndexChanged"></asp:DropDownList></td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtFromDt" runat="server"></asp:TextBox><ajaxToolkit:MaskedEditExtender ID="MasEdit2" runat="server" Mask="99/99/9999" MaskType="Date"
                                                                                TargetControlID="txtFromDt">
                                                                            </ajaxToolkit:MaskedEditExtender>
                                                                        </td>
                                                                        <td id="tdToDt" runat="server">
                                                                            <asp:TextBox ID="txtToDt" runat="server"></asp:TextBox><ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender4" runat="server" Mask="99/99/9999" MaskType="Date"
                                                                                TargetControlID="txtToDt">
                                                                            </ajaxToolkit:MaskedEditExtender>
                                                                        </td>
                                                                        <td id="tdSLTime" runat="server" visible="False">
                                                                            <asp:TextBox ID="txtFrmTime" runat="server" Width="60px"></asp:TextBox>(HH:MM)
                                                                            <ajaxToolkit:MaskedEditExtender
                                                                                ID="MaskedEditExtender3" runat="server" CultureName="en-US"
                                                                                Mask="99:99" MaskType="Time" TargetControlID="txtFrmTime" CultureAMPMPlaceholder="AM;PM" CultureCurrencySymbolPlaceholder="$" CultureDateFormat="MDY" CultureDatePlaceholder="/" CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":" Enabled="True">
                                                                            </ajaxToolkit:MaskedEditExtender>
                                                                        </td>
                                                                        <td id="tdDType" runat="server">
                                                                            <asp:DropDownList ID="ddlDayType" runat="server">
                                                                                <asp:ListItem Value="0">Full day</asp:ListItem>
                                                                                <asp:ListItem Value="1">First half</asp:ListItem>
                                                                                <asp:ListItem Value="2">Second half</asp:ListItem>
                                                                            </asp:DropDownList></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>Permission<span style="color: #ff0000">*</span></td>
                                                                        <td>Sanction Authority<span style="color: #ff0000">*</span></td>
                                                                        <td>Sanction on<span style="color: #ff0000">*</span></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:RadioButtonList ID="RDList" runat="server" RepeatDirection="Horizontal">
                                                                                <asp:ListItem Selected="True" Value="1">Normal</asp:ListItem>
                                                                                <asp:ListItem Value="2">Special</asp:ListItem>
                                                                            </asp:RadioButtonList></td>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddlSaction" runat="server" Width="150px"></asp:DropDownList></td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtSactionDt" runat="server"></asp:TextBox></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="txtFromDt" Enabled="True"></ajaxToolkit:CalendarExtender>
                                                                        </td>
                                                                        <td>
                                                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" runat="server" TargetControlID="txtToDt" Enabled="True"></ajaxToolkit:CalendarExtender>
                                                                        </td>
                                                                        <td>
                                                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender5" Format="dd/MM/yyyy" runat="server" TargetControlID="txtSactionDt" Enabled="True"></ajaxToolkit:CalendarExtender>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="4">
                                                                            <table>
                                                                                <tr>
                                                                                    <td>Reason for leave<span style="color: red">*</span></td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="txtReason" runat="server" Width="300px"></asp:TextBox></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>Contact Address<span style="color: red">*</span></td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="txtAdd" runat="server" Width="300px" TextMode="MultiLine"></asp:TextBox></td>
                                                                                    <td>
                                                                                        <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" /></td>
                                                                                    <td>
                                                                                        <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" /></td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr id="trArr" runat="server" visible="False">
                                                                        <td id="Td1" colspan="4" runat="server">
                                                                            <table>
                                                                                <tr>
                                                                                    <td>Arrange With<span style="color: red">*</span></td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="txtArrWith" runat="server"></asp:TextBox><ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionSetCount="12"
                                                                                            EnableCaching="true" MinimumPrefixLength="1" ServiceMethod="GetEmployeeList"
                                                                                            ServicePath="~\AutoComplete.asmx" TargetControlID="txtArrWith" ContextKey="1,2">
                                                                                        </ajaxToolkit:AutoCompleteExtender>
                                                                                    </td>
                                                                                    <td>Duty Description</td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="txtArrDesp" runat="server"></asp:TextBox></td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr id="trSave" runat="server" visible="False">
                                                                        <td id="Td2" colspan="4" runat="server">
                                                                            <table style="text-align: center">
                                                                                <tr>
                                                                                    <td>No. of days : <b>
                                                                                        <asp:Label ID="lblNod" runat="server"></asp:Label></b></td>
                                                                                    <td></td>
                                                                                    <td>
                                                                                        <asp:Button ID="btnAppSave" runat="server" Text="Save" OnClick="btnAppSave_Click" /><asp:TextBox ID="txtData" runat="server" Visible="False"></asp:TextBox></td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>


                                                        </ContentTemplate>


                                                    </ajaxToolkit:TabPanel>
                                                    <ajaxToolkit:TabPanel runat="server" HeaderText="Compensatory Leave Credit" ID="TabPanel3">
                                                        <ContentTemplate>
                                                            <div>
                                                                <table>
                                                                    <tr>
                                                                        <td>Working Day<span style="color: red">*</span></td>
                                                                        <td>Approved By<span style="color: red">*</span></td>
                                                                        <td>Approved Date<span style="color: red">*</span></td>
                                                                        <td>Credit No.<span style="color: red">*</span></td>
                                                                        <td>Description<span style="color: red">*</span></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:TextBox ID="txtComDay" runat="server" Width="100px"></asp:TextBox><ajaxToolkit:CalendarExtender ID="CalendarExtender3" Format="dd/MM/yyyy" runat="server" TargetControlID="txtComDay" Enabled="True"></ajaxToolkit:CalendarExtender>
                                                                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender5" runat="server" Mask="99/99/9999" MaskType="Date"
                                                                                TargetControlID="txtComDay">
                                                                            </ajaxToolkit:MaskedEditExtender>
                                                                        </td>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddlComAppBy" runat="server"></asp:DropDownList></td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtComAppDt" runat="server" Width="100px"></asp:TextBox><ajaxToolkit:CalendarExtender ID="CalendarExtender4" Format="dd/MM/yyyy" runat="server" TargetControlID="txtComAppDt" Enabled="True"></ajaxToolkit:CalendarExtender>
                                                                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="99/99/9999" MaskType="Date"
                                                                                TargetControlID="txtComAppDt">
                                                                            </ajaxToolkit:MaskedEditExtender>
                                                                        </td>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddlCredit" runat="server" Width="40px">
                                                                                <asp:ListItem>1</asp:ListItem>
                                                                                <asp:ListItem>.5</asp:ListItem>
                                                                            </asp:DropDownList></td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtDscrp" runat="server"></asp:TextBox></td>
                                                                        <td>
                                                                            <asp:Button ID="btnComSave" runat="server" Text="Save" OnClick="btnComSave_Click" /></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="6">
                                                                            <div style="max-height: 500px; overflow: auto">
                                                                                <asp:GridView ID="gvComDetail" runat="server" AutoGenerateColumns="False" CellPadding="1" CssClass="gridDynamic"
                                                                                    EmptyDataText="No Record Found ">
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="S.No.">
                                                                                            <ItemTemplate><%#((GridViewRow)Container).RowIndex+1 %></ItemTemplate>
                                                                                            <ItemStyle Width="15px" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:BoundField DataField="WORK_DT" HeaderText="Work Date" />
                                                                                        <asp:BoundField DataField="DESCRP" HeaderText="Description" />
                                                                                        <asp:BoundField DataField="APPLIED_DT" HeaderText="Applied Date" />
                                                                                        <asp:BoundField DataField="CREDIT_NO" HeaderText="No. of days" />
                                                                                        <asp:BoundField DataField="STS_VALUE" HeaderText="Status" />
                                                                                        <asp:BoundField DataField="ACTION_BY" HeaderText="Action By" />
                                                                                        <asp:BoundField DataField="ACTION_DT" HeaderText="Action Date" />
                                                                                    </Columns>
                                                                                </asp:GridView>
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>


                                                        </ContentTemplate>


                                                    </ajaxToolkit:TabPanel>
                                                    <ajaxToolkit:TabPanel runat="server" HeaderText="Leave Cancellation" ID="TabPanel4">
                                                        <ContentTemplate>
                                                            <div>
                                                                <table>
                                                                    <tr>
                                                                        <th style="padding-top: 10px">Leave For Cancellation</th>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <hr color="#ff0000" noshade="noshade" size="1" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <table>
                                                                                <tr id="trCancelSanction" runat="server" visible="False">
                                                                                    <td id="Td3" runat="server">
                                                                                        <table>
                                                                                            <tr>
                                                                                                <td>Sanction By<span style="color: #ff0000">*</span></td>
                                                                                                <td>Sanction Date<span style="color: #ff0000">*</span></td>
                                                                                                <td>Remark<span style="color: #ff0000">*</span></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <asp:DropDownList ID="ddlCanSan" runat="server" Width="175px"></asp:DropDownList></td>
                                                                                                <td>
                                                                                                    <asp:TextBox ID="txtCancelDT" runat="server"></asp:TextBox>
                                                                                                    <ajaxToolkit:MaskedEditExtender ID="MasEdit1" runat="server" Mask="99/99/9999" MaskType="Date"
                                                                                                        TargetControlID="txtCancelDT" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True">
                                                                                                    </ajaxToolkit:MaskedEditExtender>
                                                                                                    <ajaxToolkit:CalendarExtender ID="cal1" runat="server" Format="dd/MM/yyyy" TargetControlID="txtCancelDT" Enabled="True">
                                                                                                    </ajaxToolkit:CalendarExtender>

                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:TextBox ID="txtRemark" runat="server"></asp:TextBox></td>
                                                                                                <td>
                                                                                                    <asp:Button ID="btnCancelSave" runat="server" Text="Save" OnClick="btnCancelSave_Click" /></td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                    <td id="Td4" width="4" style="width: 10px" runat="server">&nbsp;</td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <div style="max-height: 500px; overflow: auto">
                                                                                <asp:GridView ID="gvLvCancel" runat="server" AutoGenerateColumns="False" CssClass="gridDynamic" DataKeyNames="LV_APP_ID" OnRowCommand="gvLvCancel_RowCommand"
                                                                                    EmptyDataText="No record found.">
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="S.No.">
                                                                                            <ItemTemplate><%#((GridViewRow)Container).RowIndex+1 %></ItemTemplate>
                                                                                            <ItemStyle Width="15px" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:BoundField DataField="LV_VALUE" HeaderText="Leave Type" />
                                                                                        <asp:BoundField DataField="FROM_DT" HeaderText="From" DataFormatString="{0:dd/MM/yyyy}" />
                                                                                        <asp:BoundField DataField="TO_DT" HeaderText="To" DataFormatString="{0:dd/MM/yyyy}" />
                                                                                        <asp:BoundField DataField="TOT_DAYS" HeaderText="Days"></asp:BoundField>
                                                                                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/Siteimages/delete.jpg" ShowSelectButton="True" />
                                                                                    </Columns>
                                                                                </asp:GridView>
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                    
                                                                </table>
                                                            </div>


                                                        </ContentTemplate>


                                                    </ajaxToolkit:TabPanel>
                                                    <ajaxToolkit:TabPanel runat="server" HeaderText="Leave Document" ID="TabPanel5">
                                                        <ContentTemplate>
                                                            <div>
                                                                <table>
                                                                    <tr id="trDocType" runat="server">
                                                                        <td runat="server">
                                                                            <table>
                                                                                <tr>
                                                                                    <td>Document to Upload<span style="color: #ff0000">*</span></td>
                                                                                    <td colspan="2">File to Upload<span style="color: #ff0000">*</span></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:TextBox ID="txtDoc2" runat="server" />

                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:FileUpload ID="upd1" runat="server" Width="250px" />

                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Button ID="btnDocSave" runat="server" Text="Save" OnClick="btnDocSave_Click" />

                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>


                                                                    <tr>
                                                                        <td>
                                                                            <div style="max-height: 500px; overflow: auto">
                                                                                <asp:GridView ID="gvDocShow" runat="server" AutoGenerateColumns="False"
                                                                                    DataKeyNames="LV_APP_ID" CssClass="gridDynamic" OnRowCommand="gvDocShow_RowCommand">
                                                                                    <Columns>
                                                                                        <asp:BoundField DataField="EMP_NAME" HeaderText="Emp Name" />
                                                                                        <asp:BoundField DataField="EMP_ID" HeaderText="Emp Code" HtmlEncode="False" />
                                                                                        <asp:BoundField DataField="LV_VALUE" HeaderText="Leave Type" />
                                                                                        <asp:BoundField DataField="FROM_DT" HeaderText="From date" DataFormatString="{0:dd/MM/yyyy}" />
                                                                                        <asp:BoundField DataField="TO_DT" HeaderText="To date" DataFormatString="{0:dd/MM/yyyy}" />
                                                                                        <asp:BoundField DataField="TOT_DAYS" HeaderText="Day's" HtmlEncode="False" />
                                                                                        <asp:BoundField HeaderText="Applied Date" DataField="REQ_DT" DataFormatString="{0:dd/MM/yyyy}"
                                                                                            HtmlEncode="False" />
                                                                                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/Siteimages/update_icon.gif" ShowSelectButton="True"
                                                                                            SelectText="Click to Upload Document" />
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
                                            <%--<Triggers>
                                                <asp:PostBackTrigger ControlID="btnDocSave" />
                                            </Triggers>--%>
                                        </asp:UpdatePanel>
                                    </div>
                                </td>
                                <td height="36" style="background-image: url('Siteimages/Disback.jpg'); background-repeat: repeat-x" valign="top">
                                <td>
                                    <table style="text-align: left">
                                        <tr>
                                            <th style="padding-top: 10px">Leave Status</th>
                                        </tr>
                                        <tr>
                                            <td>
                                                <hr color="#ff0000" noshade="noshade" size="1" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-top: 10px; padding-left: 5px">
                                                <asp:UpdatePanel ID="upd" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <uc1:LeaveBalance runat="server" ID="LeaveBalance" />
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th style="padding-top: 10px">Holiday Calender</th>
                                        </tr>
                                        <tr>
                                            <td>
                                                <hr color="#ff0000" noshade="noshade" size="1" />
                                            </td>
                                            <tr>
                                                <td style="padding-top: 10px; padding-left: 5px">
                                                    <uc1:Calender runat="server" ID="Calender" />
                                                </td>
                                            </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

