<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="TransportFinSpecialApproval.aspx.cs" Inherits="Facility_TransportFinSpecialApproval" %>

<%@ Register Src="~/Control/Student.ascx" TagPrefix="uc1" TagName="Student" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <div class="heading">
            <h2>Transport Special Approval</h2>
        </div>
        <table>
            <tr>
                <td>
                    <asp:UpdatePanel ID ="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <table>
                                <tr>
                                    <td>
                                        <table>
                                            <tr>
                                                <th>Enrollment No</th>
                                                <td>
                                                    <asp:TextBox ID="txtEnroll" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td><uc1:Student runat="server" ID="Student" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        <ajaxToolkit:AutoCompleteExtender ID="autoComplete2" runat="server" EnableCaching="true"
                                    TargetControlID="txtEnroll" ServicePath="~/AutoComplete.asmx" ServiceMethod="GetStudentList"
                                    MinimumPrefixLength="1" ContextKey="1" CompletionSetCount="12" CompletionInterval="500">
                                </ajaxToolkit:AutoCompleteExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table>
                                            <tr>
                                                <th>Permission Type</th>
                                                <th>Amount</th>
                                                <th>Amount Due Date</th>
                                                <th>Approved By</th>
                                                <th>Approved Date</th>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:DropDownList ID="ddlPerType" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtAmt" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtAmtDueDt" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlAppBy" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtAppDt" runat="server"></asp:TextBox>
                                                     
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>

                                        <asp:GridView ID="gvView" runat="server" AutoGenerateColumns="False"  CssClass="gridDynamic" Width="754px" >
                                             <Columns>
                                                      <asp:TemplateField HeaderText="S.No.">
                                                         <ItemTemplate>
                                                             <%# ((GridViewRow)Container).RowIndex + 1%>                                .
                                                               </ItemTemplate>
                                                               <ItemStyle Width="15px" />
                                                      </asp:TemplateField>
                                              <asp:BoundField HeaderText="Permission Type" DataField="PER_VALUE" />
                                               <asp:BoundField HeaderText="Amount" DataField="AMT" />
                                                 <asp:BoundField HeaderText="Amount Due Date" DataField="AMT_DUE_DATE" DataFormatString="{00:dd/MM/yyyy}" />
                                                 <asp:BoundField HeaderText="Approved By" DataField="EMP_NAME" />
                                                  <asp:BoundField HeaderText="Approved Date" DataField="APR_DATE" DataFormatString="{00:dd/MM/yyyy}" />
                                                  </Columns>
                                        </asp:GridView>

                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="txtAmtDueDt">
                                                   </ajaxToolkit:CalendarExtender>
                                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtAmtDueDt" Mask="99/99/9999" MaskType="Date">
                                                    </ajaxToolkit:MaskedEditExtender>
                                    </td>
                                    <td>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" runat="server" TargetControlID="txtAppDt">
                                                     </ajaxToolkit:CalendarExtender>
                                                      <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtAppDt" Mask="99/99/9999" MaskType="Date">
                                                       </ajaxToolkit:MaskedEditExtender>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

