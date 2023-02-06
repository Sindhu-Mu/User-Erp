<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="Trans_Host_Feedback.aspx.cs" Inherits="FeedBack_Trans_Host_Feedback" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="heading">
            <h3>QUESTIONNAIRE FOR STUDENT SATISFACTION SURVEY
            </h3>
        </div>
    <div>
        <table>
            <tr>
                <td style="color:red;font-size:14px"><strong>Note: If You Are Availing Facility Then Kindly Fill The Below FeedBack.</strong></td>
            </tr>
             <tr>
                <td style="font-size:large;color:red">
                   <strong> <asp:Label ID="lblMsg" runat="server"></asp:Label></strong>
                </td>
            </tr>
        </table>
        <div>
        <table id="TR1" runat="server">
              <tr>
                <td>Bus Route<asp:TextBox ID="txtRoute" runat="server"></asp:TextBox></td>
                <td>Bus Incharge<asp:TextBox ID="txtIncharge" runat="server"></asp:TextBox></td>
            </tr>
        </table>
        <table id="TR2" runat="server">
          
            <tr>
                <td>
                    <asp:GridView ID="gvTransport" runat="server" AutoGenerateColumns="False" GridLines="None"
                                        CssClass="gridDynamic" AlternatingRowStyle-CssClass="alt" Width="95%" DataKeyNames="FAC_QUES_ID">

                                        <Columns>
                                           <asp:TemplateField HeaderText="S.No.">
                                    <ItemTemplate>
                                        <%# ((GridViewRow)Container).RowIndex + 1%>
                                        .
                                    </ItemTemplate>
                                    <ItemStyle Width="50px" />
                                </asp:TemplateField>
                                            <asp:BoundField DataField="FAC_QUES_NAME" HeaderText="FACILITIES">
                                                <ItemStyle Width="400px" />
                                            </asp:BoundField>
                                           
                                           
                                            <asp:TemplateField HeaderText="Answer">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="ddlTransport" runat="server" Width="200px">
                                                        <asp:ListItem Text="Select" Value="-1"></asp:ListItem>
                                                        <asp:ListItem Text="Strongly Agree" Value="5"></asp:ListItem>
                                                        <asp:ListItem Text="Agree" Value="4"></asp:ListItem>
                                                        <asp:ListItem Text="Neutral" Value="3"></asp:ListItem>
                                                        <asp:ListItem Text="Disagree" Value="2"></asp:ListItem>
                                                        <asp:ListItem Text="Strongly Disagree" Value="1"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                                <ItemStyle Width="80px" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                </td>
            </tr>
             <%-- <tr>
                <td><B><U>SUGGESTIONS  </B></U></td>
            </tr>
            <tr>
                <td><asp:TextBox ID="txtSuggest" runat="server" TextMode="MultiLine"></asp:TextBox></td>
                
            </tr>
            <tr>
                <td><asp:Button ID="btnSave" Text="SAVE" runat="server" /></td>
            </tr>
        </table>
            </div>
       <div> <table>
            <tr>
                <td>

                    <asp:GridView ID="gvHostel" runat="server" AutoGenerateColumns="False" GridLines="None"
                                        CssClass="gridDynamic" AlternatingRowStyle-CssClass="alt" Width="95%" Caption="Hostel Accomodation">
                                        <Columns>
                                              <asp:TemplateField HeaderText="S.No.">
                                    <ItemTemplate>
                                        <%# ((GridViewRow)Container).RowIndex + 1%>
                                        .
                                    </ItemTemplate>
                                    <ItemStyle Width="20px" />
                                </asp:TemplateField>
                                            <asp:BoundField DataField="FAC_QUES_NAME" HeaderText="FACILITIES">
                                                <ItemStyle Width="400px" />
                                            </asp:BoundField>
                                           
                                           
                                            <asp:TemplateField HeaderText="Answer">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="ddlHostel" runat="server" Width="200px">
                                                        <asp:ListItem Text="Select" Value="-1"></asp:ListItem>
                                                        <asp:ListItem Text="Strongly Agree" Value="5"></asp:ListItem>
                                                        <asp:ListItem Text="Agree" Value="4"></asp:ListItem>
                                                        <asp:ListItem Text="Neutral" Value="3"></asp:ListItem>
                                                        <asp:ListItem Text="Disagree" Value="2"></asp:ListItem>
                                                        <asp:ListItem Text="Strongly Disagree" Value="1"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                                <ItemStyle Width="80px" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>

                </td>
            </tr>
           <tr>
                <td><hr style="font-size:xx-large; color:red" /></td>
            </tr>
           <tr>
                <td>

                    <asp:GridView ID="gvMess" runat="server" AutoGenerateColumns="False" GridLines="None"
                                        CssClass="gridDynamic" AlternatingRowStyle-CssClass="alt" Width="95%" Caption="Mess Facilities">
                                        <Columns>
                                              <asp:TemplateField HeaderText="S.No.">
                                    <ItemTemplate>
                                        <%# ((GridViewRow)Container).RowIndex + 1%>
                                        .
                                    </ItemTemplate>
                                    <ItemStyle Width="20px" />
                                </asp:TemplateField>
                                            <asp:BoundField DataField="FAC_QUES_NAME" HeaderText="FACILITIES">
                                                <ItemStyle Width="400px" />
                                            </asp:BoundField>
                                           
                                           
                                            <asp:TemplateField HeaderText="Answer">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="ddlMess" runat="server" Width="200px">
                                                        <asp:ListItem Text="Select" Value="-1"></asp:ListItem>
                                                        <asp:ListItem Text="Strongly Agree" Value="5"></asp:ListItem>
                                                        <asp:ListItem Text="Agree" Value="4"></asp:ListItem>
                                                        <asp:ListItem Text="Neutral" Value="3"></asp:ListItem>
                                                        <asp:ListItem Text="Disagree" Value="2"></asp:ListItem>
                                                        <asp:ListItem Text="Strongly Disagree" Value="1"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                                <ItemStyle Width="80px" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>

                </td>
            </tr>
           <tr>
                <td><hr style="font-size:xx-large; color:red" /></td>
            </tr>
           <tr>
                <td>

                    <asp:GridView ID="gvMedical" runat="server" AutoGenerateColumns="False" GridLines="None"
                                        CssClass="gridDynamic" AlternatingRowStyle-CssClass="alt" Width="95%" Caption="Medical Facilities">
                                        <Columns>
                                              <asp:TemplateField HeaderText="S.No.">
                                    <ItemTemplate>
                                        <%# ((GridViewRow)Container).RowIndex + 1%>
                                        .
                                    </ItemTemplate>
                                    <ItemStyle Width="20px" />
                                </asp:TemplateField>
                                            <asp:BoundField DataField="FAC_QUES_NAME" HeaderText="FACILITIES">
                                                <ItemStyle Width="400px" />
                                            </asp:BoundField>
                                           
                                           
                                            <asp:TemplateField HeaderText="Answer">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="ddlMess" runat="server" Width="200px">
                                                        <asp:ListItem Text="Select" Value="-1"></asp:ListItem>
                                                        <asp:ListItem Text="Strongly Agree" Value="5"></asp:ListItem>
                                                        <asp:ListItem Text="Agree" Value="4"></asp:ListItem>
                                                        <asp:ListItem Text="Neutral" Value="3"></asp:ListItem>
                                                        <asp:ListItem Text="Disagree" Value="2"></asp:ListItem>
                                                        <asp:ListItem Text="Strongly Disagree" Value="1"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                                <ItemStyle Width="80px" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>

                </td>
     --%>     

            <tr>
                <td><B><U>SUGGESTIONS  </B></U></td>
            </tr>
            <tr>
                <td><asp:TextBox ID="txtsugg" runat="server" TextMode="MultiLine" style="resize:none" Width="400px"></asp:TextBox></td>
                
            </tr>
            <tr>

                <td><asp:Button ID="txtSave" Text="SAVE" runat="server" OnClick="txtSave_Click" /></td>
            </tr>
            <tr>
                <td><asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Visible="false"></asp:TextBox></td>
            </tr>

        </table>


        </div>
      
    </div>
</asp:Content>

