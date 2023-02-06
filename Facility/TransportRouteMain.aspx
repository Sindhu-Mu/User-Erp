<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Short.master" AutoEventWireup="true" CodeFile="TransportRouteMain.aspx.cs" Inherits="Facility_TptRouteMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentHolder1" runat="Server">

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
            if (!CheckControl("<%=ddlCitySelect.ClientID%>")) {
                msg += "- Select Item From List. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlCitySelect.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=RteName.ClientID%>")) {
                msg += "- Enter Name Of Route.\n";
                if (ctrl == "")
                    ctrl = "<%=RteName.ClientID%>";
                flag = false;
            }

            if (!CheckControl("<%=ChDay.ClientID%>")) {
                msg += "- Enter Charges for a Day. \n";
                if (ctrl == "")
                    ctrl = "<%=ChDay.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ChSem.ClientID%>")) {
                msg += "- Enter Charges for a Semester. \n";
                if (ctrl == "")
                    ctrl = "<%=ChSem.ClientID%>";
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
            <h2>Route Master </h2>
        </div>
        <table width="100%">
            <tr>
                <td>
        <table width ="100%">
            <tr>
                <th>City Name<span class="required">*</span></th>
                <th>Route Name<span class="required">*</span></th>
                <th>Route Description</th>
                <th>Charges For A Day<span class="required">*</span></th>
                <th>Charges For A Semester<span class="required">*</span></th>

            </tr>
            <tr>
                <td>

                    <asp:DropDownList ID="ddlCitySelect" runat="server">
                    </asp:DropDownList>

                </td>
                <td>
                    <asp:TextBox ID="RteName" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="RteDesc" runat="server" Width="128px"></asp:TextBox>
                </td>
                <td>
                    <cc1:NumericTextBox ID="ChDay" runat="server" Width="86px"></cc1:NumericTextBox>
                </td>
                <td>
                    <cc1:NumericTextBox ID="ChSem" runat="server" Width="114px"></cc1:NumericTextBox>
                </td>
                <td>

                    <asp:Button ID="Save" runat="server" Text="ADD" OnClick="Save_Click" Width="56px"/>

                </td>

            </tr>
        </table>
                    </td>
                </tr>
            <tr>
                <td>

                    <asp:GridView ID="gvShow" runat="server" AutoGenerateColumns="False"  CssClass="gridDynamic" Width="754px" DataKeyNames="RTE_ID" OnRowCommand="gvShow_RowCommand">
                        <Columns>
                            <asp:TemplateField HeaderText="S.No">
                                <ItemTemplate>
                                    <%# ((GridViewRow)Container).RowIndex + 1%>                                .
                                </ItemTemplate>
                                <ItemStyle Width="15px" />
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="City Name" DataField="CITY_NAME" />
                            <asp:BoundField HeaderText="Route Name" DataField="RTE_NAME" />
                            <asp:BoundField HeaderText="Route Description" DataField="RTE_DESC" />
                            <asp:BoundField HeaderText="Charges for a Day" DataField="RATE_DAY" />
                            <asp:BoundField HeaderText="Charges for a Semester" DataField="RATE_SEM" />
                            <asp:CommandField ButtonType="Image" SelectImageUrl="~/Siteimages/edit.gif" ShowSelectButton="True" HeaderText="Modify">
                                        <ItemStyle Width="40px" />
                                    </asp:CommandField>
                            <asp:TemplateField ShowHeader="False" HeaderText="Status">
                                <ItemStyle Width="20px" HorizontalAlign="Right" />
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgAct" runat="server" CausesValidation="false" CommandArgument='<%# Bind("RTE_ID") %>'
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

