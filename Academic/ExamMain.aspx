<%@ Page Title="ERP | Admission Category Master" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="ExamMain.aspx.cs" Inherits="Academic_ExamMain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

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

            if (!CheckControl("<%=txtFullName.ClientID%>")) {
                msg += "- Enter Full Name\n";
                if (ctrl == "")
                    ctrl = "<%=txtFullName.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtShortName.ClientID%>")) {
                msg += "- Enter Short Name\n";
                if (ctrl == "")
                    ctrl = "<%=txtShortName.ClientID%>";
                flag = false;
            }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }


    </script>

    <div>
        <div class="heading">
            <h2>Entrance Exam Master</h2>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <th>Full Name<span class="required">*</span>
                                    </th>

                                    <th>Short Name<span class="required">*</span>
                                    </th>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtFullName" runat="server" Width="289px"></asp:TextBox></td>
                                    <td>
                                        <asp:TextBox ID="txtShortName" runat="server" Width="302px"></asp:TextBox></td>
                                    <td>
                                        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" /></td>
                                </tr>

                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="gvShow" runat="server" AutoGenerateColumns="False" DataKeyNames="ENT_EXAM_ID" OnRowCommand="gvShow_RowCommand" Width="100%" EmptyDataText="No Record Avaliable" CssClass="gridDynamic">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No.">
                                        <ItemTemplate>
                                            <%# ((GridViewRow)Container).RowIndex + 1%>
                                .
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Entrance Exam Name" DataField="ENT_EXAM_FULL_NAME" />
                                    <asp:BoundField HeaderText="Short Name" DataField="ENT_EXAM_SHORT_NAME" />
                                    <asp:CommandField ButtonType="Image" SelectImageUrl="~/Siteimages/edit.gif" ShowSelectButton="True" HeaderText="Modify">
                                        <ItemStyle Width="40px" />
                                    </asp:CommandField>
                                    <asp:TemplateField ShowHeader="False" HeaderText="Status">
                                        <ItemStyle Width="20px" HorizontalAlign="Right" />
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="false" CommandArgument='<%# Bind("ENT_EXAM_ID") %>'
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

