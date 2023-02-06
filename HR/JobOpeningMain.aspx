<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="JobOpeningMain.aspx.cs" Inherits="HR_OpeningMain" %>

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

            if (!CheckControl("<%=ddlIns.ClientID%>")) {
                msg += " * Select Institute \n";
                if (ctrl == "")
                    ctrl = "<%=ddlIns.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlDept.ClientID%>")) {
                msg += " * Select Department \n";
                if (ctrl == "")
                    ctrl = "<%=ddlDept.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlDes.ClientID%>")) {
                msg += " * Select Designation \n";
                if (ctrl == "")
                    ctrl = "<%=ddlDes.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlQual.ClientID%>")) {
                msg += " * Select Qualification \n";
                if (ctrl == "")
                    ctrl = "<%=ddlQual.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtMin.ClientID%>")) {
                msg += " * Enter Min. Salary\n";
                if (ctrl == "")
                    ctrl = "<%=txtMin.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtMax.ClientID%>")) {
                msg += " * Enter Max. Salary \n";
                if (ctrl == "")
                    ctrl = "<%=txtMax.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtTotal.ClientID%>")) {
                msg += " * Enter No. Of Vacancies \n";
                if (ctrl == "")
                    ctrl = "<%=txtTotal.ClientID%>";
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
            <h2>Opening Main</h2>
        </div>
        <div>
            <table>
                <tr>
                    <td>
                        <table>


                            <tr>
                                <th>Institution<span class="required">*</span>
                                </th>
                                <th>Department<span class="required">*</span>
                                </th>
                                <th>Designation<span class="required">*</span>
                                </th>
                                <th>Min. Qualification<span class="required">*</span>
                                </th>

                            </tr>

                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlIns" runat="server" OnSelectedIndexChanged="ddlIns_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlDept" runat="server" Width="150px"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlDes" runat="server" Width="150px"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlQual" runat="server"></asp:DropDownList>
                                </td>

                            </tr>
                            <tr>
                                <th>No.Of Vacancies<span class="required">*</span>
                                </th>

                                <th>Min.CTC<span class="required">*</span>
                                </th>
                                <th>Max.CTC<span class="required">*</span>
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <cc1:NumericTextBox ID="txtTotal" runat="server" AllowDecimal="false" AllowNegative="false" Width="40px"></cc1:NumericTextBox>
                                </td>
                                <td>
                                    <cc1:NumericTextBox ID="txtMin" runat="server" AllowDecimal="true" AllowNegative="false" DecimalPlaces="2" Width="70px"></cc1:NumericTextBox>
                                </td>
                                <td>
                                    <cc1:NumericTextBox ID="txtMax" runat="server" AllowDecimal="true" AllowNegative="false" DecimalPlaces="2" Width="70px"></cc1:NumericTextBox>
                                </td>
                                <td>
                                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div>
                            <asp:GridView ID="gvDetail" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" OnRowCommand="gvDetail_RowCommand">
                                <Columns>
                                    <asp:TemplateField HeaderText="S#">
                                        <ItemTemplate>
                                            <%# ((GridViewRow )Container).RowIndex+1 %>.
                                        </ItemTemplate>
                                        <ItemStyle Width="15px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="JOB_NO" HeaderText="Job No."/>
                                    <asp:BoundField DataField="DES_VALUE" HeaderText="Designation" />
                                    <asp:BoundField DataField="DEPT_VALUE" HeaderText="Dept." ItemStyle-Width="30px" />
                                    <asp:BoundField DataField="ACA_BASE_FULL_NAME" HeaderText="Min.Qualification" ItemStyle-Width="30px" />
                                    <asp:BoundField DataField="VACANCY" HeaderText="Vacancies" ItemStyle-Width="30px" />
                                    <asp:BoundField DataField="SELECTED" HeaderText="Selected" ItemStyle-Width="30px" />
                                    <asp:BoundField DataField="JOINED" HeaderText="Joined" ItemStyle-Width="30px" />
                                    <asp:BoundField DataField="SALARY" HeaderText="Salary-Range" />
                                    <asp:BoundField DataField="IN_DATE" HeaderText="In Date" DataFormatString="{0:dd/MM/yyy}" />
                                    <asp:TemplateField ShowHeader="False" HeaderText="Status">
                                        <ItemStyle Width="20px" HorizontalAlign="Right" />
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgAct" runat="server" CausesValidation="false" CommandArgument='<%# Bind("JOB_ID") %>'
                                                ImageUrl='<%# Bind("STS_IMG") %>' CommandName='<%# Bind("STS_CMD") %>' ToolTip='<%# Bind("STS_TOOLTIP")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </td>
                </tr>
            </table>


        </div>
    </div>
</asp:Content>

