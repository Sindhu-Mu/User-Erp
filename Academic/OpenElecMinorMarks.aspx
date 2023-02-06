<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="OpenElecMinorMarks.aspx.cs" Inherits="Academic_OpenElecMinorMarks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script lang="javascript" type="text/javascript">

        function show_confirm() {
            var r = confirm("You have decided to mark the entries as final. You won't be able any further changes. Do you wish to continue?");
            if (r == true) {
                return true;
            }
            else {
                return false;
            }
        }

         function CheckControl(ctrl) {
             if (bTrim(document.getElementById(ctrl).value) == "." || bTrim(document.getElementById(ctrl).value) == "Select") {
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
             if (!CheckControl("<%=ddlPaper.ClientID%>")) {
                msg += "Select Paper Code from List\n";
                if (ctrl == "")
                    ctrl = "<%=ddlPaper.ClientID%>";
                flag = false;
             }
             var flag = true;
             var msg = "", ctrl = "";
             if (!CheckControl("<%=ddlExamination.ClientID%>")) {
                 msg += "Select valid Exam Type from List\n";
                 if (ctrl == "")
                     ctrl = "<%=ddlExamination.ClientID%>";
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
            <h2>Open Elective Marks </h2>
        </div>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <table style="width: 100%">
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <th>Paper</th>
                                    <th>Examination</th>
                                </tr>
                                <tr>
                                    <td>
                                         <asp:DropDownList ID="ddlPaper" runat="server" OnSelectedIndexChanged="ddlPaper_SelectedIndexChanged" AutoPostBack="true" Width="100px">
                                        </asp:DropDownList>
                                    </td>
                                     <td>
                                        <asp:DropDownList ID="ddlExamination" Width="120px" runat="server" AutoPostBack="true" ></asp:DropDownList>
                                    </td>


                                    <td>
                                        <asp:Button ID="btnView" runat="server" Text="View" CssClass="btnBrown" OnClick="btnView_Click" />
                                        <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="btnBrown" OnClick="btnPrint_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>
                            <tr>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <div id="divStudent" runat="server" style="overflow: auto; height: 450px; width: 100%;">
                                                <asp:GridView ID="gvStudent" CssClass="gridDynamic" Caption="Student List" runat="server" AutoGenerateColumns="False"
                                                    DataKeyNames="STU_MAIN_ID">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="S.No.">
                                                            <ItemTemplate>
                                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                                            </ItemTemplate>
                                                            <ItemStyle Width="20px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField HeaderText="Enrollment No." DataField="ENROLLMENT_NO" />
                                                        <asp:BoundField HeaderText="Name" DataField="STU_FULL_NAME" />
                                                        <asp:TemplateField HeaderText="Marks" ItemStyle-Width="200px">
                                                            <ItemTemplate>
                                                                <cc1:NumericTextBox ID="txtMarks" runat="server" AllowDecimal="true" AllowNegative="false" MaxLength="4" DecimalPlaces="1" AutoCompleteType="None" Width="80px" placeholder="Marks"></cc1:NumericTextBox>
                                                               <%-- <asp:RangeValidator ID="rgvDob" runat="server" ErrorMessage="Invalid Marks" Type="Double" ControlToValidate="txtMarks" ForeColor="Red" MaximumValue='<%# Eval("EXAM_MAX_MARKS") %>' MinimumValue="0" SetFocusOnError="True" EnableClientScript="false"></asp:RangeValidator>--%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Attendance">
                                                            <ItemTemplate>
                                                                <asp:RadioButtonList ID="AttList" Width="150px" runat="server" CellPadding="0" CellSpacing="0" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Selected="True" Value="1">Present</asp:ListItem>
                                                                    <asp:ListItem Value="0">Absent</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                          
                                            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" OnClientClick="show_confirm()" /></td>
                                        </div>
                                                  </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right;">

                                   <%-- <asp:Button ID="btnVerify" runat="server" Text="Verify Entry" OnClick="btnVerify_Click" />&nbsp;--%>
                                               <%-- <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" OnClientClick="show_confirm()" /></td>--%>
                            </tr>
                        </td>
                    </tr>

                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

