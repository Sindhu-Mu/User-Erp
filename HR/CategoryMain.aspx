<%@ Page Title="ERP | Employee Category" Language="C#" MasterPageFile="~/MasterPages/Short.master" AutoEventWireup="true" CodeFile="CategoryMain.aspx.cs" Inherits="HR_CategoryMain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentHolder1" runat="Server">

    <script language="javascript" type="text/javascript">

        function CheckControl(ctrl) {
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == ".") {
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
            if (!CheckControl("<%=ddlJobType.ClientID%>")) {
                msg += "* Select Job Type \n";
                if (ctrl == "")
                    ctrl = "<%=ddlJobType.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtCatName.ClientID%>")) {
                msg += "* Enter Category Name \n";
                if (ctrl == "")
                    ctrl = "<%=txtCatName.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtCatAlias.ClientID%>")) {
                msg += "* Enter Category Alias \n";
                if (ctrl == "")
                    ctrl = "<%=txtCatAlias.ClientID%>";
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
            <h2>Employee Category</h2>
        </div>
        <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <th>Job Type<span class="required">*</span></th>
                                        <td>&nbsp;</td>
                                        <th>Category Name<span class="required">*</span></th>
                                        <td>&nbsp;</td>
                                        <th>Category Alias<span class="required">*</span></th>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="ddlJobType" runat="server" AutoPostBack="true" Width="160px"></asp:DropDownList></td>
                                        <td>&nbsp;</td>
                                        <td>
                                            <asp:TextBox ID="txtCatName" runat="server" Width="350px"></asp:TextBox></td>
                                        <td>&nbsp;</td>

                                        <td>
                                            <asp:TextBox ID="txtCatAlias" runat="server" MaxLength="2" Width="87px"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td>
                                            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" Width="70px" /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="gvCategory" runat="server" AutoGenerateColumns="False" CssClass="gridDynamic" OnRowCommand="gvCategory_RowCommand" DataKeyNames="CAT_ID">
                                    <Columns>
                                        <asp:TemplateField HeaderText="S.No.">
                                            <ItemTemplate>
                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                            </ItemTemplate>
                                            <ItemStyle Width="15px" />
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Job Type" DataField="JOB_TYPE_VALUE" />
                                        <asp:BoundField HeaderText="Category" DataField="CAT_VALUE" />
                                        <asp:BoundField HeaderText="Alias" DataField="CAT_ALIAS" />
                                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/Siteimages/edit.gif" ShowSelectButton="True" HeaderText="Modify">
                                            <ItemStyle Width="40px" />
                                        </asp:CommandField>
                                        <asp:TemplateField ShowHeader="False" HeaderText="Status">
                                            <ItemStyle Width="20px" HorizontalAlign="Right" />
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgAct" runat="server" CausesValidation="false" CommandArgument='<%# Bind("CAT_ID") %>'
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
    </div>
</asp:Content>

