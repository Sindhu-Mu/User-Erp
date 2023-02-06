<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="BankAccount.aspx.cs" Inherits="Finance_BankAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <div class="heading"><h2>Bank Account</h2></div>
    
    <div id="cBody">
        <div id="cHead">
            <table>
                <tr>
                    <td>Bank Name</td>
                    <td>A/c Type</td>
                    <td>A/c Number</td>
                    <td>Branch</td>
                    <td>A/c With</td>
                </tr>
                 <tr>
                    <td>
                        <asp:DropDownList ID="ddlBankName" runat="server"></asp:DropDownList></td>
                    <td>
                        <asp:DropDownList ID="ddlAcType" runat="server">
                            <asp:ListItem Text="Current A/c" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Saving A/c" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                        
                    </td>
                    <td><asp:TextBox ID="txtAcNumber" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="txtBranch" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="txtAcWith" runat="server"></asp:TextBox></td>
                     <td> <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="Add_Click" /></td>
                    
                </tr>
                </table>
        </div>
        <div id="cCenter">
            <asp:GridView ID="gvShow" runat="server" ShowHeader="true">
               <Columns>
                   <asp:BoundField HeaderText="Sr No" DataField="sr_no" />
                   <asp:BoundField HeaderText="Branch" DataField="sr_no" />
                   <asp:BoundField HeaderText="Account No" DataField="sr_no" />
                   <asp:BoundField HeaderText="A/c Type" DataField="sr_no" />
                   <asp:BoundField HeaderText="A/c With" DataField="sr_no" />
                   <asp:CommandField >
                    
                   </asp:CommandField>
               </Columns>

            </asp:GridView>
        </div>
         <div id="cFooter">

        </div>
</div>
</div>

</asp:Content>

