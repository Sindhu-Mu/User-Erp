<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PA03.aspx.cs" Inherits="Appraisal_PA03" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%--<link href="../css/Main.css" type="text/css" rel="stylesheet" />--%>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div>
                <table>
                    <tr style="text-align:center">
                        <td style="font-size: 20px; border-bottom: 1px solid #000">Performa: PA03<br />
                            Mangalayatan University<br />
                            &nbsp;<asp:Label ID="lblInstitution" runat="server">
                    </asp:Label>
                            <br />
                            Faculty Performance Appraisal <br />
                            (<asp:Label ID="lblRFrom" runat="server"></asp:Label>
                        to <asp:Label ID="lblRTo" runat="server"></asp:Label> )<br />
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top">
                            <hr style="height: 1px; color: Black;" />
                            <table style="text-align:left">
                                <tr>
                                    <td>
                                        <table>
                                            <tr>
                                                <th>Emp.Code:</th>
                                                <td>
                                                    <asp:Label ID="lblEmpCode" runat="server" Font-Bold="True"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <th>Faculty Name:
                                                </th>
                                                <td>
                                                    <asp:Label ID="lblFaculty" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th>Designation:</th>
                                                <td>
                                                    <asp:Label ID="lblDesignation" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <th>Date of joining:</th>
                                                <td>
                                                    <asp:Label ID="lblDoj" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <th>Department:</th>
                                                <td>
                                                    <asp:Label ID="lblDepartment" runat="server"></asp:Label></td>
                                            </tr>
                                            <%--<tr>
                                                <th>Institution</th>
                                                <td>
                                                    <asp:Label ID="llblInstitution" runat="server"></asp:Label></td>
                                            </tr>--%>
                                        </table>
                                        <hr style="height: 1px; color: Black;" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table>
                                            <tr>
                                                <td>
                                                    <div class="heading">
                                                        <h4>
                                                            <asp:Label ID="lblHeader1A" runat="server"></asp:Label>
                                                            <br />
                                                            <asp:Label ID="lblDescription1A" runat="server"></asp:Label>
                                                        </h4>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6">
                                                    <asp:GridView ID="gridData1A" runat="server" AutoGenerateColumns="false" GridLines="Both"
                                                        AllowPaging="false" AlternatingRowStyle-CssClass="alt"
                                                        SelectedRowStyle-CssClass="pgr">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S.No.">
                                                                <ItemTemplate>
                                                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                .
                                                                </ItemTemplate>
                                                                <ItemStyle Width="30px" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField HeaderText="Paper Code" DataField="PA03_1A_CODE" ItemStyle-Width="90px" />
                                                            <asp:BoundField HeaderText="Paper Name" DataField="PA03_1A_NAME" ItemStyle-Width="100px" />
                                                            <asp:BoundField HeaderText="Student Count" DataField="PA03_1A_COT" ItemStyle-Width="50px" />
                                                            <asp:BoundField HeaderText="Lecture" DataField="PA03_1A_LAB" ItemStyle-Width="50px" />
                                                            <asp:BoundField HeaderText="Tutorial" DataField="PA03_1A_TUT" ItemStyle-Width="50px" />
                                                            <asp:BoundField HeaderText="Practical" DataField="PA03_1A_PCT" ItemStyle-Width="50px" />
                                                            <asp:BoundField HeaderText="Innovation" DataField="PA03_1A_RMK" ItemStyle-Width="200px" />
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
                                                    <div class="heading">
                                                        <h4>
                                                            <asp:Label ID="lblHeader1B" runat="server"></asp:Label>
                                                            <br />
                                                            <asp:Label ID="lblDescription1B" runat="server"></asp:Label>
                                                        </h4>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6">
                                                    <asp:GridView ID="gridData1B" runat="server" AutoGenerateColumns="false" GridLines="Both"
                                                        AllowPaging="false" AlternatingRowStyle-CssClass="alt"
                                                        SelectedRowStyle-CssClass="pgr">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S.No.">
                                                                <ItemTemplate>
                                                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                .
                                                                </ItemTemplate>
                                                                <ItemStyle Width="30px" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="PA03_1B_DET" HeaderText="Details" ItemStyle-Width="500px" />
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
                                                    <div class="heading">
                                                        <h4>
                                                            <asp:Label ID="lblHeader2A" runat="server"></asp:Label>
                                                            <br />
                                                            <asp:Label ID="lblDescription2A" runat="server"></asp:Label>
                                                        </h4>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6">
                                                    <asp:GridView ID="gridData2A" runat="server" AutoGenerateColumns="false" GridLines="Both"
                                                        AllowPaging="false" AlternatingRowStyle-CssClass="alt"
                                                        SelectedRowStyle-CssClass="pgr">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S.No.">
                                                                <ItemTemplate>
                                                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                .
                                                                </ItemTemplate>
                                                                <ItemStyle Width="30px" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="PA03_2A_DUT" HeaderText="Duties" />
                                                            <asp:BoundField DataField="PA03_UNIV_LVL_VALUE" HeaderText="Level" />
                                                            <asp:BoundField DataField="PA03_2A_FROM_DATE" HeaderText="From Date" DataFormatString="{0:dd/MM/yyyy}" />
                                                            <asp:BoundField DataField="PA03_2A_TO_DATE" HeaderText="To Date" DataFormatString="{0:dd/MM/yyyy}" />
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
                                                    <div class="heading">
                                                        <h4>
                                                            <asp:Label ID="lblHeader2B" runat="server"></asp:Label>
                                                            <br />
                                                            <asp:Label ID="lblDescription2B" runat="server"></asp:Label>
                                                        </h4>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6">
                                                    <asp:GridView ID="gridData2B" runat="server" AutoGenerateColumns="false" GridLines="Both"
                                                        AllowPaging="false" AlternatingRowStyle-CssClass="alt"
                                                        SelectedRowStyle-CssClass="pgr">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S.No.">
                                                                <ItemTemplate>
                                                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                .
                                                                </ItemTemplate>
                                                                <ItemStyle Width="30px" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="PA03_2B_DUT" HeaderText="Duties" />
                                                            <asp:BoundField DataField="PA03_UNIV_LVL_VALUE" HeaderText="Level" />
                                                            <asp:BoundField DataField="PA03_OPMF_VALUE" HeaderText="O/M/P/F" />
                                                            <asp:BoundField DataField="PA03_2B_FROM_DATE" HeaderText="From Date" DataFormatString="{0:dd/MM/yyyy}" />
                                                            <asp:BoundField DataField="PA03_2B_TO_DATE" HeaderText="To Date" DataFormatString="{0:dd/MM/yyyy}" />
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
                                                    <div class="heading">
                                                        <h4>
                                                            <asp:Label ID="lblHeader2C" runat="server"></asp:Label>
                                                            <br />
                                                            <asp:Label ID="lblDescription2C" runat="server"></asp:Label>
                                                        </h4>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6">
                                                    <asp:GridView ID="gridData2C" runat="server" AutoGenerateColumns="false" GridLines="Both"
                                                        AllowPaging="false" AlternatingRowStyle-CssClass="alt"
                                                        SelectedRowStyle-CssClass="pgr">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S.No.">
                                                                <ItemTemplate>
                                                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                .
                                                                </ItemTemplate>
                                                                <ItemStyle Width="30px" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="PA03_2C_DUT" HeaderText="Duties" />
                                                            <asp:BoundField DataField="PA03_UNIV_LVL_VALUE" HeaderText="Level" />
                                                            <asp:BoundField DataField="PA03_OPMF_VALUE" HeaderText="O/M/P/F" />
                                                            <asp:BoundField DataField="PA03_2C_FROM_DATE" HeaderText="From Date" DataFormatString="{0:dd/MM/yyyy}" />
                                                            <asp:BoundField DataField="PA03_2C_TO_DATE" HeaderText="To Date" DataFormatString="{0:dd/MM/yyyy}" />
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
                                                    <div class="heading">
                                                        <h4>
                                                            <asp:Label ID="lblHeader2D" runat="server"></asp:Label>
                                                            <br />
                                                            <asp:Label ID="lblDescription2D" runat="server"></asp:Label>
                                                        </h4>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6">
                                                    <asp:GridView ID="gridData2D" runat="server" AutoGenerateColumns="false" GridLines="Both"
                                                        AllowPaging="false" AlternatingRowStyle-CssClass="alt"
                                                        SelectedRowStyle-CssClass="pgr">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S.No.">
                                                                <ItemTemplate>
                                                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                .
                                                                </ItemTemplate>
                                                                <ItemStyle Width="30px" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="PA03_2D_DUT" HeaderText="Duties" />
                                                            <asp:BoundField DataField="PA03_UNIV_LVL_VALUE" HeaderText="Level" />
                                                            <asp:BoundField DataField="PA03_OPMF_VALUE" HeaderText="O/M/P/F" />
                                                            <asp:BoundField DataField="PA03_2D_FROM_DATE" HeaderText="From Date" DataFormatString="{0:dd/MM/yyyy}" />
                                                            <asp:BoundField DataField="PA03_2D_TO_DATE" HeaderText="To Date" DataFormatString="{0:dd/MM/yyyy}" />
                                                            <%-- <asp:BoundField DataField="PA03_2D_STATUS" HeaderText="Status" />--%>
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
                                                    <div class="heading">
                                                        <h4>
                                                            <asp:Label ID="lblHeader2E" runat="server"></asp:Label>
                                                            <br />
                                                            <asp:Label ID="lblDescription2E" runat="server"></asp:Label>
                                                        </h4>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6">
                                                    <asp:GridView ID="gridData2E" runat="server" AutoGenerateColumns="false" GridLines="Both"
                                                        AllowPaging="false" AlternatingRowStyle-CssClass="alt"
                                                        SelectedRowStyle-CssClass="pgr">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S.No.">
                                                                <ItemTemplate>
                                                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                .
                                                                </ItemTemplate>
                                                                <ItemStyle Width="30px" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="PA03_2E_DUT" HeaderText="Duties" />
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
                                                    <div class="heading">
                                                        <h4>
                                                            <asp:Label ID="lblHeader2F" runat="server"></asp:Label>
                                                            <br />
                                                            <asp:Label ID="lblDescription2F" runat="server"></asp:Label>
                                                        </h4>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6">
                                                    <table>
                                        <tr>
                                            <th>1.	General Involvement</th>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <th>i) Counselling at Admission Cell <span class="required">*</span>
                                                        </th>
                                                        <td>&nbsp;</td>
                                                        <td colspan="6">
                                                            <asp:TextBox ID="txtCounselling" runat="server" MaxLength="200"
                                                                Width="300px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th>ii) Total time spent (hours) <span class="required">*</span>
                                                        </th>
                                                        <td>&nbsp;</td>
                                                        <td colspan="6">
                                                            <asp:TextBox ID="txtTotalTime" runat="server" MaxLength="200"
                                                                Width="300px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th>iii) Contact explored / travel made off campus details <span class="required">*</span>
                                                        </th>

                                                        <td colspan="6">
                                                            <asp:TextBox ID="txtContact" runat="server" MaxLength="200"
                                                                Width="300px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                  
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>2. Any other contribution</th>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <th>i)No. of students motivated to pursue higher study here  <span class="required">*</span>
                                                        </th>
                                                        <td>&nbsp;</td>
                                                        <td colspan="3">
                                                            <asp:TextBox ID="txtAny1" runat="server" MaxLength="50" 
                                                                Width="100px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th>ii) No. of students encouraged to purchase admission form  <span class="required">*</span>
                                                        </th>
                                                        <td>&nbsp;</td>
                                                        <td colspan="6">
                                                            <asp:TextBox ID="txtAny2" runat="server" MaxLength="50" 
                                                                Width="100px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th>iii) No. of students to visit university campus  <span class="required">*</span>
                                                        </th>

                                                        <td colspan="6">
                                                            <asp:TextBox ID="txtAny3" runat="server" MaxLength="50" 
                                                                Width="100px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th>iv) No. of students connected put up for counselling in admission cell  <span class="required">*</span>
                                                        </th>

                                                        <td colspan="6">
                                                            <asp:TextBox ID="txtAny4" runat="server" MaxLength="50" 
                                                                Width="100px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th>v) No. of students got admission  <span class="required">*</span>
                                                        </th>

                                                        <td colspan="6">
                                                            <asp:TextBox ID="txtAny5" runat="server"  MaxLength="50"
                                                                Width="100px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr><td colspan="7">
                                                        <asp:GridView ID="gridData2F" AutoGenerateColumns="False" runat="server" EmptyDataText="No recoeds found." CssClass="gridDynamic">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="S.No.">
                                                                    <ItemTemplate>
                                                                        <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField HeaderText="Program" DataField="PA03_2F_PROGRAM" />
                                                                <asp:BoundField HeaderText="Student" DataField="PA03_2F_STUDENT" />                                                               
                                                                
                                                            </Columns>
                                                        </asp:GridView>
                                                        </td></tr>

                                                </table>

                                            </td>
                                        </tr>
                                    <tr>

                                    </tr>
                                    </table>
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
                                                    <div class="heading">
                                                        <h4>
                                                            <asp:Label ID="lblHeader3A" runat="server"></asp:Label>
                                                            <br />
                                                            <asp:Label ID="lblDescription3A" runat="server"></asp:Label>
                                                        </h4>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6">
                                                    <asp:GridView ID="gridData3A" runat="server" AutoGenerateColumns="false" GridLines="Both"
                                                        AllowPaging="false" AlternatingRowStyle-CssClass="alt"
                                                        SelectedRowStyle-CssClass="pgr">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S.No.">
                                                                <ItemTemplate>
                                                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                .
                                                                </ItemTemplate>
                                                                <ItemStyle Width="30px" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="PA03_3A_AWD" HeaderText="Award" />
                                                            <asp:BoundField DataField="PA03_3A_RMK" HeaderText="Remark" />
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
                                                    <div class="heading">
                                                        <h4>
                                                            <asp:Label ID="lblHeader3B" runat="server"></asp:Label>
                                                            <br />
                                                            <asp:Label ID="lblDescription3B" runat="server"></asp:Label>
                                                        </h4>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6">
                                                    <asp:GridView ID="gridData3B" runat="server" AutoGenerateColumns="false" GridLines="Both"
                                                        AllowPaging="false" AlternatingRowStyle-CssClass="alt"
                                                        SelectedRowStyle-CssClass="pgr">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S.No.">
                                                                <ItemTemplate>
                                                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                .
                                                                </ItemTemplate>
                                                                <ItemStyle Width="30px" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="PA03_3B_MEM" HeaderText="Membership" />
                                                            <asp:BoundField DataField="PA03_3B_RMK" HeaderText="Remark" />
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
                                                    <div class="heading">
                                                        <h4>
                                                            <asp:Label ID="lblHeader3C" runat="server"></asp:Label>
                                                            <br />
                                                            <asp:Label ID="lblDescription3C" runat="server"></asp:Label>
                                                        </h4>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6">
                                                    <asp:GridView ID="gridData3C" runat="server" AutoGenerateColumns="false" GridLines="Both"
                                                        AllowPaging="false" AlternatingRowStyle-CssClass="alt"
                                                        SelectedRowStyle-CssClass="pgr">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S.No.">
                                                                <ItemTemplate>
                                                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                .
                                                                </ItemTemplate>
                                                                <ItemStyle Width="30px" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="PA03_3C_NAME" HeaderText="Name of the Conf./Seminar/Course" />
                                                            <asp:BoundField DataField="PA03_3C_SPD" HeaderText="Sponsored By" />
                                                            <asp:BoundField DataField="PA03_3C_FROM_DATE" HeaderText="From Date" DataFormatString="{0:dd/MM/yyyy}" />
                                                            <asp:BoundField DataField="PA03_3C_TO_DATE" HeaderText="To Date" DataFormatString="{0:dd/MM/yyyy}" />
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
                                                    <div class="heading">
                                                        <h4>
                                                            <asp:Label ID="lblHeader3D" runat="server"></asp:Label>
                                                            <br />
                                                            <asp:Label ID="lblDescription3D" runat="server"></asp:Label>
                                                        </h4>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6">
                                                    <asp:GridView ID="gridData3D" runat="server" AutoGenerateColumns="false" GridLines="Both"
                                                        AllowPaging="false" AlternatingRowStyle-CssClass="alt"
                                                        SelectedRowStyle-CssClass="pgr">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S.No.">
                                                                <ItemTemplate>
                                                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                .
                                                                </ItemTemplate>
                                                                <ItemStyle Width="30px" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="PA03_3D_INS" HeaderText="Instt./Organisation Visited" />
                                                            <asp:BoundField DataField="PA03_3D_PUP" HeaderText="Purpose Of Visit" />
                                                            <asp:BoundField DataField="PA03_3D_FROM_DATE" HeaderText="From Date" DataFormatString="{0:dd/MM/yyyy}" />
                                                            <asp:BoundField DataField="PA03_3D_TO_DATE" HeaderText="To Date" DataFormatString="{0:dd/MM/yyyy}" />
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
                                                    <div class="heading">
                                                        <h4>
                                                            <asp:Label ID="lblHeader3E" runat="server"></asp:Label>
                                                            <br />
                                                            <asp:Label ID="lblDescription3E" runat="server"></asp:Label>
                                                        </h4>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6">
                                                    <asp:GridView ID="gridData3E" runat="server" AutoGenerateColumns="false" GridLines="Both"
                                                        AllowPaging="false" AlternatingRowStyle-CssClass="alt"
                                                        SelectedRowStyle-CssClass="pgr">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S.No.">
                                                                <ItemTemplate>
                                                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                .
                                                                </ItemTemplate>
                                                                <ItemStyle Width="30px" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="PA03_3E_NAME" HeaderText="Conf./Seminar/Sym./Workshop/Short Term Courses" />
                                                            <asp:BoundField DataField="PA03_3E_PLC" HeaderText="Place" />
                                                            <asp:BoundField DataField="PA03_3E_SPD" HeaderText="Sponsored By" />
                                                            <asp:BoundField DataField="PA03_3E_FROM_DATE" HeaderText="From Date" DataFormatString="{0:dd/MM/yyyy}" />
                                                            <asp:BoundField DataField="PA03_3E_TO_DATE" HeaderText="To Date" DataFormatString="{0:dd/MM/yyyy}" />
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
                                                    <div class="heading">
                                                        <h4>
                                                            <asp:Label ID="lblHeader4A" runat="server"></asp:Label>
                                                            <br />
                                                            <asp:Label ID="lblDescription4A" runat="server"></asp:Label>
                                                        </h4>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6">
                                                    <asp:GridView ID="gridData4A" runat="server" AutoGenerateColumns="false" GridLines="Both"
                                                        AllowPaging="false" AlternatingRowStyle-CssClass="alt"
                                                        SelectedRowStyle-CssClass="pgr">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S.No.">
                                                                <ItemTemplate>
                                                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                .
                                                                </ItemTemplate>
                                                                <ItemStyle Width="30px" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="PA03_4A_OTH" HeaderText="Other Works/Duties" />
                                                            <asp:BoundField DataField="PA03_4A_FROM_DATE" HeaderText="From Date" DataFormatString="{0:dd/MM/yyyy}" />
                                                            <asp:BoundField DataField="PA03_4A_TO_DATE" HeaderText="To Date" DataFormatString="{0:dd/MM/yyyy}" />
                                                            <%--<asp:BoundField DataField="PA03_4A_STATUS" HeaderText="Status" />--%>
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
                                                    <div class="heading">
                                                        <h4>
                                                            <asp:Label ID="lblHeader5A" runat="server"></asp:Label>
                                                            <br />
                                                            <asp:Label ID="lblDescription5A" runat="server"></asp:Label>
                                                        </h4>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6">
                                                    <asp:GridView ID="gridData5A" runat="server" AutoGenerateColumns="false" GridLines="Both"
                                                        AllowPaging="false" AlternatingRowStyle-CssClass="alt"
                                                        SelectedRowStyle-CssClass="pgr">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S.No.">
                                                                <ItemTemplate>
                                                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                .
                                                                </ItemTemplate>
                                                                <ItemStyle Width="30px" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="PA03_5A_CLS" HeaderText="Class" />
                                                            <asp:BoundField DataField="PA03_5A_TTL" HeaderText="Title of Project/Dissertations" />
                                                            <asp:BoundField DataField="PA03_5A_STUS" HeaderText="Names of Students" />
                                                            <asp:BoundField DataField="PA03_5A_SPR" HeaderText="Name of other Supervisor (if any)" />
                                                            <asp:BoundField DataField="PA03_5A_RMK" HeaderText="Remarks" />
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
                                                    <div class="heading">
                                                        <h4>
                                                            <asp:Label ID="lblHeader5B" runat="server"></asp:Label>
                                                            <br />
                                                            <asp:Label ID="lblDescription5B" runat="server"></asp:Label>
                                                        </h4>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6">
                                                    <asp:GridView ID="gridData5B" runat="server" AutoGenerateColumns="false" GridLines="Both"
                                                        AllowPaging="false" AlternatingRowStyle-CssClass="alt"
                                                        SelectedRowStyle-CssClass="pgr">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S.No.">
                                                                <ItemTemplate>
                                                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                .
                                                                </ItemTemplate>
                                                                <ItemStyle Width="30px" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="PA03_5B_STU_NAME" HeaderText="Name of Student" />
                                                            <asp:BoundField DataField="PA03_5B_TTL" HeaderText="Thesis Title" />
                                                            <asp:BoundField DataField="PA03_5B_SPR" HeaderText="Other Supervisor(s) (if any)" />
                                                            <asp:BoundField DataField="PA03_5B_REG" HeaderText="Reg. Year" />
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
                                                    <div class="heading">
                                                        <h4>
                                                            <asp:Label ID="lblHeader5C" runat="server"></asp:Label>
                                                            <br />
                                                            <asp:Label ID="lblDescription5C" runat="server"></asp:Label>
                                                        </h4>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6">
                                                    <asp:GridView ID="gridData5C" runat="server" AutoGenerateColumns="false" GridLines="Both"
                                                        AllowPaging="false" AlternatingRowStyle-CssClass="alt"
                                                        SelectedRowStyle-CssClass="pgr">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S.No.">
                                                                <ItemTemplate>
                                                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                .
                                                                </ItemTemplate>
                                                                <ItemStyle Width="30px" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="PA03_5C_AUTH" HeaderText="Authors' Names(Sequence As In Paper)" />
                                                            <asp:BoundField DataField="PA03_5C_TTL" HeaderText="Title of Paper" />
                                                            <asp:BoundField DataField="PA03_5C_VOL" HeaderText="Vol. No." />
                                                            <asp:BoundField DataField="PA03_5C_YEAR" HeaderText="Year" />
                                                            <asp:BoundField DataField="PA03_5C_PAGE" HeaderText="Page Nos" />
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
                                                    <div class="heading">
                                                        <h4>
                                                            <asp:Label ID="lblHeader5D" runat="server"></asp:Label>
                                                            <br />
                                                            <asp:Label ID="lblDescription5D" runat="server"></asp:Label>
                                                        </h4>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6">
                                                    <asp:GridView ID="gridData5D" runat="server" AutoGenerateColumns="false" GridLines="Both"
                                                        AllowPaging="false" AlternatingRowStyle-CssClass="alt"
                                                        SelectedRowStyle-CssClass="pgr">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S.No.">
                                                                <ItemTemplate>
                                                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                .
                                                                </ItemTemplate>
                                                                <ItemStyle Width="30px" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="PA03_5D_AUTH" HeaderText="Authors' Names(Sequence As In Paper)" />
                                                            <asp:BoundField DataField="PA03_5D_TTL" HeaderText="Title of Paper" />
                                                            <asp:BoundField DataField="PA03_5D_CNF" HeaderText="Name of Conference" />
                                                            <asp:BoundField DataField="PA03_5D_PLC" HeaderText="Place" />
                                                            <asp:BoundField DataField="PA03_5D_YEAR" HeaderText="Year" />
                                                            <asp:BoundField DataField="PA03_5D_PAGE" HeaderText="Page Nos'" />
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
                                                    <div class="heading">
                                                        <h4>
                                                            <asp:Label ID="lblHeader5E" runat="server"></asp:Label>
                                                            <br />
                                                            <asp:Label ID="lblDescription5E" runat="server"></asp:Label>
                                                        </h4>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6">
                                                    <asp:GridView ID="gridData5E" runat="server" AutoGenerateColumns="false" GridLines="Both"
                                                        AllowPaging="false" AlternatingRowStyle-CssClass="alt"
                                                        SelectedRowStyle-CssClass="pgr">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S.No.">
                                                                <ItemTemplate>
                                                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                .
                                                                </ItemTemplate>
                                                                <ItemStyle Width="30px" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="PA03_5E_AUTH" HeaderText="Authors' Names(Sequence As In Paper)" />
                                                            <asp:BoundField DataField="PA03_5E_TTL" HeaderText="Title" />
                                                            <asp:BoundField DataField="PA03_5E_PUB" HeaderText="Publisher" />
                                                            <asp:BoundField DataField="PA03_5E_VOL" HeaderText="Vol. No." />
                                                            <asp:BoundField DataField="PA03_5E_YEAR" HeaderText="Year" />
                                                            <asp:BoundField DataField="PA03_5E_PAGE" HeaderText="Page Nos" />
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
                                                    <div class="heading">
                                                        <h4>
                                                            <asp:Label ID="lblHeader6A" runat="server"></asp:Label>
                                                            <br />
                                                            <asp:Label ID="lblDescription6A" runat="server"></asp:Label>
                                                        </h4>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6">
                                                    <asp:GridView ID="gridData6A" runat="server" AutoGenerateColumns="false" GridLines="Both"
                                                        AllowPaging="false" AlternatingRowStyle-CssClass="alt"
                                                        SelectedRowStyle-CssClass="pgr">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S.No.">
                                                                <ItemTemplate>
                                                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                .
                                                                </ItemTemplate>
                                                                <ItemStyle Width="30px" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="PA03_6A_TTL" HeaderText="Title of Project" />
                                                            <asp:BoundField DataField="PA03_6A_FUND" HeaderText="Funding Agency" />
                                                            <asp:BoundField DataField="PA03_6A_FIN" HeaderText="Financial Outlay" />
                                                            <asp:BoundField DataField="PA03_6A_PI" HeaderText="Name Of P.I. and other Investigators" />
                                                            <asp:BoundField DataField="PA03_6A_YEAR" HeaderText="Year" />
                                                            <asp:BoundField DataField="PA03_6A_PRD" HeaderText="Total Peroid (in months)" />
                                                            <asp:BoundField DataField="PA03_PA_STATUS_VALUE" HeaderText="Status" />
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
                                                    <div class="heading">
                                                        <h4>
                                                            <asp:Label ID="lblHeader6B" runat="server"></asp:Label>
                                                            <br />
                                                            <asp:Label ID="lblDescription6B" runat="server"></asp:Label>
                                                        </h4>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6">
                                                    <asp:GridView ID="gridData6B" runat="server" AutoGenerateColumns="false" GridLines="Both"
                                                        AllowPaging="false" AlternatingRowStyle-CssClass="alt"
                                                        SelectedRowStyle-CssClass="pgr">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S.No.">
                                                                <ItemTemplate>
                                                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                .
                                                                </ItemTemplate>
                                                                <ItemStyle Width="30px" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="PA03_6B_TTL" HeaderText="Title of Patent" />
                                                            <asp:BoundField DataField="PA03_6B_MEM" HeaderText="Group Members" />
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
                                                    <div class="heading">
                                                        <h4>
                                                            <asp:Label ID="lblHeader6C" runat="server"></asp:Label>
                                                            <br />
                                                            <asp:Label ID="lblDescription6C" runat="server"></asp:Label>
                                                        </h4>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6">
                                                    <asp:GridView ID="gridData6C" runat="server" AutoGenerateColumns="false" GridLines="Both"
                                                        AllowPaging="false" AlternatingRowStyle-CssClass="alt"
                                                        SelectedRowStyle-CssClass="pgr">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S.No.">
                                                                <ItemTemplate>
                                                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                .
                                                                </ItemTemplate>
                                                                <ItemStyle Width="30px" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="PA03_6C_TTL" HeaderText="Title of Lecture/Lecture Series" />
                                                            <asp:BoundField DataField="PA03_6C_DATE" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy}" />
                                                            <asp:BoundField DataField="PA03_6C_PLC" HeaderText="Place" />
                                                            <asp:BoundField DataField="PA03_6C_PRG" HeaderText="Programme" />
                                                            <asp:BoundField DataField="PA03_6C_OTH" HeaderText="Other Relevant Information" />
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
                                                    <div class="heading">
                                                        <h4>
                                                            <asp:Label ID="lblHeader6D" runat="server"></asp:Label>
                                                            <br />
                                                            <asp:Label ID="lblDescription6D" runat="server"></asp:Label>
                                                        </h4>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6">
                                                    <asp:GridView ID="gridData6D" runat="server" AutoGenerateColumns="false" GridLines="Both"
                                                        AllowPaging="false" AlternatingRowStyle-CssClass="alt"
                                                        SelectedRowStyle-CssClass="pgr">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S.No.">
                                                                <ItemTemplate>
                                                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                .
                                                                </ItemTemplate>
                                                                <ItemStyle Width="30px" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="PA03_6D_TSK" HeaderText="Task Description" />
                                                            <asp:BoundField DataField="PA03_6D_DATE" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy}" />
                                                            <asp:BoundField DataField="PA03_6D_PLC" HeaderText="Place" />
                                                            <asp:BoundField DataField="PA03_6D_PRG" HeaderText="Programme" />
                                                            <asp:BoundField DataField="PA03_6D_OTH" HeaderText="Other Relevant Information" />
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
                                                    <div class="heading">
                                                        <h4>
                                                            <asp:Label ID="lblHeader7A" runat="server"></asp:Label>
                                                            <br />
                                                            <asp:Label ID="lblDescription7A" runat="server"></asp:Label>
                                                        </h4>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6">
                                                    <asp:GridView ID="gridData7A" runat="server" AutoGenerateColumns="false" GridLines="Both"
                                                        AllowPaging="false" AlternatingRowStyle-CssClass="alt"
                                                        SelectedRowStyle-CssClass="pgr">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S.No.">
                                                                <ItemTemplate>
                                                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                .
                                                                </ItemTemplate>
                                                                <ItemStyle Width="30px" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="PA03_7A_DET" HeaderText="Details" />
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table class="entry">
                                            <tr>
                                                <td>
                                                    <div class="heading">
                                                        <h4>
                                                            <asp:Label ID="lblHeader8A" runat="server"></asp:Label>
                                                            <br />
                                                            <asp:Label ID="lblDescription8A" runat="server"></asp:Label>
                                                        </h4>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6">
                                                    <asp:GridView ID="gridData8A" runat="server" AutoGenerateColumns="false" GridLines="Both"
                                                        AllowPaging="false" AlternatingRowStyle-CssClass="alt"
                                                        SelectedRowStyle-CssClass="pgr">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S.No.">
                                                                <ItemTemplate>
                                                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                .
                                                                </ItemTemplate>
                                                                <ItemStyle Width="30px" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="PA03_8A_DET" HeaderText="Details" />
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 100px; vertical-align: top;">
                                        <table class="entry" runat="server" id="tblhODComments">
                                            <tr>
                                                <th style="text-align: left">
                                                    <span style="text-decoration: underline">HODs Comments'</span>
                                                </th>
                                            </tr>
                                            <tr>
                                                <td style="width: 400px; overflow: visible">
                                                    <asp:Label ID="lblHODCOMMENT" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table runat="server" id="tblHOIComments" visible="false">
                                            <tr>
                                                <th style="text-align: left">
                                                    <span style="text-decoration: underline">HOI's Comments'</span>
                                                </th>
                                            </tr>
                                            <tr>
                                                <td style="width: 400px; overflow: visible">
                                                    <asp:Label ID="lblHOIComments" Text="No Comments Available" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>

                                        <asp:GridView ID="gridTechingIndex" runat="server" AutoGenerateColumns="False"
                                            EmptyDataText="No Record Found" Caption="Teaching Index Summary">
                                            <Columns>
                                                <asp:BoundField DataField="STU_COT" HeaderText="Number of Student Present" />
                                                <asp:BoundField DataField="SUB_KNW" HeaderText="Subject Konowledge(0.3)" />
                                                <asp:BoundField DataField="PLANNING" HeaderText="Planning(0.3)" />
                                                <asp:BoundField DataField="COMM" HeaderText="Communication(0.15)" />
                                                <asp:BoundField DataField="CL_CTRL" HeaderText="Class Control(0.15)" />
                                                <asp:BoundField DataField="CON_STU" HeaderText="Concerned for student(0.1)" />
                                                <asp:BoundField DataField="TOTAL" HeaderText="Total" />
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr id="tblLvSmry" runat="server">
                                    <td>
                                        <strong><span style="text-decoration: underline">Leave Summary( 
                                   Institute Average Leave-<asp:Label ID="lblAvg" runat="server"></asp:Label>)</span></strong>
                                        <asp:GridView ID="gvLeave" runat="server" AutoGenerateColumns="False"
                                            EmptyDataText="No Record Found">
                                            <Columns>
                                                <asp:BoundField DataField="LV_VALUE" HeaderText="Leave Name" />
                                                <asp:BoundField DataField="NOD" HeaderText="NOD" />
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:GridView ID="gvStudentFead" runat="server" AutoGenerateColumns="False"
                                            EmptyDataText="No Feedback Recorded" Caption="Student Feedback Summary" CaptionAlign="Left" >
                                            <Columns>
                                                <asp:BoundField HeaderText="YEAR" DataField="PA02_B1_YEAR" />
                                                <asp:BoundField DataField="EVA_SCH_PAPER_CODE" HeaderText="PAPER CODE" />
                                                <asp:BoundField DataField="COURSE" HeaderText="COURSE" />
                                                <asp:BoundField DataField="ACA_SEM_ID" HeaderText="SEMESTER" />
                                                <asp:BoundField DataField="NOS" HeaderText="FEEDBACK STU. NO." />
                                                <asp:BoundField DataField="MARKS" HeaderText="PER(%)" />
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:GridView ID="gvExam" runat="server" AutoGenerateColumns="False" Caption="Examination Detail">
                                            <Columns>
                                                <asp:BoundField DataField="PAPER_CODE" HeaderText="PAPER CODE" />
                                                <asp:BoundField DataField="BRN_NAME" HeaderText="COURSE" />
                                                <asp:BoundField HeaderText="APPEAR" DataField="APPEAR" />
                                                <asp:BoundField HeaderText="PASS" DataField="PASS" />
                                                <asp:BoundField HeaderText="PASS PER(%)" DataField="PASS_PER" />
                                                <asp:BoundField HeaderText="AVG(%)" DataField="AVG_PER" />
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="vertical-align: top">
                                        <hr style="page-break-before: always;visibility:hidden" />
                                        <table style="width: 100%">
                                            <tr>
                                                <td>
                                                    <div class="headerMain">
                                                        Summary Sheet for Faculty Performance Appraisal&nbsp;
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table border="0" style="border-collapse: collapse; padding-left: 10px; width: 97%">
                                                        <tr style="page-break-inside: avoid">
                                                            <td rowspan="3" style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: windowtext 1pt solid; padding-left: 2pt; padding-bottom: 0in; border-left: windowtext 1pt solid; width: 40.5pt; padding-top: 0in; border-bottom: windowtext 1pt solid; background-color: transparent; vertical-align: top; width: 54px">
                                                                <p class="MsoNormal" style="margin: 0in 2.5pt 0pt; text-align: center">
                                                                    <b><span style="font-size: 10pt; font-family: Times New Roman">
                                                                        <?xml namespace="" ns="urn:schemas-microsoft-com:office:office" prefix="o" ?>
                                                                        &nbsp;
                                                                        &nbsp; &nbsp; &nbsp; </span></b>
                                                                </p>
                                                                <p class="MsoNormal" style="margin: 0in 2.5pt 0pt; text-align: center">
                                                                    <b><span style="font-size: 10pt"><span style="font-family: Times New Roman">Sr.No.</span></span></b>
                                                                </p>
                                                            </td>
                                                            <td rowspan="3" style="width: auto; vertical-align: top; border-right: windowtext 1pt solid; padding-right: 2pt; border-top: windowtext 1pt solid; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 2.75in; padding-top: 0in; border-bottom: windowtext 1pt solid; font-family: Times New Roman; background-color: transparent">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt; text-align: center">
                                                                    <b><span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span></b>
                                                                </p>
                                                                <p  class="MsoNormal" style="margin: 0in 0.1in 0pt; text-align: center">
                                                                    <b><span style="font-size: 10pt">Factor of Appraisal</span></b><span
                                                                        style="font-size: 10pt"></span>
                                                                </p>
                                                                <p  class="MsoNormal" style="margin: 0in 0.1in 0pt; text-align: center">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                            </td>
                                                            <td rowspan="3" style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: windowtext 1pt solid; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 85.5pt; padding-top: 0in; border-bottom: windowtext 1pt solid; font-family: Times New Roman; background-color: transparent; vertical-align: top; width: 114px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <b><span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span></b>
                                                                </p>
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <b><span style="font-size: 10pt">Weightage</span></b>
                                                                </p>
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <b><span style="font-size: 10pt">Factor</span></b><span
                                                                        style="font-size: 10pt"></span>
                                                                </p>
                                                            </td>
                                                            <td colspan="6" style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: windowtext 1pt solid; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 265.5pt; padding-top: 0in; border-bottom: windowtext 1pt solid; font-family: Times New Roman; background-color: transparent; vertical-align: top; width: 354px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt; text-align: center">
                                                                    <b><span style="font-size: 10pt">Rating Scale</span></b><span
                                                                        style="font-size: 10pt"></span>
                                                                </p>
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt; text-align: center">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                            </td>
                                                            <td rowspan="3" style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: windowtext 1pt solid; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 58.5pt; padding-top: 0in; border-bottom: windowtext 1pt solid; font-family: Times New Roman; background-color: transparent; vertical-align: top; width: 78px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt; text-align: center">
                                                                    <b><span style="font-size: 10pt">Factor Weights
                                                                    score</span></b><span style="font-size: 10pt"></span>
                                                                </p>
                                                            </td>
                                                        </tr>
                                                        <tr style="font-family: Times New Roman; height: 7.4pt; page-break-inside: avoid">
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 45pt; padding-top: 0in; border-bottom: windowtext 1pt solid; height: 7.4pt; background-color: transparent; vertical-align: top; width: 60px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <b><span style="font-size: 10pt">9-10</span></b><span
                                                                        style="font-size: 10pt"></span>
                                                                </p>
                                                            </td>
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: windowtext 1pt solid; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 58.5pt; padding-top: 0in; border-bottom: windowtext 1pt solid; height: 7.4pt; background-color: transparent; vertical-align: top; width: 78px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <b><span style="font-size: 10pt">7-8</span></b><span
                                                                        style="font-size: 10pt"></span>
                                                                </p>
                                                            </td>
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: windowtext 1pt solid; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 58.5pt; padding-top: 0in; border-bottom: windowtext 1pt solid; height: 7.4pt; background-color: transparent; vertical-align: top; width: 78px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <b><span style="font-size: 10pt">5-6</span></b><span
                                                                        style="font-size: 10pt"></span>
                                                                </p>
                                                            </td>
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: windowtext 1pt solid; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 0.75in; padding-top: 0in; border-bottom: windowtext 1pt solid; height: 7.4pt; background-color: transparent; vertical-align: top; width: 72px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <b><span style="font-size: 10pt">3-4</span></b><span
                                                                        style="font-size: 10pt"></span>
                                                                </p>
                                                            </td>
                                                            <td colspan="2" style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: windowtext 1pt solid; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 49.5pt; padding-top: 0in; border-bottom: windowtext 1pt solid; height: 7.4pt; background-color: transparent; vertical-align: top; width: 66px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <b><span style="font-size: 10pt">1-2</span></b><span
                                                                        style="font-size: 10pt"></span>
                                                                </p>
                                                            </td>
                                                        </tr>
                                                        <tr style="font-family: Times New Roman; page-break-inside: avoid">
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 45pt; padding-top: 0in; border-bottom: windowtext 1pt solid; background-color: transparent; vertical-align: top; width: 60px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <b><span style="font-size: 10pt">High</span></b><span
                                                                        style="font-size: 10pt"></span>
                                                                </p>
                                                            </td>
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 58.5pt; padding-top: 0in; border-bottom: windowtext 1pt solid; background-color: transparent; vertical-align: top; width: 78px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <b><span style="font-size: 10pt">Above Average</span></b><span
                                                                        style="font-size: 10pt"></span>
                                                                </p>
                                                            </td>
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 58.5pt; padding-top: 0in; border-bottom: windowtext 1pt solid; background-color: transparent; vertical-align: top; width: 78px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <b><span style="font-size: 10pt">Average</span></b><span
                                                                        style="font-size: 10pt"></span>
                                                                </p>
                                                            </td>
                                                            <td colspan="2" style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 58.5pt; padding-top: 0in; border-bottom: windowtext 1pt solid; background-color: transparent; vertical-align: top; width: 78px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <b><span style="font-size: 10pt">Below Average</span></b><span
                                                                        style="font-size: 10pt"></span>
                                                                </p>
                                                            </td>
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 45pt; padding-top: 0in; border-bottom: windowtext 1pt solid; background-color: transparent; vertical-align: top; width: 60px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <b><span style="font-size: 10pt">Low</span></b><span
                                                                        style="font-size: 10pt"></span>
                                                                </p>
                                                            </td>
                                                        </tr>
                                                        <tr style="font-family: Times New Roman; page-break-inside: avoid">
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: windowtext 1pt solid; width: 40.5pt; padding-top: 0in; border-bottom: windowtext 1pt solid; background-color: transparent; vertical-align: top; width: 54px">
                                                                <p class="MsoHeader" style="margin: 0in 0.1in 0pt; text-align: center">
                                                                    <b><span style="font-size: 10pt">1.</span></b>
                                                                </p>
                                                            </td>
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 2.75in; padding-top: 0in; border-bottom: windowtext 1pt solid; background-color: transparent; vertical-align: top; width: 264px">
                                                                <p class="MsoNormal" style="margin: 0in 0in 0pt">
                                                                    <b><i><span
                                                                        style="font-size: 10pt">Academic<span> &nbsp; &nbsp; </span>
                                                                        <span>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;</span></span></i></b>
                                                                </p>
                                                                <p class="MsoNormal" style="margin: 0in 0in 0pt">
                                                                    <b><i><span
                                                                        style="font-size: 10pt"><span>&nbsp;</span><span style="color: #c00000">(
                                                                        reference 1c</span>)</span></i></b>
                                                                </p>
                                                            </td>
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 85.5pt; padding-top: 0in; border-bottom: windowtext 1pt solid; background-color: transparent; vertical-align: top; width: 114px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <b><span style="font-size: 10pt">0.50</span></b>
                                                                </p>
                                                            </td>
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 45pt; padding-top: 0in; border-bottom: windowtext 1pt solid; background-color: transparent; vertical-align: top; width: 60px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                            </td>
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 58.5pt; padding-top: 0in; border-bottom: windowtext 1pt solid; background-color: transparent; vertical-align: top; width: 78px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                            </td>
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 58.5pt; padding-top: 0in; border-bottom: windowtext 1pt solid; background-color: transparent; vertical-align: top; width: 78px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt 0in">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                            </td>
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 0.75in; padding-top: 0in; border-bottom: windowtext 1pt solid; background-color: transparent; vertical-align: top; width: 72px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                            </td>
                                                            <td colspan="2" style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 49.5pt; padding-top: 0in; border-bottom: windowtext 1pt solid; background-color: transparent; vertical-align: top; width: 66px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                            </td>
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 58.5pt; padding-top: 0in; border-bottom: windowtext 1pt solid; background-color: transparent; vertical-align: top; width: 78px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt 0in">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                            </td>
                                                        </tr>
                                                        <tr style="font-family: Times New Roman; page-break-inside: avoid">
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: windowtext 1pt solid; width: 40.5pt; padding-top: 0in; border-bottom: windowtext 1pt solid; background-color: transparent; vertical-align: top; width: 54px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt; text-align: center">
                                                                    <b><span style="font-size: 10pt">2.</span></b>
                                                                </p>
                                                            </td>
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 2.75in; padding-top: 0in; border-bottom: windowtext 1pt solid; background-color: transparent; vertical-align: top; width: 264px">
                                                                <p class="MsoNormal" style="margin: 0in 0in 0pt">
                                                                    <b><i><span
                                                                        style="font-size: 10pt">Profession-related contribution</span></i></b>
                                                                </p>
                                                                <p class="MsoNormal" style="margin: 0in 0in 0pt">
                                                                    <b><i><span
                                                                        style="font-size: 10pt"><span>&nbsp;</span><span style="color: #c00000">(reference
                                                                        2a</span>) <span>&nbsp; </span><span>&nbsp;</span></span></i></b>
                                                                </p>
                                                            </td>
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 85.5pt; padding-top: 0in; border-bottom: windowtext 1pt solid; background-color: transparent; vertical-align: top; width: 114px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <b><span style="font-size: 10pt">0.10</span></b>
                                                                </p>
                                                            </td>
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 45pt; padding-top: 0in; border-bottom: windowtext 1pt solid; background-color: transparent; vertical-align: top; width: 60px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                            </td>
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 58.5pt; padding-top: 0in; border-bottom: windowtext 1pt solid; background-color: transparent; vertical-align: top; width: 78px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                            </td>
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 58.5pt; padding-top: 0in; border-bottom: windowtext 1pt solid; background-color: transparent; vertical-align: top; width: 78px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                            </td>
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 0.75in; padding-top: 0in; border-bottom: windowtext 1pt solid; background-color: transparent; vertical-align: top; width: 72px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                            </td>
                                                            <td colspan="2" style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 49.5pt; padding-top: 0in; border-bottom: windowtext 1pt solid; background-color: transparent; vertical-align: top; width: 66px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                            </td>
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 58.5pt; padding-top: 0in; border-bottom: windowtext 1pt solid; background-color: transparent; vertical-align: top; width: 78px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt 0in">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                            </td>
                                                        </tr>
                                                        <tr style="font-family: Times New Roman; page-break-inside: avoid">
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: windowtext 1pt solid; width: 40.5pt; padding-top: 0in; border-bottom: windowtext 1pt solid; background-color: transparent; vertical-align: top; width: 54px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt; text-align: center">
                                                                    <b><span style="font-size: 10pt">2.</span></b>
                                                                </p>
                                                            </td>
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 2.75in; padding-top: 0in; border-bottom: windowtext 1pt solid; background-color: transparent; vertical-align: top; width: 264px">
                                                                <p class="MsoNormal" style="margin: 0in 0in 0pt">
                                                                    <b><i><span
                                                                        style="font-size: 10pt">Co-curricular<span>&nbsp; </span>
                                                                        activities<span> &nbsp; &nbsp; </span>

                                                                    </span></i></b>
                                                                </p>
                                                                <p class="MsoNormal" style="margin: 0in 0in 0pt">
                                                                    <b><i><span
                                                                        style="font-size: 10pt"><span>&nbsp; </span><span style="color: #c00000">(reference<span>&nbsp; </span>2b</span>)</span></i></b>
                                                                </p>
                                                            </td>
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 85.5pt; padding-top: 0in; border-bottom: windowtext 1pt solid; background-color: transparent; vertical-align: top; width: 114px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <b><span style="font-size: 10pt">0.05</span></b>
                                                                </p>
                                                            </td>
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 45pt; padding-top: 0in; border-bottom: windowtext 1pt solid; background-color: transparent; vertical-align: top; width: 60px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                            </td>
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 58.5pt; padding-top: 0in; border-bottom: windowtext 1pt solid; background-color: transparent; vertical-align: top; width: 78px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                            </td>
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 58.5pt; padding-top: 0in; border-bottom: windowtext 1pt solid; background-color: transparent; vertical-align: top; width: 78px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                            </td>
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 0.75in; padding-top: 0in; border-bottom: windowtext 1pt solid; background-color: transparent; vertical-align: top; width: 72px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                            </td>
                                                            <td colspan="2" style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 49.5pt; padding-top: 0in; border-bottom: windowtext 1pt solid; background-color: transparent; vertical-align: top; width: 66px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                            </td>
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 58.5pt; padding-top: 0in; border-bottom: windowtext 1pt solid; background-color: transparent; vertical-align: top; width: 78px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt 0in">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                            </td>
                                                        </tr>
                                                        <tr style="font-family: Times New Roman; page-break-inside: avoid">
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: windowtext 1pt solid; width: 40.5pt; padding-top: 0in; border-bottom: windowtext 1pt solid; background-color: transparent; vertical-align: top; width: 54px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt; text-align: center">
                                                                    <b><span style="font-size: 10pt">3.</span></b>
                                                                </p>
                                                            </td>
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 2.75in; padding-top: 0in; border-bottom: windowtext 1pt solid; background-color: transparent; vertical-align: top; width: 264px">
                                                                <p class="MsoNormal" style="margin: 0in 0in 0pt">
                                                                    <b><i><span
                                                                        style="font-size: 10pt">Extra curricular activities</span></i></b>
                                                                </p>
                                                                <p class="MsoNormal" style="margin: 0in 0in 0pt">
                                                                    <b><i><span
                                                                        style="font-size: 10pt"><span>&nbsp;</span><span style="color: #c00000">(reference
                                                                        2c)</span></span></i></b>
                                                                </p>
                                                            </td>
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 85.5pt; padding-top: 0in; border-bottom: windowtext 1pt solid; background-color: transparent; vertical-align: top; width: 114px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <b><span style="font-size: 10pt">0.05</span></b>
                                                                </p>
                                                            </td>
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 45pt; padding-top: 0in; border-bottom: windowtext 1pt solid; background-color: transparent; vertical-align: top; width: 60px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                            </td>
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 58.5pt; padding-top: 0in; border-bottom: windowtext 1pt solid; background-color: transparent; vertical-align: top; width: 78px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                            </td>
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 58.5pt; padding-top: 0in; border-bottom: windowtext 1pt solid; background-color: transparent; vertical-align: top; width: 78px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                            </td>
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 0.75in; padding-top: 0in; border-bottom: windowtext 1pt solid; background-color: transparent; vertical-align: top; width: 72px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                            </td>
                                                            <td colspan="2" style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 49.5pt; padding-top: 0in; border-bottom: windowtext 1pt solid; background-color: transparent; vertical-align: top; width: 66px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                            </td>
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 58.5pt; padding-top: 0in; border-bottom: windowtext 1pt solid; background-color: transparent; vertical-align: top; width: 78px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt 0in">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                            </td>
                                                        </tr>
                                                        <tr style="font-family: Times New Roman; page-break-inside: avoid">
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: windowtext 1pt solid; width: 40.5pt; padding-top: 0in; border-bottom: windowtext 1pt solid; background-color: transparent; vertical-align: top; width: 54px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt; text-align: center">
                                                                    <b><span style="font-size: 10pt">4.</span></b>
                                                                </p>
                                                            </td>
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 2.75in; padding-top: 0in; border-bottom: windowtext 1pt solid; background-color: transparent; vertical-align: top; width: 264px">
                                                                <p class="MsoNormal" style="margin: 0in 0in 0pt">
                                                                    <b><i><span
                                                                        style="font-size: 10pt">Extension activities<span> &nbsp;
                                                                        </span>

                                                                    </span></i></b>
                                                                </p>
                                                                <p class="MsoNormal" style="margin: 0in 0in 0pt">
                                                                    <b><i><span
                                                                        style="font-size: 10pt"><span>&nbsp;</span><span style="color: #c00000">(
                                                                        reference 2d</span>)</span></i></b>
                                                                </p>
                                                            </td>
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 85.5pt; padding-top: 0in; border-bottom: windowtext 1pt solid; background-color: transparent; vertical-align: top; width: 114px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <b><span style="font-size: 10pt">0.05</span></b>
                                                                </p>
                                                            </td>
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 45pt; padding-top: 0in; border-bottom: windowtext 1pt solid; background-color: transparent; vertical-align: top; width: 60px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                            </td>
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 58.5pt; padding-top: 0in; border-bottom: windowtext 1pt solid; background-color: transparent; vertical-align: top; width: 78px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                            </td>
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 58.5pt; padding-top: 0in; border-bottom: windowtext 1pt solid; background-color: transparent; vertical-align: top; width: 78px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                            </td>
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 0.75in; padding-top: 0in; border-bottom: windowtext 1pt solid; background-color: transparent; vertical-align: top; width: 72px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                            </td>
                                                            <td colspan="2" style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 49.5pt; padding-top: 0in; border-bottom: windowtext 1pt solid; background-color: transparent; vertical-align: top; width: 66px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                            </td>
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 58.5pt; padding-top: 0in; border-bottom: windowtext 1pt solid; background-color: transparent; vertical-align: top; width: 78px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt 0in">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                            </td>
                                                        </tr>
                                                        <tr style="font-family: Times New Roman; page-break-inside: avoid">
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: windowtext 1pt solid; width: 40.5pt; padding-top: 0in; border-bottom: windowtext 1pt solid; background-color: transparent; vertical-align: top; width: 54px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt; text-align: center">
                                                                    <b><span style="font-size: 10pt">6</span></b>
                                                                </p>
                                                            </td>
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 2.75in; padding-top: 0in; border-bottom: windowtext 1pt solid; background-color: transparent; vertical-align: top; width: 264px">
                                                                <p class="MsoNormal" style="margin: 0in 0in 0pt">
                                                                    <b><i><span
                                                                        style="font-size: 10pt">Training and placement activities and/or</span></i></b>
                                                                </p>
                                                                <p class="MsoNormal" style="margin: 0in 0in 0pt">
                                                                    <b><i><span
                                                                        style="font-size: 10pt">Admission related activities</span></i></b>
                                                                </p>
                                                                <p class="MsoNormal" style="margin: 0in 0in 0pt">
                                                                    <b><i><span
                                                                        style="font-size: 10pt"><span>&nbsp;</span><span style="color: #c00000">(reference
                                                                        2e)</span></span></i></b>
                                                                </p>
                                                            </td>
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 85.5pt; padding-top: 0in; border-bottom: windowtext 1pt solid; background-color: transparent; vertical-align: top; width: 114px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <b><span style="font-size: 10pt">0.10</span></b>
                                                                </p>
                                                            </td>
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 45pt; padding-top: 0in; border-bottom: windowtext 1pt solid; background-color: transparent; vertical-align: top; width: 60px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                            </td>
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 58.5pt; padding-top: 0in; border-bottom: windowtext 1pt solid; background-color: transparent; vertical-align: top; width: 78px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                            </td>
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 58.5pt; padding-top: 0in; border-bottom: windowtext 1pt solid; background-color: transparent; vertical-align: top; width: 78px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                            </td>
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 0.75in; padding-top: 0in; border-bottom: windowtext 1pt solid; background-color: transparent; vertical-align: top; width: 72px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                            </td>
                                                            <td colspan="2" style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 49.5pt; padding-top: 0in; border-bottom: windowtext 1pt solid; background-color: transparent; vertical-align: top; width: 66px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                            </td>
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 58.5pt; padding-top: 0in; border-bottom: windowtext 1pt solid; background-color: transparent; vertical-align: top; width: 78px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt 0in">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                            </td>
                                                        </tr>
                                                        <tr style="font-family: Times New Roman; page-break-inside: avoid">
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: windowtext 1pt solid; width: 40.5pt; padding-top: 0in; border-bottom: windowtext 1pt solid; background-color: transparent; vertical-align: top; width: 54px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt; text-align: center">
                                                                    <b><span style="font-size: 10pt">7.</span></b>
                                                                </p>
                                                            </td>
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 2.75in; padding-top: 0in; border-bottom: windowtext 1pt solid; background-color: transparent; vertical-align: top; width: 264px">
                                                                <p class="MsoNormal" style="margin: 0in 0in 0pt">
                                                                    <b><i><span
                                                                        style="font-size: 10pt">Awards&nbsp;<span> </span>/Distinctions
                                                                    /Honors</span></i></b>
                                                                </p>
                                                                <p class="MsoNormal" style="margin: 0in 0in 0pt">
                                                                    <b><i><span
                                                                        style="font-size: 10pt"><span>&nbsp;</span></span></i></b><b><i><span
                                                                            style="font-size: 10pt; color: #c00000">(reference 3)</span></i></b>
                                                                </p>
                                                            </td>
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 85.5pt; padding-top: 0in; border-bottom: windowtext 1pt solid; background-color: transparent; vertical-align: top; width: 114px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <b><span style="font-size: 10pt">0.05</span></b>
                                                                </p>
                                                            </td>
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 45pt; padding-top: 0in; border-bottom: windowtext 1pt solid; background-color: transparent; vertical-align: top; width: 60px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                            </td>
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 58.5pt; padding-top: 0in; border-bottom: windowtext 1pt solid; background-color: transparent; vertical-align: top; width: 78px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                            </td>
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 58.5pt; padding-top: 0in; border-bottom: windowtext 1pt solid; background-color: transparent; vertical-align: top; width: 78px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                            </td>
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 0.75in; padding-top: 0in; border-bottom: windowtext 1pt solid; background-color: transparent; vertical-align: top; width: 72px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                            </td>
                                                            <td colspan="2" style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 49.5pt; padding-top: 0in; border-bottom: windowtext 1pt solid; background-color: transparent; vertical-align: top; width: 66px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                            </td>
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 58.5pt; padding-top: 0in; border-bottom: windowtext 1pt solid; background-color: transparent; vertical-align: top; width: 78px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt 0in">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                            </td>
                                                        </tr>
                                                        <tr style="font-family: Times New Roman; height: 20.65pt; page-break-inside: avoid">
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: windowtext 1pt solid; width: 40.5pt; padding-top: 0in; border-bottom: windowtext 1pt solid; height: 20.65pt; background-color: transparent; vertical-align: top; width: 54px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt; text-align: center">
                                                                    <b><span style="font-size: 10pt">8.</span></b>
                                                                </p>
                                                            </td>
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 2.75in; padding-top: 0in; border-bottom: windowtext 1pt solid; height: 20.65pt; background-color: transparent; vertical-align: top; width: 264px">
                                                                <p class="MsoNormal" style="margin: 0in 0in 0pt">
                                                                    <b><i><span
                                                                        style="font-size: 10pt">Research and Development Activities<span>
                                                                        &nbsp; &nbsp;</span><span>&nbsp; &nbsp;</span></span></i></b>
                                                                </p>
                                                                <p class="MsoNormal" style="margin: 0in 0in 0pt">
                                                                    <b><i><span
                                                                        style="font-size: 10pt"><span>&nbsp;</span><span style="color: #c00000">(references<span>&nbsp; </span>5 and 6)</span></span></i></b>
                                                                </p>
                                                            </td>
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 85.5pt; padding-top: 0in; border-bottom: windowtext 1pt solid; height: 20.65pt; background-color: transparent; vertical-align: top; width: 114px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <b><span style="font-size: 10pt">0.10</span></b>
                                                                </p>
                                                            </td>
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 45pt; padding-top: 0in; border-bottom: windowtext 1pt solid; height: 20.65pt; background-color: transparent; vertical-align: top; width: 60px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                            </td>
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 58.5pt; padding-top: 0in; border-bottom: windowtext 1pt solid; height: 20.65pt; background-color: transparent; vertical-align: top; width: 78px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                            </td>
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 58.5pt; padding-top: 0in; border-bottom: windowtext 1pt solid; height: 20.65pt; background-color: transparent; vertical-align: top; width: 78px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                            </td>
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 0.75in; padding-top: 0in; border-bottom: windowtext 1pt solid; height: 20.65pt; background-color: transparent; vertical-align: top; width: 72px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                            </td>
                                                            <td colspan="2" style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 49.5pt; padding-top: 0in; border-bottom: windowtext 1pt solid; height: 20.65pt; background-color: transparent; vertical-align: top; width: 66px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                            </td>
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 58.5pt; padding-top: 0in; border-bottom: windowtext 1pt solid; height: 20.65pt; background-color: transparent; vertical-align: top; width: 78px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt 0in">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                            </td>
                                                        </tr>
                                                        <tr style="font-family: Times New Roman; height: 17.05pt; page-break-inside: avoid">
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: windowtext 1pt solid; width: 40.5pt; padding-top: 0in; border-bottom: windowtext 1pt solid; height: 17.05pt; background-color: transparent; vertical-align: top; width: 54px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt; text-align: center">
                                                                    <b><span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span></b>
                                                                </p>
                                                            </td>
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 2.75in; padding-top: 0in; border-bottom: windowtext 1pt solid; height: 17.05pt; background-color: transparent; vertical-align: top; width: 264px">
                                                                <p class="MsoNormal" style="margin: 0in 0in 0pt">
                                                                    <b><i><span
                                                                        style="font-size: 10pt; color: #c00000">&nbsp; &nbsp; &nbsp; </span></i></b>
                                                                </p>
                                                            </td>
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 85.5pt; padding-top: 0in; border-bottom: windowtext 1pt solid; height: 17.05pt; background-color: transparent; vertical-align: top; width: 114px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <b><span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span></b>
                                                                </p>
                                                            </td>
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 45pt; padding-top: 0in; border-bottom: windowtext 1pt solid; height: 17.05pt; background-color: transparent; vertical-align: top; width: 60px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                            </td>
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 58.5pt; padding-top: 0in; border-bottom: windowtext 1pt solid; height: 17.05pt; background-color: transparent; vertical-align: top; width: 78px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                            </td>
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 58.5pt; padding-top: 0in; border-bottom: windowtext 1pt solid; height: 17.05pt; background-color: transparent; vertical-align: top; width: 78px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                            </td>
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 0.75in; padding-top: 0in; border-bottom: windowtext 1pt solid; height: 17.05pt; background-color: transparent; vertical-align: top; width: 72px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                            </td>
                                                            <td colspan="2" style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 49.5pt; padding-top: 0in; border-bottom: windowtext 1pt solid; height: 17.05pt; background-color: transparent; vertical-align: top; width: 66px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                            </td>
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 58.5pt; padding-top: 0in; border-bottom: windowtext 1pt solid; height: 17.05pt; background-color: transparent; vertical-align: top; width: 78px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt 0in">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                            </td>
                                                        </tr>
                                                        <tr style="font-family: Times New Roman; height: 21.55pt; page-break-inside: avoid;">
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: windowtext 1pt solid; width: 40.5pt; padding-top: 0in; border-bottom: windowtext 1pt solid; height: 21.55pt; background-color: transparent; vertical-align: top; width: 54px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt; text-align: center">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                            </td>
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 2.75in; padding-top: 0in; border-bottom: windowtext 1pt solid; height: 21.55pt; background-color: transparent; vertical-align: top; width: 264px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                            </td>
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 85.5pt; padding-top: 0in; border-bottom: windowtext 1pt solid; height: 21.55pt; background-color: transparent; vertical-align: top; width: 114px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt 0in">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                            </td>
                                                            <td colspan="6" style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 265.5pt; padding-top: 0in; border-bottom: windowtext 1pt solid; height: 21.55pt; background-color: transparent; vertical-align: top; width: 354px">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt">
                                                                    <b><span style="font-size: 10pt">Overall Rating
                                                                    Score (On 10 point scale)</span></b><span style="font-size: 10pt"></span>
                                                                </p>
                                                            </td>
                                                            <td style="border-right: windowtext 1pt solid; padding-right: 2pt; border-top: #d4d0c8; padding-left: 2pt; padding-bottom: 0in; border-left: #d4d0c8; width: 58.5pt; padding-top: 0in; border-bottom: windowtext 1pt solid; height: 21.55pt; background-color: transparent; /*vertical-align: top; width: 78px*/">
                                                                <p class="MsoNormal" style="margin: 0in 0.1in 0pt 0in">
                                                                    <span style="font-size: 10pt">&nbsp; &nbsp; &nbsp; </span>
                                                                </p>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
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
