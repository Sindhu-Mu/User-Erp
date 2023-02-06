<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="SpecialMinor.aspx.cs" Inherits="Academic_SpecialMinor" %>

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
            <h2>Special Minor</h2>
        </div>
        <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td align="right">
                                <table>
                                    <tr>

                                        <td>
                                            <asp:TextBox ID="txtEnroll" runat="server" Width="270px" placeholder="Name & Enrollment No"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" /></td>
                                    </tr>

                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <uc1:Student runat="server" ID="Student" />
                            </td>
                        </tr>
                        <tr>

                            <th>Paper Code: 
                            <asp:DropDownList ID="ddlPaper" runat="server" OnSelectedIndexChanged="ddlPaper_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></th>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="gvMinor" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" DataKeyNames="EXAM_TYPE_SUB_ID">
                                    <Columns>
                                        <asp:TemplateField HeaderText="S.No">
                                            <ItemTemplate>
                                                <%#((GridViewRow)Container).RowIndex + 1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Enrollment No" DataField="ENROLLMENT_NO" />
                                        <asp:BoundField HeaderText="Student Name" DataField="STU_FULL_NAME" />
                                        <asp:BoundField HeaderText="Prgoram" DataField="PGM_SHORT_NAME" />
                                        <asp:BoundField HeaderText="Exam Type" DataField="EXAM_TYPE_SUB_DESC" />
                                        <asp:BoundField HeaderText="Paper Code" DataField="EVA_SCH_PAPER_CODE" />
                                        <asp:TemplateField HeaderText="Attendance">
                                            <ItemTemplate>
                                                <asp:RadioButtonList ID="AttList" Width="150px" runat="server" CellPadding="0" CellSpacing="0" RepeatDirection="Horizontal">
                                                    <asp:ListItem Selected="True" Value="1">Present</asp:ListItem>
                                                    <asp:ListItem Value="0">Absent</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Marks" ItemStyle-Width="100px">
                                            <ItemTemplate>
                                                <cc1:NumericTextBox ID="txtMarks" runat="server" AllowDecimal="true" AllowNegative="false" MaxLength="4" DecimalPlaces="1" AutoCompleteType="None" Width="80px" placeholder="Marks"></cc1:NumericTextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" Visible="false" />
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

