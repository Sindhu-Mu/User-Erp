<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="NewJoining.aspx.cs" Inherits="Common_NewJoining" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <style type="text/css">
        .emp-card {
            min-width: 300px;
            min-height: 215px;
            max-width: 300px;
            max-height: 215px;
            margin: 5px;
            background-color: #fff;
            border: #003 solid 5px;
        }

            .emp-card hr {
                margin: 0px 0px 0px 0px;
            }

        .emp-name {
            min-height: 20px;
            background-color: #003;
            color: #FFF;
            padding: 5px;
        }

        .emp-prof {
            float: left;
            min-height: 100px;
            max-height: 100px;
            min-width: 180px;
            max-width: 180px;
        }

        .emp-img {
            min-height: 100px;
            max-height: 100px;
            margin-left: 200px;
            width: 90px;
        }

        .emp-contact {
            margin-top: 5px;
            min-height: 60px;
            max-height: 60px;
            font-size: 10px;
            border-top: 1px solid #CCC;
        }

        .emp-info {
            padding: 5px;
            background-color: #fff;
        }
    </style>

    <div class="container">
        <div class="heading">
            <h2>New Joining</h2>
        </div>
        <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td>
                                <asp:DataList ID="Repeater1" runat="server" RepeatColumns="2"
                                    RepeatDirection="Horizontal">
                                    <ItemTemplate>
                                        <div class="emp-card">
                                            <div class="emp-name"><%# Eval("EMP_NAME") %> (<%# Eval("EMP_MUID") %>)</div>
                                            <hr />
                                            <div class="emp-info">
                                                <div class="emp-prof">
                                                    <%# Eval("DES_VALUE") %><br />
                                                    <%# Eval("DEPT_VALUE") %><br />
                                                    <%# Eval("INS_VALUE") %>
                                                </div>
                                                <div class="emp-img">
                                                    <img src="<%# Eval("IMG") %>" style="height: 100px; width: 90px" alt="" />
                                                </div>
                                                <div class="emp-contact">
                                                    Phone :<%# Eval("MOBILE_OFF") %><%# Eval("MOBILE_RES") %><br />Email : <%# Eval("EMAIL") %><br />

                                                    <%# Eval("ADDRESS") %>
                                                    <br />
                                                </div>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:DataList>
                            </td>
                        </tr>

                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

