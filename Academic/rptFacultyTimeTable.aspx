<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="rptFacultyTimeTable.aspx.cs" Inherits="Academic_rptFacultyTimeTable" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="heading">
            <h2>Time Table</h2>
        </div>
        <div>
            <asp:UpdateProgress ID="upg1" runat="server" DynamicLayout="False">
                <ProgressTemplate>
                    <img src="../images/25-1.gif" />
                    Loading....
                </ProgressTemplate>
            </asp:UpdateProgress>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <th>Choose Sem<span class="expected">*</span></th>
                                        <th>Choose Class<span class="expected">*</span></th>
                                        <th>From Date<span class="required">*</span></th>
                                        <th>To Date<span class="required">*</span></th>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="ddlSemesterBound" runat="server" AutoPostBack="true" Width="100px" OnSelectedIndexChanged="ddlSemesterBound_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlChooseClass" runat="server" Width="100px">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFromDate" runat="server"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFromDate"
                                                Format="dd/MM/yyyy" PopupPosition="TopLeft">
                                            </ajaxToolkit:CalendarExtender>
                                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="99/99/9999" MaskType="Date"
                                                TargetControlID="txtFromDate">
                                            </ajaxToolkit:MaskedEditExtender>

                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtEndDate" runat="server"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtEndDate"
                                                Format="dd/MM/yyyy" PopupPosition="TopLeft">
                                            </ajaxToolkit:CalendarExtender>
                                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" Mask="99/99/9999" MaskType="Date"
                                                TargetControlID="txtEndDate">
                                            </ajaxToolkit:MaskedEditExtender>

                                        </td>
                                        <td>
                                            <asp:Button ID="btnViewClass" runat="server" Text="View" OnClick="btnViewClass_Click" />
                                        </td>

                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div id="scheduler">
                                    <cc4:ScheduleCalendar ID="tt_Calender" runat="server" DateField="" EndOfTimeScale="18:00:00"
                                        EndTimeField="" GridLines="Both" HorizontalAlign="NotSet" ItemStyleField="" Layout="Horizontal"
                                        StartDate="2011-08-08" StartDay="Monday" StartOfTimeScale="09:00:00" StartTimeField=""
                                        NumberOfRepetitions="1" DateFormatString="{0: dddd dd/MM/yyyy}" TimeFormatString="{0: hh:mm tt}"
                                        EmptySlotToolTip="" DataKeyNames="TT_DET_ID"
                                        CssClass="cal" NumberOfDays="180" EnableViewState="true">
                                        <ItemStyle CssClass="item" Wrap="False" />
                                        <BackgroundStyle CssClass="bground" />
                                        <DateStyle CssClass="rangeheader" Wrap="True" />
                                        <TimeStyle CssClass="rangefooter" Wrap="True" />
                                        <EmptyDataTemplate>
                                            No Records Found
                                        </EmptyDataTemplate>
                                        <ItemTemplate>
                                            <%#Eval("TT_DET_ID")%>&nbsp;Group:&nbsp;<%#Eval("GRP_VALUE")%><br />
                                            <%#Eval("FAC_CMPLX_NAME")%><br />
                                            Room No.:&nbsp;<%#Eval("ROOM_NO")%><br />
                                            Paper(s):&nbsp;<%#Eval("EVA_SCH_PAPER_CODE")%>
                                        </ItemTemplate>
                                    </cc4:ScheduleCalendar>
                                </div>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

