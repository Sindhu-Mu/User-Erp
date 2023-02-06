<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="itemGatePass.aspx.cs" Inherits="Inventory_itemGatePass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script lang="javascript" type="text/javascript">

        function CheckDate(ctrl) {
            var dt = document.getElementById(ctrl).value;
            if (isDatecheck(dt, "dd/MM/yyyy") == false) {
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
                return false;
            }
            else
                document.getElementById(ctrl).style.backgroundColor = "#fff";
            return true;
        }
        function CheckControl(ctrl) {
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == "Select" || bTrim(document.getElementById(ctrl).value) == ".") {
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
                return false;
            }
            else
                document.getElementById(ctrl).style.backgroundColor = "#fff";
            return true;
        }
        function CheckAutoComplete(ctrl) {

            var Value = bTrim(document.getElementById(ctrl).value);
            if (Value.indexOf(":") > 0 && Value.length - 1 != Value.lastIndexOf(":")) {
                document.getElementById(ctrl).style.backgroundColor = "#fff";
                return true;
            }
            else
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
            return false;
        }
        function validat() {
            var flag = true;
            var msg = "", ctrl = "";
            if (document.getElementById("<%=ddlEmp_type.ClientID%>").value == "1") {
                if (!CheckControl("<%=txtEmp.ClientID%>")) {
                     msg += "- Enter Employee Name or Code";
                     if (ctrl == "")
                         ctrl = "<%=txtEmp.ClientID%>";
                    flag = false;
                }
            }
            if (document.getElementById("<%=ddlType.ClientID%>").value == "1") {
                if (!CheckControl("<%=txtRtnDate.ClientID%>")) {
                     msg += "- Enter Return Date";
                     if (ctrl == "")
                         ctrl = "<%=txtEmp.ClientID%>";
                     flag = false;
                 }
             }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }


    </script>
    <div class="container">
        <div class="heading">
            <h2>Gate Pass</h2>
        </div>
        <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table>

                        <tr>
                            <th >Gate Pass Type<span class="required">*</span></th>
                            <th>Employee Type<span class="required">*</span></th>
                        </tr>
                        <tr>
                            <td >
                                <asp:DropDownList ID="ddlType" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlType_SelectedIndexChanged" Width="180px">

                                    <asp:ListItem Value="1">Returnable</asp:ListItem>
                                    <asp:ListItem Value="2">Non-Returnable</asp:ListItem>
                                </asp:DropDownList></td>
                            <td>
                                <asp:DropDownList runat="server" AutoPostBack="true" ID="ddlEmp_type" OnSelectedIndexChanged="ddlEmp_type_SelectedIndexChanged">

                                    <asp:ListItem Value="1">University Employee</asp:ListItem>
                                    <asp:ListItem Value="2">Other</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr id="EmpUniv1" runat="server">
                            <th >Carrying Name<span class="required">*</span>
                            </th>
                        </tr>
                        <tr id="EmpUniv2" runat="server">
                            <td >
                                <asp:TextBox runat="server" ID="txtEmp"></asp:TextBox>
                            </td>

                        </tr>
                        <tr>
                            <td >
                                <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionSetCount="12"
                                    EnableCaching="true" MinimumPrefixLength="1" ServiceMethod="GetEmployeeList"
                                    ServicePath="~\AutoComplete.asmx" TargetControlID="txtEmp" ContextKey="1,2,3,0">
                                </ajaxToolkit:AutoCompleteExtender>
                            </td>
                        </tr>
                        <tr id="other1" runat="server">
                            <th >Carrying Name<span class="required">*</span>
                            </th>
                            <th>Description</th>
                        </tr>
                        <tr id="other2" runat="server">
                            <td >
                                <asp:TextBox runat="server" ID="txtOther"></asp:TextBox></td>
                            <td>
                                <asp:TextBox runat="server" ID="txtDesc"></asp:TextBox></td>
                        </tr>

                        <tr>
                            <th >Recipient Type</th>
                            <th >Recipient Name</th>
                        </tr>
                        
                            <tr>
                                <td >
                                    <asp:DropDownList ID="ddlRecpt" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlRecpt_SelectedIndexChanged" Width="115px">
                                        <asp:ListItem Value="1">Vendor</asp:ListItem>
                                        <asp:ListItem Value="2">Other</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td colspan="2">
                                    <asp:DropDownList ID="ddlSupp" runat="server" AutoPostBack="true" Width="250px">
                                    </asp:DropDownList>
                                    <asp:TextBox ID="txtOtherRecpt" runat="server" Width="250px"></asp:TextBox>
                                </td>
                                
                            </tr>
                          </table>
                    <table>
                        <tr>
                            <th >Item Type</th>

                        </tr>
                      
                            <tr>
                                <td >
                                    <asp:DropDownList ID="ddlItemType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlItemType_SelectedIndexChanged">
                                        <asp:ListItem Value="1">From Item List</asp:ListItem>
                                        <asp:ListItem Value="2">Other</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                </tr>
                            <tr>
                                <th >Particulars<span style="color:red">*</span></th>
                                <th>Quantity<span style="color:red">*</span></th>
                                <th>Unit<span class="required">*</span></th>
                                                    <th>Specification</th>
                                 
                            </tr>
                            <tr>
                                 <td >
                                 <asp:DropDownList ID="ddlItem" runat="server"  AutoPostBack="true" Width="180px"  OnSelectedIndexChanged="ddlItem_SelectedIndexChanged">
                                            </asp:DropDownList> <asp:TextBox ID="txtItem" runat="server" ></asp:TextBox>
                                </td>
                                <td>
                                    <cc1:NumericTextBox ID="txtQty" runat="server" Width="45px" AllowDecimal="True" DecimalPlaces="3"></cc1:NumericTextBox>
                                </td>
                                <td><asp:TextBox ID="txtUnit" runat="server" Width="45px"></asp:TextBox></td>
                                <td colspan="2">
                                    <asp:TextBox ID="txtRemark" runat="server" Width="250px"></asp:TextBox>
                                </td>
                              
                            </tr>
                           
                       <tr>
                           <th>Sender Type<span style="color:red">*</span></th>
                                <th >Sender<span style="color:red">*</span></th>
                       </tr>
                        <tr>
                              <td>
                                    <asp:DropDownList ID="ddlSenderType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSenderType_SelectedIndexChanged" Width="180px">
                                        <asp:ListItem Value="1">University Employee</asp:ListItem>
                                        <asp:ListItem Value="2">Other</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td colspan="2">
                                     <asp:TextBox runat="server" ID="txtSender"></asp:TextBox>
                                </td>
                                <td><asp:TextBox runat="server" ID="txtOthrSender"></asp:TextBox></td>
                                <td>
                                    <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add" />
                                </td>
                                <td>
                                    <asp:TextBox ID="txtxml" runat="server" Visible="false"></asp:TextBox>
                                </td>
                             <td >
                                <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" CompletionSetCount="12"
                                    EnableCaching="true" MinimumPrefixLength="1" ServiceMethod="GetEmployeeList"
                                    ServicePath="~\AutoComplete.asmx" TargetControlID="txtSender" ContextKey="1,2,3,0">
                                </ajaxToolkit:AutoCompleteExtender>
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <th>List of Item(s)
                                <hr style="color: #ff0000; HEIGHT: 1px" />
                            </th>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="gvItemDetail" CssClass="gridDynamic" runat="server" Width="97%" EmptyDataText="No rocord found" AutoGenerateColumns="False" ShowFooter="true" OnRowDeleting="gvItemDetail_RowDeleting">
                                    <FooterStyle HorizontalAlign="Right" CssClass="gridDynamic" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="S#">
                                            <ItemTemplate>
                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                            </ItemTemplate>
                                            <ItemStyle Width="10px" />
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Particulars" DataField="ITEM" ReadOnly="true">
                                            <ItemStyle Width="250px" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="QTY" DataField="QTY">
                                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Remark" DataField="REMARK" ReadOnly="true">
                                            <ItemStyle Width="70px" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Sender" DataField="SENDER" ReadOnly="true">
                                            <ItemStyle Width="100px" />
                                        </asp:BoundField>
                                        <asp:CommandField ShowDeleteButton="true" ButtonType="Image" DeleteImageUrl="~/Siteimages/delete.jpg"
                                            HeaderText="DELETE">
                                            <ItemStyle Width="40px" />
                                        </asp:CommandField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                           
                           
                            <th runat="server" id="rDt1">Return Date</th>
                        </tr>
                        <tr>
                            
                                                   
                            <td runat="server" id="rDt2">
                                <asp:TextBox ID="txtRtnDate" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                              
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtRtnDate"
                                    Format="dd/MM/yyyy">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

