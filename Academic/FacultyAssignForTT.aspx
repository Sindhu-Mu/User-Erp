<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="FacultyAssignForTT.aspx.cs" Inherits="Academic_FacultyAssignForTT" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript">

        function SelectAllCheckboxes(spanChk) {


            var oItem = spanChk.children;
            var theBox = (spanChk.type == "checkbox") ?
                spanChk : spanChk.children.item[0];
            xState = theBox.checked;
            elm = theBox.form.elements;

            for (i = 0; i < elm.length; i++)
                if (elm[i].type == "checkbox" &&
                         elm[i].id != theBox.id) {
                    //elm[i].click();
                    if (elm[i].checked != xState)
                        elm[i].click();
                    //elm[i].checked=xState;
                }


        }

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


        function Validation() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckAutoComplete("<%=txtEmp.ClientID%>")) {
                msg += " * Enter employee name & code. \n";
                if (ctrl == "")
                    ctrl = "<%=txtEmp.ClientID%>";
                flag = false;
            }
            if (!CheckDate("<%=txtFrmDt.ClientID%>")) {
                if (!CheckControl("<%=txtFrmDt.ClientID%>")) {
                    msg += " * Enter From date. \n";
                    if (ctrl == "")
                        ctrl = "<%=txtFrmDt.ClientID%>";
                    flag = false;
                }
                else {
                    msg += " * Enter Correct Date.  \n";
                    if (ctrl == "")
                        ctrl = "<%=txtFrmDt.ClientID%>";
                    flag = false;
                }
            }
            if (!CheckDate("<%=txtToDt.ClientID%>")) {
                if (!CheckControl("<%=txtToDt.ClientID%>")) {
                    msg += " * Enter To date. \n";
                    if (ctrl == "")
                        ctrl = "<%=txtToDt.ClientID%>";
                flag = false;
            }
            else {
                msg += " * Enter Correct Date.  \n";
                if (ctrl == "")
                    ctrl = "<%=txtToDt.ClientID%>";
                    flag = false;
                }
            }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }
    </script>

    <div class="container">
        <div class="heading">
            <h2>Faculty Assign</h2>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
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
                                                                                    <asp:DropDownList ID="ddlInst" runat="server">
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <th>Choose Sem<span class="required">*</span></th>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlSemesterBound" runat="server" OnSelectedIndexChanged="ddlSemesterBound_SelectedIndexChanged"
                                                                                        AutoPostBack="true">
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <th>Choose Class<span class="required">*</span></th>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlChooseClass" runat="server">
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
                                    <asp:WizardStep ID="WizardStep2" runat="server" StepType="Step" Title="Verify Branch Data" OnActivate="ActivateWizardStep1">
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
                                                                        <asp:GridView ID="gridPaperCombination" runat="server" AutoGenerateColumns="False"
                                                                            SelectedRowStyle-BackColor="#ffff99" EnableViewState="False" ShowHeader="false"
                                                                            DataKeyNames="TT_ID" OnRowCommand="gridPaperCombination_RowCommand">
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
                                                                            </Columns>
                                                                            <SelectedRowStyle CssClass="pgr" BackColor="#ffff99" />
                                                                        </asp:GridView>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:WizardStep>

                                    <asp:WizardStep ID="WizardStep4" runat="server" StepType="Finish" Title="Additional Detail" AllowReturn="False" OnActivate="ActivateWizardStep3">
                                        <table class="wizardTable">
                                            <tr>
                                                <td class="wizardStepHeader">Choose Class Date
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table style="width: 100%">
                                                        <tr>
                                                            <td>
                                                                <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                                                                    <ContentTemplate>
                                                                        <asp:GridView ID="gridDetail" runat="server" AutoGenerateColumns="False" DataKeyNames="GRP_ID"
                                                                            EnableViewState="False" ShowHeader="true" EmptyDataText="No time table for this paper code.">
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="S.No.">
                                                                                    <ItemTemplate>
                                                                                        <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <%--<asp:BoundField DataField="PAPER_CODE" ControlStyle-Width="15px" />--%>

                                                                                <asp:BoundField DataField="GRP_VALUE" HeaderText="Group" />
                                                                                <asp:BoundField DataField="DATE" HeaderText="From Date" />
                                                                                <asp:BoundField DataField="TT_FAC_TYPE_VALUE" HeaderText="Faculty Type" />
                                                                                <asp:BoundField DataField="EMP_NAME" HeaderText="Assigned Faculty" />
                                                                            </Columns>

                                                                        </asp:GridView>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr id="trAssign" runat="server" visible="false">
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <td>User Type</td>
                                                            <td>Employee name</td>
                                                            <td>Faculty Type</td>
                                                            <td style="padding-left: 10px">From Date</td>
                                                            <td style="padding-left: 10px">To Date</td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:DropDownList ID="ddlUsrType" runat="server" Width="150px"></asp:DropDownList></td>
                                                            <td>
                                                                <asp:TextBox ID="txtEmp" runat="server" Width="200px"></asp:TextBox>
                                                                <ajaxToolkit:AutoCompleteExtender ID="autoComplete1" runat="server" CompletionInterval="500"
                                                                    CompletionSetCount="12" ContextKey="1" EnableCaching="true" MinimumPrefixLength="1"
                                                                    ServiceMethod="GetEmployeeList" ServicePath="~\AutoComplete.asmx" TargetControlID="txtEmp">
                                                                </ajaxToolkit:AutoCompleteExtender>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlFaculty" runat="server" Width="150px"></asp:DropDownList></td>
                                                            <td style="padding-left: 10px">
                                                                <asp:TextBox ID="txtFrmDt" runat="server" Width="150px"></asp:TextBox>
                                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFrmDt"
                                                                    Format="dd/MM/yyyy" PopupPosition="TopLeft">
                                                                </ajaxToolkit:CalendarExtender>
                                                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="99/99/9999" MaskType="Date"
                                                                    TargetControlID="txtFrmDt">
                                                                </ajaxToolkit:MaskedEditExtender>
                                                            </td>
                                                            <td style="padding-left: 10px">
                                                                <asp:TextBox ID="txtToDt" runat="server" Width="150px"></asp:TextBox>
                                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtToDt"
                                                                    Format="dd/MM/yyyy" PopupPosition="TopLeft">
                                                                </ajaxToolkit:CalendarExtender>
                                                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" Mask="99/99/9999" MaskType="Date"
                                                                    TargetControlID="txtToDt">
                                                                </ajaxToolkit:MaskedEditExtender>
                                                            </td>
                                                            <td style="padding-left: 10px">
                                                                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" /></td>
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

