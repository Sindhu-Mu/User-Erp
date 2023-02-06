<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="SalarySlip.aspx.cs" Inherits="PayRoll_SalarySlip" %>

<%@ Register Src="~/Control/MonthYear.ascx" TagPrefix="uc1" TagName="MonthYear" %>


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
           function CheckAutoComplete(ctrl) {

               var Value = bTrim(document.getElementById(ctrl).value);
               if (Value.indexOf(":") > 0 && Value.length - 1 != Value.lastIndexOf(":")) {
                   document.getElementById(ctrl).style.backgroundColor = "#fff";
                   return true;
               }
               else
                   document.getElementById(ctrl).style.backgroundColor = "#fc6";
               return false;
           }
           function validat() {
               var flag = true;
               var msg = "", ctrl = "";
               if (!CheckAutoComplete("<%=txtEmp.ClientID%>")) {
                msg += " * Enter Name with Code. \n";
                if (ctrl == "")
                    ctrl = "<%=txtEmp.ClientID%>";
                flag = false;
            }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
           }
             </script>
    <div id="content">
        <div class="heading">
            <h2>Salary Slip</h2>
        </div>
        <div id="contentHeader">
            <table>

                <tr>
                    <th>Month/Year</th>
                    <td>&nbsp;</td>
                    <th>Employee Name & Code</th>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>

                <tr>

                    <td>
                        <uc1:MonthYear runat="server" ID="MonthYear" />
                    </td>
                    <td>&nbsp;</td>
                    <td>
                        <asp:TextBox ID="txtEmp" runat="server" CssClass="textBox" Width="228px" placeholder="Employee Name or Code"></asp:TextBox>
                        <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" CompletionInterval="500"
                            CompletionSetCount="12" ContextKey="0,1,2,3" EnableCaching="true" MinimumPrefixLength="1"
                            ServiceMethod="GetEmployeeList" ServicePath="~\AutoComplete.asmx" TargetControlID="txtEmp">
                        </ajaxToolkit:AutoCompleteExtender>

                    </td>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="btnPrint" runat="server" CssClass="btnBrown" OnClick="btnPrint_Click"
                            Text="Print" Width="60px" /></td>
                </tr>
               
                <tr>
                    <td style="text-align: center">
                        <asp:Label ID="lblMsg" runat="server" Font-Bold="True" ForeColor="Red" />
                    </td>
                </tr>
            </table>
        </div>
        <div id="contentCenter">
            <asp:DataList ID="DataShow" runat="server" BorderStyle="None" Font-Bold="False" CellPadding="0">
                <ItemTemplate>
                    <table  style="width: 100%">
                        <tr>
                            <td style="text-align: center">
                                <table >
                                    <tr>
                                        <td>
                                            <table id="tblPay" runat="server" border="0" cellpadding="0" style="border-collapse: collapse"
                                                width="100%">
                                                <tr>
                                                    <td>&nbsp;</td>
                                                    <td>
                                                        <table border="0" cellpadding="0" style="font-size: 11px; font-family: Tahoma; border-collapse: collapse"
                                                            width="100%">
                                                            <tr>
                                                                <td id="personalInfo" runat="server" align="left" height="20" style="padding-left: 20px; font-size: 11px; font-family: Tahoma"
                                                                    width="50%">
                                                                    <b>Code No :</b> #<asp:Label ID="lblEmplCode" runat="server" CssClass="mactive"></asp:Label><br />
                                                                    <b>Name : </b>
                                                                    <asp:Label ID="lblEmpName" runat="server" CssClass="mactive"></asp:Label><br />
                                                                    <b>Designation :</b>
                                                                    <asp:Label ID="lblDesignation" runat="server" CssClass="mactive"></asp:Label><br />
                                                                    <b>Department :</b>
                                                                    <asp:Label ID="lblDepartment" runat="server" CssClass="mactive"></asp:Label></td>
                                                                <td id="acInfo" runat="server" align="right" height="20" style="padding-right: 20px; font-size: 11px; font-family: Tahoma"
                                                                    width="50%">
                                                                    <b>Days :</b>
                                                                    <asp:Label ID="lblNoOfDays" runat="server" CssClass="mactive"></asp:Label><br />
                                                                    <b>A/C No : </b>
                                                                    <asp:Label ID="lblBanckACNo" runat="server" CssClass="mactive"></asp:Label><br />
                                                                    <b>EPF No :</b>
                                                                    <asp:Label ID="lblEPFNo" runat="server" CssClass="mactive"></asp:Label><br />
                                                                    <b>PAN No :</b>
                                                                    <asp:Label ID="lblPAN" runat="server" CssClass="mactive"></asp:Label></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;</td>
                                                    <td style="padding-right: 20px; padding-left: 20px">
                                                        <hr color="#cc6600" size="1" width="100%" />
                                                    </td>
                                                    <td>
                                                        <strong>&nbsp;</strong></td>
                                                </tr>
                                                <tr style="font-weight: bold">
                                                    <td>&nbsp;</td>
                                                    <td width="800">
                                                        <table border="0" cellpadding="0" style="font-size: 11px; font-family: Tahoma; border-collapse: collapse"
                                                            width="100%">
                                                            <tr>
                                                                <td align="left" height="20" style="padding-left: 20px; font-weight: bold" width="30%">EARNINGS</td>
                                                                <td align="right" height="20" style="padding-right: 20px; font-weight: bold" width="20%">INR</td>
                                                                <td align="left" height="20" style="padding-left: 20px; font-weight: bold" width="30%">DEDUCTIONS</td>
                                                                <td align="right" height="20" style="padding-right: 20px; font-weight: bold" width="20%">INR</td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;</td>
                                                    <td style="padding-right: 20px; padding-left: 20px">
                                                        <hr color="#cc6600" size="1" />
                                                    </td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;</td>
                                                    <td>
                                                        <table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
                                                            <tr>
                                                                <td id="ear" runat="server" valign="top" width="50%">
                                                                    <table border="0" cellpadding="0" style="font-size: 11px; font-family: Tahoma; border-collapse: collapse"
                                                                        width="100%">
                                                                        <tr>
                                                                            <td align="left" height="20" style="padding-left: 20px; font-size: 11px; font-family: Tahoma"
                                                                                width="30%">BASIC SALARY</td>
                                                                            <td align="right" height="20" style="padding-right: 20px; font-size: 11px; font-family: Tahoma"
                                                                                width="20%"></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left" height="20" style="padding-left: 20px; font-size: 11px; font-family: Tahoma"
                                                                                width="30%">DA</td>
                                                                            <td align="right" height="20" style="padding-right: 20px; font-size: 11px; font-family: Tahoma"
                                                                                width="20%"></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left" height="20" style="padding-left: 20px; font-size: 11px; font-family: Tahoma"
                                                                                width="30%">CCA</td>
                                                                            <td align="right" height="20" style="padding-right: 20px; font-size: 11px; font-family: Tahoma"
                                                                                width="20%"></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left" height="20" style="padding-left: 20px; font-size: 11px; font-family: Tahoma"
                                                                                width="30%">SBCA</td>
                                                                            <td align="right" height="20" style="padding-right: 20px; font-size: 11px; font-family: Tahoma"
                                                                                width="20%"></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left" height="20" style="padding-left: 20px; font-size: 11px; font-family: Tahoma"
                                                                                width="30%">HRA</td>
                                                                            <td align="right" height="20" style="padding-right: 20px; font-size: 11px; font-family: Tahoma"
                                                                                width="20%"></td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td id="ded" runat="server" valign="top" width="50%">
                                                                    <table border="0" cellpadding="0" style="font-size: 11px; font-family: Tahoma; border-collapse: collapse"
                                                                        width="100%">
                                                                        <tr>
                                                                            <td align="left" height="20" style="padding-left: 20px; font-size: 11px; font-family: Tahoma"
                                                                                width="30%">PF</td>
                                                                            <td align="right" height="20" style="padding-right: 20px; font-size: 11px; font-family: Tahoma"
                                                                                width="20%"></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left" height="20" style="padding-left: 20px; font-size: 11px; font-family: Tahoma"
                                                                                width="30%">LIC</td>
                                                                            <td align="right" height="20" style="padding-right: 20px; font-size: 11px; font-family: Tahoma"
                                                                                width="20%"></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left" height="20" style="padding-left: 20px; font-size: 11px; font-family: Tahoma"
                                                                                width="30%">&nbsp;</td>
                                                                            <td align="right" height="20" style="padding-right: 20px; font-size: 11px; font-family: Tahoma"
                                                                                width="20%">&nbsp;</td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left" height="20" style="padding-left: 20px; font-size: 11px; font-family: Tahoma"
                                                                                width="30%">&nbsp;</td>
                                                                            <td align="right" height="20" style="padding-right: 20px; font-size: 11px; font-family: Tahoma"
                                                                                width="20%">&nbsp;</td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left" height="20" style="padding-left: 20px; font-size: 11px; font-family: Tahoma"
                                                                                width="30%">&nbsp;</td>
                                                                            <td align="right" height="20" style="padding-right: 20px; font-size: 11px; font-family: Tahoma"
                                                                                width="20%">&nbsp;</td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;</td>
                                                    <td style="padding-right: 20px; padding-left: 20px">
                                                        <hr color="#cc6600" size="1" />
                                                    </td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;</td>
                                                    <td width="800">
                                                        <table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
                                                            <tr>
                                                                <td valign="top" width="50%">
                                                                    <table border="0" cellpadding="0" style="font-size: 11px; font-family: Tahoma; border-collapse: collapse"
                                                                        width="100%">
                                                                        <tr>
                                                                            <td align="left" height="20" style="padding-left: 20px; font-size: 11px; font-family: Tahoma"
                                                                                width="30%">TOTAL EARNINGS [A]</td>
                                                                            <td id="totear" runat="server" align="right" height="20" style="padding-right: 20px; font-size: 11px; font-family: Tahoma"
                                                                                width="20%"></td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td valign="top" width="50%">
                                                                    <table border="0" cellpadding="0" style="font-size: 11px; font-family: Tahoma; border-collapse: collapse"
                                                                        width="100%">
                                                                        <tr>
                                                                            <td align="left" height="20" style="padding-left: 20px; font-size: 11px; font-family: Tahoma"
                                                                                width="30%">TOTAL DEDUCTIONS [B]</td>
                                                                            <td id="totded" runat="server" align="right" height="20" style="padding-right: 20px; font-size: 11px; font-family: Tahoma"
                                                                                width="20%"></td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;</td>
                                                    <td style="padding-right: 20px; padding-left: 20px">
                                                        <hr color="#cc6600" size="1" />
                                                    </td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;</td>
                                                    <td id="netSal" runat="server" style="padding-left: 20px; font-size: 11px; font-family: Tahoma">
                                                        <b>NET PAY (Payroll Clearance) : [A] - [B] = Rs.
                                                            <br />
                                                        </b>transferred to employees A/c with 
                                                        <asp:Label ID="lblBankName" runat="server" CssClass="mactive"></asp:Label></td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;</td>
                                                    <td style="padding-left: 20px; font-size: 11px; font-family: Tahoma">
                                                        <asp:Label ID="lblRemark" runat="server" CssClass="mactive"></asp:Label></td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                        </tr>

                    </table>
                </ItemTemplate>

            </asp:DataList>
        </div>
        <div id="contentFooter">
        </div>

    </div>

</asp:Content>

