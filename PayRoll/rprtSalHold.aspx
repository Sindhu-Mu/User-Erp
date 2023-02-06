<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="rprtSalHold.aspx.cs" Inherits="PayRoll_SalHoldReport" %>

<%@ Register Src="~/Control/MonthYear.ascx" TagPrefix="uc1" TagName="MonthYear" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="content" class="container">
         
        <div id="" class="heading">
           <h2> Salary Monthly Hold</h2>
        </div>
        
        <div id="bodyHeader">
          <table border="0">
                                        <tr  style="text-align:left;">
                                            <th >
                                                For Month<span style="color: #ff0000">*</span></th>
                                            <td>
                                                &nbsp;</td>
                                            <th >
                                                Institution<span style="color: #ff0000">*</span></th>
                                            <td>
                                                &nbsp;</td>
                                            <th >
                                                Department <span style="color: #ff0000">*</span></th>
                                            <td  style="height: 20px">
                                                &nbsp;</td>
                                            <th >
                                                Category <span style="color: #ff0000">*</span></th>
                                            <td>
                                                &nbsp;</td>
                                           
                                            <td >
                                                &nbsp;</td>
                                            <td >
                                            </td>
                                        </tr>
                                        <tr>
                                            <td >
                                               
                                                <uc1:MonthYear runat="server" ID="MonthYear" />

                                            </td>
                                            <td >
                                            </td>
                                            <td >
                                                &nbsp;<asp:DropDownList ID="ddlInsitution" runat="server" Width="90px" AutoPostBack="True"
                                                    OnSelectedIndexChanged="ddlInsitution_SelectedIndexChanged">
                                                </asp:DropDownList></td>
                                            <td >
                                            </td>
                                            <td >
                                                &nbsp;<asp:DropDownList ID="ddlDepartment" runat="server" Width="170px">
                                                </asp:DropDownList></td>
                                            <td >
                                            </td>
                                            <td >
                                                &nbsp;<asp:DropDownList ID="ddlCategory" runat="server" Width="100px">
                                                    <asp:ListItem Value=".">Select</asp:ListItem>
                                                    <asp:ListItem Value="1">Teaching</asp:ListItem>
                                                    <asp:ListItem Value="0">Non-Teaching</asp:ListItem>
                                                </asp:DropDownList></td>
                                            <td >
                                           
                                           
                                                <asp:Button ID="btnView" runat="server" CssClass="btnBrown" Text="View " Font-Overline="False"
                                                    OnClick="btnView_Click"></asp:Button>
                                            </td>
                                        </tr>
                                    </table>
                       </div>
        <div id="bodyCenter">
             <asp:GridView ID="GridShow" runat="server" AutoGenerateColumns="False" Width="97%"
                                            ShowHeader="True" CssClass="gridDynamic" DataKeyNames="TYPE">
                                            <Columns>
                                                <asp:BoundField HeaderText="S#">
                                                    <ItemStyle Width="15px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="EMP_ID" HeaderText="EMP.CODE">
                                                    <ItemStyle Width="70px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="EMP_NAME" HeaderText="NAME">
                                                    <ItemStyle Width="200px" Font-Bold="True" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="DEPT_VALUE" HeaderText="DEPARTMENT">
                                                    <ItemStyle Width="100px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="DES_VALUE" HeaderText="DESIGNATION" />
                                                <asp:BoundField DataField="MONTHVALUE" HeaderText="MONTH"></asp:BoundField>
                                                <asp:BoundField DataField="REASON" HeaderText="REASON">
                                                    <ItemStyle Width="90px" />
                                                </asp:BoundField>
                                            </Columns>
                                            <PagerStyle BorderColor="#FFFFC0" Font-Size="Larger" Font-Underline="True" Wrap="True" />
                                            <SelectedRowStyle BackColor="#99FF33" />
                                            <HeaderStyle ForeColor="Blue" />
                                        </asp:GridView>

        </div>
                        
               
        <div style="text-align:center"><asp:Button ID="btnExport" runat="server" CssClass="btnBrown" Text="Export To Excel" OnClick="btnExport_Click" Visible="false" /></div>
            </div>
              
</asp:Content>

