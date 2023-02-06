<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="FeeWave.aspx.cs" Inherits="Finance_BankAccount" %>
<%@ Register Src="~/Control/Student.ascx" TagPrefix="uc1" TagName="Student" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <script lang="javascript" type="text/javascript"> 
         // Client Side Validation Script
    </script>
    <div class="container">
        <div class="heading">
            <h2>
                <!-- Page Heading-->
                Fee Waive
            </h2>

        </div>
    
    <div id="cBody">
        <div id="cHead">
           <!-- Content  Header ex: Filters-->
           Branch <asp:DropDownList ID="ddlBranch" runat="server"></asp:DropDownList>&nbsp;&nbsp;
           Semester<asp:DropDownList ID="ddlSem" runat="server"></asp:DropDownList>&nbsp;&nbsp;
           Enrollment<asp:TextBox ID="txtEnrollment" runat="server" Width="250px"></asp:TextBox>&nbsp;&nbsp;
            <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" />&nbsp;&nbsp;  
        </div>
        <div id="cCenter">
           <!-- Content Header ex: Grids-->
            <br/>
            <uc1:Student runat="server" ID="Student" />
            <br/>
            <asp:GridView ID="gvData" runat="server" AutoGenerateColumns="False" Width="100%"
                                                         DataKeyNames="FEE_MAIN_HEAD_ID" ShowFooter="True" CssClass="gridDynamic" >
                                                        <Columns>
                                                       
                                                            <asp:TemplateField HeaderText="S.No." ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                <%#Container.DataItemIndex+1%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            <asp:BoundField HeaderText="Head Name" DataField ="FEE_MAIN_HEAD_NAME"/>
                                                            <asp:BoundField HeaderText="Demand Amount"  DataField ="FD_FEE_AMT" />
                                                            <asp:BoundField HeaderText="Waive Amount" DataField ="FEE_WAVE_OFF"  />
                                                            <asp:BoundField HeaderText="Balance Amount"  DataField ="FD_BALANCE_AMT" />
                                                           
                                                        </Columns>
                                                        <HeaderStyle ForeColor="#CC0000" />
                                                    </asp:GridView>
            <table>
                <tr><td>Group Head</td><td>Head</td><td>Deduction Amount</td></tr>
                <tr>
                    <td><asp:DropDownList ID="ddlGroupHead" runat="server" OnSelectedIndexChanged="ddlGroupHead_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></td>
                    <td><asp:dropdownlist runat="server" ID="ddlHead" OnSelectedIndexChanged="ddlHead_SelectedIndexChanged"></asp:dropdownlist></td>
                    <td><asp:TextBox runat="server" ID="txtValue"></asp:TextBox></td>
                    <td><asp:DropDownList ID="ddlType" runat="server" OnSelectedIndexChanged="ddlHead_SelectedIndexChanged" AutoPostBack="true">
                        <asp:ListItem Value="-1" >Select</asp:ListItem>
                        <asp:ListItem Value="0" >Value</asp:ListItem>
                        <asp:ListItem Value="1">Percentage</asp:ListItem>
                        </asp:DropDownList></td>
                    <td><asp:TextBox runat="server" ID="txtAmount" Enabled="false"></asp:TextBox></td>
                    <td><asp:Button runat="server" Text="Add" id="add" OnClick="add_Click"/></td>
                </tr>
                
                </table>
            <hr />
            <asp:GridView runat="server" ID="gv_Data" AutoGenerateColumns="false" OnRowDeleting="gv_Data_RowDeleting" >
                <Columns>
                    <asp:BoundField HeaderText="Head Name" DataField ="HEAD_MAIN_VALUE"/> 
                    <asp:BoundField HeaderText="Waive Amount"  DataField ="AMOUNT" />
                    <asp:CommandField ButtonType="Image" DeleteImageUrl="~/images/delete.gif" ShowDeleteButton="True"  />
                </Columns>

                </asp:GridView>
        </div>
         <div id="cFooter">
              <!-- Content Header ex:Buttons-->
             <br/>
            <table>
                <tr><td>Approve By</td><td><asp:TextBox ID="txtApproveBy" runat="server"></asp:TextBox></td></tr>
                                <tr>
                                    <td>Deposit Date</td><td><asp:TextBox ID="txtDepositDate" runat="server"></asp:TextBox>
                                                         </td>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDepositDate" Format="MM/dd/yyyy">
                    </ajaxToolkit:CalendarExtender>
                                    <td>Remark</td><td><asp:TextBox ID="txtRemark" runat="server"></asp:TextBox></td>
                                    <td><asp:Button ID="btnInsert" runat="server" Text="INSERT" OnClick="btnInsert_Click" /><br/></td>
                                    </tr>
                                </table>
             
             <asp:TextBox runat="server" ID="txtXML"  Visible="false"></asp:TextBox>

        </div>
</div>
</div>

</asp:Content>

