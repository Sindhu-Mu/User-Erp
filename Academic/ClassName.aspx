<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="ClassName.aspx.cs" Inherits="Academic_ClassName" %>

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
        function validationCordSave() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=txtCordinator.ClientID%>")) {
                msg += " * Select Institute. \n";
                if (ctrl == "")
                    ctrl = "<%=txtCordinator.ClientID%>";
                flag = false;
            }

            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }

        function validationClassSave() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=ddlInst.ClientID%>")) {
                msg += " * Select Institute. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlInst.ClientID%>";
                flag = false;
            }
         <%--    if (!CheckControl("<%=txtClassName.ClientID%>")) {
                msg += " * Enter unique Class name. \n";
                if (ctrl == "")
                    ctrl = "<%=txtClassName.ClientID%>";
                flag = false;
            }--%>

            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }

        function validationAddBranch() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=ddlCourse.ClientID%>")) {
                msg += " * Select Course. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlCourse.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlBranch.ClientID%>")) {
                msg += " * Select Branch. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlBranch.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlSemester.ClientID%>")) {
                msg += " * Select Semester. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlSemester.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlSection.ClientID%>")) {
                msg += " * Select Section. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlSection.ClientID%>";
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
            <h2>Rule Creation</h2>
        </div>
        <asp:UpdatePanel ID="UpdatePanel11" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table>
                    <tr>
                        <td>
                            <asp:Wizard ID="newClassWizard" runat="server" ActiveStepIndex="0"
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
                                    <asp:WizardStep ID="WizardStep1" runat="server" StepType="Start" Title="Class Name">
                                        <table class="wizardTable">
                                            <tr>
                                                <th>Class Name 
                                                </th>
                                            </tr>
                                            <tr>
                                                <td style="color: Red; font-style: italic; font-weight: bold">Deleting a Class will delete the relevant Time Table and Attendance Details also

                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:UpdatePanel ID="update1" runat="server" UpdateMode="Conditional">
                                                                    <ContentTemplate>
                                                                        <table>
                                                                            <tr>
                                                                                <td>Institution</td>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlInst" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlInst_SelectedIndexChanged"></asp:DropDownList></td>
                                                                            </tr>
                                                                         <%--   <tr>
                                                                                <td>Class Name</td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtClassName" runat="server"></asp:TextBox>

                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Button ID="btnSaveClassName" runat="server" Text="Save" OnClick="btnSaveClassName_Click" />

                                                                                </td>
                                                                            </tr>--%>
                                                                        </table>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                        </tr>

                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:UpdatePanel ID="update2" runat="server" UpdateMode="Conditional">
                                                        <ContentTemplate>
                                                            <table>
                                                                <tr>
                                                                    <td>
                                                                        <asp:GridView ID="gridClassName" runat="server" AutoGenerateColumns="false" EmptyDataText="No record found."
                                                                            DataKeyNames="CLS_ID" OnRowDeleting="gridClassName_RowDeleting">
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="S.No.">
                                                                                    <ItemTemplate>
                                                                                        <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                                                    .
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField HeaderText="Class Name" DataField="CLS_VALUE" />
                                                                                <asp:CommandField ShowDeleteButton="true" />
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:WizardStep>
                                </WizardSteps>
                                <WizardSteps>
                                    <asp:WizardStep ID="WizardSte2" runat="server" StepType="Step" Title="Choose Class" OnActivate="ActivateStep1">
                                        <table class="wizardTable">
                                            <tr>
                                                <th>Choose Class</th>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:UpdatePanel ID="update3" runat="server" UpdateMode="Conditional">
                                                                    <ContentTemplate>
                                                                        <table>
                                                                            <tr>
                                                                                <td>Choose Semester</td>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlSemesterBound" runat="server" Width="120px" AutoPostBack="true" OnSelectedIndexChanged="ddlSemesterBound_SelectedIndexChanged"></asp:DropDownList></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>Choose Class</td>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlChooseClass" runat="server" Width="120px" AutoPostBack="true"></asp:DropDownList></td>
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
                                </WizardSteps>
                                <WizardSteps>
                                    <asp:WizardStep ID="WizardStep3" runat="server" StepType="Step" Title="Choose Branch & Section" OnActivate="ActivateBranch">
                                        <table class="wizardTable">
                                            <tr>
                                                <th>Choose branch & Section</th>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <table>
                                                                    <tr>
                                                                        <td colspan="2">Class Cordinator : <b>
                                                                            <asp:Label ID="lblCord" runat="server" Text="Label" Visible="false"></asp:Label></b></td>
                                                                    </tr>
                                                                    <tr id="trCordBtn" runat="server" visible="true">
                                                                        <td>
                                                                            <asp:TextBox ID="txtCordinator" runat="server"></asp:TextBox>
                                                                            <ajaxToolkit:AutoCompleteExtender ID="autoComplete1" runat="server" CompletionInterval="500"
                                                                                CompletionSetCount="12" ContextKey="1" EnableCaching="true" MinimumPrefixLength="1"
                                                                                ServiceMethod="GetEmployeeList" ServicePath="~\AutoComplete.asmx" TargetControlID="txtCordinator">
                                                                            </ajaxToolkit:AutoCompleteExtender>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Button ID="btnCordSave" runat="server" Text="Save Cordinator Name" OnClick="btnCordSave_Click" /></td>
                                                                    </tr>

                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:UpdatePanel ID="update4" runat="server" UpdateMode="Conditional">
                                                                    <ContentTemplate>
                                                                        <table style="width: 100%">
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:GridView ID="gridExistingBranch" runat="server" Width="100%" AutoGenerateColumns="False"
                                                                                        EnableViewState="False">
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
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:UpdatePanel ID="update5" runat="server" UpdateMode="Conditional">
                                                                    <ContentTemplate>
                                                                        <table>
                                                                            <tr>
                                                                                <td>Institution</td>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlInstitution" runat="server" Width="120px" AutoPostBack="true" OnSelectedIndexChanged="ddlInstitution_SelectedIndexChanged"></asp:DropDownList></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>Course</td>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlCourse" runat="server" Width="120px" AutoPostBack="true" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged"></asp:DropDownList></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>Branch</td>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlBranch" runat="server" Width="120px"></asp:DropDownList></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>Semester</td>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlSemester" runat="server" Width="120px"></asp:DropDownList></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>Section</td>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlSection" runat="server" Width="120px"></asp:DropDownList></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtStep2" runat="server" Visible="false"></asp:TextBox>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtStep2Ex" runat="server" Visible="false"></asp:TextBox>
                                                                                </td>
                                                                            </tr>

                                                                        </table>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:UpdatePanel ID="update6" runat="server" UpdateMode="Conditional">
                                                                    <ContentTemplate>
                                                                        <table>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:GridView ID="gridBranch" runat="server" AutoGenerateColumns="false" EnableViewState="false" OnRowDeleting="gridBranch_RowDeleting">
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
                                                                                            <asp:CommandField ShowDeleteButton="true" />
                                                                                        </Columns>
                                                                                    </asp:GridView>
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
                                </WizardSteps>
                                <WizardSteps>
                                    <asp:WizardStep ID="WizardStep4" runat="server" StepType="Finish" Title="Select Paper Combination" OnActivate="ActivatePaper">
                                        <table class="wizardTable">
                                            <tr>
                                                <th>Select Paper Compination</th>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:UpdatePanel ID="update7" runat="server" UpdateMode="Conditional">
                                                        <ContentTemplate>
                                                            <asp:Repeater ID="repPaperCode" runat="server">
                                                                <HeaderTemplate>
                                                                    <div>
                                                                        <table>
                                                                            <tr>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <td>
                                                                        <table>
                                                                            <tr>
                                                                                <td>
                                                                                    <table>
                                                                                        <tr>
                                                                                            <th>Course:</th>
                                                                                            <td>
                                                                                                <%# DataBinder.Eval(Container.DataItem, "COURSE_SHORT_NAME") %>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <th>Batch:</th>
                                                                                            <td>
                                                                                                <%# DataBinder.Eval(Container.DataItem, "BATCH_ID") %>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <th>Branch:</th>
                                                                                            <td>
                                                                                                <%# DataBinder.Eval(Container.DataItem, "BRANCH_SHORT_NAME") %>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <th>Semester:</th>
                                                                                            <td>
                                                                                                <%# DataBinder.Eval(Container.DataItem, "SEMESTER_NO")%>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <th>Section:</th>
                                                                                            <td>
                                                                                                <asp:Label ID="lblSection" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SECTION")%>'></asp:Label>
                                                                                                <asp:Label ID="lblSection_id" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "SECTION_ID")%>'></asp:Label>

                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <table class="wizardTable">
                                                                                        <tr>
                                                                                            <td>
                                                                                                <asp:DropDownList ID="ddlPaperCode" runat="server" Width="80px">
                                                                                                </asp:DropDownList>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    </tr> </table> </div>
                                                                </FooterTemplate>
                                                            </asp:Repeater>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:UpdatePanel ID="update8" runat="server" UpdateMode="Conditional">
                                                        <ContentTemplate>
                                                            <table>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Button ID="btnGeneratePaperCombination" runat="server" Text="Generate"
                                                                            EnableViewState="false" OnClick="btnGeneratePaperCombination_Click" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtStep3" runat="server" Visible="false"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2">
                                                                        <asp:GridView ID="gridPaperCombination" runat="server" CssClass="gridDynamic" AutoGenerateColumns="false"
                                                                            EnableViewState="false" ShowHeader="false" OnRowDeleting="gridPaperCombination_RowDeleting"
                                                                            DataKeyNames="STEP_ID">
                                                                            <Columns>
                                                                                <asp:BoundField DataField="STEP_ID">
                                                                                    <ItemStyle Width="0px" />
                                                                                </asp:BoundField>
                                                                                <asp:TemplateField>
                                                                                    <ItemTemplate>
                                                                                        Paper Combination:
                                                                                    <%# DataBinder.Eval(Container.DataItem, "STEP_ID")%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField DataField="PAPER_CODE" />
                                                                                <asp:CommandField ShowDeleteButton="true" />
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:UpdatePanel ID="update9" runat="server" UpdateMode="Conditional">
                                                        <ContentTemplate>
                                                            <asp:Button ID="btnSavePaperCombination" runat="server" Text="Save" OnClick="btnSavePaperCombination_Click"
                                                                EnableViewState="false" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
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

