<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="IssueSolution.aspx.cs" Inherits="Facility_IssueSolution" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .itemCss {
            z-index: 10020;
        }
    </style>
    <div class="container">
        <div class="heading">
            <h2>Issue Details</h2>
        </div>
        <table>
            <tr>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div>
                                <table>
                                    <tr>
                                        <th>By Department</th>
                                        <th>By Complex</th>
                                        <th>By Issue</th>
                                        <th>By Token No</th>
                                        <th>By Employee</th>


                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="ddlDepartment" runat="server" Width="120px"></asp:DropDownList></td>
                                        <td>
                                            <asp:DropDownList ID="ddlComplex" runat="server" Width="110px"></asp:DropDownList></td>
                                        <td>
                                            <asp:DropDownList ID="ddlComplain" runat="server" Width="160px"></asp:DropDownList></td>
                                        <td>
                                            <asp:TextBox ID="txtToken" runat="server"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ID="txtPostedBy" runat="server" Width="200px"></asp:TextBox>
                                            <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" EnableCaching="true"
                                                TargetControlID="txtPostedBy" ServicePath="~/AutoComplete.asmx" ServiceMethod="GetEmployeeList"
                                                MinimumPrefixLength="1" ContextKey="1" CompletionSetCount="12" CompletionInterval="500" CompletionListItemCssClass="itemCss">
                                            </ajaxToolkit:AutoCompleteExtender>
                                        </td>

                                    </tr>
                                    <tr>

                                        <th colspan="3">By Posting Date</th>
                                        <th>By Status</th>
                                    </tr>
                                    <tr>

                                        <td>
                                            <asp:DropDownList ID="ddlPostDt" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DateType_Change">
                                                <asp:ListItem Text="All" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="Equals To" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Less Than" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="Greater Than" Value="3"></asp:ListItem>
                                                <asp:ListItem Text="Between" Value="4"></asp:ListItem>
                                            </asp:DropDownList></td>
                                        <td>
                                            <asp:TextBox ID="txtFrmDt" runat="server" Width="90px"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="txtFrmDt"></ajaxToolkit:CalendarExtender>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtEndDt" runat="server" Width="90px"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" runat="server" TargetControlID="txtEndDt"></ajaxToolkit:CalendarExtender>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlSts" runat="server" ></asp:DropDownList></td>

                                        <td>
                                            <asp:Button ID="btnsave" runat="server" Text="View" OnClick="btnsave_Click" />
                                            &nbsp;<asp:Button ID="btnExport" runat="server" Text="Export to Excel" Visible="false" OnClick="btnExport_Click" />
                                            <asp:Button ID="btnPrint" runat="server" Text="Print" OnClick="btnPrint_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div>
                                <table>

                                    <tr>
                                        <td>
                                            <div style="height: 450px; overflow-y: auto;">
                                                <asp:GridView ID="gvIssueDetail" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" Width="97%"
                                                    DataKeyNames="ISSUE_ID,ISSUE_STS" OnRowCommand="gvIssueDetail_RowCommand" EmptyDataText="No Record(s) Found">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="S.No">
                                                            <ItemTemplate>
                                                                <%#((GridViewRow)Container).RowIndex + 1 %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField HeaderText="Token No" DataField="ISSUE_TOKEN_NO" />

                                                        <asp:BoundField HeaderText="Complex" DataField="FAC_CMPLX_NAME" />
                                                        <asp:BoundField HeaderText="Location" DataField="ISSUE_LOCATION" ItemStyle-Width="70px" />
                                                        <asp:BoundField HeaderText="Raised On" DataField="ISSUE_DT" DataFormatString="{0:dd/MM/yyyy}" />
                                                        <asp:BoundField HeaderText="Issue Detail" DataField="ISSUE_DETAIL" ItemStyle-Width="200px" ItemStyle-Font-Size="11px" ItemStyle-Font-Bold="true" />
                                                        <asp:BoundField HeaderText="Posted By" DataField="EMP_NAME" />
                                                        <asp:TemplateField HeaderText="Detail">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="imgStatus" runat="server" CausesValidation="false" CommandArgument='<%# Bind("ISSUE_ID") %>'
                                                                    ImageUrl="~/Siteimages/edit.gif" CommandName="View" ToolTip="Issue detail" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </td>
                                    </tr>
                                  
                                    <tr>
                                        <td></td>
                                    </tr>
                                </table>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <%-- <td id="tbIssueCount" runat="server" style="vertical-align: top;">
                    <table>
                        <tr>
                            <th style="color: #000000; font-size: medium">Cuurent Year Report</th>
                        </tr>
                        <tr>
                            <th>Solved:
                                                                <br />
                                <asp:Label ID="lblSolved" runat="server" ForeColor="#ff0000"></asp:Label>
                            </th>
                        </tr>
                        <tr>
                            <th>Pending:
                                                                <br />
                                <asp:Label ID="lblPending" runat="server" ForeColor="#ff0000"></asp:Label></th>
                        </tr>
                        <tr>
                            <th>In Process:
                                                                <br />
                                <asp:Label ID="lblProces" runat="server" ForeColor="#ff0000"></asp:Label></th>
                        </tr>
                        <tr>
                            <th>Total:
                                                                <br />
                                <asp:Label ID="lblTotal" runat="server" ForeColor="#ff0000"></asp:Label></th>
                        </tr>
                    </table>
                </td>--%>
            </tr>
        </table>
    </div>
</asp:Content>

