<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="Re_Reg_App.aspx.cs" Inherits="Academic_Re_Reg_App" %>

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
                    //elm[i].click();
                    if (elm[i].checked != xState)
                        elm[i].click();
                    //elm[i].checked=xState;
                }

        }
        function CheckControl(ctrl) {
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == "." || bTrim(document.getElementById(ctrl).value) == "Select") {
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
                return false;
            }
            else
                document.getElementById(ctrl).style.backgroundColor = "#fff";
            return true;
        }
        function Validate() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=ddlReg.ClientID%>")) {
                msg += "- Select Registration session from list. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlReg.ClientID%>";
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
            <h2>Re-Admission Final Printing</h2>
        </div>
        <table>
            <tr>
                <td>
                    <table>
                        <tr>
                            <th>By RegFor</th>
                            <th>By Enroll</th>
                            <th>By Insititute</th>
                            <th>By Program</th>
                            <th>By Branch</th>
                            <th>By Semester</th>
                            <th>By Reg Status</th>
                            <th>By Status</th>
                        </tr>
                        <tr>
                            <td>
                                <asp:DropDownList ID="ddlReg" runat="server"></asp:DropDownList></td>
                            <td>
                                <asp:TextBox ID="txtStu" runat="server"></asp:TextBox></td>
                            <td>
                                <asp:DropDownList ID="ddlIns" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlIns_SelectedIndexChanged"></asp:DropDownList></td>
                            <td>
                                <asp:DropDownList ID="ddlProgram" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProgram_SelectedIndexChanged"></asp:DropDownList></td>
                            <td>
                                <asp:DropDownList ID="ddlBranch" runat="server"></asp:DropDownList></td>
                            <td>
                                <asp:DropDownList ID="ddlSem" runat="server"></asp:DropDownList></td>
                            <td>
                                <asp:DropDownList ID="ddlRegSts" runat="server">
                                    <asp:ListItem Value="0" Text="Pending"></asp:ListItem>
                                    <asp:ListItem Value="1" Text="Approved"></asp:ListItem>
                                </asp:DropDownList></td>
                            <td>
                                <asp:DropDownList ID="ddlSts" runat="server">
                                    <asp:ListItem Value="2" Text="All"></asp:ListItem>
                                    <asp:ListItem Value="1" Text="Printed"></asp:ListItem>
                                    <asp:ListItem Value="0" Text="Not Printed"></asp:ListItem>
                                </asp:DropDownList></td>
                            <td>
                                <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" />
                            </td>
                            <td>
                                <ajaxToolkit:AutoCompleteExtender ID="autoComplete2" runat="server" EnableCaching="true"
                                    TargetControlID="txtStu" ServicePath="~/AutoComplete.asmx" ServiceMethod="GetStudentList"
                                    MinimumPrefixLength="1" ContextKey="1" CompletionSetCount="12" CompletionInterval="500">
                                </ajaxToolkit:AutoCompleteExtender>
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td>
                                <div style="height: 400px; overflow: auto">
                                    <asp:GridView ID="gvShow" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" DataKeyNames="SEM_REG_ID">
                                        <Columns>
                                            <asp:TemplateField HeaderText="S.No">
                                                <ItemTemplate>
                                                    <%#((GridViewRow)Container).RowIndex +1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="Enrollment" DataField="ENROLLMENT_NO" />
                                            <asp:BoundField HeaderText="Name" DataField="STU_FULL_NAME" />
                                            <asp:BoundField HeaderText="Institute" DataField="INS_VALUE" />
                                            <asp:BoundField HeaderText="Program" DataField="PGM_FULL_NAME" />
                                            <asp:BoundField HeaderText="Branch" DataField="BRN_FULL_NAME" />
                                            <asp:BoundField HeaderText="Sem" DataField="ACA_SEM_ID" />
                                            <asp:BoundField HeaderText="Registration Date" DataField="REG_DATE" DataFormatString="{0:dd/MM/yyy}" />
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <input id="chkAll" onclick="javascript: SelectAllCheckboxes(this);" type="checkbox"
                                                        value="on" runat="server" />All
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="ChkBox" runat="server" />
                                                </ItemTemplate>
                                                <ItemStyle Width="20px" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnPrint" runat="server" Text="Print" Visible="false" OnClick="btnPrint_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

