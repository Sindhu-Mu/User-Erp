<%@ Page Title="ERP | Menu" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="MenuMain.aspx.cs" Inherits="Admin_MenuMain" %>

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
        //function onkeydown() {
        //    if (event.keyCode == 116) {
        //        event.keyCode = 0;
        //        event.cancelBubble = true;
        //        return false;
        //    }
        //}
        function Headvalidation() {

            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=txtHeadValue.ClientID%>")) {
                msg += " * Enter Menu Head Name \n";
                if (ctrl == "")
                    ctrl = "<%=txtHeadValue.ClientID%>";
                 flag = false;
             }
             if (!CheckControl("<%=ddlPageHead.ClientID%>")) {
                msg += " * Select Menu Head \n";
                if (ctrl == "")
                    ctrl = "<%=ddlPageHead.ClientID%>";
                flag = false;
            }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }
        function SubHeadvalidation() {

            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=ddlPageHead.ClientID%>")) {
                msg += " * Select Menu Head \n";
                if (ctrl == "")
                    ctrl = "<%=ddlPageHead.ClientID%>";
                flag = false;
            }

            if (!CheckControl("<%=txtSubHead.ClientID%>")) {
                msg += " * Enter Menu Sub-Head Name \n";
                if (ctrl == "")
                    ctrl = "<%=txtSubHead.ClientID%>";
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
                 if (!CheckControl("<%=ddlHead.ClientID%>")) {
                msg += " * Select Menu Head \n";
                if (ctrl == "")
                    ctrl = "<%=ddlHead.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlSubHead.ClientID%>")) {
                msg += " * Select Menu Sub Head  \n";
                if (ctrl == "")
                    ctrl = "<%=ddlSubHead.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtPageName.ClientID%>")) {
                msg += " * Enter Page Name \n";
                if (ctrl == "")
                    ctrl = "<%=txtPageName.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtPageUrl.ClientID%>")) {
                msg += " * Enter Page Url \n";
                if (ctrl == "")
                    ctrl = "<%=txtPageUrl.ClientID%>";
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
            <h2>MENU & PAGES</h2>
        </div>
        <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" OnActiveTabChanged="TabContainer1_ActiveTabChanged" AutoPostBack="true" ActiveTabIndex="2" Width="100%">
            <ajaxToolkit:TabPanel runat="server" HeaderText="Menu Head" ID="TabPanel1">
                <ContentTemplate>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <table>
                                <tr>
                                    <td>
                                        <table>
                                            <tr>
                                                <th>Head Value<span class="required">*</span></th>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="txtHeadValue" runat="server" Width="250px"></asp:TextBox></td>
                                                <td>&nbsp;</td>
                                                <td>
                                                    <asp:Button ID="btnPageHead" runat="server" Text="Save" OnClick="btnPageHead_Click" /></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>

                                <tr>
                                    <td>
                                        <asp:GridView ID="gvPageHead" runat="server" AutoGenerateColumns="False" DataKeyNames="HEAD_ID" OnRowCommand="gvPageHead_RowCommand" CssClass="gridDynamic">
                                            <Columns>
                                                <asp:TemplateField HeaderText="S.No.">
                                                    <ItemTemplate>
                                                        <%# ((GridViewRow)Container).RowIndex + 1%>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="15px" />
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="Menu Head" DataField="HEAD_VALUE" />
                                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/Siteimages/edit.gif" ShowSelectButton="True" HeaderText="Modify">
                                                    <ItemStyle Width="40px" />
                                                </asp:CommandField>
                                                <asp:TemplateField ShowHeader="False" HeaderText="Status">
                                                    <ItemStyle Width="20px" HorizontalAlign="Right" />
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="imgAct" runat="server" CausesValidation="false" CommandArgument='<%# Bind("HEAD_ID") %>'
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
            <ajaxToolkit:TabPanel runat="server" HeaderText="Menu Sub-Heads" ID="TabPanel3">
                <ContentTemplate>
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <table>
                                <tr>
                                    <td>
                                        <table>
                                            <tr>
                                                <th>Menu Head <span class="required">*</span></th>
                                                <td>&nbsp;</td>
                                                <th>Menu Sub Head<span class="required">*</span></th>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:DropDownList ID="ddlPageHead" runat="server" Width="150px"></asp:DropDownList></td>
                                                <td>&nbsp;</td>
                                                <td>
                                                    <asp:TextBox ID="txtSubHead" runat="server" Width="250px"></asp:TextBox></td>
                                                <td>&nbsp;</td>
                                                <td>
                                                    <asp:Button ID="btnPageSubHead" runat="server" Text="Save" OnClick=" btnPageSubHead_Click" />
                                                </td>
                                            </tr>
                                        </table>

                                        <tr>
                                            <td>
                                                <asp:GridView ID="gvPageSubHead" runat="server" AutoGenerateColumns="False" DataKeyNames="SUB_HEAD_ID" OnRowCommand="gvPageSubHead_RowCommand" CssClass="gridDynamic">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="S.No.">
                                                            <ItemTemplate>
                                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                                            </ItemTemplate>
                                                            <ItemStyle Width="15px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField HeaderText="Menu Head" DataField="HEAD_VALUE" />
                                                        <asp:BoundField HeaderText="Sub Page" DataField="SUB_HEAD_VALUE" />
                                                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/Siteimages/edit.gif" ShowSelectButton="True" HeaderText="Modify">
                                                            <ItemStyle Width="40px" />
                                                        </asp:CommandField>
                                                        <asp:TemplateField ShowHeader="False" HeaderText="Status">
                                                            <ItemStyle Width="20px" HorizontalAlign="Right" />
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="imgAct" runat="server" CausesValidation="false" CommandArgument='<%# Bind("SUB_HEAD_ID") %>'
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
            <ajaxToolkit:TabPanel runat="server" HeaderText="Menu Pages" ID="TabPanel2">
                <ContentTemplate>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <table>
                                <tr>
                                    <td>
                                        <table>
                                            <tr>
                                                <th>Menu Head<span class="required">*</span></th>
                                                <th>Menu Sub Head<span class="required">*</span></th>
                                                <th>Page Name<span class="required">*</span></th>
                                                <th>Page Url<span class="required">*</span></th>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:DropDownList ID="ddlHead" runat="server" OnSelectedIndexChanged="ddlHead_SelectedIndexChanged" AutoPostBack="true" Width="120px"></asp:DropDownList></td>
                                                <td>
                                                    <asp:DropDownList ID="ddlSubHead" runat="server" Width="120px"></asp:DropDownList></td>
                                                <td>
                                                    <asp:TextBox ID="txtPageName" runat="server" Width="150px"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox ID="txtPageUrl" runat="server" Width="250px"></asp:TextBox></td>
                                                <td>
                                                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" /></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div style="overflow: auto; width: 100%; height: 450px">
                                            <asp:GridView ID="gvShow" runat="server" AutoGenerateColumns="False" DataKeyNames="PAGE_ID" OnRowCommand="gvShow_RowCommand" CssClass="gridDynamic">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S.No.">
                                                        <ItemTemplate>
                                                            <%# ((GridViewRow)Container).RowIndex + 1%>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="15px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField HeaderText="Menu Head" DataField="HEAD_VALUE" />
                                                    <asp:BoundField HeaderText="Menu Sub Head" DataField="SUB_HEAD_VALUE" />
                                                    <asp:BoundField HeaderText="Page Name" DataField="PAGE_VALUE" />
                                                    <asp:BoundField HeaderText="Page Url" DataField="PAGE_URL" />
                                                    <asp:CommandField ButtonType="Image" SelectImageUrl="~/Siteimages/edit.gif" ShowSelectButton="True" HeaderText="Modify">
                                                        <ItemStyle Width="40px" />
                                                    </asp:CommandField>
                                                    <asp:TemplateField ShowHeader="False" HeaderText="Status">
                                                        <ItemStyle Width="20px" HorizontalAlign="Right" />
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="imgAct" runat="server" CausesValidation="false" CommandArgument='<%# Bind("PAGE_ID") %>'
                                                                ImageUrl='<%# Bind("STS_IMG") %>' CommandName='<%# Bind("STS_CMD") %>' ToolTip='<%# Bind("STS_TOOLTIP")%>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
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

