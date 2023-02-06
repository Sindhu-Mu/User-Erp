<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="StudentIcardOnlyAdd.aspx.cs" Inherits="Academic_StudentIcard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="heading"><h2>Student I Card</h2></div>
    <br/>
    <div id="body_h" style="text-align:center">
        <table style="width:90%;margin:20px;">
                <tr>
                                        <th colspan="1">
                                            Institution<span class="required">*</span></th>
                                        <td>
                                            &nbsp;</td>
                                        <th>
                                            Course<span class="required">*</span></th>
                                        <td>
                                            &nbsp;</td>
                                        <th>
                                            Branch<span class="required">*</span></th>
                                        <td>
                                            &nbsp;</td>
                                        <th>
                                            Batch<span class="required">*</span></th>
                                        <th>
                                        </th>
                                    </tr>
                                    <tr>
                                        <td style="vertical-align: top">
                                            <asp:DropDownList ID="ddlInstitution" runat="server" Width="107px" OnSelectedIndexChanged="ddlInstitution_SelectedIndexChanged"
                                                AutoPostBack="True">
                                            </asp:DropDownList></td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            <asp:DropDownList ID="ddlCourse" runat="server" Width="190px" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged"
                                                AutoPostBack="True">
                                            </asp:DropDownList></td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            <asp:DropDownList ID="ddlBranch" runat="server" Width="173px">
                                            </asp:DropDownList></td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            <asp:DropDownList ID="ddlBatch" runat="server" Width="83px">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th style="vertical-align: top">
                                            Semester<span class="required">*</span></th>
                                        <td>
                                            &nbsp;</td>
                                        <th>
                                            Printed<span class="required">*</span></th>
                                        <td>
                                            &nbsp;</td>
                                        <th>
                                            Enrollment<span class="required">*</span></th>
                                        <td>
                                            &nbsp;</td>
                                        <th>
                                            Counting<span class="required">*</span>
                                        </th>
                                        <th>
                                        </th>
                                    </tr>
                                    <tr>
                                        <td style="vertical-align: top">
                                            <asp:DropDownList ID="ddlSemester" runat="server" Width="100px">
                                            </asp:DropDownList></td>
                                        <td>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBox1" runat="server" Visible="false"></asp:TextBox>
                                            <asp:DropDownList ID="ddlPrinted" runat="server" Width="100px">
                                                <asp:ListItem  Value="1">Yes</asp:ListItem>
                                                 <asp:ListItem Value="0">No</asp:ListItem>

                                            </asp:DropDownList></td>
                                        <td>
                                        </td>
                                        <td>
                                           <asp:TextBox ID="txtStudent" runat="server" Width="250px" ></asp:TextBox>
        <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" CompletionSetCount="12"
                                                        EnableCaching="true" MinimumPrefixLength="1" ServiceMethod="GetStudentList"
                                                        ServicePath="~\AutoComplete.asmx" TargetControlID="txtStudent" ContextKey="1,2,3,4,5,6">
                                                    </ajaxToolkit:AutoCompleteExtender>
        
                                        <td>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlCount" runat="server" Width="80px">
                                                <asp:ListItem>1</asp:ListItem>
                                                <asp:ListItem>2</asp:ListItem>
                                                <asp:ListItem>5</asp:ListItem>
                                                <asp:ListItem>10</asp:ListItem>
                                                <asp:ListItem>20</asp:ListItem>
                                                <asp:ListItem>30</asp:ListItem>
                                                <asp:ListItem>40</asp:ListItem>
                                                <asp:ListItem>50</asp:ListItem>
                                            </asp:DropDownList></td>
                                        <td>
                                           <asp:Button Text="Show" runat="server" id="show" OnClick="show_Click" />
 
                                    </tr>
        
            </table>
      
           </div>
    <br/>
    <div id="body_c" style="text-align:center;margin:20px">
        <asp:GridView runat="server" ID="cardGrid" Width="90%" OnSelectedIndexChanged="cardGrid_SelectedIndexChanged" AutoGenerateColumns="false">
          <Columns>
              <asp:BoundField DataField="SrNo" HeaderText="Sr No" />
              <asp:BoundField DataField="STU_ADM_NO" HeaderText="Enrollment No" />
              <asp:BoundField DataField="STU_NAME" HeaderText="Name" />
          </Columns>

        </asp:GridView>
        </div>
    <div id="body_f" style="text-align:center;margin:20px;" >
        <asp:Button ID="print" runat="server" Text="Print" OnClick="print_Click" PostBackUrl="StudentIcardPrintOnlyAdd.aspx"/> 
        <br />
        <asp:TextBox ID="txtData" runat="server" Visible="false"></asp:TextBox>
        </div>
</asp:Content>

