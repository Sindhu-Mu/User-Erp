<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Short.master" AutoEventWireup="true" CodeFile="TransportBusRteMapp.aspx.cs" Inherits="Facility_TransportBusRteMapp" %>

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
                msg += "- Select City. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlCity.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlRte.ClientID%>")) {
                msg += "- Select Route. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlRte.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlBusNo.ClientID%>")) {
                msg += "-Select Bus Number.\n";
                if (ctrl == "")
                    ctrl = "<%=ddlBusNo.ClientID%>";
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
            <h2>Transport Bus Route Mapping</h2>
        </div>
        <table>
            <tr>
                <td>
                    <table>
                        <tr>
                            <th>City Name<span class="required">*</span></th>
                            <th>Route Name<span class="required">*</span></th>
                            <th>Bus No<span class="required">*</span></th>
                        </tr>
                        <tr>
                            <td>
                                <asp:DropDownList ID="ddlCity" runat="server" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged" AutoPostBack="True">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlRte" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlRte_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlBusNo" runat="server" AutoPostBack="True">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                            </td>
                        </tr>
                    </table>
                   </td>
                </tr>
                       <tr>
                <td>

                   <asp:GridView ID="gvSave" runat="server" AutoGenerateColumns="False"  CssClass="gridDynamic" DataKeyNames="MAPP_ID" OnRowCommand="gvSave_RowCommand">
                        <Columns>
                            <asp:TemplateField HeaderText="S.No">
                                <ItemTemplate>
                                    <%# ((GridViewRow)Container).RowIndex + 1%>                                .
                                </ItemTemplate>
                                <ItemStyle Width="15px" />
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="City" DataField="CITY_NAME" />
                            <asp:BoundField HeaderText="Route Name" DataField="RTE_NAME" />
                            <asp:BoundField HeaderText="Bus No" DataField="BUS_NO" />
                            <asp:CommandField ButtonType="Image" SelectImageUrl="~/Siteimages/edit.gif" ShowSelectButton="True" HeaderText="Modify">
                                        <ItemStyle Width="40px" />
                                    </asp:CommandField>
                            <asp:TemplateField ShowHeader="False" HeaderText="Status">
                                <ItemStyle Width="20px" HorizontalAlign="Right" />
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgAct" runat="server" CausesValidation="false" CommandArgument='<%# Bind("MAPP_ID") %>'
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

