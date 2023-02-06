<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="rptDailyAttSummaryForCord.aspx.cs" Inherits="Academic_rptDailyAttSummaryForCord" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
            if (!CheckControl("<%=ddlInstitute.ClientID%>")) {
                msg += " * Select Institute. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlInstitute.ClientID%>";
                flag = false;
            }
            
            if (!CheckDate("<%=txtDate.ClientID%>")) {
                if (!CheckControl("<%=txtDate.ClientID%>")) {
                    msg += " * Enter To date. \n";
                    if (ctrl == "")
                        ctrl = "<%=txtDate.ClientID%>";
                    flag = false;
                }
                else {
                    msg += " * Enter Correct Date.  \n";
                    if (ctrl == "")
                        ctrl = "<%=txtDate.ClientID%>";
                    flag = false;
                }
            }

            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;

        }
    </script>

    <div class="container">
        <div class="heading">
            <h2>Daily Attendance Summary</h2>
        </div>
        <div>
            <table>
                <tr>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <table style="vertical-align: bottom">
                                    <tr>
                                        <td>
                                            <table>
                                                <tr>
                                                    <th>Choose Institute<span class="required">*</span></th>
                                                    <th>Choose Sem<span class="expected">*</span></th>
                                                    <th>Choose Class<span class="expected">*</span></th>
                                                    <th>Choose Date</th>
                                                    <th>Status</th>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:DropDownList ID="ddlInstitute" runat="server" Width="130px">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlSemesterBound" runat="server" AutoPostBack="true" Width="130px" OnSelectedIndexChanged="ddlSemesterBound_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlChooseClass" runat="server" Width="200px">
                                                        </asp:DropDownList></td>
                                                    <td>
                                                        <asp:TextBox ID="txtDate" runat="server" Width="120px"></asp:TextBox>
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate"
                                                            Format="dd/MM/yyyy" PopupPosition="TopLeft">
                                                        </ajaxToolkit:CalendarExtender>
                                                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="99/99/9999" MaskType="Date"
                                                            TargetControlID="txtDate">
                                                        </ajaxToolkit:MaskedEditExtender>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlstatus" runat="server" Width="100px">
                                                            <asp:ListItem Value="0">Defaulter</asp:ListItem>
                                                            <asp:ListItem Value="1">Normal</asp:ListItem>
                                                        </asp:DropDownList></td>
                                                    <td>
                                                        <asp:Button ID="btnView" runat="server" Text="View" OnClick="btnView_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:GridView ID="gvShow" runat="server" AutoGenerateColumns="False" Width="100%" EmptyDataText="No Record Avaliable" CssClass="gridDynamic">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S.No.">
                                                        <ItemTemplate>
                                                            <%# ((GridViewRow)Container).RowIndex + 1%>.                                             
                                                        </ItemTemplate>
                                                        <ItemStyle Width="20px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField HeaderText="Class" DataField="CLS_VALUE" />
                                                    <asp:BoundField HeaderText="Sem" DataField="ACA_SEM_ID" />
                                                    <asp:BoundField HeaderText="Section" DataField="ACA_SEC_NAME" />
                                                    <asp:BoundField HeaderText="Class Type" DataField="CLS_TYPE_VALUE" />
                                                    <asp:BoundField HeaderText="Paper Code" DataField="PAPER_CODE" />
                                                    <asp:BoundField HeaderText="Class Date" DataField="CLS_DATE" DataFormatString="{0:dd/MM/yyyy}" />
                                                    <asp:BoundField HeaderText="Time Slot" DataField="TT_SLOT_VALUE" />
                                                    <asp:BoundField HeaderText="Group" DataField="GRP_VALUE" />
                                                    <asp:BoundField HeaderText="Complex" DataField="FAC_CMPLX_NAME" />
                                                    <asp:BoundField HeaderText="Room No." DataField="ROOM_NO" />
                                                    <asp:BoundField HeaderText="Faculty" DataField="FACULTY" />
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

