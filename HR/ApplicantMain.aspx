<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="ApplicantMain.aspx.cs" Inherits="HR_InterviewCandidateMain" %>

<%@ Register Src="~/Control/EmpAcademicType.ascx" TagPrefix="uc1" TagName="EmpAcademicType" %>
<%@ Register Src="~/Control/experienceType.ascx" TagPrefix="uc1" TagName="experienceType" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="heading">
            <h2>Candidate Information
            </h2>
        </div>
        <div>
            <table>
                <tr>
                    <td>
                    <td>
                        <asp:Wizard ID="newCanWizard" runat="server" ActiveStepIndex="0" OnFinishButtonClick="newCanWizard_FinishButtonClick"
                            SkipLinkText="" Width="99%">
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
                                <asp:WizardStep ID="WizardBasic" runat="server" StepType="Start" Title="Basic Info">
                                    <table class="wizardTable">
                                        <tr>
                                            <td class="wizardStepHeader">Basic Informantion
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <th>First Name<span class="required">*</span>
                                                        </th>
                                                        <td>
                                                            <asp:TextBox ID="txtFirstName" runat="server" Width="200px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th>Middle Name<span class="expected">*</span>
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
                                                        <th>Job No.<span class="expected">*</span></th>
                                                        <td>
                                                            <asp:DropDownList ID="ddlJob" runat="server"></asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th>Contact No.<span class="required">*</span>
                                                        </th>
                                                        <td>
                                                            <asp:TextBox ID="txtConNo" runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th>Mail<span class="required">*</span>
                                                        </th>
                                                        <td>
                                                            <asp:TextBox ID="txtMail" runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th>Mail Domain<span class="required">*</span>
                                                        </th>
                                                        <td>
                                                            <asp:DropDownList ID="ddlMailDomain" runat="server"></asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th>Location<span class="required">*</span>
                                                        </th>
                                                        <td>
                                                            <asp:TextBox ID="txtLocation" runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th>Administration Work<span class="required"></span>
                                                        </th>
                                                        <td>
                                                            <asp:DropDownList ID="ddlAdmin" runat="server">
                                                                <asp:ListItem Value="0" Text="No"></asp:ListItem>
                                                                <asp:ListItem Value="1" Text="Yes"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th>Current CTC<span class="required">*</span>
                                                        </th>
                                                        <td>
                                                            <cc1:NumericTextBox ID="txtCrntCTC" runat="server" AllowDecimal="true" AllowNegative="false" DecimalPlaces="2"></cc1:NumericTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th>Expected CTC<span class="required">*</span>
                                                        </th>
                                                        <td>
                                                            <cc1:NumericTextBox ID="txtExpctCTC" runat="server" AllowDecimal="true" AllowNegative="false" DecimalPlaces="2"></cc1:NumericTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th>Notice Period(Days)<span class="required">*</span>
                                                        </th>
                                                        <td>
                                                            <cc1:NumericTextBox ID="txtDays" runat="server" AllowDecimal="false" AllowNegative="false"></cc1:NumericTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th>Remark
                                                        </th>
                                                        <td>
                                                            <asp:TextBox ID="txtRemark" runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:WizardStep>
                                <asp:WizardStep ID="WizardAcademic" runat="server" StepType="Step" Title="Qualification">
                                    <table class="wizardTable">
                                        <tr>
                                            <td class="wizardStepHeader">Qualification Information
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <uc1:EmpAcademicType runat="server" ID="ctrlAcademic" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:WizardStep>
                                <asp:WizardStep ID="WizardExperience" runat="server" StepType="Finish" Title="Experience">
                                    <table class="wizardTable">
                                        <tr>
                                            <td class="wizardStepHeader">Experience Information
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <uc1:experienceType runat="server" ID="ctrlExperience" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>

                                </asp:WizardStep>
                            </WizardSteps>
                        </asp:Wizard>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

