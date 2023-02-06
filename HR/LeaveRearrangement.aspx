<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Short.master" AutoEventWireup="true" CodeFile="LeaveRearrangement.aspx.cs" Inherits="HR_LeaveRearrangement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentHolder1" runat="Server">
    <script language="javascript" type="text/javascript">

        function CheckAutoComplete(ctrl) {

            var Value = bTrim(document.getElementById(ctrl).value);
            if (Value.indexOf(":") > 0 && Value.length - 1 != Value.lastIndexOf(":")) {
                document.getElementById(ctrl).style.backgroundColor = "#fff";
                return true;
            }
            else
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
            return false;
        }
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
            if (!CheckAutoComplete("<%=txtEmp.ClientID%>")) {
                msg += " * Enter Employee Name & Code. \n";
                if (ctrl == "")
                    ctrl = "<%=txtEmp.ClientID%>";
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
            <h2>Leave Rearrangement</h2>
        </div>
        <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>--%>
        <div>
            <table>
                <tr>
                    <td>
                        <asp:GridView ID="gvShow" runat="server" DataKeyNames="LV_APP_ID,LV_ARR_ID" CssClass="gridDynamic" AutoGenerateColumns="False" EmptyDataText="No Recoud Foud" OnRowCommand="gvShow_RowCommand">
                            <Columns>
                                <asp:TemplateField HeaderText="S.No.">
                                    <ItemTemplate><%#((GridViewRow)Container).RowIndex+1 %></ItemTemplate>
                                    <ItemStyle Width="15px" />
                                </asp:TemplateField>

                                <asp:BoundField DataField="EMP_NAME" HeaderText=" NAME "></asp:BoundField>
                                <asp:BoundField DataField="DEPT_VALUE" HeaderText=" DEPARTMENT "></asp:BoundField>
                                <asp:BoundField DataField="REMARK" HeaderText=" REMARK " />
                                <asp:CommandField SelectText="Detail" ShowSelectButton="True" ButtonType="Button"></asp:CommandField>
                            </Columns>
                            <SelectedRowStyle BackColor="#FFFF99" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td id="tdetail" runat="server" visible="false">
                        <table>
                            <tr>
                                <td style="padding-top: 10px"><b>Leave Detail</b></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="gvDetail" runat="server" AutoGenerateColumns="False" CssClass="gridDynamic">
                                        <Columns>
                                            <asp:TemplateField HeaderText="S.No.">
                                                <ItemTemplate><%#((GridViewRow)Container).RowIndex+1 %></ItemTemplate>
                                                <ItemStyle Width="15px" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="LV_VALUE" HeaderText=" LEAVE NAME " />
                                            <asp:BoundField DataField="FROM_DT" DataFormatString="{0:dd/MM/yyyy}" HeaderText=" FROM DATE " />
                                            <asp:BoundField DataField="TO_DT" DataFormatString="{0:dd/MM/yyyy}" HeaderText=" TO DATE " />
                                            <asp:BoundField DataField="TOT_DAYS" HeaderText=" TOT DAYS " />
                                            <asp:BoundField DataField="STS_VALUE" HeaderText=" STATUS " />
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td>Time Table Detail</td>
                            </tr>
                            <asp:GridView ID="gvTT" runat="server" ShowFooter="True" Width="100%" AutoGenerateColumns="False"
                                    EmptyDataText="There is no time table." CssClass="gridDynamic">
                                    <Columns>
                                        <asp:TemplateField HeaderText="S#">
                                            <ItemTemplate>
                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="CLS_DATE" HeaderText="Class Date" DataFormatString="{0:dd/MM/yyyy}"></asp:BoundField>
                                        <asp:BoundField DataField="TT_SLOT_VALUE" HeaderText="Time Slot"></asp:BoundField>
                                        <asp:BoundField DataField="CLS_VALUE" HeaderText="Class Name"></asp:BoundField>
                                        <asp:BoundField DataField="ACA_SEM_ID" HeaderText="Semester"></asp:BoundField>
                                        <asp:BoundField DataField="ACA_SEC_NAME" HeaderText="Section"></asp:BoundField>
                                        <asp:BoundField DataField="PAPER_CODE" HeaderText="Course Code"></asp:BoundField>
                                        <asp:BoundField DataField="FAC_CMPLX_NAME" HeaderText="Complex"></asp:BoundField>
                                        <asp:BoundField DataField="ROOM_NO" HeaderText="Room No."></asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            <tr>
                                <td>
                                    <table>
                                        <tr>
                                            <td>Employee Name<span style="color: red">*</span></td>
                                            <%--<td>Date</td>--%>
                                            <td>Remark<span style="color: red">*</span></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtEmp" runat="server"></asp:TextBox>
                                                <ajaxToolkit:AutoCompleteExtender ID="autoComplete1" runat="server" CompletionInterval="500"
                                                    CompletionSetCount="12" ContextKey="1" EnableCaching="true" MinimumPrefixLength="1"
                                                    ServiceMethod="GetEmployeeList" ServicePath="~\AutoComplete.asmx" TargetControlID="txtEmp">
                                                </ajaxToolkit:AutoCompleteExtender>
                                            </td>
                                            <%--<td>
                                                    <table>
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="txtDate"></ajaxToolkit:CalendarExtender>

                                                </td>
                                                <td>
                                                    <a href="#"></a>

                                                    <script type="text/javascript">fnDate("<%=txtDate.ClientID%>", "imgCal1");</script>

                                                </td>
                                            </tr>
                                        </table>
                                    </td>--%>

                                            <td>
                                                <asp:TextBox ID="txtRemark" runat="server"></asp:TextBox></td>
                                            <td>
                                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" /></td>
                                            <td>
                                                <asp:Button
                                                    ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" /></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <%--            </ContentTemplate>
        </asp:UpdatePanel>--%>
    </div>
</asp:Content>

