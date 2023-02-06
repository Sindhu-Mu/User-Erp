<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="RptHstlStuAtt.aspx.cs" Inherits="Facility_RptHstlStuAtt" %>

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
        function Allotvalidate() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=ddlComplex.ClientID%>")) {
                msg += "- Select Complex From List. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlComplex.ClientID%>";
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
            <h2>Student Hostel Attendance</h2>
        </div>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                <ProgressTemplate><img src="../Siteimages/loading.gif" alt="loading" /></ProgressTemplate>
            </asp:UpdateProgress>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <th>By Enrollment</th>
                                    <th>By Date</th>
                                    <th>By Complex<span class="required">*</span></th>
                                    <th>By Floor</th>
                                    <th>By Room</th>
                                    <th>By Course</th>
                                    <th>By Sem</th>
                                    <th>By Status</th>
                                </tr>
                                <tr>
                                    <td><asp:TextBox ID="txtEnroll" runat="server" Width="150px"></asp:TextBox></td>
                                    <td><asp:TextBox ID="txtDt" runat="server" Width="150px"></asp:TextBox></td>
                                    <td><asp:DropDownList ID="ddlComplex" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlComplex_SelectedIndexChanged" Width="150px"></asp:DropDownList></td>
                                    <td><asp:DropDownList ID="ddlFloor" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlFloor_SelectedIndexChanged" Width="50px"></asp:DropDownList></td>
                                    <td><asp:DropDownList ID="ddlRoom" runat="server" AutoPostBack="True"></asp:DropDownList></td>
                                    <td><asp:DropDownList ID="ddlCourse" runat="server" AutoPostBack="True" Width="150px"></asp:DropDownList></td>
                                    <td><asp:DropDownList ID="ddlSem" runat="server" AutoPostBack="True"></asp:DropDownList></td>
                                    <td><asp:DropDownList ID="ddlSts" runat="server" AutoPostBack="True">
                                        <asp:ListItem Text="All" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Present" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Absent" Value="2"></asp:ListItem>
                                        </asp:DropDownList></td>
                                    <td><asp:Button ID="btnView" runat="server" Text="View" OnClick="btnView_Click" /></td>
                                </tr>
                            </table>
                            <table>
                                <tr>
                                    <td>      
                                         <div style="overflow: auto; height:500px">
                                        <asp:GridView ID="gvDetail" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" Width="950px" EmptyDataText="No Record(s) Found">
                                            <Columns>
                                                <asp:TemplateField HeaderText="S.No">
                                                    <ItemTemplate>
                                                        <%#((GridViewRow)Container).RowIndex +1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="Enrollment" DataField="ENROLLMENT_NO" />
                                                <asp:BoundField HeaderText="Student Name" DataField="STU_FULL_NAME" />
                                                <asp:BoundField HeaderText="Room No" DataField="ROOM_NO" />
                                                <asp:BoundField HeaderText="Code" DataField="HSACM_CODE" />
                                                <asp:BoundField HeaderText="Morning Time" DataField="H_STU_ATT_MRNIG_TIME" />
                                                <asp:BoundField HeaderText="Evening Time" DataField="H_STU_ATT_EVE_TIME" />
                                            </Columns>
                                        </asp:GridView>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="txtDt" Enabled="True"></ajaxToolkit:CalendarExtender>
                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtDt" Mask="99/99/9999"
                                MaskType="Date" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True">
                            </ajaxToolkit:MaskedEditExtender>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

