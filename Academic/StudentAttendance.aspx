<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="StudentAttendance.aspx.cs" Inherits="Academic_StudentAttendance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="heading">
            <h2>Student Attendance</h2>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table>
                    <tr>
                        <td>
                            <asp:Wizard ID="timeTableWizard" runat="server" ActiveStepIndex="1"
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
                                    <asp:WizardStep ID="WizardStep1" runat="server" StepType="Start" Title="Select Details">
                                        <table class="wizardTable">
                                            <tr>
                                                <td>
                                                    <table style="width: 100%">
                                                        <tr>
                                                            <th>Institute</th>
                                                            <td>
                                                                <asp:DropDownList ID="ddlInstitute" runat="server" Width="120px" AutoPostBack="true" OnSelectedIndexChanged="ddlInstitute_SelectedIndexChanged"></asp:DropDownList></td>
                                                        </tr>
                                                        <tr>
                                                            <th>Course</th>
                                                            <td>
                                                                <asp:DropDownList ID="ddlCourse" runat="server" Width="120px" AutoPostBack="true" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged"></asp:DropDownList></td>

                                                        </tr>
                                                        <tr>
                                                            <th>Branch</th>
                                                            <td>
                                                                <asp:DropDownList ID="ddlBranch" runat="server" Width="120px" AutoPostBack="true" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged"></asp:DropDownList></td>
                                                        </tr>
                                                        <tr>
                                                            <th>Batch</th>
                                                            <td>
                                                                <asp:DropDownList ID="ddlBatch" runat="server" Width="120px" AutoPostBack="true" OnSelectedIndexChanged="ddlBatch_SelectedIndexChanged"></asp:DropDownList></td>
                                                        </tr>
                                                        <tr>
                                                            <th>Semester</th>
                                                            <td>
                                                                <asp:DropDownList ID="ddlSemester" runat="server" Width="120px" AutoPostBack="true" OnSelectedIndexChanged="ddlSemester_SelectedIndexChanged"></asp:DropDownList></td>
                                                        </tr>
                                                        <tr>
                                                            <th>Paper Code</th>
                                                            <td>
                                                                <asp:DropDownList ID="ddlPaper" runat="server" Width="120px"></asp:DropDownList></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:WizardStep>

                                    <asp:WizardStep ID="WizardStep2" runat="server" StepType="Start" Title="Mark Attendance" OnActivate="ActivateWizard1">
                                        <table class="wizardTable">
                                            <tr>
                                                <td>
                                                    <table style="width: 100%">
                                                        <tr>
                                                            <td>Date</td>
                                                            <td>
                                                                
                                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate"
                                                                    Format="dd/MM/yyyy" PopupPosition="TopLeft">
                                                                </ajaxToolkit:CalendarExtender>
                                                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1"  runat="server" Mask="99/99/9999" MaskType="Date"
                                                                    TargetControlID="txtDate">
                                                                </ajaxToolkit:MaskedEditExtender>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Time slot&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlSlot" runat="server" Width="120px"></asp:DropDownList></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                                                        <ContentTemplate>
                                                            <asp:GridView ID="gridStudent" runat="server" CssClass="gridDynamic" AutoGenerateColumns="False" EnableViewState="True" DataKeyNames="STU_MAIN_ID" Width="100%">

                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="S.No.">
                                                                        <ItemTemplate>
                                                                            <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Width="20px" />
                                                                    </asp:TemplateField>

                                                                    <asp:BoundField HeaderText="Enrollment No." DataField="ENROLLMENT_NO" />
                                                                    <asp:BoundField HeaderText="Name" DataField="STU_FULL_NAME" />
                                                                    <asp:BoundField HeaderText="Group" DataField="GRP_VALUE" />
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
                                                                </Columns>
                                                            </asp:GridView>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr><td>
                                                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" /></td></tr>
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

