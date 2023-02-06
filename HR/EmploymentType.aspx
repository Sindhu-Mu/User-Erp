<%@ Page Title="ERP | Employment Type" Language="C#" MasterPageFile="~/MasterPages/Short.master" AutoEventWireup="true" CodeFile="EmploymentType.aspx.cs" Inherits="HR_EmploymentType" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentHolder1" runat="Server">

    <script language="javascript" type="text/javascript">

        function CheckControl(ctrl) {
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == "Select") {
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

            if (!CheckControl("<%=txtTypeValue.ClientID%>")) {
                msg += "- Enter Service Type Value \n";
                if (ctrl == "")
                    ctrl = "<%=txtTypeValue.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtDescription.ClientID%>")) {
                msg += "- Enter Service Type Desc \n";
                if (ctrl == "")
                    ctrl = "<%=txtDescription.ClientID%>";
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
            <h2>Employment Type</h2>
        </div>
        <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <th>Employment Type <span class="required">*</span></th>
                                        <td>&nbsp;</td>
                                        <th>Description<span class="required">*</span></th>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtTypeValue" runat="server" CssClass="textBox" Width="287px"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td>
                                            <asp:TextBox ID="txtDescription" runat="server" CssClass="textBox" Width="340px"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td>
                                            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="gvShow" runat="server" AutoGenerateColumns="False" DataKeyNames="SERV_TYPE_ID" CssClass="gridDynamic" OnRowCommand="gvShow_RowCommand">
                                    <Columns>
                                        <asp:TemplateField HeaderText="S.No.">
                                            <ItemTemplate>
                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                            </ItemTemplate>
                                            <ItemStyle Width="15px" />
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Type Name" DataField="SERV_TYPE_VALUE" />
                                        <asp:BoundField HeaderText="Description" DataField="SERV_TYPE_DESC" />
                                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/Siteimages/edit.gif" ShowSelectButton="True" HeaderText="Modify">
                                            <ItemStyle Width="40px" />
                                        </asp:CommandField>
                                        <asp:TemplateField ShowHeader="False" HeaderText="Status">
                                            <ItemStyle Width="20px" HorizontalAlign="Right" />
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgAct" runat="server" CausesValidation="false" CommandArgument='<%# Bind("SERV_TYPE_ID") %>'
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
        </div>
    </div>
</asp:Content>

