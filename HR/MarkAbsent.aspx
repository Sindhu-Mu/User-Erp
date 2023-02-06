<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="MarkAbsent.aspx.cs" Inherits="HR_MarkAbsent" %>

<%@ Register Src="~/Control/MonthYear.ascx" TagPrefix="uc1" TagName="MonthYear" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="heading">
            <h2>Mark Absent
            </h2>
        </div>
        <div>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                <ProgressTemplate>
                    <img src="../Siteimages/loading.gif" alt="loading" />
                </ProgressTemplate>
            </asp:UpdateProgress>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table>

                        <tr>
                            <td>
                                <asp:TextBox ID="txtEmp" runat="server" Width="250px" placeholder="Employee code or name"></asp:TextBox>
                                <ajaxToolkit:AutoCompleteExtender ID="autoComplete1" runat="server" CompletionInterval="500"
                                    CompletionSetCount="12" ContextKey="1,2,3,0" EnableCaching="true" MinimumPrefixLength="1"
                                    ServiceMethod="GetEmployeeList" ServicePath="~\AutoComplete.asmx" TargetControlID="txtEmp">
                                </ajaxToolkit:AutoCompleteExtender>
                            </td>
                            <td style="text-align:left">
                                <uc1:MonthYear runat="server" ID="MonthYear" />
                            </td>
                            <td style="text-align:left">
                                <asp:Button ID="btnView" runat="server" Text="View" OnClick="btnView_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:GridView ID="gridAttendance" CssClass="gridDynamic" runat="server" AutoGenerateColumns="False" OnDataBound="gridAttendance_DataBound" DataKeyNames="dcDate" Caption="Month Attendance">
                                    <Columns>
                                        <asp:BoundField DataField="dcDay" HeaderText="Day" />
                                        <asp:BoundField DataField="dcWeekDay" HeaderText="Week Day" ItemStyle-Width="100px" />
                                        <asp:BoundField DataField="dcDutyTime" HeaderText="Shift" ItemStyle-Width="120px" />
                                        <asp:BoundField DataField="dcInTime" HeaderText="In-Time" ItemStyle-Width="90px" />
                                        <asp:BoundField DataField="dcOutTime" HeaderText="Out-Time" ItemStyle-Width="90px" />
                                        <asp:BoundField DataField="dcStatus" HeaderText="Status" ItemStyle-Width="200px" />
                                        <asp:TemplateField HeaderText="Remark">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtRemark" runat="server" Width="152px"></asp:TextBox>
                                                <asp:Label ID="lblRemark" runat="server" Width="200px" Text='<%# Bind("dcRemark") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:ImageButton ID="imgBtnSaveAtt" runat="server" ImageUrl="~/images/save_icon1.jpg"
                                                    OnClick="imgBtnSaveAtt_Click" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="CheckBox1" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:TextBox ID="Txtxml" runat="server" Visible="false" />
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

