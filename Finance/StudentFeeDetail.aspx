<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="StudentFeeDetail.aspx.cs" Inherits="Finance_StudentFeeDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script lang="javascript" type="text/javascript">
        // Client Side Validation Script
    </script>
    <div class="container">
        <div class="heading">
            <h2>Fee Detail
            </h2>

        </div>

        <div id="cBody">
            <div id="cHead">
                <!-- Content  Header ex: Filters-->
                <table style="width: 100%">
                    <tr>
                        <th>By Institution</th>
                        <th>By Course</th>
                        <th>By Branch</th>
                        <th>By Batch</th>
                        <th>By Semester</th>
                        <th>By Section</th>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="ddlInstitute" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlInstitute_SelectedIndexChanged"></asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlCourse" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged"></asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlBranch" runat="server"></asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlBatch" runat="server"></asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlSemester" runat="server"></asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlSection" runat="server"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th>By Session</th>
                        <th>By Sem Type</th>
                        <th>By Student Status</th>
                        <th>By Accommodation Type</th>
                        <th>By Quota</th>
                        <th>By Fee Head</th>
                        
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="ddlSession" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlSemType" runat="server">
                                <asp:ListItem>Select</asp:ListItem>
                                <asp:ListItem Value="0">Even</asp:ListItem>
                                <asp:ListItem Value="1">Odd</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlStatus" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlAcommadation" runat="server">
                                <asp:ListItem>All</asp:ListItem>
                                <asp:ListItem Value="0">Day Scholar</asp:ListItem>
                                <asp:ListItem Value="1">Hosteller</asp:ListItem>
                                <asp:ListItem Value="2">Transport</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlQuota" runat="server">
                            </asp:DropDownList></td>
                        <td>
                            <asp:DropDownList ID="ddlShowType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlShowType_SelectedIndexChanged">
                                <asp:ListItem>Select</asp:ListItem>
                                <asp:ListItem Value="0">Group Head</asp:ListItem>
                                <asp:ListItem Value="1">Main Head</asp:ListItem>

                            </asp:DropDownList>
                        </td>
                        
                    </tr>
                    <tr>
                        <th>By Fee Head</th>
                        <th>By Student Type</th>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="ddlFeeHead" runat="server">
                                <asp:ListItem Value="0">Select</asp:ListItem>
                                <asp:ListItem Value="1">Complete</asp:ListItem>
                                <asp:ListItem Value="2">Paid</asp:ListItem>
                                <asp:ListItem Value="3">Due</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlStuType" runat="server">
                                <asp:ListItem Value="0">Select</asp:ListItem>
                                <asp:ListItem Value="1">Active</asp:ListItem>
                                <asp:ListItem Value="2">Inactive</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnExport" runat="server" Text="Export To Excel" OnClick="btnExport_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <div id="cCenter">
                <!-- Content Header ex: Grids-->
                <div style="overflow: auto; height: 400px;">
                    <asp:GridView ID="gvDemand" runat="server" CssClass="gridDynamic" AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField HeaderText="S#">
                                <ItemTemplate>
                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                </ItemTemplate>
                                <ItemStyle Width="20px" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="HEAD" HeaderText="HEAD NAME" />
                            <asp:BoundField DataField="NOS" HeaderText="NO OF STUDNET" FooterText="TOTAL" />
                            <asp:BoundField DataField="DEMAND" HeaderText="DEMAND" />
                            <asp:BoundField DataField="ADJUST" HeaderText="SCHOLAR + DISC" />
                            <asp:BoundField DataField="RECEIVE" HeaderText="RECEIVE" />
                            <asp:BoundField DataField="BALANCE" HeaderText="BALANCE" />
                        </Columns>
                    </asp:GridView>

                    <asp:GridView ID="GvDue" runat="server" CssClass="gridDynamic" AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField HeaderText="S#">
                                <ItemTemplate>
                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                </ItemTemplate>
                                <ItemStyle Width="20px" />
                            </asp:TemplateField>
                            
                            <asp:BoundField DataField="CURRENT_DUE" HeaderText="CURRENT DUE" />
                            <asp:BoundField DataField="PREV_DUE" HeaderText="PREV DUE" />
                            <asp:BoundField DataField="TOTAL_DUE" HeaderText="TOTAL DUE" />
                        </Columns>
                    </asp:GridView>


                </div>
            </div>
            <div id="cFooter">
                <!-- Content Header ex:Buttons-->

            </div>
        </div>
    </div>

</asp:Content>

