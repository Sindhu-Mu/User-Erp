<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="Auditattendance.aspx.cs" Inherits="Finance_Auditattendance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <div>
            <h3>
                <span style="color:red"><u>Attendance Report</u></span>
            </h3>
        </div>
    <div style="width:100%;margin-top:10px;" >
                        <table>
                            <tr>
                                <th>Enrollment No.<span class="required">*</span></th>
                                <td style="width: 180px; height: 22px; float: left">
                                    <asp:TextBox ID="txtEnroll" runat="server" Width="180px"></asp:TextBox>

                                </td>
                                <td>
                                    <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click"/></td>
                            </tr>


                        </table>

                    </div>
    <div id="div1" runat="server" style="margin-top:10px;">

        &nbsp; <span style="color:blue"><b><asp:Label ID="lblName" runat="server" Font-Size="18px" Font-Names="Trebuchet MS" Font-Italic="true"></asp:Label></b></span>
        <hr />
          <span style="color:red">Institute:- </span> 
        <b><asp:Label ID="lblInstitute" runat="server" CssClass="label-detail"></asp:Label></b>
         <span style="color:red">Programme :-</span><b><asp:Label ID="lblCourse" runat="server" CssClass="label-detail"></asp:Label></b>
        
       
        <hr />
          </div>
        <div>
           
                        <asp:GridView ID="gvStuAtt" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" Width="600px">
                            <Columns>
                                <asp:TemplateField HeaderText="S.No.">
                                    <ItemTemplate>
                                        <%#((GridViewRow)Container).RowIndex +1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Paper Code" DataField="PAPER_CODE">
                                  
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Held" DataField="HELD" ItemStyle-HorizontalAlign="Center">
                                   
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Present" DataField="PRESENT" ItemStyle-HorizontalAlign="Center">
                                    
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Percentage" DataField="Percentage" ItemStyle-HorizontalAlign="Center">
                                    
                                    </asp:BoundField>

                            </Columns>
                        </asp:GridView>
                   
        </div>
     </div> 
</asp:Content>

