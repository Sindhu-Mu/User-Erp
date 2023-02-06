<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="StudentClassAttendance.aspx.cs" Inherits="Academic_StudentAttandence" %>

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
            <h2>Student Attandencee</h2>
        </div>

        <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div style="float: right;">
                        <table>
                            <tr>
                                <th>Enrollemnt No.<span class="required">*</span></th>
                                <td style="width: 164px; height: 22px; float: left">
                                    <asp:TextBox ID="txtEnroll" runat="server" Width="270px"></asp:TextBox>

                                </td>
                                <td>
                                    <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" /></td>
                            </tr>


                        </table>

                    </div>
                    <div class="cleaner"></div>
                    <div>
                        <uc1:Student runat="server" ID="Student" />
                        <ajaxToolkit:AutoCompleteExtender ID="autoComplete2" runat="server" TargetControlID="txtEnroll" ServicePath="~/AutoComplete.asmx" ServiceMethod="GetStudentList"
                            MinimumPrefixLength="1" ContextKey="1,2,3,4,5,6" CompletionSetCount="12" CompletionInterval="500" DelimiterCharacters="" Enabled="True" UseContextKey="True">
                        </ajaxToolkit:AutoCompleteExtender>
                    </div>
                    <div>
                        <asp:GridView ID="gvStuAtt" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic">
                            <Columns>
                                <asp:TemplateField HeaderText="S.No.">
                                    <ItemTemplate>
                                        <%#((GridViewRow)Container).RowIndex +1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Paper Code" DataField="EVA_SCH_PAPER_CODE">
                                    <ItemStyle Width="90px" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Subject Name" DataField="ACA_SUB_NAME" />
                                <asp:BoundField HeaderText="Held" DataField="HELD" ItemStyle-HorizontalAlign="Center">
                                    <ItemStyle Width="80px" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Present" DataField="PRESENT" ItemStyle-HorizontalAlign="Center">
                                    <ItemStyle Width="80px" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Percentage" DataField="PERC" ItemStyle-HorizontalAlign="Center" />

                            </Columns>
                        </asp:GridView>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

    </div>
</asp:Content>

