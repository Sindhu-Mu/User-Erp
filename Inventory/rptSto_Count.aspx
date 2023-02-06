<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="rptSto_Count.aspx.cs" Inherits="Inventory_rptSto_Count" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="heading">
            <h2>Store Counting Report
            </h2>
        </div>
        <div>
            <table id="tblColumns">
                <tr>
                    <td>
                        <table>
                            <tr>
                                <th>Store Wise</th>
                            </tr>
                            <tr>
                                <td style="vertical-align: top">
                                    <asp:UpdatePanel ID="UP1" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <div style="height: 250px; overflow: auto; width: 100%">
                                                <asp:GridView ID="gvStore" runat="server" Width="90%" AutoGenerateColumns="False"
                                                    GridLines="None" CellPadding="3" EmptyDataText="No Record Found." CssClass="gridDynamic">
                                                    <Columns>

                                                        <asp:BoundField DataField="STO_NAME" HeaderText="Store" />

                                                        <asp:ButtonField CommandName="REQ" DataTextField="GRN" Text="Button" HeaderText="GRN">
                                                            <ItemStyle HorizontalAlign="right" />
                                                        </asp:ButtonField>

                                                        <asp:ButtonField CommandName="FAN" DataTextField="IND" Text="Button" HeaderText="Indent">
                                                            <ItemStyle HorizontalAlign="right" />
                                                        </asp:ButtonField>

                                                        <asp:ButtonField CommandName="RFQ" DataTextField="SIV" Text="Button" HeaderText="SIV">
                                                            <ItemStyle HorizontalAlign="right" />
                                                        </asp:ButtonField>


                                                    </Columns>
                                                    <SelectedRowStyle BackColor="#FFC0C0" />
                                                </asp:GridView>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="vertical-align: top" colspan="2">
                        <table>
                            <tr>
                                <th>Category Wise</th>
                            </tr>
                            <tr>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <div style="height: 250px; overflow: auto; width: 100%">
                                                <asp:GridView ID="gvCategory" runat="server" AutoGenerateColumns="False" GridLines="None"
                                                    CellPadding="3" EmptyDataText="No Record Found." CssClass="gridDynamic" Width="90%">
                                                    <Columns>

                                                        <asp:BoundField DataField="CAT_NAME" HeaderText="Category" />

                                                        <asp:ButtonField CommandName="REQ" DataTextField="GRN" Text="Button" HeaderText="GRN">
                                                            <ItemStyle HorizontalAlign="right" />
                                                        </asp:ButtonField>

                                                        <asp:ButtonField CommandName="FAN" DataTextField="IND" Text="Button" HeaderText="Indent">
                                                            <ItemStyle HorizontalAlign="right" />
                                                        </asp:ButtonField>

                                                        <asp:ButtonField CommandName="RFQ" DataTextField="SIV" Text="Button" HeaderText="SIV">
                                                            <ItemStyle HorizontalAlign="right" />
                                                        </asp:ButtonField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                    </td>

                </tr>
                <tr>
                    <td>
                        <table>
                            <tr>
                                <th>SubCategory Wise</th>
                            </tr>
                            <tr>
                                <td style="vertical-align: top">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <div style="height: 250px; overflow: auto; width: 100%">
                                                <asp:GridView ID="gvSubCategory" runat="server" Width="90%" AutoGenerateColumns="False"
                                                    GridLines="None" CellPadding="3" EmptyDataText="No Record Found." CssClass="gridDynamic">
                                                    <Columns>

                                                        <asp:BoundField DataField="SUB_CAT_NAME" HeaderText="SubCategory">
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:BoundField>

                                                        <asp:ButtonField CommandName="REQ" DataTextField="GRN" Text="Button" HeaderText="GRN">
                                                            <ItemStyle HorizontalAlign="right" />
                                                        </asp:ButtonField>

                                                        <asp:ButtonField CommandName="FAN" DataTextField="IND" Text="Button" HeaderText="Indent">
                                                            <ItemStyle HorizontalAlign="right" />
                                                        </asp:ButtonField>

                                                        <asp:ButtonField CommandName="RFQ" DataTextField="SIV" Text="Button" HeaderText="SIV">
                                                            <ItemStyle HorizontalAlign="right" />
                                                        </asp:ButtonField>
                                                    </Columns>
                                                    <SelectedRowStyle BackColor="#FFC0C0" />
                                                </asp:GridView>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="vertical-align: top" colspan="2">
                        <table>
                            <tr>
                                <th>Item Wise</th>
                            </tr>
                            <tr>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <div style="height: 250px; overflow: auto; max-width: 500px">
                                                <asp:GridView ID="gvItem" runat="server" AutoGenerateColumns="False" GridLines="None"
                                                    EmptyDataText="No Record Found." CssClass="gridDynamic">
                                                    <Columns>

                                                        <asp:BoundField DataField="ITEM_NAME" HeaderText="Item">
                                                            <ItemStyle Width="30px" />
                                                        </asp:BoundField>

                                                        <asp:ButtonField CommandName="REQ" DataTextField="GRN" Text="Button" HeaderText="GRN">
                                                            <ItemStyle HorizontalAlign="right" />
                                                        </asp:ButtonField>

                                                        <asp:ButtonField CommandName="FAN" DataTextField="IND" Text="Button" HeaderText="Indent">
                                                            <ItemStyle HorizontalAlign="right" />
                                                        </asp:ButtonField>

                                                        <asp:ButtonField CommandName="RFQ" DataTextField="SIV" Text="Button" HeaderText="SIV">
                                                            <ItemStyle HorizontalAlign="right" />
                                                        </asp:ButtonField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

