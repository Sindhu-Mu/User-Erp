<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="AttendanceIssue.aspx.cs" Inherits="HR_AttendanceIssue" %>

<%@ Register Src="../Control/MonthYear.ascx" TagName="MonthYear" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script lang="javascript" type="text/javascript">
        function SelectAllCheckboxes(spanChk) {


            var oItem = spanChk.children;
            var theBox = (spanChk.type == "checkbox") ?
                spanChk : spanChk.children.item[0];
            xState = theBox.checked;
            elm = theBox.form.elements;

            for (i = 0; i < elm.length; i++)
                if (elm[i].type == "checkbox" &&
                         elm[i].id != theBox.id) {
                    //elm[i].click();
                    if (elm[i].checked != xState)
                        elm[i].click();
                    //elm[i].checked=xState;
                }

        }
    </script>
    <div class="container">
        <div class="heading">
            <h2>Attendance Issue</h2>
        </div>
        <div>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                <ProgressTemplate>
                    <img src="../Siteimages/loading.gif" alt="loading" /></ProgressTemplate>
            </asp:UpdateProgress>

            <asp:UpdatePanel ID="updatePannel" runat="server">
                <ContentTemplate>

                    <table>
                        <tr>
                            <td>By Institution</td>
                            <td>By Department</td>
                            <td>By Type</td>
                            <td>By Month</td>
                            <td>By Date</td>
                            <td>By Status</td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:DropDownList ID="ddlInstitution" runat="server" OnSelectedIndexChanged="ddlInstitution_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></td>
                            <td>
                                <asp:DropDownList ID="ddlDepartment" runat="server">
                                          </asp:DropDownList></td>
                            <td>
                                <asp:DropDownList ID="ddlCodeType" runat="server" Width="105px">
                                    <asp:ListItem Value=".">All</asp:ListItem>
                                    <asp:ListItem Value="1">Teaching</asp:ListItem>
                                    <asp:ListItem Value="0">Non-Teaching</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <uc2:MonthYear ID="MonthYear1" runat="server" />
                            </td>
                            <td>
                                <asp:TextBox ID="txtClosingDate" runat="server"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtClosingDate" Format="dd/MM/yyyy">
                                </ajaxToolkit:CalendarExtender>
                                <td>
                                    <asp:DropDownList ID="ddlStatus" runat="server" Width="105px">
                                        <asp:ListItem Value="0">Hold</asp:ListItem>
                                        <asp:ListItem Value="1">Issue</asp:ListItem>
                                    </asp:DropDownList></td>
                            <td>
                                <asp:Button ID="btnProcess" runat="server" Text="Process" OnClick="btnShow_Click" />
                            </td>

                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td>
                                <asp:GridView ID="gridView" runat="server" Width="97%" EmptyDataText="No record found."
                                    AutoGenerateColumns="False" CssClass="gridDynamic" HeaderStyle-CssClass="GVFixedHeader"
                                    DataKeyNames="ATT_TRAN_ID,ID">
                                    <Columns>
                                        <asp:TemplateField HeaderText="S.No.">
                                            <ItemTemplate>
                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                            </ItemTemplate>
                                            <ItemStyle Width="20px" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Emp_Id" HeaderText="EmplCode">
                                            <ItemStyle HorizontalAlign="Right" Width="60px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Emp_Name" HeaderText="Employee Name">
                                            <ItemStyle Width="180px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DEPT_VALUE" HeaderText="Department">
                                            <ItemStyle Width="130px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DES_VALUE" HeaderText="Designation">
                                            <ItemStyle Width="150px" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Payable Days">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtNod" runat="server" CssClass="textbox" Width="53px" Text='<%# Bind("NOD") %>'></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="60px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Status">
                                            <HeaderTemplate>
                                                <input id="chkAll" onclick="javascript: SelectAllCheckboxes(this);" type="checkbox"
                                                    value="on" runat="server" />All
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                &nbsp;<asp:CheckBox ID="ChIssue" runat="server" Text="Issue" />
                                            </ItemTemplate>
                                            <ItemStyle Width="60px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Remark">
                                            <ItemTemplate>
                                                &nbsp;<asp:TextBox ID="txtRemark" runat="server" CssClass="textbox" Width="200px"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="210px" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle CssClass="GVFixedHeader" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnIssue" Text="Issue" runat="server" Visible="false" OnClick="btnIssue_Click" />
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

