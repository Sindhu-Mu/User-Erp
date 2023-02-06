<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditProfile.aspx.cs" Inherits="Common_EditProfile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Edit Profile</title>
    <link href="../css/menu.css" type="text/css" rel="stylesheet" />
    <script src="../js/date.js" type="text/javascript"></script>




</head>
<body>
    <form id="form2" runat="server">
        <div style="padding: 15px">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <table border="0" style="padding: 10px; border: solid 2px #cc6d18; width: 650px">
                <tr>
                    <td align="center" colspan="3">
                        <span style="font-size: 18pt; text-decoration: underline">Edit Profile</span></td>
                </tr>
                <tr>
                    <td>
                        <table>
                            <tr>
                                <td class="auto-style2">
                                    <img id="imgPicture" runat="server" alt="Upload Image" border="0" src="../images/emp_images/empImage.jpg" />
                                </td>
                                <td>
                                    <table>
                                        <tr>
                                            <td style="width: 320px">
                                                <h4>Personal Information</h4>
                                            </td>


                                        </tr>
                                        <tr>


                                            <td>
                                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td valign="top" width="55%">
                                                            <table border="0" cellpadding="0" cellspacing="0" style="font-size: 11px; font-family: Tahoma"
                                                                width="100%">
                                                                <tr>

                                                                    <td colspan="2">
                                                                        <p style="margin-top: 4px; margin-bottom: 3px">
                                                                            <b>Employee Name :<br />
                                                                                (Initial-First Name-Middle Name-Last Name)<br />
                                                                            </b>
                                                                            <asp:DropDownList ID="ddlInitial" runat="server" Font-Names="Tahoma" Font-Size="11px">
                                                                            </asp:DropDownList>
                                                                            <asp:TextBox ID="txtFname" runat="server"  MaxLength="15"
                                                                                Width="55px"></asp:TextBox>
                                                                            <asp:TextBox ID="txtMname" runat="server"  MaxLength="15"
                                                                                Width="55px"></asp:TextBox><strong> </strong>
                                                                            <asp:TextBox ID="txtLname" runat="server"  MaxLength="20"
                                                                                Width="55px"></asp:TextBox>
                                                                        </p>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <p style="margin-top: 4px; margin-bottom: 3px">
                                                                            <b>Father's Name :</b>
                                                                        </p>
                                                                    </td>
                                                                    <td>
                                                                        <p style="margin-top: 4px; margin-bottom: 3px">
                                                                            <asp:TextBox ID="txtFathersName" runat="server" MaxLength="30"
                                                                                Width="130px"></asp:TextBox>
                                                                        </p>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <p style="margin-top: 4px; margin-bottom: 3px">
                                                                            <b>Marital Status :</b>
                                                                        </p>
                                                                    </td>
                                                                    <td>
                                                                        <p style="margin-top: 4px; margin-bottom: 3px">
                                                                            <asp:DropDownList ID="ddlMeritalStatus" runat="server" Font-Names="Tahoma" Font-Size="11px">

                                                                                <asp:ListItem Value="0" Text="Unmarried"></asp:ListItem>
                                                                                <asp:ListItem Value="1" Text="Married"></asp:ListItem>
                                                                                <asp:ListItem Value="2" Text="Divorced"></asp:ListItem>
                                                                                <asp:ListItem Value="3" Text="Widow"></asp:ListItem>
                                                                                <asp:ListItem Value="4" Text="Widower"></asp:ListItem>

                                                                            </asp:DropDownList>
                                                                        </p>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <p style="margin-top: 4px; margin-bottom: 3px">
                                                                            <b>Spouse's Name :</b>
                                                                        </p>
                                                                    </td>
                                                                    <td>
                                                                        <p style="margin-top: 4px; margin-bottom: 3px">
                                                                            <asp:TextBox ID="txtSpouseName" runat="server" MaxLength="30"
                                                                                Width="120px"></asp:TextBox><strong> </strong>
                                                                        </p>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <p style="margin-top: 4px; margin-bottom: 3px">
                                                                            <b>Next Kin :</b>
                                                                        </p>
                                                                    </td>
                                                                    <td>
                                                                        <p style="margin-top: 4px; margin-bottom: 3px">
                                                                            <asp:TextBox ID="txtNextKin" runat="server" MaxLength="30"
                                                                                Width="120px"></asp:TextBox>
                                                                        </p>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <p style="margin-top: 4px; margin-bottom: 3px">
                                                                            <b>Blood Group:</b>
                                                                        </p>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlBlood" runat="server" Font-Names="Tahoma" Font-Size="12px" Width="100px">
                                                                        </asp:DropDownList></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td valign="top" width="45%">
                                                            <table border="0" cellpadding="0" cellspacing="0" style="font-size: 11px; font-family: Tahoma"
                                                                width="100%">
                                                                <tr>
                                                                    <td>
                                                                        <p style="margin-top: 4px; margin-bottom: 3px">
                                                                            <b>Sex :</b>
                                                                        </p>
                                                                    </td>
                                                                    <td>
                                                                        <p style="margin-top: 4px; margin-bottom: 3px">
                                                                            <asp:RadioButtonList ID="optLstSex" runat="server" RepeatDirection="Horizontal">
                                                                                <asp:ListItem Selected="True" Value="1">Male</asp:ListItem>
                                                                                <asp:ListItem Value="2">Female</asp:ListItem>
                                                                            </asp:RadioButtonList>
                                                                        </p>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <p style="margin-top: 4px; margin-bottom: 3px">
                                                                            <b>Date of Birth :</b>
                                                                        </p>
                                                                    </td>
                                                                    <td>
                                                                        <p style="margin-top: 4px; margin-bottom: 3px">
                                                                            <asp:TextBox ID="txtDOB" runat="server"  MaxLength="10"
                                                                                Width="65px"></asp:TextBox>&nbsp;
                                                                        </p>
                                                                        <ajaxToolkit:CalendarExtender ID="cal1" runat="server" TargetControlID="txtDOB" Format="dd/MM/yyyy">
                                                                        </ajaxToolkit:CalendarExtender>
                                                                        <ajaxToolkit:MaskedEditExtender ID="me1" runat="server" Mask="99/99/9999" MaskType="Date"
                                                                            TargetControlID="txtDOB">
                                                                        </ajaxToolkit:MaskedEditExtender>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="height: 26px">
                                                                        <p style="margin-top: 4px; margin-bottom: 3px">
                                                                            <b>Caste :</b>
                                                                        </p>
                                                                    </td>
                                                                    <td style="height: 26px">
                                                                        <p style="margin-top: 4px; margin-bottom: 3px">
                                                                            <asp:DropDownList ID="ddlCaste" runat="server" Font-Names="Tahoma" Font-Size="11px">
                                                                            </asp:DropDownList>
                                                                        </p>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <p style="margin-top: 4px; margin-bottom: 3px">
                                                                            <b>Mother Tongue:</b>
                                                                        </p>
                                                                    </td>
                                                                    <td>
                                                                        <p style="margin-top: 4px; margin-bottom: 3px">
                                                                            <asp:TextBox ID="txtMotherTongue" runat="server"  MaxLength="20"
                                                                                Width="120px"></asp:TextBox>
                                                                        </p>
                                                                    </td>
                                                                </tr>

                                                                <tr>
                                                                    <td>
                                                                        <p style="margin-top: 4px; margin-bottom: 3px">
                                                                            <b>Nationality :</b>
                                                                        </p>
                                                                    </td>
                                                                    <td>
                                                                        <p style="margin-top: 4px; margin-bottom: 3px">
                                                                            <asp:DropDownList ID="ddlNationality" runat="server"  MaxLength="20"
                                                                                Width="120px"></asp:DropDownList>
                                                                        </p>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <p style="margin-top: 4px; margin-bottom: 3px">
                                                                            <b>Religion :</b>
                                                                        </p>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlReligion" runat="server" Width="100px">
                                                                        </asp:DropDownList>

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

                <tr>
                    <td>
                        <hr style="color: #ff8c00; width: 100%; height: 0px; border-bottom-color: red; border-collapse: collapse; border-spacing: 0px;" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <h4>Communication Information</h4>
                    </td>
                </tr>
                <tr style="font-size: 8pt">
                    <td>
                        <table border="0" cellpadding="0" cellspacing="0" style="font-size: 11px; font-family: Tahoma"
                            width="100%">
                            <tr>
                                <td valign="top" style="width: 122px">
                                    <p style="margin-top: 4px; margin-bottom: 3px">
                                        <b>Present Address :</b>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p style="margin-top: 4px; margin-bottom: 3px">
                                        <asp:TextBox ID="txtPresentAddres" runat="server"  MaxLength="200"
                                            Width="97%"></asp:TextBox>
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" style="width: 122px">
                                    <p style="margin-top: 4px; margin-bottom: 3px">
                                        <b>Permanent Address :</b>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p style="margin-top: 4px; margin-bottom: 3px">
                                        <asp:TextBox ID="txtPermanentAddress" runat="server"  MaxLength="200"
                                            Width="97%"></asp:TextBox>
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" style="width: 122px; height: 26px">
                                    <p style="margin-top: 4px; margin-bottom: 3px">
                                        <b>Email :</b>
                                    </p>
                                </td>
                                <td valign="top" style="height: 26px">
                                    <p style="margin-top: 4px; margin-bottom: 3px">
                                        <asp:TextBox ID="txtEmailID" runat="server"  MaxLength="50"
                                            Width="97%"></asp:TextBox>
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" style="width: 122px">
                                    <p style="margin-top: 4px; margin-bottom: 3px">
                                        <b>Phone/Extension :</b>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p style="margin-top: 4px; margin-bottom: 3px">
                                        <asp:TextBox ID="txtPh_Ext" runat="server"  MaxLength="30"
                                            Width="97%"></asp:TextBox>
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" style="width: 122px">
                                    <p style="margin-top: 4px; margin-bottom: 3px">
                                        <b>Mobile :</b>
                                    </p>
                                </td>
                                <td valign="top">
                                    <p style="margin-top: 4px; margin-bottom: 3px">
                                        <asp:TextBox ID="txtMobileNo" runat="server"  MaxLength="30"
                                            Width="97%"></asp:TextBox>
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td height="8" style="font-size: 4px; width: 122px;" valign="top"></td>
                            </tr>
                        </table>
                    </td>
                </tr>

                <tr>
                    <td>
                        <hr style="color: #ff8c00; width: 100%; height: 0px; border-bottom-color: red; border-bottom-width: 1px; border-collapse: collapse; border-spacing: 0px;" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <h4>Departmental Information</h4>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table>
                            <tr>
                                <td valign="top" class="auto-style2">
                                    <table border="0" cellpadding="0" cellspacing="0"  style="font-size: 11px; font-family: Tahoma"
                                        width="100%">
                                        <tr>
                                            <td>
                                                <p style="margin-top: 4px; margin-bottom: 3px">
                                                    <b>Code No :</b>
                                                </p>
                                            </td>
                                            <td>
                                                <p style="margin-top: 4px; margin-bottom: 3px">
                                                    #<asp:Label ID="lblCode" runat="server"></asp:Label>
                                                </p>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <p style="margin-top: 4px; margin-bottom: 3px">
                                                    <b>Date of Joining :</b>
                                                </p>
                                            </td>
                                            <td>
                                                <p style="margin-top: 4px; margin-bottom: 3px">
                                                    <asp:TextBox ID="txtDOJ" runat="server"  MaxLength="10"
                                                        Width="65px"></asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID="CE2" runat="server" Format="dd/MM/yyyy" TargetControlID="txtDOJ">
                                                    </ajaxToolkit:CalendarExtender>
                                                </p>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <p style="margin-top: 4px; margin-bottom: 3px">
                                                    <b>Next Senior :</b>
                                                </p>
                                            </td>
                                            <td>
                                                <p style="margin-top: 4px; margin-bottom: 3px">
                                                    <asp:DropDownList ID="ddlNextSenior" runat="server" Font-Names="Tahoma" Font-Size="11px"
                                                        Width="200px">
                                                    </asp:DropDownList>
                                                </p>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td valign="top">
                                    <table border="0" cellpadding="0" cellspacing="0" style="font-size: 11px; font-family: Tahoma"
                                        width="100%">
                                        <tr>
                                            <td>
                                                <p style="margin-top: 4px; margin-bottom: 3px">
                                                    <b>Designation :</b>
                                                </p>
                                            </td>
                                            <td>
                                                <p style="margin-top: 4px; margin-bottom: 3px">
                                                    <asp:DropDownList ID="ddlDesignation" runat="server" Font-Names="Tahoma" Font-Size="11px"
                                                        Width="200px">
                                                    </asp:DropDownList>
                                                </p>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <p style="margin-top: 4px; margin-bottom: 3px">
                                                    <b>Department :</b>
                                                </p>
                                            </td>
                                            <td>
                                                <p style="margin-top: 4px; margin-bottom: 3px">
                                                    <asp:DropDownList ID="ddlDept" runat="server" Font-Names="Tahoma" Font-Size="11px"
                                                        Width="200px">
                                                    </asp:DropDownList>
                                                </p>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <p style="margin-top: 4px; margin-bottom: 3px">
                                                    <b>Institution :</b>
                                                </p>
                                            </td>
                                            <td>
                                                <p style="margin-top: 4px; margin-bottom: 3px">
                                                    <asp:DropDownList ID="ddlInstitution" runat="server" Font-Names="Tahoma" Font-Size="11px"
                                                        Width="200px">
                                                    </asp:DropDownList>
                                                </p>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>

                </tr>

                <tr>
                    <td>
                        <hr style="color: #ff8c00; width: 100%; height: 0px; border-bottom-color: red; border-bottom-width: 1px; border-collapse: collapse; border-spacing: 0px;" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <h4>Payroll Information</h4>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table border="0" cellpadding="0" cellspacing="0" style="font-size: 11px; font-family: Tahoma"
                            width="100%">
                            <tr>
                                <td style="height: 23px; width: 79px;">
                                    <p style="margin-top: 4px; margin-bottom: 3px">
                                        <b>Bank A/C No :</b>
                                    </p>
                                </td>
                                <td style="height: 23px">
                                    <p style="margin-top: 4px; margin-bottom: 3px">
                                        <asp:TextBox ID="txtAcNo" runat="server"  MaxLength="20"
                                            Width="97%"></asp:TextBox>
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 20px; width: 79px;">
                                    <p style="margin-top: 4px; margin-bottom: 3px">
                                        <b>Bank Name :</b>
                                    </p>
                                </td>
                                <td style="height: 20px">
                                    <p style="margin-top: 4px; margin-bottom: 3px">
                                        <asp:TextBox ID="txtBank" runat="server"  MaxLength="30"
                                            Width="97%"></asp:TextBox>
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 79px; height: 20px">
                                    <strong>PAN &nbsp;No:</strong></td>
                                <td style="height: 20px">
                                    <asp:TextBox ID="txtPan" runat="server"  MaxLength="30"
                                        Width="97%">0</asp:TextBox></td>
                            </tr>
                        </table>
                    </td>
                </tr>

                <tr>

                    <td align="right">
                        <asp:Button ID="btnUpdate" runat="server" Text="Forward  To HR" BackColor="#468b3c" />
                        <asp:Button ID="btnClose" runat="server" Text="Close" BackColor="#468b3c" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
