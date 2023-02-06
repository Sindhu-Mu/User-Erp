<%@ Page Language="C#" AutoEventWireup="true" CodeFile="rptFeeMain.aspx.cs" MasterPageFile="~/MasterPages/FullLength.master" Inherits="Finance_rptFeeMain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="heading">
            <h2>Fees Main
            </h2>
        </div>
        <div>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <table id="tblCol">
                        <tr>
                            <td style="width: 50%; border-right-style: ridge; vertical-align: top">
                                <table>

                                    <tr>
                                        <th>Filters </th>
                                        <tr>
                                            <th>Academic</th>
                                        </tr>
                                    <tr>
                                        <td>
                                            <table>
                                                <tr>
                                                    <th>By Instituion</th>
                                                    <th>By Program Type</th>
                                                    <th>By Program</th>
                                                    <th>By Branch</th>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:DropDownList ID="ddlInstitute" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlInstitute_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlPgmType" runat="server" OnSelectedIndexChanged="ddlPgmType_SelectedIndexChanged" AutoPostBack="True">
                                                            <asp:ListItem>All</asp:ListItem>
                                                            <asp:ListItem Value="2">U.G.</asp:ListItem>
                                                            <asp:ListItem Value="1">P.G.</asp:ListItem>
                                                            <asp:ListItem Value="5">Research</asp:ListItem>
                                                            <asp:ListItem Value="3">Diploma</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlCourse" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged" Width="250px">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlBranch" runat="server" Width="150px">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table>
                                                <tr>
                                                    <th>By Batch</th>
                                                    <th>By Semester</th>
                                                    <th>By Section</th>
                                                    <th>By Status</th>
                                                    <th>By Year</th>
                                                 
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:DropDownList ID="ddlBatch" runat="server">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlSemester" runat="server">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlSection" runat="server">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlStatus" runat="server" Width="150px">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlYear" runat="server" Width="100px">
                                                            <asp:ListItem>All</asp:ListItem>
                                                            <asp:ListItem Value="1">First Year</asp:ListItem>
                                                            <asp:ListItem Value="First Year">Final Year</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                   
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>Fees</th>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table>
                                                <tr>  <th>Year/Sem</th>
                                                    <th>By Session</th>
                                                    <th>By Sem Type</th>
                                                    <th>By Head Type</th>
                                                    <th>By Fee Head</th>
                                                </tr>
                                                <tr>
                                                     <td>
                                                        <asp:DropDownList ID="ddlSemYear" runat="server"> 
                                                            <asp:ListItem Value="1">Year</asp:ListItem>
                                                            <asp:ListItem Value="2">Semester</asp:ListItem>
                                                        </asp:DropDownList></td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlSession" runat="server"></asp:DropDownList></td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlSemType" runat="server"></asp:DropDownList></td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlHeadType" runat="server" Width="100px" AutoPostBack="true" OnSelectedIndexChanged="ddlHeadType_SelectedIndexChanged">
                                                            <asp:ListItem Value="0">Select</asp:ListItem>
                                                            <asp:ListItem Value="1">Facility</asp:ListItem>
                                                        </asp:DropDownList></td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlFeeHead" runat="server" Width="180px"></asp:DropDownList></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>Admission</th>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table style="margin: 0px; border: 0px;">
                                                <tr>
                                                    <th>By Quota</th>
                                                    <th>By Entrance Test</th>
                                                    <th>By Admission Type</th>
                                                    <th>By Student Type</th>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:DropDownList ID="ddlQuota" runat="server">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlCategory" runat="server" Width="150px">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlAdmType" runat="server"></asp:DropDownList></td>
                                                     <td>
                                                        <asp:DropDownList ID="ddlAcommadation" runat="server" Width="140px">
                                                            <asp:ListItem>All</asp:ListItem>
                                                            <asp:ListItem Value="0">Day-Scholar</asp:ListItem>
                                                            <asp:ListItem Value="1">Hosteller</asp:ListItem>
                                                            <asp:ListItem Value="2">Transport</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>


                                    <tr>
                                        <th>Personal</th>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table style="margin: 0px; border: 0px;">
                                                <tr>
                                                    <th>By Gender</th>
                                                    <th>By Caste</th>
                                                    <th>By Religion</th>
                                                    <th>By State</th>
                                                    <th>By City</th>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:DropDownList ID="ddlSex" runat="server">
                                                            <asp:ListItem>All</asp:ListItem>
                                                            <asp:ListItem Value="1">Male</asp:ListItem>
                                                            <asp:ListItem Value="2">Female</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlCaste" runat="server" Width="100px">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlReligion" runat="server" Width="120px">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlState" runat="server" AutoPostBack="True"
                                                            OnSelectedIndexChanged="ddlState_SelectedIndexChanged" Width="120px">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlCity" runat="server" Width="120px">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>

                                    <tr>
                                        <th>Semester Registration</th>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table style="margin: 0px; border: 0px;">
                                                <tr>
                                                    <th>By Sesstion</th>
                                                    <th>By Status</th>
                                                    <th colspan="3">By Date</th>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:DropDownList ID="ddlRegConfig" runat="server" Width="140px">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlRegStatus" runat="server">
                                                            <asp:ListItem>All</asp:ListItem>
                                                            <asp:ListItem Value="IS NULL">Not Strarted</asp:ListItem>
                                                            <asp:ListItem Value="=0">Registerd</asp:ListItem>
                                                            <asp:ListItem Value="=1">Completed</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlRegDate" runat="server" OnSelectedIndexChanged="DateType_Change" AutoPostBack="true">
                                                            <asp:ListItem Text="All" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Equals To" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Less Than" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="Greater Than" Value="3"></asp:ListItem>
                                                            <asp:ListItem Text="Between" Value="4"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtRegFromDT" runat="server" Width="85px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtRegToDT" runat="server" Width="85px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>



                                    <tr>
                                        <td>
                                            <asp:UpdateProgress ID="upg1" runat="server" DisplayAfter="0" DynamicLayout="False">
                                                <ProgressTemplate>
                                                    <%-- <img src="..>
                                                                Loading....--%>
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                            <ajaxToolkit:MaskedEditExtender ID="ME1" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtRegFromDT">
                                            </ajaxToolkit:MaskedEditExtender>
                                            <ajaxToolkit:CalendarExtender ID="CalEx1" runat="server" Format="dd/MM/yyyy" TargetControlID="txtRegFromDT">
                                            </ajaxToolkit:CalendarExtender>
                                        </td>
                                    </tr>

                                </table>
                            </td>
                            <td style="width: 45%; border-right-style: ridge; vertical-align: top">
                                <table>

                                    <tr>
                                        <th>Fields
                                        </th>
                                    </tr>

                                    <tr>
                                        <th>Academic
                                        </th>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:CheckBoxList ID="ChAcademic1" runat="server" RepeatColumns="3">
                                                <asp:ListItem Value="SV.INS_VALUE">Institution </asp:ListItem>
                                                <asp:ListItem Value="ACA_BATCH_NAME">Batch</asp:ListItem>
                                                <asp:ListItem Value="PGM_FULL_NAME">Course Name</asp:ListItem>
                                                <asp:ListItem Value="BRN_SHORT_NAME">Branch Name</asp:ListItem>
                                                <asp:ListItem Value="ACA_SEM_NO">Semester</asp:ListItem>
                                                <asp:ListItem Value="ACA_SEC_NAME">Section</asp:ListItem>
                                                <asp:ListItem Value="ADM_TYPE_VALUE">Adm Type</asp:ListItem>
                                                <asp:ListItem Value="STU_MAIN_INF.ADM_REG_NO">Adm Reg. No</asp:ListItem>
                                                <asp:ListItem Value="Convert(varchar,SV.STU_ENROLL_DT,103)">Admission Date</asp:ListItem>
                                                <asp:ListItem Value="SV.FORM_NO">Application No</asp:ListItem>
                                                <asp:ListItem Value="ADM_ENT_EXAM_INF.ENT_EXAM_FULL_NAME">Category</asp:ListItem>
                                                <asp:ListItem Value="QUOTA_NAME">Quota</asp:ListItem>
                                                <asp:ListItem Value="SV.STU_TEST_RANK">Test Rank</asp:ListItem>
                                                <asp:ListItem Value="dbo.GET_STU_ACCOMM_STATUS(SV.STU_MAIN_ID)">Student Type</asp:ListItem>
                                                <asp:ListItem Value="SV.STU_STS_VALUE">Status</asp:ListItem>


                                            </asp:CheckBoxList></td>
                                    </tr>
                                    <tr>
                                        <th>Fees</th>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:CheckBoxList ID="ChFeeMain" runat="server" RepeatColumns="3">
                                                <asp:ListItem Value="SUM(FD_FEE_AMT)">Demand</asp:ListItem>
                                                <asp:ListItem Value="SUM(FD_ADJUST_AMT)">Adjust</asp:ListItem>
                                                <asp:ListItem Value="SUM(CONCESSION_AMT)">Concession</asp:ListItem>
                                                <asp:ListItem Value="SUM(FD_RCV_AMT)">Receive</asp:ListItem>
                                                <asp:ListItem Value="SUM(FEE_WAVE_OFF)">Wave</asp:ListItem>
                                                <asp:ListItem Value="SUM(FD_BALANCE_AMT)">Balance</asp:ListItem>
                                            </asp:CheckBoxList></td>
                                    </tr>
                                    <tr>
                                        <th>Personal
                                        </th>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:CheckBoxList ID="ChPersonal1" runat="server" RepeatColumns="3">
                                                <asp:ListItem Value="SV.GEN_VALUE">Gender</asp:ListItem>
                                                <asp:ListItem Value="Convert(varchar,SV.DT_OF_BIRTH,103)">Date of Birth</asp:ListItem>
                                                <asp:ListItem Value="SV.FATHER_NAME">Father Name</asp:ListItem>
                                                <asp:ListItem Value="SV.MOTHER_NAME">Mother Name</asp:ListItem>
                                                <asp:ListItem Value="SV.REL_VALUE">Religion</asp:ListItem>
                                                <asp:ListItem Value="SV.CAS_VALUE">Category</asp:ListItem>
                                                <asp:ListItem Value="SV.BLO_GRP_VALUE">Blood Group</asp:ListItem>
                                                <asp:ListItem Value="SV.PHN_NO">Mobile No</asp:ListItem>
                                                <asp:ListItem Value="SV.PARENT_CONTACT">Parent No.</asp:ListItem>
                                                <asp:ListItem Value="SV.EMAIL">E-Mail ID</asp:ListItem>
                                            </asp:CheckBoxList></td>
                                    </tr>

                                    <tr>
                                        <th>Address</th>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:CheckBoxList ID="ChCommunication1" runat="server" RepeatColumns="4">
                                                <asp:ListItem Value="(STU_ADD_CNG_INF.ADD_1+' '+ISNULL(STU_ADD_CNG_INF.ADD_2,''))">Address</asp:ListItem>
                                                <asp:ListItem Value="SV.CIT_VALUE">City</asp:ListItem>
                                                <asp:ListItem Value="STA_VALUE">State</asp:ListItem>
                                                <asp:ListItem Value="COU_VALUE">Country</asp:ListItem>
                                            </asp:CheckBoxList></td>
                                    </tr>
                                    <tr>
                                        <th>Registration</th>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:CheckBoxList ID="chReg" runat="server" RepeatColumns="3">
                                                <asp:ListItem Value="CON_REG_NAME">Session</asp:ListItem>
                                                <asp:ListItem Value="CONVERT(VARCHAR,STU_SEM_REG_MAIN.REG_DATE,103)">Date</asp:ListItem>
                                                <asp:ListItem>Status</asp:ListItem>
                                            </asp:CheckBoxList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>Examination</th>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:CheckBoxList ID="chExam" runat="server" RepeatColumns="3">
                                                <asp:ListItem Value="dbo.GET_STU_LAST_EXAM(SV.STU_MAIN_ID)">Last Examination</asp:ListItem>
                                                <%-- <asp:ListItem Value="CONVERT(VARCHAR,STU_SEM_REG_MAIN.REG_DATE,103)">Date</asp:ListItem>--%>
                                                <%-- <asp:ListItem>Status</asp:ListItem>--%>
                                            </asp:CheckBoxList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnView" runat="server" Text="View" OnClick="btnView_Click" />

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
