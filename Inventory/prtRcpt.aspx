<%@ Page Language="C#" AutoEventWireup="true" CodeFile="prtRcpt.aspx.cs" Inherits="Inventory_prtRcpt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    
    <form id="form1" runat="server">
        <table style="width: 650px; font-family: Tahoma; font-size: 10pt;" cellpadding="3px" cellspacing="0" border="0">
            <tr>
                <td colspan="6" style="text-align:center; font-weight: bold;">
                    Mangalayatan University
                </td>
            </tr>
           <tr>
                <td colspan="6" style="text-align:center;font-size:smaller">
                    learn today to lead tomorrow
                </td>
            </tr>
            <tr>
                <td colspan="6" style="text-align:center;font-size:smaller">
                    
                </td>
            </tr>
           
            <tr>
                <td colspan="6" style="text-align: center">
                    <%--<span style="font-size: 12pt">--%>T-Shirt Receiving
        <%--<asp:Label ID="lblhead" runat="server" Text="(Student Copy)"></asp:Label></span>--%>
                </td>
            </tr>
            <tr>
                <td>Issue No
                </td>
                <td>:</td>
                <td>
                    <asp:Label ID="lblBillNo" runat="server" /></td>
                <td>Date/Time</td>
                <td>:</td>
                <td>
                    <asp:Label ID="lbldate" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>Enrollment No</td>
                <td>:</td>
                <td>
                    <asp:Label ID="lblReg_No" runat="server" Font-Bold="False"
                        Font-Names="Arial" Font-Size="Large"
                        Style="font-size: small; font-weight: 700" /></td>
                <td>Form No</td>
                <td>:</td>
                <td>
                    <asp:Label ID="lblFormNo" runat="server" Font-Bold="true" /></td>
                <%--<td colspan="3">
                <asp:Label ID="lblCR_NO" runat="server" style="font-style: italic" ></asp:Label>
            </td>--%>
            </tr>
            <tr>
                <td>Student
Name</td>
                <td>:</td>
                <td colspan="4">
                    <asp:Label ID="lblStu_Name" runat="server" /></td>
            </tr>
            <tr>
                <td>Course</td>
                <td>:</td>
                <td>
                    <asp:Label ID="lblCourse" runat="server" />
                </td>
                <td>Branch</td>
                <td>:</td>
                <td>
                    <asp:Label ID="lblBranch" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Contact No</td>
                <td>:</td>
                <td>
                    <asp:Label ID="lblContact" runat="server"></asp:Label>
                </td>
                <td>Item
                </td>
                <td>:
                </td>
                <td>
                    <asp:Label ID="lblItem" runat="server"></asp:Label>
                </td>
                <%--<td>
                    <asp:Label ID="lblAmt" runat="server"></asp:Label>
            </td>--%>
                <%-- <td>
                :</td>
            <td>
                <asp:Label ID="lblAmount" runat="server" ></asp:Label>
            </td>--%>
            </tr>
            <tr>
                <td>Address</td>
                <td>:</td>
                <td colspan="4">
                    <asp:Label ID="lbladdress" runat="server" /></td>
            </tr>

            <%-- <tr id="trDetail" runat="server">
            <td colspan="6" style="text-align: left" >
        
                <asp:Label ID="lblStatus" runat="server" 
                    style="font-weight: 700; font-style: italic;"></asp:Label>
                <i>&nbsp;a sum of&nbsp; </i> <span style="font-weight:bold"><i>Rs. 
                <asp:Label ID="lblNet" runat="server" CssClass="txtno"  />
    &nbsp;Only</i></span><i>&nbsp; for the Student Gown .</i>&nbsp;</td>
        </tr>--%>
            <tr>
                <td colspan="6" style="text-align: left">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="4" style="text-align: left; padding-left: 50px">Student Signature


                   
                </td>

                <td colspan="2" style="text-align: right">Issued By<br />
                    <asp:Label ID="lblemp_name" runat="server" /></td>
            </tr>
            <tr>
                <td colspan="6">&nbsp;</td>
            </tr>
            <tr id="trCoupon" runat="server">
                <td id="tdMain" runat="server" colspan="6"></td>
            </tr>
            <tr>
                <td colspan="6">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="6">

                    <p class="style1">
                        Congratulation, we are wising you a bright future.
                    </p>
                </td>
            </tr>
            <%--<tr id="trOffice" runat="server">
                <td colspan="6">
                    <table style="font-family: Tahoma; font-size: 10pt;" cellpadding="3px" width="100%" cellspacing="0" border="0">
                        <tr>
                            <td colspan="6" style="text-align: center">&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="6" style="text-align: center">
                                <span style="font-size: 12pt">T-Shirt Receiving (Office Copy)</span></td>
                        </tr>
                        <tr>
                            <td>Issue No
                            </td>
                            <td>:</td>
                            <td>
                                <asp:Label ID="lblBillNo2" runat="server" /></td>
                            <td>Date/Time</td>
                            <td>:</td>
                            <td>
                                <asp:Label ID="lblDate2" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>Enrollment No</td>
                            <td>:</td>
                            <td>
                                <asp:Label ID="lblRegNo2" runat="server" Font-Bold="False"
                                    Font-Names="Arial" Font-Size="Large"
                                    Style="font-size: small; font-weight: 700" /></td>

                            <td>Form No</td>
                            <td>:</td>
                            <td>
                                <asp:Label ID="lblFomNo2" runat="server" Font-Bold="true" /></td>
                        </tr>
                        <tr>
                            <td>Student
Name</td>
                            <td>:</td>
                            <td colspan="4">
                                <asp:Label ID="lblName2" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>Course</td>
                            <td>:</td>
                            <td>
                                <asp:Label ID="lblCourse2" runat="server" />
                            </td>
                            <td>Branch</td>
                            <td>:</td>
                            <td>
                                <asp:Label ID="lblBranch2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Contact No</td>
                            <td>:</td>
                            <td>
                                <asp:Label ID="lblContact2" runat="server"></asp:Label>
                            </td>
                            <td>Item
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblItem2" runat="server"></asp:Label>
                            </td>
                            <%-- <td>
                    Deposit Amount</td>
            <td>
                :</td>
            <td>
                <asp:Label ID="lblAmount2" runat="server" ></asp:Label>
            </td>--%>
                        <%--</tr>
                        <tr>
                            <td>Address</td>
                            <td>:</td>
                            <td colspan="4">
                                <asp:Label ID="lblAdd2" runat="server" /></td>
                        </tr>--%>

                        <%--<tr id="tr1" runat="server">
            <td colspan="6" style="text-align: left" >
        
                <i><b>Deposit</b>&nbsp;a sum of&nbsp; </i> <span style="font-weight:bold"><i>Rs. 
                <asp:Label ID="lblNet2" runat="server"  />
    &nbsp;Only</i></span><i>&nbsp; for the Student Gown .</i>&nbsp;</td>
        </tr>--%>
                        <%--<tr>
                            <td colspan="4" style="text-align: left; padding-left: 50px">Student Signature
                                                  
                            </td>
                            <td colspan="2" style="text-align: right">Issued By<br />
                                <asp:Label ID="lblemp2" runat="server" /></td>
                        </tr>
                    </table>
                </td>
            </tr>--%>
        </table>
    </form>
</body>
</html>
