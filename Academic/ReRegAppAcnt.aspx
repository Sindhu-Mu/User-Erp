<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="ReRegAppAcnt.aspx.cs" Inherits="Academic_ReRegAppAcnt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script lang="javascript" type="text/javascript">
        function SelectAllCheckboxes(spanChk) {


            var oItem = spanChk.children;
            var theBox = (spanChk.type == "checkbox") ?
                spanChk : spanChk.children.item[0];
            xState = theBox.checked;
            elm = theBox.form.elements;

            for (i = 0; i < elm.length; i++)
                if (elm[i].type == "checkbox" &&
                         elm[i].id != theBox.id) {
                    if (elm[i].checked != xState)
                        elm[i].click();
                }

        }
    </script>
    <div class="container">
        <div class="heading">
            <h2>Re-Registration Approval</h2>
        </div>
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
        
               <table>
                    <tr>
                        <th>By RegFor</th>
                        <th>By Enrollment</th>
                        <th>By Institute</th>
                        <th>By Program</th>
                        <th>By Branch</th>
                        <th>By Semester</th>
                        <th>By Status</th>

                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="ddlRegFor" runat="server" Width="100px"></asp:DropDownList>
                        </td>
                        <td>
                            <asp:TextBox ID="txtEnroll" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlIns" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlIns_SelectedIndexChanged"></asp:DropDownList></td>
                        <td>
                            <asp:DropDownList ID="ddlPgm" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPgm_SelectedIndexChanged" Width="100px"></asp:DropDownList></td>
                        <td>
                            <asp:DropDownList ID="ddlBrn" runat="server" AutoPostBack="True" Width="100px"></asp:DropDownList></td>
                        <td>
                            <asp:DropDownList ID="ddlSem" runat="server" AutoPostBack="True"></asp:DropDownList></td>
                        <td>
                            <asp:DropDownList ID="ddlSts" runat="server" AutoPostBack="True">
                                <asp:ListItem Value="0">Pending</asp:ListItem>
                                <asp:ListItem Value="1">Approved</asp:ListItem>
                            </asp:DropDownList></td>
                        <td>
                            <asp:Button ID="btnView" runat="server" Text="View" OnClick="btnView_Click" /></td>
                        <td>
                            <ajaxToolkit:AutoCompleteExtender ID="autoComplete2" runat="server" EnableCaching="true"
                                TargetControlID="txtEnroll" ServicePath="~/AutoComplete.asmx" ServiceMethod="GetStudentList"
                                MinimumPrefixLength="1" ContextKey="1" CompletionSetCount="12" CompletionInterval="500">
                            </ajaxToolkit:AutoCompleteExtender>
                        </td>
                    </tr>
                </table>
        
              <table>
                    <tr>
                        <td>
                            <div style="height: 400px; overflow-x:auto">
                                <asp:GridView ID="gvApp" runat="server" CssClass="gridDynamic" AutoGenerateColumns="false" DataKeyNames="SEM_REG_ID,SEM_REG_DTL_ID,ENROLLMENT_NO,PGM_BRN_ID,ACA_SEM_ID" OnRowCommand="gvApp_RowCommand" SelectedRowStyle-BackColor="Yellow">
                                    <Columns>
                                        <asp:TemplateField HeaderText="S.No">
                                            <ItemTemplate>
                                                <%#((GridViewRow)Container).RowIndex +1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Enrollment" DataField="ENROLLMENT_NO" />
                                        <asp:BoundField HeaderText="Name" DataField="STU_FULL_NAME" />
                                        <asp:BoundField HeaderText="Institute" DataField="INS_VALUE" />
                                        <asp:BoundField HeaderText="Program" DataField="PGM_SHORT_NAME" />
                                        <asp:BoundField HeaderText="Branch" DataField="BRN_SHORT_NAME" />
                                        <asp:BoundField HeaderText="Sem" DataField="ACA_SEM_ID" />
                                        <asp:BoundField HeaderText="Doc Pending" DataField="DOC_PEND" ItemStyle-Width="20px"/>
                                        <asp:BoundField HeaderText="Request Date" DataField="REG_DATE" />
                                         <asp:CommandField ButtonType="Button" HeaderText="Detail" ShowSelectButton="True" />
                                        <%--<asp:TemplateField>
                                            <ItemTemplate>
                                                 <asp:Button ID="btnDetail" runat="server" Text="Detail" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                                                </ItemTemplate>
                                            <HeaderTemplate>
                                                <strong>Due Detail</strong>
                                            </HeaderTemplate>
                                        </asp:TemplateField>--%>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <input id="chkAll" onclick="javascript: SelectAllCheckboxes(this);" type="checkbox"
                                                    value="on" runat="server" />All
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="ChkBox" runat="server" />
                                            </ItemTemplate>
                                            <ItemStyle Width="15px" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </td>
                    </tr>
                </table>
          
         <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>--%>
          
                <table>
                    <tr>
                        <td>
                             <asp:GridView ID="gvAcnt" runat="server" AutoGenerateColumns="False" Width="99%" CssClass="gridDynamic" ShowFooter="True">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S#">
                                                                <ItemTemplate>
                                                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="20px" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="FEE_MAIN_HEAD_NAME" HeaderText="MAIN HEAD" FooterText="TOTAL:-" />
                                                            <asp:BoundField DataField="FD_FEE_AMT" DataFormatString="{0:N2}" HeaderText="FEE AMOUNT" />
                                                            <asp:BoundField DataField="FD_RCV_AMT" DataFormatString="{0:N2}" HeaderText="RECEIVE AMOUNT" />
                                                            <asp:BoundField DataField ="FEE_WAVE_OFF" DataFormatString="{0:N2}" HeaderText="WAVE AMOUNT" />
                                                            <asp:BoundField DataField="FD_ADJUST_AMT" DataFormatString="{0:N2}" HeaderText="ADJUST AMOUNT" />
                                                            <asp:BoundField DataField="FD_BALANCE_AMT" DataFormatString="{0:N2}" HeaderText="BALANCE AMOUNT" />
                                                            <asp:BoundField DataField="FEE_DEPOSIT_DT" HEADERTEXT="DATE" />
                                                        </Columns>
                                                        <FooterStyle Font-Bold="True" />
                                 </asp:GridView>
                        </td>
                        <td id="td1" runat="server">
                            Account Credit:
                            <asp:Label ID="lblCredit" runat="server"></asp:Label>
                        </td>
                    </tr>
                     </table>
                <table>
                    <tr id="trApp" runat="server">
                        <th>Remark</th>
                        <td>
                            <asp:TextBox ID="txtRemark" runat="server"></asp:TextBox></td>
                        <td>
                            <asp:Button ID="btnApprove" runat="server" Text="Approve" OnClick="btnApprove_Click" /></td>
                    </tr>
                   </table>
               
                 <table>
                   <%-- <tr id="trMsg" runat="server">
                        <th>Message</th>
                        <td>
                            <asp:TextBox ID="txtMsg" runat="server"></asp:TextBox></td>
                        <td>
                            <asp:Button ID="btnSend" runat="server" Text="Send" OnClick="btnSend_Click"/></td>
                    </tr>--%>
                </table>
            </ContentTemplate>
             
        </asp:UpdatePanel>
    </div>
</asp:Content>

