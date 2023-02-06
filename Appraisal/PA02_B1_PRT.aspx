<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PA02_B1_PRT.aspx.cs" Inherits="Appraisal_PA02_B1_PRT" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/Main.css" type="text/css" rel="stylesheet" />
</head>
<body style="width: 700px">
    <form id="form1" runat="server">
        <div class="container">
            <div class="heading">
                <h2>Performa: PA02 (B1)
                </h2>
            </div>
            <div class="heading">
                <h3>Mangalayatan University
                </h3>
                <br />
                <br />
            </div>
            <div class="heading">
                <h3>
                    <asp:Label ID="lblInstitution" runat="server" CssClass="caps">
                    </asp:Label><br />
                </h3>
            </div>
            <div class="heading">
                <h4>SUMMARY OF STUDENT'S RESPONSE
                </h4>
            </div>
            <div>
                <table>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <th>Faculty Name:
                                    </th>
                                    <td>
                                        <asp:Label ID="lblFaculty" runat="server" CssClass="fill"></asp:Label></td>
                                    <th>Year:</th>
                                    <td>
                                        <asp:Label ID="lblYear" runat="server" CssClass="fill"></asp:Label></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <th>Course:</th>
                                    <td>
                                        <asp:Label ID="lblCourse" runat="server" CssClass="fill"></asp:Label>
                                    </td>
                                    <th>Branch:</th>
                                    <td>
                                        <asp:Label ID="lblBranch" runat="server" CssClass="fill"></asp:Label>
                                    </td>
                                    <th>Semester:</th>
                                    <td>
                                        <asp:Label ID="lblSemester" runat="server" CssClass="fill"></asp:Label>
                                    </td>
                                    <th>No. Of Students:</th>
                                    <td>
                                        <asp:Label ID="lblStudentsCount" runat="server" CssClass="fill"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <th>Subject:</th>
                                    <td>
                                        <asp:Label ID="lblSubject" runat="server" CssClass="fill"></asp:Label></td>
                                    <th>Paper Code:</th>
                                    <td>
                                        <asp:Label ID="lblPaperCode" runat="server" CssClass="fill"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <asp:GridView ID="gridMarksStudent" runat="server" AutoGenerateColumns="False" GridLines="None"
                                            CssClass="gridDynamic" AlternatingRowStyle-CssClass="alt">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="">
                                                    <ItemTemplate>
                                                        S-<%#((GridViewRow)Container).RowIndex + 1%>.
                                                    </ItemTemplate>
                                                    <ItemStyle Width="70px" />
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="1" DataField="1" HtmlEncode="false">
                                                    <ItemStyle Width="30px" HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="2" DataField="2" HtmlEncode="false">
                                                    <ItemStyle Width="30px" HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="3" DataField="3" HtmlEncode="false">
                                                    <ItemStyle Width="30px" HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="4" DataField="4" HtmlEncode="false">
                                                    <ItemStyle Width="30px" HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="5" DataField="5" HtmlEncode="false">
                                                    <ItemStyle Width="30px" HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="6" DataField="6" HtmlEncode="false">
                                                    <ItemStyle Width="30px" HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="7" DataField="7" HtmlEncode="false">
                                                    <ItemStyle Width="30px" HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="8" DataField="8" HtmlEncode="false">
                                                    <ItemStyle Width="30px" HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="9" DataField="9" HtmlEncode="false">
                                                    <ItemStyle Width="30px" HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="10" DataField="10" HtmlEncode="false">
                                                    <ItemStyle Width="30px" HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Total (50)" DataField="11" HtmlEncode="false">
                                                    <ItemStyle Width="70px" HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Percentage" DataField="12" HtmlEncode="false" DataFormatString="{0:N2}%">
                                                    <ItemStyle Width="60px" HorizontalAlign="Center" />
                                                </asp:BoundField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <asp:GridView ID="gridParameter" runat="server" AutoGenerateColumns="False" GridLines="None"
                                            CssClass="gridDynamic" AlternatingRowStyle-CssClass="alt">
                                            <Columns>
                                                <asp:TemplateField HeaderText="S.No.">
                                                    <ItemTemplate>
                                                        <%# ((GridViewRow)Container).RowIndex + 1%>
                                                    .
                                                    </ItemTemplate>
                                                    <ItemStyle Width="30px" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="PA02_B1_PARAM_HDR_VALUE" HeaderText="Param Heading">
                                                    <ItemStyle Width="200px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="PA02_B1_PARAM_VALUE" HeaderText="Parameter">
                                                    <ItemStyle Width="400px" />
                                                </asp:BoundField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
