<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="FacultyType.aspx.cs" Inherits="Academic_FacultyType" %>

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
            if (!CheckControl("<%=txtFaculty.ClientID%>")) {

                msg += "- Enter Faculty Name\n";
                if (ctrl == "")
                    ctrl = "<%=txtFaculty.ClientID%>";
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
            <h2>Faculty Type </h2>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <td>Faculty Type Name<span class="required">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txtFaculty" runat="server"></asp:TextBox></td>
                        <td>
                            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" /></td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:GridView ID="gvFaculty" runat="server" AutoGenerateColumns="False" CssClass="gridDynamic">
                                <Columns>
                                    <asp:TemplateField HeaderText="S#">

                                        <ItemTemplate>
                                            <%# ((GridViewRow )Container).RowIndex+1 %>
                                        </ItemTemplate>
                                        <ItemStyle Width="50px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="TT_FAC_TYPE_VALUE" HeaderText="Faculty type name"></asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

