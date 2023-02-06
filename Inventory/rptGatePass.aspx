<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="rptGatePass.aspx.cs" Inherits="Inventory_rptGatePass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="heading">
            <h2>Gate-Pass Detail
            </h2>
        </div>
        <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>

                    <table>
                        <tr>
                            <td style="margin-left: 10px;">
                                <table>
                                    <tr>
                                        <th>BY YEAR</th>
                                        <th>BY GATE PASS NO.</th>
                                        <th>BY CARRYING PERSON</th>
                                        <th>BY PASS TYPE</th>
                                        <th>BY VENDOR</th>
                                       <%-- <th>BY SORT</th>--%>

                                    </tr>
                                    <tr>

                                        <td>
                                            <asp:DropDownList ID="ddlYear" runat="server" Width="100px" AutoPostBack="true" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged">
                                              
                                                
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlGatePass" runat="server" Width="150px">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlCarryPers" runat="server" Width="150px">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlPassType" runat="server">
                                                <asp:ListItem Value="1">Returnable</asp:ListItem>
                                                <asp:ListItem Value="2">Non-Returnable</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlVendor" runat="server" Width="250px">
                                            </asp:DropDownList>
                                        </td>
                                       <%-- <td>
                                            <asp:DropDownList ID="ddlSort" runat="server" Width="85px">
                                                <asp:ListItem>All</asp:ListItem>
                                                <asp:ListItem Value="PASS_ID">Pass No.</asp:ListItem>
                                                <asp:ListItem Value="PASS_TYPE">Pass Type</asp:ListItem>
                                                <asp:ListItem Value="ORG_NAME">Recipient</asp:ListItem>
                                                <asp:ListItem Value="PO_DATE">DATE</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>--%>

                                    </tr>
                                    <tr>

                                        <th colspan="3">BY DATE</th>

                                    </tr>
                                    <tr>

                                        <td>
                                            <asp:DropDownList ID="ddlDate" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDate_SelectedIndexChanged">
                                                <asp:ListItem Value="0">All</asp:ListItem>
                                                <asp:ListItem Value="1">Less Than</asp:ListItem>
                                                <asp:ListItem Value="2">Greater Than</asp:ListItem>
                                                <asp:ListItem Value="3">Between</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFromDT" runat="server" Width="90px"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtToDT" runat="server" Width="90px"></asp:TextBox>
                                        </td>

                                        <td>
                                            <asp:Button ID="btnView" runat="server" Text="View" OnClick="btnView_Click"></asp:Button>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <ajaxToolkit:MaskedEditExtender ID="ME1" runat="server" Enabled="True" TargetControlID="txtFromDT"
                                    MaskType="Date" Mask="99/99/9999">
                                </ajaxToolkit:MaskedEditExtender>
                                <ajaxToolkit:MaskedEditExtender ID="ME2" runat="server" TargetControlID="txtToDT"
                                    MaskType="Date" Mask="99/99/9999">
                                </ajaxToolkit:MaskedEditExtender>
                                <ajaxToolkit:CalendarExtender ID="CE1" runat="server" TargetControlID="txtFromDT"
                                    Format="dd/MM/yyyy">
                                </ajaxToolkit:CalendarExtender>
                                <ajaxToolkit:CalendarExtender ID="CalEx2" runat="server" TargetControlID="txtToDT"
                                    Format="dd/MM/yyyy">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="overflow: auto; width: 100%; max-height: 380px">
                                    <asp:GridView ID="gvGatePass" runat="server" Width="98%" DataKeyNames="PASS_ID" ShowFooter="True" ShowHeader="True" AutoGenerateColumns="False"
                                        CssClass="gridDynamic" CellPadding="4" OnRowCommand="gvGatePass_RowCommand">
                                        <Columns>
                                            <asp:TemplateField HeaderText="S.No.">
                                                <ItemTemplate>
                                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                                </ItemTemplate>
                                                <ItemStyle Width="15px"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:HyperLinkField DataNavigateUrlFields="PASS_ID" DataNavigateUrlFormatString="prtGatePass.aspx?id={0}"
                                                DataTextField="PASS_NUMBER" NavigateUrl="prtGatePass.aspx" Target="_blank" HeaderText="PASS NO.">
                                                <ControlStyle Font-Bold="True" Font-Underline="True" ForeColor="Blue"></ControlStyle>
                                                <ItemStyle Width="150px"></ItemStyle>
                                            </asp:HyperLinkField>
                                            <asp:BoundField DataField="IN_DT" DataFormatString="{0:dd/MM/yyyy}" HeaderText="PASS DATE">
                                                <ItemStyle Width="80px"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="AUTH_BY" HeaderText="CREATED  BY">
                                                <ItemStyle Width="170px"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="RECIPNT" HeaderText="RECIPIENT ">
                                                <ItemStyle Width="200px"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:CommandField SelectText="DETAIL" ShowSelectButton="True" ButtonType="Button"
                                                HeaderText="DETAIL">
                                                <ControlStyle CssClass="btnblue"></ControlStyle>
                                                <ItemStyle Width="50px"></ItemStyle>
                                            </asp:CommandField>

                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                        <tr id="trDetail" runat="server" visible="false">
                            <td>
                                <table>
                                    <tr>
                                        <th>Item Detail</th>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:GridView ID="gvItemDetail" runat="server" Width="97%"
                                                AutoGenerateColumns="False" CellPadding="2" CssClass="gridDynamic">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S.No.">
                                                        <ItemTemplate>
                                                            <%# ((GridViewRow)Container).RowIndex + 1%>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="50px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="ITEM_NAME" HeaderText="ITEM NAME" />
                                                    <asp:BoundField DataField="QTY" HeaderText="QUANTITY" />
                                                    <asp:BoundField HeaderText="REMARK" DataField="REMARK" />
                                                    <asp:BoundField HeaderText="SENDER" DataField="SENDER" />
                                                </Columns>

                                            </asp:GridView>
                                        </td>
                                    </tr>

                                </table>
                            </td>
                        </tr>

                    </table>

                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
    </div>
</asp:Content>

