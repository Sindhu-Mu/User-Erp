<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="PA03_6.aspx.cs" Inherits="Appraisal_PA036" %>

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

         function validation6A() {

             var flag = true;
             var msg = "", ctrl = "";

             if (!CheckControl("<%=txtTitle6A.ClientID%>")) {
                msg += "- Enter Title\n";
                if (ctrl == "")
                    ctrl = "<%=txtTitle6A.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtFund6A.ClientID%>")) {
                 msg += "- Enter Funding Agency\n";
                 if (ctrl == "")
                     ctrl = "<%=txtFund6A.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtFin6A.ClientID%>")) {
                 msg += "-Enter Financial Outlay\n";
                 if (ctrl == "")
                     ctrl = "<%=txtFin6A.ClientID%>";
                flag = false;
            }
             if (!CheckControl("<%=txtPI6A.ClientID%>")) {
                 msg += "-Enter P.I. Name\n";
                 if (ctrl == "")
                     ctrl = "<%=txtPI6A.ClientID%>";
                 flag = false;
             }
             if (!CheckControl("<%=ddlYear6A.ClientID%>")) {
                 msg += "-Enter Year\n";
                 if (ctrl == "")
                     ctrl = "<%=ddlYear6A.ClientID%>";
                 flag = false;
             }
             if (!CheckControl("<%=ddlPeriod6A.ClientID%>")) {
                 msg += "-Enter Period\n";
                 if (ctrl == "")
                     ctrl = "<%=ddlPeriod6A.ClientID%>";
                 flag = false;
             }
             if (!CheckControl("<%=ddlStatus6A.ClientID%>")) {
                 msg += "-Enter Status\n";
                 if (ctrl == "")
                     ctrl = "<%=ddlStatus6A.ClientID%>";
                 flag = false;
             }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
         }
        
        function validation6B() {

            var flag = true;
            var msg = "", ctrl = "";

            if (!CheckControl("<%=txtTitle6B.ClientID%>")) {
                msg += "- Enter Title\n";
                if (ctrl == "")
                    ctrl = "<%=txtTitle6B.ClientID%>";
                 flag = false;
             }
             if (!CheckControl("<%=txtDetail6B.ClientID%>")) {
                msg += "- Enter detail\n";
                if (ctrl == "")
                    ctrl = "<%=txtDetail6B.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtMembers6B.ClientID%>")) {
                msg += "-Enter Group Member\n";
                if (ctrl == "")
                    ctrl = "<%=txtMembers6B.ClientID%>";
                flag = false;
            }

            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }
        function validation6C() {

            var flag = true;
            var msg = "", ctrl = "";

            if (!CheckControl("<%=txtTitle6C.ClientID%>")) {
                msg += "- Enter Title\n";
                if (ctrl == "")
                    ctrl = "<%=txtTitle6C.ClientID%>";
                flag = false;
            }
            
            if (CheckControl("<%=txtDate6C.ClientID%>")) {
                if (!CheckDate("<%=txtDate6C.ClientID%>")) {
                    msg += "- Invalid Format of Date.Please Enter in this[dd/MM/yyyy]\n";
                    if (ctrl == "")
                        ctrl = "<%=txtDate6C.ClientID%>";
                    flag = false;
                }
            }
            else {
                msg += "- Enter To Date\n";
                if (ctrl == "")
                    ctrl = "<%=txtDate6C.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtPlace6C.ClientID%>")) {
                msg += "- Enter Place\n";
                if (ctrl == "")
                    ctrl = "<%=txtPlace6C.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtProgramme6C.ClientID%>")) {
                msg += "- Enter Programme\n";
                if (ctrl == "")
                    ctrl = "<%=txtProgramme6C.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtOther6C.ClientID%>")) {
                msg += "- Enter Other Relevant Information\n";
                if (ctrl == "")
                    ctrl = "<%=txtOther6C.ClientID%>";
                flag = false;
            }


            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }
        function validation6D() {

            var flag = true;
            var msg = "", ctrl = "";

            if (!CheckControl("<%=txtTask6D.ClientID%>")) {
                msg += "- Enter Task\n";
                if (ctrl == "")
                    ctrl = "<%=txtTask6D.ClientID%>";
                flag = false;
            }

            if (CheckControl("<%=txtDate6D.ClientID%>")) {
                if (!CheckDate("<%=txtDate6D.ClientID%>")) {
                    msg += "- Invalid Format of Date.Please Enter in this[dd/MM/yyyy]\n";
                    if (ctrl == "")
                        ctrl = "<%=txtDate6D.ClientID%>";
                    flag = false;
                }
            }
            else {
                msg += "- Enter To Date\n";
                if (ctrl == "")
                    ctrl = "<%=txtDate6D.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtPlace6D.ClientID%>")) {
                msg += "- Enter Place\n";
                if (ctrl == "")
                    ctrl = "<%=txtPlace6D.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtProgramme6D.ClientID%>")) {
                msg += "- Enter Programme\n";
                if (ctrl == "")
                    ctrl = "<%=txtProgramme6D.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtOther6D.ClientID%>")) {
                msg += "- Enter Other Relevant Information\n";
                if (ctrl == "")
                    ctrl = "<%=txtOther6D.ClientID%>";
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
            <h2>R&amp;D Extension Element
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
                            <asp:Label ID="lblHeader6A" runat="server"></asp:Label>
                            <br />
                            <asp:Label ID="lblDescription6A" runat="server"></asp:Label>
                        </Header>
                        <Content>
                            <asp:UpdatePanel ID="up3A" runat="server">
                                <ContentTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                                <table class="entry">
                                                    <tr>
                                                        <td>
                                                            <table class="entry">
                                                                <tr>
                                                                    <th>Title of Project<span class="required">*</span></th>
                                                                    <th>Funding Agency<span class="required">*</span></th>
                                                                    <th>Financial Outlay<span class="required">*</span></th>
                                                                    <th>Name Of P.I. and<br />
                                                                        other Investigators<span class="required">*</span></th>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:TextBox ID="txtTitle6A" runat="server" MaxLength="200" TextMode="MultiLine" Rows="5"
                                                                            Width="150px"></asp:TextBox></td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtFund6A" runat="server" MaxLength="400" TextMode="MultiLine" Rows="5"
                                                                            Width="150px"></asp:TextBox></td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtFin6A" runat="server" MaxLength="400" TextMode="MultiLine" Rows="5"
                                                                            Width="150px"></asp:TextBox></td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtPI6A" runat="server" MaxLength="400" TextMode="MultiLine" Rows="5"
                                                                            Width="150px"></asp:TextBox></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table>
                                                                <tr>
                                                                    <th>Year<span class="required">*</span></th>
                                                                    <th>Total Peroid<br />
                                                                        (in months)<span class="required">*</span></th>
                                                                    <th>Status<span class="required">*</span></th>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlYear6A" runat="server" Width="90px">
                                                                        </asp:DropDownList></td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlPeriod6A" runat="server" Width="100px">
                                                                        </asp:DropDownList></td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlStatus6A" runat="server" Width="90px">
                                                                        </asp:DropDownList></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Button ID="btnSave6A" Text="Save" runat="server" OnClick="btnSave6A_Click" /></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <asp:GridView ID="gridData6A" runat="server" AutoGenerateColumns="false" GridLines="None"
                                                    AllowPaging="false" CssClass="gridDynamic" AlternatingRowStyle-CssClass="alt"
                                                    SelectedRowStyle-CssClass="pgr" DataKeyNames="PA03_6A_ID" OnRowDeleting="gridData6A_RowDeleting">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="S.No.">
                                                            <ItemTemplate>
                                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                        .
                                                            </ItemTemplate>
                                                            <ItemStyle Width="30px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="PA03_6A_TTL" HeaderText="Title of Project" />
                                                        <asp:BoundField DataField="PA03_6A_FUND" HeaderText="Funding Agency" />
                                                        <asp:BoundField DataField="PA03_6A_FIN" HeaderText="Financial Outlay" />
                                                        <asp:BoundField DataField="PA03_6A_PI" HeaderText="Name Of P.I. and other Investigators" />
                                                        <asp:BoundField DataField="PA03_6A_YEAR" HeaderText="Year" />
                                                        <asp:BoundField DataField="PA03_6A_PRD" HeaderText="Total Peroid (in months)" />
                                                        <asp:BoundField DataField="PA03_PA_STATUS_VALUE" HeaderText="Status" />
                                                        <%-- <asp:BoundField DataField="PA03_6A_STATUS" HeaderText="Status" />--%>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </Content>
                    </ajaxToolkit:AccordionPane>
                    <ajaxToolkit:AccordionPane runat="server" ID="AccordionPane2">
                        <Header>
                            <asp:Label ID="lblHeader6B" runat="server"></asp:Label>
                            <br />
                            <asp:Label ID="lblDescription6B" runat="server"></asp:Label>
                        </Header>
                        <Content>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <th>Title of Patent<span class="required">*</span></th>
                                                        <th>Patent Detail<span class="required">*</span></th>
                                                        <th>Group Members<span class="required">*</span></th>
                                                    </tr>
                                                    <tr>
                                                        <th>
                                                            <asp:TextBox ID="txtTitle6B" runat="server" MaxLength="200" TextMode="MultiLine" Rows="5" Width="200px"></asp:TextBox></th>
                                                        <th>
                                                            <asp:TextBox ID="txtDetail6B" runat="server" MaxLength="400" TextMode="MultiLine" Rows="5" Width="200px"></asp:TextBox></th>
                                                        <th>
                                                            <asp:TextBox ID="txtMembers6B" runat="server" MaxLength="400" TextMode="MultiLine" Rows="5" Width="200px"></asp:TextBox></th>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Button ID="btnSave6B" Text="Save" runat="server" OnClick="btnSave6B_Click" /></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <asp:GridView ID="gridData6B" runat="server" AutoGenerateColumns="false" GridLines="None"
                                                    AllowPaging="false" CssClass="gridDynamic" AlternatingRowStyle-CssClass="alt"
                                                    SelectedRowStyle-CssClass="pgr" DataKeyNames="PA03_6B_ID" OnRowDeleting="gridData6B_RowDeleting">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="S.No.">
                                                            <ItemTemplate>
                                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                    .
                                                            </ItemTemplate>
                                                            <ItemStyle Width="30px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="PA03_6B_TTL" HeaderText="Title of Patent" />
                                                        <asp:BoundField DataField="PA03_6B_MEM" HeaderText="Group Members" />
                                                        <%--<asp:BoundField DataField="PA03_6B_STATUS" HeaderText="Status" />--%>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>

                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </Content>
                    </ajaxToolkit:AccordionPane>
                    <ajaxToolkit:AccordionPane runat="server" ID="AccordionPane3">
                        <Header>
                            <asp:Label ID="lblHeader6C" runat="server"></asp:Label>
                            <br />
                            <asp:Label ID="lblDescription6C" runat="server"></asp:Label>
                        </Header>
                        <Content>
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <th>Title of Lecture/Lecture Series<span class="required">*</span></th>
                                                        <th>Date<span class="required">*</span></th>
                                                        <th>Place<span class="required">*</span></th>
                                                        <th>Programme<span class="required">*</span></th>
                                                        <th>Other Relevant Information</th>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="txtTitle6C" runat="server" MaxLength="200" TextMode="MultiLine" Rows="5"
                                                                Width="200px"></asp:TextBox></td>
                                                        <td>
                                                            <asp:TextBox ID="txtDate6C" runat="server" Width="80px"></asp:TextBox>
                                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtDate6C" Format="dd/MM/yyyy">
                                                            </ajaxToolkit:CalendarExtender>
                                                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="99/99/9999" MaskType="Date"
                                                                TargetControlID="txtDate6C">
                                                            </ajaxToolkit:MaskedEditExtender>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtPlace6C" runat="server" MaxLength="200" TextMode="MultiLine" Rows="5"
                                                                Width="150px"></asp:TextBox></td>
                                                        <td>
                                                            <asp:TextBox ID="txtProgramme6C" runat="server" MaxLength="200" TextMode="MultiLine"
                                                                Rows="5" Width="150px"></asp:TextBox></td>
                                                        <td>
                                                            <asp:TextBox ID="txtOther6C" runat="server" MaxLength="400" TextMode="MultiLine" Rows="5"
                                                                Width="150px"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Button ID="btnSave6C" Text="Save" runat="server" OnClick="btnSave6C_Click" /></td>

                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <asp:GridView ID="gridData6C" runat="server" AutoGenerateColumns="false" GridLines="None"
                                                    AllowPaging="false" CssClass="gridDynamic" AlternatingRowStyle-CssClass="alt"
                                                    SelectedRowStyle-CssClass="pgr" DataKeyNames="PA03_6C_ID" OnRowDeleting="gridData6C_RowDeleting">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="S.No.">
                                                            <ItemTemplate>
                                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                        .
                                                            </ItemTemplate>
                                                            <ItemStyle Width="30px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="PA03_6C_TTL" HeaderText="Title of Lecture/Lecture Series" />
                                                        <asp:BoundField DataField="PA03_6C_DATE" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy}" />
                                                        <asp:BoundField DataField="PA03_6C_PLC" HeaderText="Place" />
                                                        <asp:BoundField DataField="PA03_6C_PRG" HeaderText="Programme" />
                                                        <asp:BoundField DataField="PA03_6C_OTH" HeaderText="Other Relevant Information" />
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>

                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </Content>
                    </ajaxToolkit:AccordionPane>
                    <ajaxToolkit:AccordionPane runat="server" ID="AccordionPane4">
                        <Header>
                            <asp:Label ID="lblHeader6D" runat="server"></asp:Label>
                            <br />
                            <asp:Label ID="lblDescription6D" runat="server"></asp:Label>
                        </Header>
                        <Content>
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                    <table>
                                        <tr>
                                            <th>Task Description<span class="required">*</span></th>
                                            <th>Date<span class="required">*</span></th>
                                            <th>Place<span class="required">*</span></th>
                                            <th>Programme<span class="required">*</span></th>
                                            <th>Other Relevant Information</th>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtTask6D" runat="server" MaxLength="400" TextMode="MultiLine" Rows="5" Width="200px"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txtDate6D" runat="server" Width="80px"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate6D" Format="dd/MM/yyyy">
                                                </ajaxToolkit:CalendarExtender>
                                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" Mask="99/99/9999" MaskType="Date"
                                                    TargetControlID="txtDate6D">
                                                </ajaxToolkit:MaskedEditExtender>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtPlace6D" runat="server" MaxLength="200" TextMode="MultiLine" Rows="5" Width="150px"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txtProgramme6D" runat="server" MaxLength="200" TextMode="MultiLine"
                                                    Rows="5" Width="150px"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txtOther6D" runat="server" MaxLength="400" TextMode="MultiLine" Rows="5" Width="150px"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Button ID="btnSave6D" Text="Save" runat="server" OnClick="btnSave6D_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <asp:GridView ID="gridData6D" runat="server" AutoGenerateColumns="false" GridLines="None"
                                                    AllowPaging="false" CssClass="gridDynamic" AlternatingRowStyle-CssClass="alt"
                                                    SelectedRowStyle-CssClass="pgr" DataKeyNames="PA03_6D_ID" OnRowDeleting="gridData6D_RowDeleting">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="S.No.">
                                                            <ItemTemplate>
                                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                    .
                                                            </ItemTemplate>
                                                            <ItemStyle Width="30px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="PA03_6D_TSK" HeaderText="Task Description" />
                                                        <asp:BoundField DataField="PA03_6D_DATE" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy}" />
                                                        <asp:BoundField DataField="PA03_6D_PLC" HeaderText="Place" />
                                                        <asp:BoundField DataField="PA03_6D_PRG" HeaderText="Programme" />
                                                        <asp:BoundField DataField="PA03_6D_OTH" HeaderText="Other Relevant Information" />
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

