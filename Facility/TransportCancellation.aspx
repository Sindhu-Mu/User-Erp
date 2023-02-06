<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="TransportCancellation.aspx.cs" Inherits="Facility_TransportCancellation" %>

<%@ Register Src="~/Control/Student.ascx" TagPrefix="uc1" TagName="Student" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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

        function validateShow() {
            var flag = true;
            var msg = "", ctrl = "";

            if (!CheckControl("<%=txtStudent.ClientID%>")) {
                msg += " * Enter Enrollment \n";
                if (ctrl == "")
                    ctrl = "<%=txtStudent.ClientID%>";
                 flag = false;
             }

             if (!CheckControl("<%=ddlSem.ClientID%>")) {
                msg += "- Select Semester. \n";
                if (ctrl == "")
                    ctrl = "<%=ddlSem.ClientID%>";
                 flag = false;
             }

             if (msg != "") alert(msg);
             if (ctrl != "")
                 document.getElementById(ctrl).focus();
             return flag;
         }

         function validateView() {
             var flag = true;
             var msg = "", ctrl = "";

             if (!CheckControl("<%=txtStudent.ClientID%>")) {
                 msg += " * Enter Enrollment \n";
                 if (ctrl == "")
                     ctrl = "<%=txtStudent.ClientID%>";
                 flag = false;
             }

             if (!CheckControl("<%=ddlSem.ClientID%>")) {
                 msg += "- Select Semester. \n";
                 if (ctrl == "")
                     ctrl = "<%=ddlSem.ClientID%>";
                 flag = false;
             }
             if (!CheckControl("<%=txtRemark.ClientID%>")) {
                 msg += " * Enter Remark \n";
                 if (ctrl == "")
                     ctrl = "<%=txtRemark.ClientID%>";
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
            <h2>Transport Cancellation
            </h2>
        </div>
        <div>
            <table>
                <tr>
                    <td style="padding-left: 400px">
                        <table>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtStudent" Width="264px" runat="server"></asp:TextBox>
                                </td>
                                <th>Semseter:
                                </th>
                                <td>
                                    <asp:DropDownList ID="ddlSem" runat="server"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" />
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
                <tr>
                    <td>
                        <asp:GridView ID="gvDetail" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" DataKeyNames="REG_ROUTE_ID">
                            <Columns>
                                <asp:TemplateField HeaderText="S.No">
                                    <ItemTemplate>
                                        <%# ((GridViewRow)Container).RowIndex + 1%>                                .
                                    </ItemTemplate>
                                    <ItemStyle Width="15px" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="RTE_NAME" HeaderText="Route" />
                                <%--<asp:BoundField DataField="FD_FEE_AMT" HeaderText="Fee" />
                                <asp:BoundField DataField="FD_RCV_AMT" HeaderText="Receive" />
                                <asp:BoundField DataField="FD_BALANCE_AMT" HeaderText="Balance" />--%>
                                <asp:BoundField DataField="STS_VALUE" HeaderText="Status" />
                                <asp:BoundField DataField="APR_DATE" HeaderText="Date" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            
                <tr>
                    <td>
                        <asp:GridView ID="gvAmt" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" DataKeyNames="FEE_DEMAND_ID">
                            <Columns>
                             
                                 <asp:TemplateField HeaderText="Demand">
                                                        <ItemTemplate>
                                                          <asp:TextBox id="txtFee" runat="server" CssClass="NumericTextBoxRight" Width="112px" Text='<%# DataBinder.Eval(Container, "DataItem.DEMAND") %>' MaxLength="4">
                                                              </asp:TextBox>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="10px" />
                                                    </asp:TemplateField>                                                																						
											
                                <asp:BoundField DataField="RCV" HeaderText="Receive" />
                                <asp:BoundField DataField="CREDIT" HeaderText="Credit" />
                                <asp:BoundField DataField="BALANCE" HeaderText="Balance" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                 <tr>
                     <td>
                    <asp:Button ID="btnDue" runat="server" Text="Update Due" OnClick="btnDue_Click" Visible="false" />
                         </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="gvUpdatedDemand" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" DataKeyNames="FEE_DEMAND_ID">
                            <Columns>
                             
                                 <asp:BoundField DataField="DEMAND" HeaderText="Demand" />
                                <asp:BoundField DataField="RCV" HeaderText="Receive" />
                                <asp:BoundField DataField="CREDIT" HeaderText="Credit" />
                                <asp:BoundField DataField="BALANCE" HeaderText="Balance" />
                            </Columns>
                        </asp:GridView>
                    </td>

                </tr>
                
                <tr>
                    <th style="width:100px;"> <asp:Label ID="lblRemark" runat="server" Text="Remark:"></asp:Label></th>
                    
                </tr>
               
                <tr>
                    <td >
                      <asp:TextBox ID="txtRemark" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnCancelApprove" runat="server" Text="Cancel-Approve" OnClick="btnCancelApprove_Click" Visible="false" />
                        <asp:Button ID="btnCancel" runat="server" Text="Registraion-Cancel" OnClick="btnCancel_Click" Visible="false" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

