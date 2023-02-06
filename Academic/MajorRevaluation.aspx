<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="MajorRevaluation.aspx.cs" Inherits="Academic_MajorRevaluation" %>

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
        function validation() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=ddlExam.ClientID%>")) {
                msg += " * Select Examination \n";
                if (ctrl == "")
                    ctrl = "<%=ddlExam.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlBranch.ClientID%>")) {
                msg += " * Enter Enrollment No. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlBranch.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlSem.ClientID%>")) {
                msg += " * Enter Marks \n";
                if (ctrl == "")
                    ctrl = "<%=ddlSem.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlPaper.ClientID%>")) {
                msg += " * Select Paper Code \n";
                if (ctrl == "")
                    ctrl = "<%=ddlPaper.ClientID%>";
                flag = false;
            }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }

        function validationSave() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=ddlExam.ClientID%>")) {
                msg += " * Select Examination \n";
                if (ctrl == "")
                    ctrl = "<%=ddlExam.ClientID%>";
                flag = false;
            }
            if (!CheckAutoComplete("<%=txtExaminor.ClientID%>")) {
                msg += " * Enter Examiner \n";
                if (ctrl == "")
                    ctrl = "<%=txtExaminor.ClientID%>";
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
            <h2>Major Marks Revaluation </h2>
        </div>
        <asp:UpdatePanel ID="UP1" runat="server">
            <ContentTemplate>
                <div>
                    <table>
                        <tr>
                            <th>Examination</th>
                            <td>&nbsp;</td>
                            <th>Institute</th>
                            <td>&nbsp;</td>
                            <th>Program</th>
                            <td>&nbsp;</td>
                            <th>Branch</th>
                            <td>&nbsp;</td>
                            <th>Semester</th>
                            <td>&nbsp;</td>
                            <th>Paper Code</th>
                            <td>&nbsp;</td>

                        </tr>
                        <tr>
                            <td>
                                <asp:DropDownList ID="ddlExam" runat="server"></asp:DropDownList>
                            </td>
                            <td>&nbsp;</td>
                            <td>
                                <asp:DropDownList ID="ddlIns" runat="server" OnSelectedIndexChanged="ddlIns_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            </td>
                            <td>&nbsp;</td>
                            <td>
                                <asp:DropDownList ID="ddlPrgm" runat="server" OnSelectedIndexChanged="ddlPrgm_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            </td>
                            <td>&nbsp;</td>
                            <td>
                                <asp:DropDownList ID="ddlBranch" runat="server"></asp:DropDownList>
                            </td>
                            <td>&nbsp;</td>
                            <td>
                                <asp:DropDownList ID="ddlSem" runat="server" OnSelectedIndexChanged="ddlSem_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            </td>
                            <td>&nbsp;</td>
                            <td>
                                <asp:DropDownList ID="ddlPaper" runat="server"></asp:DropDownList>
                            </td>
                            <td>&nbsp;</td>
                            <td>
                                <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" /></td>
                        </tr>
                    </table>
                </div>
                <div>
                    <asp:GridView ID="gvDetail" runat="server" AutoGenerateColumns="false" Width="50%" DataKeyNames="MEM_ID,STU_MAIN_ID,EVA_SCH_SUB_ID" CssClass="gridDynamic">
                        <Columns>
                            <asp:TemplateField HeaderText="S.No.">
                                <ItemTemplate>
                                    <%# ((GridViewRow)Container).RowIndex + 1%>                                                        .
                                </ItemTemplate>
                                <ItemStyle Width="15px" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="ENROLLMENT_NO" HeaderText="Enrollment No." />                            
                            <asp:TemplateField HeaderText="Enter New Marks">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtMarks" Text='<%#Eval("REVALUATE_MARKS") %>' runat="server" ></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="MAX_MAJOR" HeaderText="Maximum" />                        
                        </Columns>
                    </asp:GridView>
                </div>
                <div>
                    <asp:Label ID="lblMsg" runat="server" Font-Bold="true" ForeColor="Red"></asp:Label>
                    <asp:TextBox ID="TextBox1" runat="server" Visible="false"></asp:TextBox>
                </div>
                <div id="DivSave" runat="server" visible="false">

                    <table>
                        <tr>
                            <th>Examiner</th>
                            <td>&nbsp;</td>
                           
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr >
                            <td>
                                <asp:TextBox ID="txtExaminor" runat="server"></asp:TextBox>
                                <ajaxToolkit:AutoCompleteExtender ID="autoComplete1" runat="server" CompletionInterval="500"
                                    CompletionSetCount="12" ContextKey="1" EnableCaching="true" MinimumPrefixLength="1"
                                    ServiceMethod="GetEmployeeList" ServicePath="~\AutoComplete.asmx" TargetControlID="txtExaminor">
                                </ajaxToolkit:AutoCompleteExtender>
                            </td>
                           
                            <td>&nbsp;</td>

                            <td>
                                <asp:Button ID="btnSave" runat="server" Text="Save"  OnClick="btnSave_Click" />
                            </td>
                        </tr>
                    </table>

                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

    </div>
</asp:Content>

