<%@ Page Title="ERP | Item Unit" Language="C#" MasterPageFile="~/MasterPages/Short.master" AutoEventWireup="true" CodeFile="UnitMain.aspx.cs" Inherits="Inventory_UnitMain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentHolder1" runat="Server">
    <script language="javascript" type="text/javascript">
        function CheckControl(ctrl) {
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == "Select") {
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
                return false;
            }
            else {
                document.getElementById(ctrl).style.backgroundColor = "#fff";
                return true;
            }
        }
        function validate() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=txtUnit.ClientID%>")) {
                msg += "- Enter Unit Name\n";
                if (ctrl == "") {
                    ctrl = "<%=txtUnit.ClientID%>";
                }
                flag = false;
            }
            if (msg != "")
                alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }
    </script>
    <div class="container">
        <div class="heading">
            <h2>Unit Main</h2>
        </div>
        <div>
            <asp:UpdatePanel ID="UP1" runat="server">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <th>Unit Name<span class="required">*</span></th>
                                        <td>
                                            <asp:TextBox ID="txtUnit" MaxLength="10" runat="server" Width="247px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnUnit" runat="server" Text="Save" OnClick="btnUnit_Click" />
                                        </td>
                                    </tr>
                                </table>

                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="height: 450px; width: 100%; overflow: auto">
                                    <asp:GridView ID="gvUnit" CssClass="gridDynamic" DataKeyNames="UNIT_ID" runat="server" AutoGenerateColumns="false" Width="100%" OnRowCommand="gvUnit_RowCommand">
                                        <Columns>
                                            <asp:TemplateField HeaderText="S.No.">
                                                <ItemTemplate>
                                                    <%# ((GridViewRow)Container).RowIndex + 1%>.
                                                </ItemTemplate>
                                                <ItemStyle Width="15px" />
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="Unit Value" DataField="UNIT_NAME" />
                                            <asp:CommandField HeaderText="Edit" SelectImageUrl="~/Siteimages/edit.gif" ShowSelectButton="true" ButtonType="Image">
                                                <ItemStyle Width="40px"></ItemStyle>
                                            </asp:CommandField>
                                            <asp:TemplateField ShowHeader="False" HeaderText="Status">
                                                <ItemStyle Width="20px" HorizontalAlign="Right" />
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="false" CommandArgument='<%# Bind("UNIT_ID") %>'
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

