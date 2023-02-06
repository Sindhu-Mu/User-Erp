<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="TransportBusInTime.aspx.cs" Inherits="Facility_TransportBusInTime" %>

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
        function validate() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=ddlCity.ClientID%>")) {
                msg += "- Select City From The List. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlCity.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlRoute.ClientID%>")) {
                msg += "- Select Route.\n";
                if (ctrl == "")
                    ctrl = "<%=ddlRoute.ClientID%>";
                flag = false;
            }

            if (!CheckControl("<%=ddlBusType.ClientID%>")) {
                msg += "- Selct Bus Type.\n";
                if (ctrl == "")
                    ctrl = "<%=ddlBusType.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlBusNo.ClientID%>")) {
                msg += "- Selct Bus Number.\n";
                if (ctrl == "")
                    ctrl = "<%=ddlBusNo.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtInTime.ClientID%>")) {
                msg += "- Enter Bus In Time.\n";
                if (ctrl == "")
                    ctrl = "<%=txtInTime.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtDate.ClientID%>")) {
                msg += "- Enter Date.\n";
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
            <h2>Today's Bus Timings</h2>
        </div>
        <table>
            <tr>
                <td>
                    <table>
                        <tr>
                            <th>City<span class="required">*</span></th>
                            <th>Route<span class="required">*</span></th>
                            <th>Bus Type<span class="required">*</span></th>
                            <th>Bus No<span class="required">*</span></th>
                            <th>In Time<span class="required">*</span></th>
                            <th>Date<span class="required">*</span></th>
                            <th>Remark</th>
                        </tr>
                        <tr>
                            <td>
                                <asp:DropDownList ID="ddlCity" runat="server" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged" AutoPostBack="True">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlRoute" runat="server" OnSelectedIndexChanged="ddlRoute_SelectedIndexChanged" AutoPostBack="True" Width="80px">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlBusType" runat="server" OnSelectedIndexChanged="ddlBusType_SelectedIndexChanged" AutoPostBack="True" Width="80px">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlBusNo" runat="server" AutoPostBack="True" Width="80px">
                                </asp:DropDownList>
                            </td>
                            <td>

                                <asp:TextBox ID="txtInTime" runat="server" Width="40px"></asp:TextBox>(HH:MM)Use 24hr Format
                                                        <ajaxToolkit:MaskedEditExtender
                                                            ID="MaskedEditExtender5" runat="server" CultureName="en-US"
                                                            Mask="99:99" MaskType="Time" TargetControlID="txtInTime" CultureAMPMPlaceholder="AM;PM" CultureCurrencySymbolPlaceholder="$" CultureDateFormat="MDY" CultureDatePlaceholder="/" CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":" Enabled="True">
                                                        </ajaxToolkit:MaskedEditExtender>

                            </td>
                            <td>
                                <asp:TextBox ID="txtDate" runat="server" Width="80px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtRemark" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="Save" runat="server" Text="Save" OnClick="Save_Click" />
                            </td>

                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gvBusIn" runat="server" AutoGenerateColumns="False" CssClass="gridDynamic">
                        <Columns>
                            <asp:TemplateField HeaderText="S.No">
                                <ItemTemplate>
                                    <%# ((GridViewRow)Container).RowIndex + 1%>                                .
                                </ItemTemplate>
                                <ItemStyle Width="15px" />
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="City" DataField="CITY_NAME" />
                            <asp:BoundField HeaderText="Route Name" DataField="RTE_NAME" />
                            <asp:BoundField HeaderText="Bus Type" DataField="BUS_TYPE_VALUE" />
                            <asp:BoundField HeaderText="Bus No" DataField="BUS_REG_NO" />
                            <asp:BoundField HeaderText="In Time" DataField="IN_TIME" />
                            <asp:BoundField HeaderText="Date" DataField="IN_DT" DataFormatString="{00:dd/MM/yyyy}" />
                            <asp:BoundField HeaderText="Remark" DataField="REMARK" />
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
    </div>
</asp:Content>

