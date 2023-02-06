<%@ Page Language="C#" AutoEventWireup="true" CodeFile="prtAdmitCard.aspx.cs" Inherits="Academic_prtAdmitCard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
        .style4 {
            font-size: 16px;
            font-style: italic;
            font-family: "Century Gothic";
            font-weight: bold;
        }

        .style5 {
            font-size: medium;
            font-weight: bold;
        }
    </style>
</head>
<body onload="window.print();" style="margin: 0">
    <form id="form1" runat="server">
        <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
            <ItemTemplate>
                <table style="font-family: Book Antiqua; font-size: 13px; margin: 0; height: 400px;vertical-align:top;">
                    <tr>
                        <td style="text-align: center;">
                            <span style="font-size: 12pt; text-decoration: underline; font-weight: bold;">MINOR-I ADMIT CARD(2016-17)</span>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: justify; vertical-align:top;">
                            <table border="0" style="width: 100%; padding: 0">
                                <tr>
                                    <td >
                                        <table border="1" style="width: 100%; padding: 0;border-collapse:collapse;">
                                            <tr>
                                                <td>Enrollment No:</td>

                                                <td>Name:</td>
                                                <td>Semester:</td>

                                                <td>Course:</td>
                                            </tr>
                                           
                                            <tr>
                                                <td>
                                                    <%# Eval("ENROLLMENT_NO")%>
                                                </td>
                                                <td>
                                                    <%# Eval("STU_FULL_NAME")%>
                                                </td>

                                                <td>
                                                    <%# Eval("ACA_SEM_ID")%>
                                                </td>
                                                <td>
                                                    <%#Eval("PGM_SHORT_NAME")%>-<%# Eval("BRN_SHORT_NAME")%>
                                                </td>
                                            </tr>
                                             <%--<tr><td style="font-size:16px;text-align:center;" colspan="4"><b> <%# Eval("Reg_Status")%></b></t></tr>--%>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left;">
                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Font-Size="12px">
                                            <Columns>
                                                <asp:TemplateField HeaderText="S.No.">
                                                    <ItemTemplate>
                                                        <%# ((GridViewRow)Container).RowIndex + 1%>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="20px" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="SH_CRS_CODE" HeaderText="Paper Code" />
                                                <asp:BoundField DataField="SH_CRS_NAME" HeaderText="Paper Name" />
                                                <asp:BoundField DataField="SH_DATE" DataFormatString="{0:dd/MM}" HeaderText="Date" />
                                                <asp:BoundField DataField="TIME" HeaderText="Time" />
                                                <asp:BoundField DataField="ROOM_VALUE" HeaderText="Room No." />
                                                <asp:BoundField DataField="NUM" HeaderText="Seat" />
                                                <asp:BoundField HeaderText="Invigilator Signature">
                                                    <ItemStyle Width="150px" />
                                                </asp:BoundField>
                                            </Columns>
                                        </asp:GridView>
                                        <asp:Label ID="Label1" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr><th>Note:-Bags,Mobile phones and any kind of written material is not allowed in the examination hall.</th></tr>
                                <tr>
                                    <td style="text-align: right">
                                      <%--  <img src="../images/signature.jpg" style="width: 123px; height: 20px;" />--%>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:Repeater>
    </form>
</body>
</html>
