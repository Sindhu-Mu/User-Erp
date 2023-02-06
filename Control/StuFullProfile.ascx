<%@ Control Language="C#" AutoEventWireup="true" CodeFile="StuFullProfile.ascx.cs" Inherits="Control_StuFullProfile" %>
<link rel="stylesheet" type="text/css" href="../css/Profiles.css" />

<ajaxToolkit:RoundedCornersExtender ID="RoundedCornersExtender1" runat="server" BehaviorID="RoundedCornersBehavior1"
    BorderColor="Black" TargetControlID="div1">
</ajaxToolkit:RoundedCornersExtender>
<div id="div1" runat="server">
    <div id="div2" class="main-div-stu" runat="server">
        <div class="left-area">
            #<asp:Label ID="lblEnrollment" runat="server" Style="font-weight: 700"></asp:Label><br />
            <img id="imgPicture" runat="server" alt="Image" src="~/images/Stuimages/" style="width: 120px; height: 120px" />
            <br />
            <asp:Label ID="lblStatus" runat="server" Style="font-weight: 700"></asp:Label><br />
        </div>
        <div class="right-area">
            &nbsp;<asp:Label ID="lblName" runat="server" Font-Size="18px" Font-Names="Trebuchet MS" Font-Italic="true"> </asp:Label>
            <hr />
            Father's Name:-<asp:Label ID="lblFatherName" runat="server" CssClass="label-detail"></asp:Label>&nbsp;,Mother's Name:-<asp:Label ID="lblMotherName" runat="server" CssClass="label-detail"></asp:Label>&nbsp;DOB:-<asp:Label ID="lblDob" runat="server" CssClass="label-detail"></asp:Label>
            <br />
            <asp:Label ID="lblAddress" runat="server" CssClass="label-detail"></asp:Label>
            <hr />

            Programme :-<asp:Label ID="lblCourse" runat="server" CssClass="label-detail"></asp:Label>
            (<asp:Label ID="lblBranch" runat="server" CssClass="label-detail"></asp:Label>)&nbsp; Semester :-&nbsp;<asp:Label ID="lblSem" runat="server" CssClass="label-detail"></asp:Label>&nbsp;
        Section:-<asp:Label ID="lblSection" runat="server" CssClass="label-detail"></asp:Label>&nbsp;Batch:-<asp:Label ID="lblBatch" runat="server" CssClass="label-detail"></asp:Label>
            Institute:- 
        <asp:Label ID="lblInstitute" runat="server" CssClass="label-detail"></asp:Label>
            <hr />
            Mobile No:-
            <asp:Label ID="lblMobile" runat="server" CssClass="label-detail"></asp:Label>
            &nbsp; Email-ID:-<asp:Label ID="lblEmail" runat="server" CssClass="label-detail"></asp:Label>
            &nbsp;  and Parent Mobile No:-<asp:Label ID="lblParMobile" runat="server" CssClass="label-detail"></asp:Label>
            <hr />
            Admission Type is -<asp:Label ID="lblAdmType" runat="server" ForeColor="Red" Font-Size="18px" Font-Names="Trebuchet MS" Font-Italic="true"> </asp:Label>
        </div>
    </div>
    <div style="border-collapse: collapse; width: 100%;">
        <ajaxToolkit:TabContainer ID="step1" runat="server" AutoPostBack="true" ActiveTabIndex="0" OnActiveTabChanged="step1_ActiveTabChanged1">
            <ajaxToolkit:TabPanel runat="server" HeaderText="Profile Detail" ID="TabPanel1">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td style="width: 50%; vertical-align: top">
                                <table>
                                    <tbody>
                                        <tr>
                                            <th style="padding-bottom: 3px; padding-top: 4px">Gender</th>
                                            <td style="padding-left: 4px; width: 10%">
                                                <b>:</b></td>
                                            <td>
                                                <asp:Label ID="lblSex" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <th style="padding-bottom: 3px; padding-top: 4px">Blood Group</th>
                                            <td style="padding-left: 4px; width: 10%">
                                                <b>:</b></td>
                                            <td>
                                                <asp:Label ID="lblBlood" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <th style="padding-bottom: 3px; padding-top: 4px;">Caste</th>
                                            <td style="padding-left: 4px; width: 10%;">
                                                <b>:</b></td>
                                            <td style="height: 23px">
                                                <asp:Label ID="lblCaste" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <th style="padding-bottom: 3px; padding-top: 4px">Nationality</th>
                                            <td style="padding-left: 4px; width: 10%">
                                                <b>:</b></td>
                                            <td>
                                                <asp:Label ID="lblNationality" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <th style="background-color: #000000; color: #ffffff; height: 20px;" colspan="3">3.Correspondence Address</th>
                                        </tr>
                                        <tr>
                                            <td style="padding-bottom: 3px; padding-top: 4px" colspan="3">
                                                <asp:Label ID="lblCAdd1" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="padding-bottom: 3px; padding-top: 4px" colspan="3">
                                                <asp:Label ID="lblCAdd2" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <th style="padding-bottom: 3px; padding-top: 4px">City</th>
                                            <td style="padding-left: 4px; width: 10%">
                                                <b>:</b></td>
                                            <td>
                                                <asp:Label ID="lblCity" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <th style="padding-bottom: 3px; padding-top: 4px">State
                                            </th>
                                            <td style="padding-left: 4px; width: 10%">
                                                <b>:</b></td>
                                            <td>
                                                <asp:Label ID="lblState" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <th style="padding-bottom: 3px; padding-top: 4px">STD</th>
                                            <td style="padding-left: 4px; width: 10%">
                                                <b>:</b></td>
                                            <td>
                                                <asp:Label ID="lblSTD" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <th style="padding-bottom: 3px; padding-top: 4px">Student No</th>
                                            <td style="padding-left: 4px; width: 10%">
                                                <b>:</b></td>
                                            <td>
                                                <asp:Label ID="lblMobile1" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <th style="padding-bottom: 3px; padding-top: 4px">Email-ID</th>
                                            <td style="padding-left: 4px; width: 10%">
                                                <b>:</b></td>
                                            <td>
                                                <asp:Label ID="lblEmail1" runat="server"></asp:Label></td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                            <td>&nbsp;</td>
                            <td style="width: 50%; vertical-align: top">
                                <table>
                                    <tbody>
                                        <%-- <tr>
                                                                            <th style="background-color: #000000; color: #ffffff; height: 20px;" colspan="3">2.Admission Information</th>
                                                                        </tr>--%>
                                        <tr>
                                            <th style="padding-bottom: 3px; padding-top: 4px">Form No</th>
                                            <td style="padding-left: 4px; width: 10%">
                                                <b>:</b></td>
                                            <td>
                                                <asp:Label ID="lblFormNo" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <th style="padding-bottom: 3px; padding-top: 4px">Registration No</th>
                                            <td style="padding-left: 4px; width: 10%">
                                                <b>:</b></td>
                                            <td>
                                                <asp:Label ID="lblAdmRegNo" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <th style="padding-bottom: 3px; padding-top: 4px">
                                                <b>Quota</b></th>
                                            <td style="padding-left: 4px; width: 10%">
                                                <b>:</b></td>
                                            <td style="padding-bottom: 3px; padding-top: 4px">
                                                <asp:Label ID="lblQuota" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <th style="padding-bottom: 3px; padding-top: 4px">Entrance Exam
                                            </th>
                                            <td style="padding-left: 4px; width: 10%">
                                                <b>:</b></td>
                                            <td>
                                                <asp:Label ID="lblCategory" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <th style="padding-bottom: 3px; padding-top: 4px">Rank
                                            </th>
                                            <td style="padding-left: 4px; width: 10%">
                                                <b>:</b></td>
                                            <td>
                                                <asp:Label ID="lblRank" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <th style="padding-bottom: 3px; padding-top: 4px">Date of Admission</th>
                                            <td style="padding-left: 4px; width: 10%">
                                                <b>:</b></td>
                                            <td>
                                                <asp:Label ID="lblAdmDT" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <th style="background-color: #000000; color: #ffffff; height: 20px;" colspan="3">4.Accommodation Detail</th>
                                        </tr>
                                        <tr>
                                            <th style="padding-bottom: 3px; padding-top: 4px">Type</th>
                                            <td style="padding-left: 4px; width: 10%">:</td>
                                            <td>
                                                <asp:Label ID="lblAccType" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <th style="padding-bottom: 3px; padding-top: 4px">Hostel</th>
                                            <td style="padding-left: 4px; width: 10%">:</td>
                                            <td>
                                                <asp:Label ID="lblHostel" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th style="padding-bottom: 3px; padding-top: 4px">Room No.</th>
                                            <td style="padding-left: 4px; width: 10%">:</td>
                                            <td>
                                                <asp:Label ID="lblRoom" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th style="padding-bottom: 3px; padding-top: 4px">Route No.</th>
                                            <td style="padding-left: 4px; width: 10%">
                                                <b>:</b></td>
                                            <td>
                                                <asp:Label ID="lblRuteNo" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th style="background-color: #000000; color: #ffffff; height: 20px;" colspan="3">5.Permanent Address</th>
                                        </tr>
                                        <tr>
                                            <td style="padding-bottom: 3px; padding-top: 4px" colspan="3">
                                                <asp:Label ID="lblPADD1" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="padding-bottom: 3px; padding-top: 4px" colspan="3">
                                                <asp:Label ID="lblPADD2" runat="server"></asp:Label></td>
                                        </tr>


                                        <tr>
                                            <th style="padding-bottom: 3px; padding-top: 4px">City</th>
                                            <td style="padding-left: 4px; width: 10%">
                                                <b>:</b></td>
                                            <td>
                                                <asp:Label ID="lblPCity" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <th style="padding-bottom: 3px; padding-top: 4px">State
                                            </th>
                                            <td style="padding-left: 4px; width: 10%">
                                                <b>:</b></td>
                                            <td>
                                                <asp:Label ID="lblPState" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <th style="padding-bottom: 3px; padding-top: 4px">STD</th>
                                            <td style="padding-left: 4px; width: 10%">
                                                <b>:</b></td>
                                            <td>
                                                <asp:Label ID="lblPSTD" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <th style="padding-bottom: 3px; padding-top: 4px">
                                                <b>Parent No</b></th>
                                            <td style="padding-left: 4px; width: 10%">
                                                <b>:</b></td>
                                            <td>
                                                <asp:Label ID="lblPMobile" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <th style="padding-bottom: 3px; padding-top: 4px">
                                                <b>Email-ID</b></th>
                                            <td style="padding-left: 4px; width: 10%">
                                                <b>:</b></td>
                                            <td>
                                                <asp:Label ID="lblPEMAIL" runat="server"></asp:Label></td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel runat="server" HeaderText="Qualification Detail" ID="TabPanel2">
                <ContentTemplate>
                    <asp:GridView ID="gvQualification" runat="server" Width="97%" CssClass="gridDynamic" AutoGenerateColumns="False">
                        <Columns>
                            <asp:TemplateField HeaderText="S.No.">
                                <ItemTemplate>
                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                </ItemTemplate>
                                <ItemStyle Width="50px" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="ACA_BASE_FULL_NAME" HeaderText="Examination"></asp:BoundField>
                            <asp:BoundField DataField="ACA_BRD_FULL_NAME" HeaderText="Bord/University"></asp:BoundField>
                            <asp:BoundField DataField="ACA_SCHOOL" HeaderText="School/College"></asp:BoundField>
                            <asp:BoundField DataField="TOT_MARKS" HeaderText="Total"></asp:BoundField>
                            <asp:BoundField DataField="TOT_GAIN" HeaderText="Gain"></asp:BoundField>
                            <asp:BoundField DataField="PRSNT" HeaderText="Per(%)"></asp:BoundField>
                            <asp:BoundField DataField="YER" HeaderText="Passing Year"></asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel runat="server" HeaderText="Attendance Detail" ID="TabPanel3">
                <ContentTemplate>
                    <asp:GridView ID="gvAttendance" runat="server" AutoGenerateColumns="False" Width="97%"
                        CssClass="gridDynamic">
                        <Columns>
                            <asp:TemplateField HeaderText="S.No.">
                                <ItemTemplate>
                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                </ItemTemplate>
                                <ItemStyle Width="50px" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="EVA_SCH_PAPER_CODE" HeaderText="Subject Code" />
                            <asp:BoundField DataField="ACA_SUB_NAME" HeaderText="Subject Name" />
                            <%--<asp:BoundField DataField="CLS_TYPE_VALUE" HeaderText="Class Type" />--%>
                            <asp:BoundField DataField="HELD" HeaderText="Class Held" />
                            <asp:BoundField DataField="MARKED" HeaderText="Att.Marked" />
                            <asp:BoundField DataField="PRESENT" HeaderText="Class Attended" />
                        </Columns>
                        <HeaderStyle BackColor="#000000" ForeColor="#000099" />
                    </asp:GridView>

                </ContentTemplate>
            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel runat="server" HeaderText="Examination Detail" ID="TabPanel4">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td>
                                <ajaxToolkit:Accordion ID="Accordion1" runat="server" Width="950px" SelectedIndex="0"
                                    HeaderCssClass="accordionHeader" ContentCssClass="accordionContent"
                                    HeaderSelectedCssClass="accordionHeaderSelected"
                                    AutoSize="None" FadeTransitions="true" TransitionDuration="250" FramesPerSecond="40" RequireOpenedPane="false" SuppressHeaderPostbacks="true">
                                    <Panes>
                                    </Panes>
                                </ajaxToolkit:Accordion>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel ID="TabPanel5" runat="server" HeaderText="Internal Marks">
                <ContentTemplate>
                    <asp:GridView ID="gvInternalMarks" runat="server" CssClass="gridDynamic" EmptyDataText="No record found." AutoGenerateColumns="true">
                        <Columns></Columns>
                    </asp:GridView>
                    <table>
                        <tr>
                            <td>
                                <ajaxToolkit:Accordion ID="Accordion2" runat="server" Width="950px" SelectedIndex="0"
                                    HeaderCssClass="accordionHeader" ContentCssClass="accordionContent"
                                    HeaderSelectedCssClass="accordionHeaderSelected" 
                                    AutoSize="None" FadeTransitions="true" TransitionDuration="250" FramesPerSecond="40" RequireOpenedPane="false" SuppressHeaderPostbacks="true">
                                    <Panes>
                                    </Panes>
                                </ajaxToolkit:Accordion>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel runat="server" HeaderText="Fee Detail" ID="TabPanel6">
                <ContentTemplate>

                    <table>
                        <tr>
                            <td style="width: 50%; vertical-align: top">
                                <table>
                                    <tbody>
                                        <asp:GridView ID="gvFees" runat="server" Width="97%" AutoGenerateColumns="False"
                                            ShowFooter="True" CssClass="gridDynamic" EmptyDataText="Fees detail not found.">
                                            <Columns>
                                                <asp:TemplateField HeaderText="S.No.">
                                                    <ItemTemplate>
                                                        <%# ((GridViewRow)Container).RowIndex + 1%>
                                        .
                                                    </ItemTemplate>
                                                    <ItemStyle Width="20px" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="FEE_GROUP_HEAD_NAME" HeaderText="FEE NAME" FooterText="TOTAL:-" ReadOnly="True">
                                                    <FooterStyle Font-Bold="True" HorizontalAlign="Right" />
                                                    <ItemStyle Width="200px" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="DEMAND AMOUNT" DataField="FD_FEE_AMT">
                                                    <FooterStyle Font-Bold="True" HorizontalAlign="Right" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="ADJUST" DataField="FD_ADJUST_AMT">
                                                    <FooterStyle Font-Bold="True" HorizontalAlign="Right" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>


                                                <asp:BoundField DataField="FD_RCV_AMT" HeaderText="RECEIVE" ReadOnly="True">
                                                    <FooterStyle HorizontalAlign="Right" Font-Bold="true" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="FD_BALANCE_AMT" HeaderText="BALANCE" ReadOnly="True">
                                                    <ItemStyle HorizontalAlign="Right" />
                                                    <FooterStyle Font-Bold="true" HorizontalAlign="Right" />
                                                </asp:BoundField>

                                            </Columns>
                                        </asp:GridView>
                                    </tbody>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel runat="server" HeaderText="Other Detail" ID="TabPanel7">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td>
                                <asp:GridView ID="gvRegistration" runat="server" CssClass="gridDynamic" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:TemplateField HeaderText="S.No.">
                                            <ItemTemplate>
                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                            </ItemTemplate>
                                            <ItemStyle Width="50px" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="CON_REG_NAME" HeaderText="Registration For" />
                                        <asp:BoundField DataField="REG_FOR_SEM" HeaderText="Semester" />
                                        <asp:BoundField DataField="SEM_REG_STS" HeaderText="Status" />
                                        <asp:BoundField DataField="REG_DATE" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Register Date" />
                                        <asp:BoundField DataField="PRT_DT" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Slip Print Date" />
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="gvSemester" runat="server" CssClass="gridDynamic" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:TemplateField HeaderText="S.No.">
                                            <ItemTemplate>
                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                            </ItemTemplate>
                                            <ItemStyle Width="50px" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="COURSE_SHORT_NAME" HeaderText="Course" />
                                        <asp:BoundField DataField="BRANCH_SHORT_NAME" HeaderText="Branch" />
                                        <asp:BoundField DataField="CURR_SEMISTAR_NO" HeaderText="Semester" />
                                        <asp:BoundField DataField="SEM_ROLL_NO" HeaderText="ROLL NO." />
                                        <asp:BoundField DataField="SECTION_ID" HeaderText="Section" />
                                        <asp:BoundField DataField="DT_OF_CHANGE" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Transaction DT" />
                                        <asp:BoundField DataField="EMP_NAME" HeaderText="Transaction By" />
                                        <asp:BoundField DataField="REGSTATUS" HeaderText="REG.STATUS" />
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>




        </ajaxToolkit:TabContainer>

    </div>

</div>
