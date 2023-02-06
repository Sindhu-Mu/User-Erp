<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="ExamFeeDefault.aspx.cs" Inherits="Finance_ExamFeeDefault" %>

<%@ Register Src="~/Control/Student.ascx" TagPrefix="uc1" TagName="Student" %>

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
        function Validate() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=txtEnroll.ClientID%>")) {
                msg += " * Enter  Enrollment. \n";
                if (ctrl == "")
                    ctrl = "<%=txtEnroll.ClientID%>";
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
            <h2>Fee Defaulter</h2>
        </div>
        <div>
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                    <ajaxToolkit:TabContainer ID="tabcontainer1" runat="server" ActiveTabIndex="0" OnActiveTabChanged="tabcontainer1_ActiveTabChanged" AutoPostBack="true">
                        <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="Defaulter Student">
                            <ContentTemplate>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <table>
                                            <tr>
                                                <td style="padding-left: 300px" colspan="2">
                                                    <table>
                                                        <tr>

                                                            <td>
                                                                <asp:TextBox ID="txtEnroll" runat="server" Width="200px" placeholder="Enrollment No"></asp:TextBox></td>
                                                            <td>
                                                                <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" /></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <uc1:Student runat="server" ID="Student" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <th>DUE AMOUNT:
                                                </th>
                                                <td>
                                                    <asp:Label ID="lblAmt" runat="server" Font-Size="Larger" ForeColor="#cc0000"></asp:Label>

                                                </td>
                                            </tr>
                                            <tr id="trClear" runat="server" visible="false">
                                                <th>Remark</th>
                                                <td>
                                                    <asp:TextBox ID="txtRemark" runat="server" Width="344px"></asp:TextBox>&nbsp;<asp:Button ID="btnClear" runat="server" OnClick="btnClear_Click" Text="Clear" /></td>

                                            </tr>

                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </ContentTemplate>
                        </ajaxToolkit:TabPanel>
                        <ajaxToolkit:TabPanel ID="TabPnel2" runat="server" HeaderText="Due Report">
                            <ContentTemplate>
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <table>
                                            <tr>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <th>By Insitute</th>
                                                            <th>By Program</th>
                                                            <th>By Branch</th>
                                                            <th>By Sem</th>
                                                            <th>By Status</th>
                                                            <th colspan="2">By Clear Date</th>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:DropDownList ID="ddlIns" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlIns_SelectedIndexChanged"></asp:DropDownList></td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlPgm" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPgm_SelectedIndexChanged" Width="120px"></asp:DropDownList></td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlBranch" runat="server" AutoPostBack="True" Width="120px"></asp:DropDownList></td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlSem" runat="server" AutoPostBack="True"></asp:DropDownList></td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlSts" runat="server" AutoPostBack="True">
                                                                    <asp:ListItem Value="0">Clear</asp:ListItem>
                                                                    <asp:ListItem Value="1">Defaulter</asp:ListItem>
                                                                </asp:DropDownList></td>
                                                            <td>
                                                                <asp:TextBox ID="txtFromDt" runat="server" ViewStateMode="Enabled" Width="90px"></asp:TextBox>
                                                                <ajaxToolkit:CalendarExtender ID="cde1" runat="server" Format="dd/MM/yyyy" TargetControlID="txtFromDt">
                                                                </ajaxToolkit:CalendarExtender>
                                                            </td>
                                                             <td>
                                                                <asp:TextBox ID="txtToDt" runat="server" Width="90px"></asp:TextBox>
                                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txtToDt">
                                                                </ajaxToolkit:CalendarExtender>
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="btnView" runat="server" Text="View" OnClick="btnView_Click" /></td>
                                                            <td>
                                                                <asp:Button ID="BtnExport" runat="server" Text="Export To Excel" OnClick="BtnExport_Click" Width="114px" /></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div style="height: 410px; overflow: auto">
                                                        <asp:GridView ID="gvFeeReport" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" Width="97%">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="S.No">
                                                                    <ItemTemplate>
                                                                        <%#((GridViewRow)Container).RowIndex +1 %>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField HeaderText="Enrollment" DataField="ENROLLMENT_NO" />
                                                                <asp:BoundField HeaderText="Name" DataField="STU_FULL_NAME" />
                                                                <asp:BoundField HeaderText="Institute" DataField="INS_VALUE" />
                                                                <asp:BoundField HeaderText="Program" DataField="PGM_SHORT_NAME" />
                                                                <asp:BoundField HeaderText="Clear Date" DataField="IN_DT" DataFormatString="{00:dd/MM/yyyy}" />
                                                                <asp:BoundField HeaderText="Clear By" DataField="EMP_NAME" />
                                                                <asp:BoundField HeaderText="Remark" DataField="REMARK" />

                                                            </Columns>
                                                        </asp:GridView>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="BtnExport" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </ContentTemplate>
                        </ajaxToolkit:TabPanel>
                    </ajaxToolkit:TabContainer>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

