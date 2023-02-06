<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Short.master" AutoEventWireup="true" CodeFile="ComplexMain.aspx.cs" Inherits="Facility_ComplexMain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentHolder1" Runat="Server">
    <script language ="javascript" type="text/javascript">

        function CheckControl(ctrl) {
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == "." || bTrim(document.getElementById(ctrl).value) == "Select") {
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
                return false;
            }
            else
                document.getElementById(ctrl).style.backgroundColor = "#fff";
            return true;
        }

        function validateType()
        {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=txtComType.ClientID%>")) {
                msg += "- Enter Complex Type.\n";
                if (ctrl == "")
                    ctrl = "<%=txtComType.ClientID%>";
                flag = false;
            }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }
        function validateMain()
        {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=ddlComType.ClientID%>")) {
                msg += "- Select Complex Type From The List. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlComType.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtComName.ClientID%>")) {
                msg += "- Enter Complex Name.\n";
                if (ctrl == "")
                    ctrl = "<%=txtComName.ClientID%>";
                flag = false;
            }
            
            if (!CheckControl("<%=txtNoRoom.ClientID%>")) {
                msg += "- Enter Number Of Rooms in the Complex.\n";
                if (ctrl == "")
                    ctrl = "<%=txtNoRoom.ClientID%>";
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
            <h2>Complex Main</h2>
        </div>
        <table>
            <tr>
                <td>
                    <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" AutoPostBack="true" ActiveTabIndex="0">
                        <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="Complex Type Main">
                            <ContentTemplate>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <table>
                                            <tr>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <th>Complex Type<span class="required">*</span></th>
                                                            <td><asp:TextBox ID="txtComType" runat="server"></asp:TextBox></td>
                                                            <td><asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" /></td>
                                                        </tr>
                                                        </table>
                                                        <tr>
                                                            <td>
                                                                <asp:GridView ID="gvComType" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" DataKeyNames="FAC_CMPLX_TYP_ID" OnRowCommand="gvComType_RowCommand" >
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="S.No.">
                                                                           <ItemTemplate>
                                                                            <%# ((GridViewRow)Container).RowIndex + 1%>
                                .                                           </ItemTemplate>
                                                                     </asp:TemplateField>
                                                                    <asp:BoundField HeaderText="Complex Type" DataField="FAC_CMPLX_TYP_VALUE" />
                                                      <asp:CommandField ButtonType="Image" SelectImageUrl="~/Siteimages/edit.gif" ShowSelectButton="True" HeaderText="Modify">
                                                        <ItemStyle Width="40px" />
                                                        </asp:CommandField>
                                                        <asp:TemplateField ShowHeader="False" HeaderText="Status">
                                                    <ItemStyle Width="20px" HorizontalAlign="Right" />
                                                                <ItemTemplate>
                                                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="false" CommandArgument='<%# Bind("FAC_CMPLX_TYP_ID") %>'
                                                             ImageUrl='<%# Bind("STS_IMG") %>' CommandName='<%# Bind("STS_CMD") %>' ToolTip='<%# Bind("STS_TOOLTIP")%>' />
                                                    </ItemTemplate>
                                            </asp:TemplateField>
                                                                    </Columns>
                                                                     <SelectedRowStyle BackColor="#FFFF99" />
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </ContentTemplate>
                        </ajaxToolkit:TabPanel>
                        <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="Complex Main">
                            <ContentTemplate>
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <table>
                                            <tr>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <th>Complex Type<span class="required">*</span></th>
                                                            <th>Complex Name<span class="required">*</span></th>
                                                            <th>No Of Rooms<span class="required">*</span></th>
                                                        </tr>
                                                        <tr>
                                                            <td><asp:DropDownList ID="ddlComType" runat="server"></asp:DropDownList></td>
                                                            <td><asp:TextBox ID="txtComName" runat="server"></asp:TextBox></td>
                                                            <td><cc1:NumericTextBox ID="txtNoRoom" runat="server"></cc1:NumericTextBox></td>
                                                            <td><asp:Button ID="btnAdd" runat="server" Text="ADD" OnClick="btnAdd_Click" /></td>
                                                        </tr>
                                                        </table>
                                                        <tr>
                                                            <td>
                                                                <asp:GridView ID="gvAdd" runat="server" AutoGenerateColumns="False" DataKeyNames="FAC_CMPLX_ID" CssClass="gridDynamic" OnRowCommand="gvAdd_RowCommand">
                                                                    <Columns>
                                                                    <asp:TemplateField HeaderText="S.No.">
                                                                    <ItemTemplate>
                                                                         <%# ((GridViewRow)Container).RowIndex + 1%>
                                .
                                                                 </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField HeaderText="Complex Type" DataField="FAC_CMPLX_TYP_VALUE" />
                                                                <asp:BoundField HeaderText="Complex Name" DataField="FAC_CMPLX_NAME" />
                                                                <asp:BoundField HeaderText="No Of Rooms" DataField="FAC_CMPLX_ROOM_NO" />
                                                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/Siteimages/edit.gif" ShowSelectButton="True" HeaderText="Modify">
                                                                <ItemStyle Width="40px" />
                                                        </asp:CommandField>
                                                           <asp:TemplateField ShowHeader="False" HeaderText="Status">
                                                    <ItemStyle Width="20px" HorizontalAlign="Right" />
                                                    <ItemTemplate>
                                                    <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="false" CommandArgument='<%# Bind("FAC_CMPLX_ID") %>'
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
                            </ContentTemplate>
                        </ajaxToolkit:TabPanel>
                    </ajaxToolkit:TabContainer>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

