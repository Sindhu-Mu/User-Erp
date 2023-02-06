<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="StudentSts.aspx.cs" Inherits="Academic_StudentSts" %>
<%@ Register Src="~/Control/Student.ascx" TagPrefix="uc1" TagName="Student" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
            <h2>Student Status Change</h2>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <th>Enrollemnt No<span class="required">*</span></th>
                        <td style="width: 164px; height: 22px; float: left">
                            <asp:TextBox ID="txtEnroll" runat="server" Width="270px"></asp:TextBox>
                        </td>
                        <td><asp:Button ID="btnShow" runat="server" Text ="Show" OnClick="btnShow_Click" /></td>
                    </tr>
                    <tr>
                        <td>
                            <ajaxToolkit:AutoCompleteExtender ID="autoComplete2" runat="server" TargetControlID="txtEnroll" ServicePath="~/AutoComplete.asmx" ServiceMethod="GetStudentList" 
                                MinimumPrefixLength="1" ContextKey="1,2,3,4,5,6" CompletionSetCount="12" CompletionInterval="500" DelimiterCharacters="" Enabled="True" UseContextKey="True">
                             </ajaxToolkit:AutoCompleteExtender>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <uc1:Student ID="Student" runat="server" />
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>
                            <asp:GridView ID="gvSts" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic">
                                <Columns>
                                     <asp:TemplateField HeaderText="S.No">
                                        <ItemTemplate>
                                            <%#((GridViewRow)Container).RowIndex +1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Student" DataField="STU_FULL_NAME" />
                                    <asp:BoundField HeaderText="Status" DataField="STU_STS_VALUE" />
                                    <asp:BoundField HeaderText="From Dt" DataField="STS_FROM_DT" DataFormatString="{0:dd/MM/yyyy}" />
                                    <asp:BoundField HeaderText="Change By" DataField="EMP_NAME" />
                                    <asp:BoundField HeaderText="Remark" DataField="STS_TRAN_REMARK" />
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <th><u>Modify Status</u></th>
                    </tr>
                    <tr>
                        <th>Status:</th>
                        <td><asp:DropDownList ID="ddlSts" runat="server" AutoPostBack="True"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <th>From Date:</th>
                        <td><asp:TextBox ID="txtDt" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <th>Reason:</th>
                        <td><asp:TextBox ID="txtRemark" runat="server" TextMode="MultiLine"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td><asp:Button ID="btnModify" runat="server" Text="Modify" OnClick="btnModify_Click" /></td>
                    </tr>
                    <tr>
                        <td>
                            <ajaxToolkit:CalendarExtender ID="cde1" runat="server" Format="dd/MM/yyyy" TargetControlID="txtDt">
                                                                        </ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

