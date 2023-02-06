<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="rptSubmittedSalery.aspx.cs" Inherits="HR_rptSubmittedSalery" %>
<%@ Register Src="../Control/MonthYear.ascx" TagName="MonthYear" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
  <div class="heading">
            <h2>Attandance Submitted</h2>
        </div>
    <div>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                <ProgressTemplate><img src="../Siteimages/loading.gif" alt="loading" /></ProgressTemplate>
            </asp:UpdateProgress>

         
               <div id="page_div_block" runat="server" style="position: absolute; top: 50%; left: 300px; border: solid 5px #808080; padding: 20px; background-color: #000; z-index: 200; color: white; text-align: center; ">

                            <center>Detail</center>
                            <p style="text-align: right">
                                <asp:Button runat="server" Text="Close" OnClick="close_window" ID="btnClose" /></p>
                            <asp:GridView ID="gridView1" runat="server" Width="50%" EmptyDataText="No record found."
                                AutoGenerateColumns="False" CssClass="gridDynamic" HeaderStyle-CssClass="GVFixedHeader"  DataKeyNames="Emp_Id">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No.">
                                        <ItemTemplate>
                                            <%# ((GridViewRow)Container).RowIndex + 1%>
                                        </ItemTemplate>
                                        <ItemStyle Width="20px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Emp_Id" HeaderText="EmplCode">
                                        <ItemStyle HorizontalAlign="Right" Width="60px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Emp_Name" HeaderText="Employee Name">
                                        <ItemStyle Width="180px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="NOD" HeaderText="NOD">
                                        <ItemStyle Width="180px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Insert_date" HeaderText="Date">
                                        <ItemStyle Width="180px" />
                                    </asp:BoundField>

                                </Columns>
                                <HeaderStyle CssClass="GVFixedHeader" />
                            </asp:GridView>
                        </div>
                        
        <table>
            <tr>
                 <td>Institution</td>
                 <td>Department</td>
                 <td>Type</td>
                 <td>Month</td>
                 <td>Date</td>
                 <td>Issue</td>
                <td>Status</td>
                 <td></td>
            </tr>
            <tr>
                <td> <asp:DropDownList ID="ddlInstitution" runat="server" OnSelectedIndexChanged="ddlInstitution_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></td>
                <td> <asp:DropDownList ID="ddlDepartment" runat="server"></asp:DropDownList></td>
                 <td> <asp:DropDownList ID="ddlCodeType" runat="server" Width="105px">
                     <asp:ListItem>Select</asp:ListItem>
                                           <asp:ListItem Value="2">All</asp:ListItem>
                                            <asp:ListItem Value="1">Teaching</asp:ListItem>
                                            <asp:ListItem Value="0">Non-Teaching</asp:ListItem>
                     </asp:DropDownList>
                 </td>
                 <td> <uc2:MonthYear ID="MonthYear1" runat="server" /></td>
                 <td><asp:TextBox ID="txtClosingDate" runat="server"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtClosingDate" Format="dd/MM/yyyy">
                    </ajaxToolkit:CalendarExtender>
                     <td><asp:DropDownList ID="ddlSubmittedStatus" runat="server" Width="100px">
                                                    <asp:ListItem Value="0">All</asp:ListItem>
                                                    <asp:ListItem Value="1">Submitted</asp:ListItem>
                                                    <asp:ListItem Value="2">Non-Submitted</asp:ListItem>
                                                </asp:DropDownList></td>
                 <td><asp:DropDownList ID="ddlStatus" runat="server" Width="105px">
                      <asp:ListItem Value="0">Hold</asp:ListItem>
                      <asp:ListItem Value="1">Issue</asp:ListItem>
                     </asp:DropDownList></td>
                 <td><asp:Button ID="btnProcess" runat="server"  Text="Show" OnClick="btnShow_Click"/> </td>
                
            </tr>
        </table>
       <table>
           <tr>
               <td>
                   <asp:GridView ID="gridView" runat="server" Width="97%" EmptyDataText="No record found."
                                        AutoGenerateColumns="False" CssClass="gridDynamic" HeaderStyle-CssClass="GVFixedHeader"
                                        DataKeyNames="USR_ID" OnRowCommand="gridView_RowCommand">
                                        <Columns>
                                            <asp:TemplateField HeaderText="S.No.">
                                                <ItemTemplate>
                                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                                </ItemTemplate>
                                                <ItemStyle Width="20px" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Emp_Id" HeaderText="EmplCode">
                                                <ItemStyle HorizontalAlign="Right" Width="60px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Emp_Name" HeaderText="Employee Name">
                                                <ItemStyle Width="180px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DEPT_VALUE" HeaderText="Department">
                                                <ItemStyle Width="130px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DES_VALUE" HeaderText="Designation">
                                                <ItemStyle Width="150px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="NOD" HeaderText="Payble Days">
                                            <ItemStyle Width="150px" />
                                            </asp:BoundField>
                                            <asp:CommandField ButtonType="Link" HeaderText="Grid View" SelectText="Detail"  ShowSelectButton="True" />
                                        </Columns>
                                        <HeaderStyle CssClass="GVFixedHeader" />
                                    </asp:GridView>
                     <asp:Button ID="btnPrint" runat="server" CssClass="btnBrown" OnClick="btnPrint_Click"
                                        Text="Print" Width="70px" />&nbsp;
                                    <asp:Button ID="btnExport1" runat="server" CssClass="btnBrown" OnClick="btnExport1_Click"
                                        Text="Export Data" />
                                       

               </td>
           </tr>
           <tr>
               <td>
                                  
               </td>
           </tr>
       </table>
            
        
        </div>
        </div>
</asp:Content>

