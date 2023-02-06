<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="BookRequisition.aspx.cs" Inherits="Facility_BookRequisition" %>

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
            if (!CheckControl("<%=txtTitle.ClientID%>")) {
                msg += "- Enter Book Title \n";
                if (ctrl == "")
                    ctrl = "<%=txtTitle.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtAuNme.ClientID%>")) {
                msg += "- Enter Author Name.\n";
                if (ctrl == "")
                    ctrl = "<%=txtAuNme.ClientID%>";
                flag = false;
            }

            if (!CheckControl("<%=txtNOPubliser.ClientID%>")) {
                msg += "- Enter Publisher Name. \n";
                if (ctrl == "")
                    ctrl = "<%=txtNOPubliser.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtCopiesRe.ClientID%>")) {
                msg += "- Enter No of Copies Required. \n";
                if (ctrl == "")
                    ctrl = "<%=txtCopiesRe.ClientID%>";
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
            <h2>Book Requisition</h2>
        </div>
        <div style="width: 100%;">
            <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" AutoPostBack="true" ActiveTabIndex="0" CssClass="fancy fancy-green">
                <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="New Requisition">
                    <ContentTemplate>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <div style="width: 100%;">
                                    <table style="width: 100%;">
                                        <tr>
                                            <th>Title<span class="required">*</span></th>
                                            <td colspan="3">
                                                <asp:TextBox ID="txtTitle" runat="server" Width="92%"></asp:TextBox></td>
                                             </tr>
                                        <tr>
                                            <th>Edition</th>
                                            <td colspan="3">
                                                <asp:TextBox ID="txtEdition" runat="server" Width="92%"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <th>Author Name<span class="required">*</span></th>
                                            <td colspan="3">
                                                <asp:TextBox ID="txtAuNme" runat="server" Width="92%"></asp:TextBox></td>
                                        </tr>

                                        <tr>
                                            <th>Name Of Publisher<span class="required">*</span></th>
                                            <td colspan="3">
                                                <asp:TextBox ID="txtNOPubliser" runat="server" Width="92%"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <th>No. of Copies<br />
                                                (Approximate)<span class="required">*</span></th>
                                            <td>
                                                <cc1:NumericTextBox ID="txtCopiesRe" runat="server"></cc1:NumericTextBox></td>
                                            <th>No of Students</th>
                                            <td>
                                                <cc1:NumericTextBox ID="txtNOStu" runat="server"></cc1:NumericTextBox></td>


                                        </tr>
                                        <tr>
                                            <th>Price<br />
                                                (Approximate per unit)</th>
                                            <td>
                                                <cc1:NumericTextBox ID="txtPrice" runat="server"></cc1:NumericTextBox></td>
                                            <th>I.S.B.N no</th>
                                            <td>
                                                <asp:TextBox ID="txtISBN" runat="server"></asp:TextBox></td>
                                        </tr>


                                        <tr>
                                            <th>Remark</th>
                                            <td colspan="3">
                                                <asp:TextBox ID="txtRemark" runat="server" TextMode="MultiLine" Width="92%"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right;" colspan="4">
                                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" /></td>
                                        </tr>
                                    </table>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="Previous Requisition">
                    <ContentTemplate>
                        <div style="width: 100%;">
                            <asp:GridView ID="grdBookReq" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No">
                                        <ItemTemplate>
                                            <%# ((GridViewRow)Container).RowIndex + 1 %>
                                        </ItemTemplate>
                                        <ItemStyle Width="20px" />
                                    </asp:TemplateField>                              
                                    <asp:BoundField HeaderText="Book Title" DataField="BOOK_TITLE" />
                                    <asp:BoundField HeaderText="Book Edition" DataField="BOOK_EDITION" />
                                    <asp:BoundField HeaderText="Author" DataField="BOOK_AUTHOR_NAME" />
                                    <asp:BoundField HeaderText="Publisher" DataField="BOOK_PUBLISHER" />
                                    <asp:BoundField HeaderText="Price" DataField="BOOK_PRICE" />
                                    <asp:BoundField HeaderText="Quantity" DataField="BOOK_NOC" />
                                    <asp:BoundField HeaderText="I.S.B.N" DataField="BOOK_ISBN_NO" />                                   
                                    <asp:BoundField HeaderText="Registration Date" DataField="BOOK_TRAN_DT" DataFormatString="{0:dd/MM/yyyy}" />
                                    <asp:BoundField HeaderText="Status" DataField="STS_VALUE" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
            </ajaxToolkit:TabContainer>
        </div>
    </div>
</asp:Content>

