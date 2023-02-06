<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="StuDocIssue.aspx.cs" Inherits="Academic_StuDocIssue" %>

<%@ Register Src="~/Control/Student.ascx" TagPrefix="uc1" TagName="Student" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script lang="javascript" type="text/javascript">
        function CheckControl(ctrl) {
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == "Select" || bTrim(document.getElementById(ctrl).value) == ".") {
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
        function Validat() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=ddlDoc.ClientID%>")) {
                msg += " * Select Document form list. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlDoc.ClientID%>";
                flag = false;
            }
            if (!CheckAutoComplete("<%=txtEmp.ClientID%>")) {
                msg += " * Enter Name & cdoe of employee. \n";
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
            <h2>Document Issue</h2>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <td align="right">
                            <table>
                                <tr style="text-align: left;">
                                    <th>Enrollment No<span class="required">*</span></th>
                                    <td>
                                        <asp:TextBox ID="txtEnroll" runat="server" Width="250px"></asp:TextBox></td>
                                    <td>
                                        <asp:Button ID="btnShow" runat="server" Text="show" OnClick="btnShow_Click" />
                                    </td>
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
                        <td>
                            <asp:GridView ID="gvDoc" runat="server" Caption="Issued Document Deatil" AutoGenerateColumns="false" CssClass="gridDynamic">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No">
                                        <ItemTemplate>
                                            <%#((GridViewRow)Container).RowIndex +1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Document Name" DataField="DOC_NAME" />
                                    <asp:BoundField HeaderText="Issue Date" DataField="DOC_ISSUE_DT" />
                                    <asp:BoundField HeaderText="Sign By" DataField="DOC_SIGN_BY" />
                                    <asp:BoundField HeaderText="Issue By" DataField="EMP_NAME" />
                                    <asp:BoundField HeaderText="Remark" DataField="DOC_ISSUE_REMARK" />
                                    <asp:BoundField HeaderText="Type" DataField="ISSUE_TYPE" />
                                    <asp:TemplateField HeaderText="Print">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Bind("LINK") %>'
                                                Text="Re-Print" Target="_blank"></asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <th>Document Name<span class="required">*</span></th>
                                    <th>Sign By<span class="required">*</span></th>
                                    <th>Remark</th>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:DropDownList ID="ddlDoc" runat="server" Width="100px"></asp:DropDownList></td>
                                    <td>
                                        <asp:TextBox ID="txtEmp" runat="server" Width="200px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtRemark" runat="server" Width="300px"></asp:TextBox></td>
                                    <td>
                                        <asp:Button ID="btnIssue" runat="server" OnClick="btnIssue_Click" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <ajaxToolkit:AutoCompleteExtender ID="AutoComplete1" runat="server" EnableCaching="true"
                                TargetControlID="txtEmp" ServicePath="~/AutoComplete.asmx" ServiceMethod="GetEmployeeList"
                                MinimumPrefixLength="1" ContextKey="1" CompletionSetCount="12" CompletionInterval="500">
                            </ajaxToolkit:AutoCompleteExtender>
                            <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionInterval="500"
                                CompletionSetCount="12" ContextKey="1,2,3,4,5,6" EnableCaching="true" MinimumPrefixLength="1"
                                ServiceMethod="GetStudentList" ServicePath="~\AutoComplete.asmx" TargetControlID="txtEnroll">
                            </ajaxToolkit:AutoCompleteExtender>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

