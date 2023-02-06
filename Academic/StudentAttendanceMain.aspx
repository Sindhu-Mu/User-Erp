<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="StudentAttendanceMain.aspx.cs" Inherits="Academic_StudentAttendanceMain" %>

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
        function show_confirm() {
            var r = confirm("You have decided to mark the entries as final. You won't be able any further changes. Do you wish to continue?");
            if (r == true) {
                return true;
            }
            else {
                return false;
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


             if (msg != "") alert(msg);
             if (ctrl != "")
                 document.getElementById(ctrl).focus();
             return flag;
         }



    </script>
    <div class="container">
        <div class="heading">
            <h2>Student Attendance </h2>
        </div>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <th colspan="2">Date<span class="required">*</span>
                                    </th>
                                    <th>Time<span class="required">*</span>
                                    </th>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="txtDate"></ajaxToolkit:CalendarExtender>
                                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtDate" Mask="99/99/9999"
                                            MaskType="Date">
                                        </ajaxToolkit:MaskedEditExtender>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnLoadSlot" runat="server" Text="Load Time" OnClick="btnLoadSlot_Click" /></td>
                                    <td>
                                        <asp:DropDownList ID="ddlTime" runat="server" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="ddlTime_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="gridViewData" runat="server" AutoGenerateColumns="False" GridLines="None"
                                CssClass="gridDynamic" SelectedRowStyle-CssClass="pgr">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No.">
                                        <ItemTemplate>
                                            <%# ((GridViewRow)Container).RowIndex + 1%>
                                        </ItemTemplate>
                                        <ItemStyle Width="50px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="CLS_VALUE" HeaderText="Class Name">
                                        <ItemStyle Width="150px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ACA_SEM_ID" HeaderText="Semester">
                                        <ItemStyle Width="80px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PAPER" HeaderText="Paper Code(s)">
                                        <ItemStyle Width="150px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="GRP_VALUE" HeaderText="Group">
                                        <ItemStyle Width="80px" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center; color: brown"><b>SELECT ONLY ABSENT STUDENT FORM LIST AND<br />
                            CLICK SUBMIT TO MARK ATTENDANCE.</b></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="gridStudentData" runat="server" AutoGenerateColumns="False" GridLines="None"
                                CssClass="gridDynamic" DataKeyNames="TT_DET_ID,STU_MAIN_ID"
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
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnSave" runat="server" Text="Save" OnClientClick="return show_confirm()"
                                OnClick="btnSave_Click" Enabled="False" /></td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

