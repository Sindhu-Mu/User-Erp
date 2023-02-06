<%@ Page Language="C#" AutoEventWireup="true" CodeFile="prtFeeChallan.aspx.cs" Inherits="Common_prtFeeChallan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Fee Challan</title>
</head>
<body onload="window.print();" style="margin: 0;">
    <form id="Form1" runat="server" style="margin: 0;">
        <table border="0" style="font-family: Book Antiqua; font-size: 15px; margin: 0;  width: 100%">
            <tr>
                <td style="width: 30%; vertical-align: top; margin: 0;">
                    <table style="width: 100%; vertical-align: top; margin: 0;">
                        <tr>
                            <td>
                                <table style="width: 100%; vertical-align: top; margin: 0;">
                                    <tr>
                                        <td>Sr.No.<asp:Label ID="lblCno" runat="server" BorderStyle="None" Font-Bold="True" Font-Size="Large"></asp:Label></td>
                                        <td></td>
                                        <td align="right">Bank Copy</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <span style="font-size: 18px;"><strong>
                                    <asp:Label ID="lblBank1" runat="server"></asp:Label></strong></span></td>
                        </tr>
                        <tr>
                            <td align="center">&nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <table style="width: 100%; vertical-align: top; margin: 0;">
                                    <tr>
                                        <td style="border: black 1px solid;">Branch</td>
                                        <td colspan="2" style="border: black 1px solid;">
                                            <asp:Label ID="lblBranch1" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="border: black 1px solid;">Account Name</td>
                                        <td colspan="2" style="border: black 1px solid;">
                                            <span style="font-size: 14px">
                                                <asp:Label ID="lblAccountName1" runat="server"></asp:Label></span></td>
                                    </tr>
                                    <tr>
                                        <td style="border: black 1px solid;">Account No.</td>
                                        <td colspan="2" style="border: black 1px solid;">
                                            <strong><span style="font-size: 18px;">
                                                <asp:Label ID="lblAccountNo1" runat="server"></asp:Label></span></strong></td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td colspan="2">&nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <table style="width: 80%; vertical-align: top; margin: 0;">
                                    <tr>
                                        <td>Date of Submission</td>
                                        <td style="border: black 1px solid;">&nbsp;&nbsp;</td>
                                        <td style="border: black 1px solid;">&nbsp;&nbsp;</td>
                                        <td style="border: black 1px solid;">&nbsp;&nbsp;</td>
                                        <td style="border: black 1px solid;">&nbsp;&nbsp;</td>
                                        <td style="border: black 1px solid;">&nbsp;&nbsp;</td>
                                        <td style="border: black 1px solid;">&nbsp;&nbsp;</td>
                                        <td style="border: black 1px solid;">&nbsp;&nbsp;</td>
                                        <td style="border: black 1px solid;">&nbsp;&nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <table cellpadding="2" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="center" colspan="3" nowrap="nowrap">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="3" nowrap="nowrap" style="border: black 1px solid;">
                                            <asp:Label ID="lblINs" runat="server" Font-Italic="True" Font-Size="Medium"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="3" nowrap="nowrap">&nbsp;</td>
                                    </tr>

                                    <tr>
                                        <td>Reg No.</td>
                                        <td colspan="2" style="border: black 1px solid;">
                                            <asp:Label ID="lblReg1" runat="server" Font-Bold="True"></asp:Label></td>
                                    </tr>

                                    <tr>
                                        <td>Enrollment No.</td>
                                        <td colspan="2" style="border: black 1px solid;">
                                            <asp:Label ID="lblEnrollment1" runat="server" Font-Bold="True"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>Student Name</td>
                                        <td colspan="2" style="border: black 1px solid;">
                                            <asp:Label ID="lblStuName1" runat="server" Font-Bold="False"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>Father Name</td>
                                        <td colspan="2" style="border: black 1px solid;">
                                            <asp:Label ID="lblFather1" runat="server" Font-Bold="False"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>Course Name</td>
                                        <td colspan="2" style="border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid; border-bottom: black 1px solid">
                                            <asp:Label ID="lblCourse" runat="server" Font-Bold="False"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>Semester</td>
                                        <td colspan="2" style="border: black 1px solid;">
                                            <asp:Label ID="lblSem" runat="server"></asp:Label>&nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table style="width: 100%; vertical-align: top; margin: 0;">
                                    <tr>
                                       <td style="width: 35%" valign="top">
                                            <table cellpadding="2" cellspacing="0" border="1" width="100%">
                                                <tr>
                                                    <td>Denom<br />
                                                        ination</td>
                                                    <td>NO.</td>
                                                    <td style="width: 80px">Rs.</td>
                                                </tr>
                                                <tr>
                                                    <td>2000</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td>500</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td>100</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td>50</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td>20</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td>10</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td>5</td>
                                                    <td>&nbsp;
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Coins</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td>Total</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td width="3%"></td>
                                        <td width="50%" valign="top">
                                            <table cellpadding="2" cellspacing="0" border="0" width="100%">
                                                <tr>
                                                    <td style="border: black 1px solid;">Name of Bank</td>
                                                    <td style="width: 150px; border: black 1px solid;">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td style="border: black 1px solid;">Chq./DD No.</td>
                                                    <td style="border: black 1px solid;">
                                                        <table cellpadding="2" cellspacing="0" width="100%">
                                                            <tr>
                                                                <td style="border: black 1px solid;">&nbsp;</td>
                                                                <td style="border: black 1px solid;">&nbsp;</td>
                                                                <td style="border: black 1px solid;">&nbsp;</td>
                                                                <td style="border: black 1px solid;">&nbsp;</td>
                                                                <td style="border: black 1px solid;">&nbsp;</td>
                                                                <td style="border: black 1px solid;">&nbsp;</td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="border: black 1px solid;">Date Of Chq/DD</td>
                                                    <td style="border: black 1px solid;">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td style="border: black 1px solid;">Amount</td>
                                                    <td style="border: black 1px solid;">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" valign="top">
                                                        <asp:GridView ID="gvFee1" runat="server" AutoGenerateColumns="False" CellPadding="3"
                                                            ShowFooter="True" ShowHeader="False" Width="97%" CellSpacing="1">
                                                            <Columns>
                                                                <asp:BoundField DataField="HEAD" FooterText="Total Rs." />
                                                                <asp:BoundField DataField="DUE_AMOUNT" DataFormatString="{0:N2}" />
                                                            </Columns>
                                                            <FooterStyle Font-Bold="True" />
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>Amount in Words:-................................................................................................................................</td>
                        </tr>
                        <tr>
                            <td>&nbsp;...............................................................................................................................</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <table style="width: 100%; vertical-align: top; margin: 0;">
                                    <tr>
                                        <td style="width: 30%; border: black 1px solid;">Signature</td>
                                        <td style="border: black 1px solid;">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td style="width: 30%; border: black 1px solid;">Name of Depositor</td>
                                        <td style="border: black 1px solid; height: 16px;">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td style="width: 30%; border: black 1px solid;">Address</td>
                                        <td style="border: black 1px solid;">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td style="width: 30%; border: black 1px solid;">Contact No.</td>
                                        <td style="border: black 1px solid;">&nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">&nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" style="border-top: black thin solid;">For Bank Use Only</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <table cellpadding="2" cellspacing="0" border="0" width="100%">
                                    <tr>
                                        <td>Acknowledgement</td>
                                        <td align="right">Cashier/Officer</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 2%">&nbsp;&nbsp;</td>
                <td style="width: 30%; vertical-align: top; margin: 0;">
                    <table border="0">
                        <tr>
                            <td>
                                <table style="width: 100%; border: 0;">
                                    <tr>
                                        <td>Sr.No.<asp:Label ID="lblChNo2" runat="server" BorderStyle="None" Font-Bold="True"
                                            Font-Size="Large"></asp:Label></td>
                                        <td></td>
                                        <td align="right">University Copy</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <span style="font-size: 18px;"><strong>
                                    <asp:Label ID="lblBank2" runat="server"></asp:Label></strong></span></td>
                        </tr>
                        <tr>
                            <td align="center">&nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <table style="width: 100%; vertical-align: top; margin: 0;">
                                    <tr>
                                        <td style="border: black 1px solid;">Branch</td>
                                        <td colspan="2" style="border: black 1px solid;">
                                            <asp:Label ID="lblBranch2" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="border: black 1px solid;">Account Name</td>
                                        <td colspan="2" style="border: black 1px solid;">
                                            <span style="font-size: 14px">
                                                <asp:Label ID="lblAccountName2" runat="server"></asp:Label></span></td>
                                    </tr>
                                    <tr>
                                        <td style="border: black 1px solid;">Account No.</td>
                                        <td colspan="2" style="border: black 1px solid;">
                                            <strong><span style="font-size: 18px;">
                                                <asp:Label ID="lblAccountNo2" runat="server"></asp:Label></span></strong></td>
                                    </tr>
                                    <tr>
                                        <td nowrap="nowrap"></td>
                                        <td colspan="2">&nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <table style="width: 80%; vertical-align: top; margin: 0;">
                                    <tr>
                                        <td>Date of Submission</td>
                                        <td style="border: black 1px solid;">&nbsp;&nbsp;</td>
                                        <td style="border: black 1px solid;">&nbsp;&nbsp;</td>
                                        <td style="border: black 1px solid;">&nbsp;&nbsp;</td>
                                        <td style="border: black 1px solid;">&nbsp;&nbsp;</td>
                                        <td style="border: black 1px solid;">&nbsp;&nbsp;</td>
                                        <td style="border: black 1px solid;">&nbsp;&nbsp;</td>
                                        <td style="border: black 1px solid;">&nbsp;&nbsp;</td>
                                        <td style="border: black 1px solid;">&nbsp;&nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <table style="width: 100%; vertical-align: top; margin: 0;">
                                    <tr>
                                        <td align="center" colspan="3" nowrap="nowrap">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="3" nowrap="nowrap" style="border: black 1px solid;">
                                            <asp:Label ID="lblIns2" runat="server" Font-Italic="True" Font-Size="Medium"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="3" nowrap="nowrap">&nbsp;&nbsp;</td>
                                    </tr>

                                    <tr>
                                        <td>Reg No.</td>
                                        <td colspan="2" style="border: black 1px solid;">
                                            <asp:Label ID="lblReg2" runat="server" Font-Bold="True"></asp:Label></td>
                                    </tr>

                                    <tr>
                                        <td>Enrollment No.</td>
                                        <td colspan="2" style="border: black 1px solid;">
                                            <asp:Label ID="lblEnrollment2" runat="server" Font-Bold="True"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>Student Name</td>
                                        <td colspan="2" style="border: black 1px solid;">
                                            <asp:Label ID="lblStuName2" runat="server" Font-Bold="False"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td >Father Name</td>
                                        <td colspan="2" style="border: black 1px solid;">
                                            <asp:Label ID="lblFather2" runat="server" Font-Bold="False"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>Course Name</td>
                                        <td colspan="2" style="border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid; border-bottom: black 1px solid">
                                            <asp:Label ID="lblCourse2" runat="server" Font-Bold="False"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>Semestser
                                        </td>
                                        <td colspan="2" style="border: black 1px solid;">
                                            <asp:Label ID="lblSem2" runat="server"></asp:Label>&nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table style="width: 100%; vertical-align: top; margin: 0;">
                                    <tr>
                                        <td style="width: 35%" valign="top">
                                            <table cellpadding="2" cellspacing="0" border="1" width="100%">
                                                <tr>
                                                    <td>Denom<br />
                                                        ination</td>
                                                    <td>NO.</td>
                                                    <td style="width: 80px">Rs.</td>
                                                </tr>
                                                <tr>
                                                    <td>2000</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td>500</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td>100</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td>50</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td>20</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td>10</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td>5</td>
                                                    <td>&nbsp;
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Coins</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td>Total</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td width="3%"></td>
                                        <td width="50%" valign="top">
                                            <table style="width: 100%; vertical-align: top; margin: 0;">
                                                <tr>
                                                    <td style="border: black 1px solid;">Name of Bank</td>
                                                    <td style="width: 150px; border: black 1px solid;">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td style="border: black 1px solid;">Chq./DD No.</td>
                                                    <td style="border: black 1px solid;">
                                                        <table style="width: 100%; vertical-align: top; margin: 0;">
                                                            <tr>
                                                                <td style="border: black 1px solid;">&nbsp;</td>
                                                                <td style="border: black 1px solid;">&nbsp;</td>
                                                                <td style="border: black 1px solid;">&nbsp;</td>
                                                                <td style="border: black 1px solid;">&nbsp;</td>
                                                                <td style="border: black 1px solid;">&nbsp;</td>
                                                                <td style="border: black 1px solid;">&nbsp;</td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="border: black 1px solid;">Date Of Chq/DD</td>
                                                    <td style="border: black 1px solid;">&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="border: black 1px solid;">Amount</td>
                                                    <td style="border: black 1px solid;">&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" valign="top">
                                                        <asp:GridView ID="gvFee2" runat="server" AutoGenerateColumns="False" CellPadding="3"
                                                            ShowFooter="True" ShowHeader="False" Width="97%" CellSpacing="1">
                                                            <Columns>
                                                                <asp:BoundField DataField="HEAD" FooterText="Total Rs." />
                                                                <asp:BoundField DataField="DUE_AMOUNT" DataFormatString="{0:N2}" />
                                                            </Columns>
                                                            <FooterStyle Font-Bold="True" />
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>Amount in Words:-..............................................................................................................................</td>
                        </tr>
                        <tr>
                            <td>..............................................................................................................................</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <table style="width: 100%; vertical-align: top; margin: 0;">
                                    <tr>
                                        <td style="width: 30%; border: black 1px solid;">Signature</td>
                                        <td style="border: black 1px solid;">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td style="width: 30%; border: black 1px solid;">Name of Depositor</td>
                                        <td style="border: black 1px solid; height: 16px;">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td style="width: 30%; border: black 1px solid;">Address</td>
                                        <td style="border: black 1px solid;">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td style="width: 30%; border: black 1px solid;">Contact No.</td>
                                        <td style="border: black 1px solid;">&nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="border-top: black thin solid;" align="center">For Bank Use Only</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <table style="width: 100%; vertical-align: top; margin: 0;">
                                    <tr>
                                        <td>Acknowledgement</td>
                                        <td align="right">Cashier/Officer</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 2%">&nbsp;&nbsp; &nbsp;</td>
                <td style="width: 30%; vertical-align: top; margin: 0;">
                    <table  border="0">
                        <tr>
                            <td>
                                <table style="width: 100%; vertical-align: top; margin: 0;">
                                    <tr>
                                        <td>Sr.No.<asp:Label ID="lblChNo3" runat="server" BorderStyle="None" Font-Bold="True"
                                            Font-Size="Large"></asp:Label></td>
                                        <td></td>
                                        <td align="right">Student Copy</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <span style="font-size: 18px;"><strong>
                                    <asp:Label ID="lblBank3" runat="server"></asp:Label></strong></span></td>
                        </tr>
                        <tr>
                            <td align="center">&nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <table style="width: 100%; vertical-align: top; margin: 0;">
                                    <tr>
                                        <td style="border: black 1px solid;">Branch</td>
                                        <td colspan="2" style="border: black 1px solid;">
                                            <asp:Label ID="lblBranch3" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="border: black 1px solid;">Account Name</td>
                                        <td colspan="2" style="border: black 1px solid;">
                                            <span style="font-size: 14px">
                                                <asp:Label ID="lblAccountName3" runat="server"></asp:Label></span></td>
                                    </tr>
                                    <tr>
                                        <td style="border: black 1px solid;">Account No.</td>
                                        <td colspan="2" style="border: black 1px solid;">
                                            <strong><span style="font-size: 18px;">
                                                <asp:Label ID="lblAccountNo3" runat="server"></asp:Label></span></strong></td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td colspan="2">&nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <table cellpadding="2" cellspacing="0" width="80%">
                                    <tr>
                                        <td>Date of Submission</td>
                                        <td style="border: black 1px solid;">&nbsp;&nbsp;</td>
                                        <td style="border: black 1px solid;">&nbsp;&nbsp;</td>
                                        <td style="border: black 1px solid;">&nbsp;&nbsp;</td>
                                        <td style="border: black 1px solid;">&nbsp;&nbsp;</td>
                                        <td style="border: black 1px solid;">&nbsp;&nbsp;</td>
                                        <td style="border: black 1px solid;">&nbsp;&nbsp;</td>
                                        <td style="border: black 1px solid;">&nbsp;&nbsp;</td>
                                        <td style="border: black 1px solid;">&nbsp;&nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <table style="width: 100%; vertical-align: top; margin: 0;">
                                    <tr>
                                        <td align="center" colspan="3" nowrap="nowrap">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="3" nowrap="nowrap" style="border: black 1px solid;">
                                            <asp:Label ID="lblIns3" runat="server" Font-Italic="True" Font-Size="Medium"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="3" nowrap="nowrap">&nbsp;</td>
                                    </tr>

                                    <tr>
                                        <td>Reg No.</td>
                                        <td colspan="2" style="border: black 1px solid;">
                                            <asp:Label ID="lblReg3" runat="server" Font-Bold="True"></asp:Label></td>
                                    </tr>

                                    <tr>
                                        <td nowrap>Enrollment No.</td>
                                        <td colspan="2" style="border: black 1px solid;">
                                            <asp:Label ID="lblEnrollment3" runat="server" Font-Bold="True"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td nowrap>Student Name</td>
                                        <td colspan="2" style="border: black 1px solid;">
                                            <asp:Label ID="lblStuName3" runat="server" Font-Bold="False"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td nowrap="nowrap">Father Name</td>
                                        <td colspan="2" style="border: black 1px solid;">
                                            <asp:Label ID="lblFather3" runat="server" Font-Bold="False"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td nowrap="nowrap">Course Name</td>
                                        <td colspan="2" style="border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid; border-bottom: black 1px solid">
                                            <asp:Label ID="lblCourse3" runat="server" Font-Bold="False"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>Semestser
                                        </td>
                                        <td colspan="2" style="border: black 1px solid;">
                                            <asp:Label ID="lblSem3" runat="server"></asp:Label>&nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table style="width: 100%; vertical-align: top; margin: 0;">
                                    <tr>
                                        <td width="35%" valign="top">
                                            <table cellpadding="2" cellspacing="0" border="1" width="100%">
                                                <tr>
                                                    <td>Denom<br />
                                                        ination</td>
                                                    <td>NO.</td>
                                                    <td style="width: 80px">Rs.</td>
                                                </tr>
                                                <tr>
                                                    <td>2000</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td>500</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td>100</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td>50</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td>20</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td>10</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td>5</td>
                                                    <td>&nbsp;
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Coins</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td>Total</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td width="3%"></td>
                                        <td width="40%" valign="top">
                                            <table cellpadding="2" cellspacing="0" border="0" width="100%">
                                                <tr>
                                                    <td style="border: black 1px solid;">Name of Bank</td>
                                                    <td style="width: 150px; border: black 1px solid;">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td style="border: black 1px solid;">Chq./DD No.</td>
                                                    <td style="border: black 1px solid;">
                                                        <table cellpadding="2" cellspacing="0" width="100%">
                                                            <tr>
                                                                <td style="border: black 1px solid;">&nbsp;</td>
                                                                <td style="border: black 1px solid;">&nbsp;</td>
                                                                <td style="border: black 1px solid;">&nbsp;</td>
                                                                <td style="border: black 1px solid;">&nbsp;</td>
                                                                <td style="border: black 1px solid;">&nbsp;</td>
                                                                <td style="border: black 1px solid;">&nbsp;</td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="border: black 1px solid;">Date Of Chq/DD</td>
                                                    <td style="border: black 1px solid;">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td style="border: black 1px solid;">Amount</td>
                                                    <td style="border: black 1px solid;">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" valign="top">
                                                        <asp:GridView ID="gvFee3" runat="server" AutoGenerateColumns="False" CellPadding="3"
                                                            ShowFooter="True" ShowHeader="False" Width="97%" CellSpacing="1">
                                                            <Columns>
                                                                <asp:BoundField DataField="HEAD" FooterText="Total Rs." />
                                                                <asp:BoundField DataField="DUE_AMOUNT" DataFormatString="{0:N2}" />
                                                            </Columns>
                                                            <FooterStyle Font-Bold="True" />
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>Amount in Words:-...................................................................................................................................</td>
                        </tr>
                        <tr>
                            <td>&nbsp;..................................................................................................................................</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <table style="width: 100%; vertical-align: top; margin: 0;">
                                    <tr>
                                        <td style="width:30%; border: black 1px solid;">Signature</td>
                                        <td style="border: black 1px solid;">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td style="width:30%; border: black 1px solid;">Name of Depositor</td>
                                        <td style="border: black 1px solid; height: 16px;">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td style="width:30%; border: black 1px solid;">Address</td>
                                        <td style="border: black 1px solid;">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td style="width:30%; border: black 1px solid;">Contact No.</td>
                                        <td style="border: black 1px solid;">&nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">&nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" style="border-top: black thin solid; height: 6px;">For Bank Use Only</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <table style="width: 100%; vertical-align: top; margin: 0;">
                                    <tr>
                                        <td>Acknowledgement</td>
                                        <td align="right">Cashier/Officer</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
