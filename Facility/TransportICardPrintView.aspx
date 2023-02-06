<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="TransportICardPrintView.aspx.cs" Inherits="Facility_TransportICardPrintView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class ="container">
        <div class="heading">
            <h2>Transport Bus I-Card Print</h2>
        </div>
        <table>
            <tr>
                <td>
                    <table>
                        <tr>
                            <th>Enrollment No</th>
                            <th>City</th>
                            <th>Route Name</th>
                            <th>Bus No</th>
                            <th>Print Type</th>
                            <th>Counter</th>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtEnroll" runat="server" Width="200px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlCity" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged">
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
                                <asp:RadioButtonList ID="rdlPrintType" runat="server">
                                    <asp:ListItem Text="Original" Value="1" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="Duplicate" Value="2"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlCount" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td><asp:TextBox ID="txtData" runat="server" Visible="false"></asp:TextBox></td>
                            <td>
                                <asp:Button ID="btnView" runat="server" Text="View" OnClick="btnView_Click1" />
                            </td>
                            <td>
                                <asp:Button ID="btnPrint" runat="server" Text="Print" OnClick="btnPrint_Click"  PostBackUrl="TransportPrintBusCard.aspx" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                        <ajaxToolkit:AutoCompleteExtender ID="autoComplete2" runat="server" EnableCaching="true"
                                    TargetControlID="txtEnroll" ServicePath="~/AutoComplete.asmx" ServiceMethod="GetStudentList"
                                    MinimumPrefixLength="1" ContextKey="1" CompletionSetCount="12" CompletionInterval="500">
                                </ajaxToolkit:AutoCompleteExtender>
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
                                <asp:GridView ID="gvPrint" runat="server" AutoGenerateColumns="False"  CssClass="gridDynamic">
                        <Columns>
                            <asp:TemplateField HeaderText="S.No">
                                <ItemTemplate>
                                    <%# ((GridViewRow)Container).RowIndex + 1%>                                .
                                </ItemTemplate>
                                <ItemStyle Width="15px" />
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Enrollment" DataField="ENROLLMENT_NO" />
                            <asp:BoundField HeaderText="Student Name" DataField="STU_FULL_NAME" />
                            <asp:BoundField HeaderText="City" DataField="CITY_NAME" />
                            <asp:BoundField HeaderText="Route Name" DataField="RTE_NAME" />
                            <asp:BoundField HeaderText="Stoppage" DataField="STOPPAGE" />
                            <asp:BoundField HeaderText="Bus No" DataField="BUS_ID" />
                            <asp:HyperLinkField Text="Print" DataNavigateUrlFormatString="TransportPrintBusCard.aspx?REG_ROUTE_ID={0}"
                                        DataNavigateUrlFields="REG_ROUTE_ID" />

                        </Columns>
                    </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

