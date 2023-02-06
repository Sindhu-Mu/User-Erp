<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="rptEmpCounting.aspx.cs" Inherits="HR_rptEmpCounting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="heading">
            <h2>
                <asp:Label ID="lblSearch" runat="server" ></asp:Label></h2>
        </div>

        <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div style="height: 220px; float: left; overflow: auto; width: 20%">
                        <asp:GridView ID="gvInstituion" runat="server" Width="90%" Caption="Institute Wise" AutoGenerateColumns="False"
                            EmptyDataText="No Record Found." CssClass="gridDynamic">
                            <Columns>

                                <asp:BoundField DataField="INS_VALUE" HeaderText="Institute" />

                                <asp:ButtonField CommandName="Show" DataTextField="NOS" Text="Button" HeaderText="Count">
                                    <ItemStyle HorizontalAlign="right" />
                                </asp:ButtonField>
                            </Columns>
                            <SelectedRowStyle BackColor="#FFC0C0" />
                        </asp:GridView>
                    </div>



                    <div style="height: 220px; float: left; overflow: auto; width: 60%">
                        <asp:GridView ID="gvDepartment" runat="server" Caption="Department Wise" AutoGenerateColumns="False" GridLines="None"
                            CellPadding="3" EmptyDataText="No Record Found." CssClass="gridDynamic" Width="90%">
                            <Columns>

                                <asp:BoundField DataField="INS_VALUE" HeaderText="Institute" />
                                <asp:BoundField DataField="DEPT_VALUE" HeaderText="Department" />
                                <asp:BoundField DataField="TEACHING" HeaderText="Teaching" />
                                <asp:BoundField DataField="NTEACHING" HeaderText="Non-Teaching" />
                                <asp:ButtonField CommandName="Show" DataTextField="NOS" Text="Button" HeaderText="Count">
                                    <ItemStyle HorizontalAlign="Right" Font-Bold="true" />
                                </asp:ButtonField>
                            </Columns>
                        </asp:GridView>
                    </div>


                    <div style="height: 220px; float: left; overflow: auto; width: 20%">
                        <asp:GridView ID="gvStatus" runat="server" Caption="Status Wise" AutoGenerateColumns="False" GridLines="None"
                            CellPadding="3" EmptyDataText="No Record Found." CssClass="gridDynamic">
                            <Columns>

                                <asp:BoundField DataField="STS_VALUE" HeaderText="Status" />
                                <asp:ButtonField CommandName="Show" DataTextField="NOS" Text="Button" HeaderText="Count">
                                    <ItemStyle HorizontalAlign="Right" Font-Bold="true" />
                                </asp:ButtonField>
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div class="cleaner">&nbsp;</div>
                    <div style="height: 220px; float: left; overflow: auto; width: 20%">
                        <asp:GridView ID="gvTeaching" runat="server" Caption="Teaching Wise" AutoGenerateColumns="False" GridLines="None"
                            CellPadding="3" EmptyDataText="No Record Found." CssClass="gridDynamic">
                            <Columns>

                                <asp:BoundField DataField="JOB_TYPE_VALUE" HeaderText="Status" />
                                <asp:ButtonField CommandName="Show" DataTextField="NOS" Text="Button" HeaderText="Count">
                                    <ItemStyle HorizontalAlign="Right" Font-Bold="true" />
                                </asp:ButtonField>
                            </Columns>
                        </asp:GridView>

                    </div>
                    <div style="height: 220px; float: left; overflow: auto; width: 30%">
                        <asp:GridView ID="gvCategory" Caption="Category Wise" runat="server" AutoGenerateColumns="False" GridLines="None"
                            CellPadding="3" EmptyDataText="No Record Found." CssClass="gridDynamic" Width="90%">
                            <Columns>

                                <asp:BoundField DataField="CAT_VALUE" HeaderText="Category" />
                                <asp:ButtonField CommandName="Show" DataTextField="NOS" Text="Button" HeaderText="Count">
                                    <ItemStyle HorizontalAlign="Right" Font-Bold="true" />
                                </asp:ButtonField>
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div style="height: 250px; float: left; overflow: auto; width: 40%">
                        <asp:GridView ID="gvDesignation" Caption="Designation Wise" runat="server" AutoGenerateColumns="False" GridLines="None"
                            CellPadding="3" EmptyDataText="No Record Found." CssClass="gridDynamic" Width="90%">
                            <Columns>

                                <asp:BoundField DataField="CAT_VALUE" HeaderText="Category">
                                    <ItemStyle />
                                </asp:BoundField>
                                <asp:BoundField DataField="DES_VALUE" HeaderText="Designation" />
                                <asp:ButtonField CommandName="Show" DataTextField="NOS" Text="Button" HeaderText="Count">
                                    <ItemStyle HorizontalAlign="Right" Font-Bold="true" />
                                </asp:ButtonField>
                            </Columns>
                        </asp:GridView>
                    </div>

                    <div class="cleaner">&nbsp;</div>
                    <div style="height: 220px; float: left; overflow: auto; width: 20%">
                        <asp:GridView ID="gvMarital" runat="server" Caption="Marital Status Wise" AutoGenerateColumns="False" GridLines="None"
                            CellPadding="3" EmptyDataText="No Record Found." CssClass="gridDynamic">
                            <Columns>

                                <asp:BoundField DataField="MAR_STS_VALUE" HeaderText="Status" />
                                <asp:ButtonField CommandName="Show" DataTextField="NOS" Text="Button" HeaderText="Count">
                                    <ItemStyle HorizontalAlign="Right" Font-Bold="true" />
                                </asp:ButtonField>
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div style="height: 220px; float: left; overflow: auto; width: 30%">
                        <asp:GridView ID="gvInsTeaching" runat="server" Caption="Instituion Teaching Wise" Width="90%" AutoGenerateColumns="False"
                            GridLines="None" CellPadding="3" EmptyDataText="No Record Found." CssClass="gridDynamic">
                            <Columns>

                                <asp:BoundField DataField="INSTITUTION" HeaderText="Institute" />
                                <asp:BoundField DataField="TEACHING" HeaderText="TEACHING" />
                                <asp:BoundField DataField="NON" HeaderText="NON-TEACHING" />


                            </Columns>
                            <SelectedRowStyle BackColor="#FFC0C0" />
                        </asp:GridView>
                    </div>
                    <div style="height: 250px; float: left; overflow: auto; width: 20%">
                        <asp:GridView ID="gvType" Caption="Employment Type Wise" runat="server" AutoGenerateColumns="False" GridLines="None"
                            CellPadding="3" EmptyDataText="No Record Found." CssClass="gridDynamic">
                            <Columns>

                                <asp:BoundField DataField="SERV_TYPE_VALUE" HeaderText="Type" />
                                <asp:ButtonField CommandName="Show" DataTextField="NOS" Text="Button" HeaderText="Count">
                                    <ItemStyle HorizontalAlign="Right" Font-Bold="true" />
                                </asp:ButtonField>
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div style="height: 150px; float: left; overflow: auto; width: 20%">
                        <asp:GridView ID="gvCaste" runat="server" Caption="Caste Wise" AutoGenerateColumns="False" GridLines="None"
                            CellPadding="3" EmptyDataText="No Record Found." CssClass="gridDynamic" Width="90%">
                            <Columns>

                                <asp:BoundField DataField="CAS_VALUE" HeaderText="Caste" />
                                <asp:ButtonField CommandName="Show" DataTextField="NOS" Text="Button" HeaderText="Count">
                                    <ItemStyle HorizontalAlign="Right" Font-Bold="True" />
                                </asp:ButtonField>
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div class="cleaner">&nbsp;</div>
                    <div style="height: 220px; float: left; overflow: auto; width: 20%">
                        <asp:GridView ID="gvQualiType" runat="server" Caption="Qualification Type Wise" AutoGenerateColumns="False" GridLines="None"
                            CellPadding="3" EmptyDataText="No Record Found." CssClass="gridDynamic" Width="90%">
                            <Columns>

                                <asp:BoundField DataField="ACA_BASE_FULL_NAME" HeaderText="Type" />
                                <asp:ButtonField CommandName="Show" DataTextField="NOS" Text="Button" HeaderText="Count">
                                    <ItemStyle HorizontalAlign="Right" Font-Bold="true" />
                                </asp:ButtonField>
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div style="height: 220px; float: left; overflow: auto; width: 40%">
                        <asp:GridView ID="gvQualification" runat="server" Caption="Qualification Wise" AutoGenerateColumns="False" GridLines="None"
                            CellPadding="3" EmptyDataText="No Record Found." CssClass="gridDynamic" Width="90%">
                            <Columns>

                                <asp:BoundField DataField="QUAL_REMARK" HeaderText="Qualification" />
                                <asp:ButtonField CommandName="Show" DataTextField="NOS" Text="Button" HeaderText="Count">
                                    <ItemStyle HorizontalAlign="Right" Font-Bold="true" />
                                </asp:ButtonField>
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div style="height: 220px; float: left; overflow: auto; width: 40%">
                        <asp:GridView ID="gvQualifyTeaching" runat="server" Caption="Qualification Teaching Wise" Width="90%" AutoGenerateColumns="False"
                            GridLines="None" CellPadding="3" EmptyDataText="No Record Found." CssClass="gridDynamic">
                            <Columns>

                                <asp:BoundField DataField="ACA_BASE_FULL_NAME" HeaderText="Qualification" />
                                <asp:BoundField DataField="TEACHING" HeaderText="TEACHING" />
                                <asp:BoundField DataField="NON" HeaderText="NON-TEACHING" />


                            </Columns>
                            <SelectedRowStyle BackColor="#FFC0C0" />
                        </asp:GridView>
                    </div>
                    <div class="cleaner">&nbsp;</div>
                    <div style="overflow: auto; float: left; width: 38%; height: 220px">
                        <asp:GridView ID="gvJoining" runat="server" Caption="Yearly Joining Wise" CssClass="gridDynamic" EmptyDataText="No Record Found." CellPadding="3" GridLines="None" AutoGenerateColumns="False" Width="90%">
                            <Columns>
                                <asp:BoundField DataField="DYEAR" HeaderText="Year"></asp:BoundField>
                                <asp:BoundField DataField="TEACHING" HeaderText="Type"></asp:BoundField>
                                <asp:BoundField DataField="Joining" HeaderText="Join"></asp:BoundField>
                                <asp:BoundField DataField="Reliving" HeaderText="Relive"></asp:BoundField>
                                <asp:ButtonField CommandName="Show" DataTextField="NOW" Text="Button" HeaderText="Count">
                                    <ItemStyle HorizontalAlign="Right" Font-Bold="True"></ItemStyle>
                                </asp:ButtonField>
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div style="height: 220px; float: left; overflow: auto; width: 15%">
                        <asp:GridView ID="gvGender" Caption="Gender Wise" runat="server" AutoGenerateColumns="False" GridLines="None"
                            CellPadding="3" EmptyDataText="No Record Found." CssClass="gridDynamic">
                            <Columns>
                                <asp:BoundField DataField="GEN_VALUE" HeaderText="Gender" />
                                <asp:ButtonField CommandName="Show" DataTextField="NOS" Text="Button" HeaderText="Count">
                                    <ItemStyle HorizontalAlign="Right" Font-Bold="true" />
                                </asp:ButtonField>
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div style="height: 220px; float: left; overflow: auto; width: 25%">
                        <asp:GridView ID="gvEOL" runat="server" Caption="EOL Employee" AutoGenerateColumns="False" GridLines="None"
                            CellPadding="3" EmptyDataText="No Record Found." CssClass="gridDynamic" Width="90%">
                            <Columns>
                                <asp:BoundField DataField="INS_VALUE" HeaderText="Institute" />
                                <asp:BoundField DataField="DEPT_VALUE" HeaderText="Department" />
                                <asp:ButtonField CommandName="Show" DataTextField="NOS" Text="Button" HeaderText="Count">
                                    <ItemStyle HorizontalAlign="Right" Font-Bold="True" />
                                </asp:ButtonField>
                            </Columns>
                        </asp:GridView>
                    </div>

                    <div style="height: 220px; float: left; overflow: auto; width: 15%">
                        <asp:GridView ID="gvReligion" Caption="Religion Wise" runat="server" AutoGenerateColumns="False" GridLines="None"
                            CellPadding="3" EmptyDataText="No Record Found." CssClass="gridDynamic" Width="90%">
                            <Columns>

                                <asp:BoundField DataField="REL_VALUE" HeaderText="Religion" />
                                <asp:ButtonField CommandName="Show" DataTextField="NOS" Text="Button" HeaderText="Count">
                                    <ItemStyle HorizontalAlign="Right" Font-Bold="true" />
                                </asp:ButtonField>
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div class="cleaner">&nbsp;</div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

