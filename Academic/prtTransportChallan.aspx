<%@ Page Language="C#" AutoEventWireup="true" CodeFile="prtTransportChallan.aspx.cs" Inherits="Academic_prtTransportChallan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>:: Transport Fee Challan ::</title>
</head>
<body>
		<form id="Form1"  runat="server">	
		<table cellpadding="0" cellspacing="0" border="0" style="font-family:Book Antiqua;font-size:17px;margin:0;height:1100px;width:800px" >	
		<tr><td>	
		<table   cellpadding="2" cellspacing="0" border="0">
            <tr>
                <td >
                  <table cellpadding="2" cellspacing="0" border="0" width="100%"><tr><td>Challan.No.<asp:Label ID="lblCno" runat="server"></asp:Label></td><td></td><td align="right">Bank Copy</td></tr></table></td>
            </tr>
            	<tr>
					<td align="center">
                      
                                <span style="font-size: 18px;"><strong><asp:Label ID="lblBank1" runat="server" ></asp:Label></strong></span></td>
				</tr>
            <tr>
                <td align="center">&nbsp;</td>
            </tr>
            <tr>
                <td><table cellpadding="2" cellspacing="0"  width="100%" >
                    <tr>
                        <td style="border: black 1px solid;">
                            Branch</td>
                        
                        <td style="border: black 1px solid;">
                            <asp:Label ID="lblBranch1" runat="server" ></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="border: black 1px solid;">
                            Account Name</td>
                        <td  style="border: black 1px solid;">
                            <span style="font-size:14px"><asp:Label ID="lblAccountName1" runat="server" ></asp:Label></span></td>
                    </tr>
                    <tr>
                        <td style="border: black 1px solid;">
                            Account No.</td> 
                        <td  style="border: black 1px solid;">
                            <strong><span style="font-size: 18px;"><asp:Label ID="lblAccountNo1" runat="server" ></asp:Label></span></strong></td>
                    </tr>
                    <tr>
                        <td >
                        </td>
                      
                        <td >
                            &nbsp;</td>
                    </tr>
                </table>
                    
                </td>
            </tr>
            <tr><td align="right"><table cellpadding="2" cellspacing="0" width="80%" >
                <tr>
                    <td>
                        Date of Submission</td>
                    <td style="border: black 1px solid;">
                        &nbsp;&nbsp;</td>
                    <td style="border: black 1px solid;">
                        &nbsp;&nbsp;</td>
                    <td style="border: black 1px solid;">
                        &nbsp;&nbsp;</td>
                    <td style="border: black 1px solid;">
                        &nbsp;&nbsp;</td>
                    <td style="border: black 1px solid;">
                        &nbsp;&nbsp;</td>
                    <td style="border: black 1px solid;">
                        &nbsp;&nbsp;</td>
                    <td style="border: black 1px solid;">
                        &nbsp;&nbsp;</td>
                    <td style="border: black 1px solid;">
                        &nbsp;&nbsp;</td>
                </tr>
            </table>
            </td></tr>
				<tr>
					<td colspan="4">
					<table cellpadding="2" cellspacing="0"  width="100%">
                        <tr>
                            <td align="center" colspan="4" nowrap="nowrap">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4" nowrap="nowrap">
                                <asp:Label ID="lblINs" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"
                                    Font-Italic="True" Font-Size="Medium"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4" nowrap="nowrap">
                                &nbsp;</td>
                        </tr>
                    <tr><td >
                        Enrollment No.</td><td style="width: 10px">:</td><td colspan="2">
                        <asp:Label ID="lblEnrollment1" runat="server" Font-Bold="True" ></asp:Label></td>
                    </tr>
                    <tr><td >
                        Student Name</td><td>:</td><td colspan="2">
                        <asp:Label ID="lblStuName1" runat="server" Font-Bold="False"></asp:Label></td>
                    </tr>
                        <tr>
                            <td >
                                Father Name</td>
                            <td>
                                :</td>
                            <td colspan="2">
                                
                                    <asp:Label ID="lblFather1" runat="server" Font-Bold="False"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                                Semester</td>
                            <td>
                                :</td>
                            <td colspan="2">
                                <asp:Label ID="lblSem" runat="server"></asp:Label>&nbsp;</td>
                        </tr>
                    </table>
                    </td>
				</tr>
				<tr><td><table cellpadding="2" cellspacing="0" border="0" width="100%"><tr><td width="35%">
				<table cellpadding="2" cellspacing="0" border="1" width="100%" ><tr><td>Denomination</td><td>NO.</td><td style="width:80px">Rs.</td></tr>
                    <tr>
                        <td>
                            2000</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            500</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            100</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            50</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            20</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            10</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            Coins</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            Total</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table></td>
				<td width="3%"></td>
				<td width="50%" valign="top"><table cellpadding="2" cellspacing="0" border="0" width="100%"><tr><td>Name of Bank</td><td style="width: 150px">
                    &nbsp;</td>
				</tr>
                    <tr>
                        <td>
                            Chq./DD No.</td>
                        <td><table cellpadding="2" cellspacing="0" width="100%" ><tr><td style="border: black 1px solid;">
                &nbsp;</td><td style="border: black 1px solid;">
               &nbsp;</td><td style="border: black 1px solid;">
                &nbsp;</td><td style="border: black 1px solid;">
                &nbsp;</td><td style="border: black 1px solid;">
                &nbsp;</td><td style="border: black 1px solid;">
                &nbsp;</td></tr></table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Date Of Chq/DD</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            Amount</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height: 15px">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Transport Fee</td>
                        <td >
                            <asp:Label ID="lblTFee1" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            Fine Amt.</td>
                        <td >
                            <asp:Label ID="lblFine1" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            TOTAL AMT.</td>
                        <td >
                            <asp:Label ID="lblTotal1" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label></td>
                    </tr>
                </table>
				</td></tr></table></td></tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
				<tr>
					<td>
                        Amount in Words:-................................................................................................................................</td>
				</tr>
            <tr>
                <td>&nbsp;...............................................................................................................................</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
				<tr>
					<td >
					<table cellpadding="2" cellspacing="0" width="100%" border="0"  >
                        <tr>
                            <td style="width:120px;border: black 1px solid;" >
                                Signature</td>
                            <td style="border: black 1px solid;" >
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 120px;border: black 1px solid; height: 16px;">
                                Name of Depositor</td>
                            <td style="border: black 1px solid; height: 16px;">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width:120px;border: black 1px solid;">
                                Address</td>
                            <td style="border: black 1px solid;">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 120px;border: black 1px solid;">
                                Contact No.</td>
                            <td style="border: black 1px solid;">
                                &nbsp;</td>
                        </tr>
					</table>
					</td>
				</tr>
            <tr>
                <td align="center" >
                    &nbsp;</td>
            </tr>
				<tr><td align="center" style="border-top: black thin solid; "> For Bank Use Only</td></tr>
				<tr><td>
                    &nbsp;</td></tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
				<tr><td><table cellpadding="2" cellspacing="0" border="0" width="100%"><tr><td>Acknowledgement</td><td align="right">Cashier/Officer</td></tr></table></td></tr>
				</table></td>
		 <td style="width:10px">&nbsp;<img src="../images/bar.jpg" alt="" />&nbsp;</td>
	<td><table cellpadding="2" cellspacing="0" border="0">
            <tr>
                <td >
                  <table cellpadding="2" cellspacing="0" border="0" width="100%"><tr><td>Challan.No.<asp:Label ID="lblChNo2" runat="server"></asp:Label></td><td></td><td align="right">
                      University Copy</td></tr></table></td>
            </tr>
            	<tr>
					<td align="center">
                      
                                <span style="font-size: 16px;"><strong><asp:Label ID="lblBank2" runat="server" ></asp:Label></strong></span></td>
				</tr>
            <tr>
                <td align="center">&nbsp;</td>
            </tr>
            <tr>
               <td><table cellpadding="2" cellspacing="0"  width="100%" >
                    <tr>
                        <td  style="border: black 1px solid;">
                            Branch</td>
                        
                        <td style="border: black 1px solid;">
                           <asp:Label ID="lblBranch2" runat="server" ></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="border: black 1px solid;" >
                            Account Name</td>
                        <td  style="border: black 1px solid;">
                            <span style="font-size:14px"><asp:Label ID="lblAccountName2" runat="server" ></asp:Label></span></td>
                    </tr>
                    <tr>
                        <td style="border: black 1px solid;">
                            Account No.</td> 
                        <td  style="border: black 1px solid;">
                            <strong><span style="font-size: 18px;"><asp:Label ID="lblAccountNo2" runat="server" ></asp:Label></span></strong></td>
                    </tr>
                    <tr>
                        <td >
                        </td>                     
                        <td >
                            &nbsp;</td>
                    </tr>
                </table>
                    
                </td>
            </tr>
            <tr><td align="right"><table cellpadding="2" cellspacing="0" width="80%" ><tr><td>Date of Submission</td><td style="border: black 1px solid;">&nbsp;&nbsp;</td><td style="border: black 1px solid;">
                &nbsp;&nbsp;</td><td style="border: black 1px solid;">
                &nbsp;&nbsp;</td><td style="border: black 1px solid;">
                &nbsp;&nbsp;</td><td style="border: black 1px solid;">
                &nbsp;&nbsp;</td><td style="border: black 1px solid;">
                &nbsp;&nbsp;</td><td style="border: black 1px solid;">
                &nbsp;&nbsp;</td><td style="border: black 1px solid;">
                &nbsp;&nbsp;</td></tr></table></td></tr>
				<tr>
					<td colspan="4">
					<table cellpadding="2" cellspacing="0"  width="100%">
                        <tr>
                            <td align="center" colspan="4" nowrap="nowrap">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4" nowrap="nowrap">
                                <asp:Label ID="lblIns2" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"
                                    Font-Italic="True" Font-Size="Medium"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4" nowrap="nowrap">
                                &nbsp;&nbsp;</td>
                        </tr>
                    <tr><td nowrap>
                        Enrollment No.</td><td style="width: 10px">:</td><td colspan="2">
                        <asp:Label ID="lblEnrollment2" runat="server" Font-Bold="True"></asp:Label></td>
                    </tr>
                    <tr><td nowrap>
                        Student Name</td><td>:</td><td colspan="2">
                       
                            <asp:Label ID="lblStuName2" runat="server" Font-Bold="False"></asp:Label></td>
                    </tr>
                        <tr>
                            <td nowrap="nowrap">
                                Father Name</td>
                            <td>
                                :</td>
                            <td colspan="2">
                                
                                    <asp:Label ID="lblFather2" runat="server" Font-Bold="False"></asp:Label></td>
                        </tr>
                       <tr>
                            <td>
                                Semester </td>
                            <td>
                                :</td>
                            <td colspan="2">
                                <asp:Label ID="lblSem2" runat="server"></asp:Label>&nbsp;</td>
                        </tr>
                    </table>
                    </td>
				</tr>
				<tr><td><table cellpadding="2" cellspacing="0" border="0" width="100%"><tr><td style="width:35%">
				<table cellpadding="2" cellspacing="0" border="1" width="100%" ><tr><td>Denomination</td><td>NO.</td><td style="width:80px">Rs.</td></tr>
                    <tr>
                        <td>
                            2000</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            500</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            100</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            50</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            20</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            10</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            Coins</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            Total</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table></td>
				<td width="3%"></td>
				<td width="50%" valign="top"><table cellpadding="2" cellspacing="0" border="0" width="100%"><tr><td>Name of Bank</td><td style="width: 150px">
                    &nbsp;</td>
				</tr>
                    <tr>
                        <td>
                            Chq./DD No.</td>
                        <td><table cellpadding="2" cellspacing="0" width="100%" ><tr><td style="border: black 1px solid;">
                &nbsp;</td><td style="border: black 1px solid;">
               &nbsp;</td><td style="border: black 1px solid;">
                &nbsp;</td><td style="border: black 1px solid;">
                &nbsp;</td><td style="border: black 1px solid;">
                &nbsp;</td><td style="border: black 1px solid;">
                &nbsp;</td></tr></table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Date Of Chq/DD</td>
                        <td >
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Amount</td>
                        <td >
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height: 15px">
                        </td>
                    </tr>
                   
                    <tr>
                        <td>
                            Transport Fee</td>
                        <td >
                            <asp:Label ID="lblTFee2" runat="server"></asp:Label></td>
                    </tr>
                      <tr>
                        <td>
                            Fine Amt.</td>
                        <td >
                            <asp:Label ID="lblTFine2" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            TOTAL AMT.</td>
                        <td >
                            <asp:Label ID="lblTotal2" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label></td>
                    </tr>
                </table>
				</td></tr></table></td></tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
				<tr>
					<td>
                        Amount in Words:-..............................................................................................................................</td>
				</tr>
            <tr>
                <td>
                    ..............................................................................................................................</td>
            </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
				
						<tr>
					<td >
					<table cellpadding="2" cellspacing="0" width="100%" border="0"  >
                        <tr>
                            <td style="width:120px;border: black 1px solid;" >
                                Signature</td>
                            <td style="border: black 1px solid;" >
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 120px;border: black 1px solid; height: 16px;">
                                Name of Depositor</td>
                            <td style="border: black 1px solid; height: 16px;">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width:120px;border: black 1px solid;">
                                Address</td>
                            <td style="border: black 1px solid;">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 120px;border: black 1px solid;">
                                Contact No.</td>
                            <td style="border: black 1px solid;">
                                &nbsp;</td>
                        </tr>
					</table>
					</td>
				</tr>
					
            <tr>
                <td align="center" >
                    &nbsp;</td>
            </tr>
				<tr><td style="border-top: black thin solid;" align="center"> For Bank Use Only</td></tr>
				<tr><td>
                    &nbsp;</td></tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
				<tr><td><table cellpadding="2" cellspacing="0" border="0" width="100%"><tr><td>Acknowledgement</td><td align="right">Cashier/Officer</td></tr></table></td></tr>
				</table></td>
				<td style="width:10px">&nbsp;
       <img src="../images/bar.jpg" alt="" id="IMG1" />&nbsp;</td>
		<td><table  cellpadding="2" cellspacing="0" border="0">
            <tr>
                <td >
                  <table cellpadding="2" cellspacing="0" border="0" width="100%"><tr><td>Challan.No.<asp:Label ID="lblChNo3" runat="server"></asp:Label></td><td></td><td align="right">
                      Student Copy</td></tr></table></td>
            </tr>
            	<tr>
					<td align="center">
                      
                                <span style="font-size: 16px;"><strong><asp:Label ID="lblBank3" runat="server" ></asp:Label></strong></span></td>
				</tr>
            <tr>
                <td align="center">&nbsp;</td>
            </tr>
            <tr>
                <td><table cellpadding="2" cellspacing="0"  width="100%" >
                    <tr>
                        <td style="border: black 1px solid;">
                            Branch</td>
                       
                        <td style="border: black 1px solid;">
                            <asp:Label ID="lblBranch3" runat="server" ></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="border: black 1px solid;">
                            Account Name</td> 
                        <td  style="border: black 1px solid;">
                            <span style="font-size:10pt"><asp:Label ID="lblAccountName3" runat="server" ></asp:Label></span></td>
                    </tr>
                    <tr>
                        <td style="border: black 1px solid;">
                            Account No.</td>
                        <td  style="border: black 1px solid;">
                            <strong><span style="font-size: 18px;"><asp:Label ID="lblAccountNo3" runat="server" ></asp:Label></span></strong></td>
                    </tr>
                    <tr>
                        <td >
                        </td>                       
                        <td >
                            &nbsp;</td>
                    </tr>
                </table>
                    
                </td>
            </tr>
            <tr><td align="right"><table cellpadding="2" cellspacing="0" width="80%" ><tr><td>Date of Submission</td><td style="border: black 1px solid;">&nbsp;&nbsp;</td><td style="border: black 1px solid;">
                &nbsp;&nbsp;</td><td style="border: black 1px solid;">
                &nbsp;&nbsp;</td><td style="border: black 1px solid;">
                &nbsp;&nbsp;</td><td style="border: black 1px solid;">
                &nbsp;&nbsp;</td><td style="border: black 1px solid;">
                &nbsp;&nbsp;</td><td style="border: black 1px solid;">
                &nbsp;&nbsp;</td><td style="border: black 1px solid;">
                &nbsp;&nbsp;</td></tr></table></td></tr>
				<tr>
					<td colspan="4">
					<table cellpadding="2" cellspacing="0" width="100%">
                        <tr>
                            <td align="center" colspan="4" nowrap="nowrap">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4" nowrap="nowrap">
                                <asp:Label ID="lblIns3" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"
                                    Font-Italic="True" Font-Size="Medium"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4" nowrap="nowrap">
                                &nbsp;</td>
                        </tr>
                    <tr><td nowrap>
                        Enrollment No.</td><td style="width: 10px">:</td><td colspan="2">
                        <asp:Label ID="lblEnrollment3" runat="server" Font-Bold="True" ></asp:Label></td>
                    </tr>
                    <tr><td nowrap>
                        Student Name</td><td>:</td><td colspan="2">
                        <span >
                            <asp:Label ID="lblStuName3" runat="server" Font-Bold="False"></asp:Label></span></td>
                    </tr>
                        <tr>
                            <td nowrap="nowrap">
                                Father Name</td>
                            <td>
                                :</td>
                            <td colspan="2">
                                
                                    <asp:Label ID="lblFather3" runat="server" Font-Bold="False"></asp:Label></td>
                        </tr>
                       <tr>
                            <td>
                                Semester </td>
                            <td>
                                :</td>
                            <td colspan="2">
                                <asp:Label ID="lblSem3" runat="server"></asp:Label>&nbsp;</td>
                        </tr>
                    </table>
                    </td>
				</tr>
				<tr><td><table cellpadding="2" cellspacing="0" border="0" width="100%"><tr><td width="35%">
				<table cellpadding="2" cellspacing="0" border="1" width="100%" ><tr><td>Denomination</td><td>NO.</td><td style="width:80px">Rs.</td></tr>
                    <tr>
                        <td>
                            2000</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            500</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            100</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            50</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            20</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            10</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            Coins</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            Total</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table></td>
				<td width="3%"></td>
				<td width="40%" valign="top"><table cellpadding="2" cellspacing="0" border="0" width="100%"><tr><td>Name of Bank</td><td style="width: 150px">
                    &nbsp;</td>
				</tr>
                    <tr>
                        <td>
                            Chq./DD No.</td>
                        <td ><table cellpadding="2" cellspacing="0" width="100%" ><tr><td style="border: black 1px solid;">
                &nbsp;</td><td style="border: black 1px solid;">
               &nbsp;</td><td style="border: black 1px solid;">
                &nbsp;</td><td style="border: black 1px solid;">
                &nbsp;</td><td style="border: black 1px solid;">
                &nbsp;</td><td style="border: black 1px solid;">
                &nbsp;</td></tr></table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Date Of Chq/DD</td>
                        <td >
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            Amount</td>
                        <td >
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height: 15px">
                        </td>
                    </tr>
                 
                    <tr>
                        <td>
                            Transport Fee</td>
                        <td >
                            <asp:Label ID="lblTfee3" runat="server"></asp:Label></td>
                    </tr>
                     <tr>
                        <td>
                            Fine Amt.</td>
                        <td >
                            <asp:Label ID="lblTFine3" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            TOTAL AMT.</td>
                        <td >
                            <asp:Label ID="lblTotal3" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label></td>
                    </tr>
                </table>
				</td></tr></table></td></tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
				<tr>
					<td>
                        Amount in Words:-...................................................................................................................................</td>
				</tr>
            <tr>
                <td>&nbsp;..................................................................................................................................</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
				<tr>
					<td >
					<table cellpadding="2" cellspacing="0" width="100%" border="0"  >
                        <tr>
                            <td style="width:120px;border: black 1px solid;" >
                                Signature</td>
                            <td style="border: black 1px solid;" >
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 120px;border: black 1px solid; height: 16px;">
                                Name of Depositor</td>
                            <td style="border: black 1px solid; height: 16px;">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width:120px;border: black 1px solid;">
                                Address</td>
                            <td style="border: black 1px solid;">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 120px;border: black 1px solid;">
                                Contact No.</td>
                            <td style="border: black 1px solid;">
                                &nbsp;</td>
                        </tr>
					</table>
					</td>
				</tr>
            <tr>
                <td align="center" >
                    &nbsp;</td>
            </tr>
				<tr><td align="center" style="border-top: black thin solid; height: 6px;"> For Bank Use Only</td></tr>
				<tr><td>
                    &nbsp;</td></tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
				<tr><td><table cellpadding="2" cellspacing="0" border="0" width="100%"><tr><td>Acknowledgement</td><td align="right">Cashier/Officer</td></tr></table></td></tr>
				</table></td></tr></table>
		
			</form>
	</body>
</html>
