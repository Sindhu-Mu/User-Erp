<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="rptSivMain.aspx.cs" Inherits="Inventory_rptSivMain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script lang="javascript" type="text/javascript">
        function CheckControl(ctrl) {
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == "Select" || bTrim(document.getElementById(ctrl).value) == ".") {
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
                return false;
            }
            else
                document.getElementById(ctrl).style.backgroundColor = "#fff";
            return true;
        }
        function VALID() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=ddlStore.ClientID%>")) {
                msg += "- Please Select Store Type\n";
                if (ctrl == "")
                    ctrl = "<%=ddlStore.ClientID%>";
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
            Issue Voucher Report
        </div>
        <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td>
                                <table  id="tblColumns">
                                    <tr>
                                        <th>Store</th>
                                        <th>Institution</th>
                                        <th>Department</th>
                                        <th>Indent
                                        </th>
                                        <th>Date
                                        </th>
                                        <th>From Date
                                        </th>
                                        <th>To Date
                                        </th>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="ddlStore" runat="server" Width="146px" AutoPostBack="true" OnSelectedIndexChanged="ddlStore_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlInstitute" runat="server" AutoPostBack="True" Width="100px" OnSelectedIndexChanged="ddlInstitute_SelectedIndexChanged">
                                            </asp:DropDownList></td>
                                        <td>
                                            <asp:DropDownList ID="ddlDepartment" runat="server" Width="135px">
                                            </asp:DropDownList></td>
                                        <td>
                                            <asp:DropDownList ID="ddlIndent" runat="server" Width="142px">
                                            </asp:DropDownList></td>
                                        <td>
                                            <asp:DropDownList ID="ddlDateRangeFilter" runat="server" Width="135px" AutoPostBack="true" OnSelectedIndexChanged="ddlDateRangeFilter_SelectedIndexChanged">
                                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                <asp:ListItem Value="1" Text="Less"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="Greater"></asp:ListItem>
                                                <asp:ListItem Value="3" Text="Between"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>

                                            <asp:TextBox ID="txtDateMin" runat="server" Width="90px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDateMax" runat="server" Width="90px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnView" runat="server" Text="View" OnClick="btnView_Click" /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="height: 300px; width: 100%; overflow: auto">
                                    <asp:GridView ID="gvData" runat="server" AutoGenerateColumns="false" EmptyDataText="No Record Found...."
                                        CssClass="gridDynamic" Width="97%" DataKeyNames="SIV_ID">
                                        <Columns>
                                            <asp:TemplateField HeaderText="S#">
                                                <ItemTemplate>
                                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                                </ItemTemplate>
                                                <ItemStyle Width="20px" />
                                            </asp:TemplateField>
                                            <asp:HyperLinkField HeaderText="SIV Id" DataTextField="SIV_CAL_ID" DataNavigateUrlFields="SIV_ID"
                                                DataNavigateUrlFormatString="prntSto_SIV.aspx?id={0}" NavigateUrl="prtSIVReport.aspx"
                                                Target="_blank">
                                                <ControlStyle Font-Underline="True" />
                                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                                            </asp:HyperLinkField>
                                            <asp:BoundField HeaderText="Department" DataField="DEPT_VALUE" />
                                            <asp:BoundField HeaderText="Employee" DataField="EMP_NAME" />
                                            <asp:BoundField HeaderText="Date" DataField="INS_DATE"></asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <ajaxToolkit:CalendarExtender ID="cal1" runat="server" TargetControlID="txtDateMin"
                                    Format="dd/MM/yyyy" PopupPosition="TopLeft">
                                </ajaxToolkit:CalendarExtender>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDateMax"
                                    Format="dd/MM/yyyy" PopupPosition="TopLeft">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

