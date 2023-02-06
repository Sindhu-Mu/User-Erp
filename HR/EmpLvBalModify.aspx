<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="EmpLvBalModify.aspx.cs" Inherits="HR_EmpLvBalModify" %>

<%@ Register Src="~/Control/Employee.ascx" TagPrefix="uc1" TagName="Employee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script lang="javascript" type="text/javascript">
        function CheckDate(ctrl) {
            var dt = document.getElementById(ctrl).value;
            if (!isDatecheck(dt, "dd/MM/yyyy")) {
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
                return false;
            }
            else
                document.getElementById(ctrl).style.backgroundColor = "#fff";
            return true;
        }
        function CheckAutoComplete(ctrl) {

            var Value = bTrim(document.getElementById(ctrl).value);
            if (Value.indexOf(":") > 0 && Value.length - 1 != Value.lastIndexOf(":")) {
                document.getElementById(ctrl).style.backgroundColor = "#fff";
                return true;
            }
            else
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
            return false;
        }
        function CheckControl(ctrl) {
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == "Select" || bTrim(document.getElementById(ctrl).value) == ".") {
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
                return false;
            }
            else
                document.getElementById(ctrl).style.backgroundColor = "#fff";
            return true;
        }

        function validat() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckAutoComplete("<%=txtEmployee.ClientID%>")) {
                msg += " * Enter Name with Code. \n";
                if (ctrl == "")
                    ctrl = "<%=txtEmployee.ClientID%>";
                flag = false;
            }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }

        function validate() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckAutoComplete("<%=txtEmployee.ClientID%>")) {
                msg += " * Enter Name with Code. \n";
                if (ctrl == "")
                    ctrl = "<%=txtEmployee.ClientID%>";
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
            <h2>Leave Balance Modification</h2>
        </div>
        <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div>
                        <div style="float: right;">
                            <table style="text-align: left;">

                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtEmployee" runat="server" CssClass="textBox" Width="228px" placeholder="Employee Name or Code"></asp:TextBox>
                                        <ajaxToolkit:AutoCompleteExtender ID="autoComplete1" runat="server" CompletionInterval="500"
                                            CompletionSetCount="12" ContextKey="1" EnableCaching="true" MinimumPrefixLength="1"
                                            ServiceMethod="GetEmployeeList" ServicePath="~\AutoComplete.asmx" TargetControlID="txtEmployee">
                                        </ajaxToolkit:AutoCompleteExtender>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" />
                                    </td>
                                </tr>

                            </table>
                        </div>
                        <div style="clear: both;"></div>
                    </div>
                    <div>
                    </div>
                    <uc1:Employee ID="Employee" runat="server" />
                    </div>
                   
                
                            <div style="height: 400PX; overflow: auto">
                                <asp:GridView ID="gvBalance" runat="server" EmptyDataText="No record found." AutoGenerateColumns="False" Caption="Leave Balance"
                                    CssClass="gridDynamic" DataKeyNames="LV_BL_ID" OnRowDeleting="gvBalance_RowDeleting">
                                    <Columns>
                                        <asp:TemplateField HeaderText="S.No.">
                                            <ItemTemplate><%#((GridViewRow)Container).RowIndex+1 %></ItemTemplate>
                                            <ItemStyle Width="15px" />
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Type" DataField="LV_VALUE" ReadOnly="True" ItemStyle-Width="20%"/>
                                        <asp:BoundField DataField="OPENING_BAL" HeaderText="Opening Balance" HtmlEncode="False">
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Credit">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtCredit" runat="server" Text='<%#Bind("CREDIT_BAL")%>' Width="80%"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Lapsed">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtLapsed" runat="server" Text='<%#Bind("LAPSED_BAL")%>' Width="80%"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Current. Balance" DataField="CURRENT_BAL" HtmlEncode="False">
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Availed">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtAvailed" runat="server" Text='<%#Bind("AVAILED_BAL")%>' Width="80%"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Applied">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtApplied" runat="server" Text='<%#Bind("APPLIED_BAL")%>' Width="80%"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:CommandField ButtonType="Button" HeaderText="Update" DeleteText="Update"
                                            ShowDeleteButton="true" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

