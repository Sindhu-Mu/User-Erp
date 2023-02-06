<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="rptEmployeeDetail.aspx.cs" Inherits="HR_rptEmployeeDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="heading">
            <h2>Employee Report </h2>
        </div>
        <div>
            <table>
                <tr>
                    <td>
                        <table style="width: 100%; border-collapse: collapse; border-spacing: 0px;">
                            <tr>
                                <td>
                                    <table style="width: 100%; margin: 0px; border: 0px;" id="tblColumns">
                                        <tr>
                                            <td style="width: 50%; border-right-style: ridge; vertical-align: top">
                                                <table style="margin: 0px; border: 0px; width: 80%;">
                                                    <tr>
                                                        <th>Filters
                                                        </th>
                                                    </tr>
                                                    <tr>
                                                        <th>Personal
                                                        </th>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table style="margin: 0px; border: 0px;">
                                                                <tr>
                                                                    <td>
                                                                        <table style="margin: 0px; border: 0px;">
                                                                            <tr>
                                                                                <th>By Gender
                                                                                </th>

                                                                                <th>By Marital Status
                                                                                </th>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlSex" runat="server">
                                                                                        <asp:ListItem Value="0" Text="All"></asp:ListItem>
                                                                                        <asp:ListItem Value="1" Text="Male"></asp:ListItem>
                                                                                        <asp:ListItem Value="2" Text="Female"></asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </td>

                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlMaritalStatus" runat="server">
                                                                                        <asp:ListItem Value="3" Text="All"></asp:ListItem>
                                                                                        <asp:ListItem Value="0" Text="Unmarried"></asp:ListItem>
                                                                                        <asp:ListItem Value="1" Text="Married"></asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <table style="margin: 0px; border: 0px;">
                                                                            <tr>
                                                                                <th colspan="3">By Date Of Birth</th>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlDOB" runat="server" Width="80px" AutoPostBack="true" OnSelectedIndexChanged="DateType_Change">
                                                                                        <asp:ListItem Value="0" Text="All"></asp:ListItem>
                                                                                        <asp:ListItem Value="1" Text="Less Than"></asp:ListItem>
                                                                                        <asp:ListItem Value="2" Text="Greater Than"></asp:ListItem>
                                                                                        <asp:ListItem Value="3" Text="Between"></asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtDOB1" runat="server" Width="115px" Enabled="False"></asp:TextBox>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtDOB2" runat="server" Width="115px" Enabled="False"></asp:TextBox>&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <table style="margin: 0px; border: 0px;">
                                                                            <tr>

                                                                                <th>By Nationality</th>
                                                                                <th>By Mother Tongue</th>
                                                                                <th>By Caste</th>
                                                                            </tr>
                                                                            <tr>

                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlNationality" runat="server" Width="133px">
                                                                                    </asp:DropDownList></td>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlMotherTongue" runat="server">
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlCaste" runat="server">
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
                                                        <th>Official
                                                        </th>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table style="margin: 0px; border: 0px;">
                                                                <tr>
                                                                    <th>By Staff Type</th>

                                                                    <th colspan="3">By Date Of Joining</th>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlTeaching" runat="server">
                                                                            <asp:ListItem Value="2" Text="All"></asp:ListItem>
                                                                            <asp:ListItem Value="0" Text="Non-Teaching"></asp:ListItem>
                                                                            <asp:ListItem Value="1" Text="Teaching"></asp:ListItem>
                                                                        </asp:DropDownList></td>

                                                                    <td>
                                                                        <asp:DropDownList ID="ddlDOJ" runat="server" Width="80px" AutoPostBack="true" OnSelectedIndexChanged="DateType_Change">
                                                                            <asp:ListItem Value="0" Text="All"></asp:ListItem>
                                                                            <asp:ListItem Value="1" Text="Less Than"></asp:ListItem>
                                                                            <asp:ListItem Value="2" Text="Greater Than"></asp:ListItem>
                                                                            <asp:ListItem Value="3" Text="Between"></asp:ListItem>
                                                                        </asp:DropDownList></td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtDOJ1" runat="server" Width="95px" Enabled="False"></asp:TextBox>&nbsp;
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtDOJ2" runat="server" Width="90px" Enabled="False"></asp:TextBox>&nbsp;
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table style="margin: 0px; border: 0px;">
                                                                <tr>
                                                                    <th>Status
                                                                    </th>

                                                                    <th>By Employee Type</th>
                                                                    <th>By Designation</th>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlStatus" runat="server">
                                                                        </asp:DropDownList></td>

                                                                    <td>
                                                                        <asp:DropDownList ID="ddlEmpType" runat="server">
                                                                        </asp:DropDownList></td>
                                                                    <td style="width: 150px">
                                                                        <asp:DropDownList ID="ddlDesignation" runat="server" Width="150px">
                                                                        </asp:DropDownList></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table style="margin: 0px; border: 0px;">
                                                                <tr>
                                                                    <th>Employment Type</th>
                                                                    <th colspan="2">By Half Yearly Joining</th>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlCodeType" runat="server" Width="105px">
                                                                            <asp:ListItem Value="1">Permanent </asp:ListItem>
                                                                            <asp:ListItem Value="0">Temporary</asp:ListItem>
                                                                        </asp:DropDownList></td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlYear" runat="server">
                                                                        </asp:DropDownList></td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlHYJ" runat="server">
                                                                            <asp:ListItem>Select</asp:ListItem>
                                                                            <asp:ListItem Value="1">Ist Half</asp:ListItem>
                                                                            <asp:ListItem Value="2">IInd Half</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table style="margin: 0px; border: 0px;">
                                                                <tr>
                                                                    <th>By Institution</th>
                                                                    <th>By Category</th>
                                                                    <th>By Department Type</th>

                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlInstitution" runat="server">
                                                                        </asp:DropDownList></td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlCategory" runat="server">
                                                                        </asp:DropDownList></td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlDeptType" runat="server">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table style="margin: 0px; border: 0px;">
                                                                <tr>
                                                                    <th>By Next Senior</th>
                                                                    <th>By HOD</th>
                                                                    <th>By Department</th>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlNextSeniorCode" runat="server">
                                                                        </asp:DropDownList></td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlHOD" runat="server" Width="100px">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlDepartment" runat="server" Width="150px">
                                                                        </asp:DropDownList></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table style="margin: 0px; border: 0px;">
                                                                <tr>
                                                                    <th colspan="3">By Date Of Relieving</th>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlDOR" runat="server" Width="100px" AutoPostBack="true" OnSelectedIndexChanged="DateType_Change">
                                                                            <asp:ListItem Value="0" Text="All"></asp:ListItem>
                                                                            <asp:ListItem Value="1" Text="Less Than"></asp:ListItem>
                                                                            <asp:ListItem Value="2" Text="Greater Than"></asp:ListItem>
                                                                            <asp:ListItem Value="3" Text="Between"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtDOR1" runat="server" Width="90px" Enabled="False"></asp:TextBox></td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtDOR2" runat="server" Width="90px" Enabled="False"></asp:TextBox></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th>Qualification
                                                        </th>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table style="margin: 0px; border: 0px;">
                                                                <tr>
                                                                    <th>By Qualification Type</th>
                                                                    <th>By Qualification Level</th>
                                                                    <th>By Board</th>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlQualiOption" runat="server" Width="131px">
                                                                            <asp:ListItem Value="0" Text="All"></asp:ListItem>
                                                                            <asp:ListItem Value="1" Text="Top"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>

                                                                    <td>
                                                                        <asp:DropDownList ID="ddlQualificationLevel" runat="server" Width="139px">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td>

                                                                        <asp:DropDownList ID="ddlBoard" runat="server" Width="131px">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th colspan="3">Experience</th>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table style="margin: 0px; border: 0px;">
                                                                <tr>
                                                                    <th>By Experience</th>
                                                                    <th>By Experience Type</th>
                                                                    <th colspan="3">By Experience Count (Months)</th>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlExperience" runat="server" OnSelectedIndexChanged="ddlExperience_SelectedIndexChanged" AutoPostBack="true">
                                                                            <asp:ListItem>Select</asp:ListItem>
                                                                            <asp:ListItem>Total</asp:ListItem>
                                                                            <asp:ListItem>Individual</asp:ListItem>
                                                                        </asp:DropDownList></td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlExpType" runat="server">
                                                                        </asp:DropDownList></td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlExpOption" runat="server" Width="139px" AutoPostBack="true" OnSelectedIndexChanged="DateType_Change">
                                                                            <asp:ListItem Value="0" Text="All"></asp:ListItem>
                                                                            <asp:ListItem Value="1" Text="Less Than"></asp:ListItem>
                                                                            <asp:ListItem Value="2" Text="Greater Than"></asp:ListItem>
                                                                            <asp:ListItem Value="3" Text="Between"></asp:ListItem>
                                                                        </asp:DropDownList></td>
                                                                    <td>
                                                                        <cc1:NumericTextBox ID="txtExpCountMin" runat="server" CssClass="txtno" MaxLength="3"
                                                                            Width="70px" Enabled="False"></cc1:NumericTextBox>
                                                                        <cc1:NumericTextBox ID="txtExpCountMax" runat="server" CssClass="txtno" MaxLength="3"
                                                                            Width="70px" Enabled="False"></cc1:NumericTextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table style="margin: 0px; border: 0px;">
                                                                <tr>
                                                                    <th colspan="3">Tenure Calculation
                                                                    </th>
                                                                </tr>


                                                                <tr>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlTenure" runat="server" Width="150px">
                                                                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                                            <asp:ListItem Value="2">On Date</asp:ListItem>
                                                                        </asp:DropDownList></td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtTenure1" runat="server" Width="115px" Enabled="True"></asp:TextBox></td>
                                                                    <%--<td>
                                                                        <asp:TextBox ID="txtTenure2" runat="server" Width="115px" Enabled="True"></asp:TextBox></td>--%>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table style="margin: 0px; border: 0px;">
                                                                <tr>
                                                                    <th colspan="3">Tenure Duration
                                                                    </th>
                                                                </tr>




                                                                <tr>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlTenureTime" runat="server" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="DateType_Change">
                                                                            <asp:ListItem Value="0" Text="All"></asp:ListItem>
                                                                            <asp:ListItem Value="1">Less Then</asp:ListItem>
                                                                            <asp:ListItem Value="2">Greater Then</asp:ListItem>
                                                                            <asp:ListItem Value="3">Between</asp:ListItem>
                                                                        </asp:DropDownList></td>
                                                                    <td>
                                                                        <cc1:NumericTextBox ID="txtTenureTime1" runat="server" Width="115px" Enabled="True"></cc1:NumericTextBox></td>
                                                                    <td>
                                                                        <cc1:NumericTextBox ID="txtTenureTime2" runat="server" Width="115px" Enabled="True"></cc1:NumericTextBox></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table style="margin: 0px; border: 0px;">
                                                                <tr>
                                                                    <th colspan="3">Extra Ordinary Leave
                                                                    </th>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlEOL" runat="server" Width="150px" OnSelectedIndexChanged="DateType_Change" AutoPostBack="true">
                                                                            <asp:ListItem Value="0" Text="All"></asp:ListItem>
                                                                            <asp:ListItem Value="1">Less Then</asp:ListItem>
                                                                            <asp:ListItem Value="2">Greater Then</asp:ListItem>
                                                                            <asp:ListItem Value="3">Between</asp:ListItem>
                                                                        </asp:DropDownList></td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtEOL1" runat="server" Width="115px" Enabled="False"></asp:TextBox></td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtEOL2" runat="server" Width="115px" Enabled="False"></asp:TextBox></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table style="margin: 0px; border: 0px;">
                                                                <tr>
                                                                    <th colspan="3">Long Absence</th>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlLA" runat="server" Width="150px" OnSelectedIndexChanged="DateType_Change" AutoPostBack="true">
                                                                            <asp:ListItem Value="0" Text="All"></asp:ListItem>
                                                                            <asp:ListItem Value="3" Text="Between"></asp:ListItem>
                                                                        </asp:DropDownList></td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtLA1" runat="server" Width="115px" Enabled="False"></asp:TextBox></td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtLA2" runat="server" Width="115px" Enabled="False"></asp:TextBox></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table style="margin: 0px; border: 0px;">
                                                                <tr>
                                                                    <th colspan="2">Active Employees</th>
                                                                </tr>
                                                                <tr>
                                                                    <th>On Date:</th>
                                                                    <td>
                                                                        <asp:TextBox ID="txtActive" runat="server" Width="115px"></asp:TextBox></td>

                                                                </tr>
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
                                                        <th>Personal
                                                        </th>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:CheckBoxList ID="chkPerInfo" runat="server" CssClass="checkList" RepeatColumns="3">
                                                                 <asp:ListItem Value="EV.EMP_ID" Text="Login Id"></asp:ListItem>
                                                                <asp:ListItem Value="PER.EMP_FTH_NAME" Text="Father Name"></asp:ListItem>
                                                                <asp:ListItem Value="PER.NEXT_KIN_NAME" Text="Next Kin Name"></asp:ListItem>
                                                                <asp:ListItem Value="EV.GEN_VALUE" Text="Gender"></asp:ListItem>
                                                                <asp:ListItem Value="CONVERT(VARCHAR,EV.DOB,103)" Text="Date of Birth"></asp:ListItem>
                                                                <asp:ListItem Value="EV.MAR_STS_VALUE" Text="Marital Status"></asp:ListItem>
                                                                <asp:ListItem Value="EA.PRESENT_ADD" Text="Present Address"></asp:ListItem>
                                                                <asp:ListItem Value="EA.PERMANENT_ADD" Text="Permanent Address"></asp:ListItem>
                                                                <asp:ListItem Value="EP.MOBILE_OFF" Text="Phone (First)"></asp:ListItem>
                                                                <asp:ListItem Value="EP.MOBILE_RES" Text="Phone (Second)"></asp:ListItem>
                                                                <asp:ListItem Value="EV.EMAIL" Text="Official Email"></asp:ListItem>
                                                                <asp:ListItem Value="NATION_INF.NAT_VALUE" Text="Nationality"></asp:ListItem>
                                                                <asp:ListItem Value="MOT_TON_INF.MOT_TON_VALUE" Text="Mother Tongue"></asp:ListItem>
                                                                <asp:ListItem Value="CAS_INF.CAS_VALUE" Text="Caste"></asp:ListItem>
                                                                <asp:ListItem Value="REL_INF.REL_VALUE" Text="Religion"></asp:ListItem>
                                                                 <asp:ListItem Value="BLOOD.BLO_GRP_VALUE" Text="Blood Group"></asp:ListItem>
                                                                <asp:ListItem Value="EMP_MAIL_CNG_INF.MAIL_VALUE+ MAIL_DOM_INF.MAIL_DOM_VALUE" Text="Personal Mail"></asp:ListItem>
                                                            </asp:CheckBoxList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th>Official
                                                        </th>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:CheckBoxList ID="chkOffInfo" runat="server" CssClass="checkList" RepeatColumns="3">
                                                                <asp:ListItem Value="EV.JOB_TYPE_VALUE" Text="Staff Type"></asp:ListItem>
                                                                <asp:ListItem Value="CONVERT(VARCHAR,EV.DOJ,103)" Text="Date Of Joining"></asp:ListItem>
                                                                <asp:ListItem Value="EV.DES_VALUE" Text="Designation"></asp:ListItem>
                                                                <asp:ListItem Value="EV.DEPT_VALUE" Text="Department"></asp:ListItem>
                                                                <asp:ListItem Value="EV.SERV_TYPE_VALUE" Text="Employee Type"></asp:ListItem>
                                                                <asp:ListItem Value="EV.DEPT_TYPE_VALUE" Text="Department Type"></asp:ListItem>
                                                                <asp:ListItem Value="EV.STS_VALUE" Text="Status"></asp:ListItem>
                                                                <asp:ListItem Value="EV.HOD" Text="Name Of HOD"></asp:ListItem>
                                                                <%--<asp:ListItem Value="EMP_CAT" Text="Category"></asp:ListItem>--%>
                                                                <asp:ListItem Value="EV.NEXT_SENIOR" Text="Next Senior"></asp:ListItem>
                                                                <asp:ListItem Value="EV.INS_VALUE" Text="Institution"></asp:ListItem>
                                                                <%--<asp:ListItem Value="CONVERT(VARCHAR,EV.Reliving_Date,103)" Text="Releiving Date"></asp:ListItem>--%>
                                                                <asp:ListItem Value="EV.PAN_NO">Pan No</asp:ListItem>
                                                                  <asp:ListItem Value="EV.ADHAR_NO">AAdhar No</asp:ListItem>
                                                            </asp:CheckBoxList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th>Qualification</th>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:CheckBoxList ID="chkQualification" runat="server" CssClass="checkList" RepeatColumns="3">
                                                                <asp:ListItem Value="SCH" Text="University"></asp:ListItem>
                                                                <asp:ListItem Value="YER" Text="Year"></asp:ListItem>
                                                                <asp:ListItem Value="PRSNT" Text="Per(%)"></asp:ListItem>
                                                                <asp:ListItem Value="EMP_ACA_INF.SPEC" Text="Specialization"></asp:ListItem>
                                                                <asp:ListItem Value="ACA_BRD_SHORT_NAME" Text="Board"></asp:ListItem>
                                                                <asp:ListItem Value="ACA_BASE_FULL_NAME">Qualification Level</asp:ListItem>
                                                                <asp:ListItem Value="ACA_CRS_VALUE" Text="Course Name"></asp:ListItem>
                                                            </asp:CheckBoxList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th>Experience</th>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:CheckBoxList ID="chExperienceInfo" runat="server" CssClass="checkList" RepeatColumns="2"
                                                                Enabled="true" >
                                                                <asp:ListItem Value="ORG_NAME" Text="Organisation"></asp:ListItem>
                                                                <asp:ListItem Value="EXP_DESIG" Text="Designation"></asp:ListItem>
                                                                <asp:ListItem Value="EXP_TYPE_VALUE" Text="Type"></asp:ListItem>
                                                                <asp:ListItem Value="DATEDIFF(MM,EMP_EXP_INF.FRM_DATE,EMP_EXP_INF.TO_DATE)" Text="Experience (Months)"></asp:ListItem>
                                                                 <asp:ListItem Value="CAST(DATEDIFF(MM,EMP_EXP_INF.FRM_DATE,EMP_EXP_INF.TO_DATE)/12 as varchar(10))+'.'+CAST(DATEDIFF(MM,EMP_EXP_INF.FRM_DATE,EMP_EXP_INF.TO_DATE)%12 as varchar(10))" Text="Experience(YEAR)"></asp:ListItem>
                                                            </asp:CheckBoxList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th>Leave
                                                        </th>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:CheckBoxList ID="chkLeaveInfo" runat="server" CssClass="checkList" RepeatColumns="3"
                                                                Enabled="true">
                                                                <asp:ListItem Value="EOL" Text="Extra Ordinary Leave"></asp:ListItem>
                                                                <asp:ListItem Value="LA" Text="Long Absence"></asp:ListItem>
                                                            </asp:CheckBoxList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th>PayRoll
                                                        </th>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:CheckBoxList ID="chkPayRoll" runat="server" CssClass="checkList" RepeatColumns="3"
                                                                Enabled="true">
                                                                <asp:ListItem Value="EV.ACC_NO" Text="Bank A/c No."></asp:ListItem>
                                                            </asp:CheckBoxList>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td>
                                                            <asp:Button ID="btnExecute" runat="server" Text="View" CssClass="btnBrown" Width="64px" OnClick="btnExecute_Click1" /></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 20px">
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDOJ1"
                                        Format="dd/MM/yyyy">
                                    </ajaxToolkit:CalendarExtender>
                                    <ajaxToolkit:CalendarExtender ID="calDOR2" runat="server" TargetControlID="txtDOR2"
                                        Format="dd/MM/yyyy">
                                    </ajaxToolkit:CalendarExtender>
                                    <ajaxToolkit:CalendarExtender ID="calDOR1" runat="server" TargetControlID="txtDOR1"
                                        Format="dd/MM/yyyy">
                                    </ajaxToolkit:CalendarExtender>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtDOJ2"
                                        Format="dd/MM/yyyy">
                                    </ajaxToolkit:CalendarExtender>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtDOB1"
                                        Format="dd/MM/yyyy">
                                    </ajaxToolkit:CalendarExtender>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtDOB2"
                                        Format="dd/MM/yyyy">
                                    </ajaxToolkit:CalendarExtender>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtTenure1"
                                        Format="dd/MM/yyyy">
                                    </ajaxToolkit:CalendarExtender>
                                    <%--<ajaxToolkit:CalendarExtender ID="CalendarExtender6" runat="server" TargetControlID="txtTenure2"
                                        Format="dd/MM/yyyy">
                                    </ajaxToolkit:CalendarExtender>--%>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender7" runat="server" TargetControlID="txtTenureTime1"
                                        Format="dd/MM/yyyy">
                                    </ajaxToolkit:CalendarExtender>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender8" runat="server" TargetControlID="txtTenureTime2"
                                        Format="dd/MM/yyyy">
                                    </ajaxToolkit:CalendarExtender>
                                    <ajaxToolkit:CalendarExtender ID="CalendarEol" runat="server" TargetControlID="txtEOL1" Format="dd/MM/yyyy">
                                    </ajaxToolkit:CalendarExtender>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender9" runat="server" TargetControlID="txtEOL2" Format="dd/MM/yyyy">
                                    </ajaxToolkit:CalendarExtender>
                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender4" runat="server" TargetControlID="txtLA1"
                                        Mask="99/99/9999" MaskType="Date">
                                    </ajaxToolkit:MaskedEditExtender>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender10" runat="server" TargetControlID="txtLA1"
                                        Format="dd/MM/yyyy">
                                    </ajaxToolkit:CalendarExtender>
                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtLA2"
                                        Mask="99/99/9999" MaskType="Date">
                                    </ajaxToolkit:MaskedEditExtender>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender11" runat="server" TargetControlID="txtLA2"
                                        Format="dd/MM/yyyy">
                                    </ajaxToolkit:CalendarExtender>
                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtActive"
                                        Mask="99/99/9999" MaskType="Date">
                                    </ajaxToolkit:MaskedEditExtender>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender12" runat="server" TargetControlID="txtActive"
                                        Format="dd/MM/yyyy">
                                    </ajaxToolkit:CalendarExtender>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

