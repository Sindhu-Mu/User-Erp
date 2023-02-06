<%@ Page Language="C#" AutoEventWireup="true" CodeFile="prtStuDataForm.aspx.cs" Inherits="Academic_prtStuDataForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: justify">
            <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
                <ItemTemplate>
                    <table style="width: 700px; font-family: Tahoma; padding-top: 50px; font-size: 13px; border-collapse: collapse; line-height: 170%">
                        <tr>
                            <td colspan="4">
                                <table style="width: 100%; border-collapse: collapse">
                                    <tr>
                                        <td style="text-align: center">
                                            <span style="font-size: 20px"><span class="style2">MANGALAYATAN UNIVERSITY</span><br />
                                                <span style="font-size: 16px">BATCH-<%#DataBinder.Eval(Container.DataItem, "ACA_BATCH_NAME")%></span><br />
                                                <span style="font-size: 16px" class="style1">STUDENT DATA FORM</span></span>

                                        </td>
                                        <td>
                                            <img src="<%#DataBinder.Eval(Container.DataItem, "IMG")%>" style="width: 120px; height: 130px;" />

                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <hr style="color: Black" noshade="noshade" size=".5" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" class="style1" style="height: 48px">

                                <b>Personal Information</b>
                                <%--<strong>Roll No:  <%#DataBinder.Eval(Container.DataItem, "SEM_ROLL_NO")%></strong>--%>
                                <hr style="color: Black" noshade="noshade" size=".5" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 194px; height: 16px;">Name:</td>
                            <td style="height: 16px">
                                <strong>
                                    <%#DataBinder.Eval(Container.DataItem, "STU_FULL_NAME")%>
                                </strong>
                            </td>
                            <td>Enrollment No.</td>
                            <td><strong><%#DataBinder.Eval(Container.DataItem, "ENROLLMENT_NO")%></strong></td>
                        </tr>
                        <tr>
                            <td>Date of Birth:</td>
                            <td>
                                <strong>
                                    <%#DataBinder.Eval(Container.DataItem, "DT_OF_BIRTH","{0:dd-MMM-yyyy}")%>
                                </strong>
                            </td>
                            <td>Gender: <%#DataBinder.Eval(Container.DataItem, "GEN_VALUE")%></td>
                            <td>Blood Group:___
                               
                            </td>

                        </tr>

                        <tr>
                            <td>Student Contact No:</td>
                            <td>
                                <%#DataBinder.Eval(Container.DataItem, "PHN_NO","{0:D1}")%>
                            </td>
                            <td>Email-Id:</td>
                            <td>
                                <%#DataBinder.Eval(Container.DataItem, "EMAIL")%>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 194px">Religion:</td>
                            <td style="width: 275px">
                                <asp:HiddenField ID="HiddenID" runat="server" Value='<%# Eval("STU_MAIN_ID") %>' />
                                <%#DataBinder.Eval(Container.DataItem, "REL_VALUE") %>
                            </td>
                            <td>Cast:</td>
                            <td>
                                <%#DataBinder.Eval(Container.DataItem, "CAS_ALIAS")%>
                            </td>
                        </tr>


                        <tr>
                            <td>Father's Name</td>
                            <td>
                                <strong>
                                    <%#DataBinder.Eval(Container.DataItem, "FATHER_NAME")%>
                                </strong>
                            </td>

                            <td>Father's Occupation</td>
                            <td>______________
                            </td>
                        </tr>
                        <tr>
                            <td>Mother's Name</td>
                            <td>
                                <strong>
                                    <%#DataBinder.Eval(Container.DataItem, "MOTHER_NAME")%>
                                </strong>
                            </td>


                            <td>Parent Contact No:</td>
                            <td>____________</td>

                        </tr>

                        <tr>
                            <td colspan="4">
                                <table style="width: 100%; border-collapse: collapse">
                                    <tr>
                                        <td>Permanent Address:</td>
                                        <td>Correspondence Address:</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <%#DataBinder.Eval(Container.DataItem, "ADD_1")%>
                                                        &nbsp;
                                                        <%#DataBinder.Eval(Container.DataItem, "ADD_2")%>
                                                        &nbsp;
                                                        <%#DataBinder.Eval(Container.DataItem, "CIT_VALUE")%>
                                                        &nbsp;
                                                        <%#DataBinder.Eval(Container.DataItem, "STA_VALUE")%>
                                        </td>
                                        <td>

                                            <%#DataBinder.Eval(Container.DataItem, "ADD_1")%>
                                                        &nbsp;
                                                        <%#DataBinder.Eval(Container.DataItem, "ADD_2")%>
                                                        &nbsp;
                                                        <%#DataBinder.Eval(Container.DataItem, "CIT_VALUE")%>
                                                        &nbsp;
                                                        <%#DataBinder.Eval(Container.DataItem, "STA_VALUE")%>
                                                        &nbsp;
                                        </td>
                                    </tr>
                                </table>
                                <tr>
                                    <td></td>
                                    <td></td>
                                </tr>




                            </td>
                        </tr>
                        <tr>
                        </tr>

                        <tr>
                            <td colspan="4" class="style1">
                                <strong>Academic Information</strong>
                                <hr style="color: Black" noshade="noshade" size=".5" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="1" style="width: 194px">Institution :
                            </td>
                            <td>
                                <%#DataBinder.Eval(Container.DataItem, "INS_VALUE")%>
                            </td>
                            <td colspan="1" style="width: 275px">App No:</td>
                            <td>
                                <%#DataBinder.Eval(Container.DataItem, "FORM_NO")%>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 194px">Programme:</td>
                            <td>
                                <%#DataBinder.Eval(Container.DataItem, "PGM_SHORT_NAME")%>
                            </td>
                            <td style="width: 275px">Branch:</td>
                            <td>
                                <%#DataBinder.Eval(Container.DataItem, "BRN_SHORT_NAME")%>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 194px">Batch:</td>
                            <td>
                                <%#DataBinder.Eval(Container.DataItem, "ACA_BATCH_NAME")%>
                            </td>
                            <td style="width: 275px">Semester:</td>
                            <td>
                                <%#DataBinder.Eval(Container.DataItem, "ACA_SEM_NO")%>
                            </td>
                        </tr>
                        <%-- <tr>
                            <td style="width: 194px">Section:</td>
                            <td>
                                <%#DataBinder.Eval(Container.DataItem, "ACA_SEC_NAME")%>
                            </td>
                        </tr>
                     <tr>
                                        <td style="width: 194px">
                                            Type:</td>
                                        <td style="width: 275px">
                                            <asp:Label ID="lblHosteller" runat="server" /></td>
                                        <td>
                                            Medicare No:</td>
                                        <td>
                                            <asp:Label ID="lblMedicare" runat="server" /></td>
                                    </tr>
                                    <tr id="trHostel" runat="server">
                                        <td colspan="4">
                                            <table cellpadding="3" cellspacing="0" border="0" width="100%">
                                                <tr>
                                                    <td style="width: 154px">
                                                        Hostel Name:</td>
                                                    <td style="width: 92px">
                                                        <asp:Label ID="lblHostel" runat="server" /></td>
                                                    <td colspan="2" style="width: 57px">
                                                        Room No:</td>
                                                    <td>
                                                        <asp:Label ID="lblRoom" runat="server" /></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr id="trTransport" runat="server">
                                        <td colspan="4">
                                            <table cellpadding="3" cellspacing="0" border="0" width="100%">
                                                <tr>
                                                    <td style="width: 153px">
                                                        Transport Route:</td>
                                                    <td style="width: 44px">
                                                        <asp:Label ID="lblRouteName" runat="server" /></td>
                                                    <td>
                                                        &nbsp; &nbsp; Route No:</td>
                                                    <td>
                                                        &nbsp;
                                                        <asp:Label ID="lblRouteNo" runat="server" /></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                        --%>
                        <tr>
                            <td colspan="4"><strong>Qualification Detail</strong>
                                <hr style="color: Black" noshade="noshade" size=".5" />
                            </td>
                        </tr>
                        <tr>

                            <td colspan="4">
                                <asp:GridView ID="GridView1" runat="server" Width="97%" AutoGenerateColumns="false">
                                    <Columns>
                                        <asp:TemplateField HeaderText="S.no">
                                            <ItemTemplate>
                                                <%#((GridViewRow)Container).RowIndex +1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Qualification" DataField="ACA_BASE_FULL_NAME" />
                                       <asp:BoundField HeaderText="Total Marks" DataField="TOT_MARKS" />
                                        <asp:BoundField HeaderText="Gain" DataField="TOT_GAIN" />
                                        <asp:BoundField HeaderText="%age" DataField="PRSNT" DataFormatString="{0:N2}" />
                                        <asp:BoundField HeaderText="College/School" DataField="ACA_SCHOOL" />
                                        <asp:BoundField HeaderText="University/Board" DataField="ACA_BRD_SHORT_NAME" />
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" style="text-align: left">&nbsp;</td>

                        </tr>
                        <tr>
                            <td colspan="4" style="text-align: left">&nbsp;</td>

                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: left" class="style3">&nbsp;&nbsp;&nbsp;  <%#DataBinder.Eval(Container.DataItem, "STU_FULL_NAME")%>
                                <br />
                                (Student Signature)</td>
                            <td colspan="2" style="text-align: right" class="style3">
                                <%-- <%=(Session["UserId"].ToString())%>
                                                                                    
                                            Mangalayatan University
                                            Beswan,Aligarh.--%>

                                            (Coordinator Signature) 
                            </td>
                        </tr>

                        <tr>
                            <td colspan="4">
                                <strong>Note : 1. Student must check their Name/Father's Name/Mother's Name/D.O.B. as per High
                                                School Certificates.<br />
                                    2. For more details check your student portal.
                                </strong></td>
                        </tr>
                    </table>
                    <hr style="visibility: hidden; page-break-after: always" />
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>

</html>
