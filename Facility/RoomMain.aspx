<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="RoomMain.aspx.cs" Inherits="Facility_RoomMain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script lang="javascript" type="text/javascript">

        function CheckControl(ctrl) {
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == "." || bTrim(document.getElementById(ctrl).value) == "Select") {
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
                return false;
            }
            else
                document.getElementById(ctrl).style.backgroundColor = "#fff";
            return true;
        }

        function validateType() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=txtRoomType.ClientID%>")) {
                msg += "- Enter Room Type.\n";
                if (ctrl == "")
                    ctrl = "<%=txtRoomType.ClientID%>";
                flag = false;
            }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }
        function validateMain() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=ddlComName.ClientID%>")) {
                msg += "- Select Complex Name From The List. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlComName.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlRoomType.ClientID%>")) {
                msg += "- Select Room Type.\n";
                if (ctrl == "")
                    ctrl = "<%=ddlRoomType.ClientID%>";
                flag = false;
            }

            if (!CheckControl("<%=ddlRoomCat.ClientID%>")) {
                msg += "- Selct Room Category.\n";
                if (ctrl == "")
                    ctrl = "<%=ddlRoomCat.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlRoomFloor.ClientID%>")) {
                msg += "- Selct Floor.\n";
                if (ctrl == "")
                    ctrl = "<%=ddlRoomFloor.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtRoomNo.ClientID%>")) {
                msg += "- Enter Room Number.\n";
                if (ctrl == "")
                    ctrl = "<%=txtRoomNo.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtMaxPer.ClientID%>")) {
                msg += "- Enter Number Of Maximum Person.\n";
                if (ctrl == "")
                    ctrl = "<%=txtMaxPer.ClientID%>";
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
            <h2>Room Main</h2>
        </div>
        <div>
            <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" AutoPostBack="true" ActiveTabIndex="1">
                <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="Room Type Main">
                    <ContentTemplate>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <table>
                                    <tr>
                                        <td>
                                            <table>
                                                <tr>
                                                    <th>Room Type</th>
                                                    <td>
                                                        <asp:TextBox ID="txtRoomType" runat="server"></asp:TextBox></td>
                                                    <td>
                                                        <asp:Button ID="btnAdd" runat="server" Text="ADD" OnClick="btnAdd_Click" /></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:GridView ID="gvRoomType" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" DataKeyNames="FAC_ROOM_TYP_ID" OnRowCommand="gvRoomType_RowCommand">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S.No.">
                                                        <ItemTemplate>
                                                            <%# ((GridViewRow)Container).RowIndex + 1%>
                                .                        
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField HeaderText="Room Type" DataField="FAC_ROOM_VALUE" />
                                                    <asp:CommandField ButtonType="Image" SelectImageUrl="~/Siteimages/edit.gif" ShowSelectButton="True" HeaderText="Modify">
                                                        <ItemStyle Width="40px" />
                                                    </asp:CommandField>
                                                    <asp:TemplateField ShowHeader="False" HeaderText="Status">
                                                        <ItemStyle Width="20px" HorizontalAlign="Right" />
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="false" CommandArgument='<%# Bind("FAC_ROOM_TYP_ID") %>'
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
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="Room Main">
                    <ContentTemplate>
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <table>
                                    <tr>
                                        <td>
                                            <table>
                                                <tr>
                                                    <th>Complex Name<span class="required">*</span></th>
                                                    <th>Room Type<span class="required">*</span></th>
                                                    <th>Room Category<span class="required">*</span></th>
                                                    <th>Room Floor<span class="required">*</span></th>
                                                    <th>Room No<span class="required">*</span></th>
                                                    <th>Maximum Person<span class="required">*</span></th>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:DropDownList ID="ddlComName" runat="server"></asp:DropDownList></td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlRoomType" runat="server"></asp:DropDownList></td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlRoomCat" runat="server"></asp:DropDownList></td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlRoomFloor" runat="server"></asp:DropDownList></td>
                                                    <td>
                                                        <asp:TextBox ID="txtRoomNo" runat="server" Width="90px"></asp:TextBox></td>
                                                    <td>
                                                        <cc1:NumericTextBox ID="txtMaxPer" runat="server" Width="90px"></cc1:NumericTextBox></td>
                                                    <td>
                                                        <asp:Button ID="btnSave" runat="server" Text="ADD" OnClick="btnSave_Click" /></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:GridView ID="gvRoomMain" runat="server" AutoGenerateColumns="False" CssClass="gridDynamic" DataKeyNames="ROOM_ID"  OnRowCommand="gvRoomMain_RowCommand">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S.No." ItemStyle-Width="20px">
                                                        <ItemTemplate>
                                                            <%# ((GridViewRow)Container).RowIndex + 1%>                                .                        
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField HeaderText="Complex" DataField="FAC_CMPLX_NAME" ItemStyle-Width="200px" />
                                                    <asp:BoundField HeaderText="Type" DataField="FAC_ROOM_VALUE" />
                                                    <asp:BoundField HeaderText="Category" DataField="FAC_ROOM_CATEGORY_NAME" ItemStyle-Width="90px" />
                                                    <asp:BoundField HeaderText="Floor" DataField="ROOM_FLOOR" />
                                                    <asp:BoundField HeaderText="Room No" DataField="ROOM_NO" />
                                                    <asp:BoundField HeaderText="Max" DataField="MAXIMUM_PRSN" />
                                                    <asp:CommandField ButtonType="Image" SelectImageUrl="~/Siteimages/edit.gif" ShowSelectButton="True" HeaderText="Modify">
                                                        <ItemStyle Width="30px" />
                                                    </asp:CommandField>
                                                    <asp:TemplateField ShowHeader="False" HeaderText="Status">
                                                        <ItemStyle Width="20px" HorizontalAlign="Right" />
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="false" CommandArgument='<%# Bind("ROOM_ID") %>'
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
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
            </ajaxToolkit:TabContainer>
        </div>
    </div>
</asp:Content>

