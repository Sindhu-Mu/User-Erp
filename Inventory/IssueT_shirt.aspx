<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="IssueT_shirt.aspx.cs" Inherits="Inventory_IssueT_shirt" %>

<%@ Register Src="~/Control/Student.ascx" TagPrefix="uc1" TagName="Student" %>


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


        function validation() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=ddlsubcat.ClientID%>")) {
                msg += "* Select Sub-Category from List\n";
                if (ctrl == "")
                    ctrl = "<%=ddlsubcat.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlitem.ClientID%>")) {
                msg += "* Select Item from List!!\n";
                if (ctrl == "")
                    ctrl = "<%=ddlitem.ClientID%>";
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
            <h2>Issue T_shirt</h2>

        </div>
        <div>
            <table>
                <tr>
                    <td>
                        <table>
                            <tr>
                                <th>Enrollment No.</th>
                                <th>Form No.</th>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtenroll" runat="server" Width="300px"></asp:TextBox>
                                    <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" CompletionSetCount="12"
                                        EnableCaching="true" MinimumPrefixLength="1" ServiceMethod="GetStudentList"
                                        ServicePath="~\AutoComplete.asmx" TargetControlID="txtenroll" ContextKey="1,2,3,4,5,6">
                                    </ajaxToolkit:AutoCompleteExtender>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtformno" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Button ID="btnshow" runat="server" Text="Show" OnClick="btnshow_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>

                <tr>
                    <td>
                        <uc1:Student runat="server" ID="Student" />
                    </td>
                </tr>
                <tr id="trDetail" runat="server" visible="false">
                    <td>
                        <table>
                            <tr>
                                <th>Sub Category</th>
                                <th>Item</th>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlsubcat" runat="server" AutoPostBack="true" Width="200px" OnSelectedIndexChanged="ddlsubcat_SelectedIndexChanged"></asp:DropDownList></td>
                                <td>
                                    <asp:DropDownList ID="ddlitem" runat="server" AutoPostBack="true" Width="200px"></asp:DropDownList>

                                </td>
                                <td>
                                    <asp:Button ID="btnsubmit" runat="server" Text="Submit" OnClick="btnsubmit_Click" />
                                </td>

                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

