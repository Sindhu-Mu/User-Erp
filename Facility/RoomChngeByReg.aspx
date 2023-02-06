<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Short.master" AutoEventWireup="true" CodeFile="RoomChngeByReg.aspx.cs" Inherits="Facility_HostelRoomAllotment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentHolder1" Runat="Server">
    <script language ="javascript" type="text/javascript">
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
        function ChangeValidate() {
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
            <h2>Room Change By Registration Process</h2>
        </div>
        <table>
            <tr>
                <td>
                    <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" AutoPostBack="true" ActiveTabIndex="0">
                   
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

