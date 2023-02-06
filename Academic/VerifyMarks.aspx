<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="VerifyMarks.aspx.cs" Inherits="Academic_VerifyMarks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script lang ="javascript" type="text/javascript">

        function CheckControl(ctrl) {
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == "." || bTrim(document.getElementById(ctrl).value) == "Select") {
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
                return false;
            }
            else
                document.getElementById(ctrl).style.backgroundColor = "#fff";
            return true;
        }

        function validateType() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=ddlExam.ClientID%>")) {
                msg += "- Select Exam.\n";
                if (ctrl == "")
                    ctrl = "<%=ddlExam.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlIns.ClientID%>")) {
                msg += "- Select Institute.\n";
                if (ctrl == "")
                    ctrl = "<%=ddlIns.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlPgm.ClientID%>")) {
                msg += "- Select Program.\n";
                if (ctrl == "")
                    ctrl = "<%=ddlPgm.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlBranch.ClientID%>")) {
                msg += "- Select Branch.\n";
                if (ctrl == "")
                    ctrl = "<%=ddlBranch.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlSem.ClientID%>")) {
                msg += "- Select Sem.\n";
                if (ctrl == "")
                    ctrl = "<%=ddlSem.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlPaperType.ClientID%>")) {
                msg += "- Select Paper Type.\n";
                if (ctrl == "")
                    ctrl = "<%=ddlPaperType.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlPaper.ClientID%>")) {
                msg += "- Select Paper Code.\n";
                if (ctrl == "")
                    ctrl = "<%=ddlPaper.ClientID%>";
                flag = false;
            }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }
        function VerifyMarks() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=ddlVerifyType.ClientID%>")) {
                msg += "- Select Exam Type For Verification.\n";
                if (ctrl == "")
                    ctrl = "<%=ddlVerifyType.ClientID%>";
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
            <h2>Verify Marks</h2>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <th>By Examination<span class="required">*</span></th>
                        <th>By Institute<span class="required">*</span></th>
                        <th>By Program<span class="required">*</span></th>
                        <th>By Branch<span class="required">*</span></th>
                        <th>By Sem<span class="required">*</span></th>
                        <th>Paper Type<span class="required">*</span></th>
                        <th>Paper Code<span class="required">*</span></th>
                        <th>Select Type</th>
                        <th></th>                      
                    </tr>
                    <tr>
                        <td><asp:DropDownList ID="ddlExam" runat="server" AutoPostBack="True" Width="100px"></asp:DropDownList></td>
                        <td><asp:DropDownList ID="ddlIns" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlIns_SelectedIndexChanged"></asp:DropDownList></td>
                        <td><asp:DropDownList ID="ddlPgm" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPgm_SelectedIndexChanged" Width="80px"></asp:DropDownList></td>
                        <td><asp:DropDownList ID="ddlBranch" runat="server" AutoPostBack="True"></asp:DropDownList></td>
                        <td><asp:DropDownList ID="ddlSem" runat="server" AutoPostBack="True"></asp:DropDownList></td>
                        <td><asp:DropDownList ID="ddlPaperType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPaperType_SelectedIndexChanged" Width="80px"></asp:DropDownList></td>
                        <td><asp:DropDownList ID="ddlPaper" runat="server" AutoPostBack="True" Width="200px"></asp:DropDownList></td>
                        <td><asp:DropDownList ID="ddlType" runat="server" AutoPostBack="true" Width="100px">
                            <asp:ListItem Value="1">Verify Marks</asp:ListItem>
                            <asp:ListItem Value="2">Update Marks</asp:ListItem>
                            </asp:DropDownList></td>
                        <td><asp:Button ID="btnView" runat="server" Text="View" OnClick="btnView_Click" /></td>
                         
                    </tr>
                    <tr id="tdVerify" runat="server" style="text-align:center">
                         <th>Exam Type<span class="required">*</span></th>
                         <td><asp:DropDownList ID="ddlVerifyType" runat="server">
                              <asp:ListItem Value="0">All</asp:ListItem>
                              <asp:ListItem Value="1">Minor</asp:ListItem>
                              <asp:ListItem Value="2">Major</asp:ListItem>
                              </asp:DropDownList></td>
                        
                        <td><asp:Button ID="btnVerify" runat="server" Text="Marks Verified" OnClick="btnVerify_Click"/></td>
                    </tr>
                </table>
                <table runat="server" id="tblVerify">
                    <tr>
                        <td>
                            <div style="height:450px;overflow:auto">
                       <asp:GridView ID="gvStudent" runat="server" CssClass="gridDynamic" AutoGenerateColumns="true" DataKeyNames="Enroll,Total,Major" Font-Size="15px">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No">
                                        <ItemTemplate>
                                            <%#((GridViewRow)Container).RowIndex +1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                        </td>
                    </tr>
                </table>
                <table id="tblUpdate" runat="server">
                    <tr>
                        <td>
                            <asp:GridView ID="gvEdit" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" DataKeyNames="ENROLLMENT_NO" Font-Size="15px">
                                <Columns>
                                     <asp:TemplateField HeaderText="S.No">
                                        <ItemTemplate>
                                            <%#((GridViewRow)Container).RowIndex +1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Enrollment" DataField="ENROLLMENT_NO" />
                                    <asp:BoundField HeaderText="Name" DataField="STU_FULL_NAME" />
                                        <asp:TemplateField HeaderText="Internal Marks">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtIntMarks" runat="server" Text='<%#Eval("INTERNAL_MARKS") %>'></asp:TextBox>
                                       </ItemTemplate>
                                        </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Major Marks">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtMajorMarks" runat="server" Text='<%#Eval("MAJOR_MARKS") %>'></asp:TextBox>
                                       </ItemTemplate>
                                        </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td><asp:Button ID="btnUpdate" runat="server" Text="Update Marks" OnClick="btnUpdate_Click" Visible="false" /></td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

