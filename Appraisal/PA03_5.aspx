<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="PA03_5.aspx.cs" Inherits="Appraisal_PA035" %>

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

         function validation5A() {

             var flag = true;
             var msg = "", ctrl = "";

             if (!CheckControl("<%=txtClass5A.ClientID%>")) {
                msg += "- Enter Class\n";
                if (ctrl == "")
                    ctrl = "<%=txtClass5A.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtTitle5A.ClientID%>")) {
                 msg += "- Enter Title\n";
                 if (ctrl == "")
                     ctrl = "<%=txtTitle5A.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtStudents5A.ClientID%>")) {
                 msg += "-Enter Student Name\n";
                 if (ctrl == "")
                     ctrl = "<%=txtStudents5A.ClientID%>";
                flag = false;
            }
             if (!CheckControl("<%=txtSupervisor5A.ClientID%>")) {
                 msg += "-Enter Supervisor Name\n";
                 if (ctrl == "")
                     ctrl = "<%=txtSupervisor5A.ClientID%>";
                 flag = false;
             }
             if (!CheckControl("<%=txtRemarks5A.ClientID%>")) {
                 msg += "-Enter Remark\n";
                 if (ctrl == "")
                     ctrl = "<%=txtRemarks5A.ClientID%>";
                 flag = false;
             }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
         }
         function validation5B() {

             var flag = true;
             var msg = "", ctrl = "";

             if (!CheckControl("<%=txtName5B.ClientID%>")) {
                 msg += "- Enter Nmae\n";
                 if (ctrl == "")
                     ctrl = "<%=txtName5B.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtTitle5B.ClientID%>")) {
                 msg += "- Enter Title\n";
                 if (ctrl == "")
                     ctrl = "<%=txtTitle5B.ClientID%>";
                 flag = false;
             }
         
             if (!CheckControl("<%=txtSupervisor5B.ClientID%>")) {
                 msg += "-Enter Supervisor Name\n";
                 if (ctrl == "")
                     ctrl = "<%=txtSupervisor5B.ClientID%>";
                 flag = false;
             }
             if (!CheckControl("<%=ddlReg5B.ClientID%>")) {
                 msg += "-Enter Registration\n";
                 if (ctrl == "")
                     ctrl = "<%=ddlReg5B.ClientID%>";
                 flag = false;
             }
             if (msg != "") alert(msg);
             if (ctrl != "")
                 document.getElementById(ctrl).focus();
             return flag;
         }
         function validation5C() {

             var flag = true;
             var msg = "", ctrl = "";

             if (!CheckControl("<%=txtAuthor5C.ClientID%>")) {
                 msg += "- Enter Author Name \n";
                 if (ctrl == "")
                     ctrl = "<%=txtAuthor5C.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtTitle5C.ClientID%>")) {
                 msg += "- Enter Title\n";
                 if (ctrl == "")
                     ctrl = "<%=txtTitle5C.ClientID%>";
                 flag = false;
             }
             if (!CheckControl("<%=txtJournal5C.ClientID%>")) {
                 msg += "-Enter Journal Name\n";
                 if (ctrl == "")
                     ctrl = "<%=txtJournal5C.ClientID%>";
                 flag = false;
             }
             if (!CheckControl("<%=txtVol5C.ClientID%>")) {
                 msg += "-Enter Vol.No.\n";
                 if (ctrl == "")
                     ctrl = "<%=txtVol5C.ClientID%>";
                 flag = false;
             }
             if (!CheckControl("<%=ddlYear5C.ClientID%>")) {
                 msg += "-Select Year\n";
                 if (ctrl == "")
                     ctrl = "<%=ddlYear5C.ClientID%>";
                 flag = false;
             }
             if (!CheckControl("<%=txtPage5C.ClientID%>")) {
                 msg += "-Enter Page.\n";
                 if (ctrl == "")
                     ctrl = "<%=txtPage5C.ClientID%>";
                 flag = false;
             }
             if (msg != "") alert(msg);
             if (ctrl != "")
                 document.getElementById(ctrl).focus();
             return flag;
         }
         function validation5D() {

             var flag = true;
             var msg = "", ctrl = "";

             if (!CheckControl("<%=txtAuthor5D.ClientID%>")) {
                 msg += "- Enter Author Name \n";
                 if (ctrl == "")
                     ctrl = "<%=txtAuthor5D.ClientID%>";
                 flag = false;
             }
             if (!CheckControl("<%=txtTitle5D.ClientID%>")) {
                 msg += "- Enter Title\n";
                 if (ctrl == "")
                     ctrl = "<%=txtTitle5D.ClientID%>";
                 flag = false;
             }
             if (!CheckControl("<%=txtConference5D.ClientID%>")) {
                 msg += "-Enter Conference Name\n";
                 if (ctrl == "")
                     ctrl = "<%=txtConference5D.ClientID%>";
                 flag = false;
             }
             if (!CheckControl("<%=txtPlace5D.ClientID%>")) {
                 msg += "-Enter Place\n";
                 if (ctrl == "")
                     ctrl = "<%=txtPlace5D.ClientID%>";
                 flag = false;
             }
             if (!CheckControl("<%=txtPage5D.ClientID%>")) {
                 msg += "-Enter Page.\n";
                 if (ctrl == "")
                     ctrl = "<%=txtPage5D.ClientID%>";
                 flag = false;
             }
             if (!CheckControl("<%=ddlYear5D.ClientID%>")) {
                 msg += "-Select Year\n";
                 if (ctrl == "")
                     ctrl = "<%=ddlYear5D.ClientID%>";
                 flag = false;
             }
             
             if (msg != "") alert(msg);
             if (ctrl != "")
                 document.getElementById(ctrl).focus();
             return flag;
         }
         function validation5E() {

             var flag = true;
             var msg = "", ctrl = "";

             if (!CheckControl("<%=txtAuthor5E.ClientID%>")) {
                 msg += "- Enter Author Name \n";
                 if (ctrl == "")
                     ctrl = "<%=txtAuthor5E.ClientID%>";
                 flag = false;
             }
             if (!CheckControl("<%=txtTitle5E.ClientID%>")) {
                 msg += "- Enter Title\n";
                 if (ctrl == "")
                     ctrl = "<%=txtTitle5E.ClientID%>";
                 flag = false;
             }
             if (!CheckControl("<%=txtPublisher5E.ClientID%>")) {
                 msg += "-Enter Publisher\n";
                 if (ctrl == "")
                     ctrl = "<%=txtPublisher5E.ClientID%>";
                 flag = false;
             }
             if (!CheckControl("<%=txtVolume5E.ClientID%>")) {
                 msg += "-Enter Volume\n";
                 if (ctrl == "")
                     ctrl = "<%=txtVolume5E.ClientID%>";
                 flag = false;
             }
             
             if (!CheckControl("<%=ddlYear5E.ClientID%>")) {
                 msg += "-Select Year\n";
                 if (ctrl == "")
                     ctrl = "<%=ddlYear5E.ClientID%>";
                 flag = false;
             }
             if (!CheckControl("<%=txtPage5E.ClientID%>")) {
                 msg += "-Enter Page.\n";
                 if (ctrl == "")
                     ctrl = "<%=txtPage5E.ClientID%>";
                 flag = false;
             }
             if (msg != "") alert(msg);
             if (ctrl != "")
                 document.getElementById(ctrl).focus();
             return flag;
         }
        </script>
    <div class="container">
        <div class="heading" style="width: 100%">
            <h2>Academic Research and Publication Element
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
                            <asp:Label ID="lblHeader5A" runat="server"></asp:Label>
                            <br />
                            <asp:Label ID="lblDescription5A" runat="server"></asp:Label>
                        </Header>
                        <Content>
                            <asp:UpdatePanel ID="up3A" runat="server">
                                <ContentTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <th>Class<span class="required">*</span></th>
                                                        <th>Title of Project/Dissertations<span class="required">*</span></th>
                                                        <th>Names of Students<span class="required">*</span></th>
                                                        <th>Name of other Supervisor (if any)</th>
                                                        <th>Remarks</th>
                                                    </tr>
                                                    <tr>
                                                        <td style="vertical-align: top">
                                                            <asp:TextBox ID="txtClass5A" runat="server" MaxLength="200" TextMode="MultiLine" Rows="3" Width="150px"></asp:TextBox></td>
                                                        <td>
                                                            <asp:TextBox ID="txtTitle5A" runat="server" MaxLength="400" TextMode="MultiLine" Rows="5" Width="150px"></asp:TextBox></td>
                                                        <td>
                                                            <asp:TextBox ID="txtStudents5A" runat="server" MaxLength="400" TextMode="MultiLine" Rows="5" Width="150px"></asp:TextBox></td>
                                                        <td>
                                                            <asp:TextBox ID="txtSupervisor5A" runat="server" MaxLength="200" TextMode="MultiLine" Rows="5" Width="200px"></asp:TextBox></td>
                                                        <td>
                                                            <asp:TextBox ID="txtRemarks5A" runat="server" MaxLength="400" TextMode="MultiLine" Rows="5" Width="150px"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Button ID="btnSave5A" Text="Save" runat="server" OnClick="btnSave5A_Click" /></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <asp:GridView ID="gridData5A" runat="server" AutoGenerateColumns="false" GridLines="None"
                                                    AllowPaging="false" CssClass="gridDynamic" AlternatingRowStyle-CssClass="alt" DataKeyNames="PA03_5A_ID"
                                                    SelectedRowStyle-CssClass="pgr" OnRowDeleting="gridData5A_RowDeleting">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="S.No.">
                                                            <ItemTemplate>
                                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                    .
                                                            </ItemTemplate>
                                                            <ItemStyle Width="30px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="PA03_5A_CLS" HeaderText="Class" />
                                                        <asp:BoundField DataField="PA03_5A_TTL" HeaderText="Title of Project/Dissertations" />
                                                        <asp:BoundField DataField="PA03_5A_STUS" HeaderText="Names of Students" />
                                                        <asp:BoundField DataField="PA03_5A_SPR" HeaderText="Name of other Supervisor (if any)" />
                                                        <asp:BoundField DataField="PA03_5A_RMK" HeaderText="Remarks" />
                                                        <%-- <asp:BoundField DataField="PA03_5A_STATUS" HeaderText="Status" />--%>
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
                            <asp:Label ID="lblHeader5B" runat="server"></asp:Label>
                            <br />
                            <asp:Label ID="lblDescription5B" runat="server"></asp:Label>
                        </Header>
                        <Content>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <th>Name of Student<span class="required">*</span></th>
                                                        <th>Thesis Title<span class="required">*</span></th>
                                                        <th>Other Supervisor(s) (if any)</th>
                                                        <th>Reg. Year<span class="required">*</span></th>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="txtName5B" runat="server" MaxLength="200" TextMode="MultiLine" Rows="5"
                                                                Width="200px"></asp:TextBox></td>
                                                        <td>
                                                            <asp:TextBox ID="txtTitle5B" runat="server" MaxLength="200" TextMode="MultiLine" Rows="5"
                                                                Width="200px"></asp:TextBox></td>
                                                        <td>
                                                            <asp:TextBox ID="txtSupervisor5B" runat="server" MaxLength="200" TextMode="MultiLine"
                                                                Rows="5" Width="150px"></asp:TextBox></td>
                                                        <td style="vertical-align: top">
                                                            <asp:DropDownList ID="ddlReg5B" runat="server" Width="100px">
                                                            </asp:DropDownList></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Button ID="btnSave5B" Text="Save" runat="server" OnClick="btnSave5B_Click" /></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <asp:GridView ID="gridData5B" runat="server" AutoGenerateColumns="false" GridLines="None"
                                                    AllowPaging="false" CssClass="gridDynamic" AlternatingRowStyle-CssClass="alt"
                                                    SelectedRowStyle-CssClass="pgr" DataKeyNames="PA03_5B_ID" OnRowDeleting="gridData5B_RowDeleting">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="S.No.">
                                                            <ItemTemplate>
                                                                <%#((GridViewRow)Container).RowIndex + 1%>
                                        .
                                                            </ItemTemplate>
                                                            <ItemStyle Width="30px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="PA03_5B_STU_NAME" HeaderText="Name of Student" />
                                                        <asp:BoundField DataField="PA03_5B_TTL" HeaderText="Thesis Title" />
                                                        <asp:BoundField DataField="PA03_5B_SPR" HeaderText="Other Supervisor(s) (if any)" />
                                                        <asp:BoundField DataField="PA03_5B_REG" HeaderText="Reg. Year" />
                                                        <%--<asp:BoundField DataField="PA03_5B_STATUS" HeaderText="Status" />--%>
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
                            <asp:Label ID="lblHeader5C" runat="server"></asp:Label>
                            <br />
                            <asp:Label ID="lblDescription5C" runat="server"></asp:Label>
                        </Header>
                        <Content>
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <th>Authors' Names<br />
                                                            (Sequence As In Paper)<span class="required">*</span></th>
                                                        <th>Title of Paper<span class="required">*</span></th>
                                                        <th>Name of Journal<span class="required">*</span></th>
                                                        <th>Vol. No.<span class="required">*</span></th>
                                                        <th>Year<span class="required">*</span></th>
                                                        <th>Page Nos<span class="required">*</span></th>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="txtAuthor5C" runat="server" MaxLength="400" TextMode="MultiLine" Rows="5" Width="200px"></asp:TextBox></td>
                                                        <td>
                                                            <asp:TextBox ID="txtTitle5C" runat="server" MaxLength="200" TextMode="MultiLine" Rows="5" Width="150px"></asp:TextBox></td>
                                                        <td>
                                                            <asp:TextBox ID="txtJournal5C" runat="server" MaxLength="200" TextMode="MultiLine" Rows="5" Width="150px"></asp:TextBox></td>
                                                        <td style="vertical-align: top">
                                                            <asp:TextBox ID="txtVol5C" runat="server" MaxLength="100" Rows="5" Width="100px"></asp:TextBox></td>
                                                        <td style="vertical-align: top">
                                                            <asp:DropDownList ID="ddlYear5C" runat="server" Width="90px"></asp:DropDownList></td>
                                                        <td>
                                                            <asp:TextBox ID="txtPage5C" runat="server" MaxLength="400" TextMode="MultiLine" Rows="5" Width="150px"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Button ID="btnSave5C" Text="Save" runat="server" OnClick="btnSave5C_Click" /></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <asp:GridView ID="gridData5C" runat="server" AutoGenerateColumns="false" GridLines="None"
                                                    AllowPaging="false" CssClass="gridDynamic" AlternatingRowStyle-CssClass="alt"
                                                    SelectedRowStyle-CssClass="pgr" DataKeyNames="PA03_5C_ID" OnRowDeleting="gridData5C_RowDeleting">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="S.No.">
                                                            <ItemTemplate>
                                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                    .
                                                            </ItemTemplate>
                                                            <ItemStyle Width="30px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="PA03_5C_AUTH" HeaderText="Authors' Names(Sequence As In Paper)" />
                                                        <asp:BoundField DataField="PA03_5C_TTL" HeaderText="Title of Paper" />
                                                        <asp:BoundField DataField="PA03_5C_VOL" HeaderText="Vol. No." />
                                                        <asp:BoundField DataField="PA03_5C_YEAR" HeaderText="Year" />
                                                        <asp:BoundField DataField="PA03_5C_PAGE" HeaderText="Page Nos" />
                                                        <%--<asp:BoundField DataField="PA03_5C_STATUS" HeaderText="Status" />--%>
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
                            <asp:Label ID="lblHeader5D" runat="server"></asp:Label>
                            <br />
                            <asp:Label ID="lblDescription5D" runat="server"></asp:Label>
                        </Header>
                        <Content>
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <th>Authors' Names<br />
                                                            (Sequence As In Paper)<span class="required">*</span></th>
                                                        <th>Title of Paper<span class="required">*</span></th>
                                                        <th>Name of Conference<span class="required">*</span></th>
                                                        <th>Place<span class="required">*</span></th>
                                                        <th>Page Nos'<span class="required">*</span></th>
                                                        <th>Year<span class="required">*</span></th>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="txtAuthor5D" runat="server" MaxLength="400" TextMode="MultiLine" Rows="5"
                                                                Width="172px"></asp:TextBox></td>
                                                        <td>
                                                            <asp:TextBox ID="txtTitle5D" runat="server" MaxLength="200" TextMode="MultiLine" Rows="5"
                                                                Width="139px"></asp:TextBox></td>
                                                        <td>
                                                            <asp:TextBox ID="txtConference5D" runat="server" MaxLength="200" TextMode="MultiLine"
                                                                Rows="5" Width="145px"></asp:TextBox></td>
                                                        <td>
                                                            <asp:TextBox ID="txtPlace5D" runat="server" MaxLength="200" TextMode="MultiLine" Rows="5"
                                                                Width="142px"></asp:TextBox></td>
                                                        <td>
                                                            <asp:TextBox ID="txtPage5D" runat="server" MaxLength="400" TextMode="MultiLine" Rows="5"
                                                                Width="107px"></asp:TextBox></td>
                                                        <td style="vertical-align: top">
                                                            <asp:DropDownList ID="ddlYear5D" runat="server" Width="70px">
                                                            </asp:DropDownList></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Button ID="btnSave5D" Text="Save" runat="server" OnClick="btnSave5D_Click" /></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <asp:GridView ID="gridData5D" runat="server" AutoGenerateColumns="false" GridLines="None"
                                                    AllowPaging="false" CssClass="gridDynamic" AlternatingRowStyle-CssClass="alt"
                                                    SelectedRowStyle-CssClass="pgr" DataKeyNames="PA03_5D_ID" OnRowDeleting="gridData5D_RowDeleting">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="S.No.">
                                                            <ItemTemplate>
                                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                        .
                                                            </ItemTemplate>
                                                            <ItemStyle Width="30px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="PA03_5D_AUTH" HeaderText="Authors' Names(Sequence As In Paper)" />
                                                        <asp:BoundField DataField="PA03_5D_TTL" HeaderText="Title of Paper" />
                                                        <asp:BoundField DataField="PA03_5D_CNF" HeaderText="Name of Conference" />
                                                        <asp:BoundField DataField="PA03_5D_PLC" HeaderText="Place" />
                                                        <asp:BoundField DataField="PA03_5D_YEAR" HeaderText="Year" />
                                                        <asp:BoundField DataField="PA03_5D_PAGE" HeaderText="Page Nos'" />
                                                        <%-- <asp:BoundField DataField="PA03_5D_STATUS" HeaderText="Status" />--%>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>

                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </Content>
                    </ajaxToolkit:AccordionPane>
                    <ajaxToolkit:AccordionPane runat="server" ID="AccordionPane5">
                        <Header>
                            <asp:Label ID="lblHeader5E" runat="server"></asp:Label>
                            <br />
                            <asp:Label ID="lblDescription5E" runat="server"></asp:Label>
                        </Header>
                        <Content>
                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                <ContentTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <th>Authors' Names<br />
                                                            (Sequence As In Paper)<span class="required">*</span></th>
                                                        <th>Title<span class="required">*</span></th>
                                                        <th>Publisher<span class="required">*</span></th>
                                                        <th>Vol. No.<span class="required">*</span></th>
                                                        <th>Year<span class="required">*</span></th>
                                                        <th>Page Nos<span class="required">*</span></th>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="txtAuthor5E" runat="server" MaxLength="400" TextMode="MultiLine" Rows="5" Width="200px"></asp:TextBox></td>
                                                        <td>
                                                            <asp:TextBox ID="txtTitle5E" runat="server" MaxLength="200" TextMode="MultiLine" Rows="5" Width="150px"></asp:TextBox></td>
                                                        <td>
                                                            <asp:TextBox ID="txtPublisher5E" runat="server" MaxLength="200" TextMode="MultiLine" Rows="5" Width="150px"></asp:TextBox></td>
                                                        <td style="vertical-align: top">
                                                            <asp:TextBox ID="txtVolume5E" runat="server" MaxLength="100" Rows="5" Width="80px"></asp:TextBox></td>
                                                        <td style="vertical-align: top">
                                                            <asp:DropDownList ID="ddlYear5E" runat="server" Width="100px"></asp:DropDownList></td>
                                                        <td>
                                                            <asp:TextBox ID="txtPage5E" runat="server" MaxLength="400" TextMode="MultiLine" Rows="5" Width="150px"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Button ID="btnSave5E" Text="Save" runat="server" OnClick="btnSave5E_Click" /></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <asp:GridView ID="gridData5E" runat="server" AutoGenerateColumns="false" GridLines="None"
                                                    AllowPaging="false" CssClass="gridDynamic" AlternatingRowStyle-CssClass="alt"
                                                    SelectedRowStyle-CssClass="pgr" DataKeyNames="PA03_5E_ID" OnRowDeleting="gridData5E_RowDeleting">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="S.No.">
                                                            <ItemTemplate>
                                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                    .
                                                            </ItemTemplate>
                                                            <ItemStyle Width="30px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="PA03_5E_AUTH" HeaderText="Authors' Names(Sequence As In Paper)" />
                                                        <asp:BoundField DataField="PA03_5E_TTL" HeaderText="Title" />
                                                        <asp:BoundField DataField="PA03_5E_PUB" HeaderText="Publisher" />
                                                        <asp:BoundField DataField="PA03_5E_VOL" HeaderText="Vol. No." />
                                                        <asp:BoundField DataField="PA03_5E_YEAR" HeaderText="Year" />
                                                        <asp:BoundField DataField="PA03_5E_PAGE" HeaderText="Page Nos" />
                                                        <%--<asp:BoundField DataField="PA03_5E_STATUS" HeaderText="Status" />--%>
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

