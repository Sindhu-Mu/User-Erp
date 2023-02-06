<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="HostelRoomAllotment.aspx.cs" Inherits="Facility_HostelRoomAllotment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script lang ="javascript" type="text/javascript">
        function CheckControl(ctrl) {
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == "." || bTrim(document.getElementById(ctrl).value) == "Select") {
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
                return false;
            }
            else
                document.getElementById(ctrl).style.backgroundColor = "#fff";
            return true;
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


        function Allotvalidate() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=ddlFloor.ClientID%>")) {
                msg += "- Select Floor From List. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlFloor.ClientID%>";
                flag = false;
            }
            if (!CheckAutoComplete("<%=txtStuName.ClientID%>")) {
                msg += " * Enter Name with Enrollment. \n";
                if (ctrl == "")
                    ctrl = "<%=txtStuName.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlRoomNo.ClientID%>"))
            {
                msg += "- Select Room No From The List. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlRoomNo.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtStuName.ClientID%>")) {
                msg += "- Enter Student Name & Enrollment.\n";
                if (ctrl == "")
                    ctrl = "<%=txtStuName.ClientID%>";
                flag = false;
            }

            if (!CheckControl("<%=txtDate.ClientID%>")) {
                msg += "- Enter Alloted Date. \n";
                if (ctrl == "")
                    ctrl = "<%=txtDate.ClientID%>";
                flag = false;
            }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }

function VacantValidate()
{
                    var flag = true;
                    var msg = "", ctrl = "";
            if (!CheckControl("<%=ddlVFloor.ClientID%>")) {
                msg += "- Select Floor From List. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlVFloor.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlVRoomNo.ClientID%>")) {
                msg += "- Select Room No From The List. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlVRoomNo.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlStudent.ClientID%>")) {
                msg += "- Select Student From The List. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlStudent.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtLeavingDt.ClientID%>")) {
                msg += "- Enter Vacant Date. \n";
                if (ctrl == "")
                    ctrl = "<%=txtLeavingDt.ClientID%>";
                flag = false;
            }
            
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }
function ChangeValidate()
{
               var flag = true;
               var msg = "", ctrl = "";
            if (!CheckControl("<%=ddlCFloor.ClientID%>")) {
                msg += "- Select Floor From List. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlCFloor.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlCRoomNo.ClientID%>")) {
                msg += "- Select Room No From the List. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlCRoomNo.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlCstudent.ClientID%>")) {
                msg += "-Select Student From The List. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlCstudent.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlNewRoom.ClientID%>")) {
                msg += "- Select New Room No From List. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlNewRoom.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtChangeDate.ClientID%>")) {
                msg += "- Enter Change Date. \n";
                if (ctrl == "")
                    ctrl = "<%=txtChangeDate.ClientID%>";
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
                    <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" AutoPostBack="true" ActiveTabIndex="2">
                        <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="Room Allotment">
                            <ContentTemplate>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <table>
                                            <tr>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <th>Floor<span class="required">*</span></th>
                                                            <th>Room No<span class="required">*</span></th>
                                                            <th>Student Name<span class="required">*</span></th>
                                                            <th>Occupied Date<span class="required">*</span></th>
                                                            <th>Remark</th>
                                                        </tr>
                                                        <tr>
                                                            <td><asp:DropDownList ID="ddlFloor" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlFloor_SelectedIndexChanged"></asp:DropDownList></td>
                                                            <td><asp:DropDownList ID="ddlRoomNo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlRoomNo_SelectedIndexChanged"></asp:DropDownList></td>
                                                            <td><asp:TextBox ID="txtStuName" runat="server"></asp:TextBox></td>
                                                            <td><asp:TextBox ID="txtDate" runat="server"></asp:TextBox></td>
                                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="txtDate"></ajaxToolkit:CalendarExtender>
                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtDate" Mask="99/99/9999"
                                MaskType="Date">
                            </ajaxToolkit:MaskedEditExtender>
                                                            <td><asp:TextBox ID ="txtRemark" runat="server"></asp:TextBox></td>
                                                            <td><asp:Button ID="btnAssign" runat="server" Text="Assign" OnClick="btnAssign_Click" /></td>
                                                            <td>
                                                            <ajaxToolkit:AutoCompleteExtender ID="autoComplete2" runat="server" EnableCaching="true"
                                      TargetControlID="txtStuName" ServicePath="~/AutoComplete.asmx" ServiceMethod="GetStudentList"
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
                                                <th>BED LEFT:-</th>
                                                <td>
                                                    <asp:Label ID="lblBedLeft" runat="server" ForeColor="Red"></asp:Label></td>
                                            </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:GridView ID="gvRoomAllot" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" DataKeyNames="ROOM_ID" OnRowCommand="gvRoomAllot_RowCommand">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S.No">
                                                                <ItemTemplate>
                                                                    <%#((GridViewRow)Container).RowIndex + 1 %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField HeaderText="STUDENT NAME" DataField="STU_NAME" />
                                                            <asp:BoundField HeaderText ="COURSE" DataField="PGM_SHORT_NAME" />
                                                            <asp:BoundField HeaderText="BRANCH" DataField="BRN_SHORT_NAME" />
                                                            <asp:BoundField HeaderText="OCCUPIED DATE" DataField="OCCUPIED_DATE" />
                                                            <asp:BoundField HeaderText="REMARK" DataField="ALLOTE_REMARK" />
                                                             <asp:CommandField ButtonType="Image" SelectImageUrl="~/Siteimages/edit.gif" ShowSelectButton="True" HeaderText="Modify">
                                                        <ItemStyle Width="40px" />
                                                        </asp:CommandField>
                                                        </Columns>
                                                    </asp:GridView>
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
                                                            <th>Floor<span class="required">*</span></th>
                                                            <th>Room No<span class="required">*</span></th>
                                                            <th>Student<span class="required">*</span></th>
                                                            <th>Leaving Date<span class="required">*</span></th>
                                                        </tr>
                                                        <tr>
                                                            <td><asp:DropDownList ID="ddlVFloor" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlVFloor_SelectedIndexChanged"></asp:DropDownList></td>
                                                            <td><asp:DropDownList ID="ddlVRoomNo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlVRoomNo_SelectedIndexChanged"></asp:DropDownList></td>
                                                            <td><asp:DropDownList ID="ddlStudent" runat="server"></asp:DropDownList></td>
                                                            <td><asp:TextBox ID="txtLeavingDt" runat="server"></asp:TextBox>
                                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" runat="server" TargetControlID="txtLeavingDt"></ajaxToolkit:CalendarExtender>
                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtLeavingDt" Mask="99/99/9999"
                                MaskType="Date">
                            </ajaxToolkit:MaskedEditExtender>
                                                            </td>
                                                            <td><asp:Button ID="btnVacant" runat="server" Text="Vacant Room" OnClick="btnVacant_Click"/></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <th>Bed Left:-</th>
                                                            <td>
                                                                <asp:Label ID="lblBLft" runat="server" ForeColor="Red"></asp:Label></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:GridView ID="gvRoomVcnt" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S.No">
                                                                <ItemTemplate>
                                                                    <%#((GridViewRow)Container).RowIndex + 1 %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField HeaderText="STUDENT NAME" DataField="STU_FULL_NAME" />
                                                            <asp:BoundField HeaderText ="COURSE" DataField="PGM_FULL_NAME" />
                                                            <asp:BoundField HeaderText="BRANCH" DataField="BRN_FULL_NAME" />
                                                            <asp:BoundField HeaderText="LEAVING DATE" DataField="LEAVING_DATE" />
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </ContentTemplate>
                        </ajaxToolkit:TabPanel>
                        <ajaxToolkit:TabPanel ID="Tabpanel3" runat="server" HeaderText="Room Change">
                            <ContentTemplate>
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                        <table>
                                            <tr>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <th>Floor<span class="required">*</span></th>
                                                            <th>Room No<span class="required">*</span></th>
                                                            <th>Student<span class="required">*</span></th>
                                                            <th>New Room<span class="required">*</span></th>
                                                            <th>Change Date<span class="required">*</span></th>
                                                            <th>Remark</th>
                                                        </tr>
                                                        <tr>
                                                            <td><asp:DropDownList ID="ddlCFloor" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCFloor_SelectedIndexChanged"></asp:DropDownList></td>
                                                            <td><asp:DropDownList ID="ddlCRoomNo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCRoomNo_SelectedIndexChanged"></asp:DropDownList></td>
                                                            <td><asp:DropDownList ID="ddlCstudent" runat="server" AutoPostBack="True" Width="150px"></asp:DropDownList></td>
                                                            <td><asp:DropDownList ID="ddlNewRoom" runat="server" AutoPostBack="True"></asp:DropDownList></td>
                                                            <td><asp:TextBox ID="txtChangeDate" runat="server" Width="80px"></asp:TextBox>
                                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender3" Format="dd/MM/yyyy" runat="server" TargetControlID="txtChangeDate"></ajaxToolkit:CalendarExtender>
                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txtChangeDate" Mask="99/99/9999"
                                MaskType="Date">
                            </ajaxToolkit:MaskedEditExtender>
                                                            </td>
                                                            <td><asp:TextBox ID="txtChRemark" runat="server"></asp:TextBox></td>
                                                            <td><asp:Button ID="btnChange" runat="server" Text="Change Room" OnClick="btnChange_Click" /></td>

                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <th>Bed Left:-</th>
                                                            <td>
                                                                <asp:Label ID="lblBed" runat="server"></asp:Label></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:GridView ID="gvRoomCng" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S.No">
                                                                <ItemTemplate>
                                                                    <%#((GridViewRow)Container).RowIndex + 1 %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField HeaderText="STUDENT NAME" DataField="STU_NAME" />
                                                            <asp:BoundField HeaderText ="COURSE" DataField="PGM_SHORT_NAME" />
                                                            <asp:BoundField HeaderText="BRANCH" DataField="BRN_SHORT_NAME" />
                                                            <asp:BoundField HeaderText="OCCUPIED DATE" DataField="OCCUPIED_DATE" />
                                                            <asp:BoundField HeaderText="REMARK" DataField="ALLOTE_REMARK" />
                                                        </Columns>
                                                    </asp:GridView>
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

