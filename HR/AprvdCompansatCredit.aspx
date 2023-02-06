<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="AprvdCompansatCredit.aspx.cs" Inherits="HR_AprvdCompansatCredit" %>

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
            <h2>Faculty Lecturer Hour Count</h2>
        </div>
        <div>
            <table>
                <tr>
                    
                    <th>Employee<span class="required">*</span></th>
                    
                </tr>
                <tr>

                     <td>
                        <asp:TextBox ID="txtEmployee" runat="server" Width="200px"></asp:TextBox>
                                <ajaxToolkit:AutoCompleteExtender ID="autoComplete1" runat="server" CompletionInterval="500"
                                    CompletionSetCount="12" ContextKey="0,1,2,3,4" EnableCaching="true" MinimumPrefixLength="1"
                                    ServiceMethod="GetEmployeeList" ServicePath="~\AutoComplete.asmx" TargetControlID="txtEmployee">
                                </ajaxToolkit:AutoCompleteExtender>
                    </td>
                     <td>
                        <asp:Button runat="server" ID="btnView"  Text="Show" OnClick="btnView_Click" />
                    </td>
                </tr>
                </table>
            <table>
                <tr>
                    <td colspan="7">
                        <div overflow: auto">
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
                                    <asp:BoundField DataField="ACTION_DT" HeaderText="Action Date" />
                                    <asp:BoundField DataField="ACTION_BY" HeaderText="Action By" />
                                    <asp:BoundField DataField="CREDIT_NO" HeaderText="Credited Day" />
                                     <asp:TemplateField HeaderText="Credit">
                                                        <ItemTemplate>
                                                          <asp:TextBox id="txtCredit" runat="server" CssClass="NumericTextBoxRight" Width="50px"  MaxLength="4">
                                                              </asp:TextBox>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="10px" />
                                                    </asp:TemplateField>                                                																						
												<asp:TemplateField HeaderText="Select">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkSelect" runat="server" />
                                                    </ItemTemplate>
												</asp:TemplateField>
												
                                </Columns>
                            </asp:GridView>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                          <asp:button id="btnSubmit" runat="server"  Text="Submit" OnClick="btnSubmit_Click" ></asp:button>
                    </td>
                </tr>
            </table>
            </div>
        </div>
</asp:Content>

