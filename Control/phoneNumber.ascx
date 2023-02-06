<%@ Control Language="C#" AutoEventWireup="true" CodeFile="phoneNumber.ascx.cs" Inherits="control_phoneNumber" %>
<script lang="javascript" type="text/javascript">
    function CheckControl(ctrl) {
        if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == ".") {
            document.getElementById(ctrl).style.backgroundColor = "#fc6";
            return false;
        }
        else
            document.getElementById(ctrl).style.backgroundColor = "#fff";
        return true;
    }
    function CheckNumber(ctrl) {
        var y = document.getElementById(ctrl).value;
        if (y.length > 10) {
            document.getElementById(ctrl).style.backgroundColor = "#fc6";
            return false;
        }
        else {
            document.getElementById(ctrl).style.backgroundColor = "#fff";
            return true;
        }
    }
    function Phonevalidation() {
        var flag = true;
        var msg = "", ctrl = "";
        if (!CheckControl("<%=ddlPhoneType.ClientID%>")) {
            msg += " * Select Contact Type \n";
            if (ctrl == "")
                ctrl = "<%=ddlPhoneType.ClientID%>";
            flag = false;
        }
        if (!CheckControl("<%=txtPhoneNumber.ClientID%>")) {
            msg += " * Enter Contact No \n";
            if (ctrl == "")
                ctrl = "<%=txtPhoneNumber.ClientID%>";
            flag = false;
        }
        if (!CheckNumber("<%=txtPhoneNumber.ClientID%>")) {
            msg += " * Number Should not more then 10 Digit \n";
            if (ctrl == "")
                ctrl = "<%=txtPhoneNumber.ClientID%>";
            flag = false;
        }
        if (msg != "") alert(msg);
        if (ctrl != "")
            document.getElementById(ctrl).focus();
        return flag;
    }
</script>
<table style="width: 100%">
    <tr>
        <td>
            <table>
                <tr>
                    <th>Contact Type<span class="required">*</span>
                    </th>
                    <td>
                        <asp:DropDownList ID="ddlPhoneType" runat="server">
                        </asp:DropDownList>
                        <asp:TextBox ID="txtData" runat="server" Visible="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>Contact Number<span class="required">*</span></th>
                    <td>
                        <cc1:NumericTextBox ID="txtPhoneNumber" runat="server" MaxLength="12" AllowDecimal="False"
                            AllowNegative="False" DecimalPlaces="-1"></cc1:NumericTextBox>

                    </td>
                </tr>
                <tr>
                    <th></th>
                    <td style="text-align: center">
                        <asp:Button ID="btnAddPhone" runat="server" Text="Add" OnClick="btnAddPhone_Click" />
                        <asp:Button id="btnUpdate" runat="server" Text="Update" Visible="false" OnClick="btnUpdate_Click"/>
                    </td>
                </tr>
                <tr>

                    <td colspan="2">
                        <asp:GridView ID="gvAddPhone" runat="server" AutoGenerateColumns="False" OnRowDeleting="gvAddPhone_RowDeleting" OnRowCommand="gvAddPhone_RowCommand" DataKeyNames="KEYID,ID">
                            <Columns>
                                <asp:TemplateField HeaderText="S.No.">
                                    <ItemTemplate>
                                        <%# ((GridViewRow)Container).RowIndex + 1%>
                                    </ItemTemplate>
                                    <ItemStyle Width="15px" />
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Phone Type" DataField="PHN_TYPE_VALUE" />
                                <asp:BoundField HeaderText="Phone No." DataField="PHN_NO" />
                                <asp:CommandField SelectText="Edit" ShowSelectButton="True" />
                                <asp:CommandField ShowDeleteButton="true" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </td>

    </tr>
</table>
