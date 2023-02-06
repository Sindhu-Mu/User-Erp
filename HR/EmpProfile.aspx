<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="EmpProfile.aspx.cs" Inherits="HR_EmpProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="heading">
            <h2>Employee Profile</h2>
        </div>
        <div>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <table style="width: 90%; margin: 0 auto">
                        <tr>
                            <td align="right" colspan="2">
                                <table>
                                    <tr>
                                        <th>
                                            <asp:TextBox ID="txtCode" runat="server" Width="250px" placeholder="Enter Employee Name or Code"></asp:TextBox></th>
                                        <td>
                                            <asp:Button ID="btnViewDetail" runat="server" OnClick="btnView_Click" Text="View" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <table>
                                    <tr>
                                        <td style="width: 100px">
                                            <table>
                                                <tr>
                                                    <td style="padding-top: 4px">
                                                        <img id="imgPicture" runat="server" alt="Upload Image" style="width:100px;height:120px;" border="0" src="../images/emp_images/empImage.jpg" />

                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: center">
                                                        <asp:Label ID="lblStatus" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr id="trRelvd" runat="server" visible="false">
                                                    <td>
                                                        <asp:Label ID="lblRlvd" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>

                                        <td>
                                            <table>
                                                <tr>
                                                    <td style="width: 320px">
                                                        <h4>Personal Information</h4>
                                                    </td>
                                                    <td></td>
                                                    <%--<td>
                                                        <asp:Button ID="btnModPI" Text="Edit" runat="server" Width="59px" OnClick="btnModPI_Click" Visible="false" />
                                                    </td>--%>
                                                </tr>
                                                <tr>
                                                    <td style="width: 320px">
                                                        <table>
                                                            <tr>
                                                                <th>Name: </th>
                                                                <td>
                                                                    <asp:Label ID="lblName" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th>Father's Name: </th>
                                                                <td>
                                                                    <asp:Label ID="lblfName" runat="server"></asp:Label>
                                                                </td>

                                                            </tr>
                                                            <tr>
                                                                <th>Marital Status: </th>
                                                                <td>
                                                                    <asp:Label ID="lblMarSts" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th>Spouse Name: </th>
                                                                <td>
                                                                    <asp:Label ID="lblSpsName" runat="server"></asp:Label>
                                                                </td>

                                                            </tr>
                                                            <tr>
                                                                <th>Religion: </th>
                                                                <td>
                                                                    <asp:Label ID="lblRel" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th>Next Kin: </th>
                                                                <td>
                                                                    <asp:Label ID="lblNxtKin" runat="server"></asp:Label>
                                                                </td>

                                                            </tr>

                                                        </table>
                                                    </td>
                                                    <td>
                                                        <table>
                                                            <tr>
                                                                <th>Date Of Birth: </th>
                                                                <td>
                                                                    <asp:Label ID="lblDob" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th>Caste: </th>
                                                                <td>
                                                                    <asp:Label ID="lblCaste" runat="server"></asp:Label>
                                                                </td>

                                                            </tr>
                                                            <tr>
                                                                <th>Mother Tongue: </th>
                                                                <td>
                                                                    <asp:Label ID="lblMthrTongue" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <%--<tr>
                                                    <th>Birth Place: </th>
                                                    <td>
                                                        <asp:Label ID="lblBrthPlace" runat="server"></asp:Label>
                                                    </td>

                                                </tr>--%>
                                                            <tr>
                                                                <th>Blood Group: </th>
                                                                <td>
                                                                    <asp:Label ID="lblBldGroup" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <th>Nationality: </th>
                                                                <td>
                                                                    <asp:Label ID="lblNationality" runat="server"></asp:Label>
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
                        <tr>
                            <td colspan="2">
                                <hr style="color: #ff8c00; width: 100%; height: 0px; border-bottom-color: red; border-bottom-width: 1px; border-collapse: collapse; border-spacing: 0px;" />
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                        </tr>
                        <tr>
                            <td></td>
                        </tr>
                        <tr>
                            <td></td>
                        </tr>
                        <tr>
                            <td></td>
                        </tr>

                        <tr>
                            <td colspan="2">
                                <h4>Official Information</h4>
                            </td>

                        </tr>
                        <tr>
                            <td style="vertical-align: top; min-width: 400px">
                                <table>
                                    <tr>
                                        <th style="text-align: center">Designation</th>
                                    </tr>
                                    <tr>
                                        <td style="vertical-align: top; min-width: 400px">
                                            <asp:GridView ID="gvDes" runat="server" AutoGenerateColumns="False" CssClass="gridDynamic" EmptyDataText="No Record Found" Style="max-width: 400px">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S#">
                                                        <ItemTemplate>
                                                            <%# ((GridViewRow)Container).RowIndex + 1%>.
                                                        </ItemTemplate>
                                                        <ItemStyle Width="10px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="DES_VALUE" HeaderText="Designation" ItemStyle-Width="50px" />
                                                    <asp:BoundField HeaderText="From Date" DataField="FRM_DATE" DataFormatString="{0:dd/MM/yyyy}" />
                                                    <asp:BoundField HeaderText="To Date" DataField="TO_DATE" DataFormatString="{0:dd/MM/yyyy}" />
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th style="text-align: center">Department
                                        </th>
                                    </tr>
                                    <tr>
                                        <td style="vertical-align: top">
                                            <asp:GridView ID="gvDept" runat="server" AutoGenerateColumns="False" CssClass="gridDynamic" EmptyDataText="No Record Found" Style="max-width: 400px">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S#">
                                                        <ItemTemplate>
                                                            <%# ((GridViewRow)Container).RowIndex + 1%>.
                                                        </ItemTemplate>
                                                        <ItemStyle Width="10px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="DEPT_VALUE" HeaderText="Department" ItemStyle-Width="50px" />
                                                    <asp:BoundField HeaderText="From Date" DataField="FRM_DATE" DataFormatString="{0:dd/MM/yyyy}" />
                                                    <asp:BoundField HeaderText="To Date" DataField="TO_DATE" DataFormatString="{0:dd/MM/yyyy}" />
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td style="width: 273px; vertical-align: top">
                                <table>
                                    <tr>
                                        <th>Code No.: </th>
                                        <td>
                                            <asp:Label ID="lblCode" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>Date Of Joining: </th>
                                        <td>
                                            <asp:Label ID="lblDOJ" runat="server"></asp:Label>
                                        </td>

                                    </tr>
                                    <tr>
                                        <th style="vertical-align: top">Next Senior: </th>
                                        <td>
                                            <asp:Label ID="lblNxtSenior" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>Job Type:
                                        </th>
                                        <td>
                                            <asp:Label ID="lblJob" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>Service Type:
                                        </th>
                                        <td>
                                            <asp:Label ID="lblServType" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>Institution: </th>
                                        <td>
                                            <asp:Label ID="lblIns" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>Shift: </th>
                                        <td>
                                            <asp:Label ID="lblShift" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>Week Off: </th>
                                        <td>
                                            <asp:Label ID="lblWeekOff" runat="server"></asp:Label>
                                        </td>

                                    </tr>
                                    <tr>
                                        <th>Employment Type:
                                        </th>
                                        <td>
                                            <asp:Label ID="lblEmpType" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>

                        </tr>


                        <%--<tr>
                            <td colspan="2">
                                <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" AutoPostBack="true" OnActiveTabChanged="step1_ActiveTabChanged">
                                    <ajaxToolkit:TabPanel runat="server" HeaderText="Depatment" ID="TabPanel4">
                                        <ContentTemplate>
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:GridView ID="gvDept" runat="server" AutoGenerateColumns="False" CssClass="gridDynamic" EmptyDataText="No Record Found">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="S#">
                                                                            <ItemTemplate>
                                                                                <%# ((GridViewRow)Container).RowIndex + 1%>.
                                                                            </ItemTemplate>
                                                                            <ItemStyle Width="10px" />
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField DataField="DEPT_VALUE" HeaderText="Department" />
                                                                        <asp:BoundField HeaderText="From Date" DataField="FRM_DATE" />
                                                                        <asp:BoundField HeaderText="To Date" DataField="TO_DATE" />
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </ContentTemplate>
                                    </ajaxToolkit:TabPanel>
                                    <ajaxToolkit:TabPanel runat="server" HeaderText="Designation" ID="TabPanel5">
                                        <ContentTemplate>
                                            <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:GridView ID="gvDes" runat="server" AutoGenerateColumns="False" CssClass="gridDynamic" EmptyDataText="No Record Found">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="S#">
                                                                            <ItemTemplate>
                                                                                <%# ((GridViewRow)Container).RowIndex + 1%>.
                                                                            </ItemTemplate>
                                                                            <ItemStyle Width="10px" />
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField DataField="DES_VALUE" HeaderText="Designation" />
                                                                        <asp:BoundField HeaderText="From Date" DataField="FRM_DATE" />
                                                                        <asp:BoundField HeaderText="To Date" DataField="TO_DATE" />
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </ContentTemplate>
                                    </ajaxToolkit:TabPanel>
                                </ajaxToolkit:TabContainer>
                            </td>
                        </tr>--%>
                        <tr>
                            <td colspan="2">
                                <hr style="color: #ff8c00; width: 100%; height: 0px; border-bottom-color: red; border-bottom-width: 1px; border-collapse: collapse; border-spacing: 0px;" />
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                        </tr>
                        <tr>
                            <td></td>
                        </tr>
                        <tr>
                            <td></td>
                        </tr>
                        <tr>
                            <td></td>
                        </tr>
                        <tr>
                            <td>
                                <h4>Address Information</h4>
                            </td>
                            <td>
                                <h4>Communication Information</h4>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 273px; vertical-align: top">
                                <table>
                                    <tr>
                                        <th>Present Address: </th>
                                        <td>
                                            <asp:Label ID="lblPrsntAdd" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>Permanent Address: </th>
                                        <td>
                                            <asp:Label ID="lblPrmntAdd" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td style="width: 273px">
                                <table>
                                    <tr>
                                        <th>EMail.: </th>
                                        <td>
                                            <asp:Label ID="lblEmail" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>Personal Email
                                        </th>
                                        <td>
                                            <asp:Label ID="lblPerEmail" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>Extension: </th>
                                        <td>
                                            <asp:Label ID="lblPhn" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>Mobile: </th>
                                        <td>
                                            <asp:Label ID="lblMob" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <hr style="color: #ff8c00; width: 100%; height: 0px; border-bottom-color: red; border-bottom-width: 1px; border-collapse: collapse; border-spacing: 0px;" />
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                        </tr>
                        <tr>
                            <td></td>
                        </tr>
                        <tr>
                            <td></td>
                        </tr>
                        <tr>
                            <td></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <h4>Account Information</h4>
                            </td>

                        </tr>

                        <tr>
                            <td style="width: 300px">
                                <table>
                                    <tr>
                                        <th>Bank Name:
                                        </th>
                                        <td>
                                            <asp:Label ID="lblBank" runat="server"></asp:Label>
                                        </td>

                                    </tr>
                                    <tr>
                                        <th>PAN No.:</th>
                                        <td>
                                            <asp:Label ID="lblPAN" runat="server"></asp:Label></td>
                                    </tr>
                                </table>
                            </td>
                            <td style="vertical-align: top">
                                <table>
                                    <tr>
                                        <th>Bank Account:
                                        </th>
                                        <td>
                                            <asp:Label ID="lblAccNo" runat="server"></asp:Label>
                                        </td>


                                    </tr>
                                    <tr>
                                        <th>Aadhar No.:
                                        </th>
                                        <td>
                                            <asp:Label ID="lblAdhar" runat="server"></asp:Label>
                                        </td>


                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <hr style="color: #ff8c00; width: 100%; height: 0px; border-bottom-color: red; border-bottom-width: 1px; border-collapse: collapse; border-spacing: 0px;" />
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                        </tr>
                        <tr>
                            <td></td>
                        </tr>
                        <tr>
                            <td></td>
                        </tr>
                        <tr>
                            <td></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <h4>Document/Qualification/Experience Information</h4>
                            </td>

                        </tr>

                        <tr>
                            <td colspan="2">
                                <asp:UpdatePanel ID="upTab" runat="server">
                                    <ContentTemplate>
                                        <ajaxToolkit:TabContainer ID="step1" runat="server" ActiveTabIndex="0" AutoPostBack="true" OnActiveTabChanged="step1_ActiveTabChanged">
                                            <ajaxToolkit:TabPanel runat="server" HeaderText="Document Information" ID="TabPanel1">
                                                <ContentTemplate>
                                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                                                        <ContentTemplate>
                                                            <asp:GridView ID="gvDocument" runat="server" AutoGenerateColumns="False" CssClass="gridDynamic" EmptyDataText="No Record Found" Width="400px">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="S#">
                                                                        <ItemTemplate>
                                                                            <%# ((GridViewRow)Container).RowIndex + 1%>.
                                                                        </ItemTemplate>
                                                                        <ItemStyle Width="10px" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="DOC_NAME" HeaderText="Document Name" />
                                                                    <asp:BoundField HeaderText="Document Status" DataField="DOC_STS" />
                                                                    <asp:BoundField HeaderText="Remark" DataField="DOC_REMARK" />
                                                                </Columns>
                                                            </asp:GridView>

                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>





                                                </ContentTemplate>




                                            </ajaxToolkit:TabPanel>
                                            <ajaxToolkit:TabPanel runat="server" HeaderText="Qualification Information" ID="TabPanel2">
                                                <ContentTemplate>
                                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                                                        <ContentTemplate>
                                                            <asp:GridView ID="gvQualification" runat="server" AutoGenerateColumns="False" EmptyDataText="No record found" CssClass="gridDynamic">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="S#">
                                                                        <ItemTemplate>
                                                                            <%# ((GridViewRow)Container).RowIndex + 1%>.
                                                                        </ItemTemplate>
                                                                        <ItemStyle Width="10px" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField HeaderText="Division" DataField="ACA_DIV_VALUE" />
                                                                    <asp:BoundField HeaderText="Qualification" DataField="ACA_CRS_VALUE" />
                                                                    <asp:BoundField HeaderText="School/College" DataField="SCH" />
                                                                    <asp:BoundField HeaderText="Board/University" DataField="ACA_BRD_SHORT_NAME" />
                                                                    <asp:BoundField HeaderText="Passing Year" DataField="YER" />
                                                                    <asp:BoundField HeaderText="(%)Marks" DataField="PRSNT" />
                                                                </Columns>

                                                            </asp:GridView>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>

                                                </ContentTemplate>




                                            </ajaxToolkit:TabPanel>
                                            <ajaxToolkit:TabPanel runat="server" HeaderText="Experience Information" ID="TabPanel3">
                                                <ContentTemplate>
                                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                                                        <ContentTemplate>
                                                            <table>
                                                                <tr>
                                                                    <td style="grid-row-align: center">
                                                                        <asp:GridView ID="gvExprience" runat="server" AutoGenerateColumns="False" EmptyDataText="No record found" CssClass="gridDynamic" Caption="Detail">
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="S#">
                                                                                    <ItemTemplate>
                                                                                        <%# ((GridViewRow)Container).RowIndex + 1%>.
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle Width="10px" />
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField DataField="ORG_NAME" HeaderText="Organization" />
                                                                                <asp:BoundField DataField="EXP_DESIG" HeaderText="Designation" />
                                                                                <asp:BoundField DataField="FRM_DATE" DataFormatString="{0:dd/MM/yyyy}" HeaderText="From" />
                                                                                <asp:BoundField DataField="TO_DATE" DataFormatString="{0:dd/MM/yyyy}" HeaderText="To" />
                                                                                <asp:BoundField DataField="EXP_TYPE_VALUE" HeaderText="Type" />
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                        <asp:GridView ID="gvExpCount" runat="server" AutoGenerateColumns="False" EmptyDataText="No record found" CssClass="gridDynamic" Caption="Count" Width="200px">
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="S#">
                                                                                    <ItemTemplate>
                                                                                        <%# ((GridViewRow)Container).RowIndex + 1%>.
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle Width="10px" />
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField DataField="EXP_TYPE_VALUE" HeaderText="Exp.Type" />
                                                                                <asp:BoundField DataField="EXPERIENCE" HeaderText="Months" />
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>

                                                </ContentTemplate>




                                            </ajaxToolkit:TabPanel>
                                        </ajaxToolkit:TabContainer>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <td>
                                    <ajaxToolkit:AutoCompleteExtender ID="autoComplete1" runat="server" CompletionInterval="500"
                                        CompletionSetCount="12" ContextKey="1,2,3,4,0" EnableCaching="true" MinimumPrefixLength="1"
                                        ServiceMethod="GetEmployeeList" ServicePath="~\AutoComplete.asmx" TargetControlID="txtCode">
                                    </ajaxToolkit:AutoCompleteExtender>
                                </td>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <hr style="color: #ff8c00; width: 100%; height: 0px; border-bottom-color: red; border-bottom-width: 1px; border-collapse: collapse; border-spacing: 0px;" />
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                        </tr>
                        <tr>
                            <td></td>
                        </tr>
                        <tr>
                            <td></td>
                        </tr>
                        <tr>
                            <td></td>
                        </tr>
                        <tr>
                            <td>
                                <h4>Attendance</h4>
                            </td>
                            <td>
                                <h4>EOL</h4>
                            </td>
                        </tr>
                        <tr>
                            <td style="max-width: 300px">
                                <asp:GridView ID="gvAtt" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic">
                                    <Columns>
                                        <asp:TemplateField HeaderText="S#">
                                            <ItemTemplate>
                                                <%# ((GridViewRow)Container).RowIndex + 1%>.
                                            </ItemTemplate>
                                            <ItemStyle Width="10px" />
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Month" DataField="MonthNm">
                                            <ItemStyle Width="30px" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Year" DataField="ATT_YEAR">
                                            <ItemStyle Width="30px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Present" HeaderText="Present/On Leave">
                                            <ItemStyle Width="20px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Absent" HeaderText="Absent">
                                            <ItemStyle Width="20px" />
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                            <td style="width: 273px; vertical-align: top">
                                <table>
                                    <tr>
                                        <td style="vertical-align: top">
                                            <asp:GridView ID="gvEOL" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" EmptyDataText="No Record Found" Width="400px">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S#">
                                                        <ItemTemplate>
                                                            <%# ((GridViewRow)Container).RowIndex + 1%>.
                                                        </ItemTemplate>
                                                        <ItemStyle Width="10px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField HeaderText="From Date" DataField="FROM_DT" DataFormatString="{0:dd/MM/yyyy}">
                                                        <ItemStyle Width="30px" Wrap="false" VerticalAlign="Top" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="To Date" DataField="TO_DT" DataFormatString="{0:dd/MM/yyyy}">
                                                        <ItemStyle Width="30px" Wrap="false" VerticalAlign="Top" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="TOT_DAYS" HeaderText="Total">
                                                        <ItemStyle Width="20px" Wrap="false" VerticalAlign="Top" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="REASON" HeaderText="Reason">
                                                        <ItemStyle Width="100px" />
                                                    </asp:BoundField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>

                                    </tr>
                                </table>
                            </td>
                        </tr>

                    </table>
                </ContentTemplate>
                <%-- <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
                </Triggers>--%>
            </asp:UpdatePanel>
            <table>
                <tr>
                    <td>
                        <table>
                            <tr>
                                <th>Browse Photograph</th>
                            </tr>
                            <tr>
                                <td>
                                    <input type="file" id="flPhoto" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

