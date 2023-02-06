<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="rpt_StudentMain.aspx.cs" Inherits="Academic_rpt_StudentMain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="heading">
            <h2>Student Main 
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
                                                    <th>By InstituTion</th>
                                                    <th>By Department</th>
                                                    <th>By Batch</th>
                                                    <th>By Program</th>
                                                    
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:DropDownList ID="ddlInstitute" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlInstitute_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddldepart" runat="server" ></asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlBatch" runat="server">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlCourse" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged" Width="250px">
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
                                                    <th>By Branch</th>
                                                    <th>By Semester</th>
                                                    <th>By Section</th>
                                                    <th>By Status</th>
                                                    <th>By Year</th>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:DropDownList ID="ddlBranch" runat="server" Width="150px">
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
                                        <th>Admission</th>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table style="margin: 0px; border: 0px;">
                                                <tr>
                                                    <th>By Quota</th>
                                                    <th>By Entrance Test</th>
                                                    <th colspan="3">By Test Rank</th>

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
                                                        <asp:DropDownList ID="ddlRank" runat="server" Width="80px" OnSelectedIndexChanged="DateType_Change" AutoPostBack="true">
                                                            <asp:ListItem Text="All" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Equals To" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Less Than" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="Greater Than" Value="3"></asp:ListItem>
                                                            <asp:ListItem Text="Between" Value="4"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtRank1" runat="server" CssClass="textbox" Width="85px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtRank2" runat="server" CssClass="textbox" Width="85px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table style="margin: 0px; border: 0px;">
                                                <tr>
                                                    <th>By Admission Type</th>
                                                    <th colspan="3">By Admission Date</th>

                                                    <tr>
                                                        <td>
                                                            <asp:DropDownList ID="ddlAdmType" runat="server"></asp:DropDownList></td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlAdmissionDt" runat="server" OnSelectedIndexChanged="DateType_Change" AutoPostBack="true">
                                                                <asp:ListItem Text="All" Value="0"></asp:ListItem>
                                                                <asp:ListItem Text="Equals To" Value="1"></asp:ListItem>
                                                                <asp:ListItem Text="Less Than" Value="2"></asp:ListItem>
                                                                <asp:ListItem Text="Greater Than" Value="3"></asp:ListItem>
                                                                <asp:ListItem Text="Between" Value="4"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtADM1" runat="server" CssClass="textbox" Width="85px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtADM2" runat="server" CssClass="textbox" Width="85px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>Qualification</th>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table style="margin: 0px; border: 0px;">
                                                <tr>
                                                    <th>By Type</th>
                                                    <th>By Pattern</th>
                                                    <th>By Level</th>
                                                    <th>By Board</th>
                                                    <th>By Division</th>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:DropDownList ID="ddlQualificationType" runat="server">
                                                            <asp:ListItem Value="0">All</asp:ListItem>
                                                            <asp:ListItem Value="1">Top</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlPattern" runat="server" Width="100px">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlQuaLevel" runat="server" Width="130px" AutoPostBack="true">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlBoard" runat="server" Width="130px"></asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddldivision" runat="server">
                                                            <asp:ListItem Value="0">All</asp:ListItem>
                                                            <asp:ListItem Value="1">1st</asp:ListItem>
                                                            <asp:ListItem Value="2">2nd</asp:ListItem>
                                                            <asp:ListItem Value="3">3rd</asp:ListItem>
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
                                                    <th>By Blood Group</th>
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
                                                        <asp:DropDownList ID="ddlCaste" runat="server" Width="150px">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlReligion" runat="server" Width="120px">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlBloodGp" runat="server" Width="100px">
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
                                                    <th>By Address Type</th>
                                                    <th>By State</th>
                                                    <th>By City</th>


                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:DropDownList ID="ddlAddType" runat="server" AutoPostBack="true"></asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlState" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlState_SelectedIndexChanged" Width="210px">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlCity" runat="server" Width="200px">
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
                                                    <th>By Session</th>
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
                                                            <asp:ListItem Value="=0"> Not Registered</asp:ListItem>
                                                            <asp:ListItem Value="=1">Registered</asp:ListItem>
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
                                        <th>Others</th>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table style="margin: 0px; border: 0px;">
                                                <tr>

                                                    <th>By Student Type</th>
                                                    <th>By ID-Card Print</th>
                                                    <th>By Sort</th>
                                                </tr>
                                                <tr>

                                                    <td>
                                                        <asp:DropDownList ID="ddlAcommadation" runat="server" Width="150px">
                                                            <asp:ListItem>All</asp:ListItem>
                                                            <asp:ListItem Value="0">Day-Scholar</asp:ListItem>
                                                            <asp:ListItem Value="1">Hosteller</asp:ListItem>
                                                            <asp:ListItem Value="2">Transport</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlCard" runat="server">
                                                            <asp:ListItem>Select</asp:ListItem>
                                                            <asp:ListItem Value="1">Yes</asp:ListItem>
                                                            <asp:ListItem Value="0">No</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlSort" runat="server" Width="130px">
                                                            <asp:ListItem>All</asp:ListItem>
                                                            <asp:ListItem Value="SV.INS_ID">Institution</asp:ListItem>
                                                            <asp:ListItem Value="SV.INS_PGM_ID">Course</asp:ListItem>
                                                            <asp:ListItem Value="SV.ENROLLMENT_NO">Enrollment No.</asp:ListItem>
                                                            <asp:ListItem Value="SV.PGM_BRN_ID">Branch</asp:ListItem>
                                                            <asp:ListItem Value="SV.QUOTA_ID">Quota</asp:ListItem>
                                                            <asp:ListItem Value="SV.ACA_SEM_ID">Semester</asp:ListItem>
                                                            <asp:ListItem Value="AD.ENT_EXAM_ID">Adm Category</asp:ListItem>
                                                            <asp:ListItem Value="SV.GEN_ID">Gender</asp:ListItem>
                                                            <asp:ListItem Value="SV.STU_STS_ID">Status</asp:ListItem>
                                                            <asp:ListItem Value="STU_ACA_INF.PRSNT">Marks</asp:ListItem>
                                                            <asp:ListItem Value="SV.CAS_ID">Category</asp:ListItem>
                                                        </asp:DropDownList>
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
                                            <ajaxToolkit:MaskedEditExtender ID="ME1" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtADM1">
                                            </ajaxToolkit:MaskedEditExtender>
                                            <ajaxToolkit:CalendarExtender ID="CalEx1" runat="server" Format="dd/MM/yyyy" TargetControlID="txtADM1">
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
                                                <asp:ListItem Value="PGM_SHORT_NAME">Course Name</asp:ListItem>
                                                <asp:ListItem Value="BRN_SHORT_NAME">Branch Name</asp:ListItem>
                                                <asp:ListItem Value="ACA_SEM_NO">Semester</asp:ListItem>
                                                <asp:ListItem Value="ACA_SEC_NAME">Section</asp:ListItem>
                                                <asp:ListItem Value="ADM_TYPE_VALUE">Adm Type</asp:ListItem>
                                                <asp:ListItem Value="SV.ADM_REG_NO">Adm Reg. No</asp:ListItem>
                                                <asp:ListItem Value="Convert(varchar,SV.STU_ENROLL_DT,103)">Admission Date</asp:ListItem>
                                                <asp:ListItem Value="SV.FORM_NO">Application No</asp:ListItem>
                                                <asp:ListItem Value="ADM_ENT_EXAM_INF.ENT_EXAM_FULL_NAME">Admission Category</asp:ListItem>
                                                <asp:ListItem Value="QUOTA_NAME">Quota</asp:ListItem>
                                                <asp:ListItem Value="SV.STU_TEST_RANK">Test Rank</asp:ListItem>
                                                <asp:ListItem Value="SV.SEM_ROLL_NO">Roll No</asp:ListItem>
                                                <asp:ListItem Value="SV.STU_STS_VALUE">Status</asp:ListItem>
                                                <asp:ListItem Value="SV.REMARK">Remark</asp:ListItem>
                                                  <asp:ListItem Value="SV.SEM_IN_REMARK">Branch Remark</asp:ListItem>
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
                                                <asp:ListItem Value="SV.PERSONAL_EMAIL">PERSONAL E-Mail</asp:ListItem>
                                            </asp:CheckBoxList></td>
                                    </tr>
                                    <tr>
                                        <th>Qualification
                                        </th>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:CheckBoxList ID="ChQualification1" runat="server" RepeatColumns="3">
                                                <asp:ListItem Value="ACA_BASE_FULL_NAME">Qualification</asp:ListItem>
                                                <%--<asp:ListItem>Subjects</asp:ListItem>--%>
                                                <asp:ListItem Value="ACA_SCHOOL">School/College</asp:ListItem>
                                                <asp:ListItem Value="ACA_BRD_FULL_NAME">Board/University</asp:ListItem>
                                                <asp:ListItem Value="PRSNT">Percentage</asp:ListItem>
                                                <asp:ListItem Value="case when (STU_ACA_INF.PRSNT>=60) then 'Ist' when (STU_ACA_INF.PRSNT<60 and STU_ACA_INF.PRSNT>=45) then 'IInd'  when (STU_ACA_INF.PRSNT<45 and STU_ACA_INF.PRSNT>=33) then 'IIIrd' ELSE 'FAIL' end">Division</asp:ListItem>
                                                <asp:ListItem Value="YER">Year</asp:ListItem>
                                                <asp:ListItem Value="TOT_MARKS">Total Marks</asp:ListItem>
                                                <asp:ListItem Value="TOT_GAIN">Gain</asp:ListItem>
                                                <%--<asp:ListItem>Qualification Remark</asp:ListItem>--%>
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
                                        <th>Status</th>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:CheckBoxList ID="ChStaus" runat="server" RepeatColumns="2">
                                                <asp:ListItem Value="STS_TRAN_REMARK">Status Change Remark</asp:ListItem>
                                                <asp:ListItem Value="CONVERT(VARCHAR,STS_FROM_DT,103)">Status Date</asp:ListItem>
                                                <asp:ListItem Value="SV.STU_STS_VALUE">Change Status</asp:ListItem>
                                                <asp:ListItem Value="UserView.EMP_NAME">Change By</asp:ListItem>
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
                                        <th>Others</th>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:CheckBoxList ID="ChOthers" runat="server" RepeatColumns="2">
                                                <asp:ListItem Value="dbo.GET_STU_ACCOMM_STATUS(SV.STU_MAIN_ID)">Student Type</asp:ListItem>
                                                <asp:ListItem Value="dbo.GET_STU_PASSOUT_YEAR(SV.STU_MAIN_ID)">Passout Year</asp:ListItem>
                                            </asp:CheckBoxList>
                                       
                                           
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:UpdateProgress ID="UpdateProgress1" runat="server" DynamicLayout="False">
                                                <ProgressTemplate>
                                                    <img src="../images/25-1.gif" />
                                                    Loading....
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                            <asp:Button ID="btnView" runat="server" Text="View" OnClick="btnView_Click" />
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtADM1"
                                                Format="dd/MM/yyyy">
                                            </ajaxToolkit:CalendarExtender>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtADM2"
                                                Format="dd/MM/yyyy">
                                            </ajaxToolkit:CalendarExtender>
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

