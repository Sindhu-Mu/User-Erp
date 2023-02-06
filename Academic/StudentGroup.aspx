<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="StudentGroup.aspx.cs" Inherits="Academic_StudentGroup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script lang="javascript" type="text/javascript">
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
        function CheckControl(ctrl) {
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == ".") {
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
                return false;
            }
            else
                document.getElementById(ctrl).style.backgroundColor = "#fff";
            return true;
        }
        function validate() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=ddlPpr.ClientID%>")) {
                msg += " * Select Institute. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlPpr.ClientID%>";
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
            <h2>Stuednt Group</h2>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table>
                    <tr>
                        <td>
                            <asp:Wizard ID="timeTableWizard" runat="server" ActiveStepIndex="4"
                                SkipLinkText="" Width="99%">
                                <%--<SideBarButtonStyle CssClass="wizardSideButton" />--%>
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
                                    <asp:WizardStep Title="Choose Class" runat="server" StepType="Step" ID="WizardStep0">
                                        <table class="wizardTable">
                                            <tr>
                                                <td class="wizardStepHeader">Choose Class
                                                </td>
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
                                    <asp:WizardStep ID="WizardStep1" Title="Verify Branch" runat="server" StepType="Step"
                                        AllowReturn="False" OnActivate="ActivateWizardStep1">
                                        <table class="wizardTable">
                                            <tr>
                                                <td class="wizardStepHeader">Verify Branch
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

                                    <asp:WizardStep ID="WizardStep2" Title="Paper Combination" runat="server"
                                        StepType="Step" OnActivate="ActivateWizardStep2">
                                        <table class="wizardTable">
                                            <tr>
                                                <td class="wizardStepHeader">Paper Combination
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
                                                                            SelectedRowStyle-BackColor="#ffff99" EnableViewState="False" ShowHeader="False"
                                                                            DataKeyNames="TT_ID" OnRowCommand="gridPaperCombination_RowCommand" PageSize="6">
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
                                                                                <asp:CommandField ShowSelectButton="True" ButtonType="Button" />
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

                                    <asp:WizardStep ID="WizardStep3" Title="Group Assignment" runat="server" StepType="Step"
                                        OnActivate="ActivateWizardStep3">
                                        <table class="wizardTable">
                                            <tr>
                                                <td class="wizardStepHeader">Group Assignment
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                                                                    <ContentTemplate>
                                                                        <asp:GridView ID="gridPaperCombinationSelect" runat="server" AutoGenerateColumns="False"
                                                                            EnableViewState="true" ShowHeader="False" DataKeyNames="TT_ID">
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
                                                                                <asp:BoundField DataField="STEP_ID">
                                                                                    <ItemStyle Width="0px" />
                                                                                </asp:BoundField>
                                                                            </Columns>
                                                                            <SelectedRowStyle CssClass="pgr" />
                                                                        </asp:GridView>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="chkCopy" runat="server" Text="Copy Data from existing group." OnCheckedChanged="chkCopy_CheckedChanged" AutoPostBack="true" /></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <table id="tblcopy" runat="server" visible="false">
                                                                    <tr>
                                                                        <td>select Paper Code
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddlPpr" runat="server" Width="200px"></asp:DropDownList>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Button ID="btnCopy" runat="server" Text="Copy" OnClick="btnCopy_Click" /></td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <table id="tblstu" runat="server" visible="true">

                                                                    <tr>
                                                                        <th>Select Students for grouping -</th>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                                                                                <ContentTemplate>
                                                                                    <asp:GridView ID="gridStudent" runat="server" AutoGenerateColumns="False" EnableViewState="True"
                                                                                        DataKeyNames="TT_PAP_ID, STU_MAIN_ID">

                                                                                        <Columns>
                                                                                            <asp:TemplateField HeaderText="S.No.">
                                                                                                <ItemTemplate>
                                                                                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle Width="20px" />
                                                                                            </asp:TemplateField>

                                                                                            <asp:BoundField HeaderText="Enrollment No." DataField="ENROLLMENT_NO" />
                                                                                            <asp:BoundField HeaderText="Name" DataField="STU_FULL_NAME" />
                                                                                            <asp:BoundField HeaderText="Current Group" DataField="GRP_VALUE" />
                                                                                            <asp:TemplateField HeaderText="Choose">
                                                                                                <HeaderTemplate>
                                                                                                    <input id="chkAll" onclick="javascript: SelectAllCheckboxes(this);" type="checkbox"
                                                                                                        value="on" runat="server" />All
                                                                                                </HeaderTemplate>
                                                                                                <ItemTemplate>
                                                                                                    <asp:CheckBox ID="chkStudent" runat="server" />
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle Width="20px" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:BoundField HeaderText="Color" DataField="COLOR" Visible="false" />
                                                                                        </Columns>
                                                                                    </asp:GridView>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
                                                                                <ContentTemplate>
                                                                                    <table>
                                                                                        <tr>
                                                                                            <th>Select Group<span class="required">*</span>
                                                                                            </th>
                                                                                            <td>
                                                                                                <asp:DropDownList ID="ddlGroup" runat="server">
                                                                                                </asp:DropDownList>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <th>Active From</th>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtdateGroupActive" runat="server" Width="90px"></asp:TextBox>
                                                                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="txtdateGroupActive"></ajaxToolkit:CalendarExtender>
                                                                                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtdateGroupActive" Mask="99/99/9999"
                                                                                                    MaskType="Date">
                                                                                                </ajaxToolkit:MaskedEditExtender>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Button ID="btnSaveGroup" runat="server" Text="Save" OnClick="btnSaveGroup_Click" />
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
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:WizardStep>
                                    <asp:WizardStep ID="WizardStep4" Title="Report" runat="server" StepType="Finish"
                                        OnActivate="ActivateWizardStep4">
                                        <table class="wizardTable">
                                            <tr>
                                                <td class="wizardStepHeader"> Report
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:UpdatePanel ID="UpdatePanel8" runat="server" UpdateMode="Conditional">
                                                                    <ContentTemplate>
                                                                        <asp:GridView ID="gridPaperCombinationSelect1" runat="server" AutoGenerateColumns="False"
                                                                            EnableViewState="true" ShowHeader="False" DataKeyNames="TT_ID">
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

                                                                            </Columns>
                                                                            <SelectedRowStyle CssClass="pgr" />
                                                                        </asp:GridView>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional">
                                                                    <ContentTemplate>
                                                                        <asp:GridView ID="gridStudent1" runat="server" AutoGenerateColumns="False" EnableViewState="True"
                                                                            DataKeyNames="TT_PAP_ID">

                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="S.No.">
                                                                                    <ItemTemplate>
                                                                                        <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>

                                                                                <asp:BoundField HeaderText="Enroll" DataField="ENROLLMENT_NO" />
                                                                                <asp:BoundField HeaderText="Name" DataField="STU_FULL_NAME" />
                                                                                <asp:BoundField HeaderText="Group" DataField="GRP_VALUE" />
                                                                                <asp:BoundField HeaderText="From Date" DataField="FROM_DATE" DataFormatString="{0:dd/MM/yyyy}" />
                                                                                <asp:BoundField HeaderText="To Date" DataField="TO_DATE" DataFormatString="{0:dd/MM/yyyy}" />
                                                                                <asp:BoundField HeaderText="Color" DataField="COLOR" Visible="false" />
                                                                            </Columns>
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
                                </WizardSteps>
                            </asp:Wizard>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

