<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Short.master" AutoEventWireup="true" CodeFile="StoreMain.aspx.cs" Inherits="Inventory_StoreMain" %>

<%@ Register Src="~/Control/Employee.ascx" TagPrefix="uc1" TagName="Employee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentHolder1" runat="Server">
    <script language="javascript" type="text/javascript">
        function CheckControl(ctrl) {
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == "Select" || bTrim(document.getElementById(ctrl).value) == ".") {
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
                return false;
            }
            else {
                document.getElementById(ctrl).style.backgroundColor = "#fff";
                return true;
            }
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
        function CheckDate(ctrl) {
            var dt = document.getElementById(ctrl).value;
            if (!isDatecheck(dt, "dd/MM/yyyy")) {
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
                return false;
            }
            else {
                document.getElementById(ctrl).style.backgroundColor = "#fff";
                return true;
            }
        }

        function validateBtnSaveStore() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=txtStoreName.ClientID%>")) {
                msg += "- Enter Store Name\n";
                if (ctrl == "")
                    ctrl = "<%=txtStoreName.ClientID%>";
                flag = false;

            }
            if (!CheckControl("<%=txtDesc.ClientID%>")) {
                msg += "- Enter Description\n";
                if (ctrl == "")
                    ctrl = "<%=txtDesc.ClientID%>";
                flag = false;
            }
            if (msg != "")
                alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }
        function validateIncharge()
        {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=ddlStore.ClientID%>"))
            {
                msg += "* Select Store from list\n";
                if (ctrl == "")
                    ctrl = "<%=ddlStore.ClientID%>";
                flag = false;
            }
            if (!CheckAutoComplete("<%=txtEmp.ClientID%>"))
             {
                msg += "* Enter Name & Emp.Code\n";
                if (ctrl == "")
                    ctrl = "<%=txtEmp.ClientID%>";
                  flag = false;
            }
            if (!CheckDate("<%=txtFromDt.ClientID%>")) {
                if (!CheckControl("<%=txtFromDt.ClientID%>")) {
                     msg += " * Enter From date. \n";
                     if (ctrl == "")
                         ctrl = "<%=txtFromDt.ClientID%>";
                    flag = false;
                }
                else {
                    msg += " * Enter Correct Date.  \n";
                    if (ctrl == "")
                        ctrl = "<%=txtFromDt.ClientID%>";
                    flag = false;
                }
            }
              if (msg != "")
                  alert(msg);
              if (ctrl != "")
                  document.getElementById(ctrl).focus();
              return flag;
          }
    </script>
    <div class="container">
        <div class="heading">
            <h2>Store Main</h2>
        </div>
        <div>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <ajaxToolkit:TabContainer ID="step1" runat="server" ActiveTabIndex="1" AutoPostBack="true" OnActiveTabChanged="step1_ActiveTabChanged">
                        <ajaxToolkit:TabPanel runat="server" HeaderText="Store Master" ID="TabPanel2">
                            <ContentTemplate>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <table>
                                            <tr>
                                                <td>

                                                    <table>
                                                        <tr>
                                                            <th>Store Name
                                    <span class="required">*</span>
                                                            </th>
                                                            <td>&nbsp;</td>
                                                            <th>Description
                                                            </th>
                                                            <td>&nbsp;</td>

                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="txtStoreName" runat="server" Width="200px"></asp:TextBox>
                                                            </td>
                                                            <td>&nbsp;</td>
                                                            <td>
                                                                <asp:TextBox ID="txtDesc" runat="server" Width="400px" MaxLength="200"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="btnStoreSave" runat="server" Text="Save" OnClick="btnStoreSave_Click" />
                                                            </td>
                                                        </tr>

                                                    </table>
                                                    <tr>
                                                        <td>
                                                            <asp:GridView ID="gv_Store" runat="server" AutoGenerateColumns="False" CssClass="gridDynamic"
                                                                DataKeyNames="STO_ID" OnRowCommand="gv_Store_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="S.No.">
                                                                        <ItemTemplate>
                                                                            <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Width="20px" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField HeaderText="Store Name" DataField="Sto_Name" />
                                                                    <asp:CommandField ButtonType="Image" HeaderText="Edit" SelectImageUrl="~/Siteimages/edit.gif"
                                                                        ShowSelectButton="True">
                                                                        <ItemStyle Width="40px" />
                                                                    </asp:CommandField>
                                                                    <asp:TemplateField ShowHeader="False" HeaderText="Status">
                                                                        <ItemStyle Width="20px" HorizontalAlign="Right" />
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="false" CommandArgument='<%# Bind("STO_ID") %>'
                                                                                ImageUrl='<%# Bind("STS_IMG") %>' CommandName='<%# Bind("STS_CMD") %>' ToolTip='<%# Bind("STS_TOOLTIP")%>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </ContentTemplate>
                        </ajaxToolkit:TabPanel>
                        <ajaxToolkit:TabPanel runat="server" HeaderText="Store Incharge" ID="TabPanel3">
                            <ContentTemplate>
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                        <table>
                                            <tr>
                                                <td>

                                                    <table>
                                                        <tr>
                                                            <th>Store Name
                                    <span class="required">*</span>
                                                            </th>
                                                            <td>&nbsp;</td>
                                                            <th>In-Charge Name  <span class="required">*</span>
                                                            </th>
                                                            <td>&nbsp;</td>
                                                            <th>From Date  <span class="required">*</span>
                                                            </th>
                                                            <td>&nbsp;</td>

                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:DropDownList ID="ddlStore" runat="server"></asp:DropDownList>
                                                            </td>
                                                            <td>&nbsp;</td>
                                                            <td>
                                                                <asp:TextBox ID="txtEmp" runat="server" Width="200px"></asp:TextBox>
                                                            </td>
                                                            <td>&nbsp;</td>
                                                            <td>
                                                                <asp:TextBox ID="txtFromDt" runat="server" Width="90px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="btnInchargeSave" runat="server" Text="Save" OnClick="btnInchargeSave_Click" />
                                                            </td>
                                                        </tr>

                                                    </table>
                                                    <tr>
                                                        <td>
                                                            <asp:GridView ID="gvIncgarge" runat="server" AutoGenerateColumns="False" CssClass="gridDynamic"
                                                                DataKeyNames="STO_INCRG_ID" OnRowCommand="gv_Store_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="S.No.">
                                                                        <ItemTemplate>
                                                                            <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Width="20px" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField HeaderText="Store Name" DataField="Sto_Name" />
                                                                    <asp:BoundField HeaderText="Store In-Charge" DataField="EMP_NAME" />
                                                                    <asp:BoundField HeaderText="From Date" DataField="FROM_DT" DataFormatString="{0:dd/MM/yyyy}" />
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtEmp"
                                                                CompletionSetCount="12" EnableCaching="true" MinimumPrefixLength="1" ServiceMethod="GetEmployeeList"
                                                                ServicePath="~\AutoComplete.asmx" ContextKey="1">
                                                            </ajaxToolkit:AutoCompleteExtender>
                                                            <ajaxToolkit:CalendarExtender runat="server" ID="calendar" TargetControlID="txtFromDt" Format="dd/MM/yyyy"></ajaxToolkit:CalendarExtender>
                                                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="99/99/9999" MaskType="Date"
                                                                TargetControlID="txtFromDt">
                                                            </ajaxToolkit:MaskedEditExtender>
                                                        </td>
                                                    </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </ContentTemplate>
                        </ajaxToolkit:TabPanel>
                    </ajaxToolkit:TabContainer>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

</asp:Content>

