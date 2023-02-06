<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="FeeCurrencyChange.aspx.cs" Inherits="Finance_BankAccount" %>

<%@ Register Src="~/Control/Student.ascx" TagPrefix="uc1" TagName="Student" %>


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

            if (!CheckControl("<%=txtEnroll.ClientID%>")) {
                msg += "- Enter Enrollment No.\n";
                if (ctrl == "")
                    ctrl = "<%=txtEnroll.ClientID%>";
                 flag = false;
    }
            if (!CheckControl("<%=ddlSem.ClientID%>")) {
                msg += "- Select semester no from list.\n";
                if (ctrl == "")
                    ctrl = "<%=ddlSem.ClientID%>";
                 flag = false;
             }

             if (msg != "") alert(msg);
             if (ctrl != "")
                 document.getElementById(ctrl).focus();
             return flag;
        }
         function validCurrency()
         {
             var flag = true;
             var msg = "", ctrl = "";
             if (!CheckControl("<%=txtEnroll.ClientID%>")) {
                 msg += "- Enter Enrollment No.\n";
                 if (ctrl == "")
                     ctrl = "<%=txtEnroll.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlSem.ClientID%>")) {
                 msg += "- Select semester no from list.\n";
                 if (ctrl == "")
                     ctrl = "<%=ddlSem.ClientID%>";
                flag = false;
            }

             if (!CheckControl("<%=txtRate.ClientID%>")) {
                 msg += "- Enter Currency Rate.\n";
                 if (ctrl == "")
                     ctrl = "<%=txtRate.ClientID%>";
                 flag = false;
             }

             if (!CheckControl("<%=ddlCurrencyTo.ClientID%>")) {
                msg += "- Select Currency to Change from list.\n";
                if (ctrl == "")
                    ctrl = "<%=ddlCurrencyTo.ClientID%>";
                 flag = false;
             }
             if (!CheckControl("<%=ddlCurrencyFrom.ClientID%>"))
             {
                 msg += "-Select Type Of Currency To Change In.\n";
                 if(ctrl == "")
                     ctrl = "<%=ddlCurrencyFrom.ClientID%>";
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
                Change Currency
            </h2>

        </div>
    
    <div id="cBody">
        <div id="cHead">
           <!-- Content  Header ex: Filters-->
            <table style="width:50%">
                <tr>
                    <th>Enrollment</th>
                    <th>Sem</th>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtEnroll" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSem" runat="server"></asp:DropDownList>
                    </td>
                    <td>
                        <asp:Button ID="btnShow" runat="server"  Text="Show" OnClick="btnShow_Click"/>
                    </td>
                </tr>
               
             </table>
            <table style="width:100%">
                <tr>
                    <td>
                        <uc1:Student runat="server" ID="Student" />
                    </td>
                </tr>
            </table>
           
        </div>
        <div id="cCenter">
           <!-- Content Header ex: Grids-->
            <div align="center" style="padding-top:20px">
            <asp:GridView ID="gvShow" runat="server" AutoGenerateColumns="false" DataKeyNames="" CssClass="gridDynamic">
                <Columns>
                    <asp:TemplateField HeaderText="s#">
                    <ItemTemplate>
                        <%#((GridViewRow)Container).RowIndex+1 %>
                    </ItemTemplate>     
                 </asp:TemplateField>
                    <asp:BoundField  DataField="FEE_MAIN_HEAD_NAME" HeaderText="HEAD NAME"/>
                    <asp:BoundField  DataField="FD_FEE_AMT" HeaderText="FEE AMOUNT"/>
                    <asp:BoundField  DataField="FD_ADJUST_AMT" HeaderText="ADJUST AMOUNT"/>
                    <asp:BoundField  DataField="FD_RCV_AMT" HeaderText="RECEIVE AMOUNT"/>
                    <asp:BoundField  DataField="FD_BALANCE_AMT" HeaderText="BALANCE AMOUNT"/>
                    <asp:BoundField  DataField="CURRENCY_SYMBOL" HeaderText="CURRENCY"/>
                </Columns>
            </asp:GridView>
            </div>

        </div>
         <div id="cFooter">
              <!-- Content Header ex:Buttons-->
            <div id="dvCrncy" runat="server">
            <table>
                 <tr>
                    <th>Currency Rate</th>
                    <th>Currency From</th>
                    <th>Currency To</th>
                    
                </tr>
                  <tr>
                    <td>
                        <asp:TextBox ID="txtRate" runat="server"></asp:TextBox>
                    </td>
                     <td>
                        <asp:DropDownList ID="ddlCurrencyFrom" runat="server">
                         <asp:ListItem>Select</asp:ListItem>
                         <asp:ListItem Value="1">INR</asp:ListItem>
                         <asp:ListItem Value="2">DOLLAR</asp:ListItem>
                        </asp:DropDownList>
                      </td>
                      <td>
                        <asp:DropDownList ID="ddlCurrencyTo" runat="server">
                        <asp:ListItem>Select</asp:ListItem>
                        <asp:ListItem  Value="1">INR</asp:ListItem>
                        <asp:ListItem  Value="2">DOLLAR</asp:ListItem>
                        </asp:DropDownList>
                      </td>
                     
                    <td>
                        <asp:Button  ID="btnAdd" runat="server" Text="Change" OnClick="btnAdd_Click"/>
                    </td>
                   </tr>
                
            </table>
            </div>
        </div>
</div>
</div>

</asp:Content>

