<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="FeeConcessionCriteria.aspx.cs" Inherits="Finance_BankAccount" %>

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

         function valid() {
             var flag = true;
             var msg = "", ctrl = "";

             if (!CheckControl("<%=ddlHead.ClientID%>")) {
        msg += "- Select Main Head Name from list.\n";
        if (ctrl == "")
            ctrl = "<%=ddlHead.ClientID%>";
        flag = false;
    }
    if (!CheckControl("<%=ddlQuota.ClientID%>")) {
        msg += "- Select Quota Name from list.\n";
        if (ctrl == "")
            ctrl = "<%=ddlQuota.ClientID%>";
        flag = false;
    }
    if (!CheckControl("<%=ddlSession.ClientID%>")) {
        msg += "- Select Session from list.\n";
        if (ctrl == "")
            ctrl = "<%=ddlSession.ClientID%>";
        flag = false;
    }
    if (!CheckControl("<%=nTxtPer.ClientID%>")) {
        msg += "- Enter COncession Percentage.\n";
        if (ctrl == "")
            ctrl = "<%=nTxtPer.ClientID%>";
        flag = false;
    }
    if (!CheckControl("<%=nTxtMax.ClientID%>")) {
        msg += "- Enter Maximum Concession.\n";
        if (ctrl == "")
            ctrl = "<%=nTxtMax.ClientID%>";
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
                 Fee Concession Criteria   
            </h2>

        </div>
    
    <div id="cBody">
        <div id="cHead">
           <!-- Content  Header ex: Filters-->
            <table>
             <tr>
                        <th>
                            Main Head Name<span style="color: Red">*</span></th>
                        <th>
                            Quota Name<span style="color: Red">*</span></th>
                        <th>
                            From Session<span style="color: Red">*</span></th>
                        <th>
                            Concession Percentage<span style="color: Red">*</span></th>
                        <th>
                            Maximum Concession<br />
                            in Amount<span style="color: Red">*</span></th>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                            <asp:DropDownList ID="ddlHead" runat="server" Width="120px">
                            </asp:DropDownList>&nbsp;</td>
                        <td>
                            &nbsp;
                            <asp:DropDownList ID="ddlQuota" runat="server" Width="120px">
                            </asp:DropDownList>&nbsp;</td>
                        <td>
                            &nbsp;
                            <asp:DropDownList ID="ddlSession" runat="server" Width="120px">
                            </asp:DropDownList>&nbsp;</td>
                        <td>
                            &nbsp;
                            <cc1:NumericTextBox ID="nTxtPer" runat="server"></cc1:NumericTextBox>&nbsp;</td>
                        <td>
                            &nbsp;
                            <cc1:NumericTextBox ID="nTxtMax" runat="server"></cc1:NumericTextBox>&nbsp;</td>
                        <td>
                            &nbsp;
                            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btnBrown" Width="52px"
                                OnClick="btnSave_Click" /></td>
                    </tr>    
            
            </table>

        </div>
        <div id="cCenter">
            <hr/>
           <!-- Content Header ex: Grids-->
            <asp:GridView ID="gridShow" runat="server" Width="100%" CssClass="gridDynamic" AutoGenerateColumns="False"
                                EmptyDataText="No Record Found." DataKeyNames="CONC_CRI_ID" OnRowDeleting="gridShow_RowDeleting">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No.">
                                        <ItemTemplate>
                                            <%# ((GridViewRow)Container).RowIndex + 1%>
                                        </ItemTemplate>
                                        <ItemStyle Width="50px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="FEE_MAIN_HEAD_NAME" HeaderText="Main Head Name" />
                                    <asp:BoundField DataField="QUOTA_NAME" HeaderText="Quota Name" />
                                    <asp:BoundField DataField="ACA_SESN_VALUE" HeaderText="From Session" />
                                    <asp:BoundField DataField="CONC_PER" HeaderText="Concession Percentage" />
                                    <asp:BoundField DataField="CONC_MAX" HeaderText="Maximum Concession" />
                                    <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Siteimages/delete.jpg" ShowDeleteButton="True" />
                                </Columns>
                            </asp:GridView>
            <hr/>
        </div>
         <div id="cFooter">
              <!-- Content Header ex:Buttons-->

        </div>
</div>
</div>

</asp:Content>

