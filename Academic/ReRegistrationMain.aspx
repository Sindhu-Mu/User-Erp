<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="ReRegistrationMain.aspx.cs" Inherits="Academic_ReRegistrationMain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
            if (!CheckControl("<%=txtSrtDt.ClientID%>")) {
                msg += "- Enter Start Date\n";
                if (ctrl == "")
                    ctrl = "<%=txtSrtDt.ClientID%>";
                    flag = false;
                }


                if (!CheckControl("<%=txtEndDt.ClientID%>")) {
                msg += "- Enter End Date\n";
                if (ctrl == "")
                    ctrl = "<%=txtEndDt.ClientID%>";
                    flag = false;
                }
            if (!CheckControl("<%=ddlSemType.ClientID%>")) {
                msg += "- Select Semester Type\n";
                if (ctrl == "")
                    ctrl = "<%=ddlSemType.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtSession.ClientID%>")) {
                msg += "- Enter Session\n";
                if (ctrl == "")
                    ctrl = "<%=txtSession.ClientID%>";
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
            <h2>Re-Registration Main</h2>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <th>Start Date<span class="required">*</span></th>
                        <th>End Date<span class="required">*</span></th>
                        <th>Sem Type<span class="required">*</span></th>
                        <th>Session<span class="required">*</span></th>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtSrtDt" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtEndDt" runat="server"></asp:TextBox></td>
                        <td>
                            <asp:DropDownList ID="ddlSemType" runat="server" AutoPostBack="True"></asp:DropDownList></td>
                        <td>
                            <asp:TextBox ID="txtSession" runat="server"></asp:TextBox></td>
                        <td>
                            <asp:Button ID="btnSave" runat="server" Text="SAVE" OnClick="btnSave_Click" /></td>
                    </tr>
                    </table>
                <table>
                    <tr>
                        <asp:GridView ID="gvReg" runat="server" CssClass="gridDynamic" AutoGenerateColumns="false" OnRowCommand="gvReg_RowCommand" DataKeyNames="CON_REG_ID">
                            <Columns>
                                <asp:TemplateField HeaderText="S.No">
                                    <ItemTemplate>
                                        <%#((GridViewRow)Container).RowIndex +1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Start Date" DataField="CON_REG_START_DT" />
                                <asp:BoundField HeaderText="End Date" DataField="CON_REG_END_DT" />
                                <asp:BoundField HeaderText="Session" DataField="CON_REG_SESSION" />
                                <asp:BoundField HeaderText="Semester Type" DataField="SEM_TYPE_VALUE" />
                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/Siteimages/edit.gif" ShowSelectButton="True" HeaderText="Modify">
                                    <ItemStyle Width="40px" />
                                </asp:CommandField>
                                <asp:TemplateField ShowHeader="False" HeaderText="Status">
                                    <ItemStyle Width="20px" HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="false" CommandArgument='<%# Bind("CON_REG_ID") %>'
                                            ImageUrl='<%# Bind("STS_IMG") %>' CommandName='<%# Bind("STS_CMD") %>' ToolTip='<%# Bind("STS_TOOLTIP")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </tr>
                    <tr>
                        <td>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy"
                                    TargetControlID="txtSrtDt">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                        <td>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy"
                                    TargetControlID="txtEndDt">
                                </ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

