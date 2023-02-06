<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="TNP_COMP_MAIN.aspx.cs" Inherits="TrainingAndPlacement_TNP_COMP_MAIN" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script lang="javascript" type="text/javascript">
    function CheckControl(ctrl) {
        if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == ".") {
            document.getElementById(ctrl).style.backgroundColor = "#fc6";
            return false;
        }
        else
            document.getElementById(ctrl).style.backgroundColor = "#fff";
        return true;
    }

    function CheckNumber(ctrl) {
        var y = document.getElementById(ctrl).value;
        if (y.length > 10) {
            document.getElementById(ctrl).style.backgroundColor = "#fc6";
            return false;
        }
        else {
            document.getElementById(ctrl).style.backgroundColor = "#fff";
            return true;
        }
    }

    function validation() {
        var flag = true;
        var msg = "", ctrl = "";
        if (!CheckControl("<%=txtcompname.ClientID%>")) {
            msg += "- Enter Company Title.\n";
            if (ctrl == "")
                ctrl = "<%=txtcompname.ClientID%>";
            flag = false;
        }

        if (!CheckControl("<%=txtcompadd.ClientID%>")) {
            msg += "- Enter Company address\n";
            if (ctrl == "")
                ctrl = "<%=txtcompadd.ClientID%>";
            flag = false;
        }
        if (!CheckControl("<%=ddlcity.ClientID%>")) {
            msg += "- select city.\n";
            if (ctrl == "")
                ctrl = "<%=ddlcity.ClientID%>";
            flag = false;
        }

        
        if (!CheckControl("<%=ddlcompprofile.ClientID%>")) {
            msg += "- Enter Company Profile.\n";
            if (ctrl == "")
                ctrl = "<%=ddlcompprofile.ClientID%>";
            flag = false;
        }
        
        if (!CheckControl("<%=txtpername.ClientID%>")) {
            msg += "- Enter Contact Person Name.\n";
            if (ctrl == "")
                ctrl = "<%=txtpername.ClientID%>";
            flag = false;
        }
        
        
        if (!CheckControl("<%=txtcompphn.ClientID%>")) {
            msg += " * Enter Contact No \n";
            if (ctrl == "")
                ctrl = "<%=txtcompphn.ClientID%>";
                flag = false;
            }
            if (!CheckNumber("<%=txtcompphn.ClientID%>")) {
            msg += " * Number Should not more then 10 Digit \n";
            if (ctrl == "")
                ctrl = "<%=txtcompphn.ClientID%>";
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
            <h2>Company Main</h2>
        </div>
        <hr />
        <table>
            <tr>
                <th>Company Name<span class="required">*</span></th>
                <td>
                    <asp:TextBox ID="txtcompname" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>Company Address<span class="required">*</span></th>
                <td>
                    <asp:TextBox ID="txtcompadd" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>City<span class="required">*</span></th>
                <td>
                    <asp:dropdownlist id="ddlcity" runat="server" AutoPostBack="false" Width="133"></asp:dropdownlist>
                </td>
            </tr>
            <tr>
                <th>Company Phone No.<span class="required">*</span></th>
                <td>
                    <cc1:NumericTextBox ID="txtcompphn" runat="server"></cc1:NumericTextBox>
                    <%--<asp:TextBox ID="txtcompphn" runat="server"></asp:TextBox>--%>
                </td>
            </tr>
            <tr>
                <th>Company Email</th>
                <td>
                    <asp:TextBox ID="txtcompemail" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>Company Website</th>
                <td>
                    <asp:TextBox ID="txtcompwebsite" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>Company Profile<span class="required">*</span></th>
                <td>
                    <asp:DropDownList ID="ddlcompprofile" runat="server" AutoPostBack="false" Width="133"></asp:DropDownList>
                    
                </td>
            </tr>
            <tr>
                <th>Others</th>
                <td>
                    <asp:TextBox ID="txtOthers" runat="server" TextMode="MultiLine" Width="133"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>Coordinated By<span class="required">*</span></th>
                <td>
                    <asp:TextBox ID="txtpername" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>Contact Person Phone No</th>
                <td>
                    <cc1:NumericTextBox ID="txtperphn" runat="server"></cc1:NumericTextBox>
                    <%--<asp:TextBox ID="txtperphn" runat="server"></asp:TextBox>--%>
                </td>
            </tr>
            <tr>
                <th>Contact Person Address</th>
                <td>
                    <asp:TextBox ID="txtperadd" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>Contact Person Email</th>
                <td>
                    <asp:TextBox ID="txtperemail" runat="server"></asp:TextBox>
                </td>
            </tr>
            <%--<tr>
                <td>
                    <asp:Button ID="btnshow" runat="server" Text="Show" OnClick="btnshow_Click"/>
                </td>
            </tr>--%>
        </table>
       <%-- <asp:GridView ID="gvCompDetail" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" EmptyDataText="No Record found">
              <Columns>
                                            <asp:TemplateField HeaderText="S.No.">
                                                <ItemTemplate>
                                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                                    .
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="COMP_NAME" HeaderText="Company Name" />
                                            <asp:BoundField DataField="COMP_ADDRESS" HeaderText="Company Address" />
                                            <asp:BoundField DataField="CIT_ID" HeaderText="City" />
                                            <asp:BoundField DataField="COMP_PHONE_NO" HeaderText="Company Phone No." />
                                             <asp:BoundField DataField="COMP_EMAIL" HeaderText="Company Email" />
                                            <asp:BoundField DataField="COMP_WEBSITE" HeaderText="Company Website" />
                                             <asp:BoundField DataField="COMP_PROFILE" HeaderText="Company Profile" />
                                        </Columns>
         </asp:GridView>
        </div>
    <div>
         <asp:GridView ID="GvPersonDetail" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" EmptyDataText="No Record found">
              <Columns>
                                            <asp:TemplateField HeaderText="S.No.">
                                                <ItemTemplate>
                                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                                    .
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="CONTACT_PER_NAME" HeaderText="Contact Person Name" />
                                            <asp:BoundField DataField="CONTACT_PER_ADDRESS" HeaderText="Contact Person Address" />
                                         
                                            <asp:BoundField DataField="CONTACT_PER_PHN_NO" HeaderText="Contact Person Phone No." />
                                             <asp:BoundField DataField="CONTACT_PER_EMAIL" HeaderText="Contact Person Email" />
                                        </Columns>
         </asp:GridView>--%>
        <asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click" />
    </div>
</asp:Content>

