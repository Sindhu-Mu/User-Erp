<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="rptLvMain.aspx.cs" Inherits="HR_rptLvMain" %>

<%@ Register Src="../Control/MonthYear.ascx" TagName="MonthYear" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="heading">

            <h2>Leave Report</h2>
        </div>
        <div>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                <ProgressTemplate>
                    <img src="../Siteimages/loading.gif" alt="loading" />
                </ProgressTemplate>
            </asp:UpdateProgress>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td>
                                <table
                                    id="tblColumns">
                                    <tr>
                                        <td style="width: 60%; border-right-style: ridge; vertical-align: top">
                                            <table>
                                                <tr>
                                                    <th>Filters
                                                    </th>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table style="margin: 0px; border: 0px;">
                                                            <tr>
                                                                <th colspan="2" style="width: 35%">By Institution
                                                                </th>
                                                                <th colspan="2" style="width: 35%">By Department</th>

                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" style="width: 200px">
                                                                    <asp:DropDownList ID="ddlIns" runat="server" Width="180px" OnSelectedIndexChanged="ddlIns_SelectedIndexChanged" AutoPostBack="true">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td colspan="2" style="width: 200px">
                                                                    <asp:DropDownList ID="ddlDept" runat="server" Width="180px">
                                                                    </asp:DropDownList>
                                                                </td>


                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table style="margin: 0px; border: 0px">
                                                            <tr>
                                                                <th colspan="2" style="width: 265px">By Status
                                                                </th>
                                                                <th colspan="2" style="width: 200px">By Employee
                                                                </th>

                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table style="margin: 0px; border: 0px">
                                                            <tr>
                                                                <td colspan="2" style="width: 200px">
                                                                    <asp:DropDownList ID="ddlStatus" runat="server" Width="180px">
                                                                        <asp:ListItem Value=".">All</asp:ListItem>
                                                                        <asp:ListItem Value="-2">Apply</asp:ListItem>
                                                                        <asp:ListItem Value="-1">Arrangement Accept</asp:ListItem>
                                                                        <asp:ListItem Value="1">Recommanded</asp:ListItem>
                                                                        <asp:ListItem Value="2">Approved</asp:ListItem>
                                                                        <asp:ListItem Value="0">Reject</asp:ListItem>
                                                                        <asp:ListItem Value="3">Cancel Apply</asp:ListItem>
                                                                        <asp:ListItem Value="4">Cancel Approved</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td colspan="2" style="width: 200px">
                                                                    <asp:TextBox ID="txtEmployee" runat="server"></asp:TextBox>
                                                                    <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionInterval="500"
                                                                        CompletionSetCount="12" ContextKey="1" EnableCaching="true" MinimumPrefixLength="1"
                                                                        ServiceMethod="GetEmployeeList" ServicePath="~\AutoComplete.asmx" TargetControlID="txtEmployee">
                                                                    </ajaxToolkit:AutoCompleteExtender>
                                                                </td>
                                                            </tr>

                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table style="margin: 0px; border: 0px;">

                                                            <tr>
                                                                <td>
                                                                    <table style="margin: 0px; border: 0px;">
                                                                        <tr>
                                                                            <th colspan="2" style="width: 35%">By Leave Type
                                                                            </th>
                                                                            <th colspan="2" style="width: 35%">View Type</th>

                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" style="width: 200px">
                                                                                <asp:DropDownList ID="ddlLvType" runat="server" Width="180px" OnSelectedIndexChanged="ddlLvType_SelectedIndexChanged" AutoPostBack="true">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <td colspan="2" style="width: 200px">
                                                                                <asp:DropDownList ID="ddlViewType" runat="server" Width="180px" OnSelectedIndexChanged="ddlViewType_SelectedIndexChanged" AutoPostBack="true">
                                                                                    <asp:ListItem Value="3">SELECT</asp:ListItem>
                                                                                    <asp:ListItem Value="0">Count</asp:ListItem>
                                                                                    <asp:ListItem Value="1">Count With Leave</asp:ListItem>
                                                                                    <asp:ListItem Value="2">Detail</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th colspan="2" style="width: 200px">By Date Type
                                                    </th>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" style="width: 200px; vertical-align: top">
                                                        <asp:DropDownList ID="ddlDateType" runat="server" Width="180px" OnSelectedIndexChanged="ddlDateType_SelectedIndexChanged" AutoPostBack="true">
                                                            <asp:ListItem Value="Y">Yearly</asp:ListItem>
                                                            <asp:ListItem Value="D">Daily</asp:ListItem>
                                                            <asp:ListItem Value="M">Monthly</asp:ListItem>
                                                            <asp:ListItem Value="DR">Date Range</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table style="margin: 0px; border: 0px">
                                                            <tr>

                                                                <td colspan="2">
                                                                    <table>
                                                                        <tr id="trYear" runat="server">
                                                                            <th colspan="2" style="height: 20px">Yearly:</th>
                                                                            <td colspan="2" style="height: 20px">
                                                                                <asp:DropDownList ID="ddlYear" runat="server">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="trMonth" runat="server" visible="false">
                                                                            <th colspan="2">Monthly:</th>
                                                                            <td colspan="2">
                                                                                <uc2:MonthYear ID="MonthYear2" runat="server" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="trDaily" runat="server" visible="false">
                                                                            <th colspan="2">Daily :</th>
                                                                            <td colspan="2">
                                                                                <asp:TextBox ID="txtDate" runat="server" Width="80px" CssClass="textbox"></asp:TextBox>
                                                                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txtDate"
                                                                                    Mask="99/99/9999" MaskType="Date">
                                                                                </ajaxToolkit:MaskedEditExtender>
                                                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtDate"
                                                                                    Format="dd/MM/yyyy">
                                                                                </ajaxToolkit:CalendarExtender>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="trDR" runat="server" visible="false">
                                                                            <th colspan="1">From Date:</th>
                                                                            <td style="width: 9%">
                                                                                <asp:TextBox ID="txtFrom" runat="server" CssClass="textbox" Width="77px"></asp:TextBox>
                                                                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender4" runat="server" TargetControlID="txtFrom"
                                                                                    Mask="99/99/9999" MaskType="Date">
                                                                                </ajaxToolkit:MaskedEditExtender>
                                                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtFrom"
                                                                                    Format="dd/MM/yyyy">
                                                                                </ajaxToolkit:CalendarExtender>
                                                                            </td>
                                                                            <th>To Date:</th>
                                                                            <td>
                                                                                <asp:TextBox ID="txtTo" runat="server" CssClass="textbox" Width="80px"></asp:TextBox>
                                                                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtTo"
                                                                                    Mask="99/99/9999" MaskType="Date">
                                                                                </ajaxToolkit:MaskedEditExtender>
                                                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtTo"
                                                                                    Format="dd/MM/yyyy">
                                                                                </ajaxToolkit:CalendarExtender>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>

                                                        </table>
                                                    </td>
                                                </tr>
                                                <%--<tr>
                                            <th>Leave Detail
                                            </th>
                                        </tr>--%>

                                                <%--<tr>
                                            <th>Compensatory Detail
                                            </th>
                                        </tr>--%>

                                                <%--<tr>
                                            <td>
                                                <table style="margin: 0px; border: 0px;">
                                                    <tr>


                                                        <th colspan="3" style="width: 200px">By Date </th>
                                                    </tr>
                                                    <tr>

                                                        <td>
                                                            <asp:DropDownList ID="ddlDate" runat="server" Width="80px" AutoPostBack="true" OnSelectedIndexChanged="DateType_Change">
                                                                <asp:ListItem Value="0" Text="All"></asp:ListItem>
                                                                <asp:ListItem Value="1" Text="Less Than"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="Greater Than"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="Between"></asp:ListItem>
                                                            </asp:DropDownList></td>
                                                        <td>
                                                            <asp:TextBox ID="txtFromDate" runat="server" Width="120px"></asp:TextBox>&nbsp;
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtToDate" runat="server" Width="120px"></asp:TextBox>&nbsp;
                                                        </td>

                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>--%>
                                                <%-- <tr>
                                            <th>Short Leave</th>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table style="margin: 0px; border: 0px;">
                                                    <tr>
                                                        <th colspan="2" style="width: 100%">By Month & Year </th>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 200px" colspan="2">
                                                            <uc2:MonthYear ID="MonthYear1" runat="server" />
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>--%>
                                                <tr>
                                                    <th>Pending Leave
                                                    </th>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table style="margin: 0px; border: 0px;">
                                                            <tr>
                                                                <th style="width: 35%" colspan="2">Pending With</th>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 200px" colspan="2">
                                                                    <asp:TextBox ID="txtPendingWith" runat="server"></asp:TextBox>
                                                                    <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" CompletionInterval="500"
                                                                        CompletionSetCount="12" ContextKey="1" EnableCaching="true" MinimumPrefixLength="1"
                                                                        ServiceMethod="GetEmployeeList" ServicePath="~\AutoComplete.asmx" TargetControlID="txtPendingWith">
                                                                    </ajaxToolkit:AutoCompleteExtender>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table style="margin: 0px; border: 0px;">
                                                        </table>
                                                    </td>
                                                </tr>

                                            </table>
                                        </td>
                                        <td style="width: 60%; vertical-align: top">
                                            <table style="width: 100%">
                                                <tr>
                                                    <th>Fields
                                                    </th>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:CheckBoxList ID="chkBox" runat="server" CssClass="checkList" RepeatColumns="3">
                                                            <asp:ListItem Value="EV.DEPT_VALUE" Text="Department"></asp:ListItem>
                                                            <asp:ListItem Value="EV.INS_VALUE" Text="Institution"></asp:ListItem>
                                                            <asp:ListItem Value="EV.DES_VALUE" Text="Designation"></asp:ListItem>
                                                        </asp:CheckBoxList>
                                                    </td>
                                                </tr>
                                                <tr id="trLv" runat="server" visible="false">
                                                    <th>Leave Detail
                                                    </th>
                                                </tr>
                                                <tr id="trLeave" runat="server" visible="false">
                                                    <td>
                                                        <asp:CheckBoxList ID="chkLv" runat="server" CssClass="checkList" RepeatColumns="3">
                                                            <asp:ListItem Value="LV.TOT_DAYS" Text="Days"></asp:ListItem>
                                                            <asp:ListItem Value="LV.REASON" Text="Reason"></asp:ListItem>
                                                            <asp:ListItem Value="CONVERT(VARCHAR,LV.FROM_DT,103)" Text="From Date"></asp:ListItem>
                                                            <asp:ListItem Value="CONVERT(VARCHAR,LV.TO_DT,103)" Text="To Date"></asp:ListItem>
                                                            <asp:ListItem Value="LV.LV_VALUE" Text="Leave Type"></asp:ListItem>
                                                            <asp:ListItem Value="LV.STS_VALUE" Text="Status"></asp:ListItem>
                                                        </asp:CheckBoxList>
                                                    </td>
                                                </tr>
                                                <%-- <tr>
                                            <th>Compensatory Detail
                                            </th>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:CheckBoxList ID="chkCom" runat="server" CssClass="checkList" RepeatColumns="3">
                                                    <asp:ListItem Value="" Text="Work Date"></asp:ListItem>
                                                    <asp:ListItem Value="" Text="Action Date"></asp:ListItem>
                                                    <asp:ListItem Value="" Text="Sanction By"></asp:ListItem>
                                                </asp:CheckBoxList>
                                            </td>
                                        </tr>--%>
                                                <tr id="trSL" runat="server" visible="false">
                                                    <th>Short Leave</th>
                                                </tr>
                                                <tr id="trShort" runat="server" visible="false">
                                                    <td>
                                                        <asp:CheckBoxList ID="chkSL" runat="server" CssClass="checkList" RepeatColumns="3">
                                                            <asp:ListItem Value="CONVERT(VARCHAR, LV.TO_DT, 103)" Text="Date"></asp:ListItem>
                                                            <asp:ListItem Value="CONVERT(VARCHAR,LV.ACT_DT,103)" Text="Transaction Date"></asp:ListItem>
                                                            <asp:ListItem Value="LV.REASON" Text="Reason"></asp:ListItem>
                                                            <asp:ListItem Value=" CONVERT(CHAR(5), LV.FROM_DT, 108)" Text="Start Time"></asp:ListItem>
                                                            <asp:ListItem Value="CONVERT(CHAR(5), LV.TO_DT, 108)" Text="End time"></asp:ListItem>
                                                            <asp:ListItem Value="PROC_STS_TYPE_INF.STS_VALUE" Text="Transaction"></asp:ListItem>
                                                            <asp:ListItem Value="EMP_VIEW.EMP_NAME" Text="Transaction By"></asp:ListItem>
                                                        </asp:CheckBoxList>
                                                    </td>
                                                </tr>

                                                <tr id="trPen" runat="server" visible="false">
                                                    <th>Pending Leave
                                                    </th>
                                                </tr>
                                                <tr id="trpending" runat="server" visible="false">
                                                    <td>
                                                        <asp:CheckBoxList ID="chkPen" runat="server" CssClass="checkList" RepeatColumns="3">
                                                            <asp:ListItem Value="CONVERT(VARCHAR,LV.ACT_DT,103)" Text="Apply Date"></asp:ListItem>
                                                            <asp:ListItem Value="LV.LV_VALUE" Text="Leave Type"></asp:ListItem>
                                                            <asp:ListItem Value="CONVERT(VARCHAR,LV.FROM_DT,103)" Text="From Date"></asp:ListItem>
                                                            <asp:ListItem Value="LV.PENDING_WITH +':'+EMP_VIEW.EMP_NAME" Text="Pending With"></asp:ListItem>
                                                            <asp:ListItem Value="CONVERT(VARCHAR,LV.TO_DT,103)" Text="To Date"></asp:ListItem>
                                                            <asp:ListItem Value="LV.TOT_DAYS" Text="Days"></asp:ListItem>
                                                            <asp:ListItem Value="LV.STS_VALUE" Text="Status"></asp:ListItem>
                                                        </asp:CheckBoxList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btnExecute" runat="server" Text="View" CssClass="btnBrown" Width="64px" OnClick="btnExecute_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>

                                </table>
                            </td>
                        </tr>
                        <%--<tr>
                            <td>
                                <div style="overflow: auto; width: 100%; height: 400px">
                                    <asp:GridView ID="gvCount" runat="server" CssClass="gridDynamic"></asp:GridView>
                                </div>
                            </td>
                        </tr>--%>
                        <tr>
                            <td style="height: 20px">&nbsp;</td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

