<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="rptInterviewMain.aspx.cs" Inherits="HR_rptInterviewMain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="heading">
            <h2>Interview Main Report
            </h2>
        </div>
        <div>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                <ProgressTemplate>
                    <img src="../Siteimages/loading.gif" alt="loading" />
                </ProgressTemplate>
            </asp:UpdateProgress>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table id="tblColumns">
                        <tr>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <ajaxToolkit:TabContainer ID="step1" runat="server" ActiveTabIndex="1" AutoPostBack="true" OnActiveTabChanged="step1_ActiveTabChanged">
                                            <ajaxToolkit:TabPanel runat="server" HeaderText="Job/Applicant Report" ID="TabPanel1">
                                                <ContentTemplate>
                                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                        <ContentTemplate>
                                                            <table>
                                                                <tr>
                                                                    <td style="width: 50%; border-right-style: ridge; vertical-align: top">
                                                                        <table>
                                                                            <tr>
                                                                                <th>Filters </th>
                                                                            </tr>
                                                                            <tr>
                                                                                <th>Jobs </th>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <table style="margin: 0px; border: 0px;">
                                                                                        <tr>
                                                                                            <th colspan="2" style="width: 30%">By Institution </th>
                                                                                            <th colspan="2" style="width: 30%">By Department</th>
                                                                                            <th colspan="2" style="width: 30%">By Designation</th>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="2" style="width: 150px">
                                                                                                <asp:DropDownList ID="ddlIns" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlIns_SelectedIndexChanged" Width="180px">
                                                                                                </asp:DropDownList>
                                                                                            </td>
                                                                                            <td colspan="2" style="width: 150px">
                                                                                                <asp:DropDownList ID="ddlDept" runat="server" Width="180px">
                                                                                                </asp:DropDownList>
                                                                                            </td>
                                                                                            <td colspan="2" style="width: 150px">
                                                                                                <asp:DropDownList ID="ddlDes" runat="server" Width="180px">
                                                                                                </asp:DropDownList>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <th>Applicants </th>
                                                                            </tr>
                                                                            <tr>
                                                                                <th>Basic</th>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <table style="margin: 0px; border: 0px;">
                                                                                        <tr>
                                                                                            <th colspan="2" style="width: 30%">By CTC</th>

                                                                                            <th colspan="2" style="width: 30%">By Status</th>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="2" style="width: 150px">
                                                                                                <asp:DropDownList ID="ddlCTC" runat="server" OnSelectedIndexChanged="ddlCTC_SelectedIndexChanged" AutoPostBack="true">
                                                                                                    <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                                                                    <asp:ListItem Value="1" Text="Current"></asp:ListItem>
                                                                                                    <asp:ListItem Value="2" Text="Expected"></asp:ListItem>
                                                                                                </asp:DropDownList>
                                                                                                <cc1:NumericTextBox ID="txtCTC" runat="server" AllowDecimal="true" DecimalPlaces="2" AllowNegative="false" Visible="false"></cc1:NumericTextBox>
                                                                                            </td>
                                                                                            <td colspan="2" style="width: 150px">
                                                                                                <asp:DropDownList ID="ddlStatus" runat="server"></asp:DropDownList>
                                                                                            </td>
                                                                                        </tr>

                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <th>Qualification</th>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <table style="margin: 0px; border: 0px">
                                                                                        <tr>
                                                                                            <th colspan="2" style="width: 30%">By Qualification</th>
                                                                                            <th colspan="2" style="width: 30%">By Course</th>

                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="2" style="width: 150px">
                                                                                                <asp:DropDownList ID="ddlQual" runat="server" Width="180px">
                                                                                                </asp:DropDownList>
                                                                                            </td>
                                                                                            <td colspan="2" style="width: 150px">
                                                                                                <asp:DropDownList ID="ddlCrs" runat="server" Width="180px">
                                                                                                </asp:DropDownList>
                                                                                            </td>


                                                                                        </tr>

                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <th>Experience</th>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <table style="margin: 0px; border: 0px">
                                                                                        <tr>
                                                                                            <th colspan="2" style="width: 30%">By Experience(Months)</th>
                                                                                            <th colspan="2" style="width: 30%">By Experience Type</th>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="2" style="width: 150px">
                                                                                                <asp:TextBox ID="txtExp" runat="server"></asp:TextBox>
                                                                                            </td>
                                                                                            <td colspan="2" style="width: 150px">
                                                                                                <asp:DropDownList ID="ddlExpType" runat="server"></asp:DropDownList>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                    <td style="width: 60%; vertical-align: top">
                                                                        <table style="width: 100%">
                                                                            <tr>
                                                                                <th>Fields </th>
                                                                            </tr>
                                                                            <tr>
                                                                                <th>Jobs </th>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:CheckBoxList ID="chkBox" runat="server" CssClass="checkList" RepeatColumns="3">
                                                                                        <asp:ListItem Text="Institution" Value="INS.INS_VALUE"></asp:ListItem>
                                                                                        <asp:ListItem Text="Department" Value="DEPT.DEPT_VALUE"></asp:ListItem>
                                                                                        <asp:ListItem Text="Designation" Value="DES.DES_VALUE"></asp:ListItem>
                                                                                        <asp:ListItem Text="Job No." Value="JOB.JOB_NO"></asp:ListItem>
                                                                                        <asp:ListItem Text="No. Of Vacancies" Value="JOB.VACANCY"></asp:ListItem>
                                                                                        <asp:ListItem Text="Selected" Value="JOB.SELECTED"></asp:ListItem>
                                                                                    </asp:CheckBoxList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <th>Applicants </th>
                                                                            </tr>
                                                                            <tr>
                                                                                <th>Basic</th>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:CheckBoxList ID="chkApplicants" runat="server" CssClass="checkList" RepeatColumns="3">
                                                                                        <asp:ListItem Text="Name" Value="CAN.F_NAME+' '+ISNULL(CAN.M_NAME,'') +' '+ CAN.L_NAME"></asp:ListItem>
                                                                                        <asp:ListItem Text="Contact No." Value="CAN.CONTACT_NO"></asp:ListItem>
                                                                                        <asp:ListItem Text="Mail Id" Value="CAN.MAIL+MAIL_DOM_INF.MAIL_DOM_VALUE"></asp:ListItem>
                                                                                        <asp:ListItem Text="Location" Value="CAN.LOCATION"></asp:ListItem>
                                                                                        <asp:ListItem Text="Current CTC." Value="CAN.CURRENT_CTC"></asp:ListItem>
                                                                                        <asp:ListItem Text="Expected CTC." Value="CAN.EXPECTED_CTC"></asp:ListItem>
                                                                                        <asp:ListItem Text="Status" Value="INT_STS_INF.INT_STS_VALUE"></asp:ListItem>
                                                                                    </asp:CheckBoxList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <th>Academic
                                                                                </th>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:CheckBoxList ID="chkAca" runat="server" CssClass="checkList" RepeatColumns="3">
                                                                                        <asp:ListItem Text="Base" Value="ACA_BASE_INF.ACA_BASE_SHORT_NAME"></asp:ListItem>
                                                                                        <asp:ListItem Text="Board" Value="ACA_BRD_INF.ACA_BRD_SHORT_NAME"></asp:ListItem>
                                                                                        <asp:ListItem Text="Course" Value="ACA_CRS_INF.ACA_CRS_VALUE"></asp:ListItem>
                                                                                        <asp:ListItem Text="Spec." Value="INT_CAN_ACA_INF.SPEC"></asp:ListItem>
                                                                                        <asp:ListItem Text="Year" Value="INT_CAN_ACA_INF.YER"></asp:ListItem>
                                                                                        <asp:ListItem Text="Percentage" Value="INT_CAN_ACA_INF.PRSNT"></asp:ListItem>
                                                                                        <asp:ListItem Text="Division" Value="DIV_INF.ACA_DIV_VALUE"></asp:ListItem>
                                                                                    </asp:CheckBoxList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <th>Experience
                                                                                </th>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:CheckBoxList ID="chkExp" runat="server" RepeatColumns="3">
                                                                                        <asp:ListItem Text="Designation" Value="INT_CAN_EXP_INF.EXP_DESIG"></asp:ListItem>
                                                                                        <asp:ListItem Text="Type" Value="EXP_TYPE_INF.EXP_TYPE_VALUE"></asp:ListItem>
                                                                                        <asp:ListItem Text="Organisation" Value="EXP_ORG_INF.ORG_NAME"></asp:ListItem>
                                                                                        <asp:ListItem Text="From Date" Value="CONVERT(VARCHAR,INT_CAN_EXP_INF.FRM_DATE, 103)"></asp:ListItem>
                                                                                        <asp:ListItem Text="To Date" Value="CONVERT(VARCHAR, INT_CAN_EXP_INF.TO_DATE, 103)"></asp:ListItem>
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
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </ContentTemplate>
                                            </ajaxToolkit:TabPanel>
                                            <ajaxToolkit:TabPanel runat="server" HeaderText="Interview Report" ID="TabPanel2">

                                                <ContentTemplate>
                                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                        <ContentTemplate>
                                                            <table>
                                                                <tr>
                                                                    <td style="width: 50%; border-right-style: ridge; vertical-align: top">
                                                                        <table>
                                                                            <tr>
                                                                                <th>Filters </th>
                                                                            </tr>

                                                                            <tr>
                                                                                <th>Interview</th>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <table style="margin: 0px; border: 0px">
                                                                                        <tr>
                                                                                            <th colspan="2" style="width: 30%">By Institute</th>
                                                                                            <th colspan="2" style="width: 30%">By Department</th>
                                                                                            <th colspan="2" style="width: 30%">By Job No.</th>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="2" style="width: 150px">
                                                                                                <asp:DropDownList ID="ddlInstitute" runat="server"  AutoPostBack="true" OnSelectedIndexChanged="ddlInstitute_SelectedIndexChanged"></asp:DropDownList>
                                                                                            </td>
                                                                                            <td colspan="2" style="width: 150px">
                                                                                                <asp:DropDownList ID="ddlDepartment" runat="server"  AutoPostBack="true" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged"></asp:DropDownList>
                                                                                            </td>
                                                                                            <td colspan="2" style="width: 150px">
                                                                                                <asp:DropDownList ID="ddlJob" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlJob_SelectedIndexChanged"></asp:DropDownList>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <th colspan="2" style="width: 30%">By Interview Date</th>
                                                                                            <th colspan="2" style="width: 30%">By Interview Time</th>
                                                                                            <th colspan="2" style="width: 30%">By Round</th>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="2" style="width: 150px">
                                                                                                <asp:DropDownList ID="ddlIntDate" runat="server" OnSelectedIndexChanged="ddlIntDate_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                                                                            </td>
                                                                                            <td colspan="2" style="width: 150px">
                                                                                                <asp:DropDownList ID="ddlIntTime" runat="server"></asp:DropDownList>
                                                                                            </td>
                                                                                            <td colspan="2" style="width: 150px">
                                                                                                <asp:DropDownList ID="ddlRound" runat="server">
                                                                                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                                                    <asp:ListItem Text="1st Round" Value="1"></asp:ListItem>
                                                                                                    <asp:ListItem Text="2nd Round" Value="2"></asp:ListItem>
                                                                                                    <asp:ListItem Text="3rd Round" Value="3"></asp:ListItem>
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
                                                                                            <th colspan="2" style="width: 30%">By Mode</th>
                                                                                            <th colspan="2" style="width: 30%">By Presence</th>
                                                                                            <th colspan="2" style="width: 30%">By Status</th>
                                                                                        </tr>
                                                                                        <tr>

                                                                                            <td colspan="2" style="width: 150px">
                                                                                                <asp:DropDownList ID="ddlIntMode" runat="server"></asp:DropDownList>
                                                                                            </td>
                                                                                            <td colspan="2" style="width: 150px">
                                                                                                <asp:DropDownList ID="ddlPre" runat="server">
                                                                                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                                                    <asp:ListItem Text="Present" Value="9"></asp:ListItem>
                                                                                                    <asp:ListItem Text="Absent" Value="10"></asp:ListItem>
                                                                                                </asp:DropDownList>
                                                                                            </td>
                                                                                            <td colspan="2" style="width: 150px">
                                                                                                <asp:DropDownList ID="ddlSts" runat="server"></asp:DropDownList>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                    <td style="width: 60%; vertical-align: top">
                                                                        <table style="width: 100%">
                                                                            <tr>
                                                                                <th>Fields </th>
                                                                            </tr>

                                                                            <tr>
                                                                                <th>Interview
                                                                                </th>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:CheckBoxList ID="chkInt" runat="server" RepeatColumns="3">
                                                                                        <asp:ListItem Text="Date" Value="CONVERT(VARCHAR,INT_MAIN_INF.INT_DATE,103)"></asp:ListItem>
                                                                                        <asp:ListItem Text="Time" Value="CONVERT(VARCHAR(5),INT_MAIN_INF.INT_DATE,108)"></asp:ListItem>
                                                                                        <%--<asp:ListItem Text="Panel" Value=""></asp:ListItem>--%>
                                                                                        <asp:ListItem Text="Job No." Value="JOB.JOB_NO"></asp:ListItem>
                                                                                        <asp:ListItem Text="Round" Value="INT_MAIN_INF.INT_ROUND"></asp:ListItem>
                                                                                        <asp:ListItem Text="Mode" Value="INT_MODE_INF.INT_MODE_VALUE"></asp:ListItem>
                                                                                    </asp:CheckBoxList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <th>Applicants </th>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:CheckBoxList ID="CheckBoxList1" runat="server" CssClass="checkList" RepeatColumns="3">
                                                                                        <asp:ListItem Text="Name" Value="CAN.F_NAME+' '+ISNULL(CAN.M_NAME,'') +' '+ CAN.L_NAME"></asp:ListItem>
                                                                                        <asp:ListItem Text="Contact No." Value="CAN.CONTACT_NO"></asp:ListItem>
                                                                                        <asp:ListItem Text="Mail Id" Value="CAN.MAIL+MAIL_DOM_INF.MAIL_DOM_VALUE"></asp:ListItem>
                                                                                        <asp:ListItem Text="Location" Value="CAN.LOCATION"></asp:ListItem>
                                                                                        <asp:ListItem Text="Current CTC." Value="CAN.CURRENT_CTC"></asp:ListItem>
                                                                                        <asp:ListItem Text="Expected CTC." Value="CAN.EXPECTED_CTC"></asp:ListItem>
                                                                                        <asp:ListItem Text="Status" Value="INT_STS_INF.INT_STS_VALUE"></asp:ListItem>
                                                                                    </asp:CheckBoxList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <th>Academic
                                                                                </th>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:CheckBoxList ID="CheckBoxList2" runat="server" CssClass="checkList" RepeatColumns="3">
                                                                                        <asp:ListItem Text="Base" Value="ACA_BASE_INF.ACA_BASE_SHORT_NAME"></asp:ListItem>
                                                                                        <asp:ListItem Text="Board" Value="ACA_BRD_INF.ACA_BRD_SHORT_NAME"></asp:ListItem>
                                                                                        <asp:ListItem Text="Course" Value="ACA_CRS_INF.ACA_CRS_VALUE"></asp:ListItem>
                                                                                        <asp:ListItem Text="Spec." Value="INT_CAN_ACA_INF.SPEC"></asp:ListItem>
                                                                                        <asp:ListItem Text="Year" Value="INT_CAN_ACA_INF.YER"></asp:ListItem>
                                                                                        <asp:ListItem Text="Percentage" Value="INT_CAN_ACA_INF.PRSNT"></asp:ListItem>
                                                                                        <asp:ListItem Text="Division" Value="DIV_INF.ACA_DIV_VALUE"></asp:ListItem>
                                                                                    </asp:CheckBoxList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <th>Experience
                                                                                </th>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:CheckBoxList ID="CheckBoxList3" runat="server" RepeatColumns="3">
                                                                                        <asp:ListItem Text="Designation" Value="INT_CAN_EXP_INF.EXP_DESIG"></asp:ListItem>
                                                                                        <asp:ListItem Text="Type" Value="EXP_TYPE_INF.EXP_TYPE_VALUE"></asp:ListItem>
                                                                                        <asp:ListItem Text="Organisation" Value="EXP_ORG_INF.ORG_NAME"></asp:ListItem>
                                                                                        <asp:ListItem Text="From Date" Value="CONVERT(VARCHAR,INT_CAN_EXP_INF.FRM_DATE, 103)"></asp:ListItem>
                                                                                        <asp:ListItem Text="To Date" Value="CONVERT(VARCHAR, INT_CAN_EXP_INF.TO_DATE, 103)"></asp:ListItem>
                                                                                    </asp:CheckBoxList>
                                                                                </td>
                                                                            </tr>


                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Button ID="btnExe" runat="server" Text="View" CssClass="btnBrown" Width="64px" OnClick="btnExe_Click" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>

                                                                </tr>
                                                            </table>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </ContentTemplate>
                                            </ajaxToolkit:TabPanel>
                                        </ajaxToolkit:TabContainer>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

