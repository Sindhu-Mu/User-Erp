<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="TransportFinReceive.aspx.cs" Inherits="Facility_TransportFinReceive" %>

<%@ Register Src="~/Control/Student.ascx" TagPrefix="uc1" TagName="Student" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="container">
        <div class="heading">
            <h2>Transport Fee Receive</h2>
        </div>
         <table>
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                 <ContentTemplate>
                        <tr>
                            <td>
                                <table>
                                        <tr>
                                            <th>ENROLLMENT NO</th>
                                            <td>
                                                <asp:TextBox ID="txtEnroll" runat="server" Width="300px" CssClass="textbox"></asp:TextBox></td>
                                            <td>
                                                <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click"></asp:Button>
                                            </td>
                                        </tr>
                                    
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <uc1:Student runat="server" id="ctrlStudent" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <ajaxToolkit:AutoCompleteExtender ID="autoComplete2" runat="server" EnableCaching="true"
                                    TargetControlID="txtEnroll" ServicePath="~/AutoComplete.asmx" ServiceMethod="GetStudentList"
                                    MinimumPrefixLength="1" ContextKey="1" CompletionSetCount="12" CompletionInterval="500">
                                </ajaxToolkit:AutoCompleteExtender>
                                &nbsp; &nbsp; &nbsp;&nbsp;
                            </td>
                        </tr>
                        <tr id="trReg" runat="server">
                            <td>
                                <div class="container">
                               <div class ="heading">
                                <h2>Registration Detail</h2>
                            </div>
                                <table>
                                        <tr>
                                           <th>CITY NAME :</th>
                                                <td><asp:Label ID="lblCity" runat="server"></asp:Label></td>
                                            <th>ROUTE :</th>
                                                <td><asp:Label ID="lblRoute" runat="server"></asp:Label></td>
                                            <th>STOPPAGE :</th>
                                             <td><asp:Label ID="lblStoppage" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <th>FROM DATE:</th>
                                                    <td><asp:Label ID="lblFromDt" runat="server"></asp:Label>
                                            </td>
                                            <th>TO DATE:</th>
                                                  <td><asp:Label ID="lblToDt" runat="server"></asp:Label>
                                                
                                            </td>
                                            <th>NO OF DAYS:</th>
                                                 <td><asp:Label ID="lblNOD" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>REG. DATE:</th>
                                                 <td><asp:Label ID="lblRegDt" runat="server"></asp:Label>
                                            </td>
                                            <th>
                                                    APPLIED BY :</th>
                                                  <td><asp:Label ID="lblAppBy" runat="server"></asp:Label>
                                            </td>
                                            <th>                                           
                                                   CHALLAN NO:</th>
                                                  <td><asp:Label ID="lblChallan" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>
                                                DEMAND AMOUNT:</th>
                                            <td>
                                                <asp:Label ID="lblAmount" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label></td>
                                        </tr>
                                    </table>
                                    </div>
                                </td>
                            </tr>
                                        <tr id="trPayment" runat="server">
                                            <td>
                                                <div class ="heading">
                                                    <h2>Payment Option</h2>
                                                </div>
                                            <table>
                                        <tr>
                                            <th>Pay Mode<span class="required">*</span></th>
                                            <td>
                                                <asp:DropDownList ID="ddlPaymode" runat="server"
                                                    AutoPostBack="True" OnSelectedIndexChanged="ddlPaymode_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>  Amount<span class="required">*</span></th>
                                              <td>
                                                <asp:TextBox ID="txtAmount" runat="server" Width="150px"></asp:TextBox></td>
                                        </tr>                   
                                        <tr id="trBankOption" runat="server">
                                            <td>
                                                <table>
                                                    <tr>
                                            <th>Bank Name<span class="required">*</span></th>
                                                            <td>
                                                                <asp:DropDownList ID="ddlBank" runat="server" Width="224px">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <th>
                                                               Branch Name<span class="required">*</span></th>
                                                            <td>
                                                                <asp:TextBox ID="txtBranchName" runat="server" Width="150px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                <tr>
                                                    <th>
                                                        <asp:Label ID="lblRefNo" runat="server" Text="Label"></asp:Label>
                                                    </th>
                                                    <td><asp:TextBox ID="txtRefNo" runat="server"></asp:TextBox></td>
                                                </tr>
                                                </table>
                                                </td>
                                            </tr>
                                        <tr>
                                            <th>
                                                Deposit Acount No.<span class="required">*</span></th>
                                            <td>
                                                <asp:DropDownList ID="ddlAccNo" runat="server">
                                                </asp:DropDownList></td>
                                        </tr>
                                        <tr>
                                            <th >
                                                Payment Date<span class="required">*</span></th>
                                            <td>
                                                <asp:TextBox ID="txtDate" runat="server" Width="75px" CssClass="textbox"></asp:TextBox>&nbsp;
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="txtDate"></ajaxToolkit:CalendarExtender>
                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtDate" Mask="99/99/9999"
                                MaskType="Date">
                            </ajaxToolkit:MaskedEditExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Button ID="btnModeAdd" runat="server" Text="Add Detail" OnClick="btnModeAdd_Click"></asp:Button>
                                                 <asp:TextBox ID="txtData" runat="server" Visible="False"></asp:TextBox>
                                            </td>
                                        </tr>
                                                </table>
                                                </td>
                                            </tr>
                                        <tr>
                                            <td>
                                                <asp:GridView ID="gvAddDetail" runat="server" AutoGenerateColumns="False"  CssClass="gridDynamic" OnRowDeleting="gvAddDetail_RowDeleting">
                        <Columns>
                            <asp:TemplateField HeaderText="S.No">
                                <ItemTemplate>
                                    <%# ((GridViewRow)Container).RowIndex + 1%>                                .
                                </ItemTemplate>
                                <ItemStyle Width="15px" />
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Pay Mode" DataField="PAY_MODE_VALUE" />
                            <asp:BoundField HeaderText="Bank" DataField="BANK_VALUE" />
                            <asp:BoundField HeaderText="Ref No." DataField="TRAN_MODE_NO" />
                            <asp:BoundField HeaderText="Date" DataField="TRAN_MODE_DATE" />
                            <asp:BoundField HeaderText="Amount" DataField="TRAN_MODE_AMT" />
                            <asp:CommandField ButtonType="Button" ShowDeleteButton="true"/>
                        </Columns>
                    </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr id="trRemark" runat="server">
                                            <td>
                                                <table>
                                                    <tr>
                                                    <th>REMARK</th>
                                            <td>
                                                <asp:TextBox ID="txtRemark" runat="server"></asp:TextBox></td>
                                            <td>
                                                <asp:Button ID="btnReceive" runat="server" Text="Receive" OnClick="btnReceive_Click"></asp:Button></td>
                                        </tr>
                                                    </table>
                            </td>
                        </tr>                             
                </table>
                </ContentTemplate></asp:UpdatePanel>
            </td>
        </tr>
    </table>
         </div>
</asp:Content>

