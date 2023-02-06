<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="FeeDemandCheck.aspx.cs" Inherits="StudentFinance_BankAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <script lang="javascript" type="text/javascript"> 
         // Client Side Validation Script

         function CheckControl(ctrl) {
             if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == "Select" || bTrim(document.getElementById(ctrl).value) == ".") {
                 document.getElementById(ctrl).style.backgroundColor = "#fc6";
                 return false;
             }
             else
                 document.getElementById(ctrl).style.backgroundColor = "#fff";
             return true;
         }
         function validation() {

             var flag = true;
             var msg = "", ctrl = "";
             if (!CheckControl("<%=ddlSession.ClientID%>")) {
                 msg += "- Select Session From List\n";
                 if (ctrl == "")
                     ctrl = "<%=ddlSession.ClientID%>";
        flag = false;
    }
    if (!CheckControl("<%=ddlSemtype.ClientID%>")) {
                  msg += "- Select Sem Type From List\n";
                  if (ctrl == "")
                      ctrl = "<%=ddlSemtype.ClientID%>";
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
            <h2>
                <!-- Page Heading-->
                Fee Demand Check
            </h2>

        </div>
    
    <div id="cBody">
        <div id="cHead">
           <!-- Content  Header ex: Filters-->
            <table>
                <tr>
                    <th>Session</th>
                   <td>
                 <asp:DropDownList ID="ddlSession" runat="server"></asp:DropDownList>
                 </td>
                    <th>Sem Type</th>
                    <td>
                <asp:DropDownList ID="ddlSemtype" runat="server">
                   <asp:ListItem>Select</asp:ListItem>
                    <asp:ListItem Value="0">Even</asp:ListItem>
                    <asp:ListItem Value="1">Odd</asp:ListItem>
                </asp:DropDownList>
                    </td>
                    <td>
                <asp:Button ID="btnShow"  runat="server" Text="Show" OnClick="btnShow_Click"/>
                    </td>
               </tr>
                </table>


        </div>
        <div id="cCenter">
           <!-- Content Header ex: Grids-->
            <table>
                  <tr>
                                <th id="th1" runat="server">
                                    <b>INSTITUITON WISE </b>
                                </th>
                               
                               <th id="th2" runat="server">
                                    <b>COURSE WISE</b></th>
                            </tr>
                <tr>
                    <td>
                 <asp:GridView ID="gvInstitute" runat="server" AutoGenerateColumns="False" 
                                        DataKeyNames="INS_ID" CssClass="gridDynamic" EmptyDataText="No Records Found"
                                        Width="100%" OnRowCommand="gvInstitute_RowCommand">

                     <Columns>
                          <asp:TemplateField HeaderText="S.No.">
                           <ItemTemplate>
                              <%# ((GridViewRow)Container).RowIndex + 1%>
                            </ItemTemplate>
                            <ItemStyle Width="30px" />
                           </asp:TemplateField>
                    <asp:ButtonField ButtonType="Link"  DataTextField="INS_VALUE" HeaderText="INSTITUTION" CommandName="INS"/>
                    <asp:BoundField DataField="TOTAL" HeaderText="TOTAL"/>
                    <asp:BoundField DataField="DEMANDED" HeaderText="DEMANDED"/>
                    <asp:BoundField DataField="NOT_DEMANDED" HeaderText="NOT DEMANDED"/>
                     </Columns>

                 </asp:GridView>
                    </td>
                    <td style="vertical-align:top">
            <asp:GridView ID="gvCourse" runat="server" AutoGenerateColumns="False"   CssClass="gridDynamic"
             EmptyDataText="No Records Found" Width="100%" DataKeyNames="INS_PGM_ID" OnRowCommand="gvCourse_RowCommand" >
                  <Columns>
                           <asp:TemplateField HeaderText="S.No.">
                                 <ItemTemplate>
                                      <%# ((GridViewRow)Container).RowIndex + 1%>
                                </ItemTemplate>
                            <ItemStyle Width="30px" />
                          </asp:TemplateField>
                  <asp:ButtonField  ButtonType="Link" DataTextField="PGM_SHORT_NAME" HeaderText="COURSE"  CommandName="COURSE" />
                <asp:BoundField DataField="TOTAL" HeaderText="TOTAL"/>
                <asp:BoundField DataField="DEMANDED" HeaderText="DEMANDED"/>
                <asp:BoundField DataField="NOT_DEMANDED" HeaderText="NOT DEMANDED"/>
                  </Columns>
            </asp:GridView>
                    </td>
                    <td></td>
                </tr>
                <tr>
                      <th id="th3" runat="server">
                      <b>BRANCH WISE </b>
                      </th>
                      <th id="th4" runat="server">
                      <b>SEMESTER WISE</b></th>
                </tr>
                <tr>
                    <td>
                      <asp:GridView ID="gvBranch" runat="server" AutoGenerateColumns="False" 
                       DataKeyNames="PGM_BRN_ID" CssClass="gridDynamic" EmptyDataText="No Records Found"
                       Width="100%" OnRowCommand="gvBranch_RowCommand">
                        <Columns>
                             <asp:TemplateField HeaderText="S.No.">
                                                <ItemTemplate>
                                                       <%# ((GridViewRow)Container).RowIndex + 1%>
                                                </ItemTemplate>
                                                 <ItemStyle Width="30px" />
                                            </asp:TemplateField>
                                       <asp:ButtonField  ButtonType="Link" DataTextField="BRN_SHORT_NAME" HeaderText="BRANCH" CommandName="BRANCH" />
                  <asp:BoundField DataField="TOTAL" HeaderText="TOTAL"/>
                <asp:BoundField DataField="DEMANDED" HeaderText="DEMANDED"/>
                <asp:BoundField DataField="NOT_DEMANDED" HeaderText="NOT DEMANDED"/>
                 </Columns>
                </asp:GridView>
                    </td>
                    <td style="vertical-align:top">
                  <asp:GridView ID="gvSemester"  runat="server" AutoGenerateColumns="False" GridLines="None"
                         DataKeyNames="ACA_SEM_ID" CssClass="gridDynamic" EmptyDataText="No Records Found"
                        Width="100%">
                         <Columns>
                              <asp:TemplateField HeaderText="S.No.">
                                   <ItemTemplate>
                                       <%# ((GridViewRow)Container).RowIndex + 1%>
                                    </ItemTemplate>
                                 <ItemStyle Width="30px" />
                              </asp:TemplateField>
                
                             <asp:BoundField DataField="ACA_SEM_ID" HeaderText="SEM"/>
                    <asp:BoundField DataField="TOTAL" HeaderText="TOTAL"/>
                    <asp:BoundField DataField="DEMANDED" HeaderText="DEMANDED"/>
                    <asp:BoundField DataField="NOT_DEMANDED" HeaderText="NOT DEMANDED"/>
                            </Columns>
                     </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td>

                     <asp:GridView ID="gvStudent" runat="server" AutoGenerateColumns="False" GridLines="None"
                                        CssClass="gridDynamic" EmptyDataText="No Records Found"
                                      Width="100%" DataKeyNames="PGM_BRN_ID">
                                     <Columns>
                                         <asp:TemplateField HeaderText="S.No.">
                                           <ItemTemplate>
                                                 <%# ((GridViewRow)Container).RowIndex + 1%>
                                           </ItemTemplate>
                                            <ItemStyle Width="30px" />
                                         </asp:TemplateField>
                                          <asp:BoundField DataField="ENROLLMENT_NO" HeaderText="ENROLLMENT" />
                                         <asp:BoundField DataField="STU_FULL_NAME" HeaderText="NAME" />
                                        <asp:BoundField DataField="DEMANDED" HeaderText="DEMAND STATUS"/>
                                      <%-- <asp:BoundField DataField="NOT_DEMANDED" HeaderText="NOT DEMANDED"/>--%>
                                     </Columns>
                                 </asp:GridView>

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

