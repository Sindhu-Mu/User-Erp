<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="ConcessionRule.aspx.cs" Inherits="Finance_BankAccount"  EnableEventValidation="true"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <script language="javascript" type="text/javascript"> 
         // Client Side Validation Script
    </script>
    <div class="container">
        <div class="heading">
            <h2>
                <!-- Page Heading-->
              Concession Rule 
            </h2>

        </div>
    
    <div id="cBody">
        <div id="cHead">
           <!-- Content  Header ex: Filters-->
           <table>
               <tr>
                   <th>
                       Rule Name
                   </th>
                   <th>
                      Description
                   </th>
                    <th>
                       Quota
                   </th>
                    <th>
                       Relation
                   </th>
                    <th>
                       Session
                   </th>
                    <th>
                   Percentage
                   </th>
                    <th>
                       Max Amount
                   </th>

               </tr>
               <tr>
                    <td>
                        <asp:TextBox ID="txtRuleName" runat="server"></asp:TextBox>
                   </td>
                   <td>
                       <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
                   </td>
                    <td>
                        <asp:DropDownList ID="ddlQuota" runat="server"></asp:DropDownList>
                   </td>
                    <td>
                      <asp:DropDownList ID="ddlRelation" runat="server"></asp:DropDownList>
                   </td>
                    <td>
                       <asp:DropDownList ID="ddlSession" runat="server"></asp:DropDownList>
                   </td>
                    <td>
                      <cc1:NumericTextBox ID="txtPercentage" runat="server" Width="80px"></cc1:NumericTextBox>
                   </td>
                    <td>
                        <cc1:NumericTextBox ID="txtMaxAmt" runat="server" Width="80px"></cc1:NumericTextBox>
                   </td>
                   <td>
                       <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                       </td>

               </tr>
               </table>
        </div>
        <div id="cCenter">
           <!-- Content Header ex: Grids-->
            <HR/>
             <asp:GridView ID="gridShow" runat="server" Width="100%" CssClass="gridDynamic" AutoGenerateColumns="False"
                                EmptyDataText="No Record Found." DataKeyNames="CONC_RULE_ID"  OnRowCommand="gridShow_RowCommand" >
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No.">
                                        <ItemTemplate>
                                            <%# ((GridViewRow)Container).RowIndex + 1%>
                                        </ItemTemplate>
                                        <ItemStyle Width="50px" />
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="CONC_RULE_NAME" HeaderText="Rule Name" />
                                    <asp:BoundField DataField="QUOTA_NAME" HeaderText="Quota Name" />
                                    <asp:BoundField DataField="RELATION_NAME" HeaderText="Relation" />
                                    <asp:BoundField DataField="CONC_PERCENTAGE" HeaderText="Percentage" />
                                    <asp:BoundField DataField="CONC_MAX_AMT" HeaderText="Max Concession" />
                                    <asp:BoundField DataField="RULE_STATUS" HeaderText="Max Concession" Visible="false" />
                                    <asp:TemplateField ShowHeader="False" HeaderText="Status">
                                        <ItemStyle Width="20px" HorizontalAlign="Right" />
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="false" CommandArgument='<%# Bind("CONC_RULE_ID") %>'
                                                ImageUrl='<%# Bind("STS_IMG") %>' CommandName='<%# Bind("STS_CMD") %>' ToolTip='<%# Bind("STS_TOOLTIP")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
        </div>
         <div id="cFooter">
              <!-- Content Header ex:Buttons-->

        </div>
</div>
</div>

</asp:Content>

