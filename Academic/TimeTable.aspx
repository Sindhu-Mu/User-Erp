<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="TimeTable.aspx.cs" Inherits="Academic_TimeTable" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script lang="javascript" type="text/javascript">
        function CheckControl(ctrl) {
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == ".") {
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
                return false;
            }
            else
                document.getElementById(ctrl).style.backgroundColor = "#fff";
            return true;
        }
        function CheckDate(ctrl) {
            var dt = document.getElementById(ctrl).value;
            if (!isDatecheck(dt, "dd/MM/yyyy")) {
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
                return false;
            }
            else
                document.getElementById(ctrl).style.backgroundColor = "#fff";
            return true;
        }
        function getDate(ctrl, ctrl1) {
            var dd = (compareDateshr(document.getElementById(ctrl).value, "dd/MM/yyyy", document.getElementById(ctrl1).value, "dd/MM/yyyy"));
            if (dd == 1)
                return false;

            return true;
        }

        function validate() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=ddlClassType.ClientID%>")) {
                msg += " * Select Institute. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlClassType.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlFaculty.ClientID%>")) {
                msg += " * Enter unique Class name. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlFaculty.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlGroup.ClientID%>")) {
                msg += " * Select Institute. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlGroup.ClientID%>";
                flag = false;
            }

            if (!CheckControl("<%=ddlSlot.ClientID%>")) {
                msg += " * Select Institute. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlSlot.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlRoom.ClientID%>")) {
                msg += " * Select Institute. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlRoom.ClientID%>";
                flag = false;
            }
            if (!CheckDate("<%=txtStartDate.ClientID%>")) {
                if (!CheckControl("<%=txtStartDate.ClientID%>")) {
                    msg += " * Enter To date. \n";
                    if (ctrl == "")
                        ctrl = "<%=txtStartDate.ClientID%>";
                    flag = false;
                }
                else {
                    msg += " * Enter Correct Date.  \n";
                    if (ctrl == "")
                        ctrl = "<%=txtStartDate.ClientID%>";
                    flag = false;
                }
            }

            if (!CheckDate("<%=txtEndDate.ClientID%>")) {
                if (!CheckControl("<%=txtEndDate.ClientID%>")) {
                msg += " * Enter To date. \n";
                if (ctrl == "")
                    ctrl = "<%=txtEndDate.ClientID%>";
                    flag = false;
                }
                else {
                    msg += " * Enter Correct Date.  \n";
                    if (ctrl == "")
                        ctrl = "<%=txtEndDate.ClientID%>";
                    flag = false;
                }
            }
            if (!getDate("<%=txtStartDate.ClientID%>", "<%=txtEndDate.ClientID%>")) {
                msg += "- From date is greater then To date\n";
                if (ctrl == "")
                    ctrl = "<%=txtStartDate.ClientID%>";
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
            <h2>Time table Creation</h2>
        </div>
        <asp:UpdatePanel ID="UP1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table>
                    <tr>
                        <td>
                            <asp:Wizard ID="timeTableWizard" runat="server" ActiveStepIndex="3"
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
                                    <asp:WizardStep ID="WizardStep1" runat="server" StepType="Start" Title="Choose Class">
                                        <table class="wizardTable">
                                            <tr>
                                                <td class="wizardStepHeader">Choose Class</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table style="width: 100%">
                                                        <tr>
                                                            <td>
                                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                                                    <ContentTemplate>
                                                                        <table>
                                                                            <tr>
                                                                                <th>Choose Institute<span class="required">*</span></th>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlInst" runat="server" Width="120px">
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <th>Choose Sem<span class="required">*</span></th>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlSemesterBound" runat="server" Width="120px" OnSelectedIndexChanged="ddlSemesterBound_SelectedIndexChanged"
                                                                                        AutoPostBack="true">
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <th>Choose Class<span class="required">*</span></th>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlChooseClass" runat="server" Width="120px">
                                                                                    </asp:DropDownList></td>
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
                                    <asp:WizardStep ID="WizardStep2" runat="server" StepType="Step" Title="Verify Branch Data" AllowReturn="False" OnActivate="ActivateWizardStep1">
                                        <table class="wizardTable">
                                            <tr>
                                                <td class="wizardStepHeader">Verify Branch Data
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table style="width: 100%">
                                                        <tr>
                                                            <td>
                                                                <asp:GridView ID="gridBranch" runat="server" AutoGenerateColumns="False" EnableViewState="False">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="S.No.">
                                                                            <ItemTemplate>
                                                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField HeaderText="Course" DataField="COURSE_SHORT_NAME" />
                                                                        <asp:BoundField HeaderText="Batch" DataField="BATCH_ID" />
                                                                        <asp:BoundField HeaderText="Branch" DataField="BRANCH_SHORT_NAME" />
                                                                        <asp:BoundField HeaderText="Semester" DataField="SEMESTER_NO" />
                                                                        <asp:BoundField HeaderText="Section" DataField="SECTION" />
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:WizardStep>
                                    <asp:WizardStep ID="WizardStep3" runat="server" StepType="Step" Title="Choose Paper Combination" OnActivate="ActivateWizardStep2">
                                        <table class="wizardTable">
                                            <tr>
                                                <td class="wizardStepHeader">Choose Paper Combination
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="color: Blue; font-style: italic; font-weight: bold">Press the next button after selecting the Paper Code from the list
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="color: Red; font-style: italic; font-weight: bold">Deleting a paper combination will delete the relevant Time Table and Attendance Details also
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="txtstep2" runat="server" Visible="False"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                                                                    <ContentTemplate>
                                                                        <div style="overflow: auto; width: 100%; height: 380px">
                                                                            <asp:GridView ID="gridPaperCombination" runat="server" AutoGenerateColumns="False"
                                                                                SelectedRowStyle-BackColor="#ffff99" EnableViewState="False" ShowHeader="False"
                                                                                DataKeyNames="TT_ID" OnRowCommand="gridPaperCombination_RowCommand" OnRowDeleting="gridPaperCombination_RowDeleting">
                                                                                <Columns>
                                                                                    <asp:BoundField DataField="STEP_ID">
                                                                                        <ItemStyle Width="0px" />
                                                                                    </asp:BoundField>
                                                                                    <asp:TemplateField>
                                                                                        <ItemStyle Width="5PX" />
                                                                                        <ItemTemplate>
                                                                                            Paper Combination: <%# DataBinder.Eval(Container.DataItem, "STEP_ID")%>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:BoundField DataField="PAPER_CODE" ControlStyle-Width="15px" />
                                                                                    <asp:CommandField ShowSelectButton="True" />
                                                                                    <asp:CommandField ShowDeleteButton="true" />
                                                                                </Columns>
                                                                                <SelectedRowStyle CssClass="pgr" BackColor="#ffff99" />
                                                                            </asp:GridView>
                                                                        </div>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:WizardStep>
                                    <asp:WizardStep ID="WizardStep4" runat="server" StepType="Finish" Title="Additional Details" OnActivate="ActivateWizardStep3">
                                        <table class="wizardTable">
                                            <tr>
                                                <td class="wizardStepHeader">Additional Details
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                                                                    <ContentTemplate>
                                                                        <asp:GridView ID="gridPaperCombinationSelect" runat="server" DataKeyNames="TT_ID"
                                                                            ShowHeader="False" EnableViewState="False" AutoGenerateColumns="False" CellPadding="2" CellSpacing="2" Width="97%">
                                                                            <Columns>
                                                                                <asp:BoundField DataField="STEP_ID">
                                                                                    <ItemStyle Width="0px" />
                                                                                </asp:BoundField>
                                                                                <asp:TemplateField>
                                                                                    <ItemTemplate>
                                                                                        Paper Combination: <%# DataBinder.Eval(Container.DataItem, "STEP_ID")%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField DataField="PAPER_CODE" />
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <table>
                                                                    <tr>
                                                                        <th>Faculty<span class="required">*</span>
                                                                        </th>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddlFaculty" runat="server" Width="120px">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <%--<tr>
                                                                        <th></th>
                                                                        <td>
                                                                            <asp:TextBox ID="txtFaculty" runat="server"></asp:TextBox>
                                                                            <ajaxToolkit:AutoCompleteExtender ID="autoComplete1" runat="server" CompletionInterval="500"
                                                                                CompletionSetCount="12" ContextKey="1" EnableCaching="true" MinimumPrefixLength="1"
                                                                                ServiceMethod="GetEmployeeList" ServicePath="~\AutoComplete.asmx" TargetControlID="txtFaculty">
                                                                            </ajaxToolkit:AutoCompleteExtender>
                                                                        </td>
                                                                    </tr>--%>
                                                                    <tr>
                                                                        <th>Class Type<span class="required">*</span></th>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddlClassType" runat="server" Width="120px"></asp:DropDownList>
                                                                            <%--<asp:RadioButtonList ID="radClassType" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                                                                            </asp:RadioButtonList>--%></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <th>Group<span class="required">*</span></th>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddlGroup" runat="server" Width="120px">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <th>From Date<span class="required">*</span></th>
                                                                        <td>
                                                                            <asp:TextBox ID="txtStartDate" runat="server"></asp:TextBox>
                                                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtStartDate"
                                                                                Format="dd/MM/yyyy" PopupPosition="TopLeft">
                                                                            </ajaxToolkit:CalendarExtender>
                                                                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="99/99/9999" MaskType="Date"
                                                                                TargetControlID="txtStartDate">
                                                                            </ajaxToolkit:MaskedEditExtender>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <th>To Date<span class="required">*</span></th>
                                                                        <td>
                                                                            <asp:TextBox ID="txtEndDate" runat="server"></asp:TextBox>
                                                                            <ajaxToolkit:CalendarExtender ID="cal1" runat="server" TargetControlID="txtEndDate"
                                                                                Format="dd/MM/yyyy" PopupPosition="TopLeft">
                                                                            </ajaxToolkit:CalendarExtender>
                                                                            <ajaxToolkit:MaskedEditExtender ID="me1" runat="server" Mask="99/99/9999" MaskType="Date"
                                                                                TargetControlID="txtEndDate">
                                                                            </ajaxToolkit:MaskedEditExtender>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <th>Time slot<span class="required">*</span></th>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddlSlot" runat="server" Width="120px"></asp:DropDownList>
                                                                            <%--<uc1:timepicker runat="server" id="txtStartTime" intervalminute="10" starthour="9" endhour="16" startminute="0" />
                                    </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <th>End Time<span class="required">*</span></th>
                                                                        <td>

                                    <uc1:timepicker runat="server" id="txtEndTime" intervalminute="10" starthour="9" endhour="17" startminute="0" />--%>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                                                                    <ContentTemplate>
                                                                        <table>
                                                                            <tbody>
                                                                                <tr>
                                                                                    <th>Complex<span class="required">*</span></th>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddlComplex" runat="server" Width="120px"
                                                                                            AutoPostBack="True" OnSelectedIndexChanged="ddlComplex_SelectedIndexChanged">
                                                                                        </asp:DropDownList></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <th>Room No<span class="required">*</span></th>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddlRoom" runat="server" Width="120px">
                                                                                        </asp:DropDownList></td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
                                                                    <ContentTemplate>
                                                                        <table>
                                                                            <tbody>
                                                                                <tr>
                                                                                    <th>Reoccurance<span class="expected">*</span></th>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddlReoccurance" runat="server" Width="120px"
                                                                                            AutoPostBack="True" OnSelectedIndexChanged="ddlReoccurance_SelectedIndexChanged">
                                                                                            <asp:ListItem Value="0">None</asp:ListItem>
                                                                                            <asp:ListItem Value="1">Daily</asp:ListItem>
                                                                                            <asp:ListItem Value="2">Weekly</asp:ListItem>
                                                                                            <asp:ListItem Value="3">Monthly</asp:ListItem>
                                                                                            <asp:ListItem Value="4">Fortnightly</asp:ListItem>
                                                                                            <asp:ListItem Value="5">Select Days</asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:CheckBoxList ID="chkDays" runat="server" Visible="False" RepeatDirection="Horizontal"
                                                                                            ToolTip="Pick Days">
                                                                                        </asp:CheckBoxList>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <table>
                                                                    <tr>
                                                                        <th>Save Option<span class="expected">*</span>
                                                                        </th>
                                                                        <td>
                                                                            <asp:RadioButtonList ID="radSaveConditions" runat="server" RepeatDirection="Horizontal">
                                                                                <asp:ListItem Selected="True" Value="1">Normal</asp:ListItem>
                                                                                <asp:ListItem Value="2">Modify</asp:ListItem>
                                                                            </asp:RadioButtonList></td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional">
                                                                    <ContentTemplate>
                                                                        <table style="width: 100%">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <th style="text-align: center">
                                                                                        <asp:Button ID="SaveTimeTable" runat="server" Text="Save" OnClick="SaveTimeTable_Click"></asp:Button>
                                                                                    </th>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <div style="overflow: auto; width: 100%; height: 200px">
                                                                                            <asp:GridView ID="GridView1" runat="server" EnableViewState="False"
                                                                                                AutoGenerateColumns="True" HeaderStyle-CssClass="GVFixedHeader" Width="97%">
                                                                                                <Columns>
                                                                                                </Columns>
                                                                                            </asp:GridView>
                                                                                        </div>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
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
                                </WizardSteps>

                            </asp:Wizard>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

