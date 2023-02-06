<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="VehicleReqRequestApproval.aspx.cs" Inherits="Facility_VehicleRequestApproval" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <div class="heading">
            <h2>Requisition Approval</h2>
        </div>
        <table>
            <tr>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <table>
                                <tr>
                                    <th>
                                        Applied Vehicle Requisition 
                                    </th>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:GridView ID="gvAppVehReq" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" DataKeyNames="VR_REQ_ID" OnRowCommand="gvAppVehReq_RowCommand" EmptyDataText="No Record(s) Found">
                                            <Columns>
                                                <asp:TemplateField HeaderText="S.No.">
                                                            <ItemTemplate>
                                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                                            </ItemTemplate>
                                                            <ItemStyle Width="20px" />
                                                        </asp:TemplateField>
                                                <asp:BoundField HeaderText="Employee" DataField="EMP_NAME" />
                                                <asp:BoundField HeaderText="Journey Type" DataField="VRD_JRNY_TYPE" />
                                                <asp:BoundField HeaderText="Date" DataField="VRD_JRNY_DT" />
                                                <asp:BoundField HeaderText="Pick Up Location" DataField="VR_PICK_UP_LOC" />
                                                <asp:BoundField HeaderText="Destination Address" DataField="VR_DESTI_ADD" />
                                                <asp:BoundField HeaderText="Pick Up Time" DataField="VRD_JRNY_TIME" />
                                                <asp:BoundField HeaderText="No Of Persons" DataField="VR_NOP" />
                                                <asp:BoundField HeaderText="Request Type" DataField="VR_REQ_TYPE" />
                                                <asp:CommandField SelectText="Detail" ShowSelectButton="True" ButtonType="Button" HeaderText="ACTION"></asp:CommandField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                            <table>
                                <tr>
                                    <th>
                                        Return Journey
                                    </th>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:GridView ID="gvRetJou" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" EmptyDataText="No Record(s) Found For Return Journey" DataKeyNames="VR_REQ_ID">
                                            <Columns>
                                                <asp:TemplateField HeaderText="S.No.">
                                                            <ItemTemplate>
                                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                                            </ItemTemplate>
                                                            <ItemStyle Width="20px" />
                                                        </asp:TemplateField>
                                                <asp:BoundField HeaderText="Pick Up Location" DataField="VR_PICKUP_LOCATION" />
                                                <asp:BoundField HeaderText="Return Date" DataField="VRJ_DATE" />
                                                <asp:BoundField HeaderText="Return Time" DataField="VRJ_TIME" />
                                                <asp:BoundField HeaderText="No Of Persons" DataField="VRJ_NOP" />
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                            <table>
                                <tr>
                                    <th>Remark(if any)</th>
                                    <td><asp:TextBox ID="txtRemark" runat="server"></asp:TextBox></td>
                                </tr>
                                </table>
                            <table>
                                <tr>
                                    <td><asp:Button ID="btnRecommend" runat="server" Text="Recommend" OnClick="btnRecommend_Click" Visible="false"/></td>
                                    <td><asp:Button ID="btnApprove" runat="server" Text="Approve" OnClick="btnApprove_Click" Visible="false" /></td>
                                    <td><asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="Cancel_Click" Visible="false" /></td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

