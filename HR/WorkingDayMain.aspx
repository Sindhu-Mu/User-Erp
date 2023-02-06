<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Short.master" AutoEventWireup="true" CodeFile="WorkingDayMain.aspx.cs" Inherits="HR_WorkingDayMain" %>

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
        function CheckDate(ctrl) {
            var dt = document.getElementById(ctrl).value;
            if (!isDatecheck(dt, "dd/MM/yyyy")) {
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
            if (!CheckControl("<%=ddlDayType.ClientID%>")) {
                msg += " * Select day type. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlDayType.ClientID%>";
                flag = false;
            }
            if (CheckControl("<%=txtDate.ClientID%>")) {
                if (!CheckDate("<%=txtDate.ClientID%>")) {
                     msg += "* Enter date in currect format.[dd/MM/yyyy]\n";
                     if (ctrl == "")
                         ctrl = "<%=txtDate.ClientID%>";
                    flag = false;
                }
            }
            else {
                msg += "* Enter working date\n";
                if (ctrl == "")
                    ctrl = "<%=txtDate.ClientID%>";
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
            <h2>Working day</h2>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <td>

                            <table>
                                <tr>
                                    <th>Institute<span class="required">*</span></th>
                                    <td>&nbsp;</td>
                                    <th>Type<span class="required">*</span></th>
                                    <td>&nbsp;</td>
                                    <th>Date<span class="required">*</span></th>
                                    <td>&nbsp;</td>
                                    <th>Remark</th>
                                    <th></th>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:DropDownList ID="ddlInstitution" runat="server" Width="120px"></asp:DropDownList></td>
                                    <td>&nbsp;</td>
                                    <td>
                                        <asp:DropDownList ID="ddlDayType" runat="server" Width="120px"></asp:DropDownList></td>
                                    <td>&nbsp;</td>
                                    <td>
                                        <asp:TextBox ID="txtDate" runat="server" Width="90px"></asp:TextBox>
                                    </td>
                                    <td>&nbsp;</td>
                                    <td>
                                        <asp:TextBox ID="txtRemark" runat="server" Width="279px"></asp:TextBox></td>

                                    <td>
                                        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="gvShow" runat="server" AutoGenerateColumns="false" DataKeyNames="ID" OnRowCommand="gvShow_RowCommand" CssClass="gridDynamic">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No.">
                                        <ItemTemplate><%#((GridViewRow)Container).RowIndex+1 %></ItemTemplate>
                                        <ItemStyle Width="15px" />
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Working Date" DataField="WORKING_DT" />
                                    <asp:BoundField HeaderText="For Institute" DataField="INS_VALUE" />
                                    <asp:BoundField HeaderText="Type" DataField="DAY_TYPE_NAME" />
                                    <asp:BoundField HeaderText="Remark" DataField="REMARK" />
                                    <asp:CommandField ButtonType="Image" SelectImageUrl="~/Siteimages/edit.gif" ShowSelectButton="True" HeaderText="Modify">
                                        <ItemStyle Width="40px" />
                                    </asp:CommandField>
                                    <asp:TemplateField ShowHeader="false" HeaderText="Status">
                                        <ItemStyle Width="20px" HorizontalAlign="Right" />
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgStatus" runat="server" CausesValidation="false" CommandArgument='<%# Bind("ID") %>' 
                                                ImageUrl='<%# Bind("STS_IMG") %>' CommandName='<%# Bind("STS_CMD") %>' ToolTip='<%# Bind("STS_TOOLTIP")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>

                        </td>
                    </tr>
                    <tr>
                        <td>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="txtDate"></ajaxToolkit:CalendarExtender>
                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtDate" Mask="99/99/9999"
                                MaskType="Date">
                            </ajaxToolkit:MaskedEditExtender>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

