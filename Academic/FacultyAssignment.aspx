<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="FacultyAssignment.aspx.cs" Inherits="Academic_FacultyAssignment" %>

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
        function CheckDate(ctrl) {
            var dt = document.getElementById(ctrl).value;
            if (!isDatecheck(dt, "dd/MM/yyyy")) {
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
                return false;
            }
            else
                document.getElementById(ctrl).style.backgroundColor = "#fff";
            return true;
        }
        function getDate(ctrl, ctrl1) {
            var dd = (compareDateshr(document.getElementById(ctrl).value, "dd/MM/yyyy", document.getElementById(ctrl1).value, "dd/MM/yyyy"));
            if (dd == 1)
                return false;

            return true;
        }
        function validate() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=txtTitle.ClientID%>")) {
                msg += " * Enter Title of Assignment. \n";
                if (ctrl == "")
                    ctrl = "<%=txtTitle.ClientID%>";
                flag = false;

            }
           if (!CheckControl("<%=txtdate.ClientID%>")) {
                msg += " * Enter Due Date. \n";
                if (ctrl == "")
                    ctrl = "<%=txtdate.ClientID%>";
                flag = false;
            
            }
        }
    </script>

    <div class="container">
        <div class="heading">
            <h2>Assignment</h2>
        </div>

        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>

                <asp:GridView ID="gvShow" runat="server" SelectedRowStyle-BackColor="Yellow" CssClass="gridDynamic" AutoGenerateColumns="False" DataKeyNames="TT_ID,TT_PAP_ID,EMP_ID,GRP_ID" EmptyDataText="No Record Avaliable" OnRowCommand="gvShow_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="S.No.">
                            <ItemTemplate>
                                <%# ((GridViewRow)Container).RowIndex + 1%>.
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Course_Code" HeaderText="COURSE CODE" />
                        <asp:BoundField DataField="ACA_SEM_NO" HeaderText="SEM" />
                        <asp:BoundField DataField="ACA_SEC_NAME" HeaderText="SECTION " />
                        <asp:BoundField DataField="GRP_VALUE" HeaderText="GROUP" />
                        <asp:CommandField ButtonType="Button" HeaderText="Select" ShowSelectButton="True" />

                    </Columns>
                </asp:GridView>

            </ContentTemplate>
        </asp:UpdatePanel>
        <div id="divUpload" runat="server">
            <table>
                <tr>
                    <th>Upload Resume</th>
                    <td colspan="2">
                        <asp:FileUpload ID="upd1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <th>Title</th>
                    <td colspan="2">
                        <asp:TextBox runat="server" ID="txtTitle"></asp:TextBox></td>

                </tr>
                <tr>
                    <th>Due Date</th>
                    <td>
                        <asp:TextBox ID="txtdate" runat="server" Width="90px"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="txtdate"></ajaxToolkit:CalendarExtender>
                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtdate" Mask="99/99/9999"
                            MaskType="Date">
                        </ajaxToolkit:MaskedEditExtender>
                    </td>
                    <td>
                        <asp:Button ID="btnupload" Text="Upload" runat="server" OnClick="btnupload_Click" /></td>
                </tr>
            </table>

        </div>
          <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>

                <asp:GridView ID="gvAssignment" Width="500px" runat="server"  CssClass="gridDynamic" AutoGenerateColumns="False" >
                    <Columns>
                        <asp:TemplateField HeaderText="S.No.">
                            <ItemTemplate>
                                <%# ((GridViewRow)Container).RowIndex + 1%>.
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="DOC_NAME" HeaderText="Assignment Title" />
                        <asp:BoundField DataField="DUE_DATE" HeaderText="Due Date" />
                       

                    </Columns>
                </asp:GridView>

            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

