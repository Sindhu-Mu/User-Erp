<%@ Page Title="ERP | Academic Base" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="AcademicBaseMain.aspx.cs" Inherits="Common_AcademicBaseMain" %>

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
        function validation() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=txtFullName.ClientID%>")) {
                msg += " * Enter Full Name  \n";
                if (ctrl == "")
                    ctrl = "<%=txtFullName.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtShortName.ClientID%>")) {
                msg += " * Enter Short Name \n";
                if (ctrl == "")
                    ctrl = "<%=txtShortName.ClientID%>";
                flag = false;
            }

            if (!CheckControl("<%=txtPriority.ClientID%>")) {
                msg += " * Enter Priority \n";
                if (ctrl == "")
                    ctrl = "<%=txtPriority.ClientID%>";
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
            <h2>Acadamic Base</h2>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <th>Full Name<span class="required">*</span></th>
                                    <td>&nbsp;</td>
                                    <th>Short Name<span class="required">*</span></th>
                                    <td>&nbsp;</td>
                                    <th>Priority<span class="required">*</span></th>
                                    <td>&nbsp;</td>
                                    <td></td>

                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtFullName" runat="server" Width="250px"></asp:TextBox></td>
                                    <td>&nbsp;</td>
                                    <td>
                                        <asp:TextBox ID="txtShortName" runat="server"></asp:TextBox></td>
                                    <td>&nbsp;</td>
                                    <td>
                                        <cc1:NumericTextBox ID="txtPriority" runat="server" Width="56px" MaxLength="2"></cc1:NumericTextBox></td>
                                    <td>&nbsp;</td>
                                    <td>
                                        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="gvShow" runat="server" AutoGenerateColumns="False" DataKeyNames="ACA_BASE_ID" CssClass="gridDynamic" OnRowCommand="gvShow_RowCommand">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No.">
                                        <ItemTemplate>
                                            <%# ((GridViewRow)Container).RowIndex + 1%>
                                        </ItemTemplate>
                                        <ItemStyle Width="15px" />
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Full Name" DataField="ACA_BASE_FULL_NAME" />
                                    <asp:BoundField HeaderText="Short Name" DataField="ACA_BASE_SHORT_NAME" />
                                    <asp:BoundField HeaderText="Priority" DataField="ACA_BASE_PRP" />
                                    <asp:CommandField ButtonType="Image" SelectImageUrl="~/Siteimages/edit.gif"  ShowSelectButton="true" HeaderText="Modify" >
                                        <ItemStyle Width="40px" />
                                    </asp:CommandField>
                                    <asp:TemplateField ShowHeader="False" HeaderText="Status">
                                        <ItemStyle Width="20px" HorizontalAlign="Right" />
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgAct" runat="server" CausesValidation="false" CommandArgument='<%# Bind("ACA_BASE_ID") %>'
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

