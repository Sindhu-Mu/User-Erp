<%@ Page Language="C#" AutoEventWireup="true" CodeFile="popIssue.aspx.cs" Inherits="Facility_popIssue" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/Main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <table>
                <tr>
                    <th style="font-size:18px;">Token NO:<asp:Label ID="lblTokenName" runat="server" ForeColor="Black"></asp:Label>
                    </th>
                </tr>
                <tr>
                    <td>

                        <table>
                            <tr>
                                <th>Issue By: </th>
                                <td>
                                    <asp:Label ID="lblIssueBY" runat="server"></asp:Label></td>
                                <th>Contact No: </th>
                                <td>
                                    <asp:Label ID="lblContactNo" runat="server"></asp:Label></td>
                                <th>Complex: </th>
                                <td>
                                    <asp:Label ID="lblComplx" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <th>Locaion: </th>
                                <td>
                                    <asp:Label ID="lblLoc" runat="server"></asp:Label></td>
                                <th>Issue About:</th>
                                <td>
                                    <asp:Label ID="lblIssueAbt" runat="server"></asp:Label></td>
                                <th>Posted On: </th>
                                <td>
                                    <asp:Label ID="lblIssueOn" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <th>Issue Details: </th>
                                <td>
                                    <asp:Label ID="lblDetail" runat="server"></asp:Label></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table>
                            <tr>
                                <td style="color: #cc0000; font-size: 14px; font-weight: bold">Transfer Detail</td>
                            </tr>
                            <tr>
                                <th>Transfer To</th>
                                <td>
                                    <div>
                                        <asp:TextBox ID="txtassign" runat="server" Width="200px"></asp:TextBox>
                                        <ajaxToolkit:AutoCompleteExtender ID="AutoComplete1" runat="server" EnableCaching="true"
                                            TargetControlID="txtassign" ServicePath="~/AutoComplete.asmx" ServiceMethod="GetEmployeeList"
                                            MinimumPrefixLength="1" ContextKey="1" CompletionSetCount="12" CompletionInterval="500"
                                            CompletionListItemCssClass="itemCss">
                                        </ajaxToolkit:AutoCompleteExtender>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <th>Transfer Remark</th>
                                <td>
                                    <asp:TextBox ID="txtRemark" runat="server" Width="300px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Button ID="btnAsign" runat="server" Text="Assign" OnClick="btnAsign_Click" /></td>
                            </tr>
                        </table>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:GridView ID="gvAssign" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" DataKeyNames="ISSUE_TRANSFER_ID" OnRowDeleting="gvAssign_RowDeleting">
                            <Columns>
                                <asp:TemplateField HeaderText="S.No">
                                    <ItemTemplate>
                                        <%#((GridViewRow)Container).RowIndex +1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Transferd to" DataField="EMP_NAME" />
                                <asp:BoundField HeaderText="Transferring Remark" DataField="TRANSFER_REMARK" />
                                <asp:BoundField HeaderText="Transfer Date" DataField="TRANSFER_DT" DataFormatString="{0:dd/MM/yyyy}" />
                                <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Siteimages/delete.jpg" ShowDeleteButton="True"
                                    HeaderText="Delete">
                                    <ItemStyle Width="20px" />
                                </asp:CommandField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table>
                            <tr>
                                <td style="color: #cc0000; font-size: 14px; font-weight: bold;">Response To</td>
                            </tr>
                            <tr>
                                <th>Work Description</th>
                                <td>
                                    <asp:TextBox ID="txtWork" runat="server" TextMode="MultiLine" Width="300px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <th>Material Used</th>
                                <td>
                                    <asp:TextBox ID="txtMaterial" runat="server" TextMode="MultiLine" Width="300px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <th>Action Date</th>
                                <td>
                                    <asp:TextBox ID="txtDt" runat="server"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender3" Format="dd/MM/yyyy" runat="server" TargetControlID="txtDt"></ajaxToolkit:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <th>Action By</th>
                                <td>
                                    <asp:TextBox ID="txtActionby" runat="server" Width="200px"></asp:TextBox>
                                    <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" EnableCaching="true"
                                        TargetControlID="txtActionby" ServicePath="~/AutoComplete.asmx" ServiceMethod="GetEmployeeList"
                                        MinimumPrefixLength="1" ContextKey="1" CompletionSetCount="12" CompletionInterval="500" CompletionListItemCssClass="itemCss">
                                    </ajaxToolkit:AutoCompleteExtender>
                                </td>
                                <td>
                                    <asp:Button ID="btnInProces" runat="server" Text="In-Process" OnClick="btnInProces_Click" /></td>
                                <td>
                                    <asp:Button ID="btnFinish" runat="server" Text="Finish" OnClick="btnFinish_Click" /></td>
                                <td>
                                    <asp:Button ID="btnPrint" runat="server" Text="Print" OnClick="btnPrint_Click" /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="gvWorkDes" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" DataKeyNames="ISSUE_DET_ID" OnRowDeleting="gvWorkDes_RowDeleting">
                            <Columns>
                                <asp:TemplateField HeaderText="S.No">
                                    <ItemTemplate>
                                        <%#((GridViewRow)Container).RowIndex +1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Work Description" DataField="WORK_DETAIL" />
                                <asp:BoundField HeaderText="Material Used" DataField="MATERIAL_USED" />
                                <asp:BoundField HeaderText="Assign Date" DataField="SRT_DT" DataFormatString="{0:dd/MM/yyyy}" />
                                <asp:BoundField HeaderText="Assign By" DataField="EMP_NAME" DataFormatString="{0:dd/MM/yyyy}" />
                                <asp:BoundField HeaderText="Status" DataField="ISSUE_STS_VALUE" />
                                <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Siteimages/delete.jpg" ShowDeleteButton="True"
                                    HeaderText="Delete">
                                    <ItemStyle Width="20px" />
                                </asp:CommandField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
