<%@ Page Title="ERP | Employee Shift Master" Language="C#" MasterPageFile="~/MasterPages/Short.master" AutoEventWireup="true" CodeFile="ShiftMain.aspx.cs" Inherits="HR_ShiftMain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
        function CheckControl(ctrl) {
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == "." || bTrim(document.getElementById(ctrl).value) == "Select") {
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
            if (!CheckControl("<%=txtShiftName.ClientID%>")) {
                msg += "- Select/Enter Shift Name!!\n";
                if (ctrl == "")
                    ctrl = "<%=txtShiftName.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtShortName.ClientID%>")) {
                msg += "- Enter Shift Short Name!!\n";
                if (ctrl == "")
                    ctrl = "<%=txtShortName.ClientID%>";
                flag = false;
            }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }

        function Validat() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=ddlShiftName.ClientID%>")) {
                msg += "- Select Shift Name!!\n";
                if (ctrl == "")
                    ctrl = "<%=ddlShiftName.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtInBeforeTime.ClientID%>")) {
                msg += "- Enter IN Before Time!!\n";
                if (ctrl == "")
                    ctrl = "<%=txtInBeforeTime.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtInAfterTime.ClientID%>")) {
                msg += "- Enter IN After Time!!\n";
                if (ctrl == "")
                    ctrl = "<%=txtInAfterTime.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtOutBeforeTime.ClientID%>")) {
                msg += "- Enter OUT Before Time!!\n";
                if (ctrl == "")
                    ctrl = "<%=txtOutBeforeTime.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtOutAfterTime.ClientID%>")) {
                msg += "- Enter OUT After Time!!\n";
                if (ctrl == "")
                    ctrl = "<%=txtOutAfterTime.ClientID%>";
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
            <h2>Duty Shifts </h2>
        </div>
        <table>
            <tr>
                <td>
                    <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" OnActiveTabChanged="TabContainer1_ActiveTabChanged" AutoPostBack="true" ActiveTabIndex="1" Width="100%">
                        <ajaxToolkit:TabPanel runat="server" HeaderText="Shift" ID="TabPanel1">
                            <ContentTemplate>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <table>
                                            <tr>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <th>Full Name<span class="required">*</span></th>

                                                            <th>Short Name<span class="required">*</span></th>

                                                            <th>In Time<span class="required">*</span></th>

                                                            <th>Out Time<span class="required">*</span></th>

                                                            <td></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="txtShiftName" runat="server" Width="180px"></asp:TextBox>
                                                            </td>

                                                            <td>
                                                                <asp:TextBox ID="txtShortName" runat="server" Width="128px"></asp:TextBox></td>

                                                            <td>
                                                                <cc3:TimeSelector ID="txtInTime" runat="server">
                                                                </cc3:TimeSelector>
                                                            </td>

                                                            <td>
                                                                <cc3:TimeSelector ID="txtOutTime" runat="server">
                                                                </cc3:TimeSelector>
                                                            </td>

                                                            <td>
                                                                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" /></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td> <div style="overflow: auto; width: 100%; height: 400px">
                                                    <asp:GridView ID="gvShow" runat="server" AutoGenerateColumns="False" DataKeyNames="SHIFT_ID" OnRowCommand="gvShow_RowCommand" CssClass="gridDynamic" Width="97%">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S.No.">
                                                                <ItemTemplate>
                                                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="15px" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField HeaderText="Shift Name" DataField="SHIFT_VALUE" />
                                                            <asp:BoundField HeaderText="Short Name" DataField="SHORT_NAME" />
                                                            <asp:BoundField HeaderText="In Time" DataField="IN_TIME" />
                                                            <asp:BoundField HeaderText="Out Time" DataField="OUT_TIME" />
                                                            <asp:CommandField ButtonType="Image" SelectImageUrl="~/Siteimages/edit.gif" ShowSelectButton="True" HeaderText="Modify">
                                                                <ItemStyle Width="40px" />
                                                            </asp:CommandField>
                                                            <asp:TemplateField ShowHeader="False" HeaderText="Status">
                                                                <ItemStyle Width="20px" HorizontalAlign="Right" />
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="imgAct" runat="server" CausesValidation="false" CommandArgument='<%# Bind("SHIFT_ID") %>'
                                                                        ImageUrl='<%# Bind("STS_IMG") %>' CommandName='<%# Bind("STS_CMD") %>' ToolTip='<%# Bind("STS_TOOLTIP")%>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                        </Columns>
                                                    </asp:GridView></div>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </ContentTemplate>
                        </ajaxToolkit:TabPanel>
                        <ajaxToolkit:TabPanel runat="server" HeaderText="Shift Timing" ID="TabPanel2">
                            <ContentTemplate>
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <table>
                                            <tr>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <th>Shift Name<span class="required">*</span></th>
                                                            <th>In Before Time<span class="required">*</span></th>
                                                            <th>In After Time<span class="required">*</span></th>
                                                            <th>Out Before Time<span class="required">*</span></th>
                                                            <th>Out After Time<span class="required">*</span> </th>
                                                            <td></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:DropDownList ID="ddlShiftName" runat="server" OnSelectedIndexChanged="ddlShiftName_SelectedIndexChanged" AutoPostBack="true" Width="171px"></asp:DropDownList>
                                                                <td>
                                                                    <cc1:NumericTextBox ID="txtInBeforeTime" runat="server" Width="80px"></cc1:NumericTextBox></td>
                                                                <td>
                                                                    <cc1:NumericTextBox ID="txtInAfterTime" runat="server" Width="80px"></cc1:NumericTextBox></td>
                                                                <td>
                                                                    <cc1:NumericTextBox ID="txtOutBeforeTime" runat="server" Width="80px"></cc1:NumericTextBox></td>
                                                                <td>
                                                                    <cc1:NumericTextBox ID="txtOutAfterTime" runat="server" Width="80px"></cc1:NumericTextBox></td>
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="btnSaveTime" runat="server" Text="Save" OnClick="btnSaveTime_Click" /></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td><div style="overflow: auto; width: 100%; height: 400px">
                                                    <asp:GridView ID="gvTime" runat="server" AutoGenerateColumns="False" DataKeyNames="TIME_ID" OnRowCommand="gvTime_RowCommand" CssClass="gridDynamic" >
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S.No.">
                                                                <ItemTemplate>
                                                                    <%# ((GridViewRow)Container).RowIndex + 1%>                                .
                                                                </ItemTemplate>
                                                                <ItemStyle Width="15px" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField HeaderText="Shift Name" DataField="SHIFT_VALUE" />
                                                            <asp:BoundField HeaderText="In Before Time" DataField="IN_BFR_TIME" />
                                                            <asp:BoundField HeaderText="In After Time" DataField="IN_AFT_TIME" />
                                                            <asp:BoundField HeaderText="Out Before Time" DataField="OUT_BFR_TIME" />
                                                            <asp:BoundField HeaderText="Out After Time" DataField="OUT_AFT_TIME" />
                                                            <asp:TemplateField ShowHeader="False" HeaderText="Status">
                                                                <ItemStyle Width="20px" HorizontalAlign="Right" />
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="imgAct" runat="server" CausesValidation="false" CommandArgument='<%# Bind("TIME_ID") %>'
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
                            </ContentTemplate>
                        </ajaxToolkit:TabPanel>
                    </ajaxToolkit:TabContainer>
                </td>
            </tr>
        </table>

    </div>


</asp:Content>

