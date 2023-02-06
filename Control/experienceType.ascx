<%@ Control Language="C#" AutoEventWireup="true" CodeFile="experienceType.ascx.cs"
    Inherits="control_experienceType" %>
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
        if (!CheckControl("<%=ddlExpType.ClientID%>")) {
            msg += " * Select Exprince Type \n";
            if (ctrl == "")
                ctrl = "<%=ddlExpType.ClientID%>";
            flag = false;
        }
        if (!CheckControl("<%=txtDesignation.ClientID%>")) {
            msg += " * Enter Designation \n";
            if (ctrl == "")
                ctrl = "<%=txtDesignation.ClientID%>";
            flag = false;
        }
        if (!CheckControl("<%=ddlOrg.ClientID%>")) {
            msg += " * Select Organization \n";
            if (ctrl == "")
                ctrl = "<%=ddlOrg.ClientID%>";
            flag = false;
        }
        if (!CheckControl("<%=txtFromDT.ClientID%>")) {
            msg += " * Enter From Date \n";
            if (ctrl == "")
                ctrl = "<%=txtFromDT.ClientID%>";
            flag = false;
        }
        if (!CheckControl("<%=txtToDT.ClientID%>")) {
            msg += " * Enter To Date \n";
            if (ctrl == "")
                ctrl = "<%=txtToDT.ClientID%>";
            flag = false;
        }
        if (msg != "") alert(msg);
        if (ctrl != "")
            document.getElementById(ctrl).focus();
        return flag;
    }
    function validate() {
        var flag = true;
        var msg = "", ctrl = "";

        if (!CheckControl("<%=txtOrgName.ClientID%>")) {
            msg += " * Enter Organization Name \n";
            if (ctrl == "")
                ctrl = "<%=txtOrgName.ClientID%>";
            flag = false;
        }
        if (!CheckControl("<%=ddlType.ClientID%>")) {
            msg += " * Select Organization Type \n";
            if (ctrl == "")
                ctrl = "<%=ddlType.ClientID%>";
            flag = false;
        }
        if (!CheckControl("<%=txtAddress.ClientID%>")) {
            msg += " * Enter Address \n";
            if (ctrl == "")
                ctrl = "<%=txtAddress.ClientID%>";
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
                    <th>Experience Type 
                        <span class="expected">*</span></th>
                    <td>
                        <asp:DropDownList ID="ddlExpType" runat="server" Height="30px"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <th>Designation<span class="expected">*</span></th>
                    <td>
                        <asp:TextBox ID="txtDesignation" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>
                        <asp:LinkButton ID="lnkPrime" runat="server" Font-Bold="true">Organization</asp:LinkButton>
                        <span class="expected">*</span></th>
                    <td>
                        <asp:DropDownList ID="ddlOrg" runat="server"></asp:DropDownList>
                    </td>
                </tr>

                <tr>
                    <th>From Date<span class="expected">*</span></th>
                    <td>
                        <asp:TextBox ID="txtFromDT" runat="server" Width="86px"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="cal1" runat="server" TargetControlID="txtFromDT" Format="dd/MM/yyyy">
                        </ajaxToolkit:CalendarExtender>
                        <ajaxToolkit:MaskedEditExtender ID="me1" runat="server" Mask="99/99/9999" MaskType="Date"
                            TargetControlID="txtFromDT">
                        </ajaxToolkit:MaskedEditExtender>
                    </td>
                </tr>
                <tr>
                    <th>To Date<span class="expected">*</span></th>
                    <td>
                        <asp:TextBox ID="txtToDT" runat="server" Width="86px"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="cal2" runat="server" TargetControlID="txtToDT" Format="dd/MM/yyyy">
                        </ajaxToolkit:CalendarExtender>
                        <ajaxToolkit:MaskedEditExtender ID="me2" runat="server" Mask="99/99/9999" MaskType="Date"
                            TargetControlID="txtToDT">
                        </ajaxToolkit:MaskedEditExtender>
                    </td>
                </tr>
                <tr>
                    <th>Job Description</th>
                    <td>
                        <asp:TextBox ID="txtJobDesc" runat="server" TextMode="MultiLine" Height="56px" Width="179px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th></th>
                    <td>
                        <asp:Button ID="btnAddExp" runat="server" Text="Add" Width="49px" OnClick="btnAddExp_Click" />
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" Visible="false" OnClick="btnUpdate_Click" />
                        <asp:TextBox ID="TextBox1" runat="server" Visible="False"></asp:TextBox></td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            <asp:GridView ID="gridExperience" runat="server" AutoGenerateColumns="false"  DataKeyNames="KEYID,ID"
                OnRowDeleting="gridExperience_RowDeleting" OnRowCommand="gridExperience_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="S.No.">
                        <ItemTemplate>
                            <%# ((GridViewRow)Container).RowIndex + 1%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Type" DataField="EXP_TYPE_VALUE" />
                    <asp:BoundField HeaderText="Designation" DataField="EXP_DESIG" />
                    <asp:BoundField HeaderText="Office" DataField="ORG_NAME" />
                    <asp:BoundField HeaderText="From Date" DataField="FRM_DATE" DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:BoundField HeaderText="To Date" DataField="TO_DATE" DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:CommandField SelectText="Edit" ShowSelectButton="True" />
                    <asp:CommandField ShowDeleteButton="true" />
                </Columns>
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td>
            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender" runat="server" BackgroundCssClass="modalBackground"
                CancelControlID="CancelButton" DropShadow="true" PopupControlID="Panel1" PopupDragHandleControlID="Panel3"
                TargetControlID="lnkPrime">
            </ajaxToolkit:ModalPopupExtender>
            <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" Style="display: none">
                <asp:Panel ID="Panel3" runat="server" Style="border-right: gray 1px solid; border-top: gray 1px solid; border-left: gray 1px solid; cursor: move; color: black; border-bottom: gray 1px solid; background-color: #dddddd">
                    <div>
                        <p>
                            <b>Organization </b>
                        </p>
                    </div>
                </asp:Panel>
                <div>
                    <table class="entry">
                        <tr>
                            <th>Organization <span class="required">*</span></th>
                            <td>
                                <asp:TextBox ID="txtOrgName" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>Organization Type <span class="required">*</span></th>
                            <td>
                                <asp:DropDownList ID="ddlType" runat="server"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <th>Address<span class="required">*</span></th>
                            <td>
                                <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" Rows="5" Height="94px" Width="185px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>State<span class="required">*</span></th>
                            <td>
                                <asp:DropDownList ID="ddlState" runat="server" Width="91px" AutoPostBack="True" OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <th>City<span class="required">*</span></th>
                            <td>
                                <asp:DropDownList ID="ddlCity" runat="server" Width="91px">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Button ID="btnOrgSave" runat="server" Text="Save" OnClick="btnOrgSave_Click"
                                    Width="73px" />
                                <asp:Button ID="CancelButton" runat="server" Text="Cancel" />
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
        </td>
    </tr>

</table>
