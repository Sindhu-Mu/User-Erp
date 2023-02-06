<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="SecurityDutyRoster.aspx.cs" Inherits="HR_SecurityDutyRoster" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script lang="javascript" type="text/javascript">
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
        function validate() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=txtDate.ClientID%>")) {
                msg += "- Enter Date\n";
                if (ctrl == "")
                    ctrl = "<%=txtDate.ClientID%>";
                flag = false;
            } if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }
    </script>
    <div class="container">
        <div class="heading">
            <h2>Security Duty Roster</h2>
        </div>
        <div>
            <asp:UpdatePanel ID="updatePannel" runat="server">
                <ContentTemplate>

                    <!--By Date-->
                    <table>
                        <tr>
                            <td style="vertical-align: top">
                                <table>
                                    <tr>
                                        <td>
                                            <table>
                                                <tr>

                                                    <th>DUTY DATE<span class="required">*</span></th>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtDate" runat="server" Width="100px"></asp:TextBox></td>

                                                    <td>&nbsp;</td>
                                                    <td>
                                                        <asp:Button ID="btnMake" runat="server" Text="Make & Show Duty Chart" OnClick="btnMake_Click" /></td>
                                                     <td>&nbsp;</td>
                                                  
                                                    <td>
                                                        <asp:Button ID="btnRebuild" runat="server" Text="Rebuild Duty Chart" OnClick="btnRebuild_Click" BackColor="Red" ForeColor="White" /></td>
                                                    <td>&nbsp;</td>
                                                    <td>
                                                        <asp:Button ID="btnExcelToExport" runat="server" Visible="false" Text="Export to excel" OnClick="btnExcelToExport_Click" /></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:GridView ID="gridDutyChart" runat="server" CssClass="gridDynamic" EmptyDataText="No recored found" AutoGenerateColumns="False">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S.No.">
                                                        <ItemTemplate><%#((GridViewRow)Container).RowIndex+1 %></ItemTemplate>
                                                        <ItemStyle Width="15px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="DUTY_DATE" HeaderText="Duty Date" DataFormatString="{0:dd/MM/yyyy}" />
                                                    <asp:BoundField DataField="NAME" HeaderText="NAME" />
                                                    <asp:BoundField DataField="Designation" HeaderText="Designation" />
                                                    <asp:BoundField DataField="SHIFT_TIME" HeaderText="Shift" />
                                                    <asp:BoundField DataField="LOCATION_VALUE" HeaderText="Location" />
                                                </Columns>
                                            </asp:GridView>

                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate" Format="dd/MM/yyyy">
                                            </ajaxToolkit:CalendarExtender>
                                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender5" runat="server" Mask="99/99/9999" MaskType="Date"
                                                TargetControlID="txtDate">
                                            </ajaxToolkit:MaskedEditExtender>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            
                        </tr>
                    </table>
                    <!--By Month-->

                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnExcelToExport" />
                  
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>


