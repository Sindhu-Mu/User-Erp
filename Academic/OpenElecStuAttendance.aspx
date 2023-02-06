<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="OpenElecStuAttendance.aspx.cs" Inherits="Academic_OpenElecStuAttendance" %>

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
        function validate() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=ddlPaper.ClientID%>")) {
                 msg += " * Select Paper. \n";
                 if (ctrl == "")
                     ctrl = "<%=ddlPaper.ClientID%>";
                 flag = false;
             }

           
             if (msg != "") alert(msg);
             if (ctrl != "")
                 document.getElementById(ctrl).focus();
             return flag;
        }
        function validate2() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=ddlPaper.ClientID%>")) {
                msg += " * Select Paper. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlPaper.ClientID%>";
                 flag = false;
             }

             if (!CheckControl("<%=txtClsDate.ClientID%>")) {
                msg += " * Select Date. \n";
                if (ctrl == "")
                    ctrl = "<%=txtClsDate.ClientID%>";
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
            <h2>Open Elective Student Attendance </h2>
        </div>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <table style="width: 100%">
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <th>Paper</th>

                                </tr>
                                <tr>
                                    <td>
                                        <asp:DropDownList ID="ddlPaper" runat="server" Width="100px">
                                        </asp:DropDownList>
                                    </td>



                                    <td>
                                        <asp:Button ID="btnView" runat="server" Text="View" CssClass="btnBrown" OnClick="btnView_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>
                            <tr>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <asp:GridView ID="gvStudent" runat="server" CssClass="gridDynamic" Caption="Attendance List(Select the absent student)" AutoGenerateColumns="False" EnableViewState="True"
                                                DataKeyNames="STU_MAIN_ID,STU_ELEC_ID">

                                                <Columns>
                                                    <asp:TemplateField HeaderText="S.No.">
                                                        <ItemTemplate>
                                                            <%# ((GridViewRow)Container).RowIndex + 1%>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="20px" />
                                                    </asp:TemplateField>

                                                    <asp:BoundField HeaderText="Enrollment No." DataField="ENROLLMENT_NO" />
                                                    <asp:BoundField HeaderText="Name" DataField="STU_FULL_NAME" />
                                                    <%--<asp:BoundField HeaderText="Current Group" DataField="GRP_VALUE" />--%>
                                                    <asp:TemplateField HeaderText="Choose">
                                                        <HeaderTemplate>
                                                            <input id="chkAll" onclick="javascript: SelectAllCheckboxes(this);" type="checkbox"
                                                                value="on" runat="server" />All
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkStudent" runat="server" />
                                                        </ItemTemplate>
                                                        <ItemStyle Width="20px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField HeaderText="Color" DataField="COLOR" Visible="false" />
                                                </Columns>
                                            </asp:GridView>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <table>
                                                <%-- <tr>
                                                    <th>Select Group<span class="required">*</span>
                                                    </th>
                                                    <td>
                                                        <asp:DropDownList ID="ddlGroup" runat="server">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>--%>
                                                <tr id="rowHide" runat="server">
                                                    <th>Class Date</th>
                                                    <td>
                                                        <asp:TextBox ID="txtClsDate" runat="server" Width="90px"></asp:TextBox>
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="txtClsDate"></ajaxToolkit:CalendarExtender>
                                                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtClsDate" Mask="99/99/9999"
                                                            MaskType="Date">
                                                        </ajaxToolkit:MaskedEditExtender>
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="txtSubmit" runat="server" Text="Save" OnClick="txtSubmit_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

