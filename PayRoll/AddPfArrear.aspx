<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Short.master" AutoEventWireup="true" CodeFile="AddPfArrear.aspx.cs" Inherits="PayRoll_AddPf" %>

<%@ Register Src="~/Control/MonthYear.ascx" TagPrefix="uc1" TagName="MonthYear" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentHolder1" Runat="Server">
    <script src="../js/validation_payroll.js" type="text/javascript"></script>
    <script type="text/javascript">
        function validate() {
           return AddPfValidate("<%=txtEmp.ClientID%>","<%=txtPfAmount.ClientID%>");
        }
    </script>
    <div id="container" class="container">
        <div id="header" class="heading">
            Add PF
            </div>
        <div id="gridArea">
              <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
        <table>
            <tr>
             
                <td>Employee Code</td>
                 <td>
                       <asp:TextBox ID="txtEmp" runat="server" CssClass="textBox" Width="228px" placeholder="Employee Name or Code"></asp:TextBox>
                        <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" CompletionInterval="500"
                            CompletionSetCount="12" ContextKey="1" EnableCaching="true" MinimumPrefixLength="1"
                            ServiceMethod="GetEmployeeList" ServicePath="~\AutoComplete.asmx" TargetControlID="txtEmp">
                        </ajaxToolkit:AutoCompleteExtender>

                 </td>
            </tr>
              <tr> 
                <td>For Month</td>
                  <td valign="top">
                      <uc1:MonthYear runat="server" ID="MonthYear" />
                                            </td>
            </tr>
              <tr> 
                <td>To Month</td>
                   <td>


                       <uc1:MonthYear runat="server" ID="MonthYear1" />
                   </td>
            </tr>
              <tr> 
                <td>PF Amount</td>
                   <td>
                       <cc1:NumericTextBox runat="server" ID="txtPfAmount" ></cc1:NumericTextBox>
                   </td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Button ID="btnAddPf" Text="Add Pf" runat="server" OnClick="btnAddPf_Click" /></td>
                </tr>
            </table>
                    </ContentTemplate>
</asp:UpdatePanel>
            </div>
        </div>
</asp:Content>

