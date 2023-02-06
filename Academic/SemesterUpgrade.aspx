<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="SemesterUpgrade.aspx.cs" Inherits="Academic_SemesterUpgrade" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script lang="javascript" type="text/javascript">
        function SelectAllCheckboxes(spanChk) {

            var oItem = spanChk.children;
            var theBox = (spanChk.type == "checkbox") ?
                spanChk : spanChk.children.item[0];
            xState = theBox.checked;
            elm = theBox.form.elements;

            for (i = 0; i < elm.length; i++)
                if (elm[i].type == "checkbox" &&
                         elm[i].id != theBox.id) {

                    if (elm[i].checked != xState)
                        elm[i].click();

                }

        }
        function CheckControl(ctrl) {
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == ".") {
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

            if (!CheckControl("<%=ddlInstitution.ClientID%>")) {
                msg += " * Select Institute. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlInstitution.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlCourse.ClientID%>")) {
                msg += " * Select Program. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlCourse.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlBranch.ClientID%>")) {
                msg += " * Select branch. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlBranch.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlBatch.ClientID%>")) {
                msg += " * Select batch. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlBatch.ClientID%>";
                flag = false;
            }


            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }
        function validation() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=ddlBranch2.ClientID%>")) {
                msg += " * Select branch. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlBranch2.ClientID%>";
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
            <h2>Semester Upgrade </h2>
        </div>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <div>
                    <table>
                        <tr>
                            <th>Batch<span style="color: red">*</span></th>
                            <td>&nbsp;</td>
                            <th>Institution<span style="color: red">*</span></th>
                            <td>&nbsp;</td>
                            <th>Program<span style="color: red">*</span></th>
                            <td>&nbsp;</td>
                            <th>Branch<span style="color: red">*</span></th>
                            <td>&nbsp;</td>
                            <th>Semester<span style="color: red">*</span></th>
                            <td>&nbsp;</td>
                            <td></td>

                        </tr>
                        <tr>
                            <td>
                                <asp:DropDownList ID="ddlBatch" runat="server" Width="156px"></asp:DropDownList>
                            </td>
                            <td>&nbsp;</td>
                            <td>
                                <asp:DropDownList ID="ddlInstitution" runat="server" Width="80px" OnSelectedIndexChanged="ddlInstitution_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                            </td>
                            <td>&nbsp;</td>
                            <td>
                                <asp:DropDownList ID="ddlCourse" runat="server" Width="153px" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                            </td>
                            <td>&nbsp;</td>
                            <td>
                                <asp:DropDownList ID="ddlBranch" runat="server" Width="156px"  OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                            </td>
                            <td>&nbsp;</td>

                            <td>
                                <asp:DropDownList ID="ddlSemester" runat="server" Width="80px"></asp:DropDownList>
                            </td>
                            <td>&nbsp;</td>

                            <td>
                                <asp:Button ID="btnShow" runat="server" Text="Show Students" Height="28px" OnClick="btnShow_Click" /></td>

                        </tr>
                    </table>
                </div>
                <div style="overflow: auto; max-height: 450px; width: 100%;">
                    <asp:GridView ID="GridStudent" runat="server" AutoGenerateColumns="false" EmptyDataText="No. records found"
                        CssClass="gridDynamic" Caption="Student Details" DataKeyNames="STU_MAIN_ID">
                        <Columns>
                            <asp:TemplateField HeaderText="S.No.">
                                <ItemTemplate>
                                    <%# ((GridViewRow)Container).RowIndex + 1%>.
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="ENROLLMENT_NO" HeaderText="Enrollment No" />
                            <asp:BoundField DataField="STU_FULL_NAME" HeaderText="Name" />
                            <asp:BoundField DataField="ACA_SEM_ID" HeaderText="Semester" />
                             <asp:BoundField DataField="Balance" HeaderText="Fee Balance" DataFormatString="{0:N2}" />
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <input id="chkAll" onclick="javascript: SelectAllCheckboxes(this);" type="checkbox"
                                        value="on" runat="server" />All
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="ChkBox" runat="server" />
                                </ItemTemplate>
                                <ItemStyle Width="50px" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <div style="float: right; padding-right: 20px;" id="DivAction" runat="server" visible="false">
                    <table>
                        <tr>
                            <th>Total Students are :-</th>
                            <td>&nbsp;</td>
                            <th>New Branch</th>
                            <td>&nbsp;</td>
                            <th>Action</th>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>


                        </tr>
                        <tr><td style="vertical-align: bottom">
                                <asp:Label ID="lblTotal" Font-Bold="true" ForeColor="Red" runat="server"></asp:Label></td>
                            <td>&nbsp;</td>
                            <td style="vertical-align: bottom">
                                <asp:DropDownList ID="ddlBranch2" runat="server" Width="156px"></asp:DropDownList>
                            </td>
                            <td>&nbsp;</td>
                            
                            <td style="vertical-align: bottom">
                                <asp:DropDownList ID="ddlAction" runat="server">
                                    <asp:ListItem Value="1" Selected="True">Move to next semester </asp:ListItem>
                                    <asp:ListItem Value="0">Reverse to priveouse semester </asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td style="vertical-align: bottom">
                                <asp:Button ID="btnAction" runat="server" Text="Submit Action" Height="28px" OnClick="btnAction_Click" /></td>
                        </tr>
                    </table>
                </div>
                <div class="cleaner"></div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

