<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="DutyRoster.aspx.cs" Inherits="HR_DutyRoaster" %>

<%@ Register Src="../Control/MonthYear.ascx" TagName="MonthYear" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="heading">
            <h2>Duty Roster
            </h2>
        </div>
        <div>

            <table>


                <tr>
                    <th>Month/Year</th>
                    <td>&nbsp;</td>

                </tr>
                <tr>
                    <td>
                        <uc2:MonthYear ID="MonthYear1" runat="server" />
                    </td>
                    <td>&nbsp;</td>
                    <td style="padding-right: 4px;">
                        <span style="background-color: #FF8080">Holidays</span> and <span style="background-color: #FFFF80">Sundays</span> are Highlighted 
                    </td>
                    <td>
                        <asp:LinkButton ID="lnk1" runat="server" Visible="False" Text="Completed & send for approval" Font-Bold="True" Font-Underline="True" ForeColor="#0000FF" OnClick="lnk1_Click" />
                    </td>
                    <td style="padding-right: 4px;">
                        <asp:LinkButton ID="lnk2" runat="server" Visible="False" Text="Checked & Publish" Font-Bold="True" Font-Underline="True" ForeColor="#0000FF" OnClick="lnk2_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table width="100%">
                <tr>
                    <td>
                        <asp:Button ID="btnShow" runat="server" OnClick="btnShow_Click" Text="Show" />
                    </td>
                </tr>
             
                    <tr>                         
                    <td >
                        <div id="tdMain" runat="server" style="width:100%;overflow:auto; font-size:7px;" >

                        </div>
                    </td>
               </tr>
                   <tr>
                    <td valign="top" style="min-height: 500px">
                        <asp:GridView ID="gvShow" runat="server" AutoGenerateColumns="False" EmptyDataText="No record found" CssClass="gridDynamic" GridLines="None">
                            <FooterStyle BackColor="White" ForeColor="#333333" />
                            <RowStyle BackColor="White" ForeColor="#333333" />
                            <Columns>
                                <asp:TemplateField HeaderText="S.No.">
                                    <ItemTemplate>
                                        <%# ((GridViewRow)Container).RowIndex + 1%>
                                    </ItemTemplate>
                                    <ItemStyle Width="15px" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="EMP_NAME" HeaderText="Employee" />
                                <asp:BoundField HeaderText="Shift" DataField="SHIFT" />
                                <asp:BoundField HeaderText="Hours" DataField="TIME" />
                            </Columns>
                            <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                        </asp:GridView>
                    </td>
                      </tr>
                <%--<tr>
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
                                                <%#Eval("TT_DET_ID")%>&nbsp;Group:&nbsp;<%#Eval("GRP_VALUE")%><br /><%#Eval("FAC_CMPLX_NAME")%><br />Room No.:&nbsp;<%#Eval("ROOM_NO")%><br />Paper(s):&nbsp;<%#Eval("EVA_SCH_PAPER_CODE")%>
                                            </ItemTemplate>
                                        </cc4:ScheduleCalendar>
                                    </div>
                                </td>
                            </tr>--%>
            </table>

        </div>
    </div>
</asp:Content>

