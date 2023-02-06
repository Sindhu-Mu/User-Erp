<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PA02_B1_MKS.aspx.cs" Inherits="Appraisal_PA02_B1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>--MU STUDENT'S FEEDBACK</title>
    <link href="../css/Main.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="mngUser1" runat="server">
        </asp:ScriptManager>
        <div class="heading">
            <h2>STUDENT'S FEEDBACK ON <span style="color: red">CURRICULUM & COURSE FACULTY</span>
            </h2>
        </div>
        <div>

            <asp:GridView ID="gvTeacher" runat="server" AutoGenerateColumns="False" GridLines="None"
                CssClass="gridDynamic" AlternatingRowStyle-CssClass="alt" Font-Size="15px" Width="55%" DataKeyNames="BS_MAPP_CODE, USR_ID,TT_PAP_ID">
                <Columns>
                    <asp:TemplateField HeaderText="S.No.">
                        <ItemTemplate>
                            <%# ((GridViewRow)Container).RowIndex + 1%>
                                                        .
                        </ItemTemplate>
                        <ItemStyle Width="30px" />
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Teacher" DataField="EMP_NAME" />
                    <asp:BoundField HeaderText="Paper Code" DataField="PAPER_CODE" />
                    <asp:BoundField HeaderText="Subject" DataField="SUBJECT_NAME" />
                </Columns>
                <SelectedRowStyle BackColor="YellowGreen" />
            </asp:GridView>

        </div>
          <div>&nbsp;</div>
          <div style="font-size:20px;font-weight:bold;" ><h4>Curriculum Feedback</h4></div>
          <div><asp:GridView ID="GridCurriculum" runat="server" AutoGenerateColumns="False" DataKeyNames="PA02_B1_PARAM_ID"
                CssClass="gridDynamic" Font-Size="15px" Width="99%">
                <Columns>
                    <asp:BoundField DataField="PA02_B1_PARAM_ID" HeaderText="S.No.">
                        <ItemStyle Width="5%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="PA02_B1_PARAM_VALUE" HeaderText="Question">
                        <ItemStyle Width="40%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="PA02_B1_PARAM_DESC" HeaderText="Question">
                        <ItemStyle Width="40%" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Answer">
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlMarks" runat="server" Width="200px">
                                <asp:ListItem Text="Select" Value="-1"></asp:ListItem>
                                <asp:ListItem Text="Strongly Agree(अत्याधिक सहमत)" Value="5"></asp:ListItem>
                                <asp:ListItem Text="Mostly Agree(आंशिक रूप से सहमत)" Value="4"></asp:ListItem>
                                <asp:ListItem Text="Average(औसत)" Value="3"></asp:ListItem>
                                <asp:ListItem Text="Disagree(असहमत)" Value="2"></asp:ListItem>
                                <asp:ListItem Text="Completely Disagree(पूरी तरह से असहमत)" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </ItemTemplate>
                        <ItemStyle Width="15%" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView></div>
        <div>&nbsp;</div>
           <div style="font-size:20px;font-weight:bold;" ><h4>Faculty wise Feedback</h4></div>
        <div>
            <asp:GridView ID="gvParameter" runat="server" AutoGenerateColumns="False"
                CssClass="gridDynamic" Font-Size="15px" Width="99%">
                <Columns>
                    <asp:BoundField DataField="PA02_B1_PARAM_ID" HeaderText="S.No.">
                        <ItemStyle Width="5%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="PA02_B1_PARAM_VALUE" HeaderText="Question">
                        <ItemStyle Width="40%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="PA02_B1_PARAM_DESC" HeaderText="Question">
                        <ItemStyle Width="40%" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Answer">
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlMarks" runat="server" Width="200px">
                                <asp:ListItem Text="Select" Value="-1"></asp:ListItem>
                                <asp:ListItem Text="Strongly Agree(अत्याधिक सहमत)" Value="5"></asp:ListItem>
                                <asp:ListItem Text="Mostly Agree(आंशिक रूप से सहमत)" Value="4"></asp:ListItem>
                                <asp:ListItem Text="Average(औसत)" Value="3"></asp:ListItem>
                                <asp:ListItem Text="Disagree(असहमत)" Value="2"></asp:ListItem>
                                <asp:ListItem Text="Completely Disagree(पूरी तरह से असहमत)" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </ItemTemplate>
                        <ItemStyle Width="15%" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        
        <div style="padding-right: 40%; padding-left: 40%; width: 100%;">
            <asp:Button ID="btnSave" Text="Submit and move to next course faculty" runat="server" Height="25px" OnClick="btnSave_Click" />
            <asp:TextBox ID="TextBox1" runat="server" Visible="false"></asp:TextBox>
        </div>

    </form>
</body>
</html>
