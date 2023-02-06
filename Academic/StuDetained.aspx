<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="StuDetained.aspx.cs" Inherits="Academic_StuDetained" %>

<%@ Register Src="~/Control/Student.ascx" TagPrefix="uc1" TagName="Student" %>

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
        function Validate() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckAutoComplete("<%=txtEnroll.ClientID%>")) {
                msg += " * Enter Name with Enrollment. \n";
                if (ctrl == "")
                    ctrl = "<%=txtEnroll.ClientID%>";
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
            <h2>Student Detained</h2>
        </div>
        <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td style="padding-left: 300px">
                                <table>
                                    <tr>
                                        <th>Enrollment No<span class="required">*</span></th>
                                        <td >
                                            <asp:TextBox ID="txtEnroll" runat="server" Width="270px" placeholder="Enrollment No"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <uc1:Student ID="Student" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="gvCourse" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" OnRowCommand="gvCourse_RowCommand">
                                    <Columns>
                                        <asp:TemplateField HeaderText="S.No">
                                            <ItemTemplate>
                                                <%#((GridViewRow)Container).RowIndex +1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Course Code" DataField="EVA_SCH_PAPER_CODE" />
                                        <asp:BoundField HeaderText="Course Name" DataField="ACA_SUB_NAME" />
                                        <asp:BoundField HeaderText="Class Held" DataField="HELD" />
                                        <asp:BoundField HeaderText="Present" DataField="PRESENT" />
                                        <asp:BoundField HeaderText="Medical" DataField="MEDICAL" />
                                        <asp:BoundField HeaderText="Extra" DataField="EXTRA" />
                                        <asp:BoundField HeaderText="Att(%)" DataField="PER" />
                                        <asp:TemplateField ShowHeader="False" HeaderText="Status">
                                            <ItemStyle Width="20px" HorizontalAlign="Right" />
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="false" CommandArgument='<%# Bind("ATT_ID") %>'
                                                    ImageUrl='<%# Bind("STS_IMG") %>' CommandName='<%# Bind("STS_CMD") %>' ToolTip='<%# Bind("STS_TOOLTIP")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <ajaxToolkit:AutoCompleteExtender ID="autoComplete2" runat="server" TargetControlID="txtEnroll" ServicePath="~/AutoComplete.asmx" ServiceMethod="GetStudentList"
                                    MinimumPrefixLength="1" ContextKey="1" CompletionSetCount="12" CompletionInterval="500" DelimiterCharacters="" Enabled="True" UseContextKey="True">
                                </ajaxToolkit:AutoCompleteExtender>
                            </td>
                        </tr>
                    </table>

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

