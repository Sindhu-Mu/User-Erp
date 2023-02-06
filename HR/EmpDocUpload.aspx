<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="EmpDocUpload.aspx.cs" Inherits="HR_EmpDocUpload" %>

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
        function validate() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=ddlEmployee.ClientID%>")) {
                msg += "- Select Employee Name\n";
                if (ctrl == "")
                    ctrl = "<%=ddlEmployee.ClientID%>";
                  flag = false;
              }
              if (!CheckControl("<%=ddlDocument.ClientID%>")) {
                msg += "- Select document to be uploaded \n";
                if (ctrl == "")
                    ctrl = "<%=ddlDocument.ClientID%>";
                  flag = false;
              }
              if (!CheckControl("<%=upd1.ClientID%>")) {
                msg += "- Upload File\n";
                if (ctrl == "")
                    ctrl = "<%=upd1.ClientID%>";
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
            <h2>Employee Document Upload</h2>
        </div>

        <div>
            <table>
                <tr>
                    <td>
                        <table>
                            <tr style="text-align: left;">
                                <th>Institute </th>
                                <td>&nbsp;</td>
                                <th>Department </th>
                                <td>&nbsp;</td>
                                <th>Employee Name</th>
                                <td>&nbsp;</td>
                                <th>Document(s) to be Uploaded </th>
                                <td>&nbsp;</td>
                                <th>Upload File </th>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlInstitute" runat="server" Width="100px" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlInstitute_SelectedIndexChanged">
                                    </asp:DropDownList></td>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:DropDownList ID="ddlDepartment" runat="server" Width="150px" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged">
                                    </asp:DropDownList></td>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:DropDownList ID="ddlEmployee" runat="server" Width="170px" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlEmployee_SelectedIndexChanged">
                                    </asp:DropDownList></td>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:DropDownList ID="ddlDocument" runat="server" Width="170px">
                                    </asp:DropDownList></td>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:FileUpload ID="upd1" runat="server" Width="250px" /></td>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"
                                        Width="45px" /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="GridShow" runat="server" AutoGenerateColumns="False" GridLines="None"
                            EmptyDataText="No Record Found" CssClass="gridDynamic" DataKeyNames="DOC_UP_ID">
                            <Columns>
                                <asp:TemplateField HeaderText="S.No.">
                                    <ItemTemplate>
                                        <%# ((GridViewRow)Container).RowIndex + 1%>
                                    </ItemTemplate>
                                    <ItemStyle Width="50px" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="EMP_NAME" HeaderText="Employee Name"></asp:BoundField>
                                <asp:BoundField DataField="DOC_NAME" HeaderText="Document Name"></asp:BoundField>
                                <asp:BoundField DataField="IN_DT" HeaderText="Uploaded Date" DataFormatString="{0:dd/MM/yyyy}"></asp:BoundField>
                                <asp:TemplateField HeaderText="Uploaded Document">
                                    <ItemTemplate>

                                        <asp:HyperLink ID="File" Text='<%# Bind("UPLD_FILE") %>' NavigateUrl='<%# Bind("DOC_UP_ID") %>'
                                            Target="_blank" runat="server"></asp:HyperLink>
                                        <controlstyle font-underline="True" forecolor="Blue" />
                                        <itemstyle font-underline="True" forecolor="CornflowerBlue" width="100px" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>

        </div>
    </div>
</asp:Content>

