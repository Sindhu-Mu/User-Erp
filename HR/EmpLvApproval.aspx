<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="EmpLvApproval.aspx.cs" Inherits="HR_EmpLvApproval" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script lang="javascript" type="text/javascript">
        function CheckControl(ctrl) {
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == "." || bTrim(document.getElementById(ctrl).value) == "Select") {
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
                return false;
            }
            else
                document.getElementById(ctrl).style.backgroundColor = "#fff";
            return true;
        }
        function validate() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=txtRemarks.ClientID%>")) {
                msg += "- Enter Remark. \n";
                if (ctrl == "")
                    ctrl = "<%=txtRemarks.ClientID%>";
                flag = false;
            }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }


    </script>

    <div>
        <div class="heading">
            <h2>Leave Approval</h2>
        </div>
        <table>
            <tr>
                <td>
                    <asp:UpdatePanel ID="UP10" runat="server">
                        <ContentTemplate>
                            <table>

                                <tr>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <table id="tbApp" runat="server" visible="false">
                                                    <tr>
                                                        <td>Remarks<span style="color: red">*</span> :
                                                        <asp:TextBox ID="txtRemarks" runat="server" CssClass="textbox" Width="204px"></asp:TextBox></td>

                                                        <td>
                                                            <asp:Button ID="btnApproved" runat="server" Text="Approved" OnClick="btnApproved_Click" /></td>
                                                        <td>
                                                            <asp:Button ID="btnRecommend" runat="server" Text="Recommend" OnClick="btnRecommend_Click" />
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="btnReject" runat="server" Text="Reject" OnClick="btnReject_Click" /></td>
                                                    </tr>
                                                </table>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="vertical-align: top">
                                        <asp:Button ID="btnLeave" runat="server" Text="Leave" OnClick="btnLeave_Click" />
                                        <asp:Button ID="btnOnDuty" runat="server" Text="On Duty" OnClick="btnOnDuty_Click" />
                                        <asp:Button ID="btnCancel" runat="server" Text="Leave Cancelletion" OnClick="btnCancel_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div>
                                            <asp:GridView ID="gvShow" runat="server" AutoGenerateColumns="False" CssClass="gridDynamic"
                                                EmptyDataText="No record found" DataKeyNames="LV_APP_ID, ID, LV_ID, ACTION_BY,TOT_DAYS" OnRowCommand="gvShow_RowCommand">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S.No.">
                                                        <ItemTemplate>
                                                            <%# ((GridViewRow)Container).RowIndex + 1%>
                                                        .
                                                        </ItemTemplate>
                                                        <ItemStyle Width="15px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="EMP_ID" HeaderText="Employee Code " />
                                                    <asp:BoundField DataField="EMP_NAME" HeaderText="Employee " />                                                                                                       
                                                    <asp:BoundField DataField="IN_DT" HeaderText="Request Date" />
                                                    <asp:BoundField DataField="LV_VALUE" HeaderText="Leave Type" />
                                                    <asp:BoundField DataField="FROM_DT" HeaderText="From" />
                                                    <asp:BoundField DataField="TO_DT" HeaderText="To" />
                                                    <asp:BoundField DataField="TOT_DAYS" HeaderText="Total Days" HtmlEncode="False"></asp:BoundField>
                                                    <asp:BoundField HeaderText="Forward By" DataField="ACT_BY" />
                                                    <asp:BoundField DataField="REASON" HeaderText="Reason" />
                                                    <asp:BoundField DataField="DAY_TYPE_NAME" HeaderText="Half Day" />
                                                    <asp:CommandField ButtonType="Button" SelectText="ACTION" ShowSelectButton="True"></asp:CommandField>

                                                </Columns>
                                                <SelectedRowStyle BackColor="#CCFF99" />
                                            </asp:GridView>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table id="div2" runat="server" visible="false">
                                            <tr>
                                                <td style="height: 20px; color: #ff8c00; text-align: left">
                                                    <strong>LEAVE INFORMATION OF
                                                    <asp:Label ID="lblEmployee" runat="server" ForeColor="Red"></asp:Label></strong>
                                                    &nbsp;&nbsp;
                                                <hr color="#ff8c00" noshade="noshade" size="1" />
                                                </td>
                                            </tr>
                                            <tr>

                                                <td id="tdCompen" runat="server" align="left" valign="top" visible="false">
                                                    <strong>Compensatory Detail<br />
                                                    </strong>
                                                    <asp:GridView ID="gvComp" runat="server" AutoGenerateColumns="False">
                                                        <Columns>
                                                            <asp:BoundField DataField="WorkDT" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Working Date"
                                                                HtmlEncode="False" />
                                                            <asp:BoundField DataField="Description" HeaderText="Description" />
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;<asp:Button ID="btnArrange" runat="server" CssClass="btnBrown" Text="Arrangement  Detail" OnClick="btnArrange_Click" />
                                                    <asp:Button ID="btnLeaveDetail" runat="server" CssClass="btnBrown" Text="Previous Leave Detail" OnClick="btnLeaveDetail_Click" />
                                                    <asp:Button ID="btnDeptLeave" runat="server" CssClass="btnBrown" Text="Department Leave" OnClick="btnDeptLeave_Click" /></td>
                                            </tr>
                                            <tr>
                                                <td id="tdss" runat="server">&nbsp;
                            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" DropShadow="false"
                                PopupControlID="Panel1" TargetControlID="tdss">
                            </ajaxToolkit:ModalPopupExtender>
                                                </td>
                                            </tr>
                                            <tr id="trArrange" runat="server" visible="false">
                                                <td>
                                                    <asp:GridView ID="gvArrange" runat="server" AutoGenerateColumns="False" EmptyDataText="Duty not arranged"
                                                        CssClass="gridDynamic" OnRowCommand="gvArrange_RowCommand" DataKeyNames="LV_ARR_ID">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S.No.">
                                                                <ItemTemplate>
                                                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                .
                                                                </ItemTemplate>
                                                                <ItemStyle Width="15px" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="EMP_NAME" HeaderText="Arrange With" />
                                                            <%--<asp:BoundField DataField="ARR_FOR_DT" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Arrange Date" />--%>
                                                            <asp:BoundField DataField="ARR_REMARK" HeaderText="Descreption" />
                                                            <asp:TemplateField HeaderText="Detail" ShowHeader="False">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="imgStatus" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>'
                                                                        ImageUrl="~/Siteimages/edit.gif" CommandName="TT" ToolTip="Time table detail" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            
                                            <tr id="trPrvLv" runat="server" visible="false">
                                                <td>
                                                    <asp:GridView ID="gvPrvLv" runat="server" AutoGenerateColumns="False"
                                                        EmptyDataText="No record found" CssClass="gridDynamic">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S.No.">
                                                                <ItemTemplate>
                                                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                .
                                                                </ItemTemplate>
                                                                <ItemStyle Width="15px" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="LV_VALUE" HeaderText="Leave Type" />
                                                            <asp:BoundField DataField="IN_DT" DataFormatString="{0:dd/MM/yyy}" HeaderText="Request Date"
                                                                HtmlEncode="False" />
                                                            <asp:BoundField DataField="FROM_DT" DataFormatString="{0:dd/MM/yyy}" HeaderText="From Date"
                                                                HtmlEncode="False" />
                                                            <asp:BoundField DataField="TO_DT" DataFormatString="{0:dd/MM/yyyy}" HeaderText="To Date"
                                                                HtmlEncode="False" />
                                                            <asp:BoundField DataField="TOT_DAYS" HeaderText="No of Days" HtmlEncode="False">
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="REASON" HeaderText="Reason" />
                                                            <asp:BoundField DataField="IN_BY" HeaderText="Action By" />
                                                            <asp:BoundField HeaderText="Action Remark" DataField="REMARK" />
                                                            <asp:BoundField DataField="STS_VALUE" HeaderText="Status" />
                                                            <asp:BoundField HeaderText="Pending With" />
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr id="trDeptLv" runat="server" visible="false">
                                                <td>
                                                    <asp:GridView ID="gvDeptLv" runat="server" CssClass="gridDynamic" EmptyDataText="No Record found">
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblApproved" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Panel Style="display: none; width: 50%" ID="Panel1" runat="server">
                                            <asp:Panel Style="border-right: gray 1px solid; border-top: gray 1px solid; border-left: gray 1px solid; cursor: move; color: black; border-bottom: gray 1px solid; background-color: #dddddd"
                                                ID="Panel3" runat="server">
                                                <table style="width: 100%">
                                                    <tr>
                                                        <td style="font-size: 14px; font-weight: bold">Class Detail
                                                        </td>
                                                        <td style="text-align: right">
                                                            <asp:ImageButton ID="CancelButton" runat="server" ImageUrl="~/Siteimages/cancel_icon.gif" /></td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:GridView ID="gvDetail" runat="server" ShowFooter="True" Width="100%" AutoGenerateColumns="False"
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
                                        </asp:Panel>

                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

