<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EmpTodyaAtt.ascx.cs" Inherits="Control_EmpTodyaAtt" %>

<table style="border-bottom: #c20f0f 3px solid; border-right: #c20f0f 3px solid; border-left: #c20f0f 3px solid;width:100%;border-collapse: collapse;" >
    <tr>
        <td style="font-size: 20px; background-color: #c20f0f; color: #fff;">
            <asp:Label ID="lblLogDate" runat="server"></asp:Label>
            Attendance</td>
    </tr>

    <tr>
        <td rowspan="2" style="vertical-align: top">
            <table style="font-size: 14px; text-align: left;font-weight:bold; border-collapse: collapse;width:100%">

                <tr>
                    <th>Duty Shift:</th>
                    <td>
                        <asp:Label ID="lblShift" runat="server" ForeColor="Red"></asp:Label></td>
                    <td>&nbsp</td>
                    <th>Attendance Status</th>
                    <td>
                        <asp:Label ID="lblStatus" runat="server" ForeColor="Red"></asp:Label></td>
                </tr>
                <tr style="text-align:center;">
                    <td style="font-size: 15px; background-color: #c20f0f; color: #fff;" colspan="2">IN</td>
                   <td>&nbsp</td>
                    <td style="font-size: 15px; background-color: #c20f0f; color: #fff;" colspan="2">OUT</td>
                </tr>
               
                <tr>
                    <td colspan="2" style="width:45%">
                        <table >
                            <tr>
                                <th>Timing</th>
                                <td>:<asp:Label ID="lblInTime" runat="server" ></asp:Label>
                                </td>
                            </tr>
                          <%--  <tr>
                                <th>Marked on</th>
                              
                                <td >:<asp:Label ID="lblInTimeMarkedon" runat="server" ></asp:Label></td>
                            </tr>--%>

                            <tr>
                                <th>Marked at</th>
                                
                                <td >:<asp:Label ID="lblInTimeMarkedAt" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <th>Marked By</th>
                                <td >:<asp:Label ID="lblInTimeMarkedBy" runat="server" ></asp:Label></td>
                            </tr>
                        </table>
                    </td>
                  <td>&nbsp</td>
                    <td colspan="2" style="width:45%">
                        <table >
                            <tr>
                                <th>Timing</th>
                                <td>:<asp:Label ID="lblOutTime" runat="server" ></asp:Label>
                                </td>
                            </tr>
                           <%-- <tr>
                                <th>Marked on</th>
                              
                                <td >:<asp:Label ID="lblOutTimeMarkedon" runat="server"></asp:Label></td>
                            </tr>--%>

                            <tr>
                                <th>Marked at</th>
                             
                                <td >:<asp:Label ID="lblOutTimeMarkedAt" runat="server" ></asp:Label></td>
                            </tr>
                            <tr>
                                <th>Marked By</th>
                                <td >:<asp:Label ID="lblOutTimeMarkedBy" runat="server"></asp:Label></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                </table>
          
        </td>
    </tr>
</table>
