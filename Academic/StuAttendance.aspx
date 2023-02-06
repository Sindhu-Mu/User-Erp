<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="StuAttendance.aspx.cs" Inherits="Academic_StuAttendance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script lang="javascript" type="text/javascript">
        function SelectAllCheckboxes(spanChk) {


            var oItem = spanChk.children;
            var theBox = (spanChk.type == "checkbox") ?
                spanChk : spanChk.children.item[0];
            xState = theBox.checked;
            elm = theBox.form.elements;

            for (i = 0; i < elm.length; i++)
                if (elm[i].type == "checkbox" &&
                         elm[i].id != theBox.id) {
                    //elm[i].click();
                    if (elm[i].checked != xState)
                        elm[i].click();
                    //elm[i].checked=xState;
                }
        }
        function CheckControl(ctrl) {
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == ".") {
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
                return false;
            }
            else
                document.getElementById(ctrl).style.backgroundColor = "#fff";
            return true;
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

        function validation() {
            var flag = true;
            var msg = "", ctrl = "";

            if (CheckControl("<%=txtDate.ClientID%>")) {
                if (!CheckDate("<%=txtDate.ClientID%>")) {
                    msg += "* Enter date in currect format.[dd/MM/yyyy]\n";
                    if (ctrl == "")
                        ctrl = "<%=txtDate.ClientID%>";
                    flag = false;
                }
            }
            else {
                msg += "* Enter Class date\n";
                if (ctrl == "")
                    ctrl = "<%=txtDate.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlSlot.ClientID%>")) {
                msg += "- Select Time Slot from List\n";
                if (ctrl == "")
                    ctrl = "<%=ddlSlot.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtPap.ClientID%>")) {
                msg += "- Enter Paper Code\n";
                if (ctrl == "")
                    ctrl = "<%=txtPap.ClientID%>";
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
            <h2>Student Attendance
            </h2>
        </div>
        <div>
            <table>
                <tr>
                    <td>
                        <table>
                            <tr>
                                <th>Institute
                                </th>
                                <th>Program
                                </th>
                                <th>Branch
                                </th>
                                <th>Batch
                                </th>
                                <th>Semester
                                </th>
                                <th>Section
                                </th>

                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlIns" runat="server" OnSelectedIndexChanged="ddlIns_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlPgm" runat="server" OnSelectedIndexChanged="ddlPgm_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlBranch" runat="server"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlBatch" runat="server"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlSem" runat="server"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlSec" runat="server"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Button ID="btnView" runat="server" Text="View" OnClick="btnView_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>

                <tr id="trGrid" runat="server" visible="false">
                    <td>
                        <div style="max-height: 500px; overflow: auto">
                            <asp:GridView ID="gvStudentData" runat="server" AutoGenerateColumns="False" GridLines="None"
                                CssClass="gridDynamic" DataKeyNames="STU_MAIN_ID"
                                Width="96%">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No.">
                                        <ItemTemplate>
                                            <%# ((GridViewRow)Container).RowIndex + 1%>
                                                    .
                                        </ItemTemplate>
                                        <ItemStyle Width="20px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="ENROLLMENT_NO" HeaderText="ENROLLMENT NO."></asp:BoundField>
                                    <asp:BoundField DataField="STU_FULL_NAME" HeaderText="STUDENT NAME"></asp:BoundField>
                                    <asp:BoundField DataField="PROGRAM" HeaderText="PROGRAM"></asp:BoundField>

                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <input id="chkAll" onclick="javascript: SelectAllCheckboxes(this);" type="checkbox"
                                                value="on" runat="server" />All
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkAttendance" runat="server" />
                                        </ItemTemplate>
                                        <ItemStyle Width="20px" />
                                    </asp:TemplateField>
                                </Columns>
                                <SelectedRowStyle CssClass="pgr" />
                                <AlternatingRowStyle CssClass="alt" />
                            </asp:GridView>
                        </div>
                    </td>
                </tr>
                <tr id="trEntry" runat="server" visible="false">
                    <td>
                        <table>
                            <tr>

                                <th>Paper Code<span class="required">*</span>
                                </th>
                                <th>Time Slot<span class="required">*</span>
                                </th>
                                <th>Date<span class="required">*</span>
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtPap" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlSlot" runat="server"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="txtDate"></ajaxToolkit:CalendarExtender>
                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtDate" Mask="99/99/9999"
                                        MaskType="Date">
                                    </ajaxToolkit:MaskedEditExtender>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtXML" runat="server" Visible="false"></asp:TextBox>
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

