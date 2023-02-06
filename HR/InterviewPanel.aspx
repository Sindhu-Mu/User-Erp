<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Short.master" AutoEventWireup="true" CodeFile="InterviewPanel.aspx.cs" Inherits="HR_InterviewPanel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentHolder1" runat="Server">
    <script language="javascript" type="text/javascript">

        function SelectAllCheckboxes(spanChk) {


            var oItem = spanChk.children;
            var theBox = (spanChk.type == "checkbox") ?
                spanChk : spanChk.children.item[0];
            xState = theBox.checked;
            elm = theBox.form.elements;

            for (i = 0; i < elm.length; i++)
                if (elm[i].type == "checkbox" &&
                         elm[i].id != theBox.id) {

                    if (elm[i].checked != xState)
                        elm[i].click();
                }
        }
    </script>
    <div class="container">
        <div class="heading">
            <h2>Interview Panel
            </h2>
        </div>
        <div>
            <table>
                <tr>
                    <td>
                        <table>
                            <tr>
                                <th>Job No.
                                </th>
                                <th>Round
                                </th>
                                <th>Interview Datetime
                                </th>

                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlJob" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlJob_SelectedIndexChanged"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlRound" runat="server" OnSelectedIndexChanged="ddlRound_SelectedIndexChanged" AutoPostBack="true">
                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="1st Round" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="2nd Round" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="3rd Round" Value="3"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlInt" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlInt_SelectedIndexChanged"></asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <%--<tr>
                    <td>
                        <table>
                            <tr id="trIntDetail" runat="server">
                                <td>
                                    <div>
                                        <asp:GridView ID="gvInter" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" Caption="Interview Detail">
                                            <Columns>
                                                <asp:TemplateField HeaderText="S.No.">
                                                    <ItemTemplate><%#((GridViewRow)Container).RowIndex+1 %>.</ItemTemplate>
                                                    <ItemStyle Width="15px" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="INT_MAIN_ID" HeaderText="Int. No." />
                                                <asp:BoundField DataField="DATE" HeaderText="Date" />
                                                <asp:BoundField DataField="TIME" HeaderText="Time" />
                                                <asp:BoundField DataField="COUNT" HeaderText="No. Of Applicants" />
                                                <asp:TemplateField HeaderText="All">
                                                    <HeaderTemplate>
                                                        <input id="chkAll" onclick="javascript: SelectAllCheckboxes(this);" type="checkbox"
                                                            value="on" runat="server" style="border-right: blue 2px groove; border-top: blue 2px groove; border-left: blue 2px groove; border-bottom: blue 2px groove" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="CHK_SelectAll" runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>--%>
                <tr id="trEntry" runat="server" visible="false">
                    <td>
                        <table>
                            <tr>
                                <th>Interviewer Name & Code
                                </th>
                                <td>
                                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                                    <ajaxToolkit:AutoCompleteExtender ID="autoComplete1" runat="server" CompletionInterval="500"
                                        CompletionSetCount="12" ContextKey="1" EnableCaching="true" MinimumPrefixLength="1"
                                        ServiceMethod="GetEmployeeList" ServicePath="~\AutoComplete.asmx" TargetControlID="txtName">
                                    </ajaxToolkit:AutoCompleteExtender>
                                </td>
                                <td>
                                    <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
                                    <asp:TextBox ID="TextBox1" runat="server" Visible="false"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <div>
                                        <asp:GridView ID="gvInterviewer" runat="server" AutoGenerateColumns="false" Caption="Interviewer's Detail" CssClass="gridDynamic" DataKeyNames="INT_PANEL_SUB_ID,KEY_ID" OnRowDeleting="gvInterviewer_RowDeleting">
                                            <Columns>
                                                <asp:TemplateField HeaderText="S.No.">
                                                    <ItemTemplate><%#((GridViewRow)Container).RowIndex+1 %>.</ItemTemplate>
                                                    <ItemStyle Width="15px" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="EMP_ID" HeaderText="Code" />
                                                <asp:BoundField DataField="NAME" HeaderText="Name" />
                                                <asp:CommandField ShowDeleteButton="true" />
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table>
                                        <tr>
                                            <td style="text-align: right">
                                                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
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
</asp:Content>

