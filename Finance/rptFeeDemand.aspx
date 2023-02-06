<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="rptFeeDemand.aspx.cs" Inherits="Finance_BankAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <script lang="javascript" type="text/javascript"> 
         // Client Side Validation Script
    </script>
    <div class="container">
        <div class="heading">
            <h2>
                <!-- Page Heading-->
                Report Fee Demand

            </h2>

        </div>
    
    <div id="cBody">
        <div id="cHead">
           <!-- Content  Header ex: Filters-->
            <div style="background-color:maroon;color:white;padding:5px;text-align:center">Filters</div>

        </div>
        <div id="cCenter">
           <!-- Content Header ex: Grids-->
            <table style="width:100%">
                <tr style="background-color:bisque">
                       <td>
                                                       By Institution</td>
                                                        <td>
                                                            By Batch</td>
                                                        <td>
                                                            By Course</td>
                                                        <td>
                                                            By Branch</td>
                                                        <td>
                                                            By Semester</td>
                                                        <td>
                                                            By Section</td>
                                                    </tr>

                    <tr>
                                                        <td>
                                                            <asp:DropDownList ID="ddlInstitute" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlInstitute_SelectedIndexChanged">
                                                            </asp:DropDownList></td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlBatch" runat="server" >
                                                            </asp:DropDownList></td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlCourse" runat="server"  AutoPostBack="True"
                                                                OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged">
                                                                <asp:ListItem Text="All" Value="."></asp:ListItem>
                                                            </asp:DropDownList></td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlBranch" runat="server">
                                                                  <asp:ListItem Text="All" Value="."></asp:ListItem>
                                                            </asp:DropDownList></td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlSemester" runat="server" >
                                                            </asp:DropDownList></td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlSection" runat="server" >
                                                            </asp:DropDownList></td>
                                                    </tr>
               

                
            </table>
            <table style="width:100%">
                <tr style="background-color:bisque">
                       <td>
                                                       By Gender</td>
                                                        <td>
                                                            By Religion</td>
                                                        <td>
                                                            By Caste</td>
                                                        <td>
                                                            By State</td>
                                                        <td>
                                                            By City</td>
                                                        
                                                    </tr>

                    <tr>
                                                       <td valign="bottom">
                                                            <asp:DropDownList ID="ddlSex" runat="server">
                                                                <asp:ListItem>All</asp:ListItem>
                                                                <asp:ListItem Value="M">Male</asp:ListItem>
                                                                <asp:ListItem Value="F">Female</asp:ListItem>
                                                            </asp:DropDownList></td>
                                                        <td valign="bottom">
                                                            <asp:DropDownList ID="ddlReligion" runat="server" Font-Names="Tahoma">
                                                           
                                                            </asp:DropDownList></td>
                                                        <td valign="bottom">
                                                            <asp:DropDownList ID="ddlCaste" runat="server"  Font-Names="Tahoma">
                                                                
                                                            </asp:DropDownList></td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlState" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlState_SelectedIndexChanged"
                                                                Width="188px">
                                                            </asp:DropDownList></td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlCity" runat="server" >
                                                            </asp:DropDownList></td>
                                                    </tr>
               

                
            </table>
            <table style="width:100%">
                <tr style="background-color:bisque">
                      <td>
                             By Student Status</td>
                                    <td>
                                      By Accommodation Type</td>
                                                   <td>
                                                            By Quota</td>
                                                             <td>
                                                            By Fee Head</td>
                                                        <td>
                                                            By Fee Status</td>
                                                    </tr>

                    <tr>
                                                                                                               <td valign="bottom">
                                                            <asp:DropDownList ID="ddlStatus" runat="server">
                                                            </asp:DropDownList></td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlAcommadation" runat="server">
                                                                <asp:ListItem>All</asp:ListItem>
                                                                <asp:ListItem Value="0">Day Scholar</asp:ListItem>
                                                                <asp:ListItem Value="1">Hosteller</asp:ListItem>
                                                                <asp:ListItem Value="2">Transport</asp:ListItem>
                                                            </asp:DropDownList></td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlQuota" runat="server" >
                                                            </asp:DropDownList></td>
                                                             <td>
                                                            <asp:DropDownList ID="ddlShowType" runat="server">
                                                                <asp:ListItem Value="1">Group Head</asp:ListItem>
                                                                <asp:ListItem Value="0">Main Head</asp:ListItem>
                                                            </asp:DropDownList></td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlFeeStatus" runat="server" >
                                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                                <asp:ListItem Value="1">Complete</asp:ListItem>
                                                                <asp:ListItem Value="2">Paid</asp:ListItem>
                                                                <asp:ListItem Value="3">Due</asp:ListItem>
                                                            </asp:DropDownList></td>
                                                    </tr>
               

                
            </table>
            <table style="width:100%">
                <tr style="background-color:bisque">
                     <td>By Session</td>
                                                         <td>By Sem Type</td>
                                                        <td colspan="2">
                                                            By Enrollment No.</td>
                                                        
                                                       
                                                        <td>
                                                            By Sort</td>
                                                        <td>
                                                            By Print Count</td>
                                                        <td>
                                                            By Print Status</td>
                                                    </tr>

                    <tr>
                                                                                                             
                                                          <td valign="bottom">
                                                            <asp:DropDownList ID="ddlSession" runat="server">
                                                            </asp:DropDownList></td>
                                                          <td valign="bottom">
                                                            <asp:DropDownList ID="ddlSemType" runat="server">
                                                                <asp:ListItem>Select</asp:ListItem>
                                                                <asp:ListItem Value="0">Even</asp:ListItem>
                                                                <asp:ListItem Value="1">Odd</asp:ListItem>
                                                            </asp:DropDownList></td>
                                                        <td>
                                                            <asp:TextBox ID="txtFromEnroll" runat="server" CssClass="textbox" Width="120px"></asp:TextBox></td>
                                                             <td>
                                                            <asp:TextBox ID="txtToEnroll" runat="server" CssClass="textbox" Width="120px"></asp:TextBox></td>
                                                       
                                                        <td>
                                                            <asp:DropDownList ID="ddlSort" runat="server" Width="150px">
                                                                <asp:ListItem>All</asp:ListItem>
                                                                <asp:ListItem Value="INS_ID">Institution</asp:ListItem>
                                                                <asp:ListItem Value="INS_PGM_ID">Course</asp:ListItem>
                                                                <asp:ListItem Value="STUVIEW.STU_MAIN_ID">Enrollment No.</asp:ListItem>
                                                                <asp:ListItem Value="PGM_BRN_ID">Branch</asp:ListItem>
                                                                <asp:ListItem Value="QUOTA_ID">Quota</asp:ListItem>
                                                                <asp:ListItem Value="FEE_SEM_NO">Semester</asp:ListItem>
                                                                <asp:ListItem Value="ADM_TYPE_VALUE">Adm Category</asp:ListItem>
                                                                <asp:ListItem Value="GEN_ID">Gender</asp:ListItem>
                                                                <asp:ListItem Value="STU_STS_ID">Status</asp:ListItem>
                                                                <asp:ListItem Value="PERCENTAGE">Marks</asp:ListItem>
                                                                <asp:ListItem>DIVISION</asp:ListItem>
                                                                <asp:ListItem Value="CAS_ID">Category</asp:ListItem>
                                                                <asp:ListItem Value="FEE_MAIN_HEAD_ID">Fee Head</asp:ListItem>
                                                            </asp:DropDownList></td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlCount" runat="server" Width="120px">
                                                                <asp:ListItem Value="10">10</asp:ListItem>
                                                                <asp:ListItem Value="20">20</asp:ListItem>
                                                                <asp:ListItem Value="30">30</asp:ListItem>
                                                                <asp:ListItem>40</asp:ListItem>
                                                                <asp:ListItem>50</asp:ListItem>
                                                                <asp:ListItem>75</asp:ListItem>
                                                                <asp:ListItem>100</asp:ListItem>
                                                                <asp:ListItem>500</asp:ListItem>
                                                            </asp:DropDownList></td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlPrint" runat="server" Width="120px">
                                                                <asp:ListItem Value="1">Original</asp:ListItem>
                                                                <asp:ListItem Value="0">Duplicate</asp:ListItem>
                                                            </asp:DropDownList></td>
                                                    </tr>
               

               
            </table>
            <div style="text-align:center">
                <br/>
                <asp:Button ID="btnShow" OnClick="btnShow_Click" runat="server" Width="60px" Text="Show"
                                                    CssClass="btnBrown"></asp:Button>
                                                &nbsp;<asp:Button ID="btnExport" runat="server" CssClass="btnBrown" OnClick="btnExport_Click"
                                                    Text="Export to Excel" />&nbsp;<asp:Button ID="btnPrint" runat="server" CssClass="btnBrown"
                                                        OnClick="btnPrint_Click" Text="Print Demand Letter" />

            </div>
        </div>
         <div id="cFooter" style="max-height:400px;overflow:scroll;max-width:1000px">
              <!-- Content Header ex:Buttons-->
              <asp:GridView ID="gvDemand" runat="server" CssClass="gridDynamic" HeaderStyle-CssClass="GVFixedHeader"
                                            Width="97%">
                                            <Columns>
                                                <asp:TemplateField HeaderText="S.No.">
                                                    <ItemTemplate>
                                                        <%# ((GridViewRow)Container).RowIndex + 1%>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="20px" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
        </div>
</div>
</div>

</asp:Content>

