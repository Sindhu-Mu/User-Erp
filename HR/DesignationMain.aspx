<%@ Page Title="ERP | Employee Designation Master" Language="C#" MasterPageFile="~/MasterPages/Short.master" AutoEventWireup="true" CodeFile="DesignationMain.aspx.cs" Inherits="HR_DesignationMain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentHolder1" runat="Server">
    <script language="javascript" type="text/javascript">

        function CheckControl(ctrl) {
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == ".") {
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
            if (!CheckControl("<%=ddlCatId.ClientID%>")) {
                msg += "* Select Category from List\n";
                if (ctrl == "")
                    ctrl = "<%=ddlCatId.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtDesignationValue.ClientID%>")) {
                msg += "* Enter Designation name!!\n";
                if (ctrl == "")
                    ctrl = "<%=txtDesignationValue.ClientID%>";
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
            <h2>Designation Main</h2>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <th>Category<span class="required">*</span></th>
                                    <td>&nbsp;</td>
                                    <th>Full Name <span class="required">*</span></th>
                                    <td>&nbsp;</td>
                                   
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:DropDownList ID="ddlCatId" runat="server" Width="153px" AutoPostBack="True" OnSelectedIndexChanged="ddlCatId_SelectedIndexChanged"></asp:DropDownList>
                                    </td>
                                    <td>&nbsp;</td>
                                    <td>
                                        <asp:TextBox ID="txtDesignationValue" runat="server" Width="354px"></asp:TextBox></td>
                                    <td>&nbsp;</td>
                                  

                                    <td>
                                        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" /></td>
                                </tr>

                            </table>
                        </td>
                    </tr>


                    <tr>
                        <td> <div style="overflow: auto; width: 100%; height: 400px">
                            <asp:GridView ID="gvShow" runat="server" AutoGenerateColumns="False" DataKeyNames="DES_ID" OnRowCommand="gvShow_RowCommand" CssClass="gridDynamic" >
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No.">
                                        <ItemTemplate>
                                            <%# ((GridViewRow)Container).RowIndex + 1%>
                                        </ItemTemplate>
                                        <ItemStyle Width="15px" />
                                    </asp:TemplateField>                                   
                                    <asp:BoundField HeaderText="Full Name " DataField="DES_VALUE" />                                 
                                     <asp:BoundField HeaderText="Category" DataField="CAT_VALUE" />
                                    <asp:CommandField ButtonType="Image" SelectImageUrl="~/Siteimages/edit.gif" ShowSelectButton="True" HeaderText="Modify">
                                        <ItemStyle Width="40px" />
                                    </asp:CommandField>
                                    <asp:TemplateField ShowHeader="False" HeaderText="Status">
                                        <ItemStyle Width="20px" HorizontalAlign="Right" />
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgAct" runat="server" CausesValidation="false" CommandArgument='<%# Bind("DES_ID") %>'
                                                ImageUrl='<%# Bind("STS_IMG") %>' CommandName='<%# Bind("STS_CMD") %>' ToolTip='<%# Bind("STS_TOOLTIP")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>
                            </asp:GridView>
                            </div>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

</asp:Content>

