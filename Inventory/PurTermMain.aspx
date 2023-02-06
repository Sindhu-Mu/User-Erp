<%@ Page Title="ERP | Purchase Term" Language="C#" MasterPageFile="~/MasterPages/Short.master" AutoEventWireup="true" CodeFile="PurTermMain.aspx.cs" Inherits="Inventory_PurTerm_Main" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentHolder1" runat="Server">
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
            if (!CheckControl("<%=txtTerm.ClientID%>")) {
                msg += "- Enter Term in TextBox\n";
                if (ctrl == "")
                    ctrl = "<%=txtTerm.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtDesc.ClientID%>")) {
                msg += "- Enter Description in TextBox\n";
                if (ctrl == "")
                    ctrl = "<%=txtDesc.ClientID%>";
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
            <h2>Purchase Term 
            </h2>
        </div>
        <div>
            <asp:UpdatePanel ID="UP1" runat="server">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <th>Term<span class="required">*</span></th>
                                        <th>Description </th>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtTerm" runat="server" CssClass="textbox" Width="250px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDesc" runat="server" CssClass="textbox" Width="350px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnSave" runat="server" Text="Save" Width="80px" OnClick="btnSave_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="height: 450px; overflow: auto; width: 100%">
                                    <asp:GridView ID="gvTerm" runat="server" Width="100%"
                                        DataKeyNames="PUR_TERM_ID" AutoGenerateColumns="False" OnRowCommand="gvTerm_RowCommand" CssClass="gridDynamic">
                                        <Columns>
                                            <asp:TemplateField HeaderText="S.No.">
                                                <ItemTemplate>
                                                    <%# ((GridViewRow)Container).RowIndex + 1%>.
                                                </ItemTemplate>
                                                <ItemStyle Width="20px" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="PUR_TERM" HeaderText="Term"></asp:BoundField>
                                            <asp:BoundField DataField="PUR_TERM_DESC" HeaderText="Description"></asp:BoundField>
                                            <asp:CommandField HeaderText="Edit" SelectImageUrl="~/Siteimages/edit.gif" ShowSelectButton="true" ButtonType="Image">
                                                <ItemStyle Width="20px"></ItemStyle>
                                            </asp:CommandField>
                                            <asp:TemplateField ShowHeader="False" HeaderText="Status">
                                                <ItemStyle Width="20px" HorizontalAlign="Right" />
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="false" CommandArgument='<%# Bind("PUR_TERM_ID") %>'
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
        </div>
    </div>
</asp:Content>

