<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="StuDataForm.aspx.cs" Inherits="Academic_StuDataForm" %>

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
            <h2>Student Data Form</h2>
        </div>
        <div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                    <table>
                        <tr>
                            <th>By Enrollment</th>
                            <th>By Batch</th>
                            <th>By Institute</th>

                            <th>By Program</th>
                            <th>By Branch</th>
                            <th>By Semester</th>
                            <th>By Section</th>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtEnroll" runat="server" Width="150px"></asp:TextBox></td>
                            <td>
                                <asp:DropDownList ID="ddlBatch" runat="server"></asp:DropDownList></td>
                            <td>
                                <asp:DropDownList ID="ddlIns" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlIns_SelectedIndexChanged"></asp:DropDownList></td>
                            <td>
                                <asp:DropDownList ID="ddlPgm" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPgm_SelectedIndexChanged"></asp:DropDownList></td>
                            <td>
                                <asp:DropDownList ID="ddlBrn" runat="server" AutoPostBack="True"></asp:DropDownList></td>
                            <td>
                                <asp:DropDownList ID="ddlSem" runat="server" AutoPostBack="True"></asp:DropDownList></td>
                            <td>
                                <asp:DropDownList ID="ddlSec" runat="server" AutoPostBack="True"></asp:DropDownList>
                            </td>
                            <td>
                                <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" /></td>
                            <td>
                                <asp:Button ID="btnPrint" runat="server" Text="Print" OnClick="btnPrint_Click" /></td>
                        </tr>
                        <tr>
                            <td>
                                <ajaxToolkit:AutoCompleteExtender ID="autoComplete2" runat="server" TargetControlID="txtEnroll" ServicePath="~/AutoComplete.asmx" ServiceMethod="GetStudentList"
                                    MinimumPrefixLength="1" ContextKey="1" CompletionSetCount="12" CompletionInterval="500" DelimiterCharacters="" Enabled="True" UseContextKey="True">
                                </ajaxToolkit:AutoCompleteExtender>
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="overflow:auto;max-height:400px;">
                    <asp:GridView ID="gvDetail" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" DataKeyNames="STU_MAIN_ID">
                        <Columns>
                            <asp:TemplateField HeaderText="S.No">
                                <ItemTemplate>
                                    <%#((GridViewRow)Container).RowIndex +1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Enrollment" DataField="ENROLLMENT_NO" />
                            <asp:BoundField HeaderText="Name" DataField="STU_FULL_NAME" />
                            <asp:BoundField HeaderText="Program" DataField="PGM_FULL_NAME" />
                            <asp:BoundField HeaderText="Semester" DataField="ACA_SEM_NO" />
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <input id="chkAll" onclick="javascript: SelectAllCheckboxes(this);" type="checkbox"
                                        value="on" runat="server" />All
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="ChkBox" runat="server" />
                                </ItemTemplate>
                                <ItemStyle Width="20px" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </di>
            </ContentTemplate>
        </asp:UpdatePanel>
            </div>
    </div>
</asp:Content>

