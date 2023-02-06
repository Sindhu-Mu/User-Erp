<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="rptRefund.aspx.cs" Inherits="Finance_rptRefund" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div style="overflow: auto; width: 100%; height: 400px">
        <table>
            <tr>
                <td>
                    <asp:GridView ID="GridView1" runat="server" Width="97%" CssClass="gridDynamic"
                        AutoGenerateColumns="False">
                        <Columns>
                            <asp:TemplateField HeaderText="S.No." ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Enrollment" DataField="ENROLLMENT_NO" />
                            <asp:BoundField HeaderText="Name" DataField="STU_FULL_NAME" />
                            <asp:BoundField HeaderText="Refund Amount" DataField="FEE_RFD_MODE_AMT" />
                            <asp:BoundField HeaderText="Refund Date" DataField="FEE_RFD_DT" />
                            <asp:BoundField HeaderText="Refund By" DataField="FEE_RFD_BY" />
                            <asp:HyperLinkField DataNavigateUrlFields="FEE_RFD_RECEIPT_NO" Text="Print"
                                DataNavigateUrlFormatString="~/Finance\prtFeeRefundSlip.aspx?FEE_RFD_RECEIPT_NO={0}" HeaderText="Print Receipt"
                                NavigateUrl="~/Finance\prtFeeRefundSlip.aspx" Target="_blank,fullscreen=yes" />

                        </Columns>


                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>

</asp:Content>

