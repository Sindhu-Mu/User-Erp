<%@ Page Title="ERP | Program Type Master" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="ProgramTypeMain.aspx.cs" Inherits="Academic_ProgramTypeMain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <script lang="javascript" type="text/javascript">
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
            if (!CheckControl("<%=txtProgramType.ClientID%>")) {
                msg += "- Enter Program Type Name\n";
                if (ctrl == "")
                    ctrl = "<%=txtProgramType.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtDesc.ClientID%>")) {
                msg += "- Enter Program Type Description\n";
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
    <div  class="container">
        <div class="heading">
            <h2>Program Type</h2>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <th>Type Name<span class="required">*</span></th>
                        <td>&nbsp;</td>
                        <th>Description
                        <span class="required">*</span></th>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;<asp:TextBox ID="txtProgramType" runat="server" CssClass="textBox" Width="300px"></asp:TextBox></td>
                        <td>&nbsp;</td>
                        <td>
                            <asp:TextBox ID="txtDesc" runat="server" CssClass="textBox" Width="250px"></asp:TextBox></td>
                        <td>&nbsp;</td>
                        <td>
                            <asp:Button ID="btnSave" runat="server" Text="Save" Width="70px" OnClick="btnSave_Click" /></td>
                    </tr>

                </table>
                </td></tr>

                    <tr>
                        <td>
                            <asp:GridView ID="gvShow" runat="server" AutoGenerateColumns="False" DataKeyNames="PRG_TYPE_ID" OnRowCommand="gvShow_RowCommand" CssClass="gridDynamic">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No.">
                                        <ItemTemplate>
                                            <%# ((GridViewRow)Container).RowIndex + 1%>                                .
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Program Type Name" DataField="PRG_TYPE_VALUE" />
                                    <asp:BoundField HeaderText="Description" DataField="PRG_TYPE_DESC" />
                                    <asp:CommandField ButtonType="Image" SelectImageUrl="~/Siteimages/edit.gif" ShowSelectButton="True" HeaderText="Modify">
                                        <ItemStyle Width="40px" />
                                    </asp:CommandField>
                                    <asp:TemplateField ShowHeader="False" HeaderText="Status">
                                        <ItemStyle Width="20px" HorizontalAlign="Right" />
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="false" CommandArgument='<%# Bind("PRG_TYPE_ID") %>'
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

