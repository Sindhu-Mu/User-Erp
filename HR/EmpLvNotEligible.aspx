<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Short.master" AutoEventWireup="true" CodeFile="EmpLvNotEligible.aspx.cs" Inherits="HR_EmpLvNotEligible" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentHolder1" runat="Server">
     <script language="javascript" type="text/javascript">
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
         function validation() {
             var flag = true;
             var msg = "", ctrl = "";
             if (!CheckDate("<%=txtToDate.ClientID%>")) {
                 msg += " * Enter Correct Date.  \n";
                 if (ctrl == "")
                     ctrl = "<%=txtToDate.ClientID%>";
                    flag = false;
             }
             if (!CheckDate("<%=txtFrmDate.ClientID%>")) {
                if (!CheckControl("<%=txtFrmDate.ClientID%>")) {
                    msg += " * Enter Holiday. \n";
                    if (ctrl == "")
                        ctrl = "<%=txtFrmDate.ClientID%>";
                    flag = false;
                }
                else {
                    msg += " * Enter Correct Date.  \n";
                    if (ctrl == "")
                        ctrl = "<%=txtFrmDate.ClientID%>";
                   flag = false;
               }
           }
           if (!CheckControl("<%=txtRemark.ClientID%>")) {
                msg += " * Enter Description \n";
                if (ctrl == "")
                    ctrl = "<%=txtRemark.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtEmp.ClientID%>")) {
                msg += " * Enter Employee name & code. \n";
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
    <div>
        <div class="heading">
            <h2>Employee Leave Not Eligible</h2>
        </div>
        <table>
            <tr>
                <td>
                    <table>
                        <tr>
                            <th>Employee name<span style="color: red">*</span></th>
                            <th>From Date<span style="color: red">*</span></th>
                            <th>To Date<span style="color: red">*</span></th>
                            <th>Remark<span style="color: red">*</span></th>

                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtEmp" runat="server"></asp:TextBox>
                                <ajaxToolkit:AutoCompleteExtender ID="autoComplete1" runat="server" CompletionInterval="500"
                                    CompletionSetCount="12" ContextKey="1" EnableCaching="true" MinimumPrefixLength="1"
                                    ServiceMethod="GetEMPCompletionList" ServicePath="~\AutoComplete.asmx" TargetControlID="txtEmp">
                                </ajaxToolkit:AutoCompleteExtender>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFrmDate" runat="server"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="txtFrmDate"></ajaxToolkit:CalendarExtender>
                            </td>
                            <td><asp:TextBox ID="txtToDate" runat="server"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" runat="server" TargetControlID="txtToDate"></ajaxToolkit:CalendarExtender></td>
                            <td>
                                <asp:TextBox ID="txtRemark" runat="server"></asp:TextBox></td>

                            <td>
                                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr style="padding-top: 10px">
                <td>
                    <asp:GridView ID="gvShow" runat="server" AutoGenerateColumns="false" OnRowCommand="gvShow_RowCommand" EmptyDataText="No record found.">
                        <Columns>
                            <asp:TemplateField HeaderText="S.No.">
                                <ItemTemplate><%#((GridViewRow)Container).RowIndex+1 %></ItemTemplate>
                                <ItemStyle Width="15px" />
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Employee Code" DataField="EMP_ID" />
                            <asp:BoundField HeaderText="Employee Name" DataField="EMP_NAME" />
                            <%--<asp:BoundField HeaderText="Department" DataField="DEPT_ID" />--%>
                            <asp:BoundField HeaderText="From Date" DataField="FROM_DT" />
                            <asp:BoundField HeaderText="To Date" DataField="TO_DT" />
                            <asp:BoundField HeaderText="Remark" DataField="REMARK" />
                            <asp:TemplateField ShowHeader="false" HeaderText="Status">
                                <ItemStyle Width="20px" HorizontalAlign="Right" />
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgStatus" runat="server" CausesValidation="false" CommandArgument='<%# Bind("ID") %>' ImageUrl="~/Siteimages/activate.gif" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <br />
                    <br />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

