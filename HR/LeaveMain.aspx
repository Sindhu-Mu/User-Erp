<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="LeaveMain.aspx.cs" Inherits="HR_LeaveMain" %>

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


            if (!CheckControl("<%=txtLvType.ClientID%>")) {
                msg += " * Enter Leave type. \n";
                if (ctrl == "")
                    ctrl = "<%=txtLvType.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtMinLv.ClientID%>")) {
                msg += " * Enter Minimum Leave . \n";
                if (ctrl == "")
                    ctrl = "<%=txtMinLv.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtMaxLv.ClientID%>")) {
                msg += " * Enter Maximum Leave . \n";
                if (ctrl == "")
                    ctrl = "<%=txtMaxLv.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtAnnual.ClientID%>")) {
                msg += " * Enter Annual Quota . \n";
                if (ctrl == "")
                    ctrl = "<%=txtAnnual.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtUnuse.ClientID%>")) {
                msg += " * Enter Unuse Leave . \n";
                if (ctrl == "")
                    ctrl = "<%=txtUnuse.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlCrType.ClientID%>")) {
                msg += " * Select Credit type . \n";
                if (ctrl == "")
                    ctrl = "<%=ddlCrType.ClientID%>";
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
            <h2>Leave Main </h2>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <th>Leave Type<span class="required">*</span></th>

                                    <th>Minimum Leave<span class="required">*</span></th>

                                    <th>Maximum Leave<span class="required">*</span></th>

                                    <th>Annual Quota<span class="required">*</span></th>

                                    <th>Unuse Leave<span class="required">*</span></th>


                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtLvType" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtMinLv" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtMaxLv" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtAnnual" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtUnuse" runat="server"></asp:TextBox>
                                    </td>

                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <th>Credit Type<span class="required">*</span></th>

                                    <th>Arrangement</th>
                                    <th>Clubbing</th>
                                    <th>Carry Forward</th>
                                    <th>Encashment</th>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:DropDownList ID="ddlCrType" runat="server" Width="130px">
                                            <asp:ListItem Value=".">Select</asp:ListItem>
                                            <asp:ListItem Value="12">Monthly</asp:ListItem>
                                            <asp:ListItem Value="3">Quaterly</asp:ListItem>
                                            <asp:ListItem Value="6">Half Yearly</asp:ListItem>
                                            <asp:ListItem Value="1">Annualy</asp:ListItem>
                                        </asp:DropDownList></td>
                                    <td>
                                        <asp:RadioButtonList ID="RbArrng" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Selected="True" Value="1">Yes</asp:ListItem>
                                            <asp:ListItem Value="0">No</asp:ListItem>
                                        </asp:RadioButtonList></td>
                                    <td>
                                        <asp:RadioButtonList ID="RbClub" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Selected="True" Value="1">Yes</asp:ListItem>
                                            <asp:ListItem Value="0">No</asp:ListItem>
                                        </asp:RadioButtonList></td>
                                    <td>
                                        <asp:RadioButtonList ID="RbCF" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Selected="True" Value="1">Yes</asp:ListItem>
                                            <asp:ListItem Value="0">No</asp:ListItem>
                                        </asp:RadioButtonList></td>
                                    <td>
                                        <asp:RadioButtonList ID="RbEncash" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Selected="True" Value="1">Yes</asp:ListItem>
                                            <asp:ListItem Value="0">No</asp:ListItem>
                                        </asp:RadioButtonList></td>
                                    <td>
                                        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                                    </td>
                                    <td>
                                        <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="gvLv" runat="server" AutoGenerateColumns="False" DataKeyNames="LV_ID" OnRowCommand="gvLv_RowCommand" CssClass="gridDynamic">
                                <Columns>
                                    <asp:TemplateField HeaderText="S#">

                                        <ItemTemplate>
                                            <%# ((GridViewRow )Container).RowIndex+1 %>
                                        </ItemTemplate>
                                        <ItemStyle Width="15px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="LV_VALUE" HeaderText="Name"></asp:BoundField>
                                    <asp:BoundField DataField="MIN_AVL" HeaderText="Minimum Leave"></asp:BoundField>
                                    <asp:BoundField DataField="MAX_AVL" HeaderText="Maximum Leave"></asp:BoundField>
                                    <asp:BoundField DataField="MAX_ACCUMALATION" HeaderText="Total"></asp:BoundField>
                                    <asp:BoundField DataField="CF" HeaderText="Carry Forward"></asp:BoundField>
                                    <asp:BoundField DataField="ENCASH" HeaderText="EnCachment"></asp:BoundField>
                                    <asp:CommandField ButtonType="Image" SelectImageUrl="~/Siteimages/edit.gif" ShowSelectButton="True" HeaderText="Modify">
                                        <ItemStyle Width="40px" />
                                    </asp:CommandField>
                                    <asp:TemplateField HeaderText="Status" ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgStatus" runat="server" CausesValidation="false" CommandArgument='<%# Bind("LV_ID") %>'
                                                ImageUrl='<%# Bind("STS_IMG") %>' CommandName='<%# Bind("STS_CMD") %>' ToolTip='<%# Bind("STS_TOOLTIP")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <SelectedRowStyle BackColor="#FFFF99" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

