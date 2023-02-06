<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="IssueTracking.aspx.cs" Inherits="Facility_IssueTracking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
              <style type="text/css">
        .fancy-green .ajax__tab_header {
            background: url(../Siteimages/green_bg_Tab.gif) repeat-x;
            cursor: pointer;
        }

        .fancy-green .ajax__tab_hover .ajax__tab_outer, .fancy-green .ajax__tab_active .ajax__tab_outer {
            background: url(../Siteimages/green_left_Tab.gif) no-repeat left top;
        }

        .fancy-green .ajax__tab_hover .ajax__tab_inner, .fancy-green .ajax__tab_active .ajax__tab_inner {
            background: url(../Siteimages/green_right_Tab.gif) no-repeat right top;
        }

        .fancy .ajax__tab_header {
            font-size: 13px;
            font-weight: bold;
            color: #000;
            font-family: sans-serif;
        }

            .fancy .ajax__tab_active .ajax__tab_outer, .fancy .ajax__tab_header .ajax__tab_outer, .fancy .ajax__tab_hover .ajax__tab_outer {
                height: 46px;
            }

            .fancy .ajax__tab_active .ajax__tab_inner, .fancy .ajax__tab_header .ajax__tab_inner, .fancy .ajax__tab_hover .ajax__tab_inner {
                height: 46px;
                margin-left: 16px; /* offset the width of the left image */
            }

            .fancy .ajax__tab_active .ajax__tab_tab, .fancy .ajax__tab_hover .ajax__tab_tab, .fancy .ajax__tab_header .ajax__tab_tab {
                margin: 16px 16px 0px 0px;
            }

        .fancy .ajax__tab_hover .ajax__tab_tab, .fancy .ajax__tab_active .ajax__tab_tab {
            color: #fff;
        }

        .fancy .ajax__tab_body {
            font-family: Arial;
            font-size: 10pt;
            border-top: 0;
            border: 1px solid #999999;
            padding: 8px;
            background-color: #ffffff;
        }
    </style>
        <script lang="javascript" type="text/javascript">
            function CheckControl(ctrl) {
                if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == "." || bTrim(document.getElementById(ctrl).value) == "Select") {
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
                 if (!CheckControl("<%=ddlCmplx.ClientID%>")) {
                msg += "- Select Complex from the List.\n";
                if (ctrl == "")
                    ctrl = "<%=ddlCmplx.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtLocation.ClientID%>")) {
                msg += "- Enter Issue Location.\n";
                if (ctrl == "")
                    ctrl = "<%=txtLocation.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlIssueRelated.ClientID%>")) {
                msg += "- Select Issue Related to.\n";
                if (ctrl == "")
                    ctrl = "<%=ddlIssueRelated.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlIssueAbout.ClientID%>")) {
                msg += "- EnterIssue About.\n";
                if (ctrl == "")
                    ctrl = "<%=ddlIssueAbout.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=ddlIssueDept.ClientID%>")) {
                msg += "- Select Issue Department.\n";
                if (ctrl == "")
                    ctrl = "<%=ddlIssueDept.ClientID%>";
                flag = false;
            }
                if (!CheckControl("<%=txtIssueDetail.ClientID%>")) {
                    msg += "- Enter Issue Detail.\n";
                    if (ctrl == "")
                        ctrl = "<%=txtIssueDetail.ClientID%>";
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
            <h2>Issue Tracking System</h2>
        </div>
        <table>
            <tr>
                <td>
                    <ajaxToolkit:TabContainer ID="TabCont1" runat="server" ActiveTabIndex="0" AutoPostBack="true" CssClass="fancy fancy-green">
                        <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="New Issue">
                            <ContentTemplate>
                                <asp:UpdatePanel ID="Updatepanel1" runat="server">
                                    <ContentTemplate>
                                        <table>
                                            <tr>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <th>Complex<span class="required">*</span>
                                                            </th>
                                                            <td>
                                                                <asp:DropDownList ID="ddlCmplx" runat="server" AutoPostBack="true"></asp:DropDownList>

                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <th>Location<span class="required">*</span></th>
                                                            <td>
                                                                <asp:TextBox ID="txtLocation" runat="server" Width="200px"></asp:TextBox>

                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <th>Isuue Related to<span class="required">*</span></th>
                                                            <td>
                                                                <asp:DropDownList ID="ddlIssueRelated" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlIssueRelated_SelectedIndexChanged"></asp:DropDownList>

                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <th>Issue About<span class="required">*</span></th>
                                                            <td>
                                                                <asp:DropDownList ID="ddlIssueAbout" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlIssueAbout_SelectedIndexChanged"></asp:DropDownList>

                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <th>Issue Department<span class="required">*</span></th>
                                                            <td>
                                                                <asp:DropDownList ID="ddlIssueDept" runat="server" AutoPostBack="True"></asp:DropDownList>

                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <th>Issue Details<span class="required">*</span></th>
                                                            <td>
                                                                <asp:TextBox ID="txtIssueDetail" runat="server" TextMode="MultiLine" Width="500px" Height="80px"></asp:TextBox>

                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                                                            </td>
                                                            </tr>
                                                    </table>
                                                </td>
                                                <td id="tbIssueCount" runat="server" style="vertical-align: top;">
                                                    <table>
                                                        <tr>
                                                            <td style="color:#0026ff"><b>Department Issue Count</b>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <th>
                                                               Solved: <br />
                                                                <asp:Label ID="lblSolved" runat="server" ForeColor="#ff0000"></asp:Label>
                                                            </th>
                                                        </tr>
                                                        <tr>
                                                            <th>Pending: <br />
                                                                <asp:Label ID="lblPending" runat="server" ForeColor="#ff0000"></asp:Label></th>
                                                            </tr>
                                                        <tr>
                                                            <th>
                                                                In Process: <br />
                                                                <asp:Label ID="lblProces" runat="server" ForeColor="#ff0000"></asp:Label></th>
                                                        </tr>
                                                        <tr>
                                                             <th>
                                                                Total: <br />
                                                                <asp:Label ID="lblTotal" runat="server" ForeColor="#ff0000"></asp:Label></th>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </ContentTemplate>
                        </ajaxToolkit:TabPanel>
                        <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="Previous Issues">
                            <ContentTemplate>
                                <table>
                                    <tr>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:Repeater ID="RepIssueDetail" runat="server" OnItemCommand="RepIssueDetail_ItemCommand">
                                                            <ItemTemplate>
                                                                <table>
                                                                    <tr>
                                                                        <td align="right" style="color: green" valign="top">
                                                                            <b>Token No</b>

                                                                        </td>
                                                                        <td align="center" style="width: 12px" valign="top">
                                                                            <b>:</b>

                                                                        </td>
                                                                        <td valign="top">#<%# Eval("ISSUE_TOKEN_NO")%><span style="color: green"><b>Raised on :</b></span>
                                                                            <%# Eval("ISSUE_DT") %>

                                                                        </td>
                                                                    </tr>
                                                                    <tr style="padding-top: 3px">
                                                                        <td align="right" style="width: 122px" valign="top">
                                                                            <span style="color: green"><b>Complain </b></span>
                                                                        </td>
                                                                        <td align="center" style="width: 12px" valign="top">
                                                                            <b>:</b>

                                                                        </td>
                                                                        <td valign="top">
                                                                            <%# Eval("ISSUE_DETAIL") %>
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="padding-top: 3px">
                                                                        <td align="right" style="width: 122px" valign="top">
                                                                            <span style="color: green"><b>Complain Area </b></span>
                                                                        </td>
                                                                        <td align="center" style="width: 12px" valign="top">
                                                                            <b>:</b>

                                                                        </td>
                                                                        <td valign="top">
                                                                            <%# Eval("SUB_HEAD_VALUE") %>
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="padding-top: 3px">
                                                                        <td align="right" style="width: 122px" valign="top">
                                                                            <span style="color: green"><b>Solution Provider</b></span>
                                                                        </td>
                                                                        <td align="center" style="width: 12px" valign="top">
                                                                            <b>:</b>

                                                                        </td>
                                                                        <td valign="top">
                                                                            <%# Eval("DEPT_VALUE") %>
                                                                        </td>
                                                                        </tr>
                                                                    <tr style="padding-top: 3px">
                                                                        <td align="right" style="width: 122px" valign="top">
                                                                            <span style="color: green"><b>Status </b></span>
                                                                        </td>
                                                                        <td align="center" style="width: 12px" valign="top">
                                                                            <b>:</b>

                                                                        </td>
                                                                        <td valign="top">
                                                                            <%# Eval("ISSUE_STS_VALUE") %>
                                                                        </td>
                                                                        <td>
                                                                            <table cellpadding="0" cellspacing="0" style="width: 100%">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:LinkButton ID="CmdViewSol" runat="server" Font-Bold="True" CommandName="View"
                                                                                            CommandArgument='<%# Bind("ISSUE_ID") %>'>View Solutions</asp:LinkButton>
                                                                                        &nbsp;|
                                                                            <asp:LinkButton ID="CmdEdit" runat="server" Font-Bold="True" CommandName="Edit"
                                                                                CommandArgument='<%# Bind("ISSUE_ID") %>'>Edit</asp:LinkButton>
                                                                                        &nbsp;|
                                                                            <asp:LinkButton ID="CmdDelete" runat="server" Font-Bold="True" CommandName="Delete"
                                                                                CommandArgument='<%# Bind("ISSUE_ID") %>'>Delete</asp:LinkButton>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="padding-bottom: 3px">
                                                                        <td align="right" colspan="4" valign="top">
                                                                            <hr color="#ff0000" noshade="noshade" size="1" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </ajaxToolkit:TabPanel>
                    </ajaxToolkit:TabContainer>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

