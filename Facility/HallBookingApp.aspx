<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="HallBookingApp.aspx.cs" Inherits="Facility_HallBookingApp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="heading">
            <h2>Hall Requisition Approval</h2>
        </div>
        <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <th>By Complex</th>
                                        <th colspan="3">By Booking Date</th>
                                        <th>By Event</th>
                                        <th>By Status</th>
                                        <th>By Department Employees</th>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="ddlComlx" runat="server"></asp:DropDownList></td>
                                        <td>
                                            <asp:DropDownList ID="ddlDate" runat="server" OnSelectedIndexChanged="DateType_Change" AutoPostBack="True">
                                                <asp:ListItem Value="0" Text="All"></asp:ListItem>
                                                <asp:ListItem Value="1" Text="Less Than"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="Greater Than"></asp:ListItem>
                                                <asp:ListItem Value="3" Text="Between"></asp:ListItem>
                                            </asp:DropDownList></td>
                                        <td>
                                            <asp:TextBox ID="txtFrmDt" runat="server" Visible="false"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtToDt" runat="server" Visible="false"></asp:TextBox></td>
                                        <td>
                                            <asp:DropDownList ID="ddlEvt" runat="server"></asp:DropDownList></td>
                                        <td>
                                            <asp:DropDownList ID="ddlSts" runat="server"></asp:DropDownList></td>
                                        <td>
                                            <asp:DropDownList ID="ddlemp" runat="server"></asp:DropDownList></td>
                                        <td>
                                            <asp:Button ID="btnView" runat="server" Text="View" OnClick="btnView_Click" /></td>
                                    </tr>
                                    <tr>
                                        <td style="height: 20px">
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFrmDt"
                                                Format="dd/MM/yyyy">
                                            </ajaxToolkit:CalendarExtender>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtToDt"
                                                Format="dd/MM/yyyy">
                                            </ajaxToolkit:CalendarExtender>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <th>Applied Hall Request</th>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="gvAppliedHall" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" OnRowCommand="gvAppliedHall_RowCommand" DataKeyNames="HALL_REQ_ID,HALL_ID,USR_ID" EmptyDataText="No Request Found">
                                    <Columns>
                                        <asp:TemplateField HeaderText="S.No">
                                            <ItemTemplate>
                                                <%#((GridViewRow)Container).RowIndex +1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Complex Name" DataField="FAC_CMPLX_NAME" />
                                        <asp:BoundField HeaderText="Event Type" DataField="EVENT_INFO" />
                                        <asp:BoundField HeaderText="Request Date" DataField="HALL_TRAN_DATE" DataFormatString="{0:dd/MM/yyyy}" />
                                        <asp:BoundField HeaderText="Request By" DataField="EMP_NAME" />
                                        <asp:BoundField HeaderText="Booking On" DataField="BOOKING_ON" />
                                        <asp:CommandField SelectText="Detail" ShowSelectButton="True" ButtonType="Button" HeaderText="DETAIL"></asp:CommandField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <iframe id="ifrmDetail" runat="server" style="padding: 0; background-color: transparent; width: 800px;min-height:400px" scrolling="yes" frameborder="0"  ></iframe>
                            </td>
                        </tr>
                        <tr id="tblApprove" runat="server">
                            <td>
                                <table>
                                    <tr>
                                        <th>Remark(If Any)</th>
                                        <td>
                                            <asp:TextBox ID="txtReamrk" runat="server" Width="400px"></asp:TextBox>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:Button ID="btnRecommend" runat="server" Text="Recommend" Visible="false" OnClick="btnRecommend_Click" /></td>
                                        <td>
                                            <asp:Button ID="btnApprove" runat="server" Text="Approve" Visible="false" OnClick="btnApprove_Click" /></td>
                                        <td>
                                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" Visible="false" OnClick="btnCancel_Click" /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

