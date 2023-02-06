<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="StudentMain.aspx.cs" Inherits="Academic_StudentMain" %>

<%@ Register Src="~/Control/address.ascx" TagPrefix="uc1" TagName="address" %>
<%@ Register Src="~/Control/phoneNumber.ascx" TagPrefix="uc1" TagName="phoneNumber" %>
<%@ Register Src="~/Control/email.ascx" TagPrefix="uc1" TagName="email" %>
<%@ Register Src="~/Control/addressType.ascx" TagPrefix="uc1" TagName="addressType" %>
<%@ Register Src="~/Control/academicType.ascx" TagPrefix="uc1" TagName="academicType" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="heading">
            <h2>Student Information</h2>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <td>
                            <asp:Wizard ID="NewStudentWizard" runat="server" ActiveStepIndex="0" OnFinishButtonClick="NewStudentWizard_FinishButtonClick">
                                <SideBarButtonStyle CssClass="wizardSideButton" />
                                <SideBarStyle CssClass="wizardSide" />
                                <SideBarTemplate>

                                    <asp:DataList ID="SideBarList" runat="server">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="SideBarButton" runat="server" Enabled="true" />
                                        </ItemTemplate>
                                        <SelectedItemTemplate>
                                            <asp:LinkButton ID="SideBarButton" runat="server" Enabled="false" />
                                        </SelectedItemTemplate>
                                    </asp:DataList>
                                </SideBarTemplate>
                                <WizardSteps>
                                    <asp:WizardStep runat="server" StepType="Start" Title="Personal Info">
                                        <table class="wizardTable">
                                            <tr>
                                                <td class="wizardStepHeader">Personal Information</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <th>Data For</th>
                                                            <td>
                                                                <asp:RadioButtonList ID="Rlist" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="Rlist_SelectedIndexChanged" AutoPostBack="true">
                                                                    <asp:ListItem Selected="True" Value="0">Uplade Old</asp:ListItem>
                                                                    <asp:ListItem Value="1">Insert New</asp:ListItem>
                                                                </asp:RadioButtonList></td>

                                                        </tr>
                                                        <tr id="trOld" runat="server">
                                                            <th>Name & Enrollment<span class="required">*</span></th>
                                                            <td>
                                                                <asp:TextBox ID="txtStudent" runat="server" Width="250px"></asp:TextBox>
                                                                <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" />
                                                            </td>
                                                        </tr>
                                                        <tr id="trNew" runat="server">
                                                            <th>Enrollment<span class="required">*</span></th>
                                                            <td>
                                                                <asp:TextBox ID="txtEnrollment" runat="server" Width="140px"></asp:TextBox>

                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <th>Gender<span class="required">*</span>
                                                            </th>
                                                            <td>
                                                                <asp:DropDownList ID="ddlGender" runat="server">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <th>Initial<span class="required">*</span></th>
                                                            <td>
                                                                <asp:DropDownList ID="ddlInitial" runat="server">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <th>First Name<span class="required">*</span>
                                                            </th>
                                                            <td>
                                                                <asp:TextBox ID="txtFirstName" runat="server" Width="200px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <th>Middle Name
                                                            </th>
                                                            <td>
                                                                <asp:TextBox ID="txtMiddleName" runat="server" Width="200px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <th>Last Name<span class="required">*</span></th>
                                                            <td>
                                                                <asp:TextBox ID="txtLastName" runat="server" Width="200px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <th>Date Of Birth<span class="required">*</span></th>
                                                            <td>
                                                                <asp:TextBox ID="txtDOB" runat="server" Width="86px"></asp:TextBox>
                                                                <ajaxToolkit:CalendarExtender ID="cal1" runat="server" TargetControlID="txtDOB" Format="dd/MM/yyyy">
                                                                </ajaxToolkit:CalendarExtender>
                                                                <ajaxToolkit:MaskedEditExtender ID="me1" runat="server" Mask="99/99/9999" MaskType="Date"
                                                                    TargetControlID="txtDOB">
                                                                </ajaxToolkit:MaskedEditExtender>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <th>Category
                                                            </th>
                                                            <td>
                                                                <asp:DropDownList ID="ddlCaste" runat="server">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <th>Religion</th>
                                                            <td>
                                                                <asp:DropDownList ID="ddlReligion" runat="server">
                                                                </asp:DropDownList>
                                                                <br />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <th>Nationality <span class="required">*</span></th>
                                                            <td>
                                                                <asp:DropDownList ID="ddlNationality" runat="server" >
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <th>Blood Group</th>
                                                            <td>
                                                                <asp:DropDownList ID="ddlBloodGroup" runat="server">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <th>Father Name</th>
                                                            <td>
                                                                <asp:TextBox ID="txtFatherName" runat="server" Width="200px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <th>Mother Name</th>
                                                            <td>
                                                                <asp:TextBox ID="txtMotherName" runat="server" Width="200px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <th>Father's Occupation</th>
                                                            <td>
                                                                <asp:TextBox ID="txtFatherOcc" runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <th>Upload Photo</th>
                                                            <td>
                                                                <asp:FileUpload ID="ImgUpload" runat="server" />
                                                                <asp:Label ID="lbl" Text="Only in .jpg format" ForeColor="#ff0000" runat="server"></asp:Label></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" CompletionSetCount="12"
                                                        EnableCaching="true" MinimumPrefixLength="1" ServiceMethod="GetStudentList"
                                                        ServicePath="~\AutoComplete.asmx" TargetControlID="txtStudent" ContextKey="1,2,3,4,5,6">
                                                    </ajaxToolkit:AutoCompleteExtender>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:WizardStep>
                                    <asp:WizardStep runat="server" Title="Academic Info" StepType="Step">
                                        <table class="wizardTable">
                                            <tr>
                                                <td class="wizardStepHeader">Academic Information</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                                                    <ContentTemplate>
                                                                        <table>
                                                                            <tr>
                                                                                <th>Batch</th>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlBatch" runat="server"></asp:DropDownList></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <th>Insititute</th>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlIns" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlIns_SelectedIndexChanged"></asp:DropDownList></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <th>Program</th>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlPgm" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPgm_SelectedIndexChanged"></asp:DropDownList></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <th>Branch</th>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlBranch" runat="server" AutoPostBack="True"></asp:DropDownList></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <th>Semester</th>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlSem" runat="server" AutoPostBack="True"></asp:DropDownList></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <th>Section</th>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlSection" runat="server" AutoPostBack="True"></asp:DropDownList></td>
                                                                            </tr>
                                                                             <tr>
                                                                                <th>Admission Type</th>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlAdmType" runat="server" AutoPostBack="True"></asp:DropDownList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <th>Quota</th>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlQuota" runat="server" AutoPostBack="True"></asp:DropDownList></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <th>Form No</th>
                                                                                <td>
                                                                                    <cc1:NumericTextBox ID="txtForm" runat="server"></cc1:NumericTextBox></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <th>Entrance Exam</th>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlAdmCategory" runat="server" AutoPostBack="True"></asp:DropDownList></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <th>Test Rank</th>
                                                                                <td>
                                                                                    <cc1:NumericTextBox ID="txtTestRank" runat="server"></cc1:NumericTextBox></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <th>Admission Date</th>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtAdmDt" runat="server"></asp:TextBox></td>
                                                                                <td>
                                                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtAdmDt"></ajaxToolkit:CalendarExtender>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:WizardStep>

                                    <asp:WizardStep runat="server" Title="Contact Information" StepType="Step">
                                        <table class="wizardTable">
                                            <tr>
                                                <td class="wizardStepHeader">Contact Information</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:UpdatePanel ID="UpdateAdd" runat="server" UpdateMode="Conditional">
                                                        <ContentTemplate>
                                                            <uc1:address runat="server" ID="address" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:UpdatePanel ID="UpdatePh" runat="server" UpdateMode="Conditional">
                                                        <ContentTemplate>
                                                            <uc1:phoneNumber runat="server" ID="phoneNumber" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:UpdatePanel ID="UpdateMail" runat="server" UpdateMode="Conditional">
                                                        <ContentTemplate>
                                                            <uc1:email runat="server" ID="email" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:WizardStep>
                                    <asp:WizardStep runat="server" Title="Qualification" StepType="Step">
                                        <table class="wizardTable">
                                            <tr>
                                                <td class="wizardStepHeader">Qualification Information
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <uc1:academicType runat="server" ID="academicType" />
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:WizardStep>
                                    <asp:WizardStep ID="WizardStep1" runat="server" Title="Document Collection" StepType="Finish">
                                        <table class="wizardTable">
                                            <tr>
                                                <td class="wizardStepHeader">Collection
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:GridView ID="gvDoc" runat="server" DataKeyNames="PGM_DOC_MAP_ID,STU_DOC_ID" AutoGenerateColumns="false" Width="90%" EmptyDataText="No docuemnt found">
                                                        <Columns>
                                                            <asp:TemplateField>

                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="ChkBox" runat="server" Checked='<%# Convert.ToBoolean(Eval("DOC_IN_STS"))%>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField HeaderText="Document Name" DataField="DOC_VALUE">
                                                                <ItemStyle Width="300px" />
                                                            </asp:BoundField>
                                                            <asp:TemplateField HeaderText="Remark">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtRemark" runat="server" Text=' <%# Bind("DOC_IN_REMARK") %>'></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>

                                                </td>
                                            </tr>
                                            <tr>
                                                <th>Remark</th>
                                                <td>
                                                    <asp:TextBox ID="txtRemark" runat="server" Width="250px"></asp:TextBox>
                                                    <asp:TextBox ID="txtData" runat="server" Visible="false"></asp:TextBox></td>
                                            </tr>
                                        </table>

                                    </asp:WizardStep>
                                </WizardSteps>
                            </asp:Wizard>
                        </td>
                        <td id="tbPic" runat="server" style="vertical-align: top;">
                            <table>
                                <tr>
                                    <td>
                                        <img id="imgStu" runat="server" alt="Image" src="~/images/Stuimages/photo/StuImage.jpg"
                                            style="border: 1px solid #000000; height: 110px; width: 100px;" />
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        <asp:Label ID="lblName" runat="server"></asp:Label><br />
                                        <asp:Label ID="lblStatus" runat="server" ForeColor="#ff0000"></asp:Label></th>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

