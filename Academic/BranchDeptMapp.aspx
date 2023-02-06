<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="BranchDeptMapp.aspx.cs" Inherits="Academic_BranchDeptMapp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript">
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
            if (!CheckControl("<%=ddlInstitute.ClientID%>")) {
                msg += "- Select Institute Name from list\n";
                if (ctrl == "")
                    ctrl = "<%=ddlInstitute.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlCourse.ClientID%>")) {
                msg += "- Select Course Name from list\n";
                if (ctrl == "")
                    ctrl = "<%=ddlCourse.ClientID%>";
                flag = false;
            }

            if (!CheckControl("<%=ddlDept.ClientID%>")) {
                msg += "- Select Department from list\n";
                if (ctrl == "")
                    ctrl = "<%=ddlDept.ClientID%>";
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
            <h2>Branch Department Mapping</h2>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <th>Institute Name<span class="required">*</span>
                                    </th>
                                    <th>Department Name<span class="required">*</span>
                                    </th>
                                    <th>Course Name<span class="required">*</span>
                                    </th>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:DropDownList ID="ddlInstitute" runat="server" Width="120px" AutoPostBack="true" OnSelectedIndexChanged="ddlInstitute_SelectedIndexChanged"></asp:DropDownList>
                                    </td>

                                    <td>
                                        <asp:DropDownList ID="ddlDept" runat="server" Width="160px">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlCourse" runat="server" Width="120px">
                                        </asp:DropDownList></td>
                                    <td>
                                        <asp:Button ID="btnSave" runat="server" Text="Save" Width="70px" OnClick="btnSave_Click" Height="25px" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="gvShow" runat="server" AutoGenerateColumns="False" DataKeyNames="DEPT_PGM_MAP_ID" OnRowCommand="gvShow_RowCommand" Width="100%" EmptyDataText="No Record Avaliable" CssClass="gridDynamic">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No.">
                                        <ItemTemplate>
                                            <%# ((GridViewRow)Container).RowIndex + 1%>
                                .
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Department Name" DataField="DEPT_VALUE" />
                                    <asp:BoundField HeaderText="Course Name" DataField="PGM_FULL_NAME" />
                                    <asp:CommandField ButtonType="Image" SelectImageUrl="~/Siteimages/edit.gif" ShowSelectButton="True" HeaderText="Modify">
                                        <ItemStyle Width="40px" />
                                    </asp:CommandField>
                                    <asp:TemplateField ShowHeader="False" HeaderText="Status">
                                        <ItemStyle Width="20px" HorizontalAlign="Right" />
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="false" CommandArgument='<%# Bind("DEPT_PGM_MAP_ID") %>'
                                                ImageUrl='<%# Bind("STS_IMG") %>' CommandName='<%# Bind("STS_CMD") %>' ToolTip='<%# Bind("STS_TOOLTIP")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

