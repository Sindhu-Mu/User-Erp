<%@ Page Language="C#" AutoEventWireup="true" CodeFile="prtCharacterCertificate.aspx.cs" Inherits="Academic_prtCharacterCertificate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Character Certificate</title>
    <style type="text/css">
        .style2
        {font-family:Arial;
            text-align: center;
            font-size: 20px;
            text-decoration: underline;
        }
        .style3
        { font-size: 25px;
            text-decoration: underline;
        }
        .style4
        {
            height: 24px;
        }
    </style>
</head>
<body onload="window.print(); window.close();">

    <form id="form1" runat="server" >
    <table style="width:650px;font-family:Book Antiqua;font-size:16px;margin-top:150px;margin-left:70px;margin-right:10px;margin-bottom:50px;" cellpadding="3px">
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td >
                &nbsp;</td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td style="height: 44px">
            </td>
        </tr>
    <tr>
        <td  class="style2">
        <strong>CHARACTER CERTIFICATE</strong></td></tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Ref. No.:-<asp:Label ID="lblRefNo" runat="server" Font-Bold="True"></asp:Label></td>
        </tr>
        <tr>
            <td >
                &nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: justify;font-size:22px;" >
                &nbsp;&nbsp; &nbsp; This is certify that <asp:Label ID="lblName" runat="server" Font-Bold="True" Font-Size="17px" />-Enrollment
                No.<asp:Label ID="lblEnroll" runat="server" Font-Bold="True" Font-Size="17px" />
                <asp:Label ID="lblFather" runat="server" Font-Size="17px" Font-Bold="True" />
                is/was student of Course
                <asp:Label ID="lblCourse" runat="server" Font-Bold="False"></asp:Label>
                of this University in the session 
                <asp:Label ID="lblBatch" runat="server" Font-Size="17px" Font-Bold="True" Font-Strikeout="False"></asp:Label> having passed/failed in _______ Exam 20__.</td>
        </tr>
        <tr>
            <td >
                </td>
        </tr>
        <tr>
            <td style="text-align: justify;font-size:22px;">
                &nbsp;&nbsp; &nbsp; To the best of my knowledge and belief his/her character and conduct
                have been satisfactory.</td>
        </tr>
        <tr>
            <td  >
                &nbsp;</td>
        </tr>
        <tr>
            <td id="Td1" runat="server" class="style4" >
                &nbsp;</td>
        </tr>
        <tr>
            <td id="Td2" runat="server" class="style4" >
                &nbsp;</td>
        </tr>
        <tr > 
            <td  style="text-align: left">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
        <%--<table cellpadding="0" cellspacing="0" border="0" width="98%">
        <tr><td  style="text-align: left">
            Date:-<asp:Label ID="lblDate1" runat="server" Font-Bold="True"></asp:Label></td>
            <td colspan="1" style="text-align: right">
                <asp:Label ID="lblDesig" runat="server" Font-Bold="True"></asp:Label>
                &nbsp; &nbsp; &nbsp; &nbsp;<br />
                Mangalayatan University<br />
                Beswan,Aligarh,U.P. &nbsp;&nbsp; &nbsp;
            </td>
        </tr></table>--%>
                <table style="width: 98%">
                        <tr>
                            <td style="text-align: left;width: 30%">Date:-<asp:Label ID="lblDate1" runat="server" Font-Bold="True"></asp:Label></td>
                            <td style="width:40%"></td>
                            <td colspan="1" style="text-align: center;width: 30%; font-family:Arial">
                                (<asp:Label ID="lblAuthorty"  runat="server" Font-Bold="True" ></asp:Label>)

                               
                                <br />

                                <asp:Label ID="lblDesig" runat="server"  Font-Bold="True"></asp:Label>
                               <br />
                               <span id="Span1" runat="server" font-family="Arial" style="font-size:16px" > Mangalayatan University<br />
                                Beswan, Aligarh, U.P.</span>
                            </td>
                        </tr>
                    </table>
            &nbsp;</td></tr>
        <tr>
            <td  style="text-align: center">
                &nbsp;&nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: center">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: center">
                &nbsp;&nbsp;</td>
        </tr>
          <tr>
            <td  style="text-align: center" class="style2"> 
                <strong>CHARACTER CERTIFICATE</strong><br />
                OFFICE COPY</td>
        </tr>
        <tr>
            <td>
                Student Name:-<asp:Label ID="lblStuName" runat="server" Font-Bold="True"></asp:Label>&nbsp;</td>
        </tr>
        <tr>
            <td valign="top" ><table cellpadding="0" cellspacing="0" border="0" width="100%">
                <tr>
                    <td>
                Enrollment No:-<asp:Label ID="lblErollment" runat="server" Font-Bold="True"></asp:Label></td>
                    <td>
                    </td>
                    <td>
                        Course :-<asp:Label ID="lblCourse2" runat="server" Font-Bold="True"></asp:Label></td>
                </tr>
            <tr><td>Application:-Yes/No</td><td></td><td></td></tr>
            <tr><td style="height:27px" valign="bottom">
                PreparedBy:____________________________</td><td style="height: 27px"></td><td align="right" valign="bottom" style="height: 27px; text-align: left">
                ReceivedBy:____________________________</td></tr>
            </table>
                </td>
        </tr>
    </table>
    </form>
</body>
</html>
