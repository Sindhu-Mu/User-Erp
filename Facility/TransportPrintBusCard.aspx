<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TransportPrintBusCard.aspx.cs" Inherits="Facility_TransportPrintBusCard" %>

<%@ PreviousPageType VirtualPath="~/Facility/TransportICardPrintView.aspx" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>BUS IDENTITY CARD</title>
   
</head>
<body style="margin-top: -5px;">
    <form id="form1" runat="server">
         <asp:DataList ID="rpt1" runat="server" RepeatColumns="2" Width="400px" CellSpacing="3"
                                    RepeatDirection="Horizontal">
       
            <ItemTemplate>
                
                <div style="width: 250px; font-size: 12px; padding-top: 40px;padding-left:20px; border-collapse: collapse;height:450px;vertical-align:top;">
                    <div>
                        <table style="width: 100%; display: inline; border-collapse: collapse;">
                            <tr>
                                <td style="width: 4px; border-bottom: black 1px solid">
                                    <img src="http://192.168.1.5/EmployeePortal/siteimages/logo-1_bus.png" style="height: 50px" id="Img1" alt="" />
                                </td>
                                <td style="text-align: center; border-bottom: solid 1px Black">
                                    <span style="font-size: 11pt"><strong>MANGALAYATAN UNIVERSITY
                                            <br />
                                    </strong></span><span style="font-size: 9pt"><strong>BUS IDENTITY CARD<br />
                                        REG.NO:-
                                            <%# Eval("REG_ID")%>
                                            &nbsp; &nbsp;SESSION:- </strong></span>
                                    <asp:Label ID="lblYear" runat="server" Text="2015-16"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div>
                        <table style="width: 100%; display: inline; border-collapse: collapse;">
                            <tr>
                                <td style="width: 4px"></td>
                                <td style="width: 80px">Enrollment&nbsp;:&nbsp;</td>
                                <td style="width: 100px"> <%# Eval("ENROLLMENT_NO")%></td>
                                <td rowspan="6" style="width: 72px">
                                    <img id="imgPhoto" runat="server" alt="Image" src='<%# Eval("IMAGE")%>' style="width: 100px; padding: 0; height: 115px; border-top-width: 1px; border-left-width: 1px; border-left-color: #ff0000; border-bottom-width: 1px; border-bottom-color: #ff0000; border-top-color: #ff0000;" /></td>
                            </tr>

                            

                           
                            <tr>
                                <td style="width: 2px"></td>
                                <td>Course&nbsp;:&nbsp;</td>
                                <td>
                                    <%# Eval("PGM_SHORT_NAME")%>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2px"></td>
                                <td>Semester&nbsp;:&nbsp;</td>
                                <td style="font-weight: bold">
                                    <%# Eval("ACA_SEM_ID")%>
                                </td>

                            </tr>
                             <tr>
                                <td style="width: 2px"></td>
                                <td>Bus No&nbsp;:&nbsp;</td>
                                <td>
                                   <%# Eval("BUS_ID")%>
                                </td>
                            </tr>
                            <tr >
                                <td style="width: 2px;"></td>
                                <td>Stoppage&nbsp;:&nbsp;</td>
                                <td>&nbsp;                                         
                                </td>
                            </tr>
                            <tr><td>&nbsp;</td></tr>
                              <tr >
                                <td style="width: 2px"></td>
                                <td></td>
                                <td></td>
                                <td style="vertical-align: bottom;padding-top: 20px;">
                                    <span style="font-size: 9pt;">Authorise Signatory</span></td>
                            </tr>
                        </table>
                    </div>
                    <div>
                        <table style="width: 100%; display: inline; border-collapse: collapse;">
                            <tr>
                                <td style="width: 2px"></td>
                                <td style="width:100px;">Name&nbsp;:&nbsp;
                                </td>
                                <td style="width:150px;">
                                    <%# Eval("STU_FULL_NAME")%>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2px"></td>
                                <td>Father's Name&nbsp;:&nbsp;</td>
                                <td>
                                    <%# Eval("FATHER_NAME")%>
                                </td>
                            </tr>
                            <tr style="padding-top: 5px;border-bottom:1px solid black;">
                                <td style="width: 2px"></td>
                                <td>Contact No&nbsp;:&nbsp;</td>
                                <td>&nbsp;                                            
                                </td>
                            </tr>
                          

                            <tr>
                                <td colspan="1" style="width: 2px"></td>
                                <td colspan="3">
                                    <strong>Directions for the Student :-</strong></td>
                            </tr>
                            <tr>
                                <td colspan="1" style="width: 2px"></td>
                                <td colspan="3">
                                    <div></div>
                                    1.&nbsp;Bus I-Card must be kept during travel.<br />
                                    2.&nbsp;Student must travel only in the alloted Bus.<br />
                                    3.&nbsp;Bus card is not trasferable.If it is transfered the holder will be
                                             penalised Rs.1000/-<br />
                                    4.&nbsp;Bus I-Card is to be produced at the time of checking.Students not in possession of bus card will be fined Rs 100/-.</td>
                            </tr>
                            <tr>
                                <td colspan="4" style="text-align: right">
                                    <br />
                                    Signature of Student
                                      
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </div>

                </div> 
               
            </ItemTemplate>
        </asp:DataList>
    </form>
</body>
</html>
