<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="StudentLeadger.aspx.cs" Inherits="Finance_BankAccount" %>

<%@ Register Src="~/Control/Student.ascx" TagPrefix="uc1" TagName="Student" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script lang="javascript" type="text/javascript">
        // Client Side Validation Script
    </script>
    <div class="container">
        <div class="heading">
            <h2>Student Payment History</h2>
        </div>
        <div id="cBody">
            <div id="cHead" style="float: right;">
                <asp:TextBox ID="txtEnrollment" runat="server" Width="250px" Height="30px"></asp:TextBox>
                <asp:Button ID="btnFind" runat="server" Height="30px" Text="Get Detail" OnClick="btnFind_Click" />
                 <asp:Button ID="btnLeadger" runat="server" Height="30px" Text="Get Leadger" OnClick="btnLeadger_Click" />
            </div>
            <div class="cleaner"></div>
        </div>
        <div id="cCenter">
            <div>
                <!-- Content Header ex: Grids-->
              
                <uc1:Student runat="server" ID="Student" />
                <br />
            </div>
            <!-- Content Header ex: Grids-->
            <div>
                <h3>Semester Wise Student Leadger </h3>
            </div>
          
            <div>
                <asp:GridView ID="gvDetail" AutoGenerateColumns="false" CssClass="gridDynamic" runat="server">
                    <Columns>
                        <asp:TemplateField HeaderText="S.No.">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                            </ItemTemplate>

                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Enrollment No." DataField="ENROLL" />
                        <asp:BoundField HeaderText="Name" DataField="NAME" />
                        <asp:BoundField HeaderText="Semester" DataField="SEM" />
                         <asp:BoundField HeaderText="Demand" DataField="Demand" />
                        <asp:BoundField HeaderText="Adjust" DataField="Adjust" />
                        <asp:BoundField HeaderText="Concession" DataField="Concession" />                    
                        <asp:BoundField HeaderText="Receive" DataField="Receive" />
                            <asp:BoundField HeaderText="Balance" DataField="Balance" />
                        <asp:HyperLinkField HeaderText="Leadger" DataNavigateUrlFields="Leadger_Link" DataTextField="VIEW_LINK" Target="_blank" />
                    </Columns>

                </asp:GridView>
            </div>
            <div>
                <h3>Semester Wise Fee Receipt </h3>
            </div>
            <div>
                <asp:GridView ID="gvPayTransaction" runat="server" AutoGenerateColumns="False" EmptyDataText="No record found." DataKeyNames="FEE_RCV_RECEIPT_NO" CssClass="gridDynamic">
                    <Columns>
                        <asp:TemplateField HeaderText="S.No.">
                            <ItemTemplate>
                                <%#((GridViewRow)Container).RowIndex +1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:HyperLinkField DataTextField="RECEIPT_NO" HeaderText="Receipt No" ControlStyle-ForeColor="Blue" DataNavigateUrlFields="FEE_RCV_RECEIPT_NO" DataNavigateUrlFormatString="prtFeeReceipt.aspx?id={0}" Target="_blank" ItemStyle-Width="170px" />
                           <asp:BoundField HeaderText="Semester" DataField="SEM" />
                        <asp:BoundField DataField="AMOUNT" HeaderText="Amount" />
                        <asp:BoundField DataField="FEE_DEPOSIT_DT" HeaderText="Deposit Date" DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField DataField="TRAN_DT" HeaderText="Entry Date" DataFormatString="{0:dd/MM/yyyy HH:mm}" />
                        <asp:BoundField DataField="EMP_NAME" HeaderText="Entry By" />
                        <%--<asp:BoundField DataField="FEE_RCV_REMARK" HeaderText="Remark" />--%>
                    </Columns>
                    <SelectedRowStyle BackColor="Yellow" />
                </asp:GridView>
            </div>
        </div>
        <div id="cFooter">
            <!-- Content Header ex:Buttons-->

        </div>
    </div>


</asp:Content>

