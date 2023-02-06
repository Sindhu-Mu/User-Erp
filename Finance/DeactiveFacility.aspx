<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="DeactiveFacility.aspx.cs" Inherits="Finance_DeactiveFacility" %>

<%@ Register Src="~/Control/Student.ascx" TagPrefix="uc1" TagName="Student" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
        function validation() {

            var flag = true;
            var msg = "", ctrl = "";

            if (!CheckControl("<%=ddlSem.ClientID%>")) {
                msg += "- Please Select Semester\n";
                if (ctrl == "")
                    ctrl = "<%=ddlSem.ClientID%>";
                flag = false;
            }

            if (!CheckControl("<%=txtEnroll.ClientID%>")) {
                msg += "- Please Enter Enroll \n";
                if (ctrl == "")
                    ctrl = "<%=txtEnroll.ClientID%>";
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
            <h2>
                DeActive Facility
            </h2>
            </div>
            <table>
                <tr>
                    <td>Sem<span class="required">*</span></td>
                    <td><asp:DropDownList ID="ddlSem" runat="server"></asp:DropDownList></td>
                    <td>Enrollment<span class="required">*</span></td>
                    <td><asp:TextBox ID="txtEnroll" runat="server"></asp:TextBox></td>
                    <td><asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" /></td>
                </tr>
                 <tr>
                    <td>

                        <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" CompletionSetCount="12"
                            EnableCaching="true" MinimumPrefixLength="1" ServiceMethod="GetStudentList"
                            ServicePath="~\AutoComplete.asmx" TargetControlID="txtEnroll" ContextKey="1">
                        </ajaxToolkit:AutoCompleteExtender>
                    </td>
                </tr>
            </table>

             <br/>
            <uc1:Student runat="server" ID="Student" />
            <br/>
            <asp:GridView ID="gvshow" runat="server" AutoGenerateColumns="False" CssClass="gridDynamic" OnRowCommand="gvshow_RowCommand" DataKeyNames="FD_SUB_ID,FEE_MAIN_HEAD_ID,STU_ADM_NO">
                <Columns>
                    <asp:TemplateField HeaderText="S.No">
                        <ItemTemplate>
                            <%#((GridViewRow)Container).RowIndex+1 %>
                        </ItemTemplate>
                        
                    </asp:TemplateField>
                    <asp:BoundField DataField="FEE_MAIN_HEAD_NAME" HeaderText="HEAD" />
                    <asp:BoundField DataField="FD_FEE_AMT" HeaderText="DEMAND AMOUNT" />
                    <asp:BoundField DataField="date" HeaderText="DATE" />
                    <asp:ButtonField CommandName="SHOW" Text="DELETE" ControlStyle-ForeColor="Blue"/>   

                </Columns>
            </asp:GridView>

        </div>

    </div>
</asp:Content>

