<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="MentorAssign.aspx.cs" Inherits="Academic_MentorAssign" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script language="javascript" type="text/javascript">
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
           function Pagevalidation() {

             var flag = true;
             var msg = "", ctrl = "";
             if (!CheckAutoComplete("<%=txtEmp.ClientID%>")) {
                msg += " * Enter User Name with Code. \n";
                if (ctrl == "")
                    ctrl = "<%=txtEmp.ClientID%>";
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
            <h2>Assign Mentor</h2>
        </div>
        <ajaxToolkit:TabContainer ID="TabContainer1" runat="server">
            <ajaxToolkit:TabPanel ID="Tab1" runat="server" HeaderText="Assign Mentor">
                <ContentTemplate>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <th>By Institue</th>
                                    <th>By Program</th>
                                    <th>By Branch</th>
                                    <th>By Sem</th>
                                    <th>Section</th>
                                </tr>
                                <tr>
                                    <td><asp:DropDownList ID="ddlIns" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlIns_SelectedIndexChanged"></asp:DropDownList></td>
                                    <td><asp:DropDownList ID="ddlPgm" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPgm_SelectedIndexChanged"></asp:DropDownList></td>
                                    <td><asp:DropDownList ID="ddlBranch" runat="server"></asp:DropDownList></td>
                                   <td><asp:DropDownList ID="ddlSem" runat="server"></asp:DropDownList></td>
                                    <td><asp:DropDownList ID="ddlSec" runat="server"></asp:DropDownList></td>
                                    <td><asp:Button ID="btnView" runat="server" Text="View" OnClick="btnView_Click" /></td>
                                     <td><asp:TextBox ID="txtXML" runat="server" Visible="false"></asp:TextBox></td>
                                </tr>
                            </table>
                            <table>
                                <tr>
                                    <th>Mentor Name<span class="required">*</span></th>
                                     <td><asp:TextBox ID="txtEmp" runat="server"></asp:TextBox></td>
                                     <td><asp:Button ID="btnAssign" runat="server" Text="Assign" OnClick="btnAssign_Click"/></td>
                                </tr>
                                </table>
                            <table>
                                <tr>
                                    <div>
                                        <td><asp:GridView ID="gvMentor" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" DataKeyNames="STU_MAIN_ID">
                                        <Columns>
                                            <asp:TemplateField HeaderText="S.No">
                                                <ItemTemplate>
                                                    <%#((GridViewRow)Container).RowIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="Course" DataField="PGM_SHORT_NAME" />
                                            <asp:BoundField HeaderText="Enrollment No" DataField="ENROLLMENT_NO" />
                                            <asp:BoundField HeaderText="Name" DataField="STU_FULL_NAME" />
                                            <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chk" runat="server" AutoPostBack="true" ToolTip='<%# Bind("STU_MAIN_ID") %>' />
                                                    </ItemTemplate>
                                                    <ItemStyle Width="40px" />
                                                </asp:TemplateField>
                                        </Columns>
                                        </asp:GridView></td>
                                    </div>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" CompletionSetCount="12"
                                                    EnableCaching="true" MinimumPrefixLength="1" ServiceMethod="GetEmployeeList"
                                                    ServicePath="~\AutoComplete.asmx" TargetControlID="txtEmp" ContextKey="1">
                                                </ajaxToolkit:AutoCompleteExtender>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="Modify Mentor">
                <ContentTemplate>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <table>
                                <tr id="trShow" runat="server">
                                    <th>Mentor Name<span class="required">*</span></th>
                                    <td><asp:TextBox ID="txtEmpShow" runat="server"></asp:TextBox></td>
                                    <td><asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" /></td>
                                </tr>
                                <tr id="trAdd" runat="server" visible="false">
                                    <th>Student Name</th>
                                    <td><asp:TextBox ID="txtStu" runat="server"></asp:TextBox></td>
                                    <td><asp:Button ID="btnAdd" runat="server" Text="ADD" OnClick="btnAdd_Click" /></td>
                                </tr>
                                </table>
                            <table>
                                <tr>
                                    <td><asp:GridView ID="gvDetail" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" EmptyDataText="No Record(s) Found" DataKeyNames="STU_MAIN_ID" OnRowDeleting="gvDetail_RowDeleting">
                                        <Columns>
                                            <asp:TemplateField HeaderText="S.No">
                                                <ItemTemplate>
                                                    <%#((GridViewRow)Container).RowIndex + 1 %>
                                                </ItemTemplate>
                                                </asp:TemplateField>
                                            <asp:BoundField HeaderText="Enrollment No" DataField="ENROLLMENT_NO" />
                                            <asp:BoundField HeaderText="Student Name" DataField="STU_FULL_NAME" />
                                            <asp:BoundField HeaderText="Mentor Name" DataField="EMP_NAME" />
                                           <asp:CommandField ButtonType="Button" ShowDeleteButton="true" />
                                        </Columns>
                                        </asp:GridView></td>
                                </tr>
                            </table>
                            <table>
                                <tr>
                                    <td>
                            <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionSetCount="12"
                                                    EnableCaching="true" MinimumPrefixLength="1" ServiceMethod="GetEmployeeList"
                                                    ServicePath="~\AutoComplete.asmx" TargetControlID="txtEmpShow" ContextKey="1">
                                                </ajaxToolkit:AutoCompleteExtender>
                        </td>
                        <td>
                            <ajaxToolkit:AutoCompleteExtender ID="autoComplete2" runat="server" TargetControlID="txtStu" ServicePath="~/AutoComplete.asmx" ServiceMethod="GetStudentList" 
                                MinimumPrefixLength="1" ContextKey="1" CompletionSetCount="12" CompletionInterval="500" DelimiterCharacters="" Enabled="True" UseContextKey="True">
                             </ajaxToolkit:AutoCompleteExtender>
                        </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
        </ajaxToolkit:TabContainer>
    </div>
</asp:Content>

