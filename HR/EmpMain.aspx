<%@ Page Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true"
    CodeFile="EmpMain.aspx.cs" Inherits="HR_EmpMain" Title="ERP | Employee Wizard"
    ValidateRequest="false" MaintainScrollPositionOnPostback="true" ViewStateEncryptionMode="Never" %>

<%@ Register Src="../control/email.ascx" TagName="email" TagPrefix="uc15" %>
<%@ Register Src="../control/address.ascx" TagName="address" TagPrefix="uc14" %>
<%@ Register Src="../control/bollean.ascx" TagName="bollean" TagPrefix="uc13" %>
<%@ Register Src="../control/maritalStatus.ascx" TagName="maritalStatus" TagPrefix="uc12" %>
<%@ Register Src="../control/experienceType.ascx" TagName="experienceType" TagPrefix="uc11" %>
<%@ Register Src="~/Control/EmpAcademicType.ascx" TagName="academicType" TagPrefix="uc10" %>
<%@ Register Src="../control/phoneNumber.ascx" TagName="phoneNumber" TagPrefix="uc9" %>
<%@ Register Src="../control/jobType.ascx" TagName="jobType" TagPrefix="uc7" %>
<%@ Register Src="../control/ddlNationality.ascx" TagName="ddlNationality" TagPrefix="uc4" %>
<%@ Register Src="../control/DatePicker.ascx" TagName="DatePicker" TagPrefix="uc3" %>
<%@ Register Src="../control/ddlGender.ascx" TagName="ddlGender" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script lang="javascript" type="text/javascript">
        function CheckAutoComplete(ctrl) {

            var Value = bTrim(document.getElementById(ctrl).value);
            if (Value.indexOf(":") > 0 && Value.length - 1 != Value.lastIndexOf(":")) {
                document.getElementById(ctrl).style.backgroundColor = "#fff";
                return true;
            }
            else
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
            return false;
        }

        function CheckControl(ctrl) {
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == "." || bTrim(document.getElementById(ctrl).value) == "Select") {
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
                return false;
            }
            else {
                document.getElementById(ctrl).style.backgroundColor = "#fff";
                return true;
            }
        }


        function Validate() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckAutoComplete("<%=txtEmployee.ClientID%>")) {
                msg += " * Enter Name with Code. \n";
                if (ctrl == "")
                    ctrl = "<%=txtEmployee.ClientID%>";
                flag = false;
            }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }
        function SalaryValidation() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=ddlSalaryTemplate.ClientID%>")) {
                msg += " * Select salary template . \n";
                if (ctrl == "")
                    ctrl = "<%=ddlSalaryTemplate.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlHead.ClientID%>")) {
                msg += " * Select salary head. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlHead.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtValue.ClientID%>")) {
                msg += " * Enter salary head value. \n";
                if (ctrl == "")
                    ctrl = "<%=txtValue.ClientID%>";
                flag = false;
            }
            if (CheckControl("<%=txtEffectiveDate.ClientID%>")) {
                if (!CheckDate("<%=txtEffectiveDate.ClientID%>")) {
                    msg += "- Invalid Format of Date.Please Enter in this[dd/MM/yyyy]\n";
                    if (ctrl == "")
                        ctrl = "<%=txtEffectiveDate.ClientID%>";
                    flag = false;
                }
            }
            else {
                msg += "- Please enter effective from\n";
                if (ctrl == "")
                    ctrl = "<%=txtEffectiveDate.ClientID%>";
                flag = false;
            }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }
        function ValidateWizard() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckAutoComplete("<%=txtEmployee.ClientID%>")) {
                msg += " * Enter Name with Code. \n";
                if (ctrl == "")
                    ctrl = "<%=txtEmployee.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlGender.ClientID%>")) {
                msg += " * Select Gender \n";
                if (ctrl == "")
                    ctrl = "<%=ddlGender.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlInitial.ClientID%>")) {
                msg += " * Select Initial \n";
                if (ctrl == "")
                    ctrl = "<%=ddlInitial.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtFirstName.ClientID%>")) {
                msg += " * Enter First Name  \n";
                if (ctrl == "")
                    ctrl = "<%=txtFirstName.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtLastName.ClientID%>")) {
                msg += " * Enter Last Name  \n";
                if (ctrl == "")
                    ctrl = "<%=txtLastName.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtDOB.ClientID%>")) {
                msg += " * Enter Date Of Birth  \n";
                if (ctrl == "")
                    ctrl = "<%=txtDOB.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlCaste.ClientID%>")) {
                msg += " * Select Caste  \n";
                if (ctrl == "")
                    ctrl = "<%=ddlCaste.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlReligion.ClientID%>")) {
                msg += " * Select Religion  \n";
                if (ctrl == "")
                    ctrl = "<%=ddlReligion.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlNationality.ClientID%>")) {
                msg += " * Select Nationality  \n";
                if (ctrl == "")
                    ctrl = "<%=ddlNationality.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtFatherName.ClientID%>")) {
                msg += " * Enter Father Name  \n";
                if (ctrl == "")
                    ctrl = "<%=txtFatherName.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlMaritalStatus.ClientID%>")) {
                msg += " * Select Marital Status  \n";
                if (ctrl == "")
                    ctrl = "<%=ddlMaritalStatus.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlIsHandicapped.ClientID%>")) {
                msg += " * Select Physically Challanged  \n";
                if (ctrl == "")
                    ctrl = "<%=ddlIsHandicapped.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtDOJ.ClientID%>")) {
                msg += " * Enter Date Of Joining \n";
                if (ctrl == "")
                    ctrl = "<%=txtDOJ.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlJobType.ClientID%>")) {
                msg += " * Select Job Type  \n";
                if (ctrl == "")
                    ctrl = "<%=ddlJobType.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlServiceType.ClientID%>")) {
                msg += " * Select Service Type  \n";
                if (ctrl == "")
                    ctrl = "<%=ddlServiceType.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlEmployment.ClientID%>")) {
                msg += " * Select Employment Type  \n";
                if (ctrl == "")
                    ctrl = "<%=ddlEmployment.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlCategory.ClientID%>")) {
                msg += " * Select Category  \n";
                if (ctrl == "")
                    ctrl = "<%=ddlCategory.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlDesignation.ClientID%>")) {
                msg += " * Select Designation  \n";
                if (ctrl == "")
                    ctrl = "<%=ddlDesignation.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlInstitution.ClientID%>")) {
                msg += " * Select Institution \n";
                if (ctrl == "")
                    ctrl = "<%=ddlInstitution.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlDepartment.ClientID%>")) {
                msg += " * Select Department \n";
                if (ctrl == "")
                    ctrl = "<%=ddlDepartment.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlShift.ClientID%>")) {
                msg += " * Select Shift  \n";
                if (ctrl == "")
                    ctrl = "<%=ddlShift.ClientID%>";
                flag = false;
            }
            if (!CheckAutoComplete("<%=txtNextSenior.ClientID%>")) {
                msg += " * Enter Next Senior with Code  \n";
                if (ctrl == "")
                    ctrl = "<%=txtNextSenior.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlBank.ClientID%>")) {
                msg += " * Select Bank  \n";
                if (ctrl == "")
                    ctrl = "<%=ddlBank.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtBranch.ClientID%>")) {
                msg += " * Enter Bank Branch \n";
                if (ctrl == "")
                    ctrl = "<%=txtBranch.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtAddress.ClientID%>")) {
                msg += " * Enter Bank Branch Address \n";
                if (ctrl == "")
                    ctrl = "<%=txtAddress.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlState.ClientID%>")) {
                msg += " * Select State  \n";
                if (ctrl == "")
                    ctrl = "<%=ddlState.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlCity.ClientID%>")) {
                msg += " * Select City  \n";
                if (ctrl == "")
                    ctrl = "<%=ddlCity.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtAccountNo.ClientID%>")) {
                msg += " * Enter Bank Account no. \n";
                if (ctrl == "")
                    ctrl = "<%=txtAccountNo.ClientID%>";
                flag = false;
            }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }

    </script>
    <div class="container">
        <div class="heading">
            <h2>Employee Information</h2>
        </div>
        <asp:UpdatePanel ID="UpdatePanel11" runat="server">
            <ContentTemplate>
                <table>

                    <tr>
                        <td>
                            <asp:Wizard ID="newEmpWizard" runat="server" ActiveStepIndex="0" OnFinishButtonClick="newEmpWizard_FinishButtonClick"
                                SkipLinkText="" Width="99%">
                                <SideBarButtonStyle CssClass="wizardSideButton" />
                                <SideBarStyle CssClass="wizardSide" />
                                <SideBarTemplate>
                                    <table>
                                        <tr>
                                            <td></td>
                                        </tr>
                                    </table>
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
                                    <asp:WizardStep runat="server" StepType="Start" Title="Basic Info">
                                        <table class="wizardTable">
                                            <tr>
                                                <td class="wizardStepHeader">Basic Informantion
                                                </td>
                                            </tr>

                                            <tr>
                                                <td>

                                                    <table>
                                                        <tr>
                                                            <th>Name & Code <span class="expected">*</span> </th>
                                                            <td style="width: 300px">
                                                                <asp:TextBox ID="txtEmployee" runat="server" Width="221px"></asp:TextBox>
                                                                <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" /></td>
                                                        </tr>
                                                        <tr>
                                                            <th>Gender<span class="required">*</span>
                                                            </th>
                                                            <td>
                                                                <asp:DropDownList ID="ddlGender" runat="server">
                                                                    <asp:ListItem Value="1" Text="Male"></asp:ListItem>
                                                                    <asp:ListItem Value="2" Text="Female"></asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:HiddenField ID="Hd1" runat="server" />
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
                                                            <th>Date of Birth<span class="required">*</span></th>
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
                                                            <th>Category<span class="required">*</span>
                                                            </th>
                                                            <td>
                                                                <asp:DropDownList ID="ddlCaste" runat="server">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <th>Religion<span class="required">*</span></th>
                                                            <td>
                                                                <asp:DropDownList ID="ddlReligion" runat="server">
                                                                </asp:DropDownList>
                                                                <br />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <th>Nationality <span class="required">*</span></th>
                                                            <td>
                                                                <asp:DropDownList ID="ddlNationality" runat="server">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <th>Mother Tongue<span class="expected">*</span></th>
                                                            <td>
                                                                <asp:DropDownList ID="ddlMotherTongue" runat="server">
                                                                </asp:DropDownList></td>
                                                        </tr>
                                                        <tr>
                                                            <th>Blood Group<span class="expected">*</span></th>
                                                            <td>
                                                                <asp:DropDownList ID="ddlBloodGroup" runat="server">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <th>Father Name<span class="required">*</span></th>
                                                            <td>
                                                                <asp:TextBox ID="txtFatherName" runat="server" Width="200px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <th>Mother Name<span class="expected">*</span></th>
                                                            <td>
                                                                <asp:TextBox ID="txtMotherName" runat="server" Width="200px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <th>Next Kin Type<span class="expected">*</span></th>
                                                            <td>
                                                                <asp:DropDownList ID="ddlNextKinType" runat="server">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <th>Next Kin Name<span class="expected">*</span></th>
                                                            <td>
                                                                <asp:TextBox ID="txtNextKinName" runat="server" Width="200px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <th>Marital Status<span class="required">*</span></th>
                                                            <td>
                                                                <asp:DropDownList ID="ddlMaritalStatus" runat="server">
                                                                    <asp:ListItem Value="0" Text="Unmarried"></asp:ListItem>
                                                                    <asp:ListItem Value="1" Text="Married"></asp:ListItem>
                                                                    <asp:ListItem Value="2" Text="Divorced"></asp:ListItem>
                                                                    <asp:ListItem Value="3" Text="Widow"></asp:ListItem>
                                                                    <asp:ListItem Value="4" Text="Widower"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <th>Spouse Name<span class="expected">*</span></th>
                                                            <td>
                                                                <asp:TextBox ID="txtSpouse" runat="server" Width="200px"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <th style="width: 200px">Physically Challenged<span class="required">*</span></th>
                                                            <td>
                                                                <asp:DropDownList ID="ddlIsHandicapped" runat="server">
                                                                    <asp:ListItem Value="0" Text="No"></asp:ListItem>
                                                                    <asp:ListItem Value="1" Text="Yes"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <th>Pan No.<span class="expected">*</span></th>
                                                            <td>
                                                                <asp:TextBox ID="txtPanNumber" runat="server" MaxLength="12" Width="100px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <th>Adhar No.<span class="expected">*</span></th>
                                                            <td>
                                                                <asp:TextBox ID="txtAdhar" runat="server" MaxLength="20" Width="140px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <th>Upload Photo</th>
                                                            <td>
                                                                <asp:FileUpload ID="ImgUpload" runat="server" Width="249px" />
                                                                <span style="color: #f00; font-weight: bold;">.jpg Only</span> </td>
                                                        </tr>

                                                    </table>

                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" CompletionSetCount="12"
                                                        EnableCaching="true" MinimumPrefixLength="1" ServiceMethod="GetEmployeeList"
                                                        ServicePath="~\AutoComplete.asmx" TargetControlID="txtEmployee" ContextKey="1,2,0,3,4">
                                                    </ajaxToolkit:AutoCompleteExtender>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:WizardStep>
                                    <asp:WizardStep runat="server" Title="Official Info" StepType="Step">
                                        <table class="wizardTable">
                                            <tr>
                                                <td class="wizardStepHeader">Official Info
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                                                                    <ContentTemplate>
                                                                        <table>
                                                                            <tr>
                                                                                <th style="width: 220px">Date of Joining<span class="required">*</span></th>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtDOJ" runat="server" Width="86px"></asp:TextBox>
                                                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDOJ" Format="dd/MM/yyyy">
                                                                                    </ajaxToolkit:CalendarExtender>
                                                                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="99/99/9999" MaskType="Date"
                                                                                        TargetControlID="txtDOJ">
                                                                                    </ajaxToolkit:MaskedEditExtender>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <th>Confirm On<span class="expected">*</span></th>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtConfirm" runat="server" Width="86px"></asp:TextBox>
                                                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtConfirm" Format="dd/MM/yyyy">
                                                                                    </ajaxToolkit:CalendarExtender>
                                                                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" Mask="99/99/9999" MaskType="Date"
                                                                                        TargetControlID="txtConfirm">
                                                                                    </ajaxToolkit:MaskedEditExtender>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <th>Job Type<span class="required">*</span>
                                                                                </th>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlJobType" runat="server">
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <th>Service Type<span class="required">*</span>
                                                                                </th>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlServiceType" runat="server">
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                            </tr>

                                                                            <tr>
                                                                                <th>Employment Type<span class="required">*</span>
                                                                                </th>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlEmployment" runat="server">
                                                                                        <asp:ListItem Value="1" Text="Permanent"></asp:ListItem>
                                                                                        <asp:ListItem Value="0" Text="Temporary"></asp:ListItem>
                                                                                        <asp:ListItem Value="2" Text="Noida"></asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <th>Contract Period (Months)<span class="expected">*</span>
                                                                                </th>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlContract" runat="server">
                                                                                        <asp:ListItem Value="0" Text="0"></asp:ListItem>
                                                                                        <asp:ListItem Value="1" Text="1"></asp:ListItem>
                                                                                        <asp:ListItem Value="2" Text="2"></asp:ListItem>
                                                                                        <asp:ListItem Value="3" Text="3"></asp:ListItem>
                                                                                        <asp:ListItem Value="4" Text="4"></asp:ListItem>
                                                                                        <asp:ListItem Value="5" Text="5"></asp:ListItem>
                                                                                        <asp:ListItem Value="6" Text="6"></asp:ListItem>
                                                                                        <asp:ListItem Value="7" Text="7"></asp:ListItem>
                                                                                        <asp:ListItem Value="8" Text="8"></asp:ListItem>
                                                                                        <asp:ListItem Value="9" Text="9"></asp:ListItem>
                                                                                        <asp:ListItem Value="10" Text="10"></asp:ListItem>
                                                                                        <asp:ListItem Value="11" Text="11"></asp:ListItem>
                                                                                        <asp:ListItem Value="12" Text="12"></asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <th>Probation Period<span class="expected">*</span>
                                                                                </th>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlProb" runat="server">
                                                                                        <asp:ListItem Value="0" Text="No Probation"></asp:ListItem>
                                                                                        <asp:ListItem Value="1" Text="3 Month"></asp:ListItem>
                                                                                        <asp:ListItem Value="2" Text="6 Month"></asp:ListItem>
                                                                                        <asp:ListItem Value="3" Text="1 Year"></asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <th>Category<span class="required">*</span>
                                                                                </th>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlCategory" runat="server">
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <th>Designation <span class="required">*</span>
                                                                                </th>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlDesignation" runat="server">
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <th>Institution<span class="required">*</span></th>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlInstitution" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlInstitution_SelectedIndexChanged">
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <th>Department <span class="required">*</span>
                                                                                </th>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlDepartment" runat="server">
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <th>Next Senior<span class="required">*</span>
                                                                                </th>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtNextSenior" runat="server" Width="200px"></asp:TextBox>
                                                                                    <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtNextSenior"
                                                                                        CompletionSetCount="12" EnableCaching="true" MinimumPrefixLength="1" ServiceMethod="GetEmployeeList"
                                                                                        ServicePath="~\AutoComplete.asmx" ContextKey="1">
                                                                                    </ajaxToolkit:AutoCompleteExtender>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <th>Shift <span class="required">*</span>
                                                                                </th>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlShift" runat="server">
                                                                                    </asp:DropDownList>
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
                                    <asp:WizardStep ID="WizardStep1" runat="server" Title="Salary Info" StepType="Step">
                                        <table class="wizardTable">
                                            <tr>
                                                <td class="wizardStepHeader">Salary Information
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <th style="width: 150px;">Salary Template<span class="expected">*</span></th>
                                                            <td>&nbsp;</td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlSalaryTemplate" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSalaryTemplate_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <th>Salary Head<span class="expected">*</span></th>
                                                            <td>&nbsp;</td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlHead" runat="server">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <th>Value<span class="expected">*</span></th>
                                                            <td>&nbsp;</td>
                                                            <td>
                                                                <cc1:NumericTextBox ID="txtValue" runat="server" MaxLength="18" AllowDecimal="true"
                                                                    AllowNegative="False" DecimalPlaces="2"></cc1:NumericTextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <th>Effective From<span class="expected">*</span></th>
                                                            <td>&nbsp;</td>
                                                            <td>
                                                                <asp:TextBox ID="txtEffectiveDate" runat="server" Width="86px"></asp:TextBox>
                                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtEffectiveDate" Format="dd/MM/yyyy">
                                                                </ajaxToolkit:CalendarExtender>
                                                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender3" runat="server" Mask="99/99/9999" MaskType="Date"
                                                                    TargetControlID="txtEffectiveDate">
                                                                </ajaxToolkit:MaskedEditExtender>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>
                                                                <asp:Button ID="btnAdd" runat="server" Text="Add Detail" OnClick="btnAdd_Click" /></td>
                                                        </tr>

                                                        <tr>
                                                            <td colspan="3">&nbsp;<asp:TextBox ID="txtSalaryXml" runat="server" Visible="false" ></asp:TextBox>
                                                                <br />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3">
                                                                <asp:GridView ID="SalaryGrid" runat="server" AutoGenerateColumns="false"  OnRowDeleting="SalaryGrid_RowDeleting">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="S.No.">
                                                                            <ItemTemplate>
                                                                                <%# ((GridViewRow)Container).RowIndex + 1%>                                    .
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField HeaderText="Salary Template" DataField="SAL_TEMPLATE_NAME" />
                                                                        <asp:BoundField HeaderText="Salary Head"  DataField="HEAD_NAME" />
                                                                        <asp:BoundField HeaderText="Salary Value" DataField="SAL_HEAD_VALUE" />
                                                                        <asp:BoundField HeaderText="Effective Date" DataField="EFFECTIVE_DT"  />
                                                                         <asp:CommandField ShowDeleteButton="true" DeleteImageUrl="~/images/delete.gif" DeleteText="delete" />

                                                                    </Columns>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>

                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:WizardStep>

                                    <asp:WizardStep runat="server" Title="Contact Info" StepType="Step">
                                        <table class="wizardTable">
                                            <tr>
                                                <td class="wizardStepHeader">Contact Information
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:UpdatePanel ID="upAdd1" runat="server" UpdateMode="Conditional">
                                                        <ContentTemplate>
                                                            <uc14:address ID="ctrlAddress" runat="server"></uc14:address>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td>
                                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                                        <ContentTemplate>
                                                            <uc9:phoneNumber ID="ctrlPhone" runat="server" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td>
                                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                                        <ContentTemplate>
                                                            <uc15:email ID="ctrlMail" runat="server" />
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
                                                    <uc10:academicType ID="ctrlAcademic" runat="server" />
                                                </td>
                                            </tr>

                                        </table>
                                    </asp:WizardStep>
                                    <asp:WizardStep runat="server" Title="Experience" StepType="Step">
                                        <table class="wizardTable">
                                            <tr>
                                                <td class="wizardStepHeader">Experience Information
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <uc11:experienceType ID="ctrlExperience" runat="server" />
                                                </td>
                                            </tr>

                                        </table>
                                    </asp:WizardStep>
                                    <asp:WizardStep runat="server" Title="Bank" StepType="Finish">
                                        <table class="wizardTable">
                                            <tr>
                                                <td class="wizardStepHeader">Bank Information
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <th>Bank<span class="expected">*</span></th>
                                                            <td>
                                                                <asp:DropDownList ID="ddlBank" runat="server">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <th>Branch<span class="expected">*</span></th>
                                                            <td>
                                                                <asp:TextBox ID="txtBranch" runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <th>Address<span class="expected">*</span></th>
                                                            <td>
                                                                <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <th>State<span class="expected">*</span></th>
                                                            <td>
                                                                <asp:DropDownList ID="ddlState" runat="server" OnSelectedIndexChanged="ddlState_SelectedIndexChanged"
                                                                    AutoPostBack="True">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <th>City<span class="expected">*</span></th>
                                                            <td>
                                                                <asp:DropDownList ID="ddlCity" runat="server">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <th>Account No.<span class="expected">*</span></th>
                                                            <td>
                                                                <cc1:NumericTextBox ID="txtAccountNo" runat="server" MaxLength="18" AllowDecimal="False"
                                                                    AllowNegative="False" DecimalPlaces="-1"></cc1:NumericTextBox></td>
                                                        </tr>


                                                    </table>
                                                </td>
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
                                        <img id="imgEmp" runat="server" alt="Image" src="~/images/emp_images/empImage.jpg"
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
