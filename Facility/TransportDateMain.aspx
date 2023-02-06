<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Short.master" AutoEventWireup="true" CodeFile="TransportDateMain.aspx.cs" Inherits="Facility_TransportDateMain" %>

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

        function validate() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=srtslotdate.ClientID%>")) {
                 msg += "- Enter Start Date. \n";
                 if (ctrl == "")
                     ctrl = "<%=srtslotdate.ClientID%>";
                 flag = false;
             }
             if (!CheckControl("<%=endslotdate.ClientID%>")) {
                 msg += "- Enter End Date. \n";
                 if (ctrl == "")
                     ctrl = "<%=endslotdate.ClientID%>";
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
            <h2>Date Slots</h2>
        </div>
        <table>
            <tr>
                <td>


                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <table>
                                <tr>
                                    <td>
                                        <table>
                                            <tr>
                                                <th>Start Date <span class="required">*</span></th>
                                                <th>End Date <span class="required">*</span></th>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="srtslotdate" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="endslotdate" runat="server"></asp:TextBox>
                                                </td>
                                                <td>

                                                    <asp:Button ID="SaveSlot" runat="server" Text="ADD" OnClick="SaveSlot_Click" />

                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:GridView ID="gvDate" runat="server" AutoGenerateColumns="False" DataKeyNames="SLOT_ID" CssClass="gridDynamic" OnRowCommand="gvDate_RowCommand">
                                            <Columns>
                                                <asp:TemplateField HeaderText="S.No.">
                                                    <ItemTemplate>
                                                        <%# ((GridViewRow)Container).RowIndex + 1%>                                .
                                                    </ItemTemplate>
                                                    <ItemStyle Width="15px" />
                                                </asp:TemplateField>


                                                <asp:BoundField HeaderText="Slot Period" DataField="SLOT_PRD" />
                                                <asp:BoundField HeaderText="Number Of Days" DataField="NO_OF_DAYS" />
                                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/Siteimages/edit.gif" ShowSelectButton="True" HeaderText="Modify">
                                                    <ItemStyle Width="40px" />
                                                </asp:CommandField>
                                                <asp:TemplateField ShowHeader="False" HeaderText="Status">
                                                    <ItemStyle Width="20px" HorizontalAlign="Right" />
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="imgAct" runat="server" CausesValidation="false" CommandArgument='<%# Bind("SLOT_ID") %>'
                                                            ImageUrl='<%# Bind("STATUS_IMG") %>' CommandName='<%# Bind("STATUS_CMD") %>' ToolTip='<%# Bind("STATUS_TOOLTIP")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="srtslotdate">
                                        </ajaxToolkit:CalendarExtender>
                                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="srtslotdate" Mask="99/99/9999"
                                            MaskType="Date">
                                        </ajaxToolkit:MaskedEditExtender>
                                    </td>
                                    <td>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender5" Format="dd/MM/yyyy" runat="server" TargetControlID="endslotdate">
                                        </ajaxToolkit:CalendarExtender>
                                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="endslotdate" Mask="99/99/9999"
                                            MaskType="Date">
                                        </ajaxToolkit:MaskedEditExtender>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

