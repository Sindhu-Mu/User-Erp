<%@ Page Language="C#" AutoEventWireup="true" CodeFile="prtStuMonthlyReport.aspx.cs" Inherits="Academic_prtStuMonthlyReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Student Status Report</title>
    <style lang="en-us" type="text/css">
        table {
            border-collapse: collapse;
            border-spacing: 0px;
            margin: 0px;
        }

        .space {
            border-collapse: collapse;
            border-spacing: 0px;
        }

            .space th {
                padding-right: 2px;
            }

            .space td {
                padding-right: 5px;
            }

        .border {
            border: solid 1px black;
        }

            .border th {
                border: solid 1px black;
            }

            .border td {
                border: solid 1px black;
            }
    </style>
</head>
<body style="margin: 0;" onload="window.print();">
    <form id="form1" runat="server" style="margin: 0;">
        <asp:Repeater ID="repeatStudentData" runat="server" EnableViewState="false">
            <HeaderTemplate>
                <table style="width: 700px; border-collapse: collapse; border-spacing: 0px; margin: 0; text-align: left; font-size: 14px;">
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td style="padding-left: 10px;">
                        <table style="width: 100%; border-collapse: collapse; border-spacing: 0px;">
                            <tr>
                                <td>
                                    <table style="width: 100%; border-collapse: collapse; border-spacing: 0px;">
                                        <tr>
                                            <td>&nbsp;&nbsp;&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left; vertical-align: bottom">
                                                <img src="../Siteimages/logo-1.png" alt="" style="width: 300px; height: 100px" />
                                            </td>
                                            <td>
                                                <table style="width: 100%; text-align: right; border-collapse: collapse; border-spacing: 0px;">
                                                    <tr>
                                                        <td>Extended NCR,<br />
                                                            Aligarh-Mathura Highway,33<sup>rd</sup>Milestone,
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Beswan, Aligarh-202145,India Tel: 0571-3258592-93
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Toll Free # 1800-180-3377, Fax : 05722-254220
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Website: www.mangalayatan.in
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table style="width: 100%; border-collapse: collapse; border-spacing: 0px;">
                                        <%--<tr>
                                            <td>&nbsp;&nbsp;&nbsp;
                                            </td>
                                        </tr>--%>
                                        <tr>
                                            <td align="center">
                                                <table style="text-align: left; border-collapse: collapse; border-spacing: 0px; vertical-align: top">
                                                    <tr>
                                                        <td>
                                                            <%#Eval("STU_FULL_NAME")%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>C/o&nbsp;<%#Eval("FATHER_NAME")%></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <%#Eval("COM_ADD") %>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>Ph:&nbsp;<%#Eval("PHN_NO") %></td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td style="text-align: right; vertical-align: top">Dated:<%#Eval("DATE")%></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>

                                <td style="text-decoration: underline; text-align: center; font-weight: bold;">Sub/विषय: Student Academic Report/छात्र स्थिति रिपोर्ट
                                    <%--<br />
                                    विषय: छात्र स्थिति रिपोर्ट--%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table style="width: 100%; border-collapse: collapse; border-spacing: 0px; text-align: left; font-size: 16px">
                                        <%--<tr>
                                            <td>&nbsp;&nbsp;&nbsp;
                                            </td>
                                        </tr>
                                        --%>
                                        <tr>

                                            <td>Respected Sir,
                                                <br />
                                                प्रिय महोदय/महोदया,
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>As an endeavour on our part to create a strong bond between the parents and the University,
                                                we are providing the monthly status report of your ward.
                                                <br />
                                                अभिभावक व विश्वविद्यालय के मध्य सम्बन्ध और अधिक मजबूत करने के लिए हमारे प्रयास के तहत हम आपके पुत्र /पुत्री के वर्तमान शैक्षणिक विवरण प्रेषित कर रहे हैं।
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table style="width: 100%; border-collapse: collapse; border-spacing: 0px;" class="space">
                                        <%--<tr>
                                            <td>&nbsp;&nbsp;&nbsp;
                                            </td>
                                        </tr>--%>
                                        <tr>

                                            <th>Enroll/पंजीकरण संख्या:</th>
                                            <td>
                                                <%#Eval("ENROLLMENT_NO") %>
                                            </td>
                                            <th>Batch/बैच:</th>
                                            <td>
                                                <%#Eval("ACA_BATCH_NAME") %>
                                            </td>
                                            <th>Course/पाठ्यक्रम:</th>
                                            <td>
                                                <%#Eval("PGM_SHORT_NAME") %>
                                            </td>
                                            <th>Branch/शाखा:</th>
                                            <td>
                                                <%#Eval("BRN_SHORT_NAME")%>
                                            </td>
                                            <th>Semester/सेमेस्टर:</th>
                                            <td>
                                                <%#Eval("ACA_SEM_NO") %>
                                            </td>
                                            <th>Section/अनुभाग:</th>
                                            <td>
                                                <%#Eval("ACA_SEC_NAME") %>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table style="width: 100%; border-collapse: collapse; border-spacing: 0px;">
                                        <%--<tr>
                                            <td>&nbsp;&nbsp;&nbsp;
                                            </td>
                                        </tr>
                                        --%><tr>
                                            <th>The attendance records upto the Month of
                                                <%#Eval("MONTH") %>
                                                , &nbsp;<%#Eval("YEAR")%> is as follows:-
                                                <br />
                                                <%#Eval("MONTH")%>
                                                ,
                                                <%#Eval("YEAR")%>
                                                तक का उपस्थिति रिकॉर्ड निम्नलिखित हैं:-
                                            </th>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table style="width: 100%; border-collapse: collapse; border-spacing: 0px;">
                                        <%--<tr>
                                            <td>&nbsp;&nbsp;&nbsp;
                                            </td>
                                        </tr>--%>
                                        <tr>
                                            <td>
                                                <asp:GridView ID="gvAttendance1" runat="server" AutoGenerateColumns="False" EmptyDataText="No records found"
                                                    Font-Size="13px" CssClass="border">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="S.No.">
                                                            <ItemTemplate>
                                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                .
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="EVA_SCH_PAPER_CODE" HeaderText="Paper Code" />
                                                        <asp:BoundField DataField="ACA_SUB_NAME" HeaderText="Subject" />
                                                        <asp:BoundField DataField="HELD" HeaderText="No of Class" />
                                                        <asp:BoundField DataField="PRESENT" HeaderText="Att. Status" />
                                                        <asp:BoundField DataField="PER" HeaderText="%age" />
                                                        <asp:BoundField DataField="INT_MARKS" HeaderText="Minor Marks" />
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>

                            <%--<tr>
                                <td>&nbsp;&nbsp;&nbsp;
                                </td>
                            </tr>--%>
                            <%--<tr id="trAmt" runat="server">
                                <td>
                                    <table style="width: 100%; border-collapse: collapse; border-spacing: 0px;">
                                        <tr>
                                            <td>&nbsp;&nbsp;&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>The outstanding dues in respect of your ward is Rs.<asp:Label ID="lblFee" runat="server"></asp:Label>
                                                <br />
                                                आपके बच्चे के संबंध में बकाया देय राशि रु-
                                                <asp:Label ID="lblDue" runat="server"></asp:Label>
                                                है।
                                            </th>
                                        </tr>
                                    </table>
                                </td>
                            </tr>--%>
                            <%--<tr>
                                <td>&nbsp;&nbsp;&nbsp;
                                </td>
                            </tr>
                            --%><tr>
                                <td style="font-size: 16px;">Registrar,<br />
                                    Mangalayatan University
                                    <br />
                                    रजिस्ट्रार,<br />
                                    मंगलायतन विश्वविद्यालय
                                </td>
                            </tr>
                        </table>
                        <hr style='color: White; page-break-after: always;' />
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
