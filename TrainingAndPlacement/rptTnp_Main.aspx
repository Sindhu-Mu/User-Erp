<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="rptTnp_Main.aspx.cs" Inherits="TrainingAndPlacement_rptTnp_Main" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="heading">
            <h2>TNP Report</h2>
        </div>
        <div>
            <table id="tblcolumns">
                <%--<tr>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <table>
                --%>
                <tr>
                    <td style="width: 55%; border-right-style: ridge; vertical-align: top">
                        <table>
                            <tr>
                                <th>Filters</th>
                            </tr>
                            <tr>
                                <th>Student Registeration</th>
                            </tr>
                            <tr>
                                <td>
                                    <table>
                                        <tr>
                                            <td>
                                                <table style="margin: 0px; border: 0px;">
                                                    <tr>
                                                        <th>By Instituion</th>
                                                        <th>By Course</th>
                                                        <th>By Batch</th>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:DropDownList ID="ddlInstitute" runat="server" AutoPostBack="true" Width="150px" OnSelectedIndexChanged="ddlInstitute_SelectedIndexChanged"></asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlCourse" runat="server" AutoPostBack="true" Width="150px" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged"></asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlBatch" runat="server" Width="150px" AutoPostBack="true"></asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table style="margin: 0px; border: 0px;">
                                                    <tr>
                                                        <th>By Branch</th>
                                                        <th>By Semester</th>
                                                        <th>By Section</th>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:DropDownList ID="ddlBranch" runat="server" Width="150px"></asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlSemester" runat="server" Width="150px"></asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlSection" runat="server" Width="150px"></asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table style="margin: 0px; border: 0px;">
                                                    <tr>

                                                        <th>By TNP Registeration</th>
                                                        <th>By Reg Date</th>
                                                        <th></th>
                                                        <th></th>
                                                    </tr>
                                                    <tr>


                                                        <td>
                                                            <asp:DropDownList ID="ddlRegid" runat="server" Width="110px">
                                                                <asp:ListItem>Select</asp:ListItem>
                                                                <asp:ListItem Value="1">Yes</asp:ListItem>
                                                                <asp:ListItem Value="0">No</asp:ListItem>
                                                            </asp:DropDownList>

                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlDate" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DateType_Change" Width="110px">
                                                                <asp:ListItem Text="All" Value="0"></asp:ListItem>
                                                                <asp:ListItem Text="Equals To" Value="1"></asp:ListItem>
                                                                <asp:ListItem Text="Less Than" Value="2"></asp:ListItem>
                                                                <asp:ListItem Text="Greater Than" Value="3"></asp:ListItem>
                                                                <asp:ListItem Text="Between" Value="4"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>

                                                        <td>
                                                            <asp:TextBox ID="txtDt1" runat="server" CssClass="textbox" Width="85px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtDt2" runat="server" CssClass="textbox" Width="85px"></asp:TextBox>
                                                        </td>
                                                    </tr>


                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDt1"
                                                            Format="dd/MM/yyyy">
                                                        </ajaxToolkit:CalendarExtender>
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtDt2"
                                                            Format="dd/MM/yyyy">
                                                        </ajaxToolkit:CalendarExtender>

                                                    </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>

                            <tr>
                                <th>Interview Schedule</th>
                            </tr>
                            <tr>
                                <td>
                                    <table>
                                        <tr>
                                            <td>
                                                <table style="margin: 0px; border: 0px;">
                                                    <tr>
                                                        <th>By Company Profile</th>
                                                        <th>By Company</th>
                                                        <th>By Job Profile</th>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:DropDownList ID="ddlCompProfile" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCompProf_SelectedIndexChanged" Width="110px">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlCompany" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCompany_SelectedIndexChanged" Width="110px">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlJobProfile" runat="server" OnSelectedIndexChanged="ddlJobProfile_SelectedIndexChanged" Width="110px">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 56px">
                                                <table style="margin: 0px; border: 0px;">
                                                    <tr>
                                                        <th>Salary</th>
                                                        <th></th>
                                                        <th></th>
                                                        <th>Vacancy</th>
                                                        <th>Job Location</th>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:DropDownList ID="ddlsalary" runat="server" OnSelectedIndexChanged="DateType_Change" Width="110px">
                                                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                <asp:ListItem Text="Equals To" Value="1"></asp:ListItem>
                                                                <asp:ListItem Text="Less Than" Value="2"></asp:ListItem>
                                                                <asp:ListItem Text="Greater Than" Value="3"></asp:ListItem>
                                                                <asp:ListItem Text="Between" Value="4"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtSal1" runat="server" Width="85px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtSal2" runat="server" Width="85px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtvacancy" runat="server" Width="85px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlJobLocation" runat="server" Width="110px">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 56px">
                                                <table>
                                                    <tr>
                                                        <th>Interview Date</th>
                                                        <th></th>
                                                        <th></th>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:DropDownList ID="ddlIntDt" runat="server" OnSelectedIndexChanged="DateType_Change" Width="110px">
                                                                <asp:ListItem Text="All" Value="0"></asp:ListItem>
                                                                <asp:ListItem Text="Equals To" Value="1"></asp:ListItem>
                                                                <asp:ListItem Text="Less Than" Value="2"></asp:ListItem>
                                                                <asp:ListItem Text="Greater Than" Value="3"></asp:ListItem>
                                                                <asp:ListItem Text="Between" Value="4"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtIntDt1" runat="server" Width="85px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtIntDt2" runat="server" Width="85px"></asp:TextBox>
                                                        </td>
                                                    </tr>

                                                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender3" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtIntDt1">
                                                        </ajaxToolkit:MaskedEditExtender>
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd/MM/yyyy" TargetControlID="txtIntDt1">
                                                        </ajaxToolkit:CalendarExtender>
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender6" runat="server" Format="dd/MM/yyyy" TargetControlID="txtIntDt2">
                                                        </ajaxToolkit:CalendarExtender>

                                                    </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>

                            <tr>
                                <th>Interview Registeration</th>
                            </tr>
                            <tr>
                                <td>
                                    <table>
                                        <tr>
                                            <td>
                                                <table style="margin: 0px; border: 0px;">
                                                    <tr>
                                                        <th>By Interview Registeration</th>
                                                        <th>By Interview Status</th>

                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:DropDownList ID="ddlIntRegId" runat="server" Width="110px">
                                                                <asp:ListItem>Select</asp:ListItem>
                                                                <asp:ListItem Value="1">Yes</asp:ListItem>
                                                                <asp:ListItem Value="0">No</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlIntStatus" runat="server" Width="110px">
                                                                <asp:ListItem>All</asp:ListItem>
                                                                <asp:ListItem Value="1">True</asp:ListItem>
                                                                <asp:ListItem Value="0">False</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>

                                                    </tr>

                                                    <tr>
                                                        <th>By Interview Reg Date</th>
                                                        <th></th>
                                                        <th></th>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:DropDownList ID="ddlIntRegDate" runat="server" Width="110px">
                                                                <asp:ListItem Text="All" Value="0"></asp:ListItem>
                                                                <asp:ListItem Text="Equals To" Value="1"></asp:ListItem>
                                                                <asp:ListItem Text="Less Than" Value="2"></asp:ListItem>
                                                                <asp:ListItem Text="Greater Than" Value="3"></asp:ListItem>
                                                                <asp:ListItem Text="Between" Value="4"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtIntRegDt1" runat="server" Width="85px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtIntRegDt2" runat="server" Width="85px"></asp:TextBox>
                                                        </td>
                                                    </tr>

                                                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtIntRegDt1">
                                                        </ajaxToolkit:MaskedEditExtender>
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" TargetControlID="txtIntRegDt1">
                                                        </ajaxToolkit:CalendarExtender>

                                                    </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <th>Interview Attendance</th>
                            </tr>
                            <tr>
                                <td>
                                    <table>
                                        <tr>
                                            <td>
                                                <table style="margin: 0px; border: 0px;">
                                                    <tr>
                                                        <th>By Int Att Status</th>
                                                        <th>By Int Att Date</th>
                                                        <th></th>
                                                        <th></th>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:DropDownList ID="ddlIntAttSts" runat="server" Width="110px">
                                                                <asp:ListItem Text="Select"></asp:ListItem>
                                                                <asp:ListItem Value="0">Absent</asp:ListItem>
                                                                <asp:ListItem Value="1">Present</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlIntAttDate" runat="server" OnSelectedIndexChanged="DateType_Change" Width="110px">
                                                                <asp:ListItem Text="All" Value="0"></asp:ListItem>
                                                                <asp:ListItem Text="Equals To" Value="1"></asp:ListItem>
                                                                <asp:ListItem Text="Less Than" Value="2"></asp:ListItem>
                                                                <asp:ListItem Text="Greater Than" Value="3"></asp:ListItem>
                                                                <asp:ListItem Text="Between" Value="4"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtIntAttDt1" runat="server" Width="85px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtIntAttDt2" runat="server" Width="85px"></asp:TextBox>
                                                        </td>
                                                    </tr>

                                                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender4" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtIntAttDt1">
                                                        </ajaxToolkit:MaskedEditExtender>
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" Format="dd/MM/yyyy" TargetControlID="txtIntAttDt1">
                                                        </ajaxToolkit:CalendarExtender>

                                                    </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>


                            <tr>
                                <th>Interview Result</th>
                            </tr>
                            <tr>
                                <td>
                                    <table>
                                        <tr>
                                            <td>
                                                <table style="margin: 0px; border: 0px;">
                                                    <tr>
                                                        <th>By Interview Sel Status</th>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:DropDownList ID="ddlIntselSts" runat="server" Width="110px">
                                                                <asp:ListItem Value="0">All</asp:ListItem>
                                                                <asp:ListItem Value="1">Selected</asp:ListItem>
                                                                <asp:ListItem Value="2">Not Selected</asp:ListItem>
                                                                <asp:ListItem Value="3">Waiting</asp:ListItem>
                                                                <asp:ListItem Value="4">Not Decided</asp:ListItem>
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
                                <th>Qualification</th>
                            </tr>
                            <tr>
                                <td>
                                    <table>
                                        <tr>
                                            <td>
                                                <table style="margin: 0px; border: 0px;">
                                                    <tr>
                                                        <th>By Qualification Type</th>
                                                        <th>By Qualification Level</th>

                                                        <th>By Division</th>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:DropDownList ID="ddlQualificationType" runat="server" Width="110px">
                                                                <asp:ListItem Value="0">All</asp:ListItem>
                                                                <asp:ListItem Value="1">Top</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlQuaLevel" runat="server" AutoPostBack="true" Width="110px">
                                                            </asp:DropDownList>
                                                        </td>


                                                        <td>
                                                            <asp:DropDownList ID="ddldivision" runat="server" Width="110px">
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
                                    </table>
                                </td>
                            </tr>
                            <tr>
                               <th>Personal Detail</th>
                            </tr>
                            <tr>
                                <td>
                                    <table>
                                        <tr>
                                            <td>
                                                <table>
                                                    <tr>
                                                                <th>By State</th>
                                                                <th>By City</th>
                                                                <th>By Sort</th>
                                                            </tr>
                                                    <tr>
                                                         <td>
                                                                            <asp:DropDownList ID="ddlState" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddlCity" runat="server" Width="210px">
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
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>

                    <td style="width: 45%; vertical-align: top">
                        <table style="width: 100%">
                            <tr>
                                <th>Fields </th>
                            </tr>
                            <tr>
                                <th>Student Registeration</th>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBoxList ID="ChStureg1" runat="server" RepeatColumns="3">
                                        <asp:ListItem Value="SV.INS_VALUE">Institution </asp:ListItem>
                                        <asp:ListItem Value="ACA_BATCH_NAME">Batch</asp:ListItem>
                                        <asp:ListItem Value="PGM_FULL_NAME">Course Name</asp:ListItem>
                                        <asp:ListItem Value="BRN_SHORT_NAME">Branch Name</asp:ListItem>
                                        <asp:ListItem Value="ACA_SEM_NO">Semester</asp:ListItem>
                                        <asp:ListItem Value="ACA_SEC_NAME">Section</asp:ListItem>
                                        <asp:ListItem Value="ENROLLMENT_NO">Enrollment</asp:ListItem>
                                        <asp:ListItem Value="STU_REG_ID">Reg Id</asp:ListItem>
                                        <asp:ListItem Value="STU_STATUS">Status</asp:ListItem>
                                        <asp:ListItem Value="convert(varchar,SV.DT_OF_BIRTH,103)">Dob</asp:ListItem>
                                        <asp:ListItem Value="case when SV.GEN_ID=1 then'Male' else 'Female' end">Gender</asp:ListItem>
                                        <asp:ListItem Value="CONVERT(VARCHAR,TNP_STU_REGISTERATION_INF.STU_REG_DT,103)">Reg Date</asp:ListItem>
                                        <asp:ListItem Value="TNP_ACAD_EDIT_DETAILS.PARENT_MOBILE, TNP_ACAD_EDIT_DETAILS.PERSONAL_MOBILE, TNP_ACAD_EDIT_DETAILS.PERSONAL_EMAIL, TNP_ACAD_EDIT_DETAILS.DOMAIN, 
                                                                          TNP_ACAD_EDIT_DETAILS.HSC_PERCENTAGE, TNP_ACAD_EDIT_DETAILS.HSC_YEAR, TNP_ACAD_EDIT_DETAILS.HSC_BOARD_UNIVERSITY, TNP_ACAD_EDIT_DETAILS.SSC_PERCENTAGE, 
                                                                          TNP_ACAD_EDIT_DETAILS.SSC_YEAR, TNP_ACAD_EDIT_DETAILS.SSC_BOARD_UNIVERSITY, TNP_ACAD_EDIT_DETAILS.GRADUATION_PERCENTAGE, TNP_ACAD_EDIT_DETAILS.GRADUATION_YEAR, 
                                                                          TNP_ACAD_EDIT_DETAILS.GRADUATION_BOARD_UNIVERSITY">TNP Details</asp:ListItem>
                                        <asp:ListItem Value="TNP_STU_REGISTERATION_INF.STU_RESUME">Resume</asp:ListItem>
                                        <asp:ListItem Value="FATHER_NAME">Father Name</asp:ListItem>
                                    </asp:CheckBoxList>
                                </td>
                            </tr>
                            <tr>
                                            <th>Personal Detail</th>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:CheckBoxList ID="ChPersonal1" runat="server" RepeatColumns="3">
                                                    <asp:ListItem Value="SV.PHN_NO">Phone No</asp:ListItem>
                                                    <asp:ListItem Value="SV.EMAIL">Email</asp:ListItem>
                                                    <asp:ListItem Value="(SV.ADD_1+' '+ISNULL(SV.ADD_2,''))">Address</asp:ListItem>
                                                    <asp:ListItem Value="SV.CIT_VALUE">City</asp:ListItem>
                                                    <asp:ListItem Value="STA_VALUE">State</asp:ListItem>
                                                    <asp:ListItem Value="COU_VALUE">Country</asp:ListItem>
                                                
                                                </asp:CheckBoxList>
                                            </td>
                                        </tr>
                                        
                            <tr>
                                <th>Qualification </th>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBoxList ID="ChQualification1" runat="server" RepeatColumns="4">
                                        <asp:ListItem Value="STU_10TH_PER">10TH PER</asp:ListItem>
                                        <asp:ListItem Value="STU_12TH_PER">12TH PER</asp:ListItem>
                                        <asp:ListItem Value="STU_GRADUTION">GRAD PER</asp:ListItem>
                                        <%--<asp:ListItem Value="case when (STU_ACA_INF.PRSNT&gt;=60) then 'Ist' when (STU_ACA_INF.PRSNT&lt;60 and STU_ACA_INF.PRSNT&gt;=45) then 'IInd'  when (STU_ACA_INF.PRSNT&lt;45 and STU_ACA_INF.PRSNT&gt;=33) then 'IIIrd' ELSE 'FAIL' end">Division</asp:ListItem>--%>
                                        <asp:ListItem Value="STU_DIPLOMA_PER">DIP PER</asp:ListItem>
                                        <asp:ListItem Value="STU_10TH_PASSING">10TH YEAR</asp:ListItem>
                                        <asp:ListItem Value="STU_12TH_PASSING">12TH YEAR</asp:ListItem>
                                        <asp:ListItem Value="STU_GRA_PASSING">GRAD YEAR</asp:ListItem>
                                        <asp:ListItem Value="STU_DIPLOMA_PASS">DIP YEAR</asp:ListItem>
                                        <asp:ListItem Value="STU_10TH_SCHOOL">10TH SCHL</asp:ListItem>
                                        <asp:ListItem Value="STU_12TH_SCHOOL">12TH SCHL</asp:ListItem>
                                        <asp:ListItem Value="STU_GRA_SCHOOL">GRAD SCHL</asp:ListItem>
                                        <asp:ListItem Value="STU_DIP_SCHOOL">DIP SCHL</asp:ListItem>
                                        <asp:ListItem Value="case when STU_10TH_BOARD=1 then 'CBSE' when STU_10TH_BOARD=2 then 'ICSE' when STU_10TH_BOARD=3 then 'State' else 'Others' end">10TH BRD</asp:ListItem>
                                        <asp:ListItem Value="case when STU_12TH_BOARD=1 then 'CBSE' when STU_12TH_BOARD=2 then 'ICSE' when STU_12TH_BOARD=3 then 'State' else 'Others' end">12TH BRD</asp:ListItem>
                                        <asp:ListItem Value="case when STU_GRAD_BOARD=1 then 'CBSE' when STU_GRAD_BOARD=2 then 'ICSE' when STU_GRAD_BOARD=3 then 'State' else 'Others' end">GRAD BRD</asp:ListItem>
                                        <asp:ListItem Value="case when STU_DIP_BOARD=1 then 'CBSE' when STU_DIP_BOARD=2 then 'ICSE' when STU_DIP_BOARD=3 then 'State' else 'Others' end">DIP BRD</asp:ListItem>
                                        <asp:ListItem Value="STU_10TH_SPEC">10TH SPEC</asp:ListItem>
                                        <asp:ListItem Value="STU_12TH_SPEC">12TH SPEC</asp:ListItem>
                                        <asp:ListItem Value="STU_GRA_SPEC">GRAD SPEC</asp:ListItem>
                                        <asp:ListItem Value="STU_DIP_SPEC">DIP SPEC</asp:ListItem>
 
                                    </asp:CheckBoxList>
                                </td>
                            </tr>
                            <tr>
                                <th>MU Qualification</th>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBoxList ID="ChMUQualification1" runat="server" RepeatColumns="2">
                                                    <asp:ListItem Value= "SUM(ROUND(INTERNAL_MRKS+MAJOR_MRKS,0,0))">MU Gain</asp:ListItem>
                                                    <asp:ListItem Value="SUM(MAX_INTERNAL+MAX_MAJOR)">MU Total</asp:ListItem>
                                                   <%-- <asp:ListItem Value="CAST(((SUM(ROUND(INTERNAL_MRKS+MAJOR_MRKS,0,0))/SUM(MAX_INTERNAL+MAX_MAJOR))*100) AS DECIMAL(10,2))">MU Per</asp:ListItem>--%>
                                                    <asp:ListItem Value="Examination.dbo.GET_STU_PERCENT_CGPA(ExamStuView.STU_MAIN_ID,ACA_BATCH_ID,ExamStuView.PGM_MAPP_ID)">MU Per/CGPA</asp:ListItem>
                                                    <asp:ListItem Value="Examination.dbo.GET_STU_NO_OF_BACK_COUNT(ExamStuView.STU_MAIN_ID)">MU No.of Backs</asp:ListItem>

                                                </asp:CheckBoxList>
                                </td>
                            </tr>
                            <tr>
                                <th>Interview Schedule</th>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBoxList ID="ChIntShed1" runat="server" RepeatColumns="3">
                                        <asp:ListItem Value="COMP_PROFILE">Company Profile</asp:ListItem>
                                        <asp:ListItem Value="COMP_NAME">Company Name</asp:ListItem>
                                        <asp:ListItem Value="JOB_PROFILE_ID">Job Profile</asp:ListItem>
                                        <asp:ListItem Value="SALARY">Salary</asp:ListItem>
                                        <asp:ListItem Value="VACANCY">Vacancy</asp:ListItem>
                                        <asp:ListItem Value="JOB_LOCATION">Job Location</asp:ListItem>
                                        <asp:ListItem Value="CONVERT(VARCHAR,TNP_INT_SHEDULE_MAIN_INF.INTERVIEW_DT,103)">Interview Date</asp:ListItem>
                                        <asp:ListItem Value="ACA_SESN_VALUE">Session</asp:ListItem>
                                        <asp:ListItem Value="OTHERS">Others</asp:ListItem>
                                    </asp:CheckBoxList>
                                </td>
                            </tr>
                            <tr>
                                <th>Interview Registeration</th>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBoxList ID="ChIntreg1" runat="server" RepeatColumns="2">
                                        <asp:ListItem Value="INT_REG_ID">Interview Reg Id</asp:ListItem>
                                        <asp:ListItem Value="INT_SHEDULE_MAIN_ID">Interview Shed Id</asp:ListItem>
                                        <asp:ListItem Value="CONVERT(VARCHAR,TNP_INTERVIEW_REGISTERATION.INT_REG_DT,103)">Interview Reg Date</asp:ListItem>
                                        <asp:ListItem Value="INT_STATUS">Interview Status</asp:ListItem>
                                    </asp:CheckBoxList>
                                </td>
                            </tr>
                            <tr>
                                <th>Interview Attendance</th>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBoxList ID="ChIntAtt1" runat="server" RepeatColumns="2">
                                        <asp:ListItem Value="INT_ATT_STS">Interview Att Status</asp:ListItem>
                                        <asp:ListItem Value="CONVERT(VARCHAR,TNP_STU_INT_ATTENDANCE_INF.INT_ATT_DATE,103)">Interview Att Date</asp:ListItem>
                                    </asp:CheckBoxList>
                                </td>
                            </tr>
                            <tr>
                                <th>Interview Selection</th>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBoxList ID="ChIntSel1" runat="server" RepeatColumns="2">
                                        <asp:ListItem Value="INT_SEL_ID">Interview Sel Id</asp:ListItem>
                                        <asp:ListItem Value="STATUS_ID">Interview Sel Status</asp:ListItem>
                                    </asp:CheckBoxList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="btnView" runat="server" OnClick="btnView_Click" Text="View" />
                                </td>
                            </tr>
                        </table>
                    </td>

                </tr>
                <%--</table>

                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>--%>
            </table>
        </div>
    </div>
</asp:Content>

