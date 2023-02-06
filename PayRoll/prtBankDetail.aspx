<%@ Page Language="C#" AutoEventWireup="true" CodeFile="prtBankDetail.aspx.cs" Inherits="PayRoll_prtBankDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Bank Detail</title>
    <style type="text/css">
        .style4 {
            font-size: 16px;
            font-style: italic;
            font-family: "Century Gothic";
            font-weight: bold;
        }
       .salrpt{
        border-collapse: collapse;
         border: 1px solid black;
         width:680px;
            }
            .salrpt td{
              border: 1px solid black;
             height:25px;
             padding:2px;
        }
            .salrpt th{
              border: 1px solid black;
        }

        .style5 {
            font-size: medium;
            font-weight: bold;
        }
        .char {
           letter-spacing:2px;
        }
        @media print
         {
       .pagebreak {page-break-after:always;}
        }
        .acc_no {
            
            width:40%;
        }
        .sr_no {
            width:5%;
           
        }
        .name{
            width:30%;
         
        }
        .emp_code {
              width:10%;
              text-align:center;
           
        }
         .pay {
            
              width:15%;
           
        }
        .right{
             text-align:right;
        }
        .acc {
           text-align:center;
            font-size:20px;
            font-weight:600;
        }
        
        .heading {
            text-align:center;
            font-size:20px;
            font-weight:800;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table style="width: 680px; font-family: Book Antiqua; font-size: 14px;" cellpadding="3" cellspacing="0">
            <tr>
                <td colspan="4">
                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                            <td align="left" style="width: 50%" valign="top">
                                <img src="../Siteimages/logo-1.png" alt="" style="width: 225px; height: 112px" />
                            </td>
                            <td width="45%">
                                <p style="margin-top: 0; margin-bottom: 0">&nbsp;</p>
                                <p style="margin-top: 0; margin-bottom: 0">&nbsp;</p>
                                <p style="margin-top: 0; margin-bottom: 0">&nbsp;</p>
                                <p style="margin-top: 0; margin-bottom: 0" align="right">
                                    <font face="Tahoma" size="2">Extended NCR, Aligarh-Mathura Highway</font>
                                </p>
                                <p style="margin-top: 0; margin-bottom: 0" align="right">
                                    <font face="Tahoma" size="2">Beswan, Aligarh-202145, India</font>
                                </p>
                                <p style="margin-top: 0; margin-bottom: 0" align="right">
                                    <font face="Tahoma" size="2">Tel: 0571-3258592-93 Fax: 05722-254220</font>
                                </p>
                                <p style="margin-top: 0; margin-bottom: 0" align="right">
                                    <font face="Tahoma" size="2">Website: www.mangalayatan.in</font>
                                </p>
                            </td>
                        </tr>
                    </table>
                    <hr style="color: Black" noshade="noshade" size="1" />
                </td>
            </tr>
            <tr>
                <td style="text-align: center" class="style4 heading" >Salary For the Month of
                    <asp:Label ID="lblMonth" runat="server"></asp:Label>
                    <hr style="color: Black" noshade="noshade" size="1" />
                </td>
            </tr>

            <tr>
                <td>
                    <br/>
                    <table border="0" width="100%" cellpadding="0" cellspacing="0">

                        <tr>
                            <td>
                                <div>
                                    <div id="rpt" runat="server" width="99%">
                                  
                                    </div>
                                   

                                    <%--<asp:GridView ID="gvDetail" runat="server" AutoGenerateColumns="False" Width="99%" CellPadding="2" ShowFooter="True" Font-Size="Medium"  AllowPaging="True" PageSize="10">
                                        <Columns>
                                            <asp:BoundField HeaderText="S.No." />
                                            <asp:BoundField DataField="CODE" HeaderText="EMP.CODE" >
                                                  <ItemStyle Width="80px" HorizontalAlign="Center" Height="25px" />
                                                </asp:BoundField>
                                            <asp:BoundField DataField="NAME" HeaderText="NAME" FooterText="Amount">
                                                <ItemStyle Width="200px" HorizontalAlign="Left" />
                                            </asp:BoundField>

                                            <asp:BoundField DataField="Account Number" HeaderText="BANK A/C">
                                                 <ItemStyle HorizontalAlign="Center" Width="250px" Font-Bold="true" Font-Size="18px" CssClass="char"/>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Salary Paid" HeaderText="PAY AMT.">
                                                <ItemStyle HorizontalAlign="Right" Width="80px" CssClass="char" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="SIGNATURE">
                                                <ItemStyle Width="300px" />
                                            </asp:BoundField>

                                        </Columns>

                                        <FooterStyle Font-Bold="True" />

                                    </asp:GridView>--%>
                                   
                                </div>
                                <div>
                                    <table style="font-weight:800;padding-left:30px;" >
                                        <tr>
                                            <td>Total Employees</td><td>:</td><td><asp:Label ID="lblTotalEmp" runat="server"></asp:Label></td>
                                             <td style="padding:50px">&nbsp;</td>
                                            <td>Grand Total</td><td>:</td><td><asp:Label ID="lblGrandTotal" runat="server"></asp:Label></td>
                                           
                                            </tr>
                                        </table>

                                    <table style="width:100%;text-align:center;">
                                        <tr>
                                             <td>(Signature)<br/>Samiran Baral<br/>FINANCE OFFICER</td>
                                             <td>(Signature)<br/>Purbasha Sarkar<br/>SR. MANAGER HR & ADMINISTRATION</td>
                                             <td>(Signature)<br/>Mohit Jain<br/>MANAGER ACCOUNTS</td>
                                        </tr>
                                        </table>
                                </div>
                            </td>
                        </tr>

                    </table>
                </td>
            </tr>
            <tr>
                <td>

                    <hr style="color: Black" noshade="noshade" size=".5" />
                </td>
            </tr>
            <tr>
                <td>
                    <table border="0" width="100%" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <asp:Label ID="lblDate" runat="server"></asp:Label></td>
                           
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>

