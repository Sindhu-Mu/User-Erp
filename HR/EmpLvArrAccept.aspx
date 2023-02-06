<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="EmpLvArrAccept.aspx.cs" Inherits="HR_EmpLvArrAccept" %>

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
            if (!CheckControl("<%=txtRemark.ClientID%>")) {
                msg += "- Enter Remark. \n";
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
            <h2>Leave Arrangement</h2>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnApp" runat="server" Text="Arrangement Application" OnClick="btnApp_Click" Width="250PX" /></td>
                                    <td>
                                        <asp:Button ID="btnReport" runat="server" Text="Arrangement Report" OnClick="btnReport_Click" Width="250PX" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td id="td1" runat="server" visible="false">
                            <table>
                                <tr>
                                    <td>BY YEAR</td>
                                    <td>BY NAME</td>
                                    <td>BY DEPARTMENT</td>
                                    <td>BY DATE</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:DropDownList ID="ddlYear" runat="server" Width="120px">
                                        </asp:DropDownList></td>
                                    <td>
                                        <asp:DropDownList ID="ddlName" runat="server" AutoPostBack="True" Width="120px">
                                        </asp:DropDownList></td>
                                    <td>
                                        <asp:DropDownList ID="ddlDept" runat="server" Width="120px">
                                        </asp:DropDownList></td>
                                    <td>
                                        <asp:TextBox ID="txtFromDT" runat="server"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender3" Format="dd/MM/yyyy" runat="server" TargetControlID="txtFromDT" Enabled="True"></ajaxToolkit:CalendarExtender>
                                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender5" runat="server" Mask="99/99/9999" MaskType="Date"
                                            TargetControlID="txtFromDT">
                                        </ajaxToolkit:MaskedEditExtender>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtToDT" runat="server"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="txtToDT" Enabled="True"></ajaxToolkit:CalendarExtender>
                                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="99/99/9999" MaskType="Date"
                                            TargetControlID="txtToDT">
                                        </ajaxToolkit:MaskedEditExtender>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnView" runat="server"
                                            Text="View" OnClick="btnReport_Click" /></td>

                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td id="tdss" runat="server">&nbsp;
                            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" DropShadow="false"
                                PopupControlID="Panel1" TargetControlID="tdss">
                            </ajaxToolkit:ModalPopupExtender>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="gvShow" runat="server" AutoGenerateColumns="False"
                                DataKeyNames="LV_APP_ID,LV_ARR_ID" EmptyDataText="No Recoud Foud" OnRowCommand="gvShow_RowCommand" CssClass="gridDynamic">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No.">
                                        <ItemTemplate><%#((GridViewRow)Container).RowIndex+1 %></ItemTemplate>
                                        <ItemStyle Width="15px" />
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="ALL">
                                        <HeaderTemplate>
                                            <input id="chkAll" onclick="javascript: SelectAllCheckboxes(this);" type="checkbox"
                                                value="on" runat="server" style="border-right: 2px groove; border-top: 2px groove; border-left: 2px groove; border-bottom: 2px groove" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chk1" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:BoundField DataField="EMP_NAME" HeaderText="NAME"></asp:BoundField>
                                    <asp:BoundField DataField="DEPT_VALUE" HeaderText="DEPARTMENT"></asp:BoundField>
                                    <asp:BoundField DataField="DES_VALUE" HeaderText="DESIGANTION"></asp:BoundField>
                                    <asp:BoundField DataField="IN_DT" HeaderText="APPLYED DATE" DataFormatString="{0:dd/MM/yyyy}"></asp:BoundField>
                                    <asp:BoundField DataField="FROM_DT" HeaderText="FROM DATE" DataFormatString="{0:dd/MM/yyyy}"></asp:BoundField>
                                    <asp:BoundField DataField="TO_DT" HeaderText="TO DATE" DataFormatString="{0:dd/MM/yyyy}"></asp:BoundField>
                                    <asp:BoundField DataField="ARR_REMARK" HeaderText="DUTY DETAIL"></asp:BoundField>
                                    <asp:TemplateField HeaderText="Detail" ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgStatus" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>'
                                                ImageUrl="~/Siteimages/edit.gif" CommandName="TT" ToolTip="Time table detail" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:CommandField ButtonType="Button" SelectText="Action" ShowSelectButton="True"></asp:CommandField>

                                </Columns>
                                <SelectedRowStyle BackColor="#FFFF99" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td id="tdSave" runat="server" visible="false">
                            <table>
                                <tr>
                                    <td>Status</td>
                                    <td>Remark<span style="color: red">*</span></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:DropDownList ID="ddlAction" runat="server">
                                            <asp:ListItem Value="-1">Accept</asp:ListItem>
                                            <asp:ListItem Value="0">Reject</asp:ListItem>
                                        </asp:DropDownList></td>
                                    <td>
                                        <asp:TextBox ID="txtRemark" runat="server" CssClass="textbox" Width="300px"></asp:TextBox></td>
                                    <td>
                                        <asp:Button ID="btnSave" runat="server"
                                            Text="Save" OnClick="btnSave_Click"></asp:Button></td>
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
    </div>

</asp:Content>

