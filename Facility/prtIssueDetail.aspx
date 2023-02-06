<%@ Page Language="C#" AutoEventWireup="true" CodeFile="prtIssueDetail.aspx.cs" Inherits="Facility_prtIssueDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body  onload="window.print();" >
    <form id="form1" runat="server">
        <table>
            <tr>
                <th style="font-size: 18px; text-decoration: underline;">Issue Detail</th>
            </tr>
            <tr>
                <td>

                    <asp:GridView ID="gvIssueDetail" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" Width="100%"
                       EmptyDataText="No Record(s) Found">
                        <Columns>
                            <asp:TemplateField HeaderText="S.No" ItemStyle-Width="15px">
                                <ItemTemplate>
                                    <%#((GridViewRow)Container).RowIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Token No" DataField="ISSUE_TOKEN_NO" />                                            
                            <asp:BoundField HeaderText="Raised On" DataField="ISSUE_DT" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField HeaderText="Posted By" DataField="EMP_NAME" />
                              <asp:BoundField HeaderText="Complex" DataField="FAC_CMPLX_NAME" />       
                               <asp:BoundField HeaderText="Location" DataField="ISSUE_LOCATION" ItemStyle-Width="70px" />
                            <asp:BoundField HeaderText="Issue Detail" DataField="ISSUE_DETAIL" ItemStyle-Width="250px"  />
                           <asp:BoundField HeaderText="Remark"  ItemStyle-Width="150px"  />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr><td>&nbsp;</td></tr>
            <tr>
                <td>
                    <table>
                        <tr>
                            <th style="text-align: left;">Assign Date</th>
                            <td>____________</td>
                            <th style="text-align: left;">Assign To </th>
                            <td>____________________________________________________</td>
                        </tr>
                    </table></td></tr>
        </table>
    </form>
</body>
</html>
