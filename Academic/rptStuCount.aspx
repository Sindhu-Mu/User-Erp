<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="rptStuCount.aspx.cs" Inherits="Academic_rptStuCount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="heading">
            <h2>Student Count</h2>
        </div>
        <div>
            <asp:UpdatePanel ID="UpdateFull" runat="server">
                <ContentTemplate>
                    <div style="height: 250px; overflow: auto; padding-left: 10px; float: left; width: 200px">
                        <asp:GridView ID="gvIns" runat="server" AutoGenerateColumns="False"
                            EmptyDataText="No Record Found." Caption="Institute Wise" CssClass="gridDynamic">
                            <Columns>
                                <asp:TemplateField HeaderText="S.No">
                                    <ItemTemplate>
                                        <%#((GridViewRow)Container).RowIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="INS_VALUE" HeaderText="Institute" />
                                <asp:BoundField DataField="NOS" HeaderText="Count" />
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div style="height: 250px; overflow: auto; padding-left: 10px; float: left; width: auto">
                        <asp:GridView ID="gvCourse" runat="server" Caption="Programme Wise" AutoGenerateColumns="False"
                            EmptyDataText="No Record Found." CssClass="gridDynamic">
                            <Columns>
                                <asp:TemplateField HeaderText="S.No">
                                    <ItemTemplate>
                                        <%#((GridViewRow)Container).RowIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="INS_VALUE" HeaderText="Institution" />
                                <asp:BoundField DataField="PGM_SHORT_NAME" HeaderText="Program" />
                                <asp:BoundField DataField="NOS" HeaderText="Count" />
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div style="height: 250px; overflow: auto; padding-left: 10px; float: left; max-width: 500px">
                        <asp:GridView ID="gvBranch" runat="server" AutoGenerateColumns="False"
                            EmptyDataText="No Record Found." CssClass="gridDynamic" Caption="Branch Wise">
                            <Columns>
                                <asp:TemplateField HeaderText="S.No">
                                    <ItemTemplate>
                                        <%#((GridViewRow)Container).RowIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:BoundField DataField="PGM_SHORT_NAME" HeaderText="Program"></asp:BoundField>
                                <asp:BoundField DataField="BRN_SHORT_NAME" HeaderText="Branch" />
                                <asp:BoundField DataField="NOS" HeaderText="Count" />
                            </Columns>
                        </asp:GridView>
                    </div>

                    <div class="cleaner"></div>
                    <div style="height: 250px; overflow: auto; padding-left: 10px; float: left; width: auto">
                        <asp:GridView ID="GvBatch" Caption="Batch Wise" runat="server" AutoGenerateColumns="False"
                            EmptyDataText="No Record Found." CssClass="gridDynamic">
                            <Columns>
                                <asp:TemplateField HeaderText="S.No">
                                    <ItemTemplate>
                                        <%#((GridViewRow)Container).RowIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="ACA_BATCH_NAME" HeaderText="Batch" />
                                <asp:BoundField DataField="NOS" HeaderText="Count" />
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div style="height: 250px; overflow: auto; padding-left: 10px; float: left; width: 120px">
                        <asp:GridView ID="gvYear" Caption="Year Wise" runat="server" AutoGenerateColumns="False"
                            EmptyDataText="No Record Found." CssClass="gridDynamic">
                            <Columns>

                                <asp:BoundField DataField="Year" HeaderText="Year" />
                                <asp:BoundField DataField="NOS" HeaderText="Count" />
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div style="height: 250px; overflow: auto; padding-left: 10px; float: left; width: 200px">
                        <asp:GridView ID="gvSem" runat="server" AutoGenerateColumns="False" Caption="Semester Wise" EmptyDataText="No Record Found." CssClass="gridDynamic">
                            <Columns>
                                <asp:TemplateField HeaderText="S.No">
                                    <ItemTemplate>
                                        <%#((GridViewRow)Container).RowIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="ACA_SEM_NO" HeaderText="Semester"></asp:BoundField>
                                <asp:BoundField DataField="NOS" HeaderText="Count" />
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div style="height: 250px; overflow: auto; padding-left: 10px; float: left; max-width: 500px">
                        <asp:GridView ID="gvBrnSem" runat="server" Caption="Branch Semester Wise" AutoGenerateColumns="False"
                            EmptyDataText="No Record Found." CssClass="gridDynamic">
                            <Columns>
                                <asp:TemplateField HeaderText="S.No">
                                    <ItemTemplate>
                                        <%#((GridViewRow)Container).RowIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="INS_VALUE" HeaderText="Institute"></asp:BoundField>
                                <asp:BoundField DataField="PGM_SHORT_NAME" HeaderText="Program"></asp:BoundField>
                                <asp:BoundField DataField="BRN_SHORT_NAME" HeaderText="Branch" />
                                <asp:BoundField DataField="ACA_SEM_NO" HeaderText="Sem" />
                                <asp:BoundField DataField="NOS" HeaderText="Count" />
                            </Columns>
                        </asp:GridView>
                    </div>

                    <div class="cleaner"></div>
                    <div style="height: 250px; overflow: auto; padding-left: 10px; float: left; max-width: 500px">
                        <asp:GridView ID="gvGender" runat="server" AutoGenerateColumns="False"
                            EmptyDataText="No Record Found." CssClass="gridDynamic" Caption="Gender Wise">
                            <Columns>
                                <asp:TemplateField HeaderText="S.No">
                                    <ItemTemplate>
                                        <%#((GridViewRow)Container).RowIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="GEN_VALUE" HeaderText="Gender"></asp:BoundField>
                                <asp:BoundField DataField="NOS" HeaderText="Count" />
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div style="height: 250px; overflow: auto; padding-left: 10px; float: left; width: 200px">
                        <asp:GridView ID="gvCaste" Caption="Caste Wise" runat="server" AutoGenerateColumns="False" EmptyDataText="No Record Found." CssClass="gridDynamic">
                            <Columns>
                                <asp:TemplateField HeaderText="S.No">
                                    <ItemTemplate>
                                        <%#((GridViewRow)Container).RowIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="CAS_ALIAS" HeaderText="Caste"></asp:BoundField>
                                <asp:BoundField DataField="NOS" HeaderText="Count" />
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div style="height: 250px; overflow: auto; padding-left: 10px; float: left; max-width: 500px">
                        <asp:GridView ID="gvRel" runat="server" AutoGenerateColumns="False"
                            EmptyDataText="No Record Found." CssClass="gridDynamic" Caption="Religion Wise">
                            <Columns>
                                <asp:TemplateField HeaderText="S.No">
                                    <ItemTemplate>
                                        <%#((GridViewRow)Container).RowIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="REL_VALUE" HeaderText="Religion"></asp:BoundField>
                                <asp:BoundField DataField="NOS" HeaderText="Count" />
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div style="height: 250px; overflow: auto; padding-left: 10px; float: left; width: 300px">
                        <asp:GridView ID="gvHostel" runat="server" AutoGenerateColumns="False"
                            EmptyDataText="No Record Found." CssClass="gridDynamic" Caption="Hostel Wise">
                            <Columns>
                                <asp:TemplateField HeaderText="S.No">
                                    <ItemTemplate>
                                        <%#((GridViewRow)Container).RowIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="FAC_CMPLX_NAME" HeaderText="Hoslet"></asp:BoundField>
                                <asp:BoundField DataField="Year" HeaderText="Year"></asp:BoundField>
                                <asp:BoundField DataField="NOS" HeaderText="Count" />
                            </Columns>
                        </asp:GridView>
                    </div>

                    <div class="cleaner"></div>


                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

