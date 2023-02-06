<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="MissingAttendance.aspx.cs" Inherits="Academic_MissingAttendance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript">
        function show_confirm()
        {
            var r=confirm("You won't be able any further changes. Do you wish to continue?");
            if (r==true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        function mark(value) {
            window.open("StudentAttendanceMis.aspx?id=" + value);
            return true;
        }
         </script>

    <div class="container">
        <div class="heading">
            <h2>Missing Student Report </h2>
        </div>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <td>
                            <table>
                                <table>
                                    <tr>
                                        <th>From Date<span class="required">*</span></th>
                                        <th>To Date<span class="required">*</span></th>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtFromDate" runat="server"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtToDate" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnView" runat="server" Text="View" Enabled="false"
                                                OnClick="btnView_Click" /></td>
                                        <td>
                                            <asp:ListBox ID="listReason" runat="server" Rows="1" Visible="False"></asp:ListBox></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFromDate"
                                                Format="dd/MM/yyyy">
                                            </ajaxToolkit:CalendarExtender>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtToDate"
                                                Format="dd/MM/yyyy">
                                            </ajaxToolkit:CalendarExtender>
                                        </td>
                                    </tr>
                                </table>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div>
                                <asp:GridView ID="gridStudentData" runat="server" AutoGenerateColumns="False" GridLines="None"
                                    CssClass="gridDynamic" DataKeyNames="TT_DET_ID" SelectedRowStyle-CssClass="pgr"
                                    OnRowCommand="gridStudentData_RowCommand">
                                    <Columns>
                                        <asp:TemplateField HeaderText="S.No.">
                                            <ItemTemplate>
                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                        .
                                            </ItemTemplate>
                                            <ItemStyle Width="20px" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="CLS_VALUE" HeaderText="Class">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CLS_DATE" DataFormatString="{0:dddd dd/MM/yyyy}" HeaderText="Date">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="TT_SLOT_VALUE" HeaderText="Time Slot">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ACA_SEM_ID" HeaderText="Semester">
                                            <ItemStyle Width="20px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="PAPER" HeaderText="Paper Code(s)">
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Insert Reason">
                                            <ItemTemplate>
                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:TextBox ID="txtReason" MaxLength="100" Width="97%" runat="server"></asp:TextBox>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </ItemTemplate>
                                            <ItemStyle Width="150px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:UpdatePanel ID="upBlock" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:Button ID="btnBlock" runat="server" CommandName="Block"
                                                            CommandArgument="<%#((GridViewRow)Container).RowIndex%>" Text="Block" OnClientClick="return show_confirm()" />
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </ItemTemplate>
                                            <ItemStyle Width="30px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:UpdatePanel ID="upMark" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:Button ID="btnMark" runat="server" CommandName="Mark" CommandArgument="<%#((GridViewRow)Container).RowIndex%>"
                                                            Text="Mark" OnClientClick='<%#Eval("TT_DET_ID","javascript:return mark({0});")%>' />
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </ItemTemplate>
                                            <ItemStyle Width="30px" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

