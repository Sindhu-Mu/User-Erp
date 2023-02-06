<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="OpnElecStuSelct.aspx.cs" Inherits="Academic_OpnElecStuSelct" %>

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
             if (!CheckControl("<%=ddlInstitution.ClientID%>")) {
                 msg += " * Select Institute. \n";
                 if (ctrl == "")
                     ctrl = "<%=ddlPaper.ClientID%>";
                flag = false;
             }
             if (!CheckControl("<%=ddlCourse.ClientID%>")) {
                 msg += " * Select course. \n";
                 if (ctrl == "")
                     ctrl = "<%=ddlPaper.ClientID%>";
                flag = false;
             }
             if (!CheckControl("<%=ddlBranch.ClientID%>")) {
                 msg += " * Select Branch. \n";
                 if (ctrl == "")
                     ctrl = "<%=ddlPaper.ClientID%>";
                flag = false;
             }
             if (!CheckControl("<%=ddlSemester.ClientID%>")) {
                 msg += " * Select Semester. \n";
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
             if (!CheckControl("<%=txtdateGroupActive.ClientID%>")) {
                 msg += " * Select Date. \n";
                 if (ctrl == "")
                     ctrl = "<%=ddlPaper.ClientID%>";
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
            <h2>Open Elective Student Add </h2>
        </div>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <table style="width: 100%">
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <th>Paper</th>
                                    <th>Institution</th>
                                    <th>Program</th>
                                    <th>Branch</th>
                                    <th>Semester</th>

                                </tr>
                                <tr>
                                    <td>
                                        <asp:DropDownList ID="ddlPaper" runat="server" Width="100px"
                                            AutoPostBack="True">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlInstitution" runat="server" Width="80px"
                                            AutoPostBack="True" OnSelectedIndexChanged="ddlInstitution_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlCourse" runat="server" Width="153px"
                                            AutoPostBack="True" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>

                                    <td>
                                        <asp:DropDownList ID="ddlBranch" runat="server" Width="156px">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlSemester" runat="server" Width="80px">
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
                                            <asp:GridView ID="gvStudent" CssClass="gridDynamic" runat="server" AutoGenerateColumns="False" EnableViewState="True"
                                               DataKeyNames="STU_MAIN_ID">

                                                <Columns>
                                                    <asp:TemplateField HeaderText="S.No.">
                                                        <ItemTemplate>
                                                            <%# ((GridViewRow)Container).RowIndex + 1%>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="20px" />
                                                    </asp:TemplateField>

                                                    <asp:BoundField HeaderText="Enrollment No." DataField="ENROLLMENT_NO" />
                                                    <asp:BoundField HeaderText="Name" DataField="STU_FULL_NAME" />
                                                   <%--  <asp:BoundField HeaderText="Current Group" DataField="GRP_VALUE" />--%>
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
                                                <%--<tr>
                                                    <th>Select Group<span class="required">*</span>
                                                    </th>
                                                    <td>
                                                        <asp:DropDownList ID="ddlGroup" runat="server">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>--%>
                                                <tr id="rowHide" runat="server">
                                                    <th>Active From</th>
                                                    <td>
                                                        <asp:TextBox ID="txtdateGroupActive" runat="server" Width="90px"></asp:TextBox>
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="txtdateGroupActive"></ajaxToolkit:CalendarExtender>
                                                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtdateGroupActive" Mask="99/99/9999"
                                                            MaskType="Date">
                                                        </ajaxToolkit:MaskedEditExtender>
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btnSaveGroup" runat="server" Text="Save" OnClick="btnSaveGroup_Click" />
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

