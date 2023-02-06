<%@ Page Title="" Language="C#"  AutoEventWireup="true" CodeFile="Facility_Survey.aspx.cs" Inherits="FeedBack_Facility_Survey" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../css/Main.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="heading">
            <h3>QUESTIONNAIRE FOR STUDENT SATISFACTION SURVEY
            </h3>
        </div>
    <div>
        <table>
             <tr>
                <td style="font-size:large;color:red">
                   <strong> <asp:Label ID="lblMsg" runat="server"></asp:Label></strong>
                </td>
            </tr>
        </table>
        <table id="TR1" runat="server">
             
            <tr>
                <td>
                    <asp:GridView ID="gvParameter" runat="server" AutoGenerateColumns="False" GridLines="None"
                                        CssClass="gridDynamic" AlternatingRowStyle-CssClass="alt" Width="95%" Caption="HYGIENE FACILITIES">
                                        <Columns>
                                            <asp:BoundField DataField="FAC_QUES_ID" HeaderText="SL.">
                                                <ItemStyle Width="20px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="FAC_QUES_NAME" HeaderText="FACILITIES">
                                                <ItemStyle Width="400px" />
                                            </asp:BoundField>
                                           
                                           
                                            <asp:TemplateField HeaderText="Answer">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="ddlParamMarks" runat="server" Width="200px">
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
                    <asp:GridView ID="gvSports" runat="server" AutoGenerateColumns="False" GridLines="None"
                                        CssClass="gridDynamic" AlternatingRowStyle-CssClass="alt" Width="95%" Caption="SPORTS FACILITIES">
                                        <Columns>
                                            <asp:BoundField DataField="FAC_QUES_ID" HeaderText="SL.">
                                                <ItemStyle Width="20px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="FAC_QUES_NAME" HeaderText="FACILITIES">
                                                <ItemStyle Width="400px" />
                                            </asp:BoundField>
                                           
                                           
                                            <asp:TemplateField HeaderText="Answer">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="ddlSportMarks" runat="server" Width="200px">
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
                    <asp:GridView ID="gvInfra" runat="server" AutoGenerateColumns="False" GridLines="None"
                                        CssClass="gridDynamic" AlternatingRowStyle-CssClass="alt" Width="95%" Caption="INFRASTRUCTUTRE FACILITIES">
                                        <Columns>
                                            <asp:BoundField DataField="FAC_QUES_ID" HeaderText="SL.">
                                                <ItemStyle Width="20px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="FAC_QUES_NAME" HeaderText="FACILITIES">
                                                <ItemStyle Width="400px" />
                                            </asp:BoundField>
                                           
                                           
                                            <asp:TemplateField HeaderText="Answer">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="ddlInfraMarks" runat="server" Width="200px">
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
                    <asp:GridView ID="gvSecurity" runat="server" AutoGenerateColumns="False" GridLines="None"
                                        CssClass="gridDynamic" AlternatingRowStyle-CssClass="alt" Width="95%" Caption="SECURITY FACILITIES">
                                        <Columns>
                                            <asp:BoundField DataField="FAC_QUES_ID" HeaderText="SL.">
                                                <ItemStyle Width="20px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="FAC_QUES_NAME" HeaderText="FACILITIES">
                                                <ItemStyle Width="400px" />
                                            </asp:BoundField>                                          
                                           
                                            <asp:TemplateField HeaderText="Answer">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="ddlSecMarks" runat="server" Width="200px">
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
                                         <asp:GridView ID="gvCafe" runat="server" AutoGenerateColumns="False" GridLines="None"
                                        CssClass="gridDynamic" AlternatingRowStyle-CssClass="alt" Width="95%" Caption="CAFETERIA FACILITIES">
                                        <Columns>
                                            <asp:BoundField DataField="FAC_QUES_ID" HeaderText="SL.">
                                                <ItemStyle Width="20px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="FAC_QUES_NAME" HeaderText="FACILITIES">
                                                <ItemStyle Width="400px" />
                                            </asp:BoundField>
                                           
                                           
                                            <asp:TemplateField HeaderText="Answer">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="ddlCafeMarks" runat="server" Width="200px">
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
                    <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add"/>
                    <asp:TextBox ID="TextBox1" runat="server" Visible="false"></asp:TextBox>
                    <asp:TextBox ID="TextBox2" runat="server" Visible="false"></asp:TextBox>
                    <asp:TextBox ID="TextBox3" runat="server" Visible="false"></asp:TextBox>
                    <asp:TextBox ID="TextBox5" runat="server" Visible="false"></asp:TextBox>
                    <asp:TextBox ID="TextBox4" runat="server" Visible="false"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
        </form>
</body>
</html>


