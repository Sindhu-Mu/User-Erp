<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Short.master" AutoEventWireup="true" CodeFile="EmpIssueTransfer.aspx.cs" Inherits="Facility_EmpIssueTransfer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentHolder1" Runat="Server">
    <div class="container">
        <div class="heading">
            <h2>Issue</h2>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table>
                     <tr>
                            <td id="tdss" runat="server">
                                <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" DropShadow="false"
                                    PopupControlID="Panel1" TargetControlID="tdss">
                                </ajaxToolkit:ModalPopupExtender>
                            </td>
                        </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="gvIssues" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" OnRowCommand="gvIssues_RowCommand">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No">
                                        <ItemTemplate>
                                            <%#((GridViewRow)Container).RowIndex +1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Token No" DataField="ISSUE_TOKEN_NO" />
                                    <asp:BoundField HeaderText="Transfered By" DataField="EMP_NAME" />
                                    <asp:BoundField HeaderText="Complex" DataField="FAC_CMPLX_NAME" />
                                    <asp:BoundField HeaderText="Transferd Date" DataField="TRANSFER_DT" DataFormatString="{0:dd/MM/yyyy}" />
                                    <asp:BoundField HeaderText="Issue Related To" DataField="SUB_HEAD_VALUE" />
                                    <asp:TemplateField HeaderText="Detail" ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgStatus" runat="server" CausesValidation="false" CommandArgument='<%# Bind("ISSUE_ID") %>'
                                                    ImageUrl="~/Siteimages/edit.gif" CommandName="View" ToolTip="Issue detail" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                            <td>
                                <asp:Panel Style="display: none; width: 50%; background-color:#dddddd" ID="Panel1" runat="server">
                                    <asp:Panel Style="border-right: gray 1px solid; border-top: gray 1px solid; border-left: gray 1px solid; cursor: move; color: black; border-bottom: gray 1px solid; background-color:gray"
                                        ID="Panel3" runat="server">
                                        <table style="width: 100%">
                                            <tr>
                                                <th style="font-size: 14px; font-weight: bold; color:black">Token NO:<asp:Label ID="lblTokenName" runat="server" Font-Size="14px" Font-Bold="true" ForeColor="Black"></asp:Label>
                                                </th>
                                                <td style="text-align: right">
                                                    <asp:ImageButton ID="CancelButton" runat="server" ImageUrl="~/Siteimages/cancel_icon.gif" /></td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <table>
                                        <tr>
                                            <th>Issue By: </th>
                                            <td><asp:Label ID="lblIssueBY" runat="server"></asp:Label></td>
                                            <th>Contact No: </th>
                                            <td><asp:Label ID="lblContactNo" runat="server"></asp:Label></td>
                                            <th>Complex: </th>
                                            <td><asp:Label ID="lblComplx" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <th>Locaion: </th>
                                            <td><asp:Label ID="lblLoc" runat="server"></asp:Label></td>
                                            <th>Issue About:</th>
                                            <td><asp:Label ID="lblIssueAbt" runat="server"></asp:Label></td>
                                            <th>Posted On: </th>
                                            <td><asp:Label ID="lblIssueOn" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <th>Issue Details: </th>
                                            <td><asp:Label ID="lblDetail" runat="server"></asp:Label></td>
                                        </tr>
                                    </table>
                                    <table>
                                        <tr>
                                            <td style="color:#cc0000; font-size: 14px; font-weight: bold">Response To</td>
                                        </tr>
                                        <tr>
                                            <th>Work Description</th>
                                            <td><asp:TextBox ID="txtWork" runat="server" TextMode="MultiLine" Width="300px"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <th>Material Used</th>
                                            <td><asp:TextBox ID="txtMaterial" runat="server" TextMode="MultiLine" Width="300px"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <th>Action Date</th>
                                            <td><asp:TextBox ID="txtDt" runat="server"></asp:TextBox>
                                                   <ajaxToolkit:CalendarExtender ID="CalendarExtender3" Format="dd/MM/yyyy" runat="server" TargetControlID="txtDt"></ajaxToolkit:CalendarExtender>
                                            </td>
                                            </tr>
                                        <tr>
                                            <th>Action By</th>
                                            <td><asp:TextBox ID="txtActionby" runat="server" Width="200px"></asp:TextBox>
                                                <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" EnableCaching="true"
                                      TargetControlID="txtActionby" ServicePath="~/AutoComplete.asmx" ServiceMethod="GetEmployeeList"
                                    MinimumPrefixLength="1" ContextKey="1" CompletionSetCount="12" CompletionInterval="500">
                                </ajaxToolkit:AutoCompleteExtender>
                                            </td>
                                            <td><asp:Button ID="btnFinish" runat="server" Text="Finish" OnClick="btnFinish_Click"/></td>
                                        </tr>
                                    </table>
                                    <table>
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
                                </asp:Panel>

                            </td>
                        </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

