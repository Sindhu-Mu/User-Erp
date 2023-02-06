<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="FeeDailyReceivable.aspx.cs" Inherits="StudentFinance_BankAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script  lang="javascript" type="text/javascript">
        // Client Side Validation Script

    </script>
    <div class="container">
        <div class="heading">
            <h2>Fee Daily Receivable
            </h2>

        </div>

        <div id="cBody">
            <div id="cHead">
                <!-- Content  Header ex: Filters-->
            </div>
            <div id="cCenter">
                 <table style="width: 100%">
                     <tr>
                         <td style="padding-left: 20px;">
                    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>--%>
                        <table style="border-collapse: collapse; margin: 0px; border: 0px;">
                            <tr>
                                <th>Select Session:<span style="color:red">*</span></th>
                                <td>
                                <asp:DropDownList ID="ddlSession" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSession_SelectedIndexChanged"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                            </tr>
                            <tr>
                                <td></td>
                            </tr>
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
                                          <asp:BoundField DataField="BALANCE" HeaderText="AMOUNT" DataFormatString="{0:N2}" />
                                      </Columns>
                                  </asp:GridView>
                                    
                                </td>
                                <td>
                                    <asp:GridView ID="gvCourse" runat="server" AutoGenerateColumns="False" 
                                        CssClass="gridDynamic" EmptyDataText="No Records Found" Width="100%" DataKeyNames="INS_PGM_ID" OnRowCommand="gvCourse_RowCommand" >
                                        <Columns>
                                            <asp:TemplateField HeaderText="S.No.">
                                                <ItemTemplate>
                                                     <%# ((GridViewRow)Container).RowIndex + 1%>
                                                </ItemTemplate>
                                                <ItemStyle Width="30px" />
                                            </asp:TemplateField>
                                            <asp:ButtonField  ButtonType="Link" DataTextField="PGM_SHORT_NAME" HeaderText="COURSE"  CommandName="COURSE" />
                                            <asp:BoundField DataField="BALANCE" HeaderText="AMOUNT" DataFormatString="{0:N2}" />
                                        </Columns>
                                    </asp:GridView>
                                </td>
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
                                            <asp:BoundField DataField="BALANCE" HeaderText="AMOUNT" DataFormatString="{0:N2}" />
                                        </Columns>
                                    </asp:GridView>
                                </td>
                                <td>
                                 <asp:GridView ID="gvSemester"  runat="server" AutoGenerateColumns="False" GridLines="None"
                                        DataKeyNames="FEE_SEM_NO" CssClass="gridDynamic" EmptyDataText="No Records Found"
                                        Width="100%">
                                     <Columns>
                                         <asp:TemplateField HeaderText="S.No.">
                                             <ItemTemplate>
                                                  <%# ((GridViewRow)Container).RowIndex + 1%>
                                             </ItemTemplate>
                                              <ItemStyle Width="30px" />
                                         </asp:TemplateField>
                                          <asp:ButtonField DataTextField="ACA_SEM_ID" HeaderText="SEMESTER"  CommandName="SEM" />
                                          <asp:BoundField DataField="BALANCE" HeaderText="AMOUNT" DataFormatString="{0:N2}" />
                                     </Columns>
                                 </asp:GridView>
                                    
                                </td>
                            </tr>
                            <tr>
                                <th id="th5" runat="server" colspan="2">
                                 <b>STUDENT WISE</b>
                                </th>
                            </tr>
                            <tr>
                                <td colspan="2">
                                 <asp:GridView ID="gvStudent" runat="server" AutoGenerateColumns="False" GridLines="None"
                                        CssClass="gridDynamic" EmptyDataText="No Records Found"
                                      Width="100%" DataKeyNames="STU_ADM_NO,PGM_BRN_ID,FEE_SEM_NO" OnRowCommand="gvStudent_RowCommand"  >
                                     <Columns>
                                         <asp:TemplateField HeaderText="S.No.">
                                           <ItemTemplate>
                                                 <%# ((GridViewRow)Container).RowIndex + 1%>
                                           </ItemTemplate>
                                            <ItemStyle Width="30px" />
                                         </asp:TemplateField>
                                         <asp:ButtonField DataTextField="ENROLLMENT_NO" HeaderText="ENROLLMENT" CommandName="ENROLL" />
                                         <asp:BoundField DataField="STU_FULL_NAME" HeaderText="NAME" />
                                         <asp:BoundField DataField="BALANCE" HeaderText="AMOUNT" DataFormatString="{0:N2}" />
                                     </Columns>
                                 </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                              <%--    <b>
                                        <asp:Label ID="lblStudent" runat="server"></asp:Label>
                                        WISE </b>--%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                 <asp:GridView ID="gvFeeDemand" runat="server" AutoGenerateColumns="False" CssClass="gridDynamic"
                                        DataKeyNames="FEE_MAIN_HEAD_ID" OnRowCommand="gvFeeDemand_RowCommand" ShowFooter="true">
                                  <Columns>
                                     <asp:BoundField HeaderText="SL.NO" />
                                            <asp:ButtonField CommandName="Show" DataTextField="FEE_MAIN_HEAD_NAME" HeaderText="FEE HEAD">
                                                <ControlStyle Font-Underline="True" ForeColor="Blue" />
                                            </asp:ButtonField>
                                            <asp:BoundField DataField="FD_SUB_IN_DT" DataFormatString="{0:dd/MM/yyyy}" FooterText="TOTAL DEMAND"
                                                HeaderText="DEMAND DATE">
                                                <FooterStyle Font-Bold="True" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DEMAND" HeaderText="DEMAND AMT">
                                                <FooterStyle Font-Bold="True" />
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField> 
                                  </Columns>

                                 </asp:GridView>
                                </td>
                                <td>
                                    <asp:GridView ID="gvFeeReceive" runat="server" AutoGenerateColumns="False" CssClass="gridDynamic" ShowFooter="true" >
                                        <Columns>
                                            <asp:BoundField HeaderText="SL.NO" />
                                            <asp:ButtonField CommandName="Show" DataTextField="FEE_RCV_RECEIPT_NO" HeaderText="REC.NO.">
                                            </asp:ButtonField>
                                            <asp:BoundField HeaderText="FEE HEAD" DataField="FEE_MAIN_HEAD_NAME" />
                                            <asp:BoundField DataField="FEE_RCV_TRAN_DT" DataFormatString="{0:dd/MM/yyyy}" HeaderText="RECEIVED DATE"
                                                FooterText="TOTAL">
                                                <FooterStyle Font-Bold="True" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="RECEIVED" HeaderText="RECEIVED AMT">
                                                <FooterStyle Font-Bold="True" />
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="BALANCE">
                                                <FooterStyle Font-Bold="True" />
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table> 
                      <%--  </ContentTemplate>
                        </asp:UpdatePanel>--%>
                         </td>
                     </tr>
                </table>
            </div>
            <div id="cFooter">  
            </div>
           
        </div>
    </div>

</asp:Content>

