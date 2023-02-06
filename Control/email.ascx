<%@ Control Language="C#" AutoEventWireup="true" CodeFile="email.ascx.cs" Inherits="control_email" %>
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
    function validation() {
        var flag = true;
        var msg = "", ctrl = "";
        if (!CheckControl("<%=ddlMailType.ClientID%>")) {
            msg += " * Select Mail Type \n";
            if (ctrl == "")
                ctrl = "<%=ddlMailType.ClientID%>";
            flag = false;
        }
        if (!CheckControl("<%=txtMailId.ClientID%>")) {
            msg += " * Enter Mail-Id \n";
            if (ctrl == "")
                ctrl = "<%=txtMailId.ClientID%>";
            flag = false;
        }
        if (!CheckControl("<%=ddlMailDomain.ClientID%>")) {
            msg += " * Select Domain \n";
            if (ctrl == "")
                ctrl = "<%=ddlMailDomain.ClientID%>";
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
                    <th>Mail Type<span class="required">*</span>
                    </th>
                    <td>
                        <asp:DropDownList ID="ddlMailType" runat="server">
                            <asp:ListItem Value="0" Text="Personal"></asp:ListItem>
                            <asp:ListItem Value="1" Text="Oficial"></asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <th>Mail<span class="required">*</span></th>
                    <td>
                        <asp:TextBox ID="txtMailId" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>Mail Domain<span class="required">*</span></th>
                    <td>

                        <asp:DropDownList ID="ddlMailDomain" runat="server">
                        </asp:DropDownList><asp:TextBox ID="txtData" runat="server" Visible="False"></asp:TextBox></td>
                </tr>
                <tr>
                    <th></th>
                    <td>
                        <asp:Button ID="btnAddEmail" runat="server" Text="Add Email" OnClick="btnAddEmail_Click" />
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" Visible="false" OnClick="btnUpdate_Click" />
                    </td>
                </tr>
                <tr>

                    <td style="text-align: center" colspan="2">
                        <asp:GridView ID="gvAddEmail" runat="server" AutoGenerateColumns="False" OnRowDeleting="gvAddEmail_RowDeleting" OnRowCommand="gvAddEmail_RowCommand" DataKeyNames="KEYID,ID">
                            <Columns>
                                <asp:TemplateField HeaderText="S.No.">
                                    <ItemTemplate>
                                        <%# ((GridViewRow)Container).RowIndex + 1%>
                                    </ItemTemplate>
                                    <ItemStyle Width="15px" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="MAIL_TYPE_VALUE" HeaderText="Mail Type" />
                                <asp:BoundField DataField="MAIL_VALUE" HeaderText="Mail" />
                                <asp:BoundField DataField="MAIL_DOM_VALUE" HeaderText="Domin" />
                                <asp:CommandField SelectText="Edit" ShowSelectButton="True" />
                                <asp:CommandField ShowDeleteButton="true" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </td>

</table>
