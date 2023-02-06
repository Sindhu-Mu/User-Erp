<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="MissingStudentAttendance.aspx.cs" Inherits="Academic_MissingStudentAttendance" %>

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
            <h2>Missing Student Report </h2>
        </div>
        <div>
            <table>
                <tr>
                    <td>
                        <table>
                            <tr>
                                <td>
                                    <div>
                                        <asp:GridView ID="gridAttClsNamePerSummary" runat="server" AutoGenerateColumns="false"
                                            CssClass="gridDynamic" DataKeyNames="STU_MAIN_ID, TT_PAP_ID" Width="100%"
                                            OnRowCommand="gridAttClsNamePerSummary_RowCommand">
                                            <Columns>
                                                <asp:TemplateField HeaderText="S.No.">
                                                    <ItemTemplate>
                                                        <%# ((GridViewRow)Container).RowIndex + 1%>
                                                .
                                                    </ItemTemplate>
                                                    <ItemStyle Width="20px" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="CLS_VALUE" HeaderText="Class" />
                                                <asp:BoundField DataField="ACA_SEM_ID" HeaderText="Sem" />
                                                <asp:BoundField DataField="SEC_ID" HeaderText="Section" />
                                                <asp:BoundField DataField="GRP_VALUE" HeaderText="Group" />
                                                <asp:BoundField DataField="CLS_TYPE_VALUE" HeaderText="Class Type" />
                                                <asp:BoundField DataField="PAPER_CODES" HeaderText="Paper Code" />
                                                <asp:BoundField DataField="ENROLLMENT_NO" HeaderText="Enrollment#" />
                                                <asp:BoundField DataField="STU_FULL_NAME" HeaderText="Name" />
                                                <asp:CommandField ButtonType="Button" SelectText="Mark" ShowSelectButton="true" />
                                                <%--<asp:TemplateField>
                                                    <ItemTemplate>
                                                        <a id="link" href="javascript:mark('<%#Eval("LINK")%>');" runat="server">Mark</a>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                            </Columns>
                                            <SelectedRowStyle BackColor="#ffff99" />
                                        </asp:GridView>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table id="tb1" runat="server" visible="false">
                            <tr>
                                <td>
                                    <table>
                                        <tr>
                                            <td style="font-weight: bold; color: red; text-align: center">Select only the days, the student is absent
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <hr style="color: #ff8c00; width: 100%; height: 0px; border-bottom-color: red; border-bottom-width: 1px; border-collapse: collapse; border-spacing: 0px;" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table>
                                        <tr>
                                            <td>
                                                <div>
                                                    <asp:GridView ID="gridStudentData" runat="server" AutoGenerateColumns="false"
                                                        CssClass="gridDynamic" DataKeyNames="TT_DET_ID,STU_MAIN_ID" Width="100%"
                                                        SelectedRowStyle-CssClass="pgr">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S.No.">
                                                                <ItemTemplate>
                                                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                                .
                                                                </ItemTemplate>
                                                                <ItemStyle Width="10px" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="CLS_DATE" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Date" />
                                                            <asp:BoundField DataField="TT_SLOT_VALUE" HeaderText="Time Slot" />
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
                                                    </asp:GridView>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Button ID="btnSave" runat="server" Text="Save" OnClientClick="return show_confirm()" OnClick="btnSave_Click" /></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

