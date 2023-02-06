<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="EmpRoomAllotment.aspx.cs" Inherits="Facility_EmpRoomAllotment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script lang ="javascript" type="text/javascript">
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
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == ".") {
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
                return false;
            }
            else
                document.getElementById(ctrl).style.backgroundColor = "#fff";
            return true;
        }
        function Validation()
        {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckAutoComplete("<%=txtAllotEmp.ClientID%>")) {
                msg += " * Enter Employee Name & Code. \n";
                if (ctrl == "")
                    ctrl = "<%=txtAllotEmp.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtAllotDt.ClientID%>")) {
                msg += " * Enter Date\n";
                if (ctrl == "")
                    ctrl = "<%=txtAllotDt.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlAllotCmplx.ClientID%>")) {
                msg += " * Select Complex\n";
                if (ctrl == "")
                    ctrl = "<%=ddlAllotCmplx.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlAllotFloor.ClientID%>")) {
                msg += "Select Floor. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlAllotFloor.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlAllotRoom.ClientID%>")) {
                msg += "Select Room. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlAllotRoom.ClientID%>";
                flag = false;
            }

            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }
        function Validate() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=ddlVCmplxName.ClientID%>")) {
                 msg += " * Select Complex\n";
                 if (ctrl == "")
                     ctrl = "<%=ddlVCmplxName.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlVFloor.ClientID%>")) {
                 msg += " * Select Floor\n";
                 if (ctrl == "")
                     ctrl = "<%=ddlVFloor.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlVRumNo.ClientID%>")) {
                 msg += "Select Room. \n";
                 if (ctrl == "")
                     ctrl = "<%=ddlVRumNo.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlEmp.ClientID%>")) {
                 msg += "Select Employee. \n";
                 if (ctrl == "")
                     ctrl = "<%=ddlEmp.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtVacntDt.ClientID%>")) {
                msg += "Enter Vacant Date. \n";
                if (ctrl == "")
                    ctrl = "<%=txtVacntDt.ClientID%>";
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
           <h2>Room Allotment</h2>
       </div>
        <table>
            <tr>
                <td>
                    <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" AutoPostBack="true" ActiveTabIndex="0">
                        <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="Room Allotment">
                            <ContentTemplate>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <table>
                                            <tr>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <th>Complex Name<span class="required">*</span></th>
                                                            <th>Room Floor<span class="required">*</span></th>
                                                            <th>Room No<span class="required">*</span></th>
                                                            <th>Employee Code<span class="required">*</span></th>
                                                            <th>Occupied Date<span class="required">*</span></th>
                                                            <th>Reamrk</th>
                                                        </tr>
                                                        <tr>
                                                            <td><asp:DropDownList ID="ddlAllotCmplx" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlAllotCmplx_SelectedIndexChanged"></asp:DropDownList></td>
                                                            <td><asp:DropDownList ID="ddlAllotFloor" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlAllotFloor_SelectedIndexChanged"></asp:DropDownList></td>
                                                            <td><asp:DropDownList ID="ddlAllotRoom" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlAllotRoom_SelectedIndexChanged"></asp:DropDownList></td>
                                                            <td><asp:TextBox ID="txtAllotEmp" runat="server"></asp:TextBox></td>
                                                            <td><asp:TextBox ID="txtAllotDt" runat="server"></asp:TextBox>
                                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="txtAllotDt"></ajaxToolkit:CalendarExtender>
                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtAllotDt" Mask="99/99/9999"
                                MaskType="Date">
                            </ajaxToolkit:MaskedEditExtender>
                                                            </td>
                                                             <td><asp:TextBox ID="txtRemark" runat="server"></asp:TextBox></td>
                                                            <td><asp:Button ID="btnAllotRum" runat="server" Text="Allot Room" OnClick="btnAllotRum_Click" /></td>
                                                           
                                                            <td>
                                                            <ajaxToolkit:AutoCompleteExtender ID="AutoComplete1" runat="server" EnableCaching="true"
                                      TargetControlID="txtAllotEmp" ServicePath="~/AutoComplete.asmx" ServiceMethod="GetEmployeeList"
                                    MinimumPrefixLength="1" ContextKey="1" CompletionSetCount="12" CompletionInterval="500">
                                </ajaxToolkit:AutoCompleteExtender>
                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table>
                                                        <tr>
                                                <th>BED LEFT:</th>
                                                <td>
                                                    <span class="required"><asp:Label ID="lblBedLeft" runat="server" Text="No Room Selected"></asp:Label></span></td>
                                            </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:GridView ID="grRoomAllot" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" DataKeyNames="ROOM_ID,ALLOTMENT_ID" OnRowCommand="grRoomAllot_RowCommand" >
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="S.No">
                                                                <ItemTemplate>
                                                                    <%#((GridViewRow)Container).RowIndex + 1 %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField HeaderText="EMPLOYEE ID" DataField="ALLOTED_TO" />
                                                            <asp:BoundField HeaderText ="EMPLOYEE NAME" DataField="EMP_NAME" />
                                                            <asp:BoundField HeaderText="DEPARTMENT" DataField="DEPT_VALUE" />
                                                            <asp:BoundField HeaderText="OCCUPIED DATE" DataField="OCCUPIED_DATE" />
                                                            <asp:CommandField ButtonType="Image" SelectImageUrl="~/Siteimages/edit.gif" ShowSelectButton="True" HeaderText="Modify">
                                                        <ItemStyle Width="40px" />
                                                        </asp:CommandField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </ContentTemplate>
                        </ajaxToolkit:TabPanel>
                        <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="Vacant Room">
                            <ContentTemplate>
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <table>
                                            <tr>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <th>Complex Name<span class="required">*</span></th>
                                                            <th>Floor<span class="required">*</span></th>
                                                            <th>Room No<span class="required">*</span></th>
                                                            <th>Employee<span class="required">*</span></th>
                                                            <th>Vacant Date<span class="required">*</span></th>
                                                        </tr>
                                                        <tr>
                                                            <td><asp:DropDownList ID="ddlVCmplxName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlVCmplxName_SelectedIndexChanged"></asp:DropDownList></td>
                                                            <td><asp:DropDownList ID="ddlVFloor" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlVFloor_SelectedIndexChanged"></asp:DropDownList></td>
                                                            <td><asp:DropDownList ID="ddlVRumNo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlVRumNo_SelectedIndexChanged"></asp:DropDownList></td>
                                                            <td><asp:DropDownList ID="ddlEmp" runat="server" AutoPostBack="True"></asp:DropDownList></td>
                                                            <td><asp:TextBox ID="txtVacntDt" runat="server"></asp:TextBox>
                                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" runat="server" TargetControlID="txtVacntDt"></ajaxToolkit:CalendarExtender>
                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtVacntDt" Mask="99/99/9999"
                                MaskType="Date">
                            </ajaxToolkit:MaskedEditExtender>
                                                            </td>
                                                            <td><asp:Button ID="btnVacant" runat="server" Text="Vacant Room" OnClick="btnVacant_Click" /></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </ContentTemplate>
                        </ajaxToolkit:TabPanel>
                    </ajaxToolkit:TabContainer>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

