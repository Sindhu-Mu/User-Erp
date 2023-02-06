<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="EmpLvDetail.aspx.cs" Inherits="HR_EmpLvDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="heading">
            <h2>Leave Register</h2>
        </div>
        <div>
            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <th>By Year
                                        </th>
                                        <th>By Leave
                                        </th>
                                        <th>By Status
                                        </th>
                                        <th>By Date
                                        </th>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="ddlYear" runat="server"></asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlLv" runat="server"></asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlStatus" runat="server" Width="100px">
                                                <asp:ListItem Value=".">All</asp:ListItem>
                                                <asp:ListItem Value="-2">Apply</asp:ListItem>
                                                <asp:ListItem Value="-1">Arrangement Accept</asp:ListItem>
                                                <asp:ListItem Value="1">Recommanded</asp:ListItem>
                                                <asp:ListItem Value="2">Approved</asp:ListItem>
                                                <asp:ListItem Value="0">Reject</asp:ListItem>
                                                <asp:ListItem Value="3">Cancel Apply</asp:ListItem>
                                                <asp:ListItem Value="4">Cancel Approved</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlDate" runat="server" Width="80px" AutoPostBack="true" OnSelectedIndexChanged="DateType_Change">
                                                <asp:ListItem Value="0" Text="All"></asp:ListItem>
                                                <asp:ListItem Value="1" Text="Less Than"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="Greater Than"></asp:ListItem>
                                                <asp:ListItem Value="3" Text="Between"></asp:ListItem>
                                            </asp:DropDownList></td>
                                        <td>
                                            <asp:TextBox ID="txtSD" runat="server" Width="95px"></asp:TextBox>&nbsp;
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtSD" Format="dd/MM/yyyy">
                                    </ajaxToolkit:CalendarExtender>
                                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="99/99/9999" MaskType="Date"
                                                TargetControlID="txtSD">
                                            </ajaxToolkit:MaskedEditExtender>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtED" runat="server" Width="90px"></asp:TextBox>&nbsp;
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtED" Format="dd/MM/yyyy">
                                    </ajaxToolkit:CalendarExtender>
                                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" Mask="99/99/9999" MaskType="Date"
                                                TargetControlID="txtED">
                                            </ajaxToolkit:MaskedEditExtender>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnView" runat="server" OnClick="btnView_Click" Text="Show" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="gvLvBlnc" runat="server" AutoGenerateColumns="False" EmptyDataText="No record found" CssClass="gridDynamic">
                                    <Columns>
                                        <asp:TemplateField HeaderText="S.No.">
                                            <ItemTemplate>
                                                <%# ((GridViewRow)Container).RowIndex + 1%>.
                                            </ItemTemplate>
                                            <ItemStyle Width="15px" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="LV_VALUE" HeaderText="Type" ReadOnly="True" />
                                        <asp:BoundField DataField="OPENING_BAL" HeaderText="Opening Balance" HtmlEncode="False"
                                            ReadOnly="True">
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CREDIT_BAL" HeaderText="Credit Balance" HtmlEncode="False">
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="LAPSED_BAL" HeaderText="Lapsed" />
                                        <asp:BoundField DataField="CURRENT_BAL" HeaderText="Current. Balance" HtmlEncode="False">
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="AVAILED_BAL" HeaderText="Availed" HtmlEncode="False" ReadOnly="True">
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="APPLIED_BAL" HeaderText="Applied" HtmlEncode="False">
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <div style="width: auto">
                                    <asp:GridView ID="gvAvailed" runat="server" AutoGenerateColumns="False" EmptyDataText="No record found" CssClass="gridDynamic" OnRowCommand="gvAvailed_RowCommand" DataKeyNames="LV_APP_ID">
                                        <Columns>
                                            <asp:TemplateField HeaderText="S.No.">
                                                <ItemTemplate>
                                                    <%# ((GridViewRow)Container).RowIndex + 1%>.
                                                </ItemTemplate>
                                                <ItemStyle Width="15px" />
                                            </asp:TemplateField>
                                            <asp:ButtonField CommandName="Show" DataTextField="LV_VALUE" HeaderText="Leave Type"
                                                Text="Button" />
                                            <asp:BoundField DataField="REQ_DT" DataFormatString="{0:dd/MM/yyy}" HeaderText="Request Date"
                                                HtmlEncode="False" />
                                            <asp:BoundField DataField="FROM_DT" DataFormatString="{0:dd/MM/yyy}" HeaderText="From Date"
                                                HtmlEncode="False" />
                                            <asp:BoundField DataField="TO_DT" DataFormatString="{0:dd/MM/yyyy}" HeaderText="To Date"
                                                HtmlEncode="False" />
                                            <asp:BoundField DataField="TOT_DAYS" HeaderText="No of Days" HtmlEncode="False">
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="REASON" HeaderText="Reason" />
                                            <asp:BoundField DataField="STS_VALUE" HeaderText="Action" />
                                            <asp:BoundField HeaderText="Action By" DataField="ACT_BY" />
                                            <asp:BoundField HeaderText="Pending With" DataField="PENDING_WITH" />
                                            <asp:CommandField ButtonType="Button" SelectText="DETAILS" ShowSelectButton="True" />
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>

                        <tr id="trTransaction" runat="server">
                            <td>
                                <div style="width: auto">
                                    <asp:GridView ID="gvTransaction" Caption="Transaction Details" runat="server" AutoGenerateColumns="False" CssClass="gridDynamic">
                                        <Columns>
                                            <asp:TemplateField HeaderText="S.No.">
                                                <ItemTemplate>
                                                    <%# ((GridViewRow)Container).RowIndex + 1%>.
                                                </ItemTemplate>
                                                <ItemStyle Width="15px" />
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="Transaction By" DataField="EMP_NAME" />
                                            <asp:BoundField DataField="REMARK" HeaderText="Remark" />
                                            <asp:BoundField DataField="IN_DT" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Transaction Date"
                                                HtmlEncode="False" />
                                            <asp:BoundField DataField="STS_VALUE" HeaderText="Transaction Status" />
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td id="tdss" runat="server">
                                <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" DropShadow="false"
                                    PopupControlID="Panel1" TargetControlID="tdss">
                                </ajaxToolkit:ModalPopupExtender>
                            </td>
                        </tr>
                        <tr id="trArrange" runat="server" visible="false">
                            <td>
                                <asp:GridView ID="gvArrange" runat="server" Caption="Arrangement Detail" AutoGenerateColumns="False" EmptyDataText="Duty not arranged"
                                    CssClass="gridDynamic" OnRowCommand="gvArrange_RowCommand" DataKeyNames="LV_ARR_ID">
                                    <Columns>
                                        <asp:TemplateField HeaderText="S.No.">
                                            <ItemTemplate>
                                                <%# ((GridViewRow)Container).RowIndex + 1%>.
                                                                .
                                            </ItemTemplate>
                                            <ItemStyle Width="15px" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="EMP_NAME" HeaderText="Arrange With" />
                                        <%--<asp:BoundField DataField="ARR_FOR_DT" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Arrange Date" />--%>
                                        <asp:BoundField DataField="ARR_REMARK" HeaderText="Description" />
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
    </div>
</asp:Content>

