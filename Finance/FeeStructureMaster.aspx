<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="FeeStructureMaster.aspx.cs" Inherits="Finance_BankAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript">
        // Client Side Validation Script
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
            if (!CheckControl("<%=ddlBatch.ClientID%>")) {
                msg += "- Select Batch from list\n";
                if (ctrl == "")
                    ctrl = "<%=ddlBatch.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlInstitute.ClientID%>")) {
                msg += "- Select Institute from list\n";
                if (ctrl == "")
                    ctrl = "<%=ddlInstitute.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlCourse.ClientID%>")) {
                msg += "- Select Course list \n";
                if (ctrl == "")
                    ctrl = "<%=ddlCourse.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddladmType.ClientID%>")) {
                msg += "- Select Admission Type from list \n";
                if (ctrl == "")
                    ctrl = "<%=ddladmType.ClientID%>";
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
            <h2>
                <!-- Page Heading-->
                Fee Structure
            </h2>

        </div>

        <div id="cBody">
            <div id="cHead">
                <!-- Content  Header ex: Filters-->

                <table>
                    <tr>
                        <td>Batch</td>
                        <td>&nbsp;</td>
                        <td>Institute</td>
                        <td>&nbsp;</td>
                        <td>Course</td>
                        <td>&nbsp;</td>
                        <td>Admission Type</td>
                        <td>&nbsp;</td>
                         <td>&nbsp;</td>
                         <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="ddlBatch" runat="server"></asp:DropDownList>
                        </td>
                        <td>&nbsp;</td>
                        <td>
                            <asp:DropDownList ID="ddlInstitute" runat="server" OnSelectedIndexChanged="ddlInstitute_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        </td>
                        <td>&nbsp;</td>
                        <td>
                            <asp:DropDownList ID="ddlCourse" runat="server"></asp:DropDownList>
                        </td>
                        <td>&nbsp;</td>
                        <td>
                            <asp:DropDownList runat="server" ID="ddladmType" CssClass="width_200">
                                <asp:ListItem Text="Normal" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Lateral" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Transfer" Value="2"></asp:ListItem>
                            </asp:DropDownList></td>
                        <td>&nbsp;</td>
                        <td>
                            <asp:Button ID="btnAdd" OnClick="btnAdd_Click" runat="server" Text="Create"
                                CssClass="btnBrown"></asp:Button>
                        </td>
                        <td>&nbsp;</td>
                        <td>
                            <asp:Button ID="btnCalculat" runat="server" CssClass="btnBrown" OnClick="btnCalculat_Click"
                                Text="Calculate" /></td>
                    </tr>
                </table>
                <hr />
            </div>
            <div id="cCenter">
                <!-- Content Header ex: Grids-->
                <asp:GridView ID="gvFeeStrac" runat="server" CellPadding="3" EmptyDataText="No record found"
                    AutoGenerateColumns="False" DataKeyNames="FEE_MAIN_HEAD_ID" ShowFooter="True" CssClass="gridDynamic">
                    <Columns>
                        <asp:BoundField HeaderText="S#" DataField="SR_NO">
                            <ItemStyle Width="15px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="FEE_MAIN_HEAD_NAME" HeaderText="Head Name">
                            <ItemStyle Width="200px" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Is Yearly" FooterText="Total:-">
                            <ItemTemplate>
                                <asp:RadioButtonList ID="RListType" runat="server" ForeColor="#C00000" CellSpacing="0"
                                    CellPadding="0" RepeatDirection="Horizontal" Font-Bold="True">
                                    <asp:ListItem Value="1">Yes</asp:ListItem>
                                    <asp:ListItem Selected="True" Value="0">No</asp:ListItem>
                                </asp:RadioButtonList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="1st Year">
                            <ItemTemplate>
                                <cc1:NumericTextBox ID="txt1" runat="server" CssClass="txtno" AllowDecimal="false"
                                    MaxLength="6" Width="80px"></cc1:NumericTextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="2nd Year">
                            <ItemTemplate>
                                <cc1:NumericTextBox ID="txt2" runat="server" CssClass="txtno" AllowDecimal="false"
                                    MaxLength="6" Width="80px"></cc1:NumericTextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="3rd Year">
                            <ItemTemplate>
                                <cc1:NumericTextBox ID="txt3" runat="server" CssClass="txtno" AllowDecimal="false"
                                    MaxLength="6" Width="80px"></cc1:NumericTextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="4th Year">
                            <ItemTemplate>
                                <cc1:NumericTextBox ID="txt4" runat="server" CssClass="txtno" AllowDecimal="false"
                                    MaxLength="6" Width="80px"></cc1:NumericTextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="5th Year">
                            <ItemTemplate>
                                <cc1:NumericTextBox ID="txt5" runat="server" CssClass="txtno" AllowDecimal="false"
                                    MaxLength="6" Width="80px"></cc1:NumericTextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="6th Year">
                            <ItemTemplate>
                                <cc1:NumericTextBox ID="txt6" runat="server" CssClass="txtno" AllowDecimal="false"
                                    MaxLength="6" Width="80px"></cc1:NumericTextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle HorizontalAlign="Right" Font-Bold="true" Font-Size="14px" />
                    <SelectedRowStyle BackColor="#99FF33" />
                </asp:GridView>
            </div>
            <div id="cFooter">
                <hr />
                <asp:Button ID="btnSave" runat="server" Text="Save " CssClass="btnBrown" OnClick="btnSave_Click" />
                <asp:TextBox ID="txtData" runat="server" Width="200px" Visible="false"></asp:TextBox>
            </div>
        </div>
    </div>

</asp:Content>

