<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Short.master" AutoEventWireup="true" CodeFile="EmpJoiningInfo.aspx.cs" Inherits="Common_Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentHolder1" runat="Server">
    <div class="container">
        <div class="heading">
            <h2>Employee Profile</h2>
        </div>
        <div>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td align="right" colspan="2">
                                <table>
                                    <tr>
                                        <th>Employee<asp:TextBox ID="txtCode" runat="server" Width="250px"></asp:TextBox></th>
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
                                                        <img id="imgPicture" runat="server" alt="Upload Image" border="0" src="../images/emp_images/empImage.jpg" />

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
                                                    <td>
                                                        <asp:Button ID="btnModPI" Text="Edit" runat="server" Width="59px" OnClick="btnModPI_Click" Visible="false" />
                                                    </td>
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
                                <h4>Departmental Information</h4>
                            </td>

                        </tr>
                        <tr>
                            <td style="width: 273px">
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
                                        <th>Next Senior: </th>
                                        <td>
                                            <asp:Label ID="lblNxtSenior" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <table>
                                    <tr>
                                        <th>Designation: </th>
                                        <td>
                                            <asp:Label ID="lblDes" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>Department: </th>
                                        <td>
                                            <asp:Label ID="lblDept" runat="server"></asp:Label>
                                        </td>

                                    </tr>
                                    <tr>
                                        <th>Institution: </th>
                                        <td>
                                            <asp:Label ID="lblIns" runat="server"></asp:Label>
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
                                <h4>Address Information</h4>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 273px">
                                <table>
                                    <tr>
                                        <th>Present Address: </th>

                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblPrsntAdd" runat="server"></asp:Label>
                                        </td>
                                    </tr>


                                </table>
                            </td>
                            <td>
                                <table>
                                    <tr>
                                        <th>Permanent Address: </th>

                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblPrmntAdd" runat="server"></asp:Label>
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
                                <h4>Communication Information</h4>
                            </td>

                        </tr>
                        <tr>
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
                                        <th>Phone/Extension: </th>
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
                                <h4>Payroll Information</h4>
                            </td>

                        </tr>

                        <tr>
                            <td style="width: 300px">
                                <table>
                                    <%--<tr>
                                        <th>PaySlip For:
                                        </th>
                                        <td>
                                            <asp:DropDownList ID="ddlMM" runat="server" CssClass="txtom" Font-Names="Tahoma"
                                                Font-Size="11px">
                                                <asp:ListItem Value="1">Jan</asp:ListItem>
                                                <asp:ListItem Value="2">Feb</asp:ListItem>
                                                <asp:ListItem Value="3">Mar</asp:ListItem>
                                                <asp:ListItem Value="4">Apr</asp:ListItem>
                                                <asp:ListItem Value="5">May</asp:ListItem>
                                                <asp:ListItem Value="6">Jun</asp:ListItem>
                                                <asp:ListItem Value="7">Jul</asp:ListItem>
                                                <asp:ListItem Value="8">Aug</asp:ListItem>
                                                <asp:ListItem Value="9">Sep</asp:ListItem>
                                                <asp:ListItem Value="10">Oct</asp:ListItem>
                                                <asp:ListItem Value="11">Nov</asp:ListItem>
                                                <asp:ListItem Value="12">Dec</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlYear" runat="server"></asp:DropDownList>

                                        </td>
                                        <td>
                                            <asp:Button ID="btnView" runat="server" OnClick="btnView_Click" Text="View" /></td>
                                    </tr>--%>

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


                                <ajaxToolkit:TabContainer ID="step1" runat="server" ActiveTabIndex="0" AutoPostBack="true" OnActiveTabChanged="step1_ActiveTabChanged">
                                    <ajaxToolkit:TabPanel runat="server" HeaderText="Document Information" ID="TabPanel1">
                                        <ContentTemplate>
                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:GridView ID="gvDocument" runat="server" AutoGenerateColumns="False" CssClass="gridDynamic" EmptyDataText="No Record Found">
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
                                                            </td>
                                                        </tr>
                                                    </table>
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
                                                    <asp:GridView ID="gvExprience" runat="server" AutoGenerateColumns="False" EmptyDataText="No record found" CssClass="gridDynamic">
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
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </ContentTemplate>
                                    </ajaxToolkit:TabPanel>
                                </ajaxToolkit:TabContainer>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <td>
                                    <ajaxToolkit:AutoCompleteExtender ID="autoComplete1" runat="server" CompletionInterval="500"
                                        CompletionSetCount="12" ContextKey="1,2,3,0" EnableCaching="true" MinimumPrefixLength="1"
                                        ServiceMethod="GetEmployeeList" ServicePath="~\AutoComplete.asmx" TargetControlID="txtCode">
                                    </ajaxToolkit:AutoCompleteExtender>
                                </td>
                            </td>
                        </tr>
                    </table>

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

