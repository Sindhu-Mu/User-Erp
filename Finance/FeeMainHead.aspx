<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="FeeMainHead.aspx.cs" Inherits="Finance_BankAccount" %>

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
         function validation() {

             var flag = true;
             var msg = "", ctrl = "";


             if (!CheckControl("<%=ddlGroupHead.ClientID%>")) {
        msg += "- Select Group Head from list\n";
        if (ctrl == "")
            ctrl = "<%=ddlGroupHead.ClientID%>";
        flag = false;
    }
    if (!CheckControl("<%=txtMainHeadName.ClientID%>")) {
        msg += "- Enter Main Head Name \n";
        if (ctrl == "")
            ctrl = "<%=txtMainHeadName.ClientID%>";
        flag = false;
    }
    if (!CheckControl("<%=txtPriority.ClientID%>")) {
        msg += "- Enter Fee Main Head Priority \n";
        if (ctrl == "")
            ctrl = "<%=txtPriority.ClientID%>";
        flag = false;
    }

    if (msg != "") alert(msg);
    if (ctrl != "")
        document.getElementById(ctrl).focus();
    return flag;
}
    </script>
    <div class="container">
        <div class="heading"><h2>Fees Main Head</h2></div>
    
    <div id="cBody">
        <div id="cHead">
            <table style="width:90%">
                <tr>
                    <td>Group Head</td>
                    <td>Main Head Name</td>
                    <td>In One Time</td>
                    <td>In Scholarship</td>
                    <td>Priority</td>
                    <td>In Structure</td>
                </tr>
                 <tr>
                    <td>
                        <asp:DropDownList ID="ddlGroupHead" runat="server"></asp:DropDownList></td>
                    <td>
                       <asp:TextBox ID="txtMainHeadName" runat="server"></asp:TextBox>
                      
                    </td>
                    <td>
                      <asp:RadioButtonList ID="RListType" runat="server" 
                                            RepeatDirection="Horizontal">
                                            <asp:ListItem Selected="True" Value="0">Not</asp:ListItem>
                                            <asp:ListItem Value="1">Yes</asp:ListItem>
                                        </asp:RadioButtonList></td>
                       
                    <td>
                         <asp:RadioButtonList ID="RlistInScho" runat="server" 
                                            RepeatDirection="Horizontal">
                                            <asp:ListItem Selected="True" Value="0">Not</asp:ListItem>
                                            <asp:ListItem Value="1">Yes</asp:ListItem>
                                        </asp:RadioButtonList></td>
                    <td>
                        <asp:TextBox ID="txtPriority" runat="server"></asp:TextBox></td>

                     <td>
                        <asp:RadioButtonList ID="RlistStrc" runat="server"  RepeatDirection="Horizontal"
                                            >
                                            <asp:ListItem Selected="True" Value="0">No</asp:ListItem>
                                            <asp:ListItem Value="1">Yes</asp:ListItem>
                                        </asp:RadioButtonList></td>
                     <td> <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="Add_Click" /></td>
                    
                </tr>
                </table>
        </div>
        <div id="cCenter">
            <asp:GridView ID="gvShow" runat="server" ShowHeader="true" AutoGenerateColumns="False" DataKeyNames="FEE_MAIN_HEAD_ID" CssClass="gridDynamic" AllowPaging="true" OnPageIndexChanging="OnPageIndexChanging" OnRowCommand="gvMainHeads_RowCommand">
               <Columns>
                   <asp:BoundField HeaderText="Sr No" DataField="sr_no" />
                  <asp:BoundField DataField="FEE_MAIN_HEAD_NAME" HeaderText="Head Name">
                                        
                                    </asp:BoundField>
                                    <asp:BoundField DataField="FEE_GROUP_HEAD_NAME" HeaderText="Group Name ">
                                        
                                    </asp:BoundField>
                                    <asp:BoundField DataField="FEE_HEAD_IS_ONETIME" HeaderText="One Time">
                                       
                                    </asp:BoundField>
                                    <asp:BoundField DataField="FEE_IN_SCHOLARSHIP" HeaderText="In Scholarship">
                                        
                                    </asp:BoundField>
                                    <asp:BoundField DataField="FEE_MAIN_HEAD_PRIORITY" HeaderText="Priority">
                                       
                                    </asp:BoundField>
                                    <asp:BoundField DataField="FEE_HEAD_IN_STRAC" HeaderText="In Stracture">
                                      
                                    </asp:BoundField>
                                    <asp:CommandField ButtonType="Image" SelectImageUrl="~/Siteimages/edit.gif" ShowSelectButton="True" HeaderText="Modify" >
                                       
                                    </asp:CommandField>
                                    <asp:TemplateField ShowHeader="False" HeaderText="Status">
                                        <ItemStyle Width="20px" HorizontalAlign="Right" />
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgAct" runat="server" CausesValidation="false" CommandArgument='<%# Bind("FEE_MAIN_HEAD_ID") %>'
                                                CommandName="Delete" ImageUrl="~/Siteimages/deactivate.gif"  />
                                        </ItemTemplate>
                                    </asp:TemplateField>
             
               </Columns>

            </asp:GridView>
        </div>
         <div id="cFooter">

        </div>
</div>
</div>

</asp:Content>

