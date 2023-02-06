<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="DocumentMapping.aspx.cs" Inherits="Academic_DocumentMapping" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <script language="javascript" type="text/javascript">

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
            if (!CheckControl("<%=ddlDocument.ClientID%>")) {
                msg += "- Select document from list\n";
                if (ctrl == "")
                    ctrl = "<%=ddlDocument.ClientID%>";
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
            <h2>Document Mapping</h2>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <th>Document Name<span class="required">*</span>
                                    </th>
                                    <th></th>
                                    <th>Program Name<span class="required">*</span>
                                    </th>
                                    <th></th>
                                    <th>Quota Name<span class="required">*</span></th>



                                </tr>
                                <tr>
                                    <td>
                                        <asp:DropDownList ID="ddlDocument" runat="server" Width="200px">
                                        </asp:DropDownList></td>
                                    <td></td>
                                    <td>
                                        <asp:DropDownList ID="ddlProgram" runat="server" Width="200px">
                                        </asp:DropDownList></td>
                                    <td></td>
                                    <td>
                                        <asp:DropDownList ID="ddlQuota" runat="server" Width="200px">
                                        </asp:DropDownList></td>

                                    <td>
                                        <asp:Button ID="btnSave" runat="server"
                                            Text="Save" OnClick="btnSave_Click" Width="50px"></asp:Button></td>

                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="gvShow" runat="server" AutoGenerateColumns="False" DataKeyNames="PGM_DOC_MAP_ID" OnRowCommand="gvShow_RowCommand" Width="100%" EmptyDataText="No Record Avaliable" CssClass="gridDynamic">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No.">
                                        <ItemTemplate>
                                            <%# ((GridViewRow)Container).RowIndex + 1%>                                .
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Document Name" DataField="DOC_VALUE" />
                                    <asp:BoundField HeaderText="Course Name" DataField="PGM_FULL_NAME" />
                                    <asp:BoundField HeaderText="Quota Name" DataField="QUOTA_NAME" />
                                    <asp:CommandField ButtonType="Image" SelectImageUrl="~/Siteimages/edit.gif" ShowSelectButton="True" HeaderText="Modify">
                                        <ItemStyle Width="40px" />
                                    </asp:CommandField>
                                    <asp:TemplateField ShowHeader="False" HeaderText="Status">
                                        <ItemStyle Width="20px" HorizontalAlign="Right" />
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="false" CommandArgument='<%# Bind("PGM_DOC_MAP_ID") %>'
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
</asp:Content>

