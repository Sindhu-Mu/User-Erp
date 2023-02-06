<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="RoleMain.aspx.cs" Inherits="Admin_RoleMain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script lang="javascript" type="text/javascript">
        function CheckControl(ctrl) {
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == ".") {
                document.getElementById(ctrl).style.backgroundColor = "#fc6"
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
        //function onkeydown()
        //{
        //    if (event.keyCode == 116) {
        //        event.keyCode = 0;
        //        event.cancelBubble = true;
        //        return false;
        //    }
        //}
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
        function Rolevalidation() {

            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=txtRoleName.ClientID%>")) {
                msg += " * Enter Role Name \n";
                if (ctrl == "")
                    ctrl = "<%=txtRoleName.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlRightType.ClientID%>")) {
                msg += " * Select Rights type from list.\n";
                if (ctrl == "")
                    ctrl = "<%=ddlRightType.ClientID%>";
                flag = false;
            }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }
        function Menuvalidation() {

            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=ddlRole.ClientID%>")) {
                msg += " * Select Role from list. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlRole.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlMenu.ClientID%>")) {
                msg += " * Select Menu from list.\n";
                if (ctrl == "")
                    ctrl = "<%=ddlMenu.ClientID%>";
                flag = false;
            }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }
        function Viewvalidation() {

            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=ddlUserType.ClientID%>")) {
                 msg += " * Select Role from list. \n";
                 if (ctrl == "")
                     ctrl = "<%=ddlUserType.ClientID%>";
                flag = false;
            }
            if (!CheckAutoComplete("<%=txtUser.ClientID%>")) {
                 msg += " * Enter User Name with Code. \n";
                 if (ctrl == "")
                     ctrl = "<%=txtUser.ClientID%>";
                flag = false;
            }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }
        function Pagevalidation() {

            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckAutoComplete("<%=txtUser.ClientID%>")) {
                msg += " * Enter User Name with Code. \n";
                if (ctrl == "")
                    ctrl = "<%=txtUser.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlUserRole.ClientID%>")) {
                msg += " * Select User Role from List. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlUserRole.ClientID%>";
                flag = false;
            }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }
    </script>
    <div class="container" >
        <div class="heading">
            <h2>Role & Pages</h2>
        </div>
        <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" OnActiveTabChanged="TabContainer1_ActiveTabChanged" AutoPostBack="true" ActiveTabIndex="2" Width="100%">
            <ajaxToolkit:TabPanel runat="server" HeaderText="Role" ID="TabPanel1">
                <ContentTemplate>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <table>
                                <tr>
                                    <td>
                                        <table>
                                            <tr>
                                                <th>Role Name<span class="required">*</span></th>
                                                <td>&nbsp;</td>
                                                <th>Rights Type<span class="required">*</span></th>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>

                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="txtRoleName" runat="server" Width="346px"></asp:TextBox></td>
                                                <td>&nbsp;</td>
                                                <td>
                                                    <asp:DropDownList ID="ddlRightType" runat="server" Width="178px"></asp:DropDownList></td>
                                                <td>&nbsp;</td>
                                                <td>
                                                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" /></td>
                                            </tr>
                                        </table>

                                        <tr>
                                            <td>
                                              
                                                    <asp:GridView ID="gvShow" runat="server" AutoGenerateColumns="False" DataKeyNames="ROLE_ID" CssClass="gridDynamic" OnRowCommand="gvShow_RowCommand">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S.No.">
                                                                <ItemTemplate>
                                                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="15px" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField HeaderText="Role Name" DataField="ROLE_VALUE" />
                                                            <asp:BoundField HeaderText="Right Type" DataField="AUTHORITY_VALUE" />
                                                            <asp:CommandField ButtonType="Image" SelectImageUrl="~/Siteimages/edit.gif" ShowSelectButton="True" HeaderText="Modify">
                                                                <ItemStyle Width="40px" />
                                                            </asp:CommandField>
                                                            <asp:TemplateField ShowHeader="False" HeaderText="Status">
                                                                <ItemStyle Width="20px" HorizontalAlign="Right" />
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="imgAct" runat="server" CausesValidation="false" CommandArgument='<%# Bind("ROLE_ID") %>'
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
            <ajaxToolkit:TabPanel runat="server" HeaderText="Page Assign" ID="TabPanel2">
                <ContentTemplate>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <table>
                                <tr>
                                    <td>
                                        <table>
                                            <tr>
                                                <th>Role Name<span class="required">*</span></th>
                                                <td>&nbsp;</td>
                                                <th>Menu Head<span class="required">*</span></th>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:DropDownList ID="ddlRole" runat="server" Width="200px"></asp:DropDownList></td>
                                                <td>&nbsp;</td>
                                                <td>
                                                    <asp:DropDownList ID="ddlMenu" runat="server" Width="200px" OnSelectedIndexChanged="ddlMenu_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></td>
                                                <td>&nbsp;</td>
                                                <td>
                                                    <asp:TextBox ID="txtXML" runat="server" Visible="false"></asp:TextBox>
                                                    <asp:Button ID="btnAssign" runat="server" Text="Assign" OnClick="btnAssign_Click" /></td>
                                            </tr>
                                        </table>
                                        <tr>
                                            <td>  
                                                <asp:GridView ID="gvMenuPage" runat="server" AutoGenerateColumns="False" DataKeyNames="PAGE_ID,ACTIVE" CssClass="gridDynamic">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="S.No.">
                                                            <ItemTemplate>
                                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                                            </ItemTemplate>
                                                            <ItemStyle Width="15px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField HeaderText="Menu Sub-Head" DataField="SUB_HEAD_VALUE" />
                                                        <asp:BoundField HeaderText="Page Name" DataField="PAGE_VALUE" />
                                                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/Siteimages/edit.gif" ShowSelectButton="True" HeaderText="Modify">
                                                            <ItemStyle Width="40px" />
                                                        </asp:CommandField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <input id="chkAll" onclick="javascript: SelectAllCheckboxes(this);" type="checkbox"
                                                                    value="on" runat="server" checked='<%# Bind("ACTIVE") %>' />All
                                                            </HeaderTemplate>

                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="chk" runat="server" AutoPostBack="true" ToolTip='<%# Bind("PAGE_ID") %>' />
                                                            </ItemTemplate>
                                                            <ItemStyle Width="40px" />
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
            <ajaxToolkit:TabPanel runat="server" HeaderText="User Role Assign" ID="TabPanel3">
                <ContentTemplate>
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <table>
                                <tr>
                                    <td>
                                        <table>
                                            <tr>
                                                <th>User Type<span class="required">*</span></th>
                                                <td>&nbsp;</td>
                                                <th>User<span class="required">*</span></th>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>

                                                <td>&nbsp;</td>
                                                <th>Role Name<span class="required">*</span></th>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:DropDownList ID="ddlUserType" runat="server" Width="120px"></asp:DropDownList></td>
                                                <td>&nbsp;</td>
                                                <td>
                                                    <asp:TextBox ID="txtUser" runat="server" Width="200px"></asp:TextBox></td>
                                                <td>&nbsp;</td>
                                                <td>
                                                    <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" /></td>
                                                <td>&nbsp;</td>
                                                <td>
                                                    <asp:DropDownList ID="ddlUserRole" runat="server" Width="120px"></asp:DropDownList></td>
                                                <td>&nbsp;</td>
                                                <td>
                                                    <asp:Button ID="btnUserRole" runat="server" Text="Assign" OnClick="btnUserRole_Click" /></td>
                                            </tr>
                                        </table>

                                        <tr>
                                            <td><div style="overflow: auto; width: 100%; height: 400px;">
                                                <asp:GridView ID="gvUserRole" runat="server" AutoGenerateColumns="False" DataKeyNames="USR_ROLE_ID" CssClass="gridDynamic" OnRowDeleting="gvUserRole_RowDeleting">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="S.No.">
                                                            <ItemTemplate>
                                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                                            </ItemTemplate>
                                                            <ItemStyle Width="15px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField HeaderText="User Id" DataField="USR_LOGIN_ID" />
                                                        <asp:BoundField HeaderText="User Name" DataField="USR_NAME" />
                                                        <asp:BoundField HeaderText="User Type" DataField="USR_TYPE_VALUE" />
                                                        <asp:BoundField HeaderText="Role Name" DataField="ROLE_VALUE" />
                                                        <asp:BoundField HeaderText="Assign Date" DataField="FROM_DT" DataFormatString="{0:dd/MM/yyyy}" />
                                                        <asp:CommandField ButtonType="Image" HeaderText="Delete" ShowDeleteButton="True" />
                                                    </Columns>
                                                </asp:GridView></div>
                                                <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" CompletionSetCount="12"
                                                    EnableCaching="true" MinimumPrefixLength="1" ServiceMethod="GetEmployeeList"
                                                    ServicePath="~\AutoComplete.asmx" TargetControlID="txtUser" ContextKey="1">
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

