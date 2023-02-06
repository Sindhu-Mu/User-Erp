<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Short.master" AutoEventWireup="true" CodeFile="SchmeRelationDeductionMain.aspx.cs" Inherits="HR_EPFSchmeRelationDeductionMain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentHolder1" runat="Server">
    &nbsp;<script language="javascript" type="text/javascript">
        function CheckControl(ctrl) {
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == "Select") {
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
                return false;
            }
            else
                document.getElementById(ctrl).style.backgroundColor = "#fff";
            return true;
        }
        function Scheme() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=txtScheme.ClientID%>")) {
                msg += " * Enter Scheme \n";
                if (ctrl == "")
                    ctrl = "<%=txtScheme.ClientID%>";
                flag = false;
            }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }
        function Deduction() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=txtDname.ClientID%>")) {
                msg += " * Enter Name \n";
                if (ctrl == "")
                    ctrl = "<%=txtDvalue.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtDvalue.ClientID%>")) {
                msg += " * Enter Value \n";
                if (ctrl == "")
                    ctrl = "<%=txtDname.ClientID%>";
                flag = false;
            }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }
        function Relation() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=txtRelation.ClientID%>")) {
                msg += " * Enter Relation \n";
                if (ctrl == "")
                    ctrl = "<%=txtRelation.ClientID%>";
                flag = false;
            }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }
    </script><table>
        <tr>
            <td>Scheme Relation Deduction Main </td>
        </tr>
        <tr>
            <td>
                <table>
                    <tr>
                        <td><ajaxToolkit:TabContainer ID="tabContainer" runat="server" ActiveTabIndex="0">
                            <ajaxToolkit:TabPanel runat="server" ID="TabPanel1" HeaderText="Scheme">
                                <ContentTemplate>
                                    <table>
                                        <tr>
                                            <th>EPF Scheme Name<span style="color: #ff0000"> * </span>
                                            </th>
                                        </tr>
                                        <tr>
                                            <td style="height: 22px">
                                                <asp:TextBox ID="txtScheme" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>
                                            </td>
                                            <td style="height: 22px">
                                                <asp:Button ID="saveScheme" runat="server" Text="Save" CssClass="btnBrown" OnClick="saveScheme_Click1" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:GridView ID="gvScheme" runat="server" Width="100%" DataKeyNames="SCHM_ID"
                                                    AutoGenerateColumns="False" EmptyDataText="No Record Found" OnRowCommand="gvScheme_RowCommand">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="S.No.">
                                                            <ItemTemplate>
                                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                                            </ItemTemplate>
                                                            <ItemStyle Width="15px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="SCHM_NAME" HeaderText="Scheme Name" />
                                                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/Siteimages/edit.gif" ShowSelectButton="True" HeaderText="Modify">
                                                            <ItemStyle Width="40px" />
                                                        </asp:CommandField>
                                                        <asp:TemplateField ShowHeader="False" HeaderText="Status">
                                                            <ItemStyle Width="20px" HorizontalAlign="Right" />
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="imgAct" runat="server" CausesValidation="false" CommandArgument='<%# Bind("SCHM_ID") %>'
                                                                    ImageUrl='<%# Bind("STS_IMG") %>' CommandName='<%# Bind("STS_CMD") %>' ToolTip='<%# Bind("STS_TOOLTIP")%>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </ajaxToolkit:TabPanel>
                            <ajaxToolkit:TabPanel runat="server" ID="TabPanel2" HeaderText="Relation">
                                <ContentTemplate>
                                    <table>
                                        <tr>
                                            <th>Relation<span style="color: #ff0000"> * </span>
                                            </th>
                                        </tr>
                                        <tr>
                                            <td style="height: 22px">
                                                <asp:TextBox ID="txtRelation" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>
                                            </td>
                                            <td style="height: 22px">
                                                <asp:Button ID="saveRelation" runat="server" Text="Save" CssClass="btnBrown" OnClick="saveRelation_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:GridView ID="gvRelation" runat="server" Width="100%" DataKeyNames="RELATION_ID"
                                                    AutoGenerateColumns="False" EmptyDataText="No Record Found" OnRowCommand="gvRelation_RowCommand">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="S.No.">
                                                            <ItemTemplate>
                                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                                            </ItemTemplate>
                                                            <ItemStyle Width="15px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="RELATION_NAME" HeaderText="Relation Name" />
                                                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/Siteimages/edit.gif" ShowSelectButton="True" HeaderText="Modify">
                                                            <ItemStyle Width="40px" />
                                                        </asp:CommandField>
                                                        <asp:TemplateField ShowHeader="False" HeaderText="Status">
                                                            <ItemStyle Width="20px" HorizontalAlign="Right" />
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="imgAct" runat="server" CausesValidation="false" CommandArgument='<%# Bind("RELATION_ID") %>'
                                                                    ImageUrl='<%# Bind("STS_IMG") %>' CommandName='<%# Bind("STS_CMD") %>' ToolTip='<%# Bind("STS_TOOLTIP")%>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </ajaxToolkit:TabPanel>
                            <ajaxToolkit:TabPanel runat="server" ID="TabPanel3" HeaderText="Deduction">
                                <ContentTemplate>
                                    <table>
                                        <tr>
                                            <th>Deduction Name <span style="color: #ff0000">*</span>
                                            </th>
                                            <th>Deduction Value <span style="color: #ff0000">*</span>
                                            </th>
                                        </tr>
                                        <tr>
                                            <td style="height: 22px">
                                                <asp:TextBox ID="txtDname" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDvalue" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>
                                            </td>
                                            <td style="height: 22px">
                                                <asp:Button ID="saveDeduction" runat="server" Text="Save" CssClass="btnBrown" OnClick="saveDeduction_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                <asp:GridView ID="gvDeduction" runat="server" Width="100%" DataKeyNames="DEDC_ID"
                                                    AutoGenerateColumns="False" EmptyDataText="No Record Found" OnRowCommand="gvDeduction_RowCommand">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="S.No.">
                                                            <ItemTemplate>
                                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                                            </ItemTemplate>
                                                            <ItemStyle Width="15px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="DEDC_NAME" HeaderText="Deduction Name" />
                                                        <asp:BoundField DataField="DEDC_VALUE" HeaderText="Deduction Value" />
                                                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/Siteimages/edit.gif" ShowSelectButton="True" HeaderText="Modify">
                                                            <ItemStyle Width="40px" />
                                                        </asp:CommandField>
                                                        <asp:TemplateField ShowHeader="False" HeaderText="Status">
                                                            <ItemStyle Width="20px" HorizontalAlign="Right" />
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="imgAct" runat="server" CausesValidation="false" CommandArgument='<%# Bind("DEDC_ID") %>'
                                                                    ImageUrl='<%# Bind("STS_IMG") %>' CommandName='<%# Bind("STS_CMD") %>' ToolTip='<%# Bind("STS_TOOLTIP")%>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </ajaxToolkit:TabPanel>
                        </ajaxToolkit:TabContainer>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

