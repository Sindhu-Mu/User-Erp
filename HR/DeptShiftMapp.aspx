<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Short.master" AutoEventWireup="true" CodeFile="DeptShiftMapp.aspx.cs" Inherits="HR_DeptShiftMapp" %>

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
            if (!CheckControl("<%=ddlDept.ClientID%>")) {
                msg += " * Select Department \n";
                if (ctrl == "")
                    ctrl = "<%=ddlDept.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlShift.ClientID%>")) {
                msg += " * Select Shift  \n";
                if (ctrl == "")
                    ctrl = "<%=ddlShift.ClientID%>";
                flag = false;
            }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }
    </script>
    <div>
        <div class="heading">
            <h2>DEPARTMENT SHIFT MAPPING</h2>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <th>Department<span class="required">*</span></th><td>&nbsp;</td>
                                    <th>Shift<span class="required">*</span></th><td>&nbsp;</td><td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:DropDownList ID="ddlDept" runat="server" AutoPostBack="true" Width="220px"></asp:DropDownList>
                                    </td><td>&nbsp;</td>
                                    <td>
                                        <asp:DropDownList ID="ddlShift" runat="server" AutoPostBack="true" Width="243px"></asp:DropDownList>
                                    </td><td>&nbsp;</td>
                                    <td>
                                        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                                    </td>
                                </tr>
                            </table>

                            <tr>
                                <td>
                                    <asp:GridView ID="gvShow" runat="server" AutoGenerateColumns="False" DataKeyNames="MAP_ID" OnRowCommand="gvShow_RowCommand" CssClass="gridDynamic">
                                        <Columns>
                                            <asp:TemplateField HeaderText="S.No.">
                                                <ItemTemplate>
                                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                                </ItemTemplate>
                                                <ItemStyle Width="15px" />
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="Department" DataField="DEPT_VALUE" />
                                            <asp:BoundField HeaderText="Shift" DataField="SHIFT_VALUE" />
                                            <asp:CommandField ButtonType="Image" SelectImageUrl="~/Siteimages/edit.gif" ShowSelectButton="True" HeaderText="Modify">
                                                <ItemStyle Width="40px" />
                                            </asp:CommandField>
                                            <asp:TemplateField ShowHeader="False" HeaderText="Status">
                                                <ItemStyle Width="20px" HorizontalAlign="Right" />
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgAct" runat="server" CausesValidation="false" CommandArgument='<%# Bind("MAP_ID") %>'
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

