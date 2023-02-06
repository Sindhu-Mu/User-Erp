<%@ Page Language="C#" AutoEventWireup="true" CodeFile="prtFeeReceipt.aspx.cs" Inherits="Printing_FeeReceipt" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Payment Receipt</title>
    
    <style type="text/css">
        .style2
        {font-size: 12px;
            text-align: center;          
           
        }
        .style3
        {  font-size: 20px;
            text-decoration: underline;
        }      
        
    </style>
 
</head>
<body  onload="window.print();"  >
    <form id="form1" runat="server">   
        <table style=" font-family: 'Book Antiqua'; font-size: 13px; margin: 0px;border-collapse: collapse" cellpadding="0" cellspacing="0">
            <tr>
                <td valign="top">
                    <table style="height:800px;width:480px;border-collapse: collapse" border="1" cellpadding="1" cellspacing="0">
                        <tr>
                            <td colspan="2">
                                Receipt &nbsp;No.<asp:Label ID="lblReceiptNo" runat="server" Font-Bold="True" /></td>
                            <td colspan="2" style="text-decoration: underline; font-weight: bold; text-align: right">
                                Student Copy</td>
                        </tr>
                        <tr><td colspan="4">
                             <div style="height: 75px; padding-left:30px;">
                <div style="float: left; width: 20%;">                    
                    <img src="../Siteimages/PrintLogo.jpg" style="width:30%;" alt="" />
                </div>
                <div style="text-align: center;vertical-align:bottom; float: right; width: 80%;">
                    <span class="style3">Mangalayatan University</span><br />
                    <span class="style2">Mathura-Aligarh Highway ,Beswan                       
                        Aligarh, Uttar Pradesh-202146,India<br />
                       Email:account@mangalayatan.edu.in                      
                    </span>
                </div>
                <div style="clear: both;"></div>
            </div></td>
                        </tr>
                        <tr>
                           <td>
                                Enrollment No</td>
                            <td >
                                <asp:Label ID="lblAdmNo" runat="server" Font-Bold="True" /></td>
                            <td>
                                Date</td>
                            <td>
                                <asp:Label ID="lbldate" runat="server"></asp:Label></td>
                        </tr>
                      
                        <tr>
                            <td>
                                Program</td>
                            <td>
                                <asp:Label ID="lblCourse" runat="server" /></td>
                            <td>
                                Branch</td>
                            <td>
                                <asp:Label ID="lblBranch" runat="server" /></td>
                        </tr>
                     
                        <tr>
                            <td>
                                Received From</td>
                            <td colspan="3">
                                <asp:Label ID="lblName" runat="server" /></td>
                        </tr>
                          <tr>
                             <td>
                                Father Name</td>
                            <td >
                                <asp:Label ID="lblFatherName" runat="server"></asp:Label></td>
                              <td>
                                Semester</td>
                            <td>
                                <asp:Label ID="lblSem" runat="server" /></td>
                        </tr>
                        
                         
                        <tr>
                            <td colspan="4" id="trPaid" runat="server" style="height:200px;" valign="top">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Rupees/Dollar</td>
                            <td colspan="3">
                                <asp:Label ID="lblNet" runat="server" Font-Bold="true" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" class="style2">
                                PAYMENT MODE DETAIL</td>
                        </tr>
                        <tr>
                            <td colspan="4" style="text-align: left">
                                <asp:GridView ID="gvPayMode1" runat="server"  AutoGenerateColumns="False" Width="100%"
                                    ShowFooter="True" EmptyDataText="Cash Deposit">
                                    <Columns>
                                        <asp:TemplateField HeaderText="S#">
                                            <ItemTemplate>
                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="PAY_MODE_VALUE" HeaderText="Mode" />
                                        <asp:BoundField HeaderText="Transaction No" DataField="RCV_TRAN_MODE_NO" />
                                        <asp:BoundField DataField="RCV_TRAN_MODE_DT" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy}"
                                            HtmlEncode="False"></asp:BoundField>
                                        <asp:BoundField DataField="BANK_NAME" HeaderText="Bank" FooterText="Total:-">
                                            <FooterStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="RCV_TRAN_MODE_AMT" HeaderText="Amount" DataFormatString="{0:N2}"
                                            HtmlEncode="False">
                                            <FooterStyle HorizontalAlign="Right" />
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr><td>Remark</td><td colspan="3">
                            <asp:Label ID="lblRemark1" runat="server" ></asp:Label></td></tr>
                        <tr>
                            <td colspan="4">
                                <asp:Label ID="lblNote" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: left">
                                Due Amount<br />
                                <asp:Label ID="lblDue1" runat="server"  /></td>
                            <td colspan="2" style="text-align: right">
                                Collected By<br />
                                <asp:Label ID="lblBy1" runat="server" /></td>
                        </tr>
                    </table>
                </td>
                <td style="width: 10px">
                    &nbsp;</td>
                <td valign="top">
                    <table style="height:800px;width:480px;border-collapse: collapse" border="1" cellpadding="2" cellspacing="0">
                        <tr>
                            <td colspan="2">
                                Receipt &nbsp;No.
                                <asp:Label ID="lblReceiptNo1" runat="server" Font-Bold="True" /></td>
                            <td colspan="2" style="text-decoration: underline; font-weight: bold; text-align: right">
                                File Copy</td>
                        </tr>
                        <tr>
                             <td colspan="4">
                             <div style="height: 75px; padding-left:30px;">
                <div style="float: left; width: 20%;">                    
                    <img src="../Siteimages/PrintLogo.jpg" style="width:30%;" alt="" />
                </div>
                <div style="text-align: center;vertical-align:bottom; float: right; width: 80%;">
                    <span class="style3">Mangalayatan University</span><br />
                    <span class="style2">Mathura-Aligarh Highway ,Beswan                       
                        Aligarh, Uttar Pradesh-202146,India<br />
                       Email:account@mangalayatan.edu.in                      
                    </span>
                </div>
                <div style="clear: both;"></div>
            </div></td>
                        
                        </tr>
                        <tr>
                              <td>
                               Enrollment No
                            </td>
                            <td >
                                <asp:Label ID="lblADMNo1" runat="server" Font-Bold="True" /></td>
                            
                            <td>
                                Date</td>
                            <td>
                                <asp:Label ID="lblDate1" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                          
                        </tr>
                        <tr>
                            <td>
                                Program</td>
                            <td>
                                <asp:Label ID="lblCourse1" runat="server" /></td>
                            <td>
                                Branch</td>
                            <td>
                                <asp:Label ID="lblBranch1" runat="server" /></td>
                        </tr>
                       
                        <tr>
                            <td>
                                Received From</td>
                            <td colspan="3">
                                <asp:Label ID="lblAppName" runat="server" /></td>
                        </tr>
                         <tr>
                            <td>
                                Father Name</td>
                            <td >
                                <asp:Label ID="lblFatherName1" runat="server"></asp:Label></td>
                                <td>
                                Semester</td>
                            <td>
                                <asp:Label ID="lblSem1" runat="server" /></td>
                        </tr>
                       
                        <tr>
                            <td colspan="4" id="tdMain" runat="server" style="height:200px;" valign="top">
                            </td>
                        </tr>
                         <tr>
                            <td>
                                Rupees/Dollar</td>
                            <td colspan="3">
                                <asp:Label ID="lblNet1" runat="server" Font-Bold="true" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" class="style2">
                                PAYMENT MODE DETAIL</td>
                        </tr>

                        <tr>
                            <td colspan="4" style="text-align: left">
                                <asp:GridView ID="gvPayMode2" runat="server"  AutoGenerateColumns="False" Width="100%"
                                    ShowFooter="True" EmptyDataText="Cash Deposit">
                                    <Columns>
                                        <asp:TemplateField HeaderText="S#">
                                            <ItemTemplate>
                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="PAY_MODE_VALUE" HeaderText="Mode" />
                                        <asp:BoundField HeaderText="Transaction No" DataField="RCV_TRAN_MODE_NO" />
                                        <asp:BoundField DataField="RCV_TRAN_MODE_DT" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy}"
                                            HtmlEncode="False"></asp:BoundField>
                                        <asp:BoundField DataField="BANK_NAME" HeaderText="Bank" FooterText="Total:-">
                                            <FooterStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="RCV_TRAN_MODE_AMT" HeaderText="Amount" DataFormatString="{0:N2}"
                                            HtmlEncode="False">
                                            <FooterStyle HorizontalAlign="Right" />
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                          <tr><td>Remark</td><td colspan="3">
                            <asp:Label ID="lblRemark2" runat="server" ></asp:Label></td></tr>
                        <tr>
                            <td colspan="4">
                                <asp:Label ID="lblNote2" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: left">
                                Due Amount<br />
                                <asp:Label ID="lblDue2" runat="server"  /></td>
                            <td colspan="2" style="text-align: right">
                                Collected By<br />
                                <asp:Label ID="lblBy2" runat="server" /></td>
                        </tr>
                    </table>
                </td>
                <td style="width: 10px">
                    &nbsp;</td>
                <td valign="top">
                    <table style="height:800px;width:480px;border-collapse: collapse" border="1" cellpadding="2" cellspacing="0">
                        <tr>
                            <td colspan="2">
                                Receipt &nbsp;No.
                                <asp:Label ID="lblReceipt3" runat="server" Font-Bold="True" /></td>
                            <td colspan="2" style="text-decoration: underline; font-weight: bold; text-align: right">
                                Account Copy</td>
                        </tr>
                        <tr>
                          <td colspan="4">
                             <div style="height: 75px; padding-left:30px;">
                <div style="float: left; width: 20%;">                    
                    <img src="../Siteimages/PrintLogo.jpg" style="width:30%;" alt="" />
                </div>
                <div style="text-align: center;vertical-align:bottom; float: right; width: 80%;">
                    <span class="style3">Mangalayatan University</span><br />
                    <span class="style2">Mathura-Aligarh Highway ,Beswan                      
                        Aligarh, Uttar Pradesh-202146,India<br />
                       Email:account@mangalayatan.edu.in                      
                    </span>
                </div>
                <div style="clear: both;"></div>
            </div></td>
                        </tr>
                       
                        <tr>
                            <td>
                                Enrollment NO</td>
                            <td >
                                <asp:Label ID="lblREG2" runat="server" Font-Bold="True" /></td>
                            <td>
                                Date</td>
                            <td>
                                <asp:Label ID="lblDate3" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                           
                        </tr>
                        <tr>
                            <td>
                                Program</td>
                            <td>
                                <asp:Label ID="lblCourse2" runat="server" /></td>
                            <td>
                                Branch</td>
                            <td>
                                <asp:Label ID="lblBranch2" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>
                                Received From</td>
                            <td colspan="3">
                                <asp:Label ID="lblName2" runat="server" /></td>
                        </tr>
                         <tr>
                            <td>
                                Father Name</td>
                            <td >
                                <asp:Label ID="lblFatherName2" runat="server"></asp:Label></td>
                                <td>
                                Semester</td>
                            <td>
                                <asp:Label ID="lblSem2" runat="server" /></td>
                        </tr>
                        
                        <tr>
                            <td colspan="4" id="tdMain3" runat="server" style="height:200px;" valign="top">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Rupees/Dollar</td>
                            <td colspan="3">
                                <asp:Label ID="lblNet2" runat="server" Font-Bold="True" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" class="style2" >
                                PAYMENT MODE DETAIL</td>
                        </tr>
                        <tr>
                            <td colspan="4" style="text-align: left">
                                <asp:GridView ID="gvPayMode3" runat="server"  AutoGenerateColumns="False" Width="100%"
                                    ShowFooter="True" EmptyDataText="Cash Deposit">
                                    <Columns>
                                        <asp:TemplateField HeaderText="S#">
                                            <ItemTemplate>
                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                       <asp:BoundField DataField="PAY_MODE_VALUE" HeaderText="Mode" />
                                        <asp:BoundField HeaderText="Transaction No" DataField="RCV_TRAN_MODE_NO" />
                                        <asp:BoundField DataField="RCV_TRAN_MODE_DT" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy}"
                                            HtmlEncode="False"></asp:BoundField>
                                        <asp:BoundField DataField="BANK_NAME" HeaderText="Bank" FooterText="Total:-">
                                            <FooterStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="RCV_TRAN_MODE_AMT" HeaderText="Amount" DataFormatString="{0:N2}"
                                            HtmlEncode="False">
                                            <FooterStyle HorizontalAlign="Right" />
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                          <tr><td>Remark</td><td colspan="3">
                            <asp:Label ID="lblRemark3" runat="server" ></asp:Label></td></tr>
                        <tr>
                            <td colspan="4">
                                <asp:Label ID="lblNote3" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: left">
                                Due Amount<br />
                                <asp:Label ID="lblDue3" runat="server"  /></td>
                            <td colspan="2" style="text-align: right">
                                Collected By<br />
                                <asp:Label ID="lblBy3" runat="server" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
