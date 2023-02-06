<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="TransportRouteApproval.aspx.cs" Inherits="Facility_TransportRouteApproval" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
         function validateApproval() {
             var flag = true;
             var msg = "", ctrl = "";
             if (!CheckControl("<%=ddlRoute.ClientID%>")) {
                 msg += "- Assign Route.\n";
                 if (ctrl == "")
                     ctrl = "<%=ddlRoute.ClientID%>";
                flag = false;
             }
             if (!CheckControl("<%=ddlBus.ClientID%>")) {
                 msg += "- Assign Bus.\n";
                 if (ctrl == "")
                     ctrl = "<%=ddlBus.ClientID%>";
                 flag = false;
             }
             if (!CheckControl("<%=txtStop.ClientID%>")) {
                 msg += "- Provide Sttopage.\n";
                 if (ctrl == "")
                     ctrl = "<%=txtStop.ClientID%>";
                 flag = false;
             }
             if (!CheckControl("<%=ddlAction.ClientID%>")) {
                 msg += "- Select Action.\n";
                 if (ctrl == "")
                     ctrl = "<%=ddlAction.ClientID%>";
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
            <h2>Registration Route Verification
            </h2>
        </div>
        <table>
            <tr>
                <td>
                    <table>
                        <tr>
                            <th>City</th>
                            <th>Slot No</th>
                            <th>Registration No</th>
                        </tr>
                        <tr>
                            <td>
                                <asp:DropDownList ID="ddlCity" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlSlot" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <cc1:NumericTextBox ID="txtReg" runat="server"></cc1:NumericTextBox>
                            </td>
                            <td>
                                <asp:Button ID="btnShow" runat="server" Text="View" OnClick="btnShow_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>

                    <asp:GridView ID="GridRouteApproval" runat="server" AutoGenerateColumns="False" CssClass="gridDynamic" DataKeyNames="REG_ROUTE_ID" EmptyDataText="No Record(s) Found">
                        <Columns>
                            <asp:TemplateField HeaderText="S.No">
                                <ItemTemplate>
                                    <%# ((GridViewRow)Container).RowIndex + 1%>                                .
                                </ItemTemplate>
                                <ItemStyle Width="15px" />
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Registration No" DataField="REG_ID" />
                            <asp:BoundField HeaderText="Studnet Name" DataField="STU_FULL_NAME" />
                            <asp:BoundField HeaderText="Apply date" DataField="APP_DATE" DataFormatString="{00:dd/MM/yyyy}" />
                            <asp:BoundField HeaderText="Slot" DataField="SLOT_PRD" />
                            <asp:BoundField HeaderText="Bus No" DataField="BUS_ID" />
                            <asp:BoundField HeaderText="City" DataField="CITY_NAME" />
                            <asp:BoundField HeaderText="Stoppage" DataField="STOPPAGE" />
                            <asp:BoundField HeaderText="Route Desc" DataField="ROUTE_DESC" />
                            <asp:TemplateField HeaderText="Select">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkApproval" runat="server" Checked="false" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <SelectedRowStyle BackColor="#FFFF99" />
                    </asp:GridView>

                </td>
            </tr>
            <tr>
                <td>
                    <table id="tblApp" runat="server">
                        <tr>
                            <th>Route Name<span class="required">*</span></th>
                            <th>Bus No<span class="required">*</span></th>
                            <th>Stoppage<span class="required">*</span></th>
                            <th>Action<span class="required">*</span></th>
                            <th>Remark</th>
                        </tr>
                        <tr>
                            <td>
                                <asp:DropDownList ID="ddlRoute" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlBus" runat="server"></asp:DropDownList>
                            </td>
                            <td>
                                <asp:TextBox ID="txtStop" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlAction" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:TextBox ID="txtRemark" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="btnCtn" runat="server" Text="Continue" OnClick="btnCtn_Click" />
                                <asp:TextBox ID="txtData" runat="server" Visible="False"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

