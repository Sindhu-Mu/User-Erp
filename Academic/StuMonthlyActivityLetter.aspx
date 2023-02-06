<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="StuMonthlyActivityLetter.aspx.cs" Inherits="Academic_StuMonthlyActivityLetter" %>

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
            if (!CheckControl("<%=ddlCount.ClientID%>")) {
                msg += "- Select Counter from list\n";
                if (ctrl == "")
                    ctrl = "<%=ddlCount.ClientID%>";
                flag = false;
            }

            if (!CheckControl("<%=ddlPrntType.ClientID%>")) {
                msg += "- Select Print Type from list\n";
                if (ctrl == "")
                    ctrl = "<%=ddlPrntType.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlDoc.ClientID%>")) {
                msg += "- Select Document Type from list\n";
                if (ctrl == "")
                    ctrl = "<%=ddlPrntType.ClientID%>";
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
            <h2>Student Monthly Activity Letter
            </h2>
        </div>
        <div>
            <table>
                <tr>
                    <td>
                        <table>
                            <tr>
                                <th>Institute</th>
                                <th>Program</th>
                                <th>Branch</th>

                                <th>Batch</th>
                                <th>Semester</th>
                                <th>Section</th>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlIns" runat="server" OnSelectedIndexChanged="ddlIns_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlPgm" runat="server" OnSelectedIndexChanged="ddlPgm_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlBrn" runat="server"></asp:DropDownList>
                                </td>

                                <td>
                                    <asp:DropDownList ID="ddlBatch" runat="server"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlSem" runat="server"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlSection" runat="server"></asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table>
                            <tr>
                                <th>Counter<span class="required">*</span></th>
                                <th>Print Type<span class="required">*</span></th>
                                <th>Document Type<span class="required">*</span>
                                </th>
                                <th>Enrollment No.
                                </th>
                            </tr>
                        </table>
                    </td>

                </tr>
                <tr>
                    <td>
                        <table>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlCount" runat="server"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlPrntType" runat="server">
                                        <asp:ListItem Text="Original" Value="2" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="Duplicate" Value="1"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlDoc" runat="server">
                                        <asp:ListItem Text="Select" Value="."></asp:ListItem>
                                        <asp:ListItem Text="Monthly Report" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Registration Slip" Value="1"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEnroll" runat="server"></asp:TextBox>
                                    <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" CompletionSetCount="12"
                                        EnableCaching="true" MinimumPrefixLength="1" ServiceMethod="GetStudentList"
                                        ServicePath="~\AutoComplete.asmx" TargetControlID="txtEnroll" ContextKey="1,2,3,4,5,6">
                                    </ajaxToolkit:AutoCompleteExtender>
                                </td>
                                <td>
                                    <asp:Button ID="btnView" runat="server" Text="View" OnClick="btnView_Click" />
                                </td>
                                <td>
                                    <asp:Button ID="btnPrint" runat="server" Text="Print" OnClick="btnPrint_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>

                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="gvDetail" runat="server" CssClass="gridDynamic" AutoGenerateColumns="false" EmptyDataText="No records found" Width="100%" EnableViewState="false">
                            <SelectedRowStyle Wrap="true" />
                            <Columns>
                                <asp:TemplateField HeaderText="S#">
                                    <ItemTemplate>
                                        <%# ((GridViewRow)Container).RowIndex + 1%>.
                                    </ItemTemplate>
                                    <ItemStyle Width="10px" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="ENROLLMENT_NO" HeaderText="Enrollment No." />
                                <asp:BoundField DataField="STU_FULL_NAME" HeaderText="Name" />
                                <asp:BoundField DataField="BRN_SHORT_NAME" HeaderText="Branch" />
                                <asp:BoundField DataField="ACA_SEC_NAME" HeaderText="Section" />
                            </Columns>
                        </asp:GridView>

                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

