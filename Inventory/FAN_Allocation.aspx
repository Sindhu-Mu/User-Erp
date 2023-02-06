<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="FAN_Allocation.aspx.cs" Inherits="Inventory_FAN_Allocation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="heading">
            <h2>FAN Allocation</h2>
        </div>
        <div>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <ajaxToolkit:TabContainer ID="step1" runat="server" ActiveTabIndex="1" AutoPostBack="true" OnActiveTabChanged="step1_ActiveTabChanged">
                        <ajaxToolkit:TabPanel runat="server" ID="TabPanel1">
                            <HeaderTemplate>
                                FAN Allocation
                            </HeaderTemplate>
                            <ContentTemplate>
                                <asp:UpdatePanel ID="up1" runat="server">
                                    <ContentTemplate>
                                        <table>
                                            <tr>
                                                <td style="width: 20%; vertical-align: top">
                                                    <fieldset style="border-collapse: collapse; border-spacing: 0px; margin: 0px; padding: 0px; border: none">
                                                        <legend>Purchase Requisition</legend>
                                                        <div style="height: 600px; width: 100%; overflow: auto">
                                                            <asp:GridView ID="gv_requisition" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" DataKeyNames="PUR_REQ_ID" EmptyDataText="No Record Found" OnRowCommand="gv_requisition_RowCommand" OnSelectedIndexChanged="gv_requisition_SelectedIndexChanged">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="S.No.">
                                                                        <ItemTemplate>
                                                                            <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Width="20px" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="PUR_REQ_NO" HeaderText="Requisition Number" ItemStyle-Width="40px" />
                                                                    <asp:BoundField DataField="DEPT_VALUE" HeaderText="Department" ItemStyle-Width="40px" />
                                                                    <asp:BoundField DataField="AMOUNT" HeaderText="Total Amount" ItemStyle-Width="40px" />
                                                                    <asp:BoundField DataField="REQ_ON_DT" HeaderText="Insert Date" ItemStyle-Width="40px" />
                                                                    <asp:BoundField DataField="EMP_NAME" HeaderText="Insert By" ItemStyle-Width="40px" />
                                                                    <%--<asp:BoundField DataField="REQ_REMARK" HeaderText="Remark" ItemStyle-Width="40px" />--%>
                                                                    <asp:CommandField ButtonType="Button" ControlStyle-Font-Size="Smaller" HeaderText="ALLOT" SelectText="ALLOT" ShowSelectButton="True">
                                                                        <ItemStyle Width="30px" />
                                                                    </asp:CommandField>
                                                                    <asp:ButtonField ButtonType="Image" CommandName="Print" HeaderText="PRINT" ImageUrl="~/Siteimages/print.gif" Text="PRINT" />
                                                                </Columns>
                                                            </asp:GridView>

                                                        </div>

                                                    </fieldset>
                                                </td>
                                                <td style="width: 1px; height: 100%; border-left: 1px solid red; margin-left: 2px"></td>
                                                <td style="vertical-align: top">
                                                    <table style="width: 400px; border-collapse: collapse; border-spacing: 0px; text-align: center">
                                                        <tr id="trItemDetails" runat="server" visible="true">
                                                            <td style="text-align: left; width: 40%">
                                                                <table style="width: 100%">
                                                                    <tr>
                                                                        <td>
                                                                            <details open="open">
                                                                                <summary style="text-align: left">Item Details</summary>
                                                                            </details>
                                                                            <asp:GridView ID="gv_ItemDetails" EmptyDataText="No Record Found" runat="server" AutoGenerateColumns="False" DataKeyNames="REQ_SUB_ID" OnRowCancelingEdit="gv_ItemDetails_RowCancelingEdit" OnRowEditing="gv_ItemDetails_RowEditing" OnRowUpdating="gv_ItemDetails_RowUpdating" OnRowCommand="gv_ItemDetails_RowCommand" CssClass="gridDynamic">
                                                                                <Columns>
                                                                                    <asp:TemplateField HeaderText="S.No.">
                                                                                        <ItemTemplate>
                                                                                            <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle Width="20px" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:BoundField HeaderText="Item Name" DataField="ITEM_NAME" ReadOnly="true" />
                                                                                    <asp:BoundField HeaderText="Quantity" DataField="REQ_ITEM_QTY" ReadOnly="false" />
                                                                                    <asp:BoundField HeaderText="Unit" DataField="UNIT_NAME" ReadOnly="true" />
                                                                                    <asp:BoundField HeaderText="Rate" DataField="REQ_ITEM_RATE" ReadOnly="false" />
                                                                                    <asp:BoundField HeaderText="Amount" DataField="AMOUNT" ReadOnly="true" />
                                                                                    <asp:CommandField HeaderText="Edit" ShowEditButton="true" />
                                                                                </Columns>
                                                                            </asp:GridView>
                                                                        </td>

                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <hr style="color: #ff8c00; width: 100%; height: 0px; border-bottom-color: red; border-bottom-width: 1px; border-collapse: collapse; border-spacing: 0px;" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr id="trFAN_Details" runat="server" visible="true">
                                                                        <td style="text-align: left">
                                                                            <details open="open">
                                                                                <summary style="text-align: left">FAN Details</summary>
                                                                            </details>
                                                                            <asp:GridView ID="gv_FanDetails" EmptyDataText="No Record Found" runat="server" AutoGenerateColumns="False" CssClass="gridDynamic">
                                                                                <Columns>
                                                                                    <asp:TemplateField HeaderText="S.No.">
                                                                                        <ItemTemplate>
                                                                                            <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle Width="20px" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:BoundField HeaderText="FAN No." DataField="FAN_NO" ReadOnly="true" />
                                                                                    <asp:BoundField HeaderText="Assign Date" DataField="FAN_ASSIGN_DT" ReadOnly="false" />
                                                                                    <asp:BoundField HeaderText="Pur Req. No." DataField="PUR_REQ_NO" ReadOnly="true" />
                                                                                    <asp:BoundField HeaderText="Asign By" DataField="EMP_NAME" ReadOnly="true" />
                                                                                    <asp:BoundField HeaderText="Amount" DataField="FAN_AMOUNT" ReadOnly="true" />
                                                                                </Columns>
                                                                            </asp:GridView>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <table>
                                                                                <tr id="trtext" runat="server" visible="false">
                                                                                    <td>
                                                                                        <table>
                                                                                            <tr>
                                                                                                <th>FAN No.<span class="required">*</span>
                                                                                                </th>
                                                                                                <th>FAN Amount<span class="required">*</span>
                                                                                                </th>
                                                                                                <th>FAN Remark<span class="required">*</span>
                                                                                                </th>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <asp:TextBox ID="txtFAN_No" runat="server" Width="100px"></asp:TextBox>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:TextBox ID="txtFAN_Amt" runat="server" Width="100px"></asp:TextBox>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:TextBox ID="txtFAN_Rmrk" runat="server" Width="100px"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <table>
                                                                                            <tr>


                                                                                                <td>
                                                                                                    <asp:Button ID="btnAllot" runat="server" Text="ALLOT" Visible="false" OnClick="btnAllot_Click" />
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:Button ID="btnReject" runat="server" Text="REJECT" Visible="false" OnClick="btnReject_Click" />
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:Button ID="btnCancel" runat="server" Text="CANCEL" Visible="false" OnClick="btnCancel_Click" />
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </ContentTemplate>
                        </ajaxToolkit:TabPanel>
                        <ajaxToolkit:TabPanel ID="TabPanel2" runat="server">
                            <HeaderTemplate>
                                Alloted Report
                            </HeaderTemplate>
                            <ContentTemplate>
                                <asp:UpdatePanel ID="up2" runat="server">
                                    <ContentTemplate>
                                        <table>
                                            <tr>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <th>FAN No.
                                                            </th>
                                                            <th>Department
                                                            </th>
                                                            <th>Pur.Req.No.
                                                            </th>
                                                            <th>Assign
                                                            </th>
                                                            <th>Status
                                                            </th>
                                                            <th>Date
                                                            </th>
                                                            <th>Sort
                                                            </th>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:DropDownList ID="ddl_FanId" runat="server" OnSelectedIndexChanged="ddl_FanId_SelectedIndexChanged" AutoPostBack="true" Width="100px"></asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddl_Dept" runat="server" OnSelectedIndexChanged="ddl_Dept_SelectedIndexChanged" AutoPostBack="true" Width="100px"></asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddl_PurReqId" runat="server" OnSelectedIndexChanged="ddl_PurReqId_SelectedIndexChanged" AutoPostBack="true" Width="100px"></asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddl_Assign" runat="server" OnSelectedIndexChanged="ddl_Assign_SelectedIndexChanged" AutoPostBack="true" Width="100px"></asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddl_Status" runat="server" OnSelectedIndexChanged="ddl_Status_SelectedIndexChanged" AutoPostBack="true" Width="100px"></asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtDate" runat="server">
                                                                                        
                                                                </asp:TextBox>
                                                                <ajaxToolkit:CalendarExtender runat="server" ID="calendar" TargetControlID="txtDate"></ajaxToolkit:CalendarExtender>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddl_Sort" runat="server">
                                                                    <asp:ListItem>All</asp:ListItem>
                                                                    <asp:ListItem Value="FAN_ID">FAN ID</asp:ListItem>
                                                                    <asp:ListItem Value="PUR_REQ_DEPT">DEPARTMENT</asp:ListItem>
                                                                    <asp:ListItem Value="FAN_PUR_ID">PUR.ID</asp:ListItem>
                                                                    <asp:ListItem Value="FAN_ASSIGN_BY">ASSIGN BY</asp:ListItem>
                                                                    <asp:ListItem Value="FAN_ASSIGN_DATE">DATE</asp:ListItem>
                                                                    <asp:ListItem Value="FAN_STATUS">STATUS</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="btnView" runat="server" Text="View" OnClick="btnView_Click" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <tr>
                                                        <td>
                                                            <asp:GridView ID="gvFanReport" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                                ShowFooter="True" ShowHeader="true" Width="80%" EmptyDataText="No Record Found" CssClass="gridDynamic">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="S.No.">
                                                                        <ItemTemplate>
                                                                            <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Width="20px" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="FAN_ID" HeaderText="FAN ID" />
                                                                    <asp:BoundField DataField="DEPT_VALUE" HeaderText="DEPARTMENT" />
                                                                    <asp:BoundField DataField="PUR_REQ_NO" HeaderText="PUR.ID" />
                                                                    <asp:BoundField DataField="EMP_NAME" HeaderText="ASSIGN BY" />
                                                                    <asp:BoundField DataField="FAN_ASSIGN_DT" HeaderText="FAN DATE" />
                                                                    <asp:BoundField DataField="FAN_AMOUNT" HeaderText="AMOUNT" />

                                                                </Columns>
                                                                <HeaderStyle ForeColor="Crimson" />
                                                                <SelectedRowStyle BackColor="#FFC0C0" />
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </ContentTemplate>
                        </ajaxToolkit:TabPanel>
                    </ajaxToolkit:TabContainer>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

