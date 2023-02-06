<%@ Page Title="ERP | Semester Master" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="SemesterMain.aspx.cs" Inherits="Academic_SemesterMain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

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

            if (!CheckControl("<%=txtSemesterNo.ClientID%>")) {
                msg += "- Enter Semester No\n";
                if (ctrl == "")
                    ctrl = "<%=txtSemesterNo.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlSemesterType.ClientID%>")) {
                msg += "- Enter Semester Type\n";
                if (ctrl == "")
                    ctrl = "<%=ddlSemesterType.ClientID%>";
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
            <h2>Semester Main</h2>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <td>
                            <table>
                                <tr>

                                    <th>Semester  
                                    <span class="required">*</span></th>
                                    <td>&nbsp;</td>
                                    <th>Semester Type<span class="required">*</span></th>
                                    <td>&nbsp;</td>

                                </tr>
                                <tr>

                                    <td>
                                        <asp:TextBox ID="txtSemesterNo" runat="server" Width="230px" MaxLength="5"></asp:TextBox></td>
                                    <td>&nbsp;</td>
                                    <td>
                                        <asp:DropDownList ID="ddlSemesterType" runat="server"
                                            Width="233px">
                                            <asp:ListItem Value=".">Select</asp:ListItem>
                                            <asp:ListItem Value="0">Even</asp:ListItem>
                                            <asp:ListItem Value="1">Odd</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>&nbsp;</td>

                                    <td>
                                        <asp:Button ID="btnSave" runat="server" Width="70px" Text="Save" OnClick="btnSave_Click" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="gvShow" runat="server" AutoGenerateColumns="False" DataKeyNames="ACA_SEM_ID" OnRowCommand="gvShow_RowCommand" CssClass="gridDynamic">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No.">
                                        <ItemTemplate>
                                            <%# ((GridViewRow)Container).RowIndex + 1%>
                                    .
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Semester" DataField="ACA_SEM_NO" />
                                    <asp:BoundField HeaderText="Semester Type" DataField="SEM_TYPE_VALUE" />
                                    <asp:CommandField ButtonType="Image" SelectImageUrl="~/Siteimages/edit.gif" ShowSelectButton="True" HeaderText="Modify">
                                        <ItemStyle Width="40px" />
                                    </asp:CommandField>
                                    <asp:TemplateField ShowHeader="False" HeaderText="Status">
                                        <ItemStyle Width="20px" HorizontalAlign="Right" />
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="false" CommandArgument='<%# Bind("ACA_SEM_ID") %>'
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

