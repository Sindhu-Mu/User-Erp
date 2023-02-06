<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="StudentAttendanceMis.aspx.cs" Inherits="Academic_StudentAttendanceMis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
        function show_confirm() {
            var r = confirm("You have decided to mark the entries as final. You won't be able any further changes. Do you wish to continue?");
            if (r == true) {
                return true;
            }
            else {
                return false;
            }
        }
    </script>

    <div class="container">
        <div class="heading">
            <h2>Student Attendance </h2>
        </div>
        <div>
            <table>
                <tr>
                    <td>
                        <asp:GridView ID="gridViewData" runat="server" AutoGenerateColumns="False" GridLines="None"
                            CssClass="gridDynamic" SelectedRowStyle-CssClass="pgr">
                            <Columns>
                                <asp:TemplateField HeaderText="S.No.">
                                    <ItemTemplate>
                                        <%# ((GridViewRow)Container).RowIndex + 1%>
                                    </ItemTemplate>
                                    <ItemStyle Width="50px" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="CLS_VALUE" HeaderText="Class Name">
                                    <ItemStyle Width="150px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ACA_SEM_ID" HeaderText="Semester">
                                    <ItemStyle Width="80px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="PAPER" HeaderText="Paper Code(s)">
                                    <ItemStyle Width="150px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="GRP_VALUE" HeaderText="Group">
                                    <ItemStyle Width="80px" />
                                </asp:BoundField>
                                 <asp:BoundField DataField="CLS_DATE" HeaderText="Date">
                                    <ItemStyle Width="100px" />
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table>
                            <tr>
                                <td style="text-align: center; color: brown"><b>SELECT ONLY ABSENT STUDENT FORM LIST AND<br />
                                    CLICK SUBMIT TO MARK ATTENDANCE.</b></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="gridStudentData" runat="server" AutoGenerateColumns="False" GridLines="None"
                                        CssClass="gridDynamic" DataKeyNames="TT_DET_ID,STU_MAIN_ID"
                                        HWidth="96%" SelectedRowStyle-CssClass="pgr">
                                        <Columns>
                                            <asp:TemplateField HeaderText="S.No.">
                                                <ItemTemplate>
                                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                                    .
                                                </ItemTemplate>
                                                <ItemStyle Width="20px" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="ENROLLMENT_NO" HeaderText="ENROLLMENT NO."></asp:BoundField>
                                            <asp:BoundField DataField="STU_FULL_NAME" HeaderText="STUDENT NAME"></asp:BoundField>
                                            <asp:BoundField DataField="PROGRAM" HeaderText="COURSE"></asp:BoundField>

                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <input id="chkAll" onclick="javascript: SelectAllCheckboxes(this);" type="checkbox"
                                                        value="on" runat="server" />All
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkAttendance" runat="server" />
                                                </ItemTemplate>
                                                <ItemStyle Width="20px" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <SelectedRowStyle CssClass="pgr" />
                                        <AlternatingRowStyle CssClass="alt" />
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClientClick="return show_confirm()"
                                         Enabled="False" OnClick="btnSave_Click" /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

