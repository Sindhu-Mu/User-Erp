<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EmployeeShort.ascx.cs" Inherits="Control_EmployeeShort" %>
<ajaxToolkit:RoundedCornersExtender ID="RoundedCornersExtender1" runat="server"
    BehaviorID="RoundedCornersBehavior1" BorderColor="Black" TargetControlID="div1">
</ajaxToolkit:RoundedCornersExtender>
<div id="div1" style="background-color: #B32D07;" runat="server">
    <table>
        <tr>
            <td>
                <table style="font-family: Tahoma; font-size: 11px; border-collapse: collapse">
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td style="padding-top: 4px">
                                        <img id="imgPicture" runat="server" alt="Image" src="../images/emp_images/empImage.jpg" width="94" height="107" style="border: 5px solid #808080; padding: 0" /></td>
                                </tr>
                                <tr>
                                    <td style="font-family: Arial; color: white; font-size: 11px; text-align:center">
                                        <asp:Label ID="lblStatus" runat="server"></asp:Label>
                                        <asp:Label ID="lblRlvngDate" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>

                        <td>&nbsp;</td>
                        <td>



                            <table border="0" style="font-family: Tahoma; font-size: 11px; color: #fff; border-collapse: collapse">
                                <tr>
                                    <td>
                                        <div style="float: left; font-size: 12px; font-family: 'Trebuchet MS'; font-weight: bold; color: #000000;">
                                            EMPLOYEE INFORMATION

                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table border="0" style="color: white; text-align: center">
                                            <tr>
                                                <td>
                                                    <table border="0" style="font-family: Arial; color: white; font-size: 11px">
                                                        <tr>
                                                            <td>
                                                                <p style="margin-top: 4px; margin-bottom: 3px">
                                                                    Code No : #<asp:Label ID="lblCode" runat="server"></asp:Label>
                                                                </p>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <p style="margin-top: 4px; margin-bottom: 3px">
                                                                    Name :
                                                                    <asp:Label ID="lblName" runat="server"></asp:Label>
                                                                </p>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <p style="margin-top: 4px; margin-bottom: 3px">
                                                                    Date of Joining :
                                                                    <asp:Label ID="lblDoj" runat="server"></asp:Label>
                                                                </p>
                                                            </td>
                                                        </tr>



                                                    </table>
                                                </td>
                                                <td>
                                                    <table border="0" style="font-family: Tahoma; color: white; font-size: 11px">
                                                        <tr>
                                                            <td>
                                                                <p style="margin-top: 4px; margin-bottom: 3px">
                                                                    Next Senior :
                                                                    <asp:Label ID="lblNextS" runat="server"></asp:Label>
                                                                </p>
                                                            </td>
                                                        </tr>


                                                        <tr>
                                                            <td>
                                                                <p style="margin-top: 4px; margin-bottom: 3px">
                                                                    Department :
                                                                    <asp:Label ID="lblDepartment" runat="server"></asp:Label>
                                                                </p>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <p style="margin-top: 4px; margin-bottom: 3px">
                                                                    Institution :
                                                                    <asp:Label ID="lblInstitute" runat="server"></asp:Label>
                                                                </p>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>

                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</div>
