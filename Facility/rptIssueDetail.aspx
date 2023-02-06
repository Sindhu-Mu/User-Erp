<%@ Page Language="C#" AutoEventWireup="true" CodeFile="rptIssueDetail.aspx.cs" Inherits="Facility_rptIssueDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Issue Detail</title>
</head>
<body onload="window.print();">
    <form id="form1" runat="server">
        <div>
            <table style="width:100%">
                <tr>
                    <td>
                        <asp:Label ID="lblHead" runat="server"></asp:Label>
                        <hr/>
                    </td>
                </tr>
                <tr style="text-align: left;">
                    <td>
                        <table>
                            <tr>
                                <th>From: </th>
                                <td><asp:Label ID="lblEmpName" runat="server"></asp:Label></td></tr>
                            <tr>
                                <th>Phone No:</th>
                                <td><asp:Label ID="lblPhn" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <th>Department: </th>
                                <td>
                                    <asp:Label ID="lblDeptName" runat="server"></asp:Label>
                                </td>
                                </tr>
                            <tr>
                                <th>Building: </th>
                                 <td>
                                    <asp:Label ID="lblBuilding" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    Location: </th>
                                <td>
                                    <asp:Label ID="lblLocation" runat="server"></asp:Label>
                                </td>
                                </tr>
                            <tr>
                                <th>
                                    Complain about: </th><td>
                                    <asp:Label ID="lblComplainAbout" runat="server"></asp:Label>
                                </td>
                                </tr>
                            <tr>
                                <th>
                                    Posted On: </th>
                                <td>
                                    <asp:Label ID="lblComplainDt" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <th>Complain Details</th>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblCompDetail" runat="server" Font-Size="15px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <th>
                        ASSIGN DETAIL
                        
                    </th>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="gvAssign" runat="server" AutoGenerateColumns="False" CssClass="gridDynamic" DataKeyNames="ISSUE_TRANSFER_ID">
                            <Columns>
                                <asp:TemplateField HeaderText="S.No.">
                                    <ItemTemplate>
                                        <%# ((GridViewRow)Container).RowIndex + 1%>
                                    </ItemTemplate>
                                    <ItemStyle Width="50px" />
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Assign To" DataField="EMP_NAME" />
                                <asp:BoundField HeaderText="Assign Remark" DataField="TRANSFER_REMARK" />
                                <asp:BoundField HeaderText="Assign Date" DataField="TRANSFER_DT" DataFormatString="{0:dd/MM/yyyy}" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <th>
                        RESPONSE DETAIL
                        <hr/>
                    </th>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="gvDetail" runat="server" AutoGenerateColumns="False" DataKeyNames="ISSUE_DET_ID">
                            <Columns>
                                <asp:TemplateField HeaderText="S.No.">
                                    <ItemTemplate>
                                        <%# ((GridViewRow)Container).RowIndex + 1%>
                                    </ItemTemplate>
                                    <ItemStyle Width="15px" />
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Work Description" DataField="WORK_DETAIL" >
                                    <ItemStyle Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Meterial Used" DataField="MATERIAL_USED" >
                                    <ItemStyle Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Action Date" DataField="SRT_DT" DataFormatString="{0:dd/MM/yyyy}" />
                                <asp:BoundField HeaderText="Action By" DataField="EMP_NAME" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
