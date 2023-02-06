<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="FeeDemand.aspx.cs" Inherits="Finance_BankAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <script lang="javascript" type="text/javascript"> 
         // Client Side Validation Script
    </script>
    <div class="container">
        <div class="heading">
            <h2>
                <!-- Page Heading-->
                Fee Demand
            </h2>

        </div>
    
    <div id="cBody">
        <div id="cHead">
           <!-- Content  Header ex: Filters-->

        </div>
        <div id="cCenter">
           <!-- Content Header ex: Grids-->
            <table style="width:100%">
                <tr>
                    <td style="border-right:2px solid;vertical-align:top" width="20%" vertical-align="top" >
                        <table>
                            <tr>
                                <td>Institute</td>
                                <td><asp:DropDownList runat="server" ID="ddlInstitue" OnSelectedIndexChanged="ddlInstitue_SelectedIndexChanged" AutoPostBack="true" CssClass="width_200"></asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td>Batch</td>
                                <td><asp:DropDownList runat="server" ID="ddlBatch" CssClass="width_200"></asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td>Course</td>
                                <td><asp:DropDownList runat="server" ID="ddlCourse" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged" AutoPostBack="true" CssClass="width_200"></asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td>Branch</td>
                                <td><asp:DropDownList runat="server" ID="ddlBranch" CssClass="width_200"></asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td>Semester</td>
                                <td><asp:DropDownList runat="server" ID="ddlSemester" CssClass="width_200"></asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td>Adm Type</td>
                                <td><asp:DropDownList runat="server" ID="ddladmType" CssClass="width_200">
                                     <asp:ListItem Text="Normal" Value="0"></asp:ListItem>
                                     <asp:ListItem Text="Lateral" Value="1"></asp:ListItem>
                                     <asp:ListItem Text="Transfer" Value="2"></asp:ListItem>
                                     
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td>Fee Structure</td>
                                <td><asp:DropDownList runat="server" ID="ddlFeeStruc" OnSelectedIndexChanged="ddlFeeStruc_SelectedIndexChanged" AutoPostBack="true" CssClass="width_200"></asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td>Fee Template</td>
                                <td><asp:DropDownList runat="server" ID="ddlFeeTemp" CssClass="width_200"></asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td>Fee For</td>
                                <td>
                                    <asp:RadioButtonList runat="server" CssClass="width_200" ID="Rlist">
                                        <asp:ListItem Value="1">Next</asp:ListItem>
                                        <asp:ListItem Value="0">Current</asp:ListItem>
                                        </asp:RadioButtonList>
                                </td>
                               
                            </tr>
                            <tr>
                                <td>Process Rule</td>
                                <td><asp:DropDownList runat="server" ID="ddlProcess" CssClass="width_200"></asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td>Fine Rule</td>
                                <td><asp:DropDownList runat="server" ID="ddlFineRule" CssClass="width_200"></asp:DropDownList></td>
                            </tr>
                             <tr>
                                <td>Enrollment No.</td>
                                <td><asp:TextBox ID="txtEnrol" runat="server" CssClass="width_200"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>Remark</td>
                                <td><asp:TextBox runat="server" ID="txtRemark" CssClass="width_200"></asp:TextBox></td>
                            </tr>
                        </table>
                    </td>
                    <td valign="top">
                        Fee Structure
                        <hr/>
                        <asp:gridview id="gridStruc" runat="server" CssClass="gridDynamic" AutoGenerateColumns="false">
                             <Columns>
                                                                            <asp:TemplateField HeaderText="S.No.">
                                                                                <ItemTemplate>
                                                                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                                </ItemTemplate>
                                                                                <ItemStyle Width="15px" />
                                                                            </asp:TemplateField>
                                                                            <asp:BoundField DataField="FEE_TEMP_ID" HeaderText="Template ID" />
                                                                            <asp:BoundField DataField="FEE_GROUP_HEAD_NAME" HeaderText="Group Head" />
                                                                            <asp:BoundField DataField="FEE_MAIN_HEAD_NAME" HeaderText="Fee Head" FooterText="Total:-" />
                                                                            <asp:BoundField HeaderText="Amount" DataField="FEE_AMT" DataFormatString="{0:N2}" />
                                                                            <asp:BoundField HeaderText="Priority" DataField="FEE_MAIN_HEAD_PRIORITY" />
                                                                            <asp:BoundField DataField="FEE_STRC_SUB_IN_DT" HeaderText="W.E.F" DataFormatString="{0:dd/MM/yyyy}" />
                                                                        </Columns>

                        </asp:gridview>
                    </td>
                </tr>
                </table>
        </div>
         <div id="cFooter">
              <!-- Content Header ex:Buttons-->
             <asp:Button ID="btnDemand" runat="server" Text="Demand" OnClick="btnDemand_Click" /> &nbsp;&nbsp;&nbsp;
             <asp:Button ID="btnRefresh" runat="server" Text="Refresh" OnClick="btnRefresh_Click" />
        </div>
</div>
</div>

</asp:Content>

