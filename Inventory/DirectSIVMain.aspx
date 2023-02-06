<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="DirectSIVMain.aspx.cs" Inherits="Inventory_DirectSIVMain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="heading">
            <h2>Issue Voucher</h2>
        </div>

        <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <th>Indent No.
                                        </th>
                                        <th>Indent Date/Time</th>
                                        <th>Issue to Department
                                        </th>
                                        <th>Indentor</th>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblIndentNo" runat="server"></asp:Label></td>
                                        <td>
                                            <asp:Label ID="lblDateTime" runat="server"></asp:Label></td>
                                        <td>
                                            <asp:Label ID="lblDept" runat="server"></asp:Label></td>
                                        <td>
                                            <asp:Label ID="lblIndenter" runat="server"></asp:Label></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="gvItem" runat="server" AutoGenerateColumns="False" CssClass="gridDynamic" DataKeyNames="ITEM_ID" Width="97%">
                                    <Columns>
                                        <asp:TemplateField HeaderText="S#">
                                            <ItemTemplate>
                                                <%# ((GridViewRow)Container).RowIndex + 1%>.
                                            </ItemTemplate>
                                            <ItemStyle Width="10px" />
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Item Name" DataField="ITEM_NAME" ReadOnly="True" HtmlEncode="false" />
                                        <asp:BoundField HeaderText="Req. Qty" DataField="REQ_QTY" ReadOnly="True">
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Qty Issued">
                                            <ItemStyle HorizontalAlign="Right" />
                                            <ItemTemplate>
                                                <cc1:NumericTextBox ID="txtIssdQty" runat="server" Width="85px" AllowDecimal="false" Text='<%# Bind("ISD_QTY") %>' Enabled='<%#Eval("IS_CNG_ALWD")%>'></cc1:NumericTextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btnBrown" OnClick="btnSubmit_Click" />

                                <asp:HiddenField ID="hfAll_IDs" runat="server" />
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
    </div>
</asp:Content>

