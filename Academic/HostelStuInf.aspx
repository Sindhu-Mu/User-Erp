<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="HostelStuInf.aspx.cs" Inherits="Academic_HostelStuInf" %>

<%@ Register Src="~/Control/StuFullProfile.ascx" TagPrefix="uc1" TagName="StuFullProfile" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
        function Allotvalidate() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=ddlCmplx.ClientID%>")) {
                msg += "- Select Complex From List. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlCmplx.ClientID%>";
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
            <h2>Student Information</h2>
        </div>
        <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <th>By Complex<span class="required">*</span></th>
                                        <th>By Floor</th>
                                        <th>By Room</th>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="ddlCmplx" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCmplx_SelectedIndexChanged" Width="200px"></asp:DropDownList></td>
                                        <td>
                                            <asp:DropDownList ID="ddlFloor" runat="server" OnSelectedIndexChanged="ddlFloor_SelectedIndexChanged" AutoPostBack="True" Width="200px"></asp:DropDownList></td>
                                        <td>
                                            <asp:DropDownList ID="ddlRoom" runat="server" Width="200px"></asp:DropDownList></td>
                                        <td>
                                            <asp:Button ID="btnView" runat="server" Text="View" OnClick="btnView_Click" /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="height: 250px; overflow: auto">
                                    <asp:GridView ID="gvStu" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" DataKeyNames="ALLOTED_TO" OnRowCommand="gvStu_RowCommand" EmptyDataText="No Record(s) Found">
                                        <Columns>
                                            <asp:TemplateField HeaderText="S.No">
                                                <ItemTemplate>
                                                    <%#((GridViewRow)Container).RowIndex +1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="Enrollment" DataField="ENROLLMENT_NO" />
                                            <asp:BoundField HeaderText="Name" DataField="STU_FULL_NAME" />
                                            <asp:BoundField HeaderText="Room No" DataField="ROOM_NO" />
                                            <asp:BoundField HeaderText="Course" DataField="PGM_SHORT_NAME" />
                                            <asp:ButtonField ButtonType="Button" CommandName="Detail" Text="Detail" HeaderText="Detail" />
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <div>
                                    <uc1:StuFullProfile runat="server" ID="Student"/>
                                </div>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

