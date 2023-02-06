<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="DocumentMain.aspx.cs" Inherits="Academic_DocumentMain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


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
        function validation() {

            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=ddlDocFor.ClientID%>")) {
                msg += "- Select Document at the time of from list\n";
                if (ctrl == "")
                    ctrl = "<%=ddlDocFor.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtDocName.ClientID%>")) {
                msg += "- Enter Document Name\n";
                if (ctrl == "")
                    ctrl = "<%=txtDocName.ClientID%>";
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
            <h2>Document Master</h2>
        </div>
        <table>
            <tr>
                <th>At The Time Of <span class="required">*</span></th>
                <td>&nbsp;</td>
                <th>Document Name <span class="required">*</span></th>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlDocFor" runat="server" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="ddlDocFor_SelectedIndexChanged">
                    </asp:DropDownList></td>
                <td>&nbsp;</td>
                <td>
                    <asp:TextBox ID="txtDocName" runat="server" CssClass="textBox" Width="300px"></asp:TextBox></td>
                <td>&nbsp;</td>


                <td>
                    <asp:Button ID="btnSave" runat="server" Text="Save" Width="70px" OnClick="btnSave_Click" /></td>
            </tr>


            <tr>
                <td colspan="3">
                    <asp:GridView ID="gvShow" runat="server" AutoGenerateColumns="False" DataKeyNames="DOC_ID" OnRowCommand="gvShow_RowCommand" CssClass="gridDynamic">
                        <Columns>
                            <asp:TemplateField HeaderText="S.No.">
                                <ItemTemplate>
                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                .
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Doc Name" DataField="DOC_VALUE" />
                            <asp:BoundField HeaderText="At The Time Of" DataField="DOC_FOR_VALUE" />
                            <asp:CommandField ButtonType="Image" SelectImageUrl="~/Siteimages/edit.gif" ShowSelectButton="True" HeaderText="Modify">
                                <ItemStyle Width="40px" />
                            </asp:CommandField>
                            <asp:TemplateField ShowHeader="False" HeaderText="Status">
                                <ItemStyle Width="20px" HorizontalAlign="Right" />
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="false" CommandArgument='<%# Bind("DOC_ID") %>'
                                        ImageUrl='<%# Bind("STS_IMG") %>' CommandName='<%# Bind("STS_CMD") %>' ToolTip='<%# Bind("STS_TOOLTIP")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>



    </div>
</asp:Content>

