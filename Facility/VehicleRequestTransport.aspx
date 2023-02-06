<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="VehicleRequestTransport.aspx.cs" Inherits="Facility_VehicleRequestTransport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="heading">
            <h2>Vehicle Assignment</h2>
        </div>
        <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <th>Approved Vehicle Requisition Detail</th>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:GridView ID="gvVehReqDetail" runat="server" CssClass="gridDynamic" AutoGenerateColumns="false" DataKeyNames="VR_REQ_ID" OnRowCommand="gvVehReqDetail_RowCommand">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S.No.">
                                                        <ItemTemplate>
                                                            <%# ((GridViewRow)Container).RowIndex + 1%>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="20px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField HeaderText="Employee" DataField="EMP_NAME" />
                                                    <asp:BoundField HeaderText="Contact No" DataField="VR_CONTACT_NO" />
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
                            </td>
                        </tr>

                        <tr id="trReturn" runat="server">
                            <td>
                                <table>
                                    <tr>
                                        <th>Return Journey</th>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:GridView ID="gvRetJourney" runat="server" CssClass="gridDynamic" AutoGenerateColumns="false" EmptyDataText="No Record(s) Found For Return Journey" DataKeyNames="VR_REQ_ID">
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
                            </td>


                        </tr>

                        <tr>
                            <th>Vehicle And Driver Assign</th>
                        </tr>
                        <tr>
                            <td>
                                <table style="vertical-align: top;">
                                    <tr>
                                        <td>
                                            <asp:GridView ID="gvVehicle" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" DataKeyNames="VEH_ID">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S.No.">
                                                        <ItemTemplate>
                                                            <%# ((GridViewRow)Container).RowIndex + 1%>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="20px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField HeaderText="Registration No" DataField="VEH_REG_NO" />
                                                    <asp:BoundField HeaderText="Vehicle Type" DataField="VEH_TYPE" />
                                                    <asp:BoundField HeaderText="Vehicle Category" DataField="VEH_CAT" />
                                                    <asp:BoundField HeaderText="Seats" DataField="VEH_SEAT_CAPICITY" />
                                                    <asp:TemplateField HeaderText="Select">

                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkVehAssign" runat="server" Checked="false" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                        <td>
                                            <asp:GridView ID="gvDriver" runat="server" AutoGenerateColumns="false" DataKeyNames="DRIVER_ID" CssClass="gridDynamic">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S.No">
                                                        <ItemTemplate>
                                                            <%#((GridViewRow)Container).RowIndex + 1 %>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="20px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField HeaderText="Employee Name" DataField="EMP_NAME" />
                                                    <asp:BoundField HeaderText="Driver Phone" DataField="DRIVER_PHONE" />
                                                    <asp:TemplateField HeaderText="Select">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkDriverAssign" runat="server" Checked="false" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>

                                    </tr>
                                    <tr>
                                        <th>Remark(If Any):-
                                            <asp:TextBox ID="txtRemark" runat="server" Width="361px"></asp:TextBox></th>

                                        <td>
                                            <asp:Button ID="btnAssign" runat="server" Text="Assign" OnClick="btnAssign_Click" />
                                            <iframe id="ifram" runat="server" border="0" frameborder="0" height="100" scrolling="yes"
                                                style="padding-right: 0px; padding-left: 0px; padding-bottom: 0px; padding-top: 0px; height: 1px; background-color: transparent"></iframe>
                                        </td>
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

