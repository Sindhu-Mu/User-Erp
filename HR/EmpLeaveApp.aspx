<%@ Page Title="ERP | Leave Main" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="EmpLeaveApp.aspx.cs" Inherits="HR_EmpLeaveApplication" %>

<%@ Register Src="~/Control/LeaveBalance.ascx" TagPrefix="uc1" TagName="LeaveBalance" %>
<%@ Register Src="~/Control/Calender.ascx" TagPrefix="uc1" TagName="Calender" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
           <style type="text/css">
        .fancy-green .ajax__tab_header {
            background: url(../Siteimages/green_bg_Tab.gif) repeat-x;
            cursor: pointer;
        }

        .fancy-green .ajax__tab_hover .ajax__tab_outer, .fancy-green .ajax__tab_active .ajax__tab_outer {
            background: url(../Siteimages/green_left_Tab.gif) no-repeat left top;
        }

        .fancy-green .ajax__tab_hover .ajax__tab_inner, .fancy-green .ajax__tab_active .ajax__tab_inner {
            background: url(../Siteimages/green_right_Tab.gif) no-repeat right top;
        }

        .fancy .ajax__tab_header {
            font-size: 13px;
            font-weight: bold;
            color: #000;
            font-family: sans-serif;
        }

            .fancy .ajax__tab_active .ajax__tab_outer, .fancy .ajax__tab_header .ajax__tab_outer, .fancy .ajax__tab_hover .ajax__tab_outer {
                height: 46px;
            }

            .fancy .ajax__tab_active .ajax__tab_inner, .fancy .ajax__tab_header .ajax__tab_inner, .fancy .ajax__tab_hover .ajax__tab_inner {
                height: 46px;
                margin-left: 16px; /* offset the width of the left image */
            }

            .fancy .ajax__tab_active .ajax__tab_tab, .fancy .ajax__tab_hover .ajax__tab_tab, .fancy .ajax__tab_header .ajax__tab_tab {
                margin: 16px 16px 0px 0px;
            }

        .fancy .ajax__tab_hover .ajax__tab_tab, .fancy .ajax__tab_active .ajax__tab_tab {
            color: #fff;
        }

        .fancy .ajax__tab_body {
            font-family: Arial;
            font-size: 10pt;
            border-top: 0;
            border: 1px solid #999999;
            padding: 8px;
            background-color: #ffffff;
        }
    </style>

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

            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }

     
    </script>

    <div class="container">
        <div class="heading">
            <h2>Leave Main</h2>
        </div>
        <div>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td style="vertical-align: top">
                                <div style="width: 670px">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" OnActiveTabChanged="TabContainer1_ActiveTabChanged" AutoPostBack="true" CssClass="fancy fancy-green" ActiveTabIndex="1">
                                                <ajaxToolkit:TabPanel runat="server" HeaderText="Leave Detail" ID="TabPanel1">
                                                    <ContentTemplate>
                                                        <div>
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
                                                                <tr>
                                                                    <td><a href="EmpLvDetail.aspx">For more detail click here...</a></td>
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
                                                                        <asp:DropDownList ID="ddlLvType" runat="server" Width="120px" AutoPostBack="True" OnSelectedIndexChanged="ddlLvType_SelectedIndexChanged"></asp:DropDownList></td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtFromDt" runat="server"></asp:TextBox><ajaxToolkit:MaskedEditExtender ID="MasEdit2" runat="server" Mask="99/99/9999" MaskType="Date"
                                                                            TargetControlID="txtFromDt" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True">
                                                                        </ajaxToolkit:MaskedEditExtender>
                                                                    </td>
                                                                    <td id="tdToDt" runat="server">
                                                                        <asp:TextBox ID="txtToDt" runat="server"></asp:TextBox><ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender4" runat="server" Mask="99/99/9999" MaskType="Date"
                                                                            TargetControlID="txtToDt" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True">
                                                                        </ajaxToolkit:MaskedEditExtender>
                                                                    </td>
                                                                    <td id="tdSLTime" runat="server" visible="False">
                                                                        <asp:TextBox ID="txtFrmTime" runat="server" Width="40px"></asp:TextBox>(HH:MM) Use 24hr Format
                                                        <ajaxToolkit:MaskedEditExtender
                                                            ID="MaskedEditExtender3" runat="server" CultureName="en-US"
                                                            Mask="99:99" MaskType="Time" TargetControlID="txtFrmTime" CultureAMPMPlaceholder="AM;PM" CultureCurrencySymbolPlaceholder="$" CultureDateFormat="MDY" CultureDatePlaceholder="/" CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":" Enabled="True">
                                                        </ajaxToolkit:MaskedEditExtender>
                                                                    </td>
                                                                    <td id="tdDType" runat="server">
                                                                        <asp:DropDownList ID="ddlDayType" runat="server" OnSelectedIndexChanged="ddlDayType_SelectedIndexChanged" AutoPostBack="true">
                                                                            <asp:ListItem Value="0">Full day</asp:ListItem>
                                                                            <asp:ListItem Value="1">First half</asp:ListItem>
                                                                            <asp:ListItem Value="2">Second half</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>

                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="txtFromDt" Enabled="True"></ajaxToolkit:CalendarExtender>
                                                                    </td>
                                                                    <td>
                                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" runat="server" TargetControlID="txtToDt" Enabled="True"></ajaxToolkit:CalendarExtender>
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
                                                                    <td colspan="4" runat="server">
                                                                        <table>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:GridView ID="gvLvArr" runat="server" AutoGenerateColumns="False" CssClass="gridDynamic" DataKeyNames="TT_DET_ID">
                                                                                        <Columns>
                                                                                            <asp:TemplateField HeaderText="S.No.">
                                                                                                <ItemTemplate><%#((GridViewRow)Container).RowIndex+1 %></ItemTemplate>
                                                                                                <ItemStyle Width="15px" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:BoundField DataField="CLS_DATE" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy}" />
                                                                                            <asp:BoundField DataField="TT_SLOT_VALUE" HeaderText="Time Slot">
                                                                                                <ItemStyle Width="95px" />
                                                                                            </asp:BoundField>
                                                                                            <asp:BoundField DataField="PAPER_CODE" HeaderText="Course Code" />

                                                                                            <asp:TemplateField HeaderText="Arrange With">
                                                                                                <ItemTemplate>
                                                                                                    <asp:TextBox ID="txtArrEmp" runat="server"></asp:TextBox>
                                                                                                    <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionSetCount="12"
                                                                                                        EnableCaching="true" MinimumPrefixLength="1" ServiceMethod="GetEmployeeList"
                                                                                                        ServicePath="~\AutoComplete.asmx" TargetControlID="txtArrEmp" ContextKey="1,2">
                                                                                                    </ajaxToolkit:AutoCompleteExtender>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Duty Description">
                                                                                                <ItemTemplate>
                                                                                                    <asp:TextBox ID="txtArrRemark" runat="server"></asp:TextBox>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                    </asp:GridView>
                                                                                </td>
                                                                            </tr>
                                                                            <tr id="trArrTxt" runat="server" visible="False">
                                                                                <td runat="server">
                                                                                    <table>
                                                                                        <tr>
                                                                                            <td>Arrange With<span style="color: red">*</span></td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtArrWith" runat="server"></asp:TextBox>
                                                                                                <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionSetCount="12" MinimumPrefixLength="1" ServiceMethod="GetEmployeeList"
                                                                                                    ServicePath="~\AutoComplete.asmx" TargetControlID="txtArrWith" ContextKey="1,2" DelimiterCharacters="" Enabled="True" UseContextKey="True">
                                                                                                </ajaxToolkit:AutoCompleteExtender>
                                                                                            </td>
                                                                                            <td>Duty Description</td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtArrDesp" runat="server"></asp:TextBox></td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                        </table>

                                                                    </td>
                                                                </tr>
                                                                <tr id="trSave" runat="server" visible="False">
                                                                    <td colspan="4" runat="server">
                                                                        <table style="text-align: center">
                                                                            <tr>
                                                                                <td>No. of days : <b>
                                                                                    <asp:Label ID="lblNod" runat="server"></asp:Label></b></td>
                                                                                <td></td>
                                                                                <td>
                                                                                    <asp:Button ID="btnAppSave" runat="server" Text="Save" OnClick="btnAppSave_Click" />
                                                                                    <asp:TextBox ID="txtData" runat="server" Visible="False"></asp:TextBox></td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>

                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </ContentTemplate>
                                                </ajaxToolkit:TabPanel>
                                                <%--<ajaxToolkit:TabPanel runat="server" HeaderText="Compensatory Leave Credit" ID="TabPanel3">
                                                    <ContentTemplate>
                                                        <div>
                                                            <table>
                                                                <tr>
                                                                    <td>Working Day<span style="color: red">*</span></td>
                                                                    <td>From Time<span style="color: red">*</span></td>
                                                                    <td>To Time<span style="color: red">*</span></td>
                                                                    <td>Description<span style="color: red">*</span></td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:TextBox ID="txtComDay" runat="server"></asp:TextBox>
                                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender3" Format="dd/MM/yyyy" runat="server" TargetControlID="txtComDay" Enabled="True"></ajaxToolkit:CalendarExtender>
                                                                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender5" runat="server" Mask="99/99/9999" MaskType="Date"
                                                                            TargetControlID="txtComDay">
                                                                        </ajaxToolkit:MaskedEditExtender>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtComFTime" runat="server" Width="40px"></asp:TextBox>(HH:MM)
                                                        <ajaxToolkit:MaskedEditExtender
                                                            ID="MaskedEditExtender1" runat="server" CultureName="en-US"
                                                            Mask="99:99" MaskType="Time" TargetControlID="txtComFTime" CultureAMPMPlaceholder="AM;PM" CultureCurrencySymbolPlaceholder="$" CultureDateFormat="MDY" CultureDatePlaceholder="/" CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":" Enabled="True">
                                                        </ajaxToolkit:MaskedEditExtender>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtComTTime" runat="server" Width="40px"></asp:TextBox>(HH:MM)
                                                        <ajaxToolkit:MaskedEditExtender
                                                            ID="MaskedEditExtender2" runat="server" CultureName="en-US"
                                                            Mask="99:99" MaskType="Time" TargetControlID="txtComTTime" CultureAMPMPlaceholder="AM;PM" CultureCurrencySymbolPlaceholder="$" CultureDateFormat="MDY" CultureDatePlaceholder="/" CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":" Enabled="True">
                                                        </ajaxToolkit:MaskedEditExtender>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtDscrp" runat="server"></asp:TextBox></td>
                                                                    <td>
                                                                        <asp:Button ID="btnComSave" runat="server" Text="Save" OnClick="btnComSave_Click" /></td>
                                                                </tr>

                                                                <tr>
                                                                    <td colspan="5">
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
                                                                                <asp:BoundField DataField="STS_VALUE" HeaderText="Status" />
                                                                                <asp:BoundField DataField="ACTION_BY" HeaderText="Action By" />
                                                                                <asp:BoundField DataField="ACTION_DT" HeaderText="Action Date" />
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </ContentTemplate>
                                                </ajaxToolkit:TabPanel>--%>
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
                                                                        <asp:GridView ID="gvLvCancel" runat="server" AutoGenerateColumns="False" CssClass="gridDynamic" DataKeyNames="LV_APP_ID" OnRowCommand="gvLvCancel_RowCommand"
                                                                            EmptyDataText="No record found.">
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="S.No.">
                                                                                    <ItemTemplate><%#((GridViewRow)Container).RowIndex+1 %></ItemTemplate>
                                                                                    <ItemStyle Width="15px" />
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField DataField="LV_VALUE" HeaderText="Leave Type" />
                                                                                <asp:BoundField DataField="FROM_DT" HeaderText="From" DataFormatString="{0:dd/MM/yyyy}" />
                                                                                <asp:BoundField DataField="TO_DT" HeaderText="To" DataFormatString="{0:dd/MMyyyy}" />
                                                                                <asp:BoundField DataField="TOT_DAYS" HeaderText="Days"></asp:BoundField>
                                                                                <asp:TemplateField HeaderText="Remark">
                                                                                    <ItemTemplate>
                                                                                        <asp:TextBox ID="txtCanRe" runat="server"></asp:TextBox>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/Siteimages/delete.jpg" ShowSelectButton="True" />
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <th style="padding-top: 10px">Leave Cancellation Detail</th>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <hr color="#ff0000" noshade="noshade" size="1" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:GridView ID="gvLvCancelDetail" runat="server" AutoGenerateColumns="False" CssClass="gridDynamic" EmptyDataText="No record found.">
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
                                            </ajaxToolkit:TabContainer>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </td>
                            <td height="36" style="background-image: url('Siteimages/Disback.jpg'); background-repeat: repeat-x" valign="top">
                            <td>
                                <table>
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
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

