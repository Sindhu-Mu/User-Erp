<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Short.master" AutoEventWireup="true" CodeFile="TransportBusMain.aspx.cs" Inherits="Facility_TransportBusMain" %>

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

        function validate() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=ddlCity.ClientID%>")) {
                msg += "- Select Route From List. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlCity.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtBusNo.ClientID%>")) {
                msg += "- Enter Bus Number.\n";
                if (ctrl == "")
                    ctrl = "<%=txtBusNo.ClientID%>";
                flag = false;
            }

            if (!CheckControl("<%=ddlBusType.ClientID%>")) {
                msg += "- Select Bus Type. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlBusType.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtcap.ClientID%>")) {
                msg += "- Enter Capacity of a Bus. \n";
                if (ctrl == "")
                    ctrl = "<%=txtcap.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtcharg.ClientID%>")) {
                msg += "- Enter Charges of a Bus. \n";
                if (ctrl == "")
                    ctrl = "<%=txtcharg.ClientID%>";
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
            <h2>Bus Master </h2>
        </div>
        <table>
            <tr>
                <td>
        <table>
            <tr>
                <th>City Name<span class="required">*</span></th>
                <th>Bus Number<span class="required">*</span></th>
                <th>Bus Type<span class="required">*</span></th>
                <th>Capicity Of a Bus<span class="required">*</span></th>
                <th>Charges Of a Bus<span class="required">*</span></th>

            </tr>
            <tr>
                <td><asp:DropDownList ID="ddlCity" runat="server">
                    </asp:DropDownList></td>
                <td>

                    <asp:TextBox ID="txtBusNo" runat="server"></asp:TextBox>

                </td>
                <td>

                    <asp:DropDownList ID="ddlBusType" runat="server">
                    </asp:DropDownList>

                </td>
                <td>
                    <cc1:NumericTextBox ID="txtcap" runat="server" Width="80px"></cc1:NumericTextBox>
                </td>
                <td>
                    <cc1:NumericTextBox ID="txtcharg" runat="server" Width="85px"></cc1:NumericTextBox>
                </td>
                <td>
                    <asp:Button ID="Save" runat="server" Text="ADD" OnClick="Save_Click" />
                </td>
            </tr>
            </table>
                    </td>
                </tr>
            <tr>
                <td>

                   <asp:GridView ID="gvShow" runat="server" AutoGenerateColumns="False"  CssClass="gridDynamic" DataKeyNames="BUS_ID" OnRowCommand="gvShow_RowCommand">
                        <Columns>
                            <asp:TemplateField HeaderText="S.No">
                                <ItemTemplate>
                                    <%# ((GridViewRow)Container).RowIndex + 1%>                                .
                                </ItemTemplate>
                                <ItemStyle Width="15px" />
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="City Name" DataField="CITY_NAME" />
                            <asp:BoundField HeaderText="Bus Registration No" DataField="BUS_REG_NO" />
                            <asp:BoundField HeaderText="Bus Type" DataField="BUS_TYPE_VALUE" />
                            <asp:BoundField HeaderText="Capicity" DataField="CAPICITY" />
                            <asp:BoundField HeaderText="Charges of Bus" DataField="IS_CHARGE" />
                            <asp:CommandField ButtonType="Image" SelectImageUrl="~/Siteimages/edit.gif" ShowSelectButton="True" HeaderText="Modify">
                                        <ItemStyle Width="40px" />
                                    </asp:CommandField>
                            <asp:TemplateField ShowHeader="False" HeaderText="Status">
                                <ItemStyle Width="20px" HorizontalAlign="Right" />
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgAct" runat="server" CausesValidation="false" CommandArgument='<%# Bind("BUS_ID") %>'
                                        ImageUrl='<%# Bind("STATUS_IMG") %>' CommandName='<%# Bind("STATUS_CMD") %>' ToolTip='<%# Bind("STATUS_TOOLTIP")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                        <SelectedRowStyle BackColor="#FFFF99" />
                    </asp:GridView>

                </td>
            </tr>
            </table>
         </div>
</asp:Content>

