<%@ Page Language="C#" AutoEventWireup="true" CodeFile="prtDemandLetter.aspx.cs"
    Inherits="prtDemandLetter" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body onload="window.print();">
    <form id="form1" runat="server">

        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <table style="font-family: Arial; font-size: 10pt; text-align: justify; width: 700px; border-collapse: collapse">
                    <tr>
                        <td>
                            <table style="border-collapse: collapse; width: 100%">
                                <tr>
                                    <td style="width: 50%; vertical-align: top">
                                        <img src="../muImages/image001.jpg" alt="" style="width: 310px; height: 103px" /></td>
                                    <td style="width: 45%">

                                        <p style="margin-top: 0; margin-bottom: 0">
                                            &nbsp;
                                        </p>
                                        <p style="margin-top: 0; margin-bottom: 0">
                                            &nbsp;
                                        </p>
                                        <p style="margin-top: 0; margin-bottom: 0" align="right">
                                            Extended NCR, Aligarh-Mathura Highway
                                        </p>
                                        <p style="margin-top: 0; margin-bottom: 0" align="right">
                                            Beswan, Aligarh-202145, India
                                        </p>
                                        <p style="margin-top: 0; margin-bottom: 0" align="right">
                                            Tel: 0571-3258592-93 Fax: 05722-254220
                                        </p>
                                        <p style="margin-top: 0; margin-bottom: 0" align="right">
                                            Website: www.mangalayatan.in
                                        </p>
                                        <p style="margin-top: 0; margin-bottom: 0" align="right">
                                            Email: info@mangalayatan.edu.in
                                        </p>
                                        <p style="text-align: right";>
                                            Date:- <%#Eval("DATE")%>
                                       </p>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <table style="border-collapse: collapse; width: 60%;float:left">
                                <tr>
                                    <td>Ref.No.:-<%#Eval("REF")%></td>
                                     <td>&nbsp;</td>                                 
                               
                                </tr>
                          <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>To,
                        </td>
                        
                    </tr>
                    <tr>
                        <td>
                            <%#Eval("PARENT_NAME")%>
                        </td>
                        
                    </tr>
                    <tr>
                        <td>
                            <%#Eval("PADD")%>
                        </td>
                        
                    </tr>
                    <tr>
                        <td>CONTACT NO.:-
                    <%#Eval("PHN_NO")%>
                            <asp:Label ID="lblNo" runat="server"></asp:Label></td>
                    </tr>
                                </table>

                            <table style="border-collapse: collapse; width: 40%;float:right">
                                 <tr>
                        <td>&nbsp;</td>
                    </tr>
                                 <tr>
                        <td>&nbsp;</td>
                    </tr>
                           <tr>
                                      <td>NAME:-<%#Eval("STU_FULL_NAME")%></td>
                                </tr>
                                <tr>
                                    <td>COURSE:-
                    <%#Eval("COURSE")%>&nbsp;
                        </td>
                                </tr>
                                <tr>
                                    <td>
                            SEMESTER:-
                    <%#Eval("SEM")%>  
                        </td>
                                </tr>
                                <tr>
                                    <td>
                            SECTION:-
                    <%#Eval("ACA_SEC_NAME")%>
                        </td>
                                </tr>
                            </table>
                            </td>
                        </tr>
                    <tr>
                        <th  style="text-align: center;">
                            <u>FEE DEMAND LETTER</u></th>
                    </tr>

                        <tr>
                            <td>&nbsp;</td>
                        </tr>
                        <tr style="text-align: left;">
                            <th>&nbsp; Dear &nbsp; <%#Eval("PARENT_NAME")%></th>
                        </tr>
                        <tr>
                            <td>With warm greetings from the Mangalayatan University family, you are hereby informed that the academic year 2017-18 is coming to an end on <b>25th May 2017.</b>
                                <br/>We would like to take the opportunity to inform you that the last date for submission of semester fee for the next semester has been fixed at <b>30th June 2017.</b>
                                <br />The due status of your ward as on date is:

                   <%-- <%#Eval("CLS_DT")%>.<br />
                                &nbsp; &nbsp;&nbsp; &nbsp;In order to facilitate the smooth operations of fee accounting
                    for your ward
                   <b><%#Eval("STU_FULL_NAME")%> (<%#Eval("ENROLLMENT_NO")%>) </b>we would like to take the opportunity to inform you that
                    the last date for submission of Semester Fees for the next Semester/s has been fixed
                    at <%#Eval("ENDDATE")%>.<br />
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;We shall appreciate if you clear the fee due against
                    your ward by <%#Eval("STARTDATE")%>.<br />
                                &nbsp;&nbsp; &nbsp; &nbsp;All the defaulters who have not paid the current/previous
                    semester/s fees will be barred to appear for upcoming semester
                    Exam in May.2014.<br />
                                &nbsp;&nbsp; &nbsp;It may be noted that failure to comply with the above notice
                    shall lead to imposition of Late Fine as per University Guidelines for the next
                    Semester & “striking off” of the name of your ward from the attendance register
                    for the next Semester.<br />
                   --%>           
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="gvOpening" runat="server" Width="90%" AutoGenerateColumns="False"
                                    ShowFooter="True">
                                    <Columns>
                                        <asp:TemplateField HeaderText="S.No.">
                                            <ItemTemplate>
                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                            </ItemTemplate>
                                            <ItemStyle Width="20px" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="FEE_GROUP_HEAD_NAME" HeaderText="Particulars " FooterText="Total Fee Due :-">
                                            <FooterStyle Font-Bold="True" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="DAMT" DataFormatString="{0:N2}" HeaderText="Upcoming Semester(2017-18) (Amount in Rupees)">
                                            <FooterStyle HorizontalAlign="Right" Font-Bold="true" />
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-size: 14px;">
                                <strong>Grand Total :- </strong>
                                <asp:Label ID="lblTotalAmt" runat="server" Font-Bold="True"
                                    Font-Italic="True"></asp:Label>
                               </td>
                        </tr>
                        <tr>
                            <td>
                                <strong>Note:</strong> Hostel & Transport Fee is to be paid as per circulated schedule.
                            </td>
                        </tr>
                        <tr>
                            <td>Failing to the above notice shall lead to imposition of late fee as per University Guidelines for the next semseter and "striking off" of the name of your ward from the attendance register for the next semester.</td>
                            </tr>
                        <tr>
                            <td>Students are requested to collect fee <b>Challan & Demand Letter</b> from the document section before 30.05.2017 to facilitate the concerned aspect & complete the registration process through ERP.Fee may be paid through Cash/Demand Draft at University Accounts Section in all working days or directly in University Punjab National Bank Account <b> Finance Officer, Mangalayatan University",A/c No. 1825000100087495(IFS Code PUNB0614200)</b> Or through Net Banking Facility. Wishing you & your ward success in all your ventures.</td>

                            </tr>
                     <tr>
                         <td>
                             With Best Wishes.
                         </td>
                    <%-- </tr>
                             <tr><td>in case you are disagreeing with the above demand or already paid any of the fee reflected above,proof of payment may please be produced at the Accounts Office for verification/confirmation.</td></tr>
                             <tr><td>Students are requested to collect fee Challan from Document Section to deposit fee.</tr>
                   
                        <tr>
                            <td>
                                The Fee amount may be paid in Cash/ DD//Net Banking as per the details provided below;-
                      <table style="width: 100%; border-collapse: collapse; font-size: 15px;" border="1">
                                            <tr>
                                                <th>Cash</th>
                                                <td>To be deposited at PNB Beswan Branch at University Campus.<br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <th>DD/As per cheque</th>
                                                <td>To be deposited to University Account Section directly/directly to Bank Account.<br />
                                                    A/C No.-1825000100087495,FO,Mangalayatan University,Punjab National Bank,<br />
                                                    IFSC Code;-PUNB0614200</td>
                                            </tr>
                                            <tr>
                                                <th>Net Banking-(visit Link on website)</th>
                                                <td>A/C No-34181547930, Mangalayatan University, State Bank of India.<br />
                                                    IFSC code-SBIN0002309&nbsp;&nbsp;&nbsp;Branch Code-A2309      
                                                </td>
                                            </tr>
                                        </table>
                                </td>
                            </tr>
                                
                            </td>
                        </tr>
                       --%>
                        <tr style="text-align: right;">
                            <td>Mangalayatan University</td>
                        </tr>
                        <tr style="text-align: right;">
                            <td >Authorized Signatory &nbsp; &nbsp; &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <b>Note:</b> Students may verify their dues from the Accounts Department of the
                    University or e-mail to<strong>account@mangalayatan.edu.in</strong>
                                or e-mail to sonam.bansal@mangalayatan.edu.in .<br />
                                <b>Special Instruction:</b>All students will be required to register for the next semester.Registration will be allowed on payment of full fees.
                                Students will be permitted to attend the classes only after registration.(Directors may allow registration and permission to attend the classes to Sc Candidates).
                                   </td>
                        </tr>
                   <tr>
                            <td style="text-align: center"><br /><em>
                       “It’s a computer generated format hence signature is
                        not required”</em>
                            </td>
                        </tr>
                </table>
                <hr style='color: White; visibility: hidden; page-break-before: always' />
            </ItemTemplate>
        </asp:Repeater>
    </form>
</body>
</html>
