<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="rptTptCount.aspx.cs" Inherits="Facility_rptTptCountaspx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script lang="javascript" type="text/javascript">
        function expand(feild, caller) {
            if (feild.style.display == 'block') {
                feild.style.display = 'none';
                caller.innerHTML = "<span class='collapse'>Expand " + caller.title + "</span>"
            }
            else {
                feild.style.display = 'block';
                caller.innerHTML = "<span class='collapse' style='color:red'>Collapse " + caller.title + "</span>";
            }
        }
    </script>
    <div class="container">
        <div class="heading">
            <h2>Transport Count Report</h2>
        </div>
        <table>
            <tr>
                <td>
                    <div onclick="expand(ByReg, this)" style="cursor: hand" title="Registration Data">
                        <span class="collapse">Expand Registration Data</span>
                    </div>
                    <div style="width: 100%; overflow: auto; display: none" id="ByReg">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <fieldset>
                                    <legend>By Registration</legend>
                                    <table>
                                        <tr>
                                            <td>
                                                <fieldset>
                                                    <legend>By City</legend>
                                                    <asp:GridView ID="gridRegCity" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic"
                                                        AlternatingRowStyle-CssClass="alt">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S.No.">
                                                                <ItemTemplate>
                                                                    <%# ((GridViewRow)Container).RowIndex + 1%>.
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="CITY_NAME" HeaderText="City" />
                                                            <asp:BoundField DataField="CNT" HeaderText="Count" />
                                                        </Columns>
                                                    </asp:GridView>
                                                </fieldset>
                                            </td>
                                            <td>
                                                <fieldset>
                                                    <legend>By Ins</legend>
                                                    <asp:GridView CssClass="gridDynamic"
                                                        AlternatingRowStyle-CssClass="alt" ID="gridRegIns" runat="server" AutoGenerateColumns="false" OnRowCommand="gridRegIns_RowCommand">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S.No.">
                                                                <HeaderTemplate>
                                                                    <asp:LinkButton Text="Reset" ID="linkINS_ID" runat="server" CommandName="RESET"></asp:LinkButton>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton Text='<%#Eval("INS_VALUE")%>' ID="linkINS_ID" runat="server" CommandName="GET" CommandArgument='<%#Eval("INS_ID")%>'></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="CNT" HeaderText="Count" />
                                                        </Columns>
                                                    </asp:GridView>
                                                </fieldset>
                                            </td>
                                            <td>
                                                <fieldset>
                                                    <legend>By Program
                                                    </legend>
                                                    <asp:GridView ID="gridRegInsCourse" CssClass="gridDynamic"
                                                        AlternatingRowStyle-CssClass="alt" runat="server" AutoGenerateColumns="false" OnRowCommand="gridRegInsCourse_RowCommand" >
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S.No.">
                                                                <HeaderTemplate>
                                                                    <asp:LinkButton Text="Reset" ID="linkINS_ID" runat="server" CommandName="RESET"></asp:LinkButton>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton Text='<%#Eval("PGM_SHORT_NAME")%>' ID="linkINS_ID" runat="server" CommandName="GET" CommandArgument='<%#Eval("INS_PGM_ID")%>'></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="CNT" HeaderText="Count" />
                                                        </Columns>
                                                    </asp:GridView>
                                                </fieldset>
                                            </td>
                                            <td>
                                                <fieldset>
                                                    <legend>By Branch</legend>
                                                    <asp:GridView CssClass="gridDynamic"
                                                        AlternatingRowStyle-CssClass="alt" ID="gridRegInsCourseBranch" runat="server" AutoGenerateColumns="false">
                                                        <Columns>
                                                            <asp:BoundField DataField="BRN_SHORT_NAME" HeaderText="Branch" />
                                                            <asp:BoundField DataField="CNT" HeaderText="Count" />
                                                        </Columns>
                                                    </asp:GridView>
                                                </fieldset>
                                            </td>
                                        </tr>
                                    </table>
                                </fieldset>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div onclick="expand(ByApr, this)" style="cursor:hand" title="Approved Route Data">
                        <span class="collapse">Expand Approved Route/Bus Data</span>
                    </div>
                    <div style="width: 100%; overflow: auto; display: none" id="ByApr">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <fieldset>
                                    <legend>By Approved Route/Bus</legend>
                                <table>
                                    <tr>
                                        <td>
                                            <fieldset>
                                                <legend>By City</legend>
                                                <asp:GridView CssClass="gridDynamic"
                                                    AlternatingRowStyle-CssClass="alt" ID="gridAprCity" runat="server" AutoGenerateColumns="false" EmptyDataText="No records found" OnRowCommand="gridAprCity_RowCommand"> 
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="S.No.">
                                                            <HeaderTemplate>
                                                                <asp:LinkButton Text="Reset" ID="linkINS_ID" runat="server" CommandName="RESET"></asp:LinkButton>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:LinkButton Text='<%#Eval("CITY_NAME")%>' ID="linkINS_ID" runat="server" CommandName="GET" CommandArgument='<%#Eval("CITY_ID")%>'></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="CNT" HeaderText="Count" />
                                                    </Columns>
                                                </asp:GridView>
                                            </fieldset>
                                        </td>
                                        <td>
                                            <fieldset>
                                                <legend>By Route</legend>
                                                <asp:GridView CssClass="gridDynamic"
                                                    AlternatingRowStyle-CssClass="alt" ID="gridAprRoute" runat="server" AutoGenerateColumns="false" EmptyDataText="No records found">
                                                    <Columns>
                                                        <asp:BoundField DataField="CITY_NAME" HeaderText="City" />
                                                        <asp:BoundField DataField="RTE_NAME" HeaderText="Route" />
                                                        <asp:BoundField DataField="BUS_ID" HeaderText="Bus NO" />
                                                        <asp:BoundField DataField="CNT" HeaderText="Count" />
                                                    </Columns>
                                                </asp:GridView>
                                            </fieldset>
                                        </td>
                                        <td>
                                            <fieldset>
                                                <legend>By Ins</legend>
                                                <asp:GridView CssClass="gridDynamic"
                                                    AlternatingRowStyle-CssClass="alt" ID="gridAprIns" runat="server" AutoGenerateColumns="false" EmptyDataText="No records found" OnRowCommand="gridAprIns_RowCommand">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="S.No.">
                                                            <HeaderTemplate>
                                                                <asp:LinkButton Text="Reset" ID="linkINS_ID" runat="server" CommandName="RESET"></asp:LinkButton>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:LinkButton Text='<%#Eval("INS_VALUE")%>' ID="linkINS_ID" runat="server" CommandName="GET" CommandArgument='<%#Eval("INS_ID")%>'></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="CNT" HeaderText="Count" />
                                                    </Columns>
                                                </asp:GridView>
                                            </fieldset>
                                        </td>
                                        <td>
                                            <fieldset>
                                                <legend>By Course</legend>
                                                <asp:GridView CssClass="gridDynamic"
                                                    AlternatingRowStyle-CssClass="alt" ID="gridAprCourse" runat="server" AutoGenerateColumns="false"  EmptyDataText="No records found" OnRowCommand="gridAprCourse_RowCommand">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="S.No.">
                                                            <HeaderTemplate>
                                                                <asp:LinkButton Text="Reset" ID="linkINS_ID" runat="server" CommandName="RESET"></asp:LinkButton>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:LinkButton Text='<%#Eval("PGM_SHORT_NAME")%>' ID="linkINS_ID" runat="server" CommandName="GET" CommandArgument='<%#Eval("INS_PGM_ID")%>'></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="CNT" HeaderText="Count" />
                                                    </Columns>
                                                </asp:GridView>
                                            </fieldset>
                                        </td>
                                        <td>
                                            <fieldset>
                                                <legend>By Branch</legend>
                                                <asp:GridView CssClass="gridDynamic"
                                                    AlternatingRowStyle-CssClass="alt" ID="gridAprBranch" runat="server" AutoGenerateColumns="false" EmptyDataText="No records found">
                                                    <Columns>
                                                        <asp:BoundField DataField="BRN_SHORT_NAME" HeaderText="Branch" />
                                                        <asp:BoundField DataField="CNT" HeaderText="Count" />
                                                    </Columns>
                                                </asp:GridView>
                                            </fieldset>
                                        </td>
                                    </tr>
                                </table>
                                     </fieldset>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div onclick="expand(ByPay,this)" style="cursor: hand" title="Approved Bus Data">
                        <span class="collapse">Expand Payment Done</span>
                        </div>
                        <div style="width: 100%; overflow: auto; display: none" id="ByPay">
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                    <fieldset>
                                        <legend>By Payment Done</legend>
                                        <table>
                                            <tr>
                                                <td>
                                                    <fieldset>
                                                        <legend>By City</legend>
                                                        <asp:GridView CssClass="gridDynamic"
                                                            AlternatingRowStyle-CssClass="alt" ID="gridBusCity" runat="server" AutoGenerateColumns="false" EmptyDataText="No records found" OnRowCommand="gridBusCity_RowCommand">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="S.No.">
                                                                    <HeaderTemplate>
                                                                        <asp:LinkButton Text="Reset" ID="linkINS_ID" runat="server" CommandName="RESET"></asp:LinkButton>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton Text='<%#Eval("CITY_NAME")%>' ID="linkINS_ID" runat="server" CommandName="GET" CommandArgument='<%#Eval("CITY_ID")%>'></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="CNT" HeaderText="Count" />
                                                            </Columns>
                                                        </asp:GridView>
                                                    </fieldset>
                                                </td>
                                                <td>
                                                    <fieldset>
                                                        <legend>By Route</legend>
                                                        <asp:GridView CssClass="gridDynamic"
                                                            AlternatingRowStyle-CssClass="alt" ID="gridBusRoute" runat="server" AutoGenerateColumns="false" EmptyDataText="No records found" OnRowCommand="gridBusRoute_RowCommand">
                                                            <Columns>
                                                                <asp:BoundField DataField="CITY_NAME" HeaderText="City" />
                                                                <asp:TemplateField HeaderText="S.No.">
                                                                    <HeaderTemplate>
                                                                        <asp:LinkButton Text="Reset" ID="linkINS_ID" runat="server" CommandName="RESET"></asp:LinkButton>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton Text='<%#Eval("RTE_NAME")%>' ID="linkINS_ID" runat="server" CommandName="GET" CommandArgument='<%#Eval("RTE_ID")%>'></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="CNT" HeaderText="Count" />
                                                            </Columns>
                                                        </asp:GridView>
                                                    </fieldset>
                                                </td>
                                                <td>
                                                    <fieldset>
                                                        <legend>By Bus</legend>
                                                        <asp:GridView CssClass="gridDynamic"
                                                            AlternatingRowStyle-CssClass="alt" ID="GridView1" runat="server" AutoGenerateColumns="false" EmptyDataText="No records found">
                                                            <Columns>
                                                                <asp:BoundField DataField="CITY_NAME" HeaderText="City" />
                                                                <asp:BoundField DataField="RTE_NAME" HeaderText="Route" />
                                                                <asp:BoundField DataField="BUS_ID" HeaderText="Bus No" />
                                                                <asp:BoundField DataField="CNT" HeaderText="Count" />
                                                            </Columns>
                                                        </asp:GridView>
                                                    </fieldset>
                                                </td>
                                                <td>
                                                    <fieldset>
                                                        <legend>By Ins</legend>
                                                        <asp:GridView CssClass="gridDynamic"
                                                            AlternatingRowStyle-CssClass="alt" ID="gridBusIns" runat="server" AutoGenerateColumns="false" EmptyDataText="No records found" OnRowCommand="gridBusIns_RowCommand">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="S.No.">
                                                                    <HeaderTemplate>
                                                                        <asp:LinkButton Text="Reset" ID="linkINS_ID" runat="server" CommandName="RESET"></asp:LinkButton>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton Text='<%#Eval("INS_VALUE")%>' ID="linkINS_ID" runat="server" CommandName="GET" CommandArgument='<%#Eval("INS_ID")%>'></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="CNT" HeaderText="Count" />
                                                            </Columns>
                                                        </asp:GridView>
                                                    </fieldset>
                                                </td>
                                                <td>
                                                    <fieldset>
                                                        <legend>By Course</legend>
                                                        <asp:GridView CssClass="gridDynamic"
                                                            AlternatingRowStyle-CssClass="alt" ID="gridBusCourse" runat="server" AutoGenerateColumns="false"  EmptyDataText="No records found" OnRowCommand="gridBusCourse_RowCommand">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="S.No.">
                                                                    <HeaderTemplate>
                                                                        <asp:LinkButton Text="Reset" ID="linkINS_ID" runat="server" CommandName="RESET"></asp:LinkButton>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton Text='<%#Eval("PGM_SHORT_NAME")%>' ID="linkINS_ID" runat="server" CommandName="GET" CommandArgument='<%#Eval("INS_PGM_ID")%>'></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="CNT" HeaderText="Count" />
                                                            </Columns>
                                                        </asp:GridView>
                                                    </fieldset>
                                                </td>
                                                <td>
                                                    <fieldset>
                                                        <legend>By Branch</legend>
                                                        <asp:GridView CssClass="gridDynamic"
                                                            AlternatingRowStyle-CssClass="alt" ID="gridBusBranch" runat="server" AutoGenerateColumns="false" EmptyDataText="No records found">
                                                            <Columns>
                                                                <asp:BoundField DataField="BRN_SHORT_NAME" HeaderText="Branch" />
                                                                <asp:BoundField DataField="CNT" HeaderText="Count" />
                                                            </Columns>
                                                        </asp:GridView>
                                                    </fieldset>
                                                </td>
                                            </tr>
                                        </table>
                                    </fieldset>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

