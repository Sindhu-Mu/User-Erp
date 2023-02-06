<%@ Page Title="ERP | EMPLOYEE PF MAIN" Language="C#" MasterPageFile="~/MasterPages/Short.master" AutoEventWireup="true" CodeFile="EmpPFMain.aspx.cs" Inherits="HR_EmpPFMain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentHolder1" runat="Server">

    <script language="javascript" type="text/javascript">

        function CheckControl(ctrl) {
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == "Select" || bTrim(document.getElementById(ctrl).value) == ".") {
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
                return false;
            }
            else
                document.getElementById(ctrl).style.backgroundColor = "#fff";
            return true;
        }
        function CheckDate(ctrl) {
            var dt = document.getElementById(ctrl).value;
            if (isDatecheck(dt, "dd/MM/yyyy") == false) {
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
                return false;
            }
            else
                document.getElementById(ctrl).style.backgroundColor = "#fff";
            return true;
        }
        function Employee() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=txtEmpID.ClientID%>")) {
                msg += "-  Enter Employee Name\n";
                if (ctrl == "")
                    ctrl = "<%=txtEmpID.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtAcc2.ClientID%>")) {
                msg += "- Enter Account No.\n";
                if (ctrl == "")
                    ctrl = "<%=txtAcc2.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtJoinDt.ClientID%>")) {
                msg += "- Enter Joining Date\n";
                if (ctrl == "")
                    ctrl = "<%=txtJoinDt.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtPermAdrs.ClientID%>")) {
                msg += "- Enter Address\n";
                if (ctrl == "")
                    ctrl = "<%=txtPermAdrs.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtTempAdrs.ClientID%>")) {
                msg += "- Enter Address\n";
                if (ctrl == "")
                    ctrl = "<%=txtTempAdrs.ClientID%>";
                flag = false;
            }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }

        function Nominee() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=txtNomiName.ClientID%>")) {
                msg += "- Enter Nominee Name\n";
                if (ctrl == "")
                    ctrl = "<%=txtNomiName.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtNomiAdrs.ClientID%>")) {
                msg += "- Enter Nominee Address\n";
                if (ctrl == "")
                    ctrl = "<%=txtNomiAdrs.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtNomiDOB.ClientID%>")) {
                msg += "- Enter Nominee DOB\n";
                if (ctrl == "")
                    ctrl = "<%=txtNomiDOB.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlNomiRelation.ClientID%>")) {
                msg += "- Select Nominee Relation\n";
                if (ctrl == "")
                    ctrl = "<%=ddlNomiRelation.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtNomiBenifit.ClientID%>")) {
                msg += "- Please enter Benifit\n";
                if (ctrl == "")
                    ctrl = "<%=txtNomiBenifit.ClientID%>";
                flag = false;
            }
            if (CheckControl("<%=txtNomiDOB.ClientID%>")) {
                if (!CheckDate("<%=txtNomiDOB.ClientID%>")) {
                    msg += "- Invalid Format of Date.Please Enter in this[dd/MM/yyyy]\n";
                    if (ctrl == "")
                        ctrl = "<%=txtNomiDOB.ClientID%>";
                    flag = false;
                }
            }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }
        function Family() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=txtFmlyName.ClientID%>")) {
                msg += "- Enter Member Name\n";
                if (ctrl == "")
                    ctrl = "<%=txtFmlyName.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtFmlyAdrs.ClientID%>")) {
                msg += "- Enter Member Address\n";
                if (ctrl == "")
                    ctrl = "<%=txtFmlyAdrs.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtFmlyDOB.ClientID%>")) {
                msg += "- Enter Member DOB\n";
                if (ctrl == "")
                    ctrl = "<%=txtFmlyDOB.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlFmlyRelation.ClientID%>")) {
                msg += "- Select Member Relation\n";
                if (ctrl == "")
                    ctrl = "<%=ddlFmlyRelation.ClientID%>";
                flag = false;
            }
            if (CheckControl("<%=txtFmlyDOB.ClientID%>")) {
                if (!CheckDate("<%=txtFmlyDOB.ClientID%>")) {
                    msg += "- Invalid Format of Date.Please Enter in this[dd/MM/yyyy]\n";
                    if (ctrl == "")
                        ctrl = "<%=txtFmlyDOB.ClientID%>";
                    flag = false;
                }
            }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }
        function Nominee2() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=txtNomiName2.ClientID%>")) {
                msg += "- Enter Nominee Name\n";
                if (ctrl == "")
                    ctrl = "<%=txtNomiName2.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtNomiAdrs2.ClientID%>")) {
                msg += "- Enter Nominee Address\n";
                if (ctrl == "")
                    ctrl = "<%=txtNomiAdrs2.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtNomiDOB2.ClientID%>")) {
                msg += "- Enter Nominee DOB\n";
                if (ctrl == "")
                    ctrl = "<%=txtNomiDOB2.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlNomiRelation2.ClientID%>")) {
                msg += "- Select Nominee Relation\n";
                if (ctrl == "")
                    ctrl = "<%=ddlNomiRelation2.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtNomiBenifit2.ClientID%>")) {
                msg += "- Please enter Benifit\n";
                if (ctrl == "")
                    ctrl = "<%=txtNomiBenifit2.ClientID%>";
                flag = false;
            }
            if (CheckControl("<%=txtNomiDOB2.ClientID%>")) {
                if (!CheckDate("<%=txtNomiDOB2.ClientID%>")) {
                    msg += "- Invalid Format of Date.Please Enter in this[dd/MM/yyyy]\n";
                    if (ctrl == "")
                        ctrl = "<%=txtNomiDOB2.ClientID%>";
                    flag = false;
                }
            }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }
        function Family2() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=txtFmlyName2.ClientID%>")) {
                msg += "- Enter Member Name\n";
                if (ctrl == "")
                    ctrl = "<%=txtFmlyName2.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtFmlyAdrs2.ClientID%>")) {
                msg += "- Enter Member Address\n";
                if (ctrl == "")
                    ctrl = "<%=txtFmlyAdrs2.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtFmlyDOB2.ClientID%>")) {
                msg += "- Enter Member DOB\n";
                if (ctrl == "")
                    ctrl = "<%=txtFmlyDOB2.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlFmlyRelation2.ClientID%>")) {
                msg += "- Select Member Relation\n";
                if (ctrl == "")
                    ctrl = "<%=ddlFmlyRelation2.ClientID%>";
                flag = false;
            }
            if (CheckControl("<%=txtFmlyDOB2.ClientID%>")) {
                if (!CheckDate("<%=txtFmlyDOB2.ClientID%>")) {
                    msg += "- Invalid Format of Date.Please Enter in this[dd/MM/yyyy]\n";
                    if (ctrl == "")
                        ctrl = "<%=txtFmlyDOB.ClientID%>";
                    flag = false;
                }
            }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }
        function EmployeeID() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=ddlEmpID.ClientID%>")) {
                msg += "- Select Employee\n";
                if (ctrl == "")
                    ctrl = "<%=ddlEmpID.ClientID%>";
                flag = false;
            }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }
        function EmployeeNew() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=txtEmpID.ClientID%>")) {
                msg += "- Enter Employee\n";
                if (ctrl == "")
                    ctrl = "<%=txtEmpID.ClientID%>";
                flag = false;
            }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }
        function EmployeeEnd() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=ddlEmpIDEnd.ClientID%>")) {
                msg += "- Select Employee\n";
                if (ctrl == "")
                    ctrl = "<%=ddlEmpIDEnd.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtLeftDt.ClientID%>")) {
                msg += "- Enter Left Date\n";
                if (ctrl == "")
                    ctrl = "<%=txtLeftDt.ClientID%>";
                flag = false;
            }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }
    </script>

    <div>
        <table>
            <tr>
                <td>
                    <h2>EMP PF Master</h2>
                </td>
            </tr>
            <tr>
                <td>
                    <table>
                        <tr>
                            <td>
                                <ajaxToolkit:TabContainer ID="tabContainer" runat="server" ActiveTabIndex="1">
                                    <ajaxToolkit:TabPanel runat="server" ID="TabPanel1" HeaderText="New Entry">
                                        <ContentTemplate>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <table>
                                                                        <tr>
                                                                            <th>Employee ID <span style="color: #ff0000">*</span> </th>
                                                                            <td>
                                                                                <asp:TextBox ID="txtEmpID" runat="server"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Button ID="btn" runat="server" CssClass="btnBrown" Text="View" OnClick="btn_Click1" />
                                                                            </td>
                                                                            <td>
                                                                                <table>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txtUpdateLeft" runat="server"></asp:TextBox>
                                                                                        </td>
                                                                                        <td id="Td1" runat="server">
                                                                                            <asp:Button ID="btnActiveAcc" runat="server" Text="Active Left Account" OnClick="btnActiveAcc_Click" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <table id="NewEmployee" runat="server">
                                                                        <tr runat="server">
                                                                            <td runat="server">
                                                                                <table>
                                                                                    <tr>
                                                                                        <th>
                                                                                            <asp:Label ID="Label1" runat="server" Text="DOB: "></asp:Label>
                                                                                            <asp:Label ID="lblEmpDOB" runat="server"></asp:Label>
                                                                                        </th>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <th>
                                                                                            <asp:Label ID="Label3" runat="server" Text="Gender: "></asp:Label>
                                                                                            <asp:Label ID="lblEmpGender" runat="server"></asp:Label>
                                                                                        </th>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <th>
                                                                                            <asp:Label ID="Label5" runat="server" Text="Martial Status: "></asp:Label>
                                                                                            <asp:Label ID="lblEmpMartial" runat="server"></asp:Label>
                                                                                        </th>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <th>
                                                                                            <asp:Label ID="Label7" runat="server" Text="Remark : "></asp:Label></th>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txtRemark" runat="server"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <th>
                                                                                            <asp:Label ID="Label8" runat="server" Text="Father Name : "></asp:Label></th>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txtFather" runat="server"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <th>
                                                                                            <asp:Label ID="Label9" runat="server" Text="Spouse Name : "></asp:Label></th>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txtSpouse" runat="server"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr runat="server">
                                                                            <td runat="server">
                                                                                <table cellpadding="2" cellspacing="0">
                                                                                    <tr>
                                                                                        <th colspan="2">PF Account No. <span style="color: #ff0000">* </span></th>
                                                                                        <th>PF Joining Date <span style="color: #ff0000">* </span></th>
                                                                                        <th>Scheme Type <span style="color: #ff0000">* </span></th>
                                                                                        <th>PF Deduction <span style="color: #ff0000">* </span></th>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txtAcc1" runat="server" ReadOnly="True">UP43601-</asp:TextBox>
                                                                                        </td>
                                                                                        <td>
                                                                                            <cc1:NumericTextBox ID="txtAcc2" runat="server" AllowDecimal="False" AllowNegative="False" DecimalPlaces="-1" MaxLength="5"></cc1:NumericTextBox>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txtJoinDt" runat="server" CssClass="textbox"></asp:TextBox>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:DropDownList ID="ddlScheme" runat="server" Width="150px">
                                                                                            </asp:DropDownList>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:DropDownList ID="ddlDedu" runat="server" Width="105px">
                                                                                            </asp:DropDownList>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                                <table cellpadding="2" cellspacing="0">
                                                                                    <tr>
                                                                                        <th>Permanent Address &nbsp; </th>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txtPermAdrs" runat="server" Width="286px"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <th>Temporary Address &nbsp; </th>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txtTempAdrs" runat="server" Width="287px"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr runat="server">
                                                                            <td runat="server">
                                                                                <table cellpadding="2" cellspacing="0">
                                                                                    <tr>
                                                                                        <th>Family <span style="color: #ff0000">Details </span>
                                                                            <hr style="color: red; width: 100%; height: 0px; border-bottom-color: red; border-bottom-width: 1px; border-collapse: collapse; border-spacing: 0px;" />
                                                                                        </th>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <table>
                                                                                                <tr>
                                                                                                    <th>Member Name <span style="color: #ff0000">*</span> </th>
                                                                                                    <th>Address <span style="color: #ff0000">*</span> </th>
                                                                                                    <th>DOB <span style="color: #ff0000">*</span> </th>
                                                                                                    <th>Relation <span style="color: #ff0000">*</span> </th>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:TextBox ID="txtFmlyName" runat="server"></asp:TextBox>
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <asp:TextBox ID="txtFmlyAdrs" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <asp:TextBox ID="txtFmlyDOB" runat="server"></asp:TextBox>
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <asp:DropDownList ID="ddlFmlyRelation" runat="server" Width="108px">
                                                                                                        </asp:DropDownList>
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <asp:Button ID="btnAddFmly" runat="server" Text="Add" OnClick="btnAddFmly_Click" />
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <caption>
                                                                                        &nbsp;
                                                                                    </caption>
                                                                                </table>
                                                                                <table cellpadding="2" cellspacing="0" style="width: 100%">
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:GridView ID="gvFamily" runat="server" AutoGenerateColumns="False" EmptyDataText="Nothing To Show......" OnRowDeleting="gvFamily_RowDeleting">
                                                                                                <Columns>
                                                                                                    <asp:TemplateField HeaderText="S.No.">
                                                                                                        <ItemTemplate>
                                                                                                            <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                                                        </ItemTemplate>
                                                                                                        <ItemStyle Width="50px" />
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:BoundField DataField="FMLY_MEM_NAME" HeaderText="Member Name" />
                                                                                                    <asp:BoundField DataField="FMLY_MEM_ADRS" HeaderText="Member Address" />
                                                                                                    <asp:BoundField DataField="FMLY_MEM_DOB" HeaderText="DOB" />
                                                                                                    <asp:BoundField DataField="RELATION_NAME" HeaderText="Relation" />
                                                                                                    <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Siteimages/delete.jpg" ShowDeleteButton="True" />
                                                                                                </Columns>
                                                                                            </asp:GridView>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr runat="server">
                                                                            <td runat="server">
                                                                                <table cellpadding="2" cellspacing="0">
                                                                                    <tr>
                                                                                        <th>Nominee <span style="color: #ff0000">Details </span>
                                                                                            <hr color="#ff0000" noshade size="1" />
                                                                                        </th>
                                                                                    </tr>
                                                                                    <caption>
                                                                                        &nbsp;
                                                                    <tr>
                                                                        <td>
                                                                            <table cellpadding="2" cellspacing="0">
                                                                                <tr>
                                                                                    <th>Nominee Name<span style="color: #ff0000">*</span> </th>
                                                                                    <th>Address<span style="color: #ff0000">*</span> </th>
                                                                                    <th>DOB<span style="color: #ff0000">*</span> </th>
                                                                                    <th>Relation<span style="color: #ff0000">*</span> </th>
                                                                                    <th>Benifit(%)<span style="color: #ff0000">*</span> </th>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 160px">
                                                                                        <asp:TextBox ID="txtNomiName" runat="server" CssClass="textbox"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="txtNomiAdrs" runat="server" CssClass="textbox" TextMode="MultiLine"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="txtNomiDOB" runat="server" CssClass="textbox"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddlNomiRelation" runat="server" CssClass="dropdown">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td style="width: 129px">
                                                                                        <cc1:NumericTextBox ID="txtNomiBenifit" runat="server" AllowDecimal="False" AllowNegative="False" CssClass="textbox" DecimalPlaces="-1" Width="84px"></cc1:NumericTextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Button ID="btnAddNomi" runat="server" Text="Add" OnClick="btnAddNomi_Click" />
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>

                                                                    </tr>
                                                                                </table>
                                                                                <table cellpadding="2" cellspacing="0" style="width: 100%">
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:GridView ID="gvNominee" runat="server" AutoGenerateColumns="False" EmptyDataText="Nothing To Show......" OnRowDeleting="gvNominee_RowDeleting">
                                                                                                <Columns>
                                                                                                    <asp:TemplateField HeaderText="S.No.">
                                                                                                        <ItemTemplate>
                                                                                                            <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                                                        </ItemTemplate>
                                                                                                        <ItemStyle Width="50px" />
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:BoundField DataField="NOMI_NAME" HeaderText="Nominee Name" />
                                                                                                    <asp:BoundField DataField="RELATION_NAME" HeaderText="Relation" />
                                                                                                    <asp:BoundField DataField="NOMI_ADRS" HeaderText="Nominee Address" />
                                                                                                    <asp:BoundField DataField="NOMI_DOB" HeaderText="DOB" />
                                                                                                    <asp:BoundField DataField="NOMI_BENIFIT" HeaderText="Benifit" />
                                                                                                    <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Siteimages/delete.jpg" ShowDeleteButton="True" />
                                                                                                </Columns>
                                                                                            </asp:GridView>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <caption>
                                                                                        &nbsp;
                                                                                    </caption>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr runat="server">
                                                                            <td runat="server">
                                                                                <table>
                                                                                    <tr>
                                                                                        <td style="height: 211px">
                                                                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtJoinDt">
                                                                                            </ajaxToolkit:CalendarExtender>
                                                                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender6" runat="server" Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtFmlyDOB">
                                                                                            </ajaxToolkit:CalendarExtender>
                                                                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender7" runat="server" Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtNomiDOB">
                                                                                            </ajaxToolkit:CalendarExtender>
                                                                                            <ajaxToolkit:AutoCompleteExtender ID="autoComplete1" runat="server" CompletionInterval="500" CompletionSetCount="12" ContextKey="1" DelimiterCharacters="" Enabled="True" MinimumPrefixLength="1" ServiceMethod="GetEMPCompletionList" ServicePath="~\AutoComplete.asmx" TargetControlID="txtEmpID" UseContextKey="True">
                                                                                            </ajaxToolkit:AutoCompleteExtender>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txt1" runat="server"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txt2" runat="server"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>

                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </ajaxToolkit:TabPanel>
                                    <ajaxToolkit:TabPanel ID="TabPanel4" runat="server" HeaderText="Update Account Details">
                                        <ContentTemplate>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <table>
                                                            <tr>
                                                                <th>Employee ID</th>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlEmpID" runat="server"></asp:DropDownList></td>
                                                                <td>
                                                                    <asp:Button ID="btnView" runat="server" Text="View" OnClick="btnView_Click" /></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table id="Update" runat="server">
                                                            <tr runat="server">
                                                                <td runat="server">
                                                                    <table>
                                                                        <tr>
                                                                            <th>
                                                                                <asp:Label ID="Label16" runat="server" Text="Remark : "></asp:Label></th>
                                                                            <td>
                                                                                <asp:TextBox ID="txtRemark2" runat="server"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <th>
                                                                                <asp:Label ID="Label17" runat="server" Text="Father Name : "></asp:Label></th>
                                                                            <td>
                                                                                <asp:TextBox ID="txtFather2" runat="server"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <th>
                                                                                <asp:Label ID="Label18" runat="server" Text="Spouse Name : "></asp:Label></th>
                                                                            <td>
                                                                                <asp:TextBox ID="txtSpouse2" runat="server"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr runat="server">
                                                                <td runat="server">
                                                                    <table cellpadding="2" cellspacing="0">
                                                                        <tr>
                                                                            <th colspan="2">PF Account No. <span style="color: #ff0000">* </span></th>
                                                                            <th>PF Joining Date <span style="color: #ff0000">* </span></th>
                                                                            <th>Scheme Type <span style="color: #ff0000">* </span></th>
                                                                            <th>PF Deduction <span style="color: #ff0000">* </span></th>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:TextBox ID="txtAccUpdate1" runat="server" ReadOnly="True">UP43601-</asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <cc1:NumericTextBox ID="txtAccUpdate2" runat="server" AllowDecimal="False" AllowNegative="False" DecimalPlaces="-1" MaxLength="5"></cc1:NumericTextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtJoinDt2" runat="server" CssClass="textbox"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList ID="ddlScheme2" runat="server" Width="150px">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList ID="ddlDedu2" runat="server" Width="105px">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table cellpadding="2" cellspacing="0">
                                                                        <tr>
                                                                            <th>Permanent Address &nbsp; </th>
                                                                            <td>
                                                                                <asp:TextBox ID="txtPermAdrs2" runat="server" Width="286px"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <th>Temporary Address &nbsp; </th>
                                                                            <td>
                                                                                <asp:TextBox ID="txtTempAdrs2" runat="server" Width="287px"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr runat="server">
                                                                <td runat="server">
                                                                    <table cellpadding="2" cellspacing="0">
                                                                        <tr>
                                                                            <th>Family <span style="color: #ff0000">Details </span>
                                                                                <hr color="#ff0000" noshade size="1" />
                                                                            </th>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <table>
                                                                                    <tr>
                                                                                        <th>Member Name <span style="color: #ff0000">*</span> </th>
                                                                                        <th>Address <span style="color: #ff0000">*</span> </th>
                                                                                        <th>DOB <span style="color: #ff0000">*</span> </th>
                                                                                        <th>Relation <span style="color: #ff0000">*</span> </th>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txtFmlyName2" runat="server"></asp:TextBox>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txtFmlyAdrs2" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txtFmlyDOB2" runat="server"></asp:TextBox>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:DropDownList ID="ddlFmlyRelation2" runat="server" Width="108px">
                                                                                            </asp:DropDownList>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Button ID="btnAddFamily2" runat="server" Text="Add" OnClick="btnAddFamily2_Click" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <caption>
                                                                            &nbsp;
                                                                        </caption>
                                                                    </table>
                                                                    <table cellpadding="2" cellspacing="0" style="width: 100%">
                                                                        <tr>
                                                                            <td>
                                                                                <asp:GridView ID="gridFamily" runat="server" AutoGenerateColumns="False" DataKeyNames="FMLY_ID,RELATION_ID" EmptyDataText="Nothing To Show......" OnRowDeleting="gridFamily_RowDeleting" OnRowCancelingEdit="gridFamily_RowCancelingEdit" OnRowEditing="gridFamily_RowEditing" OnRowUpdating="gridFamily_RowUpdating" OnRowDataBound="gridFamily_RowDataBound">
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="S.No.">
                                                                                            <ItemTemplate>
                                                                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle Width="50px" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Member Name">
                                                                                            <EditItemTemplate>
                                                                                                <asp:TextBox ID="txtFmlyName" runat="server" Text='<%# Bind("FMLY_MEM_NAME", "{0:dd/MM/yyyy}") %>'
                                                                                                    Width="80px" CssClass="textbox"></asp:TextBox>
                                                                                            </EditItemTemplate>
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("FMLY_MEM_NAME", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Member Address">
                                                                                            <EditItemTemplate>
                                                                                                <asp:TextBox ID="txtFmlyAdrs" runat="server" Text='<%# Bind("FMLY_MEM_ADRS", "{0:dd/MM/yyyy}") %>'
                                                                                                    Width="80px" CssClass="textbox"></asp:TextBox>
                                                                                            </EditItemTemplate>
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("FMLY_MEM_ADRS", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="DOB">
                                                                                            <EditItemTemplate>
                                                                                                <asp:TextBox ID="txtGridFmlyDOB" runat="server" Text='<%# Bind("FMLY_MEM_DOB", "{0:dd/MM/yyyy}") %>'
                                                                                                    Width="80px" CssClass="textbox"></asp:TextBox>
                                                                                            </EditItemTemplate>
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("FMLY_MEM_DOB", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Relation">
                                                                                            <EditItemTemplate>
                                                                                                <asp:DropDownList ID="ddlGridFmlyRelation" runat="server">
                                                                                                    <asp:ListItem>Select</asp:ListItem>
                                                                                                </asp:DropDownList>
                                                                                                <asp:Label ID="lblRelation" runat="server" Text='<%# Bind("RELATION_ID") %>' Visible="false"></asp:Label>
                                                                                            </EditItemTemplate>
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("RELATION_NAME") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:CommandField ButtonType="Image" CancelImageUrl="~/Siteimages/cancel_icon.gif" EditImageUrl="~/Siteimages/editsmall.gif"
                                                                                            ShowEditButton="True" UpdateImageUrl="~/Siteimages/update_icon.gif" />
                                                                                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Siteimages/delete.jpg" ShowDeleteButton="True" />
                                                                                    </Columns>
                                                                                </asp:GridView>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr runat="server">
                                                                <td runat="server">
                                                                    <table cellpadding="2" cellspacing="0">
                                                                        <tr>
                                                                            <th>Nominee <span style="color: #ff0000">Details </span>
                                                                                <hr color="#ff0000" noshade size="1" />
                                                                            </th>
                                                                        </tr>
                                                                        <caption>
                                                                            &nbsp;
                                                                    <tr>
                                                                        <td>
                                                                            <table cellpadding="2" cellspacing="0">
                                                                                <tr>
                                                                                    <th>Nominee Name<span style="color: #ff0000">*</span> </th>
                                                                                    <th>Address<span style="color: #ff0000">*</span> </th>
                                                                                    <th>DOB<span style="color: #ff0000">*</span> </th>
                                                                                    <th>Relation<span style="color: #ff0000">*</span> </th>
                                                                                    <th>Benifit(%)<span style="color: #ff0000">*</span> </th>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 160px">
                                                                                        <asp:TextBox ID="txtNomiName2" runat="server" CssClass="textbox"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="txtNomiAdrs2" runat="server" CssClass="textbox" TextMode="MultiLine"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="txtNomiDOB2" runat="server" CssClass="textbox"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddlNomiRelation2" runat="server" CssClass="dropdown">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td style="width: 129px">
                                                                                        <cc1:NumericTextBox ID="txtNomiBenifit2" runat="server" AllowDecimal="False" AllowNegative="False" CssClass="textbox" DecimalPlaces="-1" Width="84px"></cc1:NumericTextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Button ID="btnAddNomi2" runat="server" Text="Add" OnClick="btnAddNomi2_Click" />
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                        </caption>
                                                                    </table>
                                                                    <table cellpadding="2" cellspacing="0" style="width: 100%">
                                                                        <tr>
                                                                            <td>
                                                                                <asp:GridView ID="gridNominee" runat="server" DataKeyNames="NOMI_ID" AutoGenerateColumns="False" EmptyDataText="Nothing To Show......" OnRowDeleting="gridNominee_RowDeleting" OnRowCancelingEdit="gridNominee_RowCancelingEdit" OnRowUpdating="gridNominee_RowUpdating" OnRowEditing="gridNominee_RowEditing" OnRowDataBound="gridNominee_RowDataBound">
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="S.No.">
                                                                                            <ItemTemplate>
                                                                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle Width="50px" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Nominee Name">
                                                                                            <EditItemTemplate>
                                                                                                <asp:TextBox ID="txtGridNomiName" runat="server" Text='<%# Bind("NOMI_NAME", "{0:dd/MM/yyyy}") %>'
                                                                                                    Width="80px" CssClass="textbox"></asp:TextBox>
                                                                                            </EditItemTemplate>
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="LabelN" runat="server" Text='<%# Bind("NOMI_NAME", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Relation">
                                                                                            <EditItemTemplate>
                                                                                                <asp:DropDownList ID="ddlGridNomiRelation" runat="server">
                                                                                                    <asp:ListItem>Select</asp:ListItem>
                                                                                                </asp:DropDownList>
                                                                                                <asp:Label ID="lblRelationNom" runat="server" Text='<%# Bind("RELATION_ID") %>' Visible="false"></asp:Label>
                                                                                            </EditItemTemplate>
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="LabelR" runat="server" Text='<%# Bind("RELATION_NAME", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Nominee Address">
                                                                                            <EditItemTemplate>
                                                                                                <asp:TextBox ID="txtGridNomiAdrs" runat="server" Text='<%# Bind("NOMI_ADRS", "{0:dd/MM/yyyy}") %>'
                                                                                                    Width="80px" CssClass="textbox"></asp:TextBox>
                                                                                            </EditItemTemplate>
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="LabelA" runat="server" Text='<%# Bind("NOMI_ADRS", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="DOB">
                                                                                            <EditItemTemplate>
                                                                                                <asp:TextBox ID="txtGridNomiDOB" runat="server" Text='<%# Bind("NOMI_DOB", "{0:dd/MM/yyyy}") %>'
                                                                                                    Width="80px" CssClass="textbox"></asp:TextBox>
                                                                                            </EditItemTemplate>
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="LabelD" runat="server" Text='<%# Bind("NOMI_DOB", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Benifit">
                                                                                            <EditItemTemplate>
                                                                                                <asp:TextBox ID="txtGridNomiBenifit" runat="server" Text='<%# Bind("NOMI_BENIFIT") %>'
                                                                                                    Width="80px" CssClass="textbox"></asp:TextBox>
                                                                                            </EditItemTemplate>
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="LabelB" runat="server" Text='<%# Bind("NOMI_BENIFIT") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:CommandField ButtonType="Image" CancelImageUrl="~/Siteimages/cancel_icon.gif" EditImageUrl="~/Siteimages/editsmall.gif"
                                                                                            ShowEditButton="True" UpdateImageUrl="~/Siteimages/update_icon.gif" />
                                                                                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Siteimages/delete.jpg" ShowDeleteButton="True" />
                                                                                    </Columns>
                                                                                </asp:GridView>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table>
                                                            <tr>
                                                                <td style="height: 211px">
                                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender5" runat="server" Format="dd/MM/yyyy"
                                                                        TargetControlID="txtJoinDt2">
                                                                    </ajaxToolkit:CalendarExtender>
                                                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" Mask="99/99/9999"
                                                                        MaskType="Date" TargetControlID="txtJoinDt2">
                                                                    </ajaxToolkit:MaskedEditExtender>
                                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender9" runat="server" Format="dd/MM/yyyy"
                                                                        TargetControlID="txtFmlyDOB2">
                                                                    </ajaxToolkit:CalendarExtender>
                                                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender3" runat="server" Mask="99/99/9999"
                                                                        MaskType="Date" TargetControlID="txtFmlyDOB2">
                                                                    </ajaxToolkit:MaskedEditExtender>
                                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender10" runat="server" Format="dd/MM/yyyy"
                                                                        TargetControlID="txtNomiDOB2">
                                                                    </ajaxToolkit:CalendarExtender>
                                                                    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender4" runat="server" Mask="99/99/9999"
                                                                        MaskType="Date" TargetControlID="txtNomiDOB2">
                                                                    </ajaxToolkit:MaskedEditExtender>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </ajaxToolkit:TabPanel>
                                    <ajaxToolkit:TabPanel ID="TabPanel5" runat="server" HeaderText="End Account">
                                        <ContentTemplate>
                                            <table cellpadding="2" cellspacing="0">
                                                <tr>
                                                    <th style="width: 138px">Employee ID<span style="color: #ff0000">*</span>
                                                    </th>
                                                    <th>EMP PF End Date<span style="color: #ff0000">*</span>
                                                    </th>
                                                </tr>
                                                <tr>
                                                    <td style="width: 138px">
                                                        <asp:DropDownList ID="ddlEmpIDEnd" runat="server">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtLeftDt" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btnEnd" runat="server" Text="End Account" OnClick="btnEnd_Click" />
                                                    </td>
                                                </tr>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender8" runat="server" Format="dd/MM/yyyy"
                                                    TargetControlID="txtLeftDt">
                                                </ajaxToolkit:CalendarExtender>
                                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="99/99/9999"
                                                    MaskType="Date" TargetControlID="txtLeftDt">
                                                </ajaxToolkit:MaskedEditExtender>
                                            </table>
                                        </ContentTemplate>
                                    </ajaxToolkit:TabPanel>
                                </ajaxToolkit:TabContainer>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

