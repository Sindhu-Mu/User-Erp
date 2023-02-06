<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="InstallmentPayment.aspx.cs" Inherits="Finance_BankAccount" %>

<%@ Register Src="~/Control/Student.ascx" TagPrefix="uc1" TagName="Student" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <script lang="javascript" type="text/javascript"> 
         // Client Side Validation Script
    </script>
    <div class="container">
        <div class="heading">
            <h2>
                <!-- Page Heading-->
            Installment Payment
            </h2>
  
        </div>
    
    <div id="cBody">
        <div id="cHead">
           <!-- Content  Header ex: Filters-->
        <table style="width:100%">
            <tr>
                <th>Enrollment</th>
                <th>Sem</th>
                <th>Branch</th>
            </tr>
            <tr>
               <td>
                <asp:TextBox ID="txtEnroll" runat="server"></asp:TextBox>
               </td> 
               <td>
               <asp:DropDownList ID="ddlSem" runat="server"></asp:DropDownList>
                </td>
                <td>
                <asp:DropDownList ID="ddlBranch" runat="server"></asp:DropDownList>
                </td>
                <td>
                <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click"/>
                </td>
            </tr>
        </table>
        <table style="width:100%">
                 <tr>
                     <td>
                     <uc1:Student runat="server" ID="Student" ></uc1:Student>
                     </td>
                 </tr>
        </table>  
        <table style="width:100%">
            <tr>
                <th>Group Head</th>
                <th>Head Amt</th>
                <th>Amt/Per</th>
                
            </tr>
            <tr>
                <td>
                <asp:DropDownList ID="ddlGroupHead" runat="server" OnSelectedIndexChanged="ddlGroupHead_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                </td>
                <td>
                <asp:Label ID="lblHeadAmt" runat="server"></asp:Label>
                </td>
                <td>
                <asp:TextBox ID="txtAmt" runat="server"></asp:TextBox> 
                </td>
            </tr>
            <tr>
                <th>Select</th>  
                <th>Installment</th>
                <th>Date</th>
            </tr>
            <tr>
                <td>
                 <asp:DropDownList ID="ddlAmtPer" runat="server" OnSelectedIndexChanged="ddlAmtPer_SelectedIndexChanged" AutoPostBack="true">
                   <asp:ListItem>Select</asp:ListItem>
                   <asp:ListItem Value="0">Value</asp:ListItem>
                   <asp:ListItem Value="1">Percent</asp:ListItem>
                </asp:DropDownList>
                </td>
                <td>      
                <asp:TextBox ID="txtInstall" runat="server"></asp:TextBox>
                </td>
                <td>     
                <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy"
                                        TargetControlID="txtDate">
                 </ajaxToolkit:CalendarExtender>
                 <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" Mask="99/99/9999"
                                        MaskType="Date" TargetControlID="txtDate">
                 </ajaxToolkit:MaskedEditExtender>
                </td>
                <td>
                <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
                </td>
                <td>
                    <asp:TextBox ID="txtXML" runat="server" Visible="false"></asp:TextBox>
                </td>
            </tr>
        </table>

        </div>
        <div id="cCenter">
           <!-- Content Header ex: Grids-->
            
            <asp:GridView ID="gvShow" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic"  OnRowDeleting="gvShow_RowDeleting">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                               <%# ((GridViewRow)Container).RowIndex + 1%>
                        </ItemTemplate>
                        <ItemStyle Width="10px" />
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="GROUP_HEAD_NAME" DataField="GROUP_HEAD_NAME" />
                    <asp:BoundField HeaderText="HEAD_AMOUNT" DataField="HEAD_AMOUNT" />
                    <asp:BoundField HeaderText="AMT_OR_PER" DataField="AMT_OR_PER" />
                    <asp:BoundField HeaderText="INSTALLMNT_TYPE" DataField="INSTALLMNT_TYPE" />
                    <asp:BoundField HeaderText="INSTALLMNT AMOUNT" DataField="INSTALLEMT_AMT" />
                    <asp:BoundField HeaderText="DATE" DataField="IN_DATE" />
                    <asp:CommandField HeaderText="DELETE"  ButtonType ="Image" DeleteImageUrl="~/images/delete.gif" ShowDeleteButton="True" />
                </Columns>

            </asp:GridView>

        </div>
         <div id="cFooter">
              <!-- Content Header ex:Buttons-->
           <asp:Button ID="btnInsert" runat="server"  Text="INSERT" OnClick="btnInsert_Click"/>
        </div>
</div>
</div>

</asp:Content>

