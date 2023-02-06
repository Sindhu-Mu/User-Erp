<%@ Page Language="C#" AutoEventWireup="true" CodeFile="prtOpenElecMarks.aspx.cs" Inherits="Academic_prtOpenElecMarks" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body onload="window.print();">
    <form id="form1" runat="server">
        <div>
            <table style="border-collapse: collapse; margin: 0px; width: 100%; vertical-align: top">
                <tr>
                    <td class="style5" colspan="2" style="height: 50px;text-align: center; ">MANGALAYATAN UNIVERSITY
                    </td>

                </tr>
                <tr>
                    <td>PAPER CODE:<asp:Label runat="server" ID="lblPap"></asp:Label>
                    </td>
                     <td>SUBJECT NAME:<asp:Label runat="server" ID="lblSUB_NAME"></asp:Label>
                    </td>
                </tr>
                <tr>
                     <td>EXAMINATION:<asp:Label runat="server" ID="lblExam"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:GridView ID="GridView1" runat="server" Caption="OPEN ELECTIVE MARKS" CssClass="gridDynamic" AutoGenerateColumns="False" Width="99%"
                            CellPadding="2">
                            <Columns>
                                <asp:TemplateField HeaderText="S.No.">
                                    <ItemTemplate>
                                        <%# ((GridViewRow)Container).RowIndex + 1%>
                                    </ItemTemplate>
                                     <ItemStyle HorizontalAlign="Center"/>
                                </asp:TemplateField>
                                <asp:BoundField DataField="ENROLLMENT_NO" HeaderText="ENROLLMENT">
                                    <ItemStyle HorizontalAlign="Center"/>
                                </asp:BoundField>
                                <asp:BoundField DataField="STU_FULL_NAME" HeaderText="STUDENT NAME" />
                                <asp:BoundField HeaderText="MARKS" DataField="MARKS">
                                     <ItemStyle HorizontalAlign="Center"/>
                                </asp:BoundField>
                                <asp:BoundField DataField="ATT_STS" HeaderText="ATTENDANCE" >
                                     <ItemStyle HorizontalAlign="Center"/>
                                   </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
