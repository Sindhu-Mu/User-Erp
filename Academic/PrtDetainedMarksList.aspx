<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrtDetainedMarksList.aspx.cs" Inherits="Academic_PrtDetainedMarksList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body onload="window.print();">
    <form id="form1" runat="server">

        <table style="width: 700px; font-family: Book Antiqua; font-size: 14px; vertical-align: top">

            <tr>
                <td>
                    <table style="border-collapse: collapse; margin: 0px; text-align: center; width: 100%; vertical-align: top">
                        <tr>
                            <td class="style5" style="height: 50px">MANGALAYATAN UNIVERSITY
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblIns" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">
                                <asp:Label ID="lblExamName" runat="server"></asp:Label>

                            </td>
                        </tr>
                    </table>
                    <hr style="color: Black; height: 1px; padding: 0px; border-collapse: collapse; width: 100%" />
                </td>
            </tr>
            <tr>
                <td>
                    <table style="width: 100%;">
                        <tr>
                            <th style="text-align: left; padding-right: 5px">Course Code</th>

                            <td>&nbsp;</td>
                            <th style="text-align: left; padding-right: 5px">Course Name</th>
                        </tr>
                        <tr>
                            <td style="padding-right: 5px">

                                <asp:Label ID="lblCourseCode" runat="server"></asp:Label>
                            </td>
                            <td></td>
                            <td style="padding-right: 5px">

                                <asp:Label ID="lblCourseName" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gvDetainMarks" runat="server" AutoGenerateColumns="False" Width="99%"
                        CellPadding="2">
                        <Columns>
                            <asp:TemplateField HeaderText="S.No.">
                                <ItemTemplate>
                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                        .
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="ENROLLMENT_NO" HeaderText="Enrollment No" />
                            <asp:BoundField DataField="STU_FULL_NAME" HeaderText="Name" />
                             <asp:BoundField DataField="PGM_SHORT_NAME" HeaderText="Course" />
                             <asp:BoundField DataField="BRN_SHORT_NAME" HeaderText="Branch" />
                            <asp:BoundField DataField="MINOR1" HeaderText="Minor1"></asp:BoundField>
                            <asp:BoundField DataField="MINOR2" HeaderText="Minor2" />
                            <asp:BoundField DataField="CLASS_PERFORM" HeaderText="Class Performance" />
                            <asp:BoundField DataField="ATT_MARKS" HeaderText="Attendance Marks" />
                            <asp:BoundField DataField="TOTAL" HeaderText="Total Marks" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>
                    <hr style="visibility: hidden; color: White; background-color: White; page-break-before: always" />
                </td>
            </tr>
        </table>

    </form>
</body>
</html>
