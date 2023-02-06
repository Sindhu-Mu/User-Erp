<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="FeeAdjust.aspx.cs" Inherits="Finance_BankAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <script lang="javascript" type="text/javascript"> 
         // Client Side Validation Script


         function SelectAllCheckboxes(spanChk) {


             var oItem = spanChk.children;
             var theBox = (spanChk.type == "checkbox") ?
                 spanChk : spanChk.children.item[0];
             xState = theBox.checked;
             elm = theBox.form.elements;

             for (i = 0; i < elm.length; i++)
                 if (elm[i].type == "checkbox" &&
                          elm[i].id != theBox.id) {
                     //elm[i].click();
                     if (elm[i].checked != xState)
                         elm[i].click();
                     //elm[i].checked=xState;
                 }

         }
    </script>
    <div class="container">
        <div class="heading">
            <h2>
                <!-- Page Heading-->
            Fee Adjust
            </h2>

        </div>
    
    <div id="cBody">
        <div id="cHead">
           <!-- Content  Header ex: Filters-->
            <table style="width:80%">
                <tr>
                   <th>Institute</th>
                   <th>Course</th>
                   <th>Branch</th>
                   <th>Semester</th>
                   <th>Session</th>
                   <th>Main Head Id</th>
                </tr>
                <tr>
                    <td>
                       <asp:DropDownList ID="ddlInstitute" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlInstitute_SelectedIndexChanged"></asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCourse" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged"></asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlBranch" runat="server"></asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSemType" runat="server">
                            <asp:ListItem >Select</asp:ListItem>
                            <asp:ListItem value="1">Odd</asp:ListItem>
                            <asp:ListItem  Value="2">Even</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSession" runat="server"></asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlMainHead" runat="server"></asp:DropDownList>
                    </td>
          
                    <td style="text-align:right">
                        <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click"/>
                    </td>
                    <td><asp:Button ID="btnAdjust" Text="Adjust" runat="server" OnClick="btnAdjust_Click" /></td>
                </tr>
                    
            </table>

        </div>
        <div id="cCenter">
           <!-- Content Header ex: Grids-->
            <asp:GridView ID="gvDetail" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" DataKeyNames="FEE_DEMAND_ID">
                <Columns>
                    <asp:TemplateField HeaderText="S#">
                        <ItemTemplate>
                             <%#((GridViewRow)Container).RowIndex+1 %>
                        </ItemTemplate>
                        <ItemStyle  Width="20px"/>
                    </asp:TemplateField>
                    <asp:BoundField  DataField="ENROLLMENT_NO" HeaderText="ENROLLMENT"/>
                    <asp:BoundField  DataField="STU_FULL_NAME" HeaderText="NAME"/>
                    <asp:BoundField DataField="INS_VALUE" HeaderText="INSTITUTE" />
                    <asp:BoundField  DataField="PGM_SHORT_NAME" HeaderText="COURSE"/>
                    <asp:BoundField  DataField="ACA_SEM_NO" HeaderText="SEM"/>
                    <asp:BoundField DataField="BRN_SHORT_NAME" HeaderText="BRANCH" />
                    <asp:BoundField DataField="FD_BALANCE_AMT" HeaderText="BALANCE AMOUNT" />
                    <asp:BoundField DataField="MONEY_CR_BAL_AMT" HeaderText="CREDIT AVAILABLE" />
                    <asp:BoundField DataField="FEE_DEMAND_ID" HeaderText="DEMAND ID" Visible="false" />      
                    <asp:TemplateField HeaderText="ADJUST AMT">
                      <ItemTemplate >
                          <asp:TextBox ID="txtAdjustAmt" runat="server" Text='<%# Bind("Pay") %>'  ></asp:TextBox>
                      </ItemTemplate>
                    </asp:TemplateField>  
                   <%-- <asp:TemplateField HeaderText="Select">
                        <ItemTemplate>
                            <asp:CheckBox ID="chk" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="Status">
                                            <HeaderTemplate>
                                                <input id="chkAll" onclick="javascript: SelectAllCheckboxes(this);" type="checkbox"
                                                    value="on" runat="server" />All
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                &nbsp;<asp:CheckBox ID="chk" runat="server" Text="" />
                                            </ItemTemplate>
                                            <ItemStyle Width="60px" />
                                        </asp:TemplateField>
                </Columns>
            </asp:GridView>

        </div>
         <div id="cFooter">
              <!-- Content Header ex:Buttons-->
             <div id="adj" runat="server">
             
             </div>
             <asp:TextBox ID="txtXML" runat="server" Visible="false"></asp:TextBox>
        </div>
</div>
</div>

</asp:Content>

