<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="FeeGroupHeadMaster.aspx.cs" Inherits="Finance_BankAccount" %>

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
             if (!CheckControl("<%=ddlHeadType.ClientID%>")) {
        msg += "- Select Head Type from list\n";
        if (ctrl == "")
            ctrl = "<%=ddlHeadType.ClientID%>";
        flag = false;
    }
    if (!CheckControl("<%=txtHeadName.ClientID%>")) {
            msg += "- Enter Group Head Name\n";
            if (ctrl == "")
                ctrl = "<%=txtHeadName.ClientID%>";
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
             Fee Group Heads

            </h2>

        </div>
    
    <div id="cBody">
        <div id="cHead">
      
             <table style=" width="100%" border="0"">
                                    <tbody>
                                        <tr style="vertical-align: bottom; text-align: left">
                                            <th>
                                                Head Type<span style="color: #ff0000">*</span></th>
                                            <td>
                                                &nbsp;</td>
                                            <th>
                                               Top Head Name<span style="color: #ff0000">*</span></th>
                                            <td>
                                                &nbsp;</td>

                                            <th>
                                                Group Head Name<span style="color: #ff0000">*</span></th>
                                            <td>
                                                &nbsp;</td>
                                            <td>
                                                &nbsp;</td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:DropDownList ID="ddlHeadType" runat="server" Width="110px" OnSelectedIndexChanged="ddlHeadType_SelectedIndexChanged"
                                                    AutoPostBack="True">
                                                </asp:DropDownList></td>
                                            <td>
                                                &nbsp;</td>
                                            <td>
                                                <asp:DropDownList ID="ddlTopHeadName" runat="server" Width="110px" OnSelectedIndexChanged="ddlTopHeadName_SelectedIndexChanged"
                                                    AutoPostBack="True">
                                                </asp:DropDownList></td>
                                            <td>
                                                &nbsp;</td>
                                            <td>
                                                <asp:TextBox ID="txtHeadName" runat="server" Width="270px" MaxLength="100" CssClass="textbox"></asp:TextBox></td>
                                            <td>
                                                &nbsp;</td>
                                            <td>
                                                <asp:Button ID="btnSave" OnClick="btnSave_Click" runat="server" Width="60px" Text="Save"
                                                    CssClass="btnBrown"></asp:Button></td>
                                        </tr>
                                    </tbody>
                                </table>
       
        </div>
        <div id="cCenter">
          <asp:GridView ID="gvGroupHeads" runat="server" Width="60%" EmptyDataText="No record found"
                                    CellPadding="3" AutoGenerateColumns="False" DataKeyNames="FEE_GROUP_HEAD_ID"
                                    OnRowCommand="gvGroupHeads_RowCommand">
                                    <Columns>
                                        <asp:BoundField HeaderText="S#">
                                            <ItemStyle Width="15px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="FEE_GROUP_HEAD_NAME" HeaderText="GROUP HEAD NAME">
                                            <ItemStyle Width="90px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="HEAD_TYPE_FULL_NAME" HeaderText="HEAD TYPE">
                                            <ItemStyle Width="90px" />
                                        </asp:BoundField>
                                     
                                       <%-- <asp:BoundField DataField="FEE_GROUP_HEAD_DESC" HeaderText="Description">
                                            <ItemStyle Width="120px" />
                                        </asp:BoundField>--%>
                                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/edit.jpg" ShowSelectButton="True">
                                            <ItemStyle Width="50px" />
                                        </asp:CommandField>
                                        <asp:TemplateField ShowHeader="False" HeaderText="Status">
                                            <ItemStyle Width="20px" HorizontalAlign="Right" />
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgAct" runat="server" CausesValidation="false" CommandArgument='<%# Bind("FEE_GROUP_HEAD_ID") %>'
                                                    CommandName="Delete" ImageUrl="~/images/deactivate.gif" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <SelectedRowStyle BackColor="#99FF33" />
                                </asp:GridView>

        </div>
         <div id="cFooter">
              <!-- Content Header ex:Buttons-->

        </div>
</div>
</div>

</asp:Content>

