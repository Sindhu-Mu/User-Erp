<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="BoardMain.aspx.cs" Inherits="Academic_BoardMain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript">
        function CheckControl(ctrl) {
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == "Select") {
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
            if (!CheckControl("<%=txtBoardName.ClientID%>")) {
                    msg += "- Enter Board Full Name\n";
                    if (ctrl == "")
                        ctrl = "<%=txtBoardName.ClientID%>";
                    flag = false;
                }


                if (!CheckControl("<%=txtShortName.ClientID%>")) {
                    msg += "- Enter Board Short Name\n";
                    if (ctrl == "")
                        ctrl = "<%=txtShortName.ClientID%>";
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
            <h2>Academic Board</h2>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <th>Full Name
                            <span class="required">*</span></th>
                                    <td>&nbsp;</td>
                                    <th>Short Name <span class="required">*</span></th>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtBoardName" runat="server" CssClass="textBox" Width="300px"></asp:TextBox></td>
                                    <td>&nbsp;</td>
                                    <td>
                                        <asp:TextBox ID="txtShortName" runat="server" CssClass="textBox" Width="250px"></asp:TextBox></td>
                                    <td>&nbsp;</td>
                                    <td>
                                        <asp:Button ID="btnSave" runat="server" Text="Save" Width="70px" OnClick="btnSave_Click" /></td>
                                </tr>


                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="gvShow" runat="server" AutoGenerateColumns="False" DataKeyNames="ACA_BRD_ID" CssClass="gridDynamic" OnRowCommand="gvShow_RowCommand" EmptyDataText="No Record Avaliable">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No.">
                                        <ItemTemplate>
                                            <%# ((GridViewRow)Container).RowIndex + 1%>                                .
                                        </ItemTemplate>
                                        <ItemStyle Width="20px" />
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Board Full Name" DataField="ACA_BRD_FULL_NAME" />
                                    <asp:BoundField HeaderText="Board Short Name" DataField="ACA_BRD_SHORT_NAME" />
                                    <asp:CommandField ButtonType="Image" SelectImageUrl="~/Siteimages/edit.gif" ShowSelectButton="True" HeaderText="Modify">
                                        <ItemStyle Width="40px" />
                                    </asp:CommandField>
                                    <asp:TemplateField ShowHeader="False" HeaderText="Status">
                                        <ItemStyle Width="20px" HorizontalAlign="Right" />
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="false" CommandArgument='<%# Bind("ACA_BRD_ID") %>'
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

