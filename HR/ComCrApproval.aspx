<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Short.master" AutoEventWireup="true" CodeFile="ComCrApproval.aspx.cs" Inherits="HR_ComCrApproval" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentHolder1" runat="Server">
    <script language="javascript" type="text/javascript">
        function CheckControl(ctrl) {
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == ".") {
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
            if (!CheckControl("<%=txtRemark.ClientID%>")) {
                msg += " * Enter Remark. \n";
                if (ctrl == "")
                    ctrl = "<%=txtRemark.ClientID%>";
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
            <span style="font-size:14px;color:red;font-weight:bold"></span>
            <h2>Compensatory Credit Approval</h2>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <td id="tdAction" runat="server" visible="false">
                            <table>
                                <tr>
                                    <td>Remarks
                                        <asp:TextBox ID="txtRemark" runat="server"></asp:TextBox></td>
                                    <%--<td>For Day :<asp:DropDownList ID="ddlForward" runat="server" Width="90px">
                                        <asp:ListItem Value="1">Full Day</asp:ListItem>
                                        <asp:ListItem Value=".5">Half Day</asp:ListItem>
                                    </asp:DropDownList></td>--%>
                                    <td>
                                        <asp:Button ID="btnReccomend" runat="server" Text="Recommend" Width="100px" OnClick="btnReccomend_Click"/>
                                        <asp:Button ID="btnApproved" runat="server" Text="Approved" Width="100px" OnClick="btnApproved_Click" /></td>
                                    <td>
                                        <asp:Button ID="btnReject" runat="server" Text="Reject" Width="100px" OnClick="btnReject_Click" /></td>
                                    <td>
                                        <asp:Label ID="lblMsg" runat="server" Visible="false"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="gvCom" runat="server" AutoGenerateColumns="False" EmptyDataText="No record found" OnRowCommand="gvCom_RowCommand" DataKeyNames="ID" CssClass="gridDynamic">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No.">
                                        <ItemTemplate>
                                            <%# ((GridViewRow)Container).RowIndex + 1%>
                                                        .
                                        </ItemTemplate>
                                        <ItemStyle Width="15px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="EMP_ID" HeaderText="Sender Code"></asp:BoundField>
                                    <asp:BoundField DataField="EMP_NAME" HeaderText="Sender Name"></asp:BoundField>
                                    <%--<asp:BoundField DataField="DEPT_VALUE" HeaderText="Department"></asp:BoundField>
                                    <asp:BoundField DataField="DES_VALUE" HeaderText="Designation"></asp:BoundField>--%>
                                    <asp:BoundField DataField="WORK_DT" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Work Date"></asp:BoundField>
                                    <asp:BoundField DataField="FROM_TIME" HeaderText="From Time" />
                                    <asp:BoundField DataField="TO_TIME" HeaderText="To Time" />
                                    <asp:BoundField DataField="DESCRP" HeaderText="Description"></asp:BoundField>
                                    <asp:BoundField DataField="IN_DT" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Applyed Date"></asp:BoundField>
                                    <asp:BoundField DataField="NOD" HeaderText="For Day" />
                                    <asp:CommandField ButtonType="Button" SelectText="Log Detail" ShowSelectButton="True"></asp:CommandField>
                                </Columns>
                                <SelectedRowStyle BackColor="#CCFF99" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td id="tdAtt" runat="server" visible="false">
                            <table>
                                <tr>
                                    <td><b>Attendance Detail</b></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:GridView ID="gvAtt" runat="server" AutoGenerateColumns="False" EmptyDataText="No record found">
                                            <Columns>
                                                <asp:TemplateField HeaderText="S.No.">
                                                    <ItemTemplate><%#((GridViewRow)Container).RowIndex+1 %></ItemTemplate>
                                                    <ItemStyle Width="15px" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="EMP_NAME" HeaderText="Sender Name"></asp:BoundField>
                                                <asp:BoundField DataField="DATE_TIME" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Work Date"
                                                    HtmlEncode="False"></asp:BoundField>
                                                <asp:BoundField DataField="TIME" HeaderText="Time" />
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

</asp:Content>
