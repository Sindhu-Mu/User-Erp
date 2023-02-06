<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="rptStuAttHOD.aspx.cs" Inherits="Academic_rptStuAttHOD" %>

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
        function validation() {

            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=ddlDept.ClientID%>")) {
                 msg += "- Select Department from list\n";
                 if (ctrl == "")
                     ctrl = "<%=ddlDept.ClientID%>";
                flag = false; 9
            }
            
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }
    </script>
    <div class="container">
        <div class="heading">
            <h2>Class Attendance
            </h2>
        </div>
        <div>
            <table>
                <tr>
                    <td>
                        <table>
                            <tr>
                                <th>Department<span class="required">*</span>
                                </th>
                                <th>Program
                                </th>
                                <th>Branch
                                </th>
                                <th>Semester
                                </th>

                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlDept" runat="server" OnSelectedIndexChanged="ddlDept_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlPgm" runat="server" OnSelectedIndexChanged="ddlPgm_SelectedIndexChanged" AutoPostBack="true">
                                        <asp:ListItem Value="." Text="Select"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlBrnch" runat="server">
                                        <asp:ListItem Value="." Text="Select"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlSem" runat="server"></asp:DropDownList>
                                </td>

                                <td>
                                    <asp:Button ID="btnView" runat="server" Text="View" OnClick="btnView_Click" />
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
                                    <asp:GridView ID="gvClassDetail" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" DataKeyNames="CLS_ID,DEPT_ID,INS_PGM_ID,PGM_BRN_ID" OnRowCommand="gvClassDetail_RowCommand">
                                        <Columns>
                                            <asp:TemplateField HeaderText="S.No.">
                                                <ItemTemplate>
                                                    <%# ((GridViewRow)Container).RowIndex + 1%>.
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="CLS_VALUE" HeaderText="Class Name" />
                                            <asp:BoundField DataField="PGM_SHORT_NAME" HeaderText="Program" /> 
                                            <asp:BoundField DataField="BRN_SHORT_NAME" HeaderText="Branch" /> 
                                            <asp:BoundField DataField="ACA_SEM_ID" HeaderText="Semester" />
                                            <asp:CommandField ButtonType="Button" HeaderText="Faculty" ShowSelectButton="True" />
                                            <asp:ButtonField ButtonType="Button" CommandName="Student" HeaderText="Student" Text="Student" />
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>

                    </td>
                </tr>
                <tr id="trFaculty" runat="server">
                    <td>
                        <asp:GridView ID="gvFaculty" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic">
                            <Columns>
                                <asp:TemplateField HeaderText="S.No.">
                                    <ItemTemplate>
                                        <%# ((GridViewRow)Container).RowIndex + 1%>.
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Emp.Code" DataField="USR_LOGIN_ID" />
                                <asp:BoundField HeaderText="Name" DataField="EMP_NAME" />
                                <asp:BoundField HeaderText="Department" DataField="DEPT_VALUE" />
                                <asp:BoundField HeaderText="Course Code" DataField="COURSE_CODE" />
                                <asp:BoundField HeaderText="Held" DataField="HELD" />
                                <asp:BoundField HeaderText="Marked" DataField="MARKED" />
                                <asp:BoundField HeaderText="Block" DataField="BLOCK" />
                                <asp:BoundField HeaderText="Not Marked" DataField="NOT_MARKED" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr id="trStudent" runat="server">
                    <td>
                        <asp:GridView ID="gvStudent" runat="server" CssClass="gridDynamic" AutoGenerateColumns="false" EnableViewState="false" EmptyDataText="No records found">
                            <Columns>
                                <asp:TemplateField HeaderText="S.No.">
                                    <ItemTemplate>
                                        <%# ((GridViewRow)Container).RowIndex + 1%>.
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Enroll" DataField="ENROLLMENT_NO">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Roll No." DataField="SEM_ROLL_NO">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Name" DataField="STU_FULL_NAME">
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

