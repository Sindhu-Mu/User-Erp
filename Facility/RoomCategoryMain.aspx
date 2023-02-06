<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Short.master" AutoEventWireup="true" CodeFile="RoomCategoryMain.aspx.cs" Inherits="Facility_RoomCategoryMain" %>

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

        function Roomvalidate() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=txtRoomCatNm.ClientID%>")) {
                msg += "- Enter Room Category. \n";
                if (ctrl == "")
                    ctrl = "<%=txtRoomCatNm.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtCharges.ClientID%>")) {
                msg += "- Enter Charges of Room. \n";
                if (ctrl == "")
                    ctrl = "<%=txtCharges.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlNoOfBed.ClientID%>")) {
                msg += "-Select No Of Bed.\n";
                if (ctrl == "")
                    ctrl = "<%=ddlNoOfBed.ClientID%>";
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
            <h2>Room Category Main</h2>
        </div>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <th>Room Category Name<span class="required">*</span></th>
                                    <th>Room Charges<span class="required">*</span></th>
                                    <th>No. Of Bed<span class="required">*</span></th>
                                    <th>Gender<span class="required">*</span></th>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtRoomCatNm" runat="server"></asp:TextBox></td>
                                    <td>
                                        <cc1:NumericTextBox ID="txtCharges" runat="server"></cc1:NumericTextBox></td>
                                    <td>
                                        <asp:DropDownList ID="ddlNoOfBed" runat="server"></asp:DropDownList></td>
                                    <td>
                                        <asp:RadioButtonList ID="rdGen" runat="server">
                                            <asp:ListItem Text="Male" Value="1" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="Female" Value="2"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnAdd" runat="server" Text="ADD" OnClick="btnAdd_Click" /></td>
                                </tr>
                            </table>
                            <tr>
                                <td>
                                    <asp:GridView ID="gvAdd" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" DataKeyNames="FAC_ROOM_CATEGORY_ID" OnRowCommand="gvAdd_RowCommand1">
                                        <Columns>
                                            <asp:TemplateField HeaderText="S.No.">
                                                <ItemTemplate>
                                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="Room Category" DataField="FAC_ROOM_CATEGORY_NAME" />
                                            <asp:BoundField HeaderText="Room Charges" DataField="FAC_ROOM_CATEGORY_CHARGE" />
                                            <asp:BoundField HeaderText="Bed Count" DataField="FAC_ROOM_CATEGORY_BED_CNT" />
                                            <asp:BoundField HeaderText="Gender" DataField="GEN_VALUE" />
                                            <asp:CommandField ButtonType="Image" SelectImageUrl="~/Siteimages/edit.gif" ShowSelectButton="True" HeaderText="Modify">
                                                <ItemStyle Width="40px" />
                                            </asp:CommandField>
                                            <asp:TemplateField ShowHeader="False" HeaderText="Status">
                                                <ItemStyle Width="20px" HorizontalAlign="Right" />
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="false" CommandArgument='<%# Bind("FAC_ROOM_CATEGORY_ID") %>'
                                                        ImageUrl='<%# Bind("STS_IMG") %>' CommandName='<%# Bind("STS_CMD") %>' ToolTip='<%# Bind("STS_TOOLTIP")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>

    </div>
</asp:Content>

