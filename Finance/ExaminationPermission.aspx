<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="ExaminationPermission.aspx.cs" Inherits="StudentFinance_BankAccount" %>

<%@ Register Src="~/Control/Student.ascx" TagPrefix="uc1" TagName="Student" %>


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
          function Validate() {
              var flag = true;
              var msg = "", ctrl = "";
              if (!CheckControl("<%=ddlExamType.ClientID%>")) {
                  msg += " * Select Exam Type. \n";
                  if (ctrl == "")
                      ctrl = "<%=ddlExamType.ClientID%>";
                flag = false;
              if (!CheckControl("<%=txtEnrollment.ClientID%>")) {
                msg += " * Enter  Enrollment. \n";
                if (ctrl == "")
                    ctrl = "<%=txtEnrollment.ClientID%>";
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
            <h2>Exam Permission
            </h2>

        </div>
        <div id="cBody">
            <div id="cHead">
                <!-- Content  Header ex: Filters-->
                <div>
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" OnActiveTabChanged="TabContainer1_ActiveTabChanged" AutoPostBack="true">
                                <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="Exam Permission">
                                    <ContentTemplate>
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <table>
                                                    <tr>
                                                        <td style="padding-left: 300px" colspan="2">
                                                            <table>
                                                                <tr>
                                                                    <th>Examination</th>
                                                                    <th>Enrollment</th>
                                                                    <td>&nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlExamType" runat="server">
                                                                            <asp:ListItem Text="Major" Value="3"></asp:ListItem>
                                                                            <asp:ListItem Text="Minor-II" Value="2"></asp:ListItem>
                                                                            <asp:ListItem Text="Minor-I" Value="1"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtEnrollment" runat="server" Width="181px"></asp:TextBox>
                                                                    </td>
                                                                    <td>&nbsp;&nbsp;
                                                                        <asp:Button ID="btnShow" runat="server" OnClick="btnShow_Click" Text="Show" />
                                                                        &nbsp;&nbsp; </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <uc1:Student runat="server" ID="Student" />
                                                            <br />
                                                            <div id="divPanelNoDue" runat="server"></div>
                                                            <div id="divPanelDue" runat="server" visible="False">
                                                                <table style="width: 100%">
                                                                    <tr>
                                                                        <td style="width: 50%; vertical-align: top">
                                                                            <p>Fees Due</p>
                                                                            <hr />
                                                                            <asp:GridView ID="gridDue" runat="server" AutoGenerateColumns="False" DataKeyNames="STU_DUE_ID" EmptyDataText="No Due">
                                                                                <Columns>
                                                                                    <asp:BoundField DataField="ENROLLMENT_NO" HeaderText="ENROLLMENT NO" />
                                                                                    <asp:BoundField DataField="DUE_AMT" HeaderText="Due Amount" />
                                                                                </Columns>

                                                                            </asp:GridView>
                                                                        </td>
                                                                        <td>
                                                                            <p>Provide Permission</p>
                                                                            <hr />

                                                                            <table>
                                                                                <tr>

                                                                                    <td>Permission</td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddlPermissionType" runat="server">

                                                                                            <asp:ListItem Value="1" Text="Clear"></asp:ListItem>
                                                                                            <asp:ListItem Value="2" Text="Permit"></asp:ListItem>
                                                                                        </asp:DropDownList></td>
                                                                                </tr>

                                                                                <tr>
                                                                                    <td>Remark</td>
                                                                                    <td>
                                                                                        <asp:TextBox runat="server" ID="txtRemark" Height="82px" TextMode="MultiLine" Width="217px"></asp:TextBox></td>
                                                                                </tr>


                                                                                <tr>
                                                                                    <td></td>
                                                                                    <td>
                                                                                        <asp:Button Text="Save" ID="btnAdd" runat="server" OnClick="btnAdd_Click" /></td>

                                                                                </tr>

                                                                            </table>



                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </ContentTemplate>
                                </ajaxToolkit:TabPanel>
                                <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="Due Report">
                                    <ContentTemplate>
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <table>
                                                                <tr>
                                                                    <th>By Exam Type</th>
                                                                    <th>By Insitute</th>
                                                                    <th>By Program</th>
                                                                    <th>By Branch</th>
                                                                    <th>By Sem</th>
                                                                    <th>By Status</th>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlexamtypes" runat="server" AutoPostBack="true">
                                                                            <asp:ListItem Value="2" Text="Minor-II"></asp:ListItem>
                                                                            <asp:ListItem Value="1" Text="Minor-I"></asp:ListItem>
                                                                            <asp:ListItem Value="3" Text="Major"></asp:ListItem>

                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlIns" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlIns_SelectedIndexChanged"></asp:DropDownList></td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlPgm" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPgm_SelectedIndexChanged" Width="120px"></asp:DropDownList></td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlBranch" runat="server" AutoPostBack="True" Width="120px"></asp:DropDownList></td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlSem" runat="server" AutoPostBack="True"></asp:DropDownList></td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlSts" runat="server" AutoPostBack="True">
                                                                            <asp:ListItem Value="-1">All</asp:ListItem>
                                                                            <asp:ListItem Value="1">Clear</asp:ListItem>
                                                                            <asp:ListItem Value="2">Permit</asp:ListItem>
                                                                            <asp:ListItem Value="0">Pending</asp:ListItem>
                                                                        </asp:DropDownList></td>
                                                                    <td>
                                                                        <asp:Button ID="btnView" runat="server" Text="View" OnClick="btnView_Click" /></td>
                                                                    <td>
                                                                        <asp:Button ID="BtnExport" runat="server" Text="Export To Excel" OnClick="BtnExport_Click" Width="114px" /></td>
                                                                </tr>
                                                            </table>

                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <div style="height: 410px; overflow: auto">
                                                                <asp:GridView ID="gvFeeReport" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" Width="97%">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="S.No">
                                                                            <ItemTemplate>
                                                                                <%#((GridViewRow)Container).RowIndex +1 %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField HeaderText="Enrollment" DataField="ENROLLMENT_NO" />
                                                                        <asp:BoundField HeaderText="Name" DataField="STU_FULL_NAME" />
                                                                        <asp:BoundField HeaderText="Institute" DataField="INS_VALUE" />
                                                                        <asp:BoundField HeaderText="Program" DataField="PGM_SHORT_NAME" />
                                                                        <asp:BoundField HeaderText="Clear By" DataField="EMP_NAME" />
                                                                        <asp:BoundField HeaderText="Remark" DataField="REMARK" />

                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:PostBackTrigger ControlID="BtnExport" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </ContentTemplate>


                                </ajaxToolkit:TabPanel>
                            </ajaxToolkit:TabContainer>
                        </ContentTemplate>

                    </asp:UpdatePanel>
                </div>


            </div>
            <div id="cCenter">
                <!-- Content Header ex: Grids-->

                <div id="cFooter">
                    <!-- Content Header ex:Buttons-->

                </div>
            </div>
        </div>
    </div>
</asp:Content>

