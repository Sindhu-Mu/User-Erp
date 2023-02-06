<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="OpenElecViewAtt.aspx.cs" Inherits="Academic_OpenElecViewAtt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script lang="javascript" type="text/javascript">
        function CheckAutoComplete(ctrl) {

            var Value = bTrim(document.getElementById(ctrl).value);
            if (Value.indexOf(":") > 0 && Value.length - 1 != Value.lastIndexOf(":")) {
                document.getElementById(ctrl).style.backgroundColor = "#fff";
                return true;
            }
            else
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
            return false;
        }

       
    </script>
    <div class="container">
        <div class="heading">
            <h2>Open Elective Attendance and Marks Status </h2>
        </div>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <table >
                    <tr>
                        <td>
                            <span style="color:red;">* Select either Faculty or Paper</span>
                        </td>
                    </tr>
                    <tr>

                        <th>Faculty</th>
                        <th>Paper</th>
                    </tr>
                    <tr>

                       
                        <td>
                            <asp:TextBox ID="txtFaculty" runat="server" Width="200px"></asp:TextBox>
                            <ajaxToolkit:AutoCompleteExtender ID="autoComplete1" runat="server" CompletionInterval="500"
                                CompletionSetCount="12" ContextKey="0,1,2,3,4" EnableCaching="true" MinimumPrefixLength="1"
                                ServiceMethod="GetEmployeeList" ServicePath="~\AutoComplete.asmx" TargetControlID="txtFaculty">
                            </ajaxToolkit:AutoCompleteExtender>
                        </td>
                        <td>
                                        <asp:DropDownList ID="ddlPaper" runat="server" Width="100px"
                                            AutoPostBack="True">
                                        </asp:DropDownList>
                                    </td>
                        <td>
                        <asp:Button ID="btnViewAtt" runat="server" Text="View Attendance" CssClass="btnBrown" OnClick="btnViewAtt_Click" />
                        
                            </td>
                        <td>
                             <asp:Button ID="btnViewMarks" runat="server" Text="View Marks" CssClass="btnBrown" OnClick="btnViewMarks_Click" />
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
                                            <asp:GridView ID="gvPaper" CssClass="gridDynamic" Caption="Open Elective Attendance Detail " runat="server" AutoGenerateColumns="False" EnableViewState="True">


                                                <Columns>
                                                    <asp:TemplateField HeaderText="S.No.">
                                                        <ItemTemplate>
                                                            <%# ((GridViewRow)Container).RowIndex + 1%>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="20px" />
                                                    </asp:TemplateField>

                                                    <asp:BoundField HeaderText="Paper Code" DataField="PAPER_CODE" />
                                                    <asp:BoundField HeaderText="Class Date" DataField="CLS_DT" />
                                                </Columns>
                                            </asp:GridView>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>

                        </td>
                    </tr>
                    <tr>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <asp:GridView ID="gvMarks" CssClass="gridDynamic" Caption="Open Elective Marks Detail " runat="server" AutoGenerateColumns="False" EnableViewState="True">


                                                <Columns>
                                                    <asp:TemplateField HeaderText="S.No.">
                                                        <ItemTemplate>
                                                            <%# ((GridViewRow)Container).RowIndex + 1%>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="20px" />
                                                    </asp:TemplateField>

                                                    <asp:BoundField HeaderText="Paper Code" DataField="PAPER_CODE" />
                                                    <asp:BoundField HeaderText="Examination" DataField="EXAM_TYPE_SUB_HEAD" />

                                                </Columns>
                                            </asp:GridView>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

