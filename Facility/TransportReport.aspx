<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="TransportReport.aspx.cs" Inherits="Facility_TransportReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="heading">
            <h2>Transport Report</h2>
        </div>
        <table>
            <tr>
                <td>
                    <table style="width: 100%; border-collapse: collapse; border-spacing: 0px;">
                        <tr>
                            <td>
                                <table style="width: 100%; margin: 0px; border: 0px;"
                                    id="tblColumns">
                                    <tr>
                                        <td style="width: 60%; border-right-style: ridge; vertical-align: top">
                                            <table style="margin: 0px; border: 0px; width: 100%;">
                                                <tr>
                                                    <th>Filters</th>
                                                </tr>
                                                <tr>
                                                    <th>By Registration
                                                    </th>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table style="margin: 0px; border: 0px;">
                                                            <tr>
                                                                <td>
                                                                    <table style="margin: 0px; border: 0px;">
                                                                        <tr>
                                                                            <th style="width: 125px">By Gender</th>
                                                                            <th style="width: 125px">By Institute</th>
                                                                            <th style="width: 150px">By Course</th>
                                                                            <th style="width: 150px">By Branch</th>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="width: 100px">
                                                                                <asp:DropDownList ID="ddlGender" runat="server" Width="100px"></asp:DropDownList>
                                                                            </td>
                                                                            <td style="width: 100px">
                                                                                <asp:DropDownList ID="ddlIns" runat="server" Width="100px" AutoPostBack="True" OnSelectedIndexChanged="ddlIns_SelectedIndexChanged"></asp:DropDownList>
                                                                            </td>
                                                                            <td style="width: 100px">
                                                                                <asp:DropDownList ID="ddlCourse" runat="server" Width="100px" AutoPostBack="True" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged"></asp:DropDownList>
                                                                            </td>
                                                                            <td style="width: 100px">
                                                                                <asp:DropDownList ID="ddlBranch" runat="server" Width="100px"></asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table style="margin: 0px; border: 0px;">
                                                            <tr>
                                                                <th style="width: 125px" colspan="3">By Date</th>
                                                                <th style="width: 125px">By Slot</th>
                                                                <th style="width: 125px">By Status</th>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100px">
                                                                    <asp:DropDownList ID="ddlDate" runat="server" Width="100px" OnSelectedIndexChanged="DateType_Change" AutoPostBack="True">
                                                                        <asp:ListItem Value="0" Text="All"></asp:ListItem>
                                                                        <asp:ListItem Value="1" Text="Less Than"></asp:ListItem>
                                                                        <asp:ListItem Value="2" Text="Greater Than"></asp:ListItem>
                                                                        <asp:ListItem Value="3" Text="Between"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td style="width: 100px">
                                                                    <asp:TextBox ID="txtSD" runat="server" Width="100px"></asp:TextBox></td>
                                                                <td style="width: 100px">
                                                                    <asp:TextBox ID="txtED" runat="server" Width="100px"></asp:TextBox></td>
                                                                <td style="width: 100px">
                                                                    <asp:DropDownList ID="ddlSlot" runat="server" Width="100px"></asp:DropDownList></td>
                                                                <td style="width: 100px">
                                                                    <asp:DropDownList ID="ddlStatus" runat="server" Width="100px" OnSelectedIndexChanged="DateType_Change" AutoPostBack="True">
                                                                        <asp:ListItem Value="0" Text="All"></asp:ListItem>
                                                                        <asp:ListItem Value="-2" Text="Apply"></asp:ListItem>
                                                                        <asp:ListItem Value="10" Text="Paid"></asp:ListItem>
                                                                        <asp:ListItem Value="11" Text="Registration Cancelled"></asp:ListItem>
                                                                        <asp:ListItem Value="9" Text="Vehicle Alloted"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                
                                                <tr>
                                                    <th>By Approval</th>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table style="margin: 0px; border: 0px;">
                                                            <tr>
                                                                <th style="width: 125px">By City</th>
                                                                <th style="width: 125px">By Route</th>
                                                                <th style="width: 125px">By Bus</th>
                                                                <th style="width: 150px">By Route/Bus Approval</th>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 125px">
                                                                    <asp:DropDownList ID="ddlCity" runat="server" Width="125px" AutoPostBack="True" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged"></asp:DropDownList>
                                                                </td>
                                                                <td style="width: 125px">
                                                                    <asp:DropDownList ID="ddlRoute" runat="server" Width="125px" AutoPostBack="True" OnSelectedIndexChanged="ddlRoute_SelectedIndexChanged"></asp:DropDownList>
                                                                </td>
                                                                <td style="width: 125px">
                                                                    <asp:DropDownList ID="ddlBus" runat="server" Width="125px"></asp:DropDownList>
                                                                </td>
                                                                <td style="width: 125px">
                                                                    <asp:DropDownList ID="ddlRouteApp" runat="server" Width="150px"></asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                             </table>
                                                    </td>
                                                </tr>
                                                
                                                <tr>
                                                    <td>
                                                        <table>
                                                <tr>
                                                    <th style="width:150px">By Session</th>
                                                    <th style="width:150px">By Sem Type</th>
                                                    <th style="width:150px">By Head Type</th>
                                                    <th style="width:150px">By Fee Head</th>
                                                </tr>
                                                <tr>
                                                    <td><asp:DropDownList ID="ddlsession" runat="server" Width="100px"></asp:DropDownList></td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlSemType" runat="server" Width="100px"></asp:DropDownList></td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlHeadType" runat="server" Width="100px"><%-- AutoPostBack="true" OnSelectedIndexChanged="ddlHeadType_SelectedIndexChanged">--%>
                                                            <asp:ListItem Value="0">Select</asp:ListItem>
                                                            <asp:ListItem Value="1">Facility</asp:ListItem>
                                                        </asp:DropDownList></td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlFeeHead" runat="server" Width="100px">
                                                             <asp:ListItem Value="0">Select</asp:ListItem>
                                                            <asp:ListItem Value="15">Transport</asp:ListItem>
                                                        </asp:DropDownList></td>
                                                </tr>
                                            </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td style="width: 60%; vertical-align: top">
                                            <table style="width: 100%">
                                                <tr>
                                                    <th>Fields</th>
                                                </tr>
                                                <tr>
                                                    <th>Personal</th>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:CheckBoxList ID="ChPersonal" runat="server" RepeatColumns="3">
                                                            <asp:ListItem Value="StuFullView.FATHER_NAME">Father Name</asp:ListItem>
                                                            <asp:ListItem Value="StuFullView.MOTHER_NAME">Mothers Name</asp:ListItem>
                                                            <asp:ListItem Value="StuFullView.GEN_VALUE">Gender</asp:ListItem>
                                                            <asp:ListItem Value="CONVERT(VARCHAR,StuFullView.DT_OF_BIRTH,103)">DOB</asp:ListItem>
                                                            <asp:ListItem Value="StuFullView.INS_VALUE">Institute</asp:ListItem>
                                                            <asp:ListItem Value="StuFullView.PGM_SHORT_NAME">Program</asp:ListItem>
                                                            <asp:ListItem Value="StuFullView.BRN_SHORT_NAME">Branch</asp:ListItem>
                                                            <asp:ListItem Value="StuFullView.ACA_SEM_NO">Semester</asp:ListItem>
                                                            <asp:ListItem Value="StuFullView.ACA_BATCH_NAME">Batch</asp:ListItem>
                                                        </asp:CheckBoxList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>Registration</th>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:CheckBoxList ID="ChReg" runat="server" RepeatColumns="3">
                                                            <asp:ListItem Value="TPT_STU_REG_MAIN_INF.CHALLAN_NO">Challan No</asp:ListItem>
                                                            <asp:ListItem Value="CONVERT(VARCHAR,TPT_STU_REG_MAIN_INF.APP_DATE,103)">Applied date</asp:ListItem>
                                                            <asp:ListItem Value="TPT_DATE_SLOT_MAPP_INF.SLOT_PRD">Slot</asp:ListItem>
                                                            <asp:ListItem Value="PROC_STS_TYPE_INF.STS_VALUE">Status</asp:ListItem>
                                                            <asp:ListItem Value="TPT_STU_REG_TRAN_INF.REMARK">Remark</asp:ListItem>
                                                        </asp:CheckBoxList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <th>Route Approval</th>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:CheckBoxList ID="ChRouteApproval" runat="server" RepeatColumns="3">
                                                            <asp:ListItem Value="TPT_CITY_INF.CITY_NAME">City</asp:ListItem>
                                                            <asp:ListItem Value="TPT_RTE_INF.RTE_NAME">Route</asp:ListItem>
                                                            <asp:ListItem Value="TPT_STU_REG_ROUTE_INF.STOPPAGE">Stoppage</asp:ListItem>
                                                            <asp:ListItem Value="EMP_VIEW.EMP_NAME">Approved By</asp:ListItem>
                                                            <asp:ListItem Value="TPT_STU_REG_ROUTE_INF.BUS_ID">Bus No</asp:ListItem>
                                                            <asp:ListItem Value="CONVERT(VARCHAR,TPT_STU_REG_TRAN_INF.IN_DT,103)">Approved Date</asp:ListItem>
                                                        </asp:CheckBoxList>
                                                    </td>
                                                </tr>
                                                 <th>Fees</th>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:CheckBoxList ID="ChFeeMain" runat="server" RepeatColumns="3">
                                                <asp:ListItem Value="(FD_FEE_AMT)">Demand</asp:ListItem>
                                                <asp:ListItem Value="(FD_ADJUST_AMT)">Adjust</asp:ListItem>
                                               
                                                <asp:ListItem Value="(FD_RCV_AMT)">Receive</asp:ListItem>
                                                 <asp:ListItem Value="(FEE_WAVE_OFF)">Wave</asp:ListItem>
                                                <asp:ListItem Value="(FD_BALANCE_AMT)">Balance</asp:ListItem>
                                            </asp:CheckBoxList></td>
                                    </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btnView" runat="server" Text="View" CssClass="btnBrown" Width="64px" OnClick="btnView_Click" /></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 20px">
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtSD"
                                    Format="dd/MM/yyyy">
                                </ajaxToolkit:CalendarExtender>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtED"
                                    Format="dd/MM/yyyy">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

