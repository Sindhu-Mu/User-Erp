<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="rptTimeTable.aspx.cs" Inherits="Academic_rptTimeTable" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <script lang="javascript" type="text/javascript">
         function CheckControl(ctrl) {
             if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == "Select" || bTrim(document.getElementById(ctrl).value) == ".") {
                 document.getElementById(ctrl).style.backgroundColor = "#fc6";
                 return false;
             }
             else
                 document.getElementById(ctrl).style.backgroundColor = "#fff";
             return true;
         }
         function validation() {

             var flag = true;
             var msg = "", ctrl = "";
             if (!CheckControl("<%=txtFromDate.ClientID%>")) {
                 msg += " * Enter Start Date \n";
                 if (ctrl == "")
                     ctrl = "<%=txtFromDate.ClientID%>";
                flag = false;
             }
             if (!CheckControl("<%=txtEndDate.ClientID%>")) {
                 msg += " * Enter End Date \n";
                 if (ctrl == "")
                     ctrl = "<%=txtEndDate.ClientID%>";
                 flag = false;
             }
             if (!CheckControl("<%=ddlInstitute.ClientID%>")) {
                msg += "- Select Institute from list\n";
                if (ctrl == "")
                    ctrl = "<%=ddlInstitute.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlSemesterBound.ClientID%>")) {
                msg += "- Select Semester from list\n";
                if (ctrl == "")
                    ctrl = "<%=ddlSemesterBound.ClientID%>";
                flag = false;
            }
             if (!CheckControl("<%=ddlChooseClass.ClientID%>")) {
                 msg += "- Select Class from list\n";
                 if (ctrl == "")
                     ctrl = "<%=ddlChooseClass.ClientID%>";
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
            <h2>Time Table Report</h2>
        </div>
        <div>
            <asp:UpdatePanel ID="UP11" runat="server">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <th>Choose Institute<span class="required">*</span></th>
                                        <th>Choose Sem<span class="required">*</span></th>
                                        <th>Choose Class<span class="required">*</span></th>
                                        <th>From Date<span class="required">*</span></th>
                                        <th>To Date<span class="required">*</span></th>
                                        <td></td>
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
                                            <asp:DropDownList ID="ddlChooseClass" runat="server" Width="130px">
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
                                    <cc4:schedulecalendar id="tt_Calender" runat="server" datefield="" endoftimescale="18:00:00"
                                        endtimefield="" gridlines="Both" horizontalalign="NotSet" itemstylefield="" layout="Horizontal"
                                        startdate="2011-08-08" startday="Monday" startoftimescale="09:00:00" starttimefield=""
                                        NumberOfRepetitions="1" dateformatstring="{0: dddd dd/MM/yyyy}" timeformatstring="{0: hh:mm tt}"
                                        emptyslottooltip="" datakeynames="TT_DET_ID"
                                        cssclass="cal" numberofdays="180" enableviewstate="true">
                                        <ItemStyle CssClass="item" Wrap="False" />
                                        <BackgroundStyle CssClass="bground" />
                                        <DateStyle CssClass="rangeheader" Wrap="True" />
                                        <TimeStyle CssClass="rangefooter" Wrap="True" />
                                        <EmptyDataTemplate>
                                            No Records Found
                                        </EmptyDataTemplate>
                                        <ItemTemplate>
                                           <%#Eval("TT_DET_ID")%>&nbsp;Group:&nbsp;<%#Eval("GRP_VALUE")%><br />
                                            Faculty:&nbsp;<%#Eval("EMP_NAME")%><br />
                                            <%#Eval("FAC_CMPLX_NAME")%><br />Room No.:&nbsp;<%#Eval("ROOM_NO")%><br />
                                            Paper(s):&nbsp;<%#Eval("EVA_SCH_PAPER_CODE")%>
                                        </ItemTemplate>
                                    </cc4:schedulecalendar>
                                </div>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

