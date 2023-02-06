<%@ Page Title="ERP | Document Master" Language="C#" MasterPageFile="~/MasterPages/Short.master" AutoEventWireup="true" CodeFile="DocumentMain.aspx.cs" Inherits="HR_DocumentMain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
        s
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
            if (!CheckControl("<%=txtDocName.ClientID%>")) {
                msg += "- Enter Document Name\n";
                if (ctrl == "")
                    ctrl = "<%=txtDocName.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlType.ClientID%>")) {
                msg += "- Select employee type from  list \n";
                if (ctrl == "")
                    ctrl = "<%=ddlType.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlDocFor.ClientID%>")) {
                msg += "- Select document at the time of list \n";
                if (ctrl == "")
                    ctrl = "<%=ddlDocFor.ClientID%>";
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
            <h2>Documents Main</h2>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <td>
                            <table>

                                <tr>
                                    <th>Document Name<span class="required">*</span></th>
                                    <td>&nbsp;</td>
                                    <th>Job Type<span class="required">*</span></th>
                                    <td>&nbsp;</td>
                                    <th>At Time Of<span class="required">*</span></th>
                          
                                    <td></td>
                                </tr>

                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtDocName" runat="server" Width="300px" CssClass="textbox" /></td>
                                    <td>&nbsp;</td>
                                    <td>
                                        <asp:DropDownList ID="ddlType" runat="server" Width="120px" Height="28px" CssClass="textbox" /></td>
                                    <td>&nbsp;</td>
                                    <td>
                                        <asp:DropDownList ID="ddlDocFor" runat="server" Width="120px" Height="28px" CssClass="textbox">
                                            <asp:ListItem Value="1">Joining</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                
                                    <td>
                                        <asp:Button ID="btnSave" runat="server"
                                            Text="Save" OnClick="btnSave_Click" Width="70px"></asp:Button>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td> <div style="overflow: auto; width: 100%; height: 400px">
                            <asp:GridView ID="gvShow" runat="server" AutoGenerateColumns="False" DataKeyNames="DOC_ID" OnRowCommand="gvShow_RowCommand" EmptyDataText="No Record Found" CssClass="gridDynamic" >
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No.">
                                        <ItemTemplate>
                                            <%# ((GridViewRow)Container).RowIndex + 1%>
                                .
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="DOC_NAME" HeaderText="Document Name" />
                                    <asp:BoundField DataField="JOB_TYPE_VALUE" HeaderText="Employee Type" />
                                    <asp:BoundField DataField="DOC_FOR_VALUE" HeaderText="Document  At the time Of" />
                                    <asp:CommandField ButtonType="Image" SelectImageUrl="~/Siteimages/edit.gif" ShowSelectButton="True" HeaderText="Modify">
                                        <ItemStyle Width="40px" />
                                    </asp:CommandField>
                                    <asp:TemplateField ShowHeader="False" HeaderText="Status">
                                        <ItemStyle Width="20px" HorizontalAlign="Right" />
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgAct" runat="server" CausesValidation="false" CommandArgument='<%# Bind("DOC_ID") %>'
                                               ImageUrl='<%# Bind("STS_IMG") %>' CommandName='<%# Bind("STS_CMD") %>' ToolTip='<%# Bind("STS_TOOLTIP")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView></div>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>

    </div>

</asp:Content>

