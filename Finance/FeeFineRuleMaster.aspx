<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="FeeFineRuleMaster.aspx.cs" Inherits="Finance_BankAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <script lang="javascript" type="text/javascript">
         function CheckControl(ctrl) {
             if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == "Select" || bTrim(document.getElementById(ctrl).value) == ".") {
                 document.getElementById(ctrl).style.backgroundColor = "#fc6";
                 return false;
             }
             else
                 document.getElementById(ctrl).style.backgroundColor = "#fff";
             return true;
         }
         function validate() {
             var flag = true;
             var msg = "", ctrl = "";
             if (!CheckControl("<%=ddlFineHead.ClientID%>")) {
                msg += "- Select Fine Rule from list \n";
                if (ctrl == "")
                    ctrl = "<%=ddlFineHead.ClientID%>";
                flag = false;
             }
             if (!CheckControl("<%=ddlRule.ClientID%>")) {
                 msg += "- Select or Enter Rule Name\n";
                 if (ctrl == "")
                     ctrl = "<%=ddlRule.ClientID%>";
                 flag = false;
             }
             if (!CheckControl("<%=ddlCalType.ClientID%>")) {
                 msg += "- Select Calculation from list \n";
                 if (ctrl == "")
                     ctrl = "<%=ddlCalType.ClientID%>";
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
            Rule Master
            </h2>

        </div>
    
    <div id="cBody">
        <div id="cHead">
            <table>
                <tr>
                                            <th>
                                                Fine Heads<span style="color: #ff0000">*</span></th>
                                            <th>
                                                Rule Name<span style="color: #ff0000">*</span></th>
                                            <th>
                                                Calculation On<span style="color: #ff0000">*</span></th>                                          
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:DropDownList ID="ddlFineHead" runat="server" Width="140px">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlRule" runat="server">
                                                </asp:DropDownList><b>/</b><asp:TextBox ID="txtRuleName" runat="server" Width="150px" CssClass="textbox"></asp:TextBox></td>
                                             <td>
                                                <asp:DropDownList ID="ddlCalType" runat="server">
                                                </asp:DropDownList></td>
                                            <td>
                                                <asp:TextBox ID="txtdata" runat="server" Visible="False"></asp:TextBox></td>
                                        </tr>
            </table>
                                <table>
                                    <tbody>
                                        

                                         <tr>
                            <td style="width: 30%">
                                <table  border="0">
                                    <tbody>
                                       
                                        <tr>
                                            <th>
                                                After Days</th>
                                            <td>
                                                <asp:TextBox ID="txtNOD" runat="server"  CssClass="txtno" MaxLength="10"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th >
                                                Amount</th>
                                            <td>
                                                <asp:TextBox ID="txtAmount" runat="server" CssClass="txtno" MaxLength="10"></asp:TextBox></td>
                                        </tr>
                                        <tr style="vertical-align: top">
                                            <td style="height: 20px">
                                                <asp:Button ID="btnAdd" OnClick="btnAdd_Click" runat="server" Width="60px" Text="Add Fee"
                                                    CssClass="btnBrown"></asp:Button></td>
                                          
                                            <td style="height: 20px">
                                                <asp:Button ID="btnSave" OnClick="btnSave_Click" runat="server" Width="60px" Text="Save"
                                                    CssClass="btnBrown"></asp:Button></td>
                                        </tr>

                                    </tbody>
                                </table>  
                                </table>

        </div>
        <div id="cCenter">
           <!-- Content Header ex: Grids-->

             <asp:GridView ID="gvCondition" runat="server"  OnRowDeleting="gvCondition_RowDeleting"
                                    EmptyDataText="No record found" DataKeyNames="FINE_RULE_ID" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:TemplateField HeaderText="S.No.">
                                            <ItemTemplate>
                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                            </ItemTemplate>
                                            <ItemStyle Width="20px" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="FINE_CND_DAYS" HeaderText="AFTER DAYS">
                                            <ItemStyle Width="80px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="FINE_CND_AMT" HeaderText="AMOUNT">
                                            <ItemStyle Width="80px" />
                                        </asp:BoundField>
                                        <%--<asp:BoundField DataField="EMP_NAME" HeaderText="INSERT BY">
                                            <ItemStyle Width="80px" />
                                        </asp:BoundField>--%>
                                        <asp:BoundField DataField="FINE_CND_IN_DT" HeaderText="INSERT DATE">
                                            <ItemStyle Width="80px" />
                                        </asp:BoundField>
                                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/images/delete.gif" ShowDeleteButton="True" />
                                    </Columns>
                                </asp:GridView>

        </div>
         <div id="cFooter">
              <!-- Content Header ex:Buttons-->

        </div>
</div>
</div>

</asp:Content>

