<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Short.master" AutoEventWireup="true" CodeFile="TransportBusProvide.aspx.cs" Inherits="Facility_TransportBusProvide" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentHolder1" Runat="Server">
    <div class="container">
        <div class="heading">
            <h2>Bus Approval</h2>
        </div>
        <table>
            <tr>
                <td>
                    <table>
                        <tr>
                            <th>Pending Bus Approval List</th>
                            </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="gvPendingBusList" runat="server" AutoGenerateColumns="False"  CssClass="gridDynamic">
                                     <Columns>
                            <asp:TemplateField HeaderText="S.No">
                                <ItemTemplate>
                                    <%# ((GridViewRow)Container).RowIndex + 1%>                                .
                                </ItemTemplate>
                                <ItemStyle Width="15px" />
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="City Name" DataField="CITY_NAME" />
                            <asp:BoundField HeaderText="Route Name" DataField="RTE_NAME" />
                            <asp:BoundField HeaderText="Counter" DataField="PENDING" />
                        </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table>
                        <tr>
                            <th>City Name</th>
                            <th>Route Name</th>
                            <th>Count</th>
                        </tr>
                        <tr>
                            <td>
                                <asp:DropDownList ID="ddlCity" runat="server" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged" AutoPostBack="True">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlRte" runat="server" AutoPostBack="True">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlCount" runat="server" AutoPostBack="True">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Button ID="btnView" runat="server" Text="View" OnClick="btnView_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table>
                        <tr>
                            <td>

                                <asp:GridView ID="gvBusProviderList" runat="server" AutoGenerateColumns="False"  CssClass="gridDynamic" DataKeyNames="REG_ROUTE_ID" EmptyDataText="No Record(s) Found">
                                    <Columns>
                            <asp:TemplateField HeaderText="S.No">
                                <ItemTemplate>
                                    <%# ((GridViewRow)Container).RowIndex + 1%>                                .
                                </ItemTemplate>
                                <ItemStyle Width="15px" />
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Enrollment No" DataField="STU_ADM_NO" />
                            <asp:BoundField HeaderText="City Name" DataField="CITY_NAME" />
                            <asp:BoundField HeaderText="Route Name" DataField="RTE_NAME" />
                            <asp:BoundField HeaderText="Stoppage" DataField="STOPPAGE" />
                        </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table>
                        <tr>
                            <th>Bus</th>
                            <td>
                                <asp:DropDownList ID="ddlBusNo" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Button ID="btnAssign" runat="server" Text="Assign" OnClick="btnAssign_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

