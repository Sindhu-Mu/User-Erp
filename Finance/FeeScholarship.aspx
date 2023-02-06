<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="FeeScholarship.aspx.cs" Inherits="Finance_BankAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <script language="javascript" type="text/javascript"> 
         // Client Side Validation Script
    </script>
    <div class="container">
        <div class="heading">
            <h2>
               Fee Scholarship

            </h2>

        </div>
    
    <div id="cBody">
        <div id="cHead">
           <!-- Content  Header ex: Filters-->
            <table style="width:80%">
                <tr>
                    <th>Session<span style="color:red">*</span></th>
                    <th>Institute</th>
                    <th>Course</th>
                    <th>Branch</th>
                    <th>Percentage</th>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="ddlSession" runat="server"></asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlInstitute" runat="server" OnSelectedIndexChanged="ddlInstitute_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCourse" runat="server" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlBranch" runat="server"></asp:DropDownList>
                    </td>
                    <td>
                       <asp:DropDownList ID="ddlPercentage" runat="server">
                           <asp:ListItem Value="0">All</asp:ListItem>
                           <asp:ListItem Value="0">25%</asp:ListItem>
                           <asp:ListItem Value="0">50%</asp:ListItem>
                           <asp:ListItem Value="0">100%</asp:ListItem>
                       </asp:DropDownList>
                    </td>
                    <td>
                       <asp:Button  ID="btnView" runat="server" Text="View" OnClick="btnView_Click"/>
                    </td>
                </tr>
            </table>

        </div>
        <div id="cCenter">
           <!-- Content Header ex: Grids-->
            <asp:GridView ID="gvStudent" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" DataKeyNames="STU_MAIN_ID">
               <Columns>
                   <asp:TemplateField HeaderText="S.No.">
                       <ItemTemplate>
                           <%# ((GridViewRow)Container).RowIndex + 1%>
                       </ItemTemplate>
                       <ItemStyle Width="20px" />
                   </asp:TemplateField>
                   <asp:BoundField DataField="STU_FULL_NAME" HeaderText="Name" />
                   <asp:BoundField DataField="PGM_SHORT_NAME" HeaderText="COURSE" />
                   <asp:BoundField DataField="BRN_SHORT_NAME" HeaderText="BRANCH" />
                   <asp:BoundField DataField="PER" HeaderText="EXAM(%)" />
                   <asp:BoundField DataField="TOTAL" HeaderText="FEE AMT" DataFormatString="{0:N2}"/>
                   <asp:BoundField DataField="scho" HeaderText="SCHOLARSHIP(%)" />
                   <asp:BoundField DataField="SCHO_AMT" HeaderText="SCHOLARSHIP(AMT.)" DataFormatString="{0:N2}" />
                   <asp:TemplateField>
                       <HeaderTemplate>
                            <input id="chkAll" onclick="javascript: SelectAllCheckboxes(this);" type="checkbox"
                                    value="on" runat="server" />
                       </HeaderTemplate>
                       <ItemTemplate>
                          <asp:CheckBox ID="chk1" runat="server" />
                        </ItemTemplate>
                   </asp:TemplateField>
               </Columns>
            </asp:GridView>
            

        </div>
         <div id="cFooter">
              <!-- Content Header ex:Buttons-->
             <table id="trSave" runat="server" visible="false">
                 <tr>
                     <th>Remark</th>
                 </tr>
                 <tr>
                     <td>
                        <asp:TextBox ID="txtRemark" runat="server"></asp:TextBox>    
                     </td>
                     <td>
                          <asp:Button  ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"/>
                     </td>
                     <td>
                      <asp:TextBox ID="txtData" runat="server" Visible="false"></asp:TextBox>
                     </td>
                 </tr>
                 <tr>
                     <td>
                         <asp:Button ID="btnExport" runat="server" Text="Export To Excel" OnClick="btnExport_Click" />
                     </td>
                 </tr>
          
             </table>

        </div>
</div>
</div>

</asp:Content>

