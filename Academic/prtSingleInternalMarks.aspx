<%@ Page Language="C#" AutoEventWireup="true" CodeFile="prtSingleInternalMarks.aspx.cs" Inherits="Academic_prtSingleInternalMarks" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body onload="window.print();">
    <form id="form1" runat="server">
        <asp:Repeater ID="repMarks" runat="server">
            <HeaderTemplate>
                <table style="width: 700px; font-family: Book Antiqua; font-size: 14px; vertical-align: top">
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <table style="border-collapse: collapse; margin: 0px; text-align: center; width: 100%; vertical-align: top">
                            <tr>
                                <td class="style5" style="height: 50px">MANGALAYATAN UNIVERSITY
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <%#Eval("INS_DESC")%>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-weight:bold">
                                    <%#Eval("EXAM_TYPE_SUB_HEAD")%>
                                    Marks(<%#Eval("ACA_SESN_VALUE") %>)
                                </td>
                            </tr>
                        </table>
                        <hr style="color: Black; height: 1px; padding: 0px; border-collapse: collapse; width: 100%" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <table style="text-align: center; vertical-align: top; margin: auto">
                            <tr>
                                <td>
                                    <table style="border-collapse: collapse; border-spacing: 0px;">
                                        <tr>
                                            <th style="text-align: right; padding-right: 5px">Course:</th>
                                            <td style="min-width: 20px; padding-right: 5px; text-align: left">
                                                <%#Eval("PGM_SHORT_NAME")%>
                                            </td>
                                            <th style="text-align: right; padding-right: 5px">Branch:</th>
                                            <td style="min-width: 20px; padding-right: 5px; text-align: left">
                                                <%#Eval("BRN_SHORT_NAME")%>
                                            </td>
                                            <th style="text-align: right; padding-right: 5px">Batch:</th>
                                            <td style="min-width: 20px; padding-right: 5px; text-align: left">
                                                <%#Eval("ACA_BATCH_NAME")%>
                                            </td>
                                            <th style="text-align: right; padding-right: 5px">Semester:</th>
                                            <td style="min-width: 20px; padding-right: 5px; text-align: left">
                                                <%#Eval("ACA_SEM_NO")%>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table style="border-collapse: collapse; border-spacing: 0px;">
                                        <tr>
                                            <th style="text-align: right; padding-right: 5px">Subject:</th>
                                            <td colspan="3">
                                                <%#Eval("PAPER_CODE")%>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <hr style="color: Black; height: 1px; padding: 0px; border-collapse: collapse; width: 100%" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="99%"
                            CellPadding="2">
                            <Columns>
                                <asp:TemplateField HeaderText="S.No.">
                                    <ItemTemplate>
                                        <%# ((GridViewRow)Container).RowIndex + 1%>
                                        .
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="STU_ADM_NO" HeaderText="ENROLLMENT" />
                                <asp:BoundField DataField="STU_FULL_NAME" HeaderText="STUDENT NAME" />
                                <asp:BoundField HeaderText="MARKS" DataField="INT_MARKS"></asp:BoundField>
                                <asp:BoundField DataField="ATT" HeaderText="ATTENDANCE" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td>
                        <hr style="visibility: hidden; color: White; background-color: White; page-break-before: always" />
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </form>
</body>
</html>
