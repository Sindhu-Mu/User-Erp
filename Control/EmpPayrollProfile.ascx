<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EmpPayrollProfile.ascx.cs" Inherits="Control_EmpPayrollProfile" %>
<style>
    .payroll_cntrl tr td {
        color: #fff;
    }
</style>
<div id="div1" style="background-color: #b22222; padding: 10px; width: 98%" runat="server">
    <table border="0" style="font-family: Arial, Sans-Serif; font-weight: bold;" class="payroll_cntrl">
        <tr>
            <td>
                <table border="0" style="font-family: Tahoma; font-size: 13px; border-collapse: collapse;" class="payroll_cntrl">
                    <tr>
                        <td  style="padding: 5px">
                            <img id="imgPicture" runat="server" alt="Image" src="../images/emp_images/empImage.jpg"
                                style="border: 1px solid #000000; padding: 0; width: 110px; height: 125px;" /></td>
                        <td >&nbsp;</td>
                        <td >
                            <table border="0"  style="border-collapse: collapse">
                                <tr>
                                    <td>
                                        <table border="0">
                                            <tr>
                                                <td style="width: 50%">
                                                    <table border="0">
                                                        <tr>
                                                            <td>
                                                                <p style="margin-top: 4px; margin-bottom: 3px">
                                                                    <b>Name :</b>
                                                                    <asp:Label ID="lblAA" runat="server">ss</asp:Label>
                                                                    <asp:Label ID="lblName" runat="server"></asp:Label>
                                                                </p>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <p style="margin-top: 4px; margin-bottom: 3px">
                                                                    <b>Date of Birth :</b>&nbsp;
                                                                    <asp:Label ID="lblDob" runat="server"></asp:Label>
                                                                </p>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <p style="margin-top: 4px; margin-bottom: 3px">
                                                                    <b>Date of Joining :</b>
                                                                    <asp:Label ID="lblDoj" runat="server"></asp:Label>
                                                                </p>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <p style="margin-top: 4px; margin-bottom: 3px">
                                                                    <b>Designation :</b>
                                                                    <asp:Label ID="lblDesg" runat="server"></asp:Label>
                                                                </p>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <p style="margin-top: 4px; margin-bottom: 3px">
                                                                    <b>Mobile :</b>
                                                                    <asp:Label ID="lblMobile" runat="server"></asp:Label>
                                                                </p>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <p>
                                                                    <b>Email :</b>
                                                                    <asp:Label ID="lblEmail" runat="server"></asp:Label>
                                                                </p>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td  style="width: 50%">
                                                    <table border="0" >
                                                        <tr>
                                                            <td>
                                                                <p style="margin-top: 4px; margin-bottom: 3px">
                                                                    <b>Code No :</b> #<asp:Label ID="lblCode" runat="server"></asp:Label>
                                                                </p>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <p style="margin-top: 4px; margin-bottom: 3px">
                                                                    <b>Department :</b>
                                                                    <asp:Label ID="lblDepartment" runat="server"></asp:Label>&nbsp;<b>Institute :</b>
                                                                    <asp:Label ID="lblInstitute" runat="server"></asp:Label>
                                                                </p>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <p style="margin-top: 4px; margin-bottom: 3px">
                                                                    &nbsp;<b>Salary Template :</b>
                                                                    <asp:Label ID="lblTemplate" runat="server"></asp:Label>
                                                                </p>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <p style="margin-top: 4px; margin-bottom: 3px">
                                                                    &nbsp;<b>Pay Scale :</b>
                                                                    <asp:Label ID="lblScale" runat="server"></asp:Label>
                                                                </p>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <p style="margin-top: 4px; margin-bottom: 3px">
                                                                    &nbsp;<b>Gross Pay :</b>
                                                                    <asp:Label ID="lblGross" runat="server"></asp:Label>
                                                                    &nbsp;<b>Status :</b>
                                                                    <asp:Label ID="lblStatus" runat="server"></asp:Label>
                                                                </p>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <p style="margin-top: 4px; margin-bottom: 3px">
                                                                    &nbsp;<b>PAN:</b>
                                                                    <asp:Label ID="lblPan" runat="server"></asp:Label>
                                                                    &nbsp;<b>Account :</b>
                                                                    <asp:Label ID="lblAccount" runat="server"></asp:Label>
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
