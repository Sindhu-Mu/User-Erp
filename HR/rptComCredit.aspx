<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="rptComCredit.aspx.cs" Inherits="HR_rptComCredit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script lang="javascript" type="text/javascript">
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

        function validateView() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckAutoComplete("<%=txtEmployee.ClientID%>")) {
                msg += " * Enter Employee Name & Code. \n";
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
            <h2>Compensatory Credit Report
            </h2>
        </div>
        <div>
            <table>
                <tr>
                    <th>Institution
                    </th>
                    <th>Department
                    </th>

                    <th>Status
                    </th>
                     <th>Date</th>
                    <th colspan="2"></th>
                    <th>Employee Code</th>
                    
                   
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="ddlIns" runat="server" OnSelectedIndexChanged="ddlIns_SelectedIndexChanged"></asp:DropDownList>
                    </td>
                    <td style="width: 100px">
                        <asp:DropDownList ID="ddlDept" runat="server"></asp:DropDownList>
                    </td>

                    <td >
                        <asp:DropDownList ID="ddlStatus" runat="server">
                            <asp:ListItem Value=".">All</asp:ListItem>
                            <asp:ListItem Value="-2">Apply</asp:ListItem>
                            <asp:ListItem Value="1">Recommanded</asp:ListItem>
                            <asp:ListItem Value="0">Reject</asp:ListItem>
                            <asp:ListItem Value="2">Approved</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                                   <td>
                        <asp:DropDownList ID="ddlDate" runat="server" OnSelectedIndexChanged="ddlDate_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem Value="0" Text="All"></asp:ListItem>
                            <asp:ListItem Value="1" Text="Less Than"></asp:ListItem>
                            <asp:ListItem Value="2" Text="Greater Than"></asp:ListItem>
                            <asp:ListItem Value="3" Text="Between"></asp:ListItem>
                        </asp:DropDownList>

                    </td>
                    <td>
                        <asp:TextBox ID="txtFromDate" runat="server" Width="80px"></asp:TextBox>&nbsp;
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender3" Format="dd/MM/yyyy" runat="server" TargetControlID="txtFromDate" Enabled="True"></ajaxToolkit:CalendarExtender>
                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender5" runat="server" Mask="99/99/9999" MaskType="Date"
                            TargetControlID="txtFromDate">
                        </ajaxToolkit:MaskedEditExtender>
                    </td>
                    <td>
                        <asp:TextBox ID="txtToDate" runat="server" Width="80px"></asp:TextBox>&nbsp;
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="txtToDate" Enabled="True"></ajaxToolkit:CalendarExtender>
                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="99/99/9999" MaskType="Date"
                            TargetControlID="txtToDate">
                        </ajaxToolkit:MaskedEditExtender>
                    </td>
                     <td>
                   <asp:TextBox ID="txtEmployee" runat="server" Width="200px"></asp:TextBox></td>
                         
                              <td><ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionSetCount="12"
                                    EnableCaching="true" MinimumPrefixLength="1" ServiceMethod="GetEmployeeList"
                                    ServicePath="~\AutoComplete.asmx" TargetControlID="txtEmployee" ContextKey="1,2,3,0">
                                </ajaxToolkit:AutoCompleteExtender></td>
                     <td>
                        <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" />
                    </td>
                </tr>
                </table>
            <table>
               
                </table>
            <table>
                <tr>
                    <td colspan="7">
                        <div style="height: 400px; overflow: auto">
                            <asp:GridView ID="gvComDetail" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No.">
                                        <ItemTemplate><%#((GridViewRow)Container).RowIndex+1 %></ItemTemplate>
                                        <ItemStyle Width="15px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="EMP_ID" HeaderText="Emp.Code" />
                                    <asp:BoundField DataField="EMP_NAME" HeaderText="Name" />
                                    <asp:BoundField DataField="DES_VALUE" HeaderText="Designation" />
                                    <asp:BoundField DataField="WORK_DT" HeaderText="Work Date" />
                                    <asp:BoundField DataField="STS_VALUE" HeaderText="Status" />
                                    <asp:BoundField DataField="ACTION_DT" HeaderText="Action Date" />
                                    <asp:BoundField DataField="ACTION_BY" HeaderText="Action By" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

