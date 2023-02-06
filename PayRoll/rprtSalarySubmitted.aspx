<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="rprtSalarySubmitted.aspx.cs" Inherits="PayRoll_rprtSalarySubmitted" %>

<%@ Register Src="~/Control/MonthYear.ascx" TagPrefix="uc1" TagName="MonthYear" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="heading" class="heading">
        <h2>Salary Submitted</h2>
        </div>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
    <div id="bodyHeader">
        <table >
                                        <tr >
                                            <td>
                                                Template
                                            </td>
                                            <td>
                                                &nbsp;</td>
                                            <td>
                                                Institution</td>
                                            <td>
                                                &nbsp;</td>
                                            <td  style="height: 20px">
                                                Department</td>
                                            <td  style="width: 4px;" >
                                                &nbsp;</td>
                                            <td style="height: 20px">
                                                Designation</td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td  style="height: 20px">
                                                Employee</td>
                                            <td></td>
                                            <td  style="height: 20px">
                                                Salary By</td>
                                            <td >
                                                &nbsp;</td>
                                            <td  style="height: 20px">
                                                Month & Year</td>
                                            <td  style="height: 20px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td >
                                                <asp:DropDownList ID="ddlTemplate" runat="server" Width="110px">
                                                    <asp:ListItem>Select</asp:ListItem>
                                                    <asp:ListItem Value="1">Earnings</asp:ListItem>
                                                    <asp:ListItem Value="0">Deduction</asp:ListItem>
                                                </asp:DropDownList></td>
                                            <td>
                                                &nbsp;</td>
                                            <td >
                                                <asp:DropDownList ID="ddlInsName" runat="server" AutoPostBack="True" Width="90px"
                                                    OnSelectedIndexChanged="ddlInsName_SelectedIndexChanged">
                                                </asp:DropDownList></td>
                                            <td >
                                                &nbsp;</td>
                                            <td >
                                                <asp:DropDownList ID="ddlDept" runat="server" Width="130px">
                                                </asp:DropDownList></td>
                                            <td >
                                                &nbsp;</td>
                                            <td >
                                                <asp:DropDownList ID="ddlDesig" runat="server" Width="130px">
                                                </asp:DropDownList></td>
                                            <td >
                                                &nbsp;</td>
                                            <td >
 <asp:TextBox ID="txtEmp" runat="server" CssClass="textBox" Width="150px" placeholder="Employee Name or Code" value=""></asp:TextBox>
                        <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" CompletionInterval="500"
                            CompletionSetCount="12" ContextKey="1" EnableCaching="true" MinimumPrefixLength="1"
                            ServiceMethod="GetEmployeeList" ServicePath="~\AutoComplete.asmx" TargetControlID="txtEmp">
                        </ajaxToolkit:AutoCompleteExtender>
                                            </td>
                                              <td >
                                                &nbsp;</td>
                                               <td >
                                                <asp:DropDownList ID="ddlSaleryBy" runat="server" Width="80px">
                                                     <asp:ListItem Value="0" Text="Combined"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="Breakup"></asp:ListItem>
                                                </asp:DropDownList></td>
                                            <td >
                                                &nbsp;</td>
                                            <td  style="height: 20px">
                                               
                                                <uc1:MonthYear runat="server" ID="MonthYear" />
                                            </td>
                                            <td >
                                                &nbsp;</td>
                                            <td  >
                                                <asp:Button ID="btnView" runat="server" CssClass="btnblue" Text="View " OnClick="btnView_Click"
                                                    Font-Overline="False" AccessKey="s" Width="60px"></asp:Button></td>
                                        </tr>
                                    </table>
        </div>
            <div id="bodyContent" style="overflow:scroll;max-height:500px" >
                <asp:GridView ID="gvPayable" runat="server" CssClass="gridDynamic"  ShowFooter="true" >
                                             <Columns>
                                                            <asp:TemplateField HeaderText="S.No">
                                                                <ItemTemplate>
                                                                    <%#((GridViewRow)Container).RowIndex+1 %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                        </asp:GridView>

        </div>
            <div id="bodyFooter">
                <br/>
                   </td>
                   <asp:Button ID="btnExport" runat="server" Text="Export"
                                        OnClick="btnExport_Click" Visible="false" />
                <br/>
        </div>
            </ContentTemplate>
        <Triggers>
                <asp:PostBackTrigger ControlID="btnExport"  />
            </Triggers>
        </asp:UpdatePanel>

</asp:Content>

