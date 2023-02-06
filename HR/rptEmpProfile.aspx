<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="rptEmpProfile.aspx.cs" Inherits="HR_rptEmpProfile" %>

<%@ Register Src="../Control/MonthYear.ascx" TagName="MonthYear" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <script lang="javascript" type="text/javascript">
        function CheckControl(ctrl) {
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == ".") {
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
                return false;
            }
            else
                document.getElementById(ctrl).style.backgroundColor = "#fff";
            return true;
        }
        function Validation() {
            var flag = true;
            var msg = "", ctrl = "";

            if (!CheckControl("<%=ddlIns.ClientID%>")) {
                msg += " * Select Institute From List. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlIns.ClientID%>";
                flag = false;
            }

            if (!CheckControl("<%=ddlDept.ClientID%>")) {
                msg += " * Select Department From List. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlDept.ClientID%>";
                flag = false;
            }

            if (!CheckControl("<%=ddlEmp.ClientID%>")) {
                msg += " * Select Employee From List. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlEmp.ClientID%>";
                flag = false;
            }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }

    </script>
  <div class="container">
        <div class="heading">
            <h2>Employee Profile/Leave/Attendane Details
            </h2>
        </div>
        <div>
            <table>
                <tr>
                    <th>Institute
                    </th>
                    <th>Department
                    </th>
                    <th>Employee
                    </th>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="ddlIns" runat="server" OnSelectedIndexChanged="ddlIns_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlDept" runat="server" OnSelectedIndexChanged="ddlDept_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlEmp" runat="server"></asp:DropDownList>
                    </td>
                    <td>
                        <asp:Button ID="btnView" Text="View" runat="server" OnClick="btnView_Click1" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:UpdatePanel ID="up1" runat="server">
                            <ContentTemplate>
                                <ajaxToolkit:TabContainer ID="step1" runat="server" ActiveTabIndex="0" AutoPostBack="true" Visible="false" OnActiveTabChanged="step1_ActiveTabChanged">
                                    <ajaxToolkit:TabPanel runat="server" HeaderText="Profile" ID="TabPanel3">
                                        <ContentTemplate>
                                            <table>
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
                                                                    </table>
                                                                </td>

                                                                <td>
                                                                    <table>
                                                                        <tr>
                                                                            <td style="width: 320px">
                                                                                <h4>Personal Information</h4>
                                                                            </td>
                                                                            <td></td>

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
                                                        <h4>Document/Qualification/Experience Information</h4>
                                                    </td>

                                                </tr>

                                                <tr>
                                                    <td colspan="2">
                                                        <asp:UpdatePanel ID="update" runat="server">
                                                            <ContentTemplate>
                                                                <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" AutoPostBack="True" OnActiveTabChanged="TabContainer1_SelectedIndexChanged" CssClass="">
                                                                    <ajaxToolkit:TabPanel runat="server" HeaderText="Document Information" ID="TabPanel4">
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
                                                                    <ajaxToolkit:TabPanel runat="server" HeaderText="Qualification Information" ID="TabPanel5">
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
                                                                    <ajaxToolkit:TabPanel runat="server" HeaderText="Experience Information" ID="TabPanel6">
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
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>


                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </ajaxToolkit:TabPanel>
                                    <ajaxToolkit:TabPanel runat="server" HeaderText="Leave Detail" ID="TabPanel2">
                                        <ContentTemplate>
                                            <table>
                                                <tr>
                                                    <th>BY YEAR</th>

                                                    <th>BY LEAVE</th>

                                                    <th>BY STATUS</th>
                                                    <th colspan="2">BY DATE</th>
                                                    <td id="tdss" runat="server">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:DropDownList ID="ddlYear" runat="server" Width="80px"
                                                            AutoPostBack="True">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlLeaveType" runat="server" Width="100px">
                                                        </asp:DropDownList>
                                                    </td>

                                                    <td>
                                                        <asp:DropDownList ID="ddlStatus" runat="server" Width="100px">
                                                            <asp:ListItem Value=".">All</asp:ListItem>
                                                            <asp:ListItem Value="-2">Apply</asp:ListItem>
                                                            <asp:ListItem Value="-1">Arrangement Accept</asp:ListItem>
                                                            <asp:ListItem Value="1">Recommanded</asp:ListItem>
                                                            <asp:ListItem Value="2">Approved</asp:ListItem>
                                                            <asp:ListItem Value="0">Reject</asp:ListItem>
                                                            <asp:ListItem Value="3">Cancel Apply</asp:ListItem>
                                                            <asp:ListItem Value="4">Cancel Approved</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtFromDT" runat="server" Width="80px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtToDT" runat="server" Width="80px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="Button1" runat="server" Text="View" OnClick="btnView_Click"></asp:Button>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="6">
                                                        <asp:GridView ID="gvLvBalance" runat="server" AutoGenerateColumns="False" Caption="Leave Balance" CssClass="gridDynamic">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="S.No.">
                                                                    <ItemTemplate><%#((GridViewRow)Container).RowIndex+1 %></ItemTemplate>
                                                                    <ItemStyle Width="15px" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField HeaderText="Type" DataField="LV_VALUE" ReadOnly="True" />
                                                                <asp:BoundField DataField="OPENING_BAL" HeaderText="Opening Balance" ReadOnly="True"
                                                                    HtmlEncode="False">
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="CREDIT_BAL" HeaderText="Credit Balance" HtmlEncode="False">
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="LAPSED_BAL" HeaderText="Lapsed">
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                </asp:BoundField>
                                                                <asp:BoundField HeaderText="Current. Balance" DataField="CURRENT_BAL" HtmlEncode="False">
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                </asp:BoundField>
                                                                <asp:BoundField HeaderText="Availed" DataField="AVAILED_BAL" ReadOnly="True" HtmlEncode="False">
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                </asp:BoundField>
                                                                <asp:BoundField HeaderText="Applied" DataField="APPLIED_BAL" HtmlEncode="False">
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                </asp:BoundField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="6">
                                                        <asp:GridView ID="gvLvHistory" runat="server" AutoGenerateColumns="False" Caption="Leave History" CssClass="gridDynamic">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="S.No.">
                                                                    <ItemTemplate><%#((GridViewRow)Container).RowIndex+1 %></ItemTemplate>
                                                                    <ItemStyle Width="15px" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="LV_APP_ID" ReadOnly="True" HeaderText="Leave Id"></asp:BoundField>
                                                                <asp:BoundField DataField="REQ_DT" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Req. Date"
                                                                    ReadOnly="True"></asp:BoundField>
                                                                <asp:BoundField DataField="LV_VALUE" HeaderText="Leave type" ReadOnly="True"></asp:BoundField>
                                                                <asp:BoundField DataField="FROM_DT" HeaderText="From Date" DataFormatString="{0:dd/MM/yyyy}" />
                                                                <asp:BoundField DataField="TO_DT" HeaderText="To Date" DataFormatString="{0:dd/MM/yyyy}" />
                                                                <asp:BoundField DataField="TOT_DAYS" HeaderText="NOD" ReadOnly="True" />
                                                                <asp:BoundField DataField="DAY_TYPE_NAME" HeaderText="Day Type" ReadOnly="True" />
                                                                <asp:BoundField DataField="Reason" HeaderText="Reason" ReadOnly="True" />
                                                                <asp:BoundField HeaderText="Action date" ReadOnly="True" DataField="ACT_DT" DataFormatString="{0:dd/MM/yyyy}"></asp:BoundField>
                                                                <asp:BoundField HeaderText="Action By" ReadOnly="True" DataField="ACT_BY"></asp:BoundField>
                                                                <asp:BoundField HeaderText="Status" ReadOnly="True" DataField="STS_VALUE"></asp:BoundField>
                                                                <asp:BoundField HeaderText="Pending" ReadOnly="True" DataField="PENDING_WITH"></asp:BoundField>

                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </ajaxToolkit:TabPanel>
                                    <ajaxToolkit:TabPanel runat="server" HeaderText="Attendance Detail" ID="TabPanel1">
                                        <ContentTemplate>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                                            <ProgressTemplate>
                                                                <img src="../Siteimages/loading.gif" alt="loading" />
                                                            </ProgressTemplate>
                                                        </asp:UpdateProgress>
                                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                            <ContentTemplate>
                                                                <table>
                                                                    <tr>
                                                                        <td style="vertical-align: top;">
                                                                            <table>
                                                                                <tr>
                                                                                    <th>Month/Year</th>
                                                                                    <td>&nbsp;</td>
                                                                                    <th>Attendance Status</th>
                                                                                    <td>&nbsp;</td>

                                                                                    <td>&nbsp;</td>

                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <uc2:MonthYear ID="MonthYear1" runat="server" />
                                                                                    </td>
                                                                                    <td>&nbsp;</td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddlAttType" runat="server"></asp:DropDownList></td>
                                                                                    <td>&nbsp;</td>

                                                                                    <td>&nbsp;</td>
                                                                                    <td>
                                                                                        <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" /></td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>

                                                                    <tr>
                                                                        <td>
                                                                            <asp:GridView ID="gridAttendance" CssClass="gridDynamic" runat="server" AutoGenerateColumns="False" OnDataBound="gridAttendance_DataBound" DataKeyNames="dcDate" Caption="Month Attendance">
                                                                                <Columns>
                                                                                    <asp:BoundField DataField="dcDay" HeaderText="Day" />
                                                                                    <asp:BoundField DataField="dcWeekDay" HeaderText="Week Day" ItemStyle-Width="100px" />
                                                                                    <asp:BoundField DataField="dcDutyTime" HeaderText="Shift" ItemStyle-Width="120px" />
                                                                                    <asp:BoundField DataField="dcInTime" HeaderText="In-Time" ItemStyle-Width="90px" />
                                                                                    <asp:BoundField DataField="dcOutTime" HeaderText="Out-Time" ItemStyle-Width="90px" />
                                                                                    <asp:BoundField DataField="dcStatus" HeaderText="Status" ItemStyle-Width="200px" />
                                                                                </Columns>
                                                                            </asp:GridView>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </ajaxToolkit:TabPanel>
                                </ajaxToolkit:TabContainer>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

