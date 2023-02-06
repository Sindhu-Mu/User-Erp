<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Short.master" AutoEventWireup="true" CodeFile="IssueMaster.aspx.cs" Inherits="IssueTracking_IssueMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentHolder1" Runat="Server">
    <script lang ="javascript" type="text/javascript">

        function CheckControl(ctrl) {
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == "." || bTrim(document.getElementById(ctrl).value) == "Select") {
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
                return false;
            }
            else
                document.getElementById(ctrl).style.backgroundColor = "#fff";
            return true;
        }

        function validateDept() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=ddlIssueCat.ClientID%>")) {
                msg += "- Select Issue Category.\n";
                if (ctrl == "")
                    ctrl = "<%=ddlIssueCat.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtIssueDept.ClientID%>")) {
                msg += "- Enter Issue Department.\n";
                if (ctrl == "")
                    ctrl = "<%=txtIssueDept.ClientID%>";
                flag = false;
            }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }
        function validateSolution()
        {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=txtDept.ClientID%>"))
            {
                msg += "- Enter Department.\n";
                if (ctrl == "")
                    ctrl = "<%=txtDept.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlSolDept.ClientID%>")) {
                msg += "- Select Solution Department.\n";
                if (ctrl == "")
                    ctrl = "<%=ddlSolDept.ClientID%>";
                flag = false;
            }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }
        function validateArea()
        {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=ddlIssueDept.ClientID%>")) {
                msg += "- Select Issue Department.\n";
                if (ctrl == "")
                    ctrl = "<%=ddlIssueDept.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtIssueArea.ClientID%>")) {
                msg += "- Enter Issue Area.\n";
                if (ctrl == "")
                    ctrl = "<%=txtIssueArea.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlDept.ClientID%>")) {
                msg += "- Select Department.\n";
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
            <h2>Issue Tracking Main</h2>
        </div>
        <table>
            <tr>
                <td>
                    <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" AutoPostBack="true" ActiveTabIndex="2">
                        <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="Issue Department">
                            <ContentTemplate>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <table>
                                            <tr>
                                                <th>Issue Category<span class="required">*</span></th>
                                                <th>Issue Department<span class="required">*</span></th>
                                            </tr>
                                            <tr>
                                                <td><asp:DropDownList ID="ddlIssueCat" runat="server"></asp:DropDownList></td>
                                                <td><asp:TextBox ID="txtIssueDept" runat="server"></asp:TextBox></td>
                                                <td><asp:Button ID="btnAdd" runat="server" Text="ADD" OnClick="btnAdd_Click" /></td>
                                            </tr>
                                        </table>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:GridView ID="gvIssueDept" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" DataKeyNames="HEAD_ID" OnRowCommand="gvIssueDept_RowCommand">
                                                       <Columns>
                                                         <asp:TemplateField HeaderText="S.No.">
                                                          <ItemTemplate>
                                                          <%# ((GridViewRow)Container).RowIndex + 1%>
                                .                         </ItemTemplate>
                                                     </asp:TemplateField>
                                            <asp:BoundField HeaderText="Issue Department" DataField="HEAD_VALUE" />
                                            <asp:CommandField ButtonType="Image" SelectImageUrl="~/Siteimages/edit.gif" ShowSelectButton="True" HeaderText="Modify">
                                                        <ItemStyle Width="40px" />
                                                        </asp:CommandField>
                                                        <asp:TemplateField ShowHeader="False" HeaderText="Status">
                                                         <ItemStyle Width="20px" HorizontalAlign="Right" />
                                                         <ItemTemplate>
                                                         <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="false" CommandArgument='<%# Bind("HEAD_ID") %>'
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
                            </ContentTemplate>
                        </ajaxToolkit:TabPanel>
                        <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="Issue Solution Dept">
                            <ContentTemplate>
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <table>
                                            <tr>
                                                <th>Issue Solution Dept<span class="required">*</span></th>
                                                <th>Solution Department<span class="required">*</span></th>
                                            </tr>
                                            <tr>
                                                <td><asp:TextBox ID="txtDept" runat="server"></asp:TextBox></td>
                                                <td><asp:DropDownList ID="ddlSolDept" runat="server"></asp:DropDownList></td>
                                                <td><asp:Button ID="btnSolAdd" runat="server" Text="ADD" OnClick="btnSolAdd_Click" /></td>
                                            </tr>
                                        </table>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:GridView ID="gvIssueSol" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic">
                                                        <Columns>
                                                         <asp:TemplateField HeaderText="S.No.">
                                                          <ItemTemplate>
                                                          <%# ((GridViewRow)Container).RowIndex + 1%>
                                .                         </ItemTemplate>
                                                     </asp:TemplateField>
                                                            <asp:BoundField HeaderText="Issue Department" DataField="SOL_SEC_VALUE" />
                                                            <asp:BoundField HeaderText="Solution Deapartment" DataField="DEPT_ID" />
                                                            </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </ContentTemplate>
                        </ajaxToolkit:TabPanel>
                        <ajaxToolkit:TabPanel ID="TabPanel3" runat="server" HeaderText="Issue Areas">
                            <ContentTemplate>
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                        <table>
                                            <tr>
                                                <th>Issue Department<span class="required">*</span></th>
                                                <th>Issue Area<span class="required">*</span></th>
                                                <th>Issue Solution Department<span class="required">*</span></th>
                                            </tr>
                                            <tr>
                                                <td><asp:DropDownList ID="ddlIssueDept" runat="server"></asp:DropDownList></td>
                                                <td><asp:TextBox ID="txtIssueArea" runat="server"></asp:TextBox></td>
                                                <td><asp:DropDownList ID="ddlDept" runat="server"></asp:DropDownList></td>
                                                <td><asp:Button ID="btnAreaAdd" runat="server" Text="ADD" OnClick="btnAreaAdd_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:GridView ID="gvArea" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" DataKeyNames="SUB_HEAD_ID" OnRowCommand="gvArea_RowCommand">
                                                        <Columns>
                                                         <asp:TemplateField HeaderText="S.No.">
                                                          <ItemTemplate>
                                                          <%# ((GridViewRow)Container).RowIndex + 1%>
                                .                         </ItemTemplate>
                                                     </asp:TemplateField>
                                            <asp:BoundField HeaderText="Issue Department" DataField="HEAD_VALUE" />
                                             <asp:BoundField HeaderText="Issue Area" DataField="SUB_HEAD_VALUE" />
                                             <asp:BoundField HeaderText="Solution Department" DataField="SOL_SEC_VALUE" />
                                            <asp:CommandField ButtonType="Image" SelectImageUrl="~/Siteimages/edit.gif" ShowSelectButton="True" HeaderText="Modify">
                                                        <ItemStyle Width="40px" />
                                                        </asp:CommandField>
                                                        <asp:TemplateField ShowHeader="False" HeaderText="Status">
                                                         <ItemStyle Width="20px" HorizontalAlign="Right" />
                                                         <ItemTemplate>
                                                         <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="false" CommandArgument='<%# Bind("SUB_HEAD_ID") %>'
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
                            </ContentTemplate>
                        </ajaxToolkit:TabPanel>
                    </ajaxToolkit:TabContainer>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

