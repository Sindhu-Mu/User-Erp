<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Short.master" AutoEventWireup="true" CodeFile="VendorReg.aspx.cs" Inherits="Inventory_VendorReg" %>

<%@ Register Src="~/Control/address.ascx" TagPrefix="uc1" TagName="address" %>
<%@ Register Src="~/Control/phoneNumber.ascx" TagPrefix="uc1" TagName="phoneNumber" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentHolder1" runat="Server">
    <script language="javascript" type="text/javascript">
        function CheckControl(ctrl) {
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == ".") {
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
                return false;
            }
            else
                document.getElementById(ctrl).style.backgroundColor = "#fff";
            return true;
        }
        function validate() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=ddlOrgMainDomain.ClientID%>")) {
                msg += "- Select Mail Domain. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlOrgMainDomain.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlStore.ClientID%>")) {
                msg += "- Select Store. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlStore.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtOrgMail.ClientID%>")) {
                msg += "- Enter Mail Id. \n";
                if (ctrl == "")
                    ctrl = "<%=txtOrgMail.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtOrgMobileNo.ClientID%>")) {
                msg += "- Enter Mobile No. \n";
                if (ctrl == "")
                    ctrl = "<%=txtOrgMobileNo.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtOrgName.ClientID%>")) {
                msg += "- Enter Organisation Name. \n";
                if (ctrl == "")
                    ctrl = "<%=txtOrgName.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtOrgPhone.ClientID%>")) {
                msg += "- Enter Phone No. \n";
                if (ctrl == "")
                    ctrl = "<%=txtOrgPhone.ClientID%>";
                flag = false;
            }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }
    </script>
    <div class="container">
        <div class="heading">
            <h2>Vendor Main
            </h2>
        </div>
        <div>
            <table>
                <tr>
                    <th>Store<span class="required">*</span>
                    </th>
                    <td>
                        <asp:DropDownList ID="ddlStore" runat="server"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <th>Organisation Name<span class="required">*</span>
                    </th>
                    <td>
                        <asp:TextBox ID="txtOrgName" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <uc1:address runat="server" ID="address" />
                    </td>
                </tr>
                <tr>
                    <th>Mobile Number<span class="required">*</span>
                    </th>
                    <td>
                        <cc1:NumericTextBox ID="txtOrgMobileNo" runat="server" MaxLength="10" AllowDecimal="False"
                            AllowNegative="False" DecimalPlaces="-1"></cc1:NumericTextBox>
                    </td>
                </tr>
                <tr>
                    <th>Landline Number<span class="required">*</span>
                    </th>
                    <td>
                        <cc1:NumericTextBox ID="txtOrgPhone" runat="server" MaxLength="12" AllowDecimal="False"
                            AllowNegative="False" DecimalPlaces="-1"></cc1:NumericTextBox>
                    </td>
                </tr>
                <tr>
                    <th>Mail Id<span class="required">*</span>
                    </th>
                    <td>
                        <asp:TextBox ID="txtOrgMail" runat="server" Width="150px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>Mail Domain<span class="required">*</span>
                    </th>
                    <td>
                        <asp:DropDownList ID="ddlOrgMainDomain" runat="server"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td style="text-align: right">
                        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

