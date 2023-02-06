<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="rptHostelCounting.aspx.cs" Inherits="Facility_rptHostelCounting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <div class="heading">
<h2>Hostel Student Counting</h2>
        </div>
        <div>
            <table id="tblColumns">
                <tr>
                    <td>
                        <table>
                            <tr>
                                <th>Institution Wise</th>
                            </tr>
                            <tr>
                                <td style="vertical-align: top">
                                    <asp:UpdatePanel ID="UP1" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <div style="height: 250px; overflow: auto; width:auto">
                                                <asp:GridView ID="gvIns" runat="server" AutoGenerateColumns="False"
                                                     EmptyDataText="No Record Found." CssClass="gridDynamic">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="S.No">
                                                            <ItemTemplate>
                                                                <%#((GridViewRow)Container).RowIndex + 1 %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="INS_VALUE" HeaderText="Institute" />
                                                        <asp:BoundField DataField="Boys" HeaderText="Boys" />
                                                        <asp:BoundField DataField="Girls" HeaderText="Girls" />
                                                        <asp:BoundField DataField="TOT" HeaderText="Total" />
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="vertical-align: top" colspan ="1">
                        <table>
                            <tr>
                                <th>Course Wise</th>
                            </tr>
                            <tr>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <div style="height: 250px; overflow: auto; width:auto">
                                                <asp:GridView ID="gvCourse" runat="server" AutoGenerateColumns="False"
                                                   EmptyDataText="No Record Found." CssClass="gridDynamic" >
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="S.No">
                                                            <ItemTemplate>
                                                                <%#((GridViewRow)Container).RowIndex + 1 %>
                                                            </ItemTemplate>
                                                            </asp:TemplateField>
                                                        <asp:BoundField DataField="INS_VALUE" HeaderText="Institution" />
                                                        <asp:BoundField DataField="PGM_SHORT_NAME" HeaderText="Program" />
                                                        <asp:BoundField DataField="Boys" HeaderText="Boys" />
                                                         <asp:BoundField DataField="Girls" HeaderText="Girls" />
                                                         <asp:BoundField DataField="TOT" HeaderText="Total" />
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="vertical-align: top">
                        <table>
                            <tr>
                                <th>Batch Wise</th>
                            </tr>
                            <tr>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <div style="height: 250px; overflow: auto; width:auto">
                                                <asp:GridView ID="GvBatch" runat="server" AutoGenerateColumns="False"
                                                    EmptyDataText="No Record Found." CssClass="gridDynamic">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="S.No">
                                                            <ItemTemplate>
                                                                <%#((GridViewRow)Container).RowIndex + 1 %>
                                                            </ItemTemplate>
                                                            </asp:TemplateField>
                                                        <asp:BoundField DataField="ACA_BATCH_NAME" HeaderText="Batch" />
                                                        <asp:BoundField DataField="Boys" HeaderText="Boys" />
                                                        <asp:BoundField DataField="Girls" HeaderText="Girls" />
                                                        <asp:BoundField DataField="TOT" HeaderText="Total" />
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table>
                            <tr>
                                <th>Caste Wise</th>
                            </tr>
                            <tr>
                                    <td style="vertical-align: top">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <div style="height: 250px; overflow: auto; width:auto">
                                                <asp:GridView ID="gvCaste" runat="server" AutoGenerateColumns="False" EmptyDataText="No Record Found." CssClass="gridDynamic">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="S.No">
                                                            <ItemTemplate>
                                                                <%#((GridViewRow)Container).RowIndex + 1 %>
                                                            </ItemTemplate>
                                                            </asp:TemplateField>
                                                        <asp:BoundField DataField="CAS_VALUE" HeaderText="Caste"/>
                                                        <asp:BoundField DataField="Boys" HeaderText="Boys" />
                                                        <asp:BoundField DataField="Girls" HeaderText="Girls" />
                                                        <asp:BoundField DataField="TOT" HeaderText="Total" />
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="vertical-align: top">
                        <table>
                            <tr>
                                <th>Branch Wise</th>
                            </tr>
                            <tr>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <div style="height: 250px; overflow: auto; max-width: 500px">
                                                <asp:GridView ID="gvBranch" runat="server" AutoGenerateColumns="False"
                                                    EmptyDataText="No Record Found." CssClass="gridDynamic">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="S.No">
                                                            <ItemTemplate>
                                                                <%#((GridViewRow)Container).RowIndex + 1 %>
                                                            </ItemTemplate>
                                                            </asp:TemplateField>
                                                        <asp:BoundField DataField="PGM_SHORT_NAME" HeaderText="Program">
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="BRN_SHORT_NAME" HeaderText="Branch" />
                                                       <asp:BoundField DataField="Boys" HeaderText="Boys" />
                                                        <asp:BoundField DataField="Girls" HeaderText="Girls" />
                                                        <asp:BoundField DataField="TOT" HeaderText="Total" />
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="vertical-align: top">
                        <table>
                            <tr>
                                <th>Floor Wise</th>
                            </tr>
                            <tr>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <div style="height: 250px; overflow: auto; max-width: 500px">
                                                <asp:GridView ID="gvFloor" runat="server" AutoGenerateColumns="False"
                                                    EmptyDataText="No Record Found." CssClass="gridDynamic">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="S.No">
                                                            <ItemTemplate>
                                                                <%#((GridViewRow)Container).RowIndex + 1 %>
                                                            </ItemTemplate>
                                                            </asp:TemplateField>
                                                        <asp:BoundField DataField="ROOM_FLOOR" HeaderText="Gender">
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Boys" HeaderText="Boys" />
                                                        <asp:BoundField DataField="Girls" HeaderText="Girls" />
                                                        <asp:BoundField DataField="TOT" HeaderText="Total" />
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                    <table>
                        <tr>
                            <th>Semester Wise</th>
                        </tr>
                        <tr>
                            <td style="vertical-align: top">
                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <div style="height: 250px; overflow: auto; width:auto">
                                                <asp:GridView ID="gvSem" runat="server" AutoGenerateColumns="False" EmptyDataText="No Record Found." CssClass="gridDynamic">
                                                   <Columns>
                                                        <asp:TemplateField HeaderText="S.No">
                                                            <ItemTemplate>
                                                                <%#((GridViewRow)Container).RowIndex + 1 %>
                                                            </ItemTemplate>
                                                            </asp:TemplateField>
                                                        <asp:BoundField DataField="ACA_SEM_NO" HeaderText="Semester">
                                                        </asp:BoundField>
                                                         <asp:BoundField DataField="Boys" HeaderText="Boys" />
                                                        <asp:BoundField DataField="Girls" HeaderText="Girls" />
                                                        <asp:BoundField DataField="TOT" HeaderText="Total" />
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                        </tr>
                    </table>
                </td>
                    <td style="vertical-align: top">
                        <table>
                            <tr>
                                <th>Branch Semester Wise</th>
                            </tr>
                            <tr>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <div style="height: 250px; overflow: auto; width:auto">
                                                <asp:GridView ID="gvBrnSem" runat="server" AutoGenerateColumns="False"
                                                  EmptyDataText="No Record Found." CssClass="gridDynamic">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="S.No">
                                                            <ItemTemplate>
                                                                <%#((GridViewRow)Container).RowIndex + 1 %>
                                                            </ItemTemplate>
                                                            </asp:TemplateField>
                                                        <asp:BoundField DataField="PGM_SHORT_NAME" HeaderText="Program">
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="BRN_SHORT_NAME" HeaderText="Branch" />
                                                        <asp:BoundField DataField="ACA_SEM_NO" HeaderText="Sem" />
                                                         <asp:BoundField DataField="Boys" HeaderText="Boys" />
                                                        <asp:BoundField DataField="Girls" HeaderText="Girls" />
                                                        <asp:BoundField DataField="TOT" HeaderText="Total" />
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="vertical-align: top" colspan="2">
                        <table>
                            <tr>
                                <th>Religion Wise</th>
                            </tr>
                            <tr>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel8" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <div style="height: 250px; overflow: auto; width: 100%">
                                                <asp:GridView ID="gvRel" runat="server" AutoGenerateColumns="False"
                                                  EmptyDataText="No Record Found." CssClass="gridDynamic">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="S.No">
                                                            <ItemTemplate>
                                                                <%#((GridViewRow)Container).RowIndex + 1 %>
                                                            </ItemTemplate>
                                                            </asp:TemplateField>
                                                        <asp:BoundField DataField="REL_VALUE" HeaderText="Religion">
                                                        </asp:BoundField>
                                                         <asp:BoundField DataField="Boys" HeaderText="Boys" />
                                                        <asp:BoundField DataField="Girls" HeaderText="Girls" />
                                                        <asp:BoundField DataField="TOT" HeaderText="Total" />
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

