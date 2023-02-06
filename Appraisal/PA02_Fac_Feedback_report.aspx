<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="PA02_Fac_Feedback_report.aspx.cs" Inherits="Appraisal_PA02_Fac_Feedback_report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script lang="javascript" type="text/javascript">
        function CallPrint(strid) {
            var prtContent = document.getElementById(strid);
            var WinPrint = window.open('', '', 'letf=0,top=0,width=800,height=700,toolbar=0,scrollbars=0,status=0,dir=ltr');
            WinPrint.document.write(prtContent.innerHTML);
            WinPrint.document.close();
            WinPrint.focus();
            WinPrint.print();
            WinPrint.close();
            prtContent.innerHTML = strOldOne;
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
        function CheckDate(ctrl) {
            var dt = document.getElementById(ctrl).value;
            if (!isDatecheck(dt, "dd/MM/yyyy")) {
                document.getElementById(ctrl).style.backgroundColor = "#fc6";
                return false;
            }
            else
                document.getElementById(ctrl).style.backgroundColor = "#fff";
            return true;
        }
        function getDate(ctrl, ctrl1) {
            var dd = (compareDateshr(document.getElementById(ctrl).value, "dd/MM/yyyy", document.getElementById(ctrl1).value, "dd/MM/yyyy"));
            if (dd == 1)
                return false;

            return true;
        }
        function validateView() {
            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckAutoComplete("<%=txtEmployee.ClientID%>")) {
                msg += " * Enter Employee Name & Code. \n";
                if (ctrl == "")
                    ctrl = "<%=txtEmployee.ClientID%>";
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
            <h2>Feedback Report</h2>
        </div>

        <table style="margin: 10px 0px 30px 0px">

            <tr>
                <th>BY EMPLOYEE*
                </th>
                <th>BY YEAR
                </th>
                <th>BY SEM
                </th>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtEmployee" runat="server" Width="200px"></asp:TextBox></td>
                <td>
                    <asp:DropDownList ID="ddlYear" runat="server" Width="80px">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="ddlSemType" runat="server" Width="80px">
                        <asp:ListItem Value="0">Even</asp:ListItem>
                        <asp:ListItem Value="1">Odd</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Button ID="btnView" runat="server" Text="View" OnClick="btnView_Click"></asp:Button>
                </td>

            </tr>
            <tr>
                <td>
                    <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionSetCount="12"
                        EnableCaching="true" MinimumPrefixLength="1" ServiceMethod="GetEmployeeList"
                        ServicePath="~\AutoComplete.asmx" TargetControlID="txtEmployee" ContextKey="1,2,3,0">
                    </ajaxToolkit:AutoCompleteExtender>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblMsg" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                </td>
            </tr>
        </table>
        <div style="margin-left: 20px;" id="printDiv1">
            <table id="tblIns" runat="server" style="margin-bottom: 10px">
                <tr>
                    <th style="font: 20px bold;">Feedback :
                        <asp:Label ID="lblyear" runat="server"></asp:Label></th>
                </tr>
                <tr>
                    <th style="text-align: left">Institute:</th>
                    <td colspan="3" style="font: 18px bolder">
                        <b>
                            <asp:Label ID="lblIns" runat="server"></asp:Label></b>
                    </td>
                </tr>
                <tr>
                    <th style="text-align: left">Department:</th>
                    <td colspan="3" style="font: 18px bolder">
                        <b>
                            <asp:Label ID="lblDept" runat="server"></asp:Label></b>
                    </td>
                </tr>
                <tr>
                    <th style="text-align: left">Faculty Name:</th>
                    <td>
                        <b>
                            <asp:Label ID="lblName" runat="server"></asp:Label></b>
                    </td>

                </tr>
                <tr>
                    <th style="text-align: left">Code:</th>
                    <td>
                        <b>
                            <asp:Label ID="lblCode" runat="server"></asp:Label></b>
                    </td>
                </tr>
            </table>
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>

                    <asp:GridView ID="gvShow" runat="server" SelectedRowStyle-BackColor="Yellow" CssClass="gridDynamic" AutoGenerateColumns="False">
                        <Columns>
                            <asp:TemplateField HeaderText="S.No.">
                                <ItemTemplate>
                                    <%# ((GridViewRow)Container).RowIndex + 1%>.
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="PGM_SHORT_NAME" HeaderText="Programme">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="EVA_SCH_PAPER_CODE" HeaderText="Paper Code">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="registered" HeaderText="Registered Students">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Responded" HeaderText="Responded Students">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="MAXIMUM" HeaderText="Max. Score(%) ">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="MINIMUM" HeaderText="Min. Score(%)">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="avg_perc" HeaderText="Avg. Score(%) ">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Status" HeaderText="Remark">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>

                </ContentTemplate>
            </asp:UpdatePanel>


            <div style="margin-top: 20px">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>

                        <asp:GridView ID="gvStuMarking" Width="750px" runat="server" CssClass="gridDynamic" AutoGenerateColumns="False">
                            <Columns>

                                <asp:BoundField DataField="EVA_SCH_PAPER_CODE" HeaderText="PAPER CODE">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Poor" HeaderText="POOR (upto 50%)">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Satisfactory" HeaderText="SATISFACTORY (51-60%)">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Good" HeaderText="GOOD (61-80%)">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Excellent" HeaderText="EXCELLENT (81-100%)">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>

                            </Columns>
                        </asp:GridView>

                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <table id="tableStatus" runat="server" style="border: 1px solid black; border-collapse: collapse; margin-top: 20px;">
                <tr>
                    <th style="border: 1px solid black;"><b>Score(%)</b></th>
                    <td style="border: 1px solid black; text-align: center"><b>Less than 50</b></td>
                    <td style="border: 1px solid black; text-align: center"><b>51-60</b></td>
                    <td style="border: 1px solid black; text-align: center"><b>61-80</b></td>
                    <td style="border: 1px solid black; text-align: center"><b>81 and above</b></td>
                </tr>
                <tr>
                    <th style="border: 1px solid black;">Interpretation</th>

                    <td style="border: 1px solid black; text-align: center">Poor</td>
                    <td style="border: 1px solid black; text-align: center">Satisfactory</td>
                    <td style="border: 1px solid black; text-align: center">Good</td>
                    <td style="border: 1px solid black; text-align: center">Excellent</td>
                </tr>
                <tr>
                    <th style="border: 1px solid black;">Comment</th>
                    <td style="border: 1px solid black; text-align: center">Calls for Immediate Action</td>
                    <td style="border: 1px solid black; text-align: center">Improvement Expected</td>
                    <td style="border: 1px solid black; text-align: center">Try to Excel</td>
                    <td style="border: 1px solid black; text-align: center">Congratulations</td>
                </tr>
            </table>
        </div>
        <table style="margin-left: 15px; margin-top: 10px">
            <tr>
                <td>
                    <asp:Button ID="btnPrint" runat="server" OnClientClick="javascript:CallPrint('printDiv1');" OnClick="btnPrint_Click" Text="Print" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

