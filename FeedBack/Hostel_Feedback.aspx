<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="Hostel_Feedback.aspx.cs" Inherits="FeedBack_Hostel_Feedback" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="heading">
            <h3>FOR HOSTEL RESIDING STUDENTS ONLY
            </h3>
        </div>
    <div>
        <table id="TR1" runat="server">
            <tr>
                <td style="font-size:large;color:red">
                   <strong> <asp:Label ID="lblMsg" runat="server"></asp:Label></strong>
                </td>
            </tr>
        </table>
    <table id="TR2" runat="server">
          
            <tr>
                <td>
                    <asp:GridView ID="gvHostel" runat="server" AutoGenerateColumns="False" GridLines="None"
                                        CssClass="gridDynamic" AlternatingRowStyle-CssClass="alt" Width="95%" DataKeyNames="FAC_QUES_ID">

                                        <Columns>
                                           <asp:TemplateField HeaderText="S.No.">
                                    <ItemTemplate>
                                        <%# ((GridViewRow)Container).RowIndex + 1%>
                                        .
                                    </ItemTemplate>
                                    <ItemStyle Width="20px" />
                                </asp:TemplateField>
                                            <asp:BoundField DataField="FAC_QUES_NAME" HeaderText="Hostel Accomodation">
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
            <td>
                <asp:GridView ID="gvMess" runat="server" AutoGenerateColumns="False" GridLines="None"
                                        CssClass="gridDynamic" AlternatingRowStyle-CssClass="alt" Width="95%" DataKeyNames="FAC_QUES_ID">

                                        <Columns>
                                           <asp:TemplateField HeaderText="S.No.">
                                    <ItemTemplate>
                                        <%# ((GridViewRow)Container).RowIndex + 1%>
                                        .
                                    </ItemTemplate>
                                    <ItemStyle Width="20px" />
                                </asp:TemplateField>
                                            <asp:BoundField DataField="FAC_QUES_NAME" HeaderText="MESS FACILITIES">
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
            <td>
                <asp:GridView ID="gvMedical" runat="server" AutoGenerateColumns="False" GridLines="None"
                                        CssClass="gridDynamic" AlternatingRowStyle-CssClass="alt" Width="95%" DataKeyNames="FAC_QUES_ID">

                                        <Columns>
                                           <asp:TemplateField HeaderText="S.No.">
                                    <ItemTemplate>
                                        <%# ((GridViewRow)Container).RowIndex + 1%>
                                        .
                                    </ItemTemplate>
                                    <ItemStyle Width="20px" />
                                </asp:TemplateField>
                                            <asp:BoundField DataField="FAC_QUES_NAME" HeaderText="MEDICAL FACILITIES">
                                                <ItemStyle Width="400px" />
                                            </asp:BoundField>
                                           
                                           
                                            <asp:TemplateField HeaderText="Answer">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="ddlMedical" runat="server" Width="200px">
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
                <td><B><U>SUGGESTIONS  </B></U></td>
            </tr>
            <tr>
                <td><asp:TextBox ID="txtsugg" runat="server" TextMode="MultiLine"></asp:TextBox></td>
                
            </tr>
            <tr>

                <td><asp:Button ID="txtSave" Text="SAVE" runat="server" OnClick="txtSave_Click" /></td>
            </tr>
            <tr>
                <td><asp:TextBox ID="TextBox1" runat="server"  Visible="false"></asp:TextBox></td>
               
            </tr>
        <tr>
             <td><asp:TextBox ID="TextBox2" runat="server"  Visible="false"></asp:TextBox></td>
              
        </tr>
        <tr>
              <td><asp:TextBox id="TextBox3" runat="server" Visible="false"></asp:TextBox></td>
        </tr>

        </table>
        </div>
</asp:Content>

