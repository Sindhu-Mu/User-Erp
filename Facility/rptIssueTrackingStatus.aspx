<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="rptIssueTrackingStatus.aspx.cs" Inherits="Facility_rptIssueTrackingStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
            <h2>Issue Tracking Report
            </h2>
        </div>

       <div>
            <table>
                <tr>
                    <th>Institution
                    </th>
                    <th>Department
                    </th>

                   
                     <th>Date</th>
                    <th colspan="2"></th>
                    <th>Employee Code</th>
                     <th>Concern Department</th>
                   
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="ddlIns" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlIns_SelectedIndexChanged"></asp:DropDownList>
                    </td>
                    <td >
                        <asp:DropDownList ID="ddlDept" runat="server"></asp:DropDownList>
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
                         
                              
                     <td colspan="2">
                                <asp:DropDownList ID="ddlConcernDept" runat="server"  >
                                    <asp:ListItem Value="0">All</asp:ListItem>
                                    <asp:ListItem Value="25">Accounts</asp:ListItem>
                                    <asp:ListItem Value="26">CSD</asp:ListItem>
                                    <asp:ListItem Value="27">Administration</asp:ListItem>
                                    <asp:ListItem Value="30">Construction</asp:ListItem>
                                    <asp:ListItem Value="48">Human Resource</asp:ListItem>
                                    <asp:ListItem Value="54">Electrical and Maintenance</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                    <td>
                        <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" />
                    </td>
                </tr>
                <tr>
                      <td><ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionSetCount="12"
                                    EnableCaching="true" MinimumPrefixLength="1" ServiceMethod="GetEmployeeList"
                                    ServicePath="~\AutoComplete.asmx" TargetControlID="txtEmployee" ContextKey="1,2,3,0">
                                </ajaxToolkit:AutoCompleteExtender></td>
                     
                </tr>
                </table>
            <table>
               
                </table>
            <table>
                <tr>
                    <td colspan="7">
                        <div style="height: 500px; overflow: auto">
                            <asp:GridView ID="gvIssuDetail" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" DataKeyNames="ISSUE_ID,ISSUE_TOKEN_NO" OnRowCommand="gvIssuDetail_RowCommand">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No.">
                                        <ItemTemplate><%#((GridViewRow)Container).RowIndex+1 %></ItemTemplate>
                                        <ItemStyle Width="15px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="ISSUE_TOKEN_NO" HeaderText="Token No." />
                                    <asp:BoundField DataField="EMP_ID" HeaderText="Emp.Code" />
                                    <asp:BoundField DataField="EMP_NAME" HeaderText="Name" />
                                    <asp:BoundField DataField="ISSUE_DT" HeaderText="Issue Date" />
                                    <asp:BoundField DataField="ISSUE_STS_VALUE" HeaderText="Status" />
                                    <asp:BoundField DataField="DEPT_VALUE" HeaderText="Concern Department" />
                                       <asp:ButtonField ButtonType="Button" CommandName="View" HeaderText="Detail" Text="View" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

