<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Short.master" AutoEventWireup="true" CodeFile="rptLvCredit.aspx.cs" Inherits="HR_rptLvCredit" %>

<%@ Register Src="~/Control/MonthYear.ascx" TagPrefix="uc1" TagName="MonthYear" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentHolder1" runat="Server">
    <script language="javascript" type="text/javascript">
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
        function validate() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=ddlCreditType.ClientID%>")) {
                msg += "- Select Credit Type from List\n";
                if (ctrl == "")
                    ctrl = "<%=ddlCreditType.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlLvType.ClientID%>")) {
                msg += "- Select Leave Type from the List \n";
                if (ctrl == "")
                    ctrl = "<%=ddlLvType.ClientID%>";
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
            <h2>Leave Credit Report
            </h2>
        </div>
        <div>
            <asp:UpdatePanel ID="up1" runat="server">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <th>Month & Year<span class="required">*</span>
                                        </th>
                                        <th>Leave Type<span class="required">*</span>
                                        </th>
                                        <th>Credit Type<span class="required">*</span>
                                        </th>
                                    </tr>
                                    <tr>
                                        <td>
                                            <uc1:MonthYear runat="server" ID="MonthYear" />
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlLvType" runat="server"></asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlCreditType" runat="server">
                                                <asp:ListItem Text="Select" Value="."></asp:ListItem>
                                                <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="No" Value="0"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnView" runat="server" Text="View" OnClick="btnView_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>

                        <tr id="trGrid" runat="server" visible="false">
                            <td >
                                <asp:GridView ID="gvDetail" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" EmptyDataText="No Record Found">
                                    <Columns>
                                        <asp:TemplateField HeaderText="S.No.">
                                            <ItemTemplate><%#((GridViewRow)Container).RowIndex+1 %>.</ItemTemplate>
                                            <ItemStyle Width="15px" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="EMP_ID" HeaderText="Emp.Code" />
                                        <asp:BoundField DataField="EMP_NAME" HeaderText="Name" />
                                        <asp:BoundField DataField="CREDIT" HeaderText="Credit" />
                                        <asp:BoundField DataField="DES_VALUE" HeaderText="Designation" />
                                        <asp:BoundField DataField="DEPT_VALUE" HeaderText="Department" />
                                        <asp:BoundField DataField="DOJ" HeaderText="DOJ" />
                                        <asp:BoundField DataField="CR_REM" HeaderText="Remark" />
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
    </div>
</asp:Content>

