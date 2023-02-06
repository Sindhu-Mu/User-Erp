<%@ Page Title="ERP | Subject Master" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="SubjectMain.aspx.cs" Inherits="Academic_SubjectMain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script lang="javascript" type="text/javascript">
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
            if (!CheckControl("<%=ddlDepartment.ClientID%>")) {
                msg += "- Enter Subject Short Name\n";
                if (ctrl == "")
                    ctrl = "<%=ddlDepartment.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtSubjectName.ClientID%>")) {
                msg += "- Enter Subject Name\n";
                if (ctrl == "")
                    ctrl = "<%=txtSubjectName.ClientID%>";
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
            <h2>Subject Main</h2>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                    <table>
                        <tr>
                            <th>Subject Department <span class="required">*</span></th>
                            <td>&nbsp;</td>
                            <th>Subject Name
                                   <span class="required">*</span></th>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:DropDownList ID="ddlDepartment" runat="server" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></td>
                            <td>&nbsp;</td>
                            <td>
                                <asp:TextBox ID="txtSubjectName" runat="server" CssClass="textbox"></asp:TextBox></td>
                            <td>
                                <asp:Button ID="btnSave" runat="server" Text="Save" Width="70px" OnClick="btnSave_Click" /></td>
                        </tr>


                    </table>
                </div>
                <div style="height: 400px; overflow: auto; width: 97%">
                    <asp:GridView ID="gvShow" runat="server" AutoGenerateColumns="False" DataKeyNames="ACA_SUB_ID" OnRowCommand="gvShow_RowCommand" Width="97%" EmptyDataText="No Record Avaliable" CssClass="gridDynamic">
                        <Columns>
                            <asp:TemplateField HeaderText="S.No.">
                                <ItemTemplate>
                                    <%# ((GridViewRow)Container).RowIndex + 1%>.                                             
                                </ItemTemplate>
                                <ItemStyle Width="20px" />
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Subject" DataField="ACA_SUB_NAME" />
                            <asp:BoundField HeaderText="Department" DataField="DEPT_VALUE" />
                            <asp:CommandField ButtonType="Image" SelectImageUrl="~/Siteimages/edit.gif" ShowSelectButton="True" HeaderText="Modify">
                                <ItemStyle Width="40px" />
                            </asp:CommandField>
                            <asp:TemplateField ShowHeader="False" HeaderText="Status">
                                <ItemStyle Width="20px" HorizontalAlign="Right" />
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="false" CommandArgument='<%# Bind("ACA_SUB_ID") %>'
                                        ImageUrl='<%# Bind("STS_IMG") %>' CommandName='<%# Bind("STS_CMD") %>' ToolTip='<%# Bind("STS_TOOLTIP")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                    </asp:GridView>
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

