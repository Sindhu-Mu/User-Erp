<%@ Control Language="C#" AutoEventWireup="true" CodeFile="address.ascx.cs" Inherits="control_address" %>


<script lang="javascript" type="text/javascript">
    function CheckControl(ctrl) {
        if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == "." || bTrim(document.getElementById(ctrl).value) == "Select") {
            document.getElementById(ctrl).style.backgroundColor = "#fc6";
            return false;
        }
        else
            document.getElementById(ctrl).style.backgroundColor = "#fff";
        return true;
    }
    function Addressvalidation() {
        var flag = true;
        var msg = "", ctrl = "";
        if (!CheckControl("<%=ddlAddressType.ClientID%>")) {
            msg += " * Enter Name  \n";
            if (ctrl == "")
                ctrl = "<%=ddlAddressType.ClientID%>";
            flag = false;
        }
        if (!CheckControl("<%=txtAddress1.ClientID%>")) {
            msg += " * Enter Address line 1 \n";
            if (ctrl == "")
                ctrl = "<%=txtAddress1.ClientID%>";
            flag = false;
        }
        if (!CheckControl("<%=ddlCountry.ClientID%>")) {
            msg += " * Select Country \n";
            if (ctrl == "")
                ctrl = "<%=ddlCountry.ClientID%>";
            flag = false;
        }
        if (!CheckControl("<%=ddlState.ClientID%>")) {
            msg += " * Select State \n";
            if (ctrl == "")
                ctrl = "<%=ddlState.ClientID%>";
            flag = false;
        }
        if (!CheckControl("<%=ddlCity.ClientID%>")) {
            msg += " * Select City \n";
            if (ctrl == "")
                ctrl = "<%=ddlCity.ClientID%>";
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
                    <th style="width: 150px">Address Type<span class="required">*</span>
                    </th>
                    <td>
                        <asp:DropDownList ID="ddlAddressType" runat="server" Width="95px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <th>Address Line 1<span class="required">*</span>
                    </th>
                    <td>
                        <asp:TextBox ID="txtAddress1" runat="server" MaxLength="100" TextMode="MultiLine"
                            Rows="3"></asp:TextBox></td>
                </tr>
                <tr>
                    <th>Address Line 2</th>
                    <td>
                        <asp:TextBox ID="txtAddress2" runat="server" MaxLength="100" TextMode="MultiLine"
                            Rows="3"></asp:TextBox></td>
                </tr>
                <tr>
                    <th>Country</th>
                    <td>
                        <asp:DropDownList ID="ddlCountry" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <th>State<span class="required">*</span>
                    </th>
                    <td>
                        <asp:DropDownList ID="ddlState" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <th>City<span class="required">*</span>
                    </th>
                    <td>
                        <asp:DropDownList ID="ddlCity" runat="server">
                        </asp:DropDownList></td>
                </tr>
                 <tr>
                    <th>Pin
                    </th>
                    <td>
                        <asp:TextBox ID="txtPin" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <th></th>
                    <td>
                        <asp:Button ID="btnAdd" runat="server" Text="Add" Width="49px" EnableViewState="false"
                            OnClick="btnAdd_Click" />
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" Visible="false" />

                        <asp:TextBox ID="TextBox1" runat="server" Visible="false"></asp:TextBox>

                    </td>
                </tr>
            </table>
        </td>
    </tr>

    <tr>
        <td>
            <asp:GridView ID="gridData" runat="server" AutoGenerateColumns="false" DataKeyNames="KEYID,ID"
                OnRowDeleting="gridData_RowDeleting" OnRowCommand="gridData_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="S.No.">
                        <ItemTemplate>
                            <%# ((GridViewRow)Container).RowIndex + 1%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Type" DataField="ADD_TYPE_VALUE" />
                    <asp:BoundField HeaderText="Add 1" DataField="ADD_1" />
                    <asp:BoundField HeaderText="Add 2" DataField="ADD_2" />
                    <asp:BoundField HeaderText="Country" DataField="COU_VALUE" />
                    <asp:BoundField HeaderText="State" DataField="STA_VALUE" />
                    <asp:BoundField HeaderText="City" DataField="CIT_VALUE" />
                    <asp:BoundField HeaderText="Pin Code" DataField="PINCODE" />
                    <asp:CommandField SelectText="Edit" ShowSelectButton="True" />
                    <asp:CommandField ShowDeleteButton="true" />
                </Columns>
            </asp:GridView>
        </td>
    </tr>
</table>
