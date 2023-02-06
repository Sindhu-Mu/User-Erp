<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Short.master" AutoEventWireup="true" CodeFile="VacationLeave.aspx.cs" Inherits="HR_VacationLeave" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentHolder1" runat="Server">
    <script language="javascript" type="text/javascript">

        function SelectAllCheckboxes(spanChk) {


            var oItem = spanChk.children;
            var theBox = (spanChk.type == "checkbox") ?
                spanChk : spanChk.children.item[0];
            xState = theBox.checked;
            elm = theBox.form.elements;

            for (i = 0; i < elm.length; i++)
                if (elm[i].type == "checkbox" &&
                         elm[i].id != theBox.id) {

                    if (elm[i].checked != xState)
                        elm[i].click();
                }
        }

        function CheckAutoComplete(ctrl) {

            var Value = bTrim(document.getElementById(ctrl).value);
            if (Value.indexOf(":") > 0 && Value.length - 1 != Value.lastIndexOf(":")) {
                document.getElementById(ctrl).style.backgroundColor = "#fff";
                return true;
            }
            else
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
            return false;
        }

        function CheckControl(ctrl) {
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == "." || bTrim(document.getElementById(ctrl).value) == "Select") {
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
                return false;
            }
            else {
                document.getElementById(ctrl).style.backgroundColor = "#fff";
                return true;
            }
        }
        function CheckDate(ctrl) {
            var dt = document.getElementById(ctrl).value;
            if (!isDatecheck(dt, "dd/MM/yyyy")) {
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
            if (!CheckControl("<%=ddlType.ClientID%>")) {
                msg += "- Select Vacation Type from List\n";
                if (ctrl == "")
                    ctrl = "<%=ddlType.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlIns.ClientID%>")) {
                msg += "- Select Institute from the List \n";
                if (ctrl == "")
                    ctrl = "<%=ddlIns.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlDept.ClientID%>")) {
                msg += "- Select Department from the List \n";
                if (ctrl == "")
                    ctrl = "<%=ddlDept.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlSaction.ClientID%>")) {
                msg += "- Enter Approved By \n";
                if (ctrl == "")
                    ctrl = "<%=ddlSaction.ClientID%>";
                flag = false;
            }
            if (!CheckDate("<%=txtFrom.ClientID%>")) {
                msg += "- Enter From Date\n";
                if (ctrl == "")
                    ctrl = "<%=txtFrom.ClientID%>";
                flag = false;
            }
            if (!CheckDate("<%=txtToDate.ClientID%>")) {
                msg += "- Enter To Date \n";
                if (ctrl == "")
                    ctrl = "<%=txtToDate.ClientID%>";
                flag = false;
            }
            if (!CheckDate("<%=AppDate.ClientID%>")) {
                msg += "- Enter Approved Date \n";
                if (ctrl == "")
                    ctrl = "<%=AppDate.ClientID%>";
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
            <h2>Vacation Leave</h2>
        </div>
        <div>
            <table>
                <tr>
                    <td>
                        <table>
                            <tr>
                                <th>Vacation Type<span class="required">*</span></th>
                                <th>Institute<span class="required">*</span></th>
                                <th>Department<span class="required">*</span></th>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlType" runat="server" OnSelectedIndexChanged="ddlType_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlIns" runat="server" OnSelectedIndexChanged="ddlIns_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlDept" runat="server" OnSelectedIndexChanged="ddlDept_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div>
                            <asp:GridView ID="gvDetail" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" DataKeyNames="USR_ID" EmptyDataText="No Record Found">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No.">
                                        <ItemTemplate><%#((GridViewRow)Container).RowIndex+1 %>.</ItemTemplate>
                                        <ItemStyle Width="15px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="EMP_ID" HeaderText="Emp.Code"/>
                                    <asp:BoundField DataField="EMP_NAME" HeaderText="Name" />
                                    <asp:TemplateField HeaderText="All">
                                        <HeaderTemplate>
                                            <input id="chkAll" onclick="javascript: SelectAllCheckboxes(this);" type="checkbox"
                                                value="on" runat="server" style="border-right: blue 2px groove; border-top: blue 2px groove; border-left: blue 2px groove; border-bottom: blue 2px groove" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CHK_SelectAll" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </td>
                </tr>
                <tr id="trDetail" runat="server" visible="false">
                    <td>
                        <table>
                            <tr>
                                <th>From Date<span class="required">*</span>
                                </th>
                                <td>
                                    <asp:TextBox ID="txtFrom" runat="server"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFrom" Format="dd/MM/yyyy">
                                    </ajaxToolkit:CalendarExtender>
                                   <%-- <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="99/99/9999" MaskType="Date"
                                        TargetControlID="txtFrom">
                                    </ajaxToolkit:MaskedEditExtender>--%>
                                </td>
                                <th>To Date<span class="required">*</span>
                                </th>
                                <td>
                                    <asp:TextBox ID="txtToDate" runat="server"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtToDate" Format="dd/MM/yyyy">
                                    </ajaxToolkit:CalendarExtender>
                                    <%--<ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" Mask="99/99/9999" MaskType="Date"
                                        TargetControlID="txtToDate">
                                    </ajaxToolkit:MaskedEditExtender>--%>
                                </td>
                            </tr>
                            <tr>
                                <th>Approved By<span class="required">*</span>
                                </th>
                                <td>
                                    <asp:DropDownList ID="ddlSaction" runat="server" Width="150px"></asp:DropDownList>
               
                                </td>
                                <th>Approved Date<span class="required">*</span>
                                </th>
                                <td>
                                    <asp:TextBox ID="AppDate" runat="server"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="AppDate" Format="dd/MM/yyyy">
                                    </ajaxToolkit:CalendarExtender>
                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender3" runat="server" Mask="99/99/9999" MaskType="Date"
                                        TargetControlID="AppDate">
                                    </ajaxToolkit:MaskedEditExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="TextBox1" runat="server" Visible="false"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

