<%@ Page Language="C#" AutoEventWireup="true" CodeFile="prtTNP_Training_Letter.aspx.cs" Inherits="TrainingAndPlacement_prtTNP_Training_Letter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table style="width: 690px; border-collapse: collapse; border-spacing: 0px">
            <tr>
                <td style="padding-left:10px">
                    <table style="width: 100%; border-collapse: collapse; border-spacing: 0px;">
                        <tr>
                            <td style="height:157px;">
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <td style="text-align:left">
                                          <b>Ref. No.:</b>
                                            <asp:Label ID="lblTrngNo" runat="server"></asp:Label>
                                        </td>
                                        <td style="width:100px"></td>
                                        <td style="width:100px"></td>
                                        <td style="width:100px"></td>
                                        <td style="text-align:right">
                                           <b> Dated:</b> 
                                            <asp:Label ID="lblDate" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>


                        <tr>

                            <td style="text-align: left">To,
                            </td>
                        </tr>
                        <tr>

                            <td style="text-align: left">___________________________
                            </td>
                        </tr>
                        <tr>

                            <td style="text-align: left">___________________________
                            </td>
                        </tr>
                        <tr>

                            <td style="text-align: left">___________________________
                            </td>
                        </tr>
                        <tr>

                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <th>
                                <span style="font-size: 18pt; text-decoration: underline;">SUMMER TRAINING</span>
                            </th>
                        </tr>
                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <td>Dear Sir/Madam,
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>We are one of the leading Universities in Northern India with a strong commitment to provide dynamic managers and technocrats to meet the ever-changing expectations of the corporate world.
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td><asp:Label ID="title" runat="server" Text="Mr./Ms. " Font-Bold="True"></asp:Label><asp:Label ID="lblName" runat="server" Font-Bold="True"></asp:Label> &nbsp;<asp:Label ID="lblfn" runat="server" Text="S/o or D/o Mr. " Font-Bold="true"></asp:Label><asp:Label ID="lblFthrName" runat="server" Font-Bold="True"></asp:Label><asp:Label ID="lbl" runat="server" Text=", (Enrollment No. " Font-Bold="true"></asp:Label>
                                            <asp:Label ID="lblEnroll" runat="server" Font-Bold="True"></asp:Label>
                                             is a student of &nbsp;<asp:Label ID="lblCrs" runat="server"  Font-Bold="true"></asp:Label> <asp:Label ID="lblbranch" runat="server" Font-Bold="True"></asp:Label> <asp:Label ID="lblSem" runat="server" Font-Bold="true"></asp:Label> 
                                            <strong>semester</strong>,of our University,during the session 2016-17.
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>After completion of <asp:Label ID="lblseme" runat="server" ></asp:Label> Semester, he/she is required to undergo a Summer Training programme of 
                                            <asp:Label ID="lblduration" runat="server" Font-Bold="true"></asp:Label>&nbsp;<span style="font-weight:bold">weeks</span> in one of the esteemed corporate setting like yours, in partial fulfillment of <asp:Label ID="lblCrse" runat="server" ></asp:Label> degree.
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>We, therefore, request you to kindly provide him/her this opportunity by assigning project work pertinent to the stream being pursued, which will enable him/her to visualize practical applications of theoretical inputs acquired, so far.
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>A feedback of the candidate on the assigned ‘Project’ will be highly appreciated. For any query, you may kindly contact undersigned at +917351002501.
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>Thanking you,
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>Yours’ Sincerely,
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td><img src="../images/sign/Abhay_Sign.jpeg" alt="" style="width: 120px; height: 31px"/></td>
                                    </tr>
                                    <tr>
                                        <td>Dr. Abhay Kumar
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>(Director- Training & Placement Cell)
                                        </td>
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
