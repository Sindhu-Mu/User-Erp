<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="MajorMarks.aspx.cs" Inherits="Academic_MajorMarks" %>

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
        function validation() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=txtEnroll.ClientID%>")) {
                msg += " * Enter Enrollment No. \n";
                if (ctrl == "")
                    ctrl = "<%=txtEnroll.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtMarks.ClientID%>")) {
                msg += " * Enter Marks \n";
                if (ctrl == "")
                    ctrl = "<%=txtMarks.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlPaper.ClientID%>")) {
                msg += " * Select Paper Code \n";
                if (ctrl == "")
                    ctrl = "<%=ddlPaper.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlExam.ClientID%>")) {
                msg += " * Select Examination \n";
                if (ctrl == "")
                    ctrl = "<%=ddlExam.ClientID%>";
                flag = false;
            }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }

        function validationSave() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckAutoComplete("<%=txtExaminor.ClientID%>")) {
                msg += " * Enter Examiner \n";
                if (ctrl == "")
                    ctrl = "<%=txtExaminor.ClientID%>";
                flag = false;
            }
           
            
            if (!CheckControl("<%=ddlExam.ClientID%>")) {
                msg += " * Select Examination \n";
                if (ctrl == "")
                    ctrl = "<%=ddlExam.ClientID%>";
                flag = false;
            }
            if (!CheckAutoComplete("<%=txtScrut.ClientID%>")) {
                msg += " * Enter Scrutinizer \n";
                if (ctrl == "")
                    ctrl = "<%=txtScrut.ClientID%>";
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
            <h2>Major Marks
            </h2>
            <div>
                <table>
                    <tr>
                        <th>Institute
                        </th>
                        <th>Program
                        </th>
                        <th>Branch
                        </th>
                        <th>Semester
                        </th>
                        <th>Paper Code
                        </th>
                        <th>Weightage
                        </th>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="ddlIns" runat="server" OnSelectedIndexChanged="ddlIns_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlPrgm" runat="server" OnSelectedIndexChanged="ddlPrgm_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlBranch" runat="server"></asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlSem" runat="server" OnSelectedIndexChanged="ddlSem_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlPaper" runat="server" ></asp:DropDownList>
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rbWeightage" runat="server" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0" Width="80px">
                                <asp:ListItem Text="100%" Value="100"></asp:ListItem>
                                <asp:ListItem Text="80%" Value="80"></asp:ListItem>
                                <asp:ListItem Text="50%" Value="50" Selected="True"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <th colspan="3">Examination</th>
                        <th>Enrollment No.</th>
                        <th>Marks</th>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:DropDownList ID="ddlExam" runat="server"></asp:DropDownList>
                        </td>
                        <td>
                            <asp:TextBox ID="txtEnroll" runat="server"></asp:TextBox>

                        </td>

                        <td>
                            <cc1:NumericTextBox ID="txtMarks" runat="server" AllowNegative="false" AllowDecimal="true"></cc1:NumericTextBox>
                        <td>
                            <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            <div>
                                <asp:GridView ID="gvDetail" runat="server" AutoGenerateColumns="false" DataKeyNames="STU_MAIN_ID,EVA_SCH_SUB_ID" CssClass="gridDynamic" OnRowDeleting="gvDetail_RowDeleting">
                                    <Columns>
                                        <asp:TemplateField HeaderText="S.No.">
                                            <ItemTemplate>
                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                                        .
                                            </ItemTemplate>
                                            <ItemStyle Width="15px" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="ENROLLMENT_NO" HeaderText="Enrollment No." />
                                        <asp:BoundField DataField="STU_FULL_NAME" HeaderText="Student Name" />
                                        <asp:BoundField DataField="MARKS" HeaderText="Marks" />
                                        <asp:BoundField DataField="WEIGHTAGE_MARKS" HeaderText="Weightage Marks" />
                                         <asp:CommandField ShowDeleteButton="true" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <th>Examiner</th>
                        <td>
                            <asp:TextBox ID="txtExaminor" runat="server"></asp:TextBox>
                            <ajaxToolkit:AutoCompleteExtender ID="autoComplete1" runat="server" CompletionInterval="500"
                                            CompletionSetCount="12" ContextKey="1" EnableCaching="true" MinimumPrefixLength="1"
                                            ServiceMethod="GetEmployeeList" ServicePath="~\AutoComplete.asmx" TargetControlID="txtExaminor">
                                        </ajaxToolkit:AutoCompleteExtender>
                        </td>
                        <th>
                            Scrutinizer
                        </th>
                        <td>
                            <asp:TextBox ID="txtScrut" runat="server"></asp:TextBox>
                            <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionInterval="500"
                                            CompletionSetCount="12" ContextKey="1" EnableCaching="true" MinimumPrefixLength="1"
                                            ServiceMethod="GetEmployeeList" ServicePath="~\AutoComplete.asmx" TargetControlID="txtScrut">
                                        </ajaxToolkit:AutoCompleteExtender>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6" style="text-align: right">
                            <asp:Label ID="lblMsg" runat="server" Visible="false"></asp:Label>
                            <asp:Button ID="btnSave" runat="server" Text="Save" Visible="false" OnClick="btnSave_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="TextBox1" runat="server" Visible="false"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>

