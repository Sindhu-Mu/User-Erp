<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="PA03_4.aspx.cs" Inherits="Appraisal_PA03_4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script lang="javascript" type="text/javascript">
        function CheckDate(ctrl) {
            var dt = document.getElementById(ctrl).value;
            if (isDatecheck(dt, "dd/MM/yyyy") == false) {
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
                return false;
            }
            else
                document.getElementById(ctrl).style.backgroundColor = "#fff";
            return true;
        }
        function CheckControl(ctrl) {
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == "-1") {
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

            if (!CheckControl("<%=txtOther.ClientID%>")) {
                msg += "- Enter Other Work detail\n";
                if (ctrl == "")
                    ctrl = "<%=txtOther.ClientID%>";
                flag = false;
            }

            if (CheckControl("<%=txtFromDate.ClientID%>")) {
                if (!CheckDate("<%=txtFromDate.ClientID%>")) {
                    msg += "- Invalid Format of Date.Please Enter in this[dd/MM/yyyy]\n";
                    if (ctrl == "")
                        ctrl = "<%=txtFromDate.ClientID%>";
                    flag = false;
                }
            }
            else {
                msg += "- Enter From Date\n";
                if (ctrl == "")
                    ctrl = "<%=txtFromDate.ClientID%>";
                flag = false;
            }
            if (CheckControl("<%=txtToDate.ClientID%>")) {
                if (!CheckDate("<%=txtToDate.ClientID%>")) {
                    msg += "- Invalid Format of Date.Please Enter in this[dd/MM/yyyy]\n";
                    if (ctrl == "")
                        ctrl = "<%=txtToDate.ClientID%>";
                    flag = false;
                }
            }
            else {
                msg += "- Enter To Date\n";
                if (ctrl == "")
                    ctrl = "<%=txtToDate.ClientID%>";
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
            <h2>Other Work
            </h2>
        </div>
        <div style="text-align: right; color: #5a72f8; font-weight: bold; font-size: 14px">
            <a href="PA03_Home.aspx" style="">Back To Main Page</a>
        </div>
        <div style="width: 98%; padding-left: 10px">
            <ajaxToolkit:Accordion ID="Accordion1" runat="server" Width="950px" SelectedIndex="0" HeaderCssClass="accordionHeader" ContentCssClass="accordionContent" HeaderSelectedCssClass="accordionHeaderSelected"
                AutoSize="None" FadeTransitions="true" TransitionDuration="250" FramesPerSecond="40" RequireOpenedPane="false" SuppressHeaderPostbacks="true">
                <Panes>
                    <ajaxToolkit:AccordionPane runat="server" ID="AccordionPane1">
                        <Header>
                            <asp:Label ID="lblHeader4A" runat="server"></asp:Label>
                            <br />
                            <asp:Label ID="lblDescription4A" runat="server"></asp:Label>
                        </Header>
                        <Content>
                            <asp:UpdatePanel ID="up3A" runat="server">
                                <ContentTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <th>Other Works/Duties</th>
                                                        <th>From Date</th>
                                                        <th>To Date</th>
                                                    </tr>
                                                    <tr>
                                                        <th style="vertical-align: top">
                                                            <asp:TextBox ID="txtOther" runat="server" MaxLength="400" Width="400px" TextMode="MultiLine" Rows="5"></asp:TextBox></th>
                                                        <td style="vertical-align: top">
                                                            <asp:TextBox ID="txtFromDate" runat="server" Width="80px"></asp:TextBox>
                                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtFromDate" Format="dd/MM/yyyy">
                                                            </ajaxToolkit:CalendarExtender>
                                                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="99/99/9999" MaskType="Date"
                                                                TargetControlID="txtFromDate">
                                                            </ajaxToolkit:MaskedEditExtender>
                                                        </td>
                                                        <td style="vertical-align: top">
                                                            <asp:TextBox ID="txtToDate" runat="server" Width="80px"></asp:TextBox>
                                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtToDate" Format="dd/MM/yyyy">
                                                            </ajaxToolkit:CalendarExtender>
                                                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" Mask="99/99/9999" MaskType="Date"
                                                                TargetControlID="txtToDate">
                                                            </ajaxToolkit:MaskedEditExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Button ID="btnSave" Text="Save" runat="server" OnClick="btnSave_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <asp:GridView ID="gridData4A" runat="server" AutoGenerateColumns="false" GridLines="None"
                                                    AllowPaging="false" CssClass="gridDynamic" AlternatingRowStyle-CssClass="alt"
                                                    SelectedRowStyle-CssClass="pgr" DataKeyNames="PA03_4A_ID" OnRowDeleting="gridData_RowDeleting">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="S.No.">
                                                            <ItemTemplate>
                                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                    .
                                                            </ItemTemplate>
                                                            <ItemStyle Width="30px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="PA03_4A_OTH" HeaderText="Other Works/Duties" />
                                                        <asp:BoundField DataField="PA03_4A_FROM_DATE" HeaderText="From Date" DataFormatString="{0:dd/MM/yyyy}" />
                                                        <asp:BoundField DataField="PA03_4A_TO_DATE" HeaderText="To Date" DataFormatString="{0:dd/MM/yyyy}" />
                                                        <asp:BoundField DataField="PA03_4A_STATUS" HeaderText="Status" />
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>

                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </Content>
                    </ajaxToolkit:AccordionPane>
                </Panes>
            </ajaxToolkit:Accordion>
        </div>
        <div style="text-align: right; color: #5a72f8; font-weight: bold; font-size: 14px">
            <a href="PA03_Home.aspx" style="">Back To Main Page</a>
        </div>
    </div>
</asp:Content>

