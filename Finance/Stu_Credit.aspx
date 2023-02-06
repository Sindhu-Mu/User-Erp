<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="Stu_Credit.aspx.cs" Inherits="Finance_BankAccount" %>

<%@ Register Src="~/Control/Student.ascx" TagPrefix="uc1" TagName="Student" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <script lang="javascript" type="text/javascript"> 
         // Client Side Validation Script
    </script>
    <div class="container">
        <div class="heading">
            <h2>
                <!-- Page Heading-->
                Student Credit Transaction
            </h2>
           
        </div>
    
    <div id="cBody">
        <div id="cHead">
           <!-- Content  Header ex: Filters-->

        </div>
        <div id="cCenter">
           <!-- Content Header ex: Grids-->
            <table>
                <tr>
                 <th>Enrollment No.</th>
                    <td><asp:TextBox ID="txtenroll" runat="server"></asp:TextBox></td>
                    <td><asp:Button ID="btnshow" runat="server" Text="Show" OnClick="btnshow_Click" /></td>
                </tr>
                <tr>
                    <td colspan="3">
                        <uc1:Student runat="server" ID="Student" />
                    </td>
                </tr>
                <tr>
                    <th>Credit Amount</th>
                    <td><asp:Label ID="LBLCREDIT" runat="server"></asp:Label><br/></td>
                </tr>  
                  <tr>
                    <th>Amount</th>
                <td>
                        <asp:TextBox ID="txtAmount" runat="server" Width="150"></asp:TextBox>
                    </td>
                    </tr>
                
                <tr>
                        <th>Tran Type</th>
                    <td>
                        <asp:DropDownList ID="ddltrantype" runat="server" AutoPostBack="false" Width="150px">
                            <asp:ListItem>Select</asp:ListItem>
                            <asp:ListItem Value="0">Debit</asp:ListItem>
                            <asp:ListItem Value="1">Credit</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr> 
                <tr>
                    <th>Adjust Type</th>
                    <td><asp:DropDownList ID="ddladjtype" runat="server" AutoPostBack="false" Width="150px" OnSelectedIndexChanged="ddladjtype_SelectedIndexChanged"></asp:DropDownList></td>
                </tr>
                <tr>
                    <th>Remark</th>
                    <td><asp:TextBox ID="txtremark" runat="server" Width="150"></asp:TextBox></td>
                </tr>
                <tr>
                    <th>
                       Date
                    </th>
                    <td>
                        <asp:TextBox ID="txtdate" runat="server" Width="150"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtdate" Format="dd/MM/yyyy">
                    </ajaxToolkit:CalendarExtender>
                    </td>
                </tr>
                
                <tr>
                    <td>
                        <asp:Button ID="btnadd" runat="server" Text="ADD" OnClick="btnadd_Click" />
                    </td>
                </tr>
                                    
                
                </table>

        </div>
         <div id="cFooter">
              <!-- Content Header ex:Buttons-->

        </div>
</div>
</div>

</asp:Content>

