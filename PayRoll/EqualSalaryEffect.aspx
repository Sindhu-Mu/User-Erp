<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="EqualSalaryEffect.aspx.cs" Inherits="PayRoll_EqualSalaryEffect" %>


<%@ Register Src="~/Control/MonthYear.ascx" TagPrefix="uc1" TagName="MonthYear" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script lang="javascript" type="text/javascript">
        function CheckControl(ctrl) {

            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == "." || bTrim(document.getElementById(ctrl).value) == "Select") {
                document.getElementById(ctrl).style.backgroundColor = "#fc6";

                return false;
            }
            else {
                document.getElementById(ctrl).style.backgroundColor = "#fff";
                return true;
            }
        }
        function validation() {

            var flag = true;
            var msg = "", ctrl = "";

            if (!CheckControl("<%=ddlHeadType.ClientID%>")) {
                msg += " * Select Head Type. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlHeadType.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlHeadName.ClientID%>")) {
                msg += " * Select Head name.\n";
                if (ctrl == "")
                    ctrl = "<%=ddlHeadName.ClientID%>";
                flag = false;
            }

        

            if (!CheckControl("<%=txtValue.ClientID%>")) {
                msg += " * Enter Deduction (%). \n";
                if (ctrl == "")
                    ctrl = "<%=txtValue.ClientID%>";
                flag = false;
            }

            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }
    </script>
    <div id="content" class="container" style="padding: 10px;">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <div style="border-bottom: 1px solid black;">
                    <h3>Monthly Transaction</h3>
                </div>
                <div>
                    <table border="0">
                        <tr>
                            <th>For Month<span style="color: #ff0000">*</span></th>
                            <td>&nbsp;</td>
                            <th>Head Type<span style="color: #ff0000">*</span></th>
                            <td>&nbsp;</td>
                            <th>Head Name<span style="color: #ff0000">*</span></th>
                            <td>&nbsp;</td>
                            <th>Institute</th>
                            <td>&nbsp;</td>
                            <th>Department</th>
                            <td>&nbsp;</td>
                            <th>Employee Type</th>
                            <td>&nbsp;</td>
                            <th>Deduction(%)<span style="color: #ff0000">*</span></th>
                            <td>&nbsp;</td>
                        </tr>
                        <tr style="vertical-align: top;">
                            <td>
                                <uc1:MonthYear runat="server" ID="MonthYear" />
                            </td>
                            <td>&nbsp;</td>
                            <td>
                                <asp:DropDownList ID="ddlHeadType" runat="server" Width="120px" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlHeadType_SelectedIndexChanged">
                                    <asp:ListItem >Select</asp:ListItem>
                                    <asp:ListItem Value="1">Earnings</asp:ListItem>
                                    <asp:ListItem Value="0">Deduction</asp:ListItem>
                                </asp:DropDownList></td>
                            <td>&nbsp;</td>
                            <td>
                                <asp:DropDownList ID="ddlHeadName" runat="server" Width="150px">
                                </asp:DropDownList></td>
                            <td>&nbsp;</td>
                            <td>
                                <asp:DropDownList ID="ddlInstitution" runat="server" OnSelectedIndexChanged="ddlInstitution_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList></td>
                            <td>&nbsp;</td>
                            <td>
                                <asp:DropDownList ID="ddlDepartment" runat="server">
                                </asp:DropDownList></td>
                            <td>&nbsp;</td>
                            <td>
                                <asp:DropDownList ID="ddlEmpType" runat="server">
                                    <asp:ListItem Value="-1">All</asp:ListItem>
                                    <asp:ListItem Value="1">Teaching</asp:ListItem>
                                    <asp:ListItem Value="0">Non-Teaching</asp:ListItem>
                                </asp:DropDownList></td>
                            <td>&nbsp;</td>
                            <td>
                                <cc1:NumericTextBox ID="txtValue" runat="server" Width="100px" MaxLength="2" CssClass="txtno"></cc1:NumericTextBox>
                            </td>
                            <td>&nbsp;</td>
                            <td>
                        </tr>
                    </table>
                </div>
                <div style="text-align:right;">
                    <asp:Button ID="btnEntry" runat="server" Text="Entry" CssClass="btnBrown" OnClick="btnEntry_Click" Width="80px" Height="30px"/>
                    &nbsp;
                    <asp:Button ID="btnDetail" runat="server" Text="Detail" CssClass="btnBrown" OnClick="btnDetail_Click" Width="80px" Height="30px"/>
                </div>
                <div id="trEntry" runat="server">
                    <div style="height: 400px; overflow: auto; width: 100%">
                        <asp:GridView ID="gvTranDetail" Width="97%" runat="server" CssClass="gridDynamic"
                            AutoGenerateColumns="False" DataKeyNames="ES_ID,AMOUNT,TRAN_REMARKS" HeaderStyle-CssClass="GVFixedHeader">
                            <Columns>
                                <asp:TemplateField HeaderText="S.No.">
                                    <ItemTemplate>
                                        <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                    .
                                    </ItemTemplate>
                                    <ItemStyle Width="15px" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="EMP_ID" HeaderText="EMP.CODE" />
                                <asp:BoundField DataField="EMP_NAME" HeaderText="NAME" />
                                <asp:BoundField DataField="DEPT_VALUE" HeaderText="DEPARTMENT" />
                                 <asp:BoundField DataField="ED_HEAD_VALUE" HeaderText="CONSOLIDATE SALARY" />
                                <asp:TemplateField HeaderText="AMOUNT">
                                    <ItemTemplate>
                                        <cc1:NumericTextBox ID="txtAmount" runat="server"  Text='<%# Bind("AMOUNT") %>'  CssClass="txtno"
                                            AllowDecimal="true" MaxLength="6" DecimalPlaces="2" Width="100px"></cc1:NumericTextBox>
                                    </ItemTemplate>
                                    <ItemStyle Width="100px" HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="REMARKS">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtRemark" CssClass="textbox" runat="server" Text='<%# Bind("TRAN_REMARKS") %>'
                                            Width="200px" />
                                    </ItemTemplate>
                                    <ItemStyle Width="200px" />
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle CssClass="GVFixedHeader" />
                        </asp:GridView>
                    </div>
                    <div style="text-align: right;">
                        <asp:Label ID="lblTotal" runat="server" Font-Bold="True"></asp:Label>
                        <asp:TextBox ID="txtData" runat="server" Visible="False"></asp:TextBox>
                        <asp:Button AccessKey="c" ID="btnCalculate" OnClick="btnCalculate_Click" runat="server" Text="Calculate" CssClass="btnBrown" Font-Overline="False" Width="80px" Height="30px"></asp:Button>
                        <asp:Button ID="btnSave" runat="server" AccessKey="s" CssClass="btnBrown" Font-Overline="False" OnClick="btnSave_Click" Text="Save" Width="80px" Height="30px" /></td>
                    </div>

                </div>
                <div id="trDetail" runat="server" visible="false">

                    <div style="height: 400px; overflow: auto; width: 100%">
                        <asp:GridView ID="gvDetail" Width="97%" runat="server" CssClass="gridDynamic" AutoGenerateColumns="False"
                            ShowFooter="True">
                            <Columns>
                                <asp:TemplateField HeaderText="S.No.">
                                    <ItemTemplate>
                                        <%# ((GridViewRow)Container).RowIndex + 1%>
                                                        .
                                    </ItemTemplate>
                                    <ItemStyle Width="15px" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="EMP_ID" HeaderText="EMP.CODE" />
                                <asp:BoundField DataField="EMP_NAME" HeaderText="NAME" />
                                <asp:BoundField DataField="DEPT_VALUE" HeaderText="DEPARTMENT" />
                                <asp:BoundField DataField="HEAD_NAME" HeaderText="HEAD" FooterText="TOTAL:-">
                                    <FooterStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="AMOUNT" DataField="HEAD_VALUE" />
                                <asp:BoundField HeaderText="REMARKS" DataField="TRAN_REMARKS" />
                                <asp:BoundField DataField="TRAN_BY" HeaderText="INSERT BY" />
                                <asp:BoundField DataField="TRAN_IN_DT" DataFormatString="{0:dd/MM/yyyy}" HeaderText="INSERT DT" />
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div>
                        <asp:Button ID="btnExcel" runat="server" Text="Export To Excel" CssClass="btnBrown"
                            OnClick="btnExcel_Click" />
                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="btnExcel" />
            </Triggers>
        </asp:UpdatePanel>
    </div>

</asp:Content>

