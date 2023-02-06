<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintSalarySlip.aspx.cs" Inherits="Common_PrintSalarySlip" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <script lang="javascript" type="text/javascript">
        function popElectricity() {
           // var url = '../facility/electricityBill.aspx?' + document.getElementById("<%=hfParam.ClientID%>").value;
        //window.open(url, '_blank', 'width=625,height=310, scrollbars=1, left=100');
    }
    function popArrear() {

       // window.open('arrear.aspx?' + document.getElementById("<%=mmm.ClientID%>").value + '-' + document.getElementById("<%=yym.ClientID%>").value, '_blank', 'width=775, scrollbars=1, left=100');
    }
    </script>
</head>
<body onload="window.print();" bgcolor="#f5f5f5" style="background-image: url('../muimages/bk.png'); background-repeat: no-repeat; background-position: center;">
    <form id="form1" runat="server">
        <asp:Label ID="lblMsg" runat="server" CssClass="redText"></asp:Label>
<table id ="tblPay" runat ="server" border="0" width="100%" cellpadding="0" style="border-collapse: collapse">

	<tr>
		<td  >&nbsp;</td>
		<td>
				<table border="0" width="100%" cellpadding="0" style="border-collapse: collapse; font-family:Times New Roman; font-size: 12px; ">
					<tr>
						<td height="20" width="100%" align="center" >
                            <img src="../Siteimages/mu_logo.jpg" style="height: 100px" width="300" alt="" /><br />
                            <strong>Extended NCR, Aligarh-Mathura Highway, Beswan, Aligarh-202145, India<br />
                                Tel: 0571-3258592-93 Fax: 05722-254220 Website: www.mangalayatan.in&nbsp;</strong></td>
						
					</tr>
	
					
					</table>
		</td>
		<td style="width: 173px"  >&nbsp;</td>
	</tr>
	<tr>
		<td  >&nbsp;</td>
		<td>
           <div style ="padding-left:20px;padding-right:20px">
           <table border="0" cellpadding="0" style="border-collapse: collapse; font-family: Tahoma;
                        font-size: 11px" width="100%">
                    
                        <tr >
                        <td id="SlipMonth" runat ="server" height="20" width="100%" align="center" style="font-family: Arial Black; font-size: 14px" >
						
						
						<span style="font-size: 13pt"> P R O V I S I O N A L - P A Y&nbsp; S L I P
						</span><br />
						<i><b><font face="Times New Roman">for the month ending 
						January, 9999</font></b></i><br /><br />&nbsp;
						
						</td>
                        </tr>	
						</table>
           </div>
				<table border="0" width="100%" cellpadding="0" style="border-collapse: collapse; font-family: Tahoma; font-size: 11px; ">
					<tr>
						<td id="personalInfo" runat ="server"  height="20" width="50%" align="left" style="padding-left:20px; font-family:Tahoma; font-size:11px">
						<b>Code No :</b> #<asp:Label ID="lblEmplCode" runat="server" CssClass="mactive"></asp:Label><br />
						<b>Name : </b>
                            <asp:Label ID="lblEmpName" runat="server" CssClass="mactive"></asp:Label><br />
						<b>Designation :</b> 
                            <asp:Label ID="lblDesignation" runat="server" CssClass="mactive"></asp:Label><br />
						<b>Department :</b> 
                            <asp:Label ID="lblDepartment" runat="server" CssClass="mactive"></asp:Label><br />
                            </td>
						
						<td id="acInfo" runat ="server" height="20" width="50%" align="right" style="padding-right:20px; font-family:Tahoma; font-size:11px">
						<b>Days :</b> 
                            <asp:Label ID="lblNoOfDays" runat="server" CssClass="mactive"></asp:Label><br />
						<b>A/C No : </b>
                            <asp:Label ID="lblBanckACNo" runat="server" CssClass="mactive"></asp:Label><br />
						<b>EPF No :</b> 
                            <asp:Label ID="lblEPFNo" runat="server" CssClass="mactive"></asp:Label><br />
						<b>&nbsp;PAN No:</b><asp:Label ID="lblPan" runat="server" CssClass="mactive"></asp:Label></td>
					</tr>
					</table>
		</td>
		<td style="width: 173px"  >&nbsp;</td>
	</tr>
	<tr>
		<td  >&nbsp;</td>
		<td style ="padding-left:20px;padding-right:20px">
		<hr color="#CC6600" size="1" width ="100%">
		</td>
		<td style="width: 173px"  >&nbsp;</td>
	</tr>
	<tr>
		<td  >&nbsp;</td>
		<td width="800">
				<table border="0" width="100%" cellpadding="0" style="border-collapse: collapse; font-family: Tahoma; font-size: 11px; ">
					<tr>
						<td height="20" width="30%" align="left" style="font-weight: bold;  padding-left:20px">EARNINGS</td>
						<td height="20" width="20%" align="right" style="font-weight: bold;  padding-right:20px">INR</td>
						<td height="20" width="30%" align="left" style="font-weight: bold;  padding-left:20px">DEDUCTIONS</td>
						<td height="20" width="20%" align="right" style="font-weight: bold;  padding-right:20px">INR</td>
					</tr>
					</table>
		</td>
		<td style="width: 173px"  >&nbsp;</td>
	</tr>
	<tr>
		<td  >&nbsp;</td>
		<td style ="padding-left:20px;padding-right:20px">
		<hr color="#CC6600" size="1">
		</td>
		<td style="width: 173px"  >&nbsp;</td>
	</tr>
	<tr>
		<td  >&nbsp;</td>
		<td >
				<table border="0" width="100%" cellpadding="0" style="border-collapse: collapse">
					<tr>
						<td id="ear" runat ="server"  width="50%" valign="top">
				<table border="0" width="100%" cellpadding="0" style="border-collapse: collapse; font-family: Tahoma; font-size: 11px; ">
					<tr>
						<td height="20" width="30%" align="left" style="padding-left:20px; font-family:Tahoma; font-size:11px">
						BASIC SALARY</td>
						<td height="20" width="20%" align="right" style="padding-right:20px; font-family:Tahoma; font-size:11px">
						</td>
					</tr>
					<tr>
						<td height="20" width="30%" align="left" style="padding-left:20px; font-family:Tahoma; font-size:11px">
						DA</td>
						<td height="20" width="20%" align="right" style="padding-right:20px; font-family:Tahoma; font-size:11px">
						</td>
					</tr>
					<tr>
						<td height="20" width="30%" align="left" style="padding-left:20px; font-family:Tahoma; font-size:11px">
						CCA</td>
						<td height="20" width="20%" align="right" style="padding-right:20px; font-family:Tahoma; font-size:11px">
						</td>
					</tr>
					<tr>
						<td height="20" width="30%" align="left" style="padding-left:20px; font-family:Tahoma; font-size:11px">
						SBCA</td>
						<td height="20" width="20%" align="right" style="padding-right:20px; font-family:Tahoma; font-size:11px">
						</td>
					</tr>
					<tr>
						<td height="20" width="30%" align="left" style="padding-left:20px; font-family:Tahoma; font-size:11px">
						HRA</td>
						<td height="20" width="20%" align="right" style="padding-right:20px; font-family:Tahoma; font-size:11px">
						</td>
					</tr>
					</table>
						</td>
						<td id="ded" runat ="server" width="50%" valign="top">
				<table border="0" width="100%" cellpadding="0" style="border-collapse: collapse; font-family: Tahoma; font-size: 11px; ">
					<tr>
						<td height="20" width="30%" align="left" style="padding-left:20px; font-family:Tahoma; font-size:11px">
						PF</td>
						<td height="20" width="20%" align="right" style="padding-right:20px; font-family:Tahoma; font-size:11px">
						</td>
					</tr>
					<tr>
						<td height="20" width="30%" align="left" style="padding-left:20px; font-family:Tahoma; font-size:11px">
						LIC</td>
						<td height="20" width="20%" align="right" style="padding-right:20px; font-family:Tahoma; font-size:11px">
						</td>
					</tr>
					<tr>
						<td height="20" width="30%" align="left" style="padding-left:20px; font-family:Tahoma; font-size:11px">&nbsp;</td>
						<td height="20" width="20%" align="right" style="padding-right:20px; font-family:Tahoma; font-size:11px">&nbsp;</td>
					</tr>
					<tr>
						<td height="20" width="30%" align="left" style="padding-left:20px; font-family:Tahoma; font-size:11px">&nbsp;</td>
						<td height="20" width="20%" align="right" style="padding-right:20px; font-family:Tahoma; font-size:11px">&nbsp;</td>
					</tr>
					<tr>
						<td height="20" width="30%" align="left" style="padding-left:20px; font-family:Tahoma; font-size:11px">&nbsp;</td>
						<td height="20" width="20%" align="right" style="padding-right:20px; font-family:Tahoma; font-size:11px">&nbsp;</td>
					</tr>
					</table>
						</td>
					</tr>
				</table>
		</td>
		<td style="width: 173px"  >&nbsp;</td>
	</tr>
	<tr>
		<td  >&nbsp;</td>
		<td style ="padding-left:20px;padding-right:20px">
		<hr color="#CC6600" size="1">
		</td>
		<td style="width: 173px"  >&nbsp;</td>
	</tr>
	<tr>
		<td  >&nbsp;</td>
		<td width="800">
		<table border="0" width="100%" cellpadding="0" style="border-collapse: collapse">
			<tr>
				<td width="50%" valign="top">
				<table border="0" width="100%" cellpadding="0" style="border-collapse: collapse; font-family: Tahoma; font-size: 11px; ">
					<tr>
						<td height="20" width="30%" align="left" style="padding-left:20px; font-family:Tahoma; font-size:11px">TOTAL EARNINGS [A]</td>
						<td id="totear" runat ="server" height="20" width="20%" align="right" style="padding-right:20px; font-family:Tahoma; font-size:11px">
						</td>
					</tr>
					</table>
				</td>
				<td width="50%" valign="top">
				<table border="0" width="100%" cellpadding="0" style="border-collapse: collapse; font-family: Tahoma; font-size: 11px; ">
					<tr>
						<td height="20" width="30%" align="left" style="padding-left:20px; font-family:Tahoma; font-size:11px">TOTAL DEDUCTIONS [B]</td>
						<td id="totded" runat ="server" height="20" width="20%" align="right" style="padding-right:20px; font-family:Tahoma; font-size:11px">
						</td>
					</tr>
					</table>
				</td>
			</tr>
		</table>
		</td>
		<td style="width: 173px"  >&nbsp;</td>
	</tr>
	<tr>
		<td>&nbsp;</td>
		<td style ="padding-left:20px;padding-right:20px">
		<hr color="#CC6600" size="1">
		</td>
		<td style="width: 173px">&nbsp;</td>
	</tr>
	<tr>
		<td>&nbsp;</td>
		<td id="netSal" runat ="server" style="padding-left:20px;font-family: Tahoma; font-size: 11px">
		<b>NET PAY (Payroll Clearance) : [A] - [B] = Rs. 
            <br />
		</b><%--transferred to employee A/c with <asp:Label ID="lblBank" runat="server" Font-Italic="true" /> --%></td>
		<td style="width: 173px">&nbsp;</td>
	</tr>
   
	
	<tr>
		<td>&nbsp;</td>
		<td style="padding-left:20px; font-family:Tahoma; font-size:11px"><asp:Label ID="lblRemark" runat="server" CssClass="mactive" Font-Bold="True" ForeColor="#804000" /></td>
		<td style="width: 173px">&nbsp;</td>
	</tr>
   
     <tr>
       <td colspan="3">&nbsp;</td>
        
    </tr>
     <tr>
       <td colspan="3">&nbsp;</td>
        
    </tr>
     <tr>
       <td colspan="3">&nbsp;</td>
        
    </tr>
     <tr>
       <td colspan="3">&nbsp;</td>
        
    </tr>
	 <tr>
       <td>&nbsp;</td> <td style="font-size:13px;text-align:center;" >---<u>This is a system generated document hence doesn't require any signature.</u>---</td>
         <td>&nbsp;</td>
    </tr>
</table>

        <asp:HiddenField ID="hfParam" runat="server" />
<asp:HiddenField id="mmm" runat="server"></asp:HiddenField>
<asp:HiddenField id="yym" runat="server"></asp:HiddenField>
    </form>
</body>
</html>
