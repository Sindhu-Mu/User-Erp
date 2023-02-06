<%@ Page Language="C#" AutoEventWireup="true" CodeFile="prtFeeRefundSlip.aspx.cs" Inherits="Finance_prtFeeRefundSlip" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Fee Refund Receipt</title>
</head>
<body onload="window.print();">
    <form id="form1" runat="server">
    <div>
    <table style="font-family: Tahoma; font-size: 17px; margin-top: 40px; border-collapse: collapse">
            <tr>
                <td style="vertical-align:top;">
                    <table style="height: 800px; width: 480px;" border="1">
                        <tr>
                            <td colspan="2">
                                Receipt &nbsp;No.<asp:Label ID="lblReceiptNo" runat="server" Font-Bold="True" /></td>
                            <td colspan="2" style="text-decoration: underline; font-weight: bold; text-align: right">
                                Student Copy</td>
                        </tr>
                        <tr>
                            <td style="height: 50px" align="center" colspan="4">
                                <span class="style3">MANGALAYATAN UNIVERSITY</span><br />
                                P.O.-Beswan,Aligrah-202145(INDIA)</td>
                        </tr>
                        <tr>
                            <td>
                                Institute</td>
                            <td>
                                <asp:Label ID="lblIns" runat="server"></asp:Label></td>
                            <td>
                                Date</td>
                            <td>
                                <asp:Label ID="lbldate" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                                Course</td>
                            <td>
                                <asp:Label ID="lblCourse" runat="server" /></td>
                            <td>
                                Branch</td>
                            <td>
                                <asp:Label ID="lblBranch" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>
                                Enrollment No.</td>
                            <td>
                                <asp:Label ID="lblAdmNo" runat="server" Font-Bold="True" /></td>
                            <td>
                                Semester</td>
                            <td>
                                <asp:Label ID="lblSem" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                                Student Name</td>
                            <td colspan="3">
                                <asp:Label ID="lblName" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>
                                Rupees</td>
                            <td colspan="3">
                                <asp:Label ID="lblNet" runat="server" Font-Bold="true" /></td>
                        </tr>
                        <tr>
                            <td colspan="4" valign="top">
                                <asp:GridView ID="gvReceive1" runat="server" AutoGenerateColumns="False" Width="99%"
                                    ShowFooter="True">
                                    <Columns>
                                        <asp:TemplateField HeaderText="S#">
                                            <ItemTemplate>
                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="FEE_MAIN_HEAD_NAME" FooterText="TOTAL" HeaderText="HEAD" />
                                        <asp:BoundField DataField="RECEIVED" DataFormatString="{0:N2}" HeaderText="AMOUNT" />
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" class="style2">
                                PAYMENT MODE DETAIL</td>
                        </tr>
                        <tr>
                            <td colspan="4" style="text-align: left" valign="top">
                                <asp:GridView ID="gvPayMode1" runat="server" Font-Size="15px" AutoGenerateColumns="False"
                                    Width="100%" ShowFooter="True" EmptyDataText="Cash Deposit">
                                    <Columns>
                                        <asp:TemplateField HeaderText="S#">
                                            <ItemTemplate>
                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="PAY_MODE_VALUE" HeaderText="MODE TYPE" />
                                        <asp:BoundField HeaderText="MODE NO" DataField="FEE_RFD_MODE_NO" />
                                        <asp:BoundField DataField="FEE_RFD_MODE_DT" HeaderText="DATE" DataFormatString="{0:dd/MM/yyyy}">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="BANK_VALUE" HeaderText="BANK" FooterText="TOTAL:-">
                                            <FooterStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="FEE_RFD_MODE_AMT" HeaderText="AMOUNT" DataFormatString="{0:N2}"
                                            HtmlEncode="False">
                                            <FooterStyle HorizontalAlign="Right" />
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Remark</td>
                            <td colspan="3">
                                <asp:Label ID="lblRemark1" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:Label ID="lblNote" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            
                            <td colspan="4" style="text-align: right">
                                Refunded By<br />
                                <asp:Label ID="lblBy1" runat="server" /></td>
                        </tr>
                    </table>
                </td>
                <td style="width: 10px">
                    &nbsp;</td>
                <td valign="top">
                    <table style="height: 800px; width: 480px" border="1">
                        <tr>
                            <td colspan="2">
                                Receipt &nbsp;No.
                                <asp:Label ID="lblReceiptNo1" runat="server" Font-Bold="True" /></td>
                            <td colspan="2" style="text-decoration: underline; font-weight: bold; text-align: right">
                                File Copy</td>
                        </tr>
                        <tr>
                            <td style="height: 50px" align="center" colspan="4">
                                <span class="style3">MANGALAYATAN UNIVERSITY</span><br />
                                P.O.-Beswan,Aligrah-202145(INDIA)<span class="style2"></span></td>
                        </tr>
                        <tr>
                            <td>
                                Institute</td>
                            <td>
                                <asp:Label ID="lblIns1" runat="server"></asp:Label></td>
                            <td>
                                Date</td>
                            <td>
                                <asp:Label ID="lblDate1" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                                Course</td>
                            <td>
                                <asp:Label ID="lblCourse1" runat="server" /></td>
                            <td>
                                Branch</td>
                            <td>
                                <asp:Label ID="lblBranch1" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>
                                Enrollment No.</td>
                            <td>
                                <asp:Label ID="lblADMNo1" runat="server" Font-Bold="True" /></td>
                            <td>
                                Semester</td>
                            <td>
                                <asp:Label ID="lblSem1" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                                Student Name</td>
                            <td colspan="3">
                                <asp:Label ID="lblAppName" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>
                                Rupees</td>
                            <td colspan="3">
                                <asp:Label ID="lblNet1" runat="server" Font-Bold="true" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" valign="top">
                                <asp:GridView ID="gvReceive2" runat="server" ShowFooter="True" AutoGenerateColumns="False"
                                    Width="99%">
                                    <Columns>
                                        <asp:TemplateField HeaderText="S#">
                                            <ItemTemplate>
                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="FEE_MAIN_HEAD_NAME" FooterText="TOTAL" HeaderText="HEAD" />
                                        <asp:BoundField DataField="RECEIVED" DataFormatString="{0:N2}" HeaderText="AMOUNT" />
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" class="style2">
                                PAYMENT MODE DETAIL</td>
                        </tr>
                        <tr>
                            <td colspan="4" style="text-align: left" valign="top">
                                <asp:GridView ID="gvPayMode2" runat="server" Font-Size="15px" AutoGenerateColumns="False"
                                    Width="100%" ShowFooter="True" EmptyDataText="Cash Deposit">
                                    <Columns>
                                        <asp:TemplateField HeaderText="S#">
                                            <ItemTemplate>
                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="PAY_MODE_VALUE" HeaderText="MODE TYPE" />
                                        <asp:BoundField HeaderText="MODE NO" DataField="FEE_RFD_MODE_NO" />
                                        <asp:BoundField DataField="FEE_RFD_MODE_DT" HeaderText="DATE" DataFormatString="{0:dd/MM/yyyy}">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="BANK_VALUE" HeaderText="BANK" FooterText="TOTAL:-">
                                            <FooterStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="FEE_RFD_MODE_AMT" HeaderText="AMOUNT" DataFormatString="{0:N2}"
                                            HtmlEncode="False">
                                            <FooterStyle HorizontalAlign="Right" />
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Remark</td>
                            <td colspan="3">
                                <asp:Label ID="lblRemark2" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:Label ID="lblNote2" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            
                            <td colspan="4" style="text-align: right">
                                Refunded By<br />
                                <asp:Label ID="lblBy2" runat="server" /></td>
                        </tr>
                    </table>
                </td>
                <td style="width: 10px">
                    &nbsp;</td>
                <td valign="top">
                    <table style="height: 800px; width: 480px" border="1">
                        <tr>
                            <td colspan="2">
                                Receipt &nbsp;No.
                                <asp:Label ID="lblReceipt3" runat="server" Font-Bold="True" /></td>
                            <td colspan="2" style="text-decoration: underline; font-weight: bold; text-align: right">
                                Account Copy</td>
                        </tr>
                        <tr>
                            <td style="height: 50px" align="center" colspan="4">
                                <span class="style3">MANGALAYATAN UNIVERSITY</span><br />
                                P.O.-Beswan,Aligrah-202145(INDIA)</td>
                        </tr>
                        <tr>
                            <td>
                                Institute</td>
                            <td>
                                <asp:Label ID="lblIns3" runat="server"></asp:Label></td>
                            <td>
                                Date</td>
                            <td>
                                <asp:Label ID="lblDate3" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                                Course</td>
                            <td>
                                <asp:Label ID="lblCourse2" runat="server" /></td>
                            <td>
                                Branch</td>
                            <td>
                                <asp:Label ID="lblBranch2" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>
                                Enrollment No.</td>
                            <td>
                                <asp:Label ID="lblREG2" runat="server" Font-Bold="True" /></td>
                            <td>
                                Semester</td>
                            <td>
                                <asp:Label ID="lblSem2" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                                Student Name</td>
                            <td colspan="3">
                                <asp:Label ID="lblName2" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>
                                Rupees</td>
                            <td colspan="3">
                                <asp:Label ID="lblNet2" runat="server" Font-Bold="True" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" valign="top">
                                <asp:GridView ID="gvReceive3" runat="server" ShowFooter="True" AutoGenerateColumns="False"
                                    Width="99%">
                                    <Columns>
                                        <asp:TemplateField HeaderText="S#">
                                            <ItemTemplate>
                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="FEE_MAIN_HEAD_NAME" FooterText="TOTAL" HeaderText="HEAD" />
                                        <asp:BoundField DataField="RECEIVED" DataFormatString="{0:N2}" HeaderText="AMOUNT" />
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                PAYMENT MODE DETAIL</td>
                        </tr>
                        <tr>
                            <td colspan="4" style="text-align: left" valign="top">
                                <asp:GridView ID="gvPayMode3" runat="server" Font-Size="15px" AutoGenerateColumns="False"
                                    Width="100%" ShowFooter="True" EmptyDataText="Cash Deposit">
                                    <Columns>
                                        <asp:TemplateField HeaderText="S#">
                                            <ItemTemplate>
                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="PAY_MODE_VALUE" HeaderText="MODE TYPE" />
                                        <asp:BoundField HeaderText="MODE NO" DataField="FEE_RFD_MODE_NO" />
                                        <asp:BoundField DataField="FEE_RFD_MODE_DT" HeaderText="DATE" DataFormatString="{0:dd/MM/yyyy}">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="BANK_VALUE" HeaderText="BANK" FooterText="TOTAL:-">
                                            <FooterStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="FEE_RFD_MODE_AMT" HeaderText="AMOUNT" DataFormatString="{0:N2}"
                                            HtmlEncode="False">
                                            <FooterStyle HorizontalAlign="Right" />
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Remark</td>
                            <td colspan="3">
                                <asp:Label ID="lblRemark3" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:Label ID="lblNote3" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            
                            <td colspan="4" style="text-align: right">
                                Refunded By<br />
                                <asp:Label ID="lblBy3" runat="server" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
